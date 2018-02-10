using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Model
{
    /// <summary>
    /// Wraps elements from a fixed up .gir file that declare a class.
    /// </summary>
    public class InterfaceInfo : TypeDeclarationInfo
    {
        /// <summary>
        /// Gets the prerequisite types defined for this interface
        /// </summary>
        IReadOnlyList<Type> Prerequisites => _Prerequisites.Value;
        readonly Lazy<IReadOnlyList<Type>> _Prerequisites;

        /// <summary>
        /// Gets the base list syntax for the interface declaration.
        /// </summary>
        /// <value>The base list.</value>
        public BaseListSyntax BaseList => _BaseList.Value;
        readonly Lazy<BaseListSyntax> _BaseList;

        /// <summary>
        /// Gets the interface declaration (without any members)
        /// </summary>
        public InterfaceDeclarationSyntax InterfaceDeclaration => _InterfaceDeclaration.Value;
        readonly Lazy<InterfaceDeclarationSyntax> _InterfaceDeclaration;

        /// <summary>
        /// Gets the interface static class declaration (without any members)
        /// </summary>
        public ClassDeclarationSyntax InterfaceExtensionsDeclaration => _InterfaceExtensionsDeclaration.Value;
        readonly Lazy<ClassDeclarationSyntax> _InterfaceExtensionsDeclaration;

        /// <summary>
        /// Gets a list of all of the members of <see cref="InterfaceDeclaration"/>
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> InterfaceMembers => _InterfaceMembers.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _InterfaceMembers;

        /// <summary>
        /// Gets a list of all of the members of <see cref="InterfaceExtensionsDeclaration"/>
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> InterfaceExtensionsMembers => _InterfaceExtensionsMembers.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _InterfaceExtensionsMembers;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceInfo"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="declaringMember">Declaring member.</param>
        /// <exception cref="ArgumentException">If the element is not an element that declares an interface.</exception>
        public InterfaceInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "interface") {
                throw new ArgumentException ("Requires <gi:interface> element.", nameof(element));
            }

            _BaseList = new Lazy<BaseListSyntax>(() => BaseList(SeparatedList(GetBaseTypes())));
            _InterfaceDeclaration = new Lazy<InterfaceDeclarationSyntax>(GetInterfaceDeclaration);
            _InterfaceExtensionsDeclaration = new Lazy<ClassDeclarationSyntax>(GetInterfaceExtensionsDeclaration);
            _InterfaceMembers = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetInterfaceMembers()));
            _InterfaceExtensionsMembers = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetInterfaceExtensionsMembers()));
            _Prerequisites = new Lazy<IReadOnlyList<Type>>(() => GetPrerequisites().ToList().AsReadOnly());
        }

        IEnumerable<Type> GetPrerequisites()
        {
            foreach (var p in Element.Elements(gi + "prerequisite")) {
                yield return GirType.ResolveType(p.Attribute("name").AsString(), Element.Document);
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            InterfaceDeclarationSyntax interfaceDeclaration;
            ClassDeclarationSyntax interfaceExtensionsDeclaration;

            try {
                interfaceDeclaration = InterfaceDeclaration.WithMembers(InterfaceMembers);
                interfaceExtensionsDeclaration = InterfaceExtensionsDeclaration.WithMembers(InterfaceExtensionsMembers);
            } catch (Exception ex) {
                Console.WriteLine($"Skipping {QualifiedName} due to error: {ex.Message}");
                yield break;
            }

            yield return interfaceDeclaration;
            yield return interfaceExtensionsDeclaration;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists()
        {
            return base.GetAttributeLists().Concat(GetInterfaceAttributeLists());
        }

        IEnumerable<AttributeListSyntax> GetInterfaceAttributeLists()
        {
            // Create an attribute for the instantiable prerequisite type
            // (there should only be zero or one even though this is a for loop)
            foreach (var p in Prerequisites.Where(x => !x.IsInterface)) {
                var attrName = ParseName(typeof(GISharp.Runtime.GInterfacePrerequisiteAttribute).FullName);
                var typeArg = AttributeArgument(ParseExpression($"typeof({p.FullName})"));
                var attr = Attribute(attrName).AddArgumentListArguments(typeArg);
                yield return AttributeList().AddAttributes(attr);
            }
        }

        // gets a list of all base interfaces (prerequisites in GLib terms)
        IEnumerable<BaseTypeSyntax> GetBaseTypes ()
        {
            if (Element.Descendants (gi + "prerequisite").Any ()) {
                foreach (var prerequisite in Element.Descendants (gi + "prerequisite")) {
                    var type = GirType.ResolveType (prerequisite.Attribute ("name").Value, Element.Document);
                    yield return SimpleBaseType (ParseTypeName (type.FullName));
                }
            }
        }

        // gets the interface declaration (without any members)
        InterfaceDeclarationSyntax GetInterfaceDeclaration()
        {
            var declaration = InterfaceDeclaration("I" + Identifier.Text)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
            if (BaseList.ChildNodes().Any()) {
                declaration = declaration.WithBaseList(BaseList);
            }
            return declaration;
        }

        // gets the interface static class declaration (without any members)
        ClassDeclarationSyntax GetInterfaceExtensionsDeclaration()
        {
            var modifiers = TokenList()
                .Add(Token(SyntaxKind.PublicKeyword))
                .Add(Token(SyntaxKind.StaticKeyword));
            var declaration = ClassDeclaration(Identifier)
                .WithModifiers(modifiers);
            return declaration;
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMembers ()
        {
            return PropertyInfos.SelectMany (x => x.AllDeclarations)
                .Concat (VirtualMethodInfos.SelectMany (x => x.AllDeclarations));
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceExtensionsMembers()
        {
            return MethodInfos.SelectMany(x => x.AllDeclarations);
        }
    }
}
