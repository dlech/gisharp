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
            var any = false;
            foreach (var p in Element.Elements(gi + "prerequisite")) {
                yield return GirType.ResolveType(p.Attribute("name").AsString(), Element.Document);
                any = true;
            }
            if (!any) {
                // use GObject as the default if the GIR did not define any prerequisites
                yield return typeof(GISharp.GObject.Object);
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
                Console.WriteLine("Skipping {0} ({1}) due to error: {2}",
                    QualifiedName, Element.Name.LocalName, ex.Message);
                yield break;
            }

            yield return interfaceDeclaration;
            yield return interfaceExtensionsDeclaration;
        }

        // gets a list of all base interfaces (prerequisites in GLib terms)
        IEnumerable<BaseTypeSyntax> GetBaseTypes()
        {
            foreach (var p in Prerequisites) {
                var typeName = p.FullName;
                if (!p.IsInterface) {
                    typeName = string.Format("{0}<{1}>",
                        typeof(GISharp.Runtime.GInterface<>).FullName.TrimEnd('`', '1'),
                        typeName);
                }
                yield return SimpleBaseType(ParseName(typeName));
            }
        }

        // gets the interface declaration (without any members)
        InterfaceDeclarationSyntax GetInterfaceDeclaration()
        {
            var declaration = InterfaceDeclaration("I" + Identifier.Text)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers)
                .WithBaseList(BaseList)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
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
            return PropertyInfos.SelectMany(x => x.InterfaceDeclarations)
                .Concat (VirtualMethodInfos.SelectMany (x => x.AllDeclarations));
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceExtensionsMembers()
        {
            return GTypeMembers
                .Concat(ConstantInfos.SelectMany(x => x.AllDeclarations))
                .Concat(MethodInfos.SelectMany(x => x.AllDeclarations));
        }
    }
}
