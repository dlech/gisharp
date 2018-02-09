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

        SyntaxList<MemberDeclarationSyntax>? _InterfaceMembers;
        public SyntaxList<MemberDeclarationSyntax> InterfaceMembers {
            get {
                if (!_InterfaceMembers.HasValue) {
                    _InterfaceMembers = List<MemberDeclarationSyntax> (GetInterfaceMembers ());
                }
                return _InterfaceMembers.Value;
            }
        }

        SyntaxList<MemberDeclarationSyntax>? _InterfaceExtensionsMembers;
        public SyntaxList<MemberDeclarationSyntax> InterfaceExtensionsMembers {
            get {
                if (!_InterfaceExtensionsMembers.HasValue) {
                    _InterfaceExtensionsMembers = List<MemberDeclarationSyntax> (MethodInfos.SelectMany (mi => mi.AllDeclarations));
                }
                return _InterfaceExtensionsMembers.Value;
            }
        }

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
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            InterfaceDeclarationSyntax interfaceDeclaration;
            ClassDeclarationSyntax interfaceExtensionsDeclaration;

            try {
                interfaceDeclaration = InterfaceDeclaration.WithMembers(InterfaceMembers);

                var interfaceExtensionsModifiers = TokenList ()
                    .Add (Token (SyntaxKind.PublicKeyword))
                    .Add (Token (SyntaxKind.StaticKeyword));
                interfaceExtensionsDeclaration = ClassDeclaration (Identifier)
                    .WithModifiers (interfaceExtensionsModifiers)
                    .WithMembers (InterfaceExtensionsMembers);
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
            // TODO: this should probably be omitted when there are base interfaces
            // since the attribute can be inherited
            var attrName = ParseName(typeof(GISharp.Runtime.GInterfacePrerequisiteAttribute).FullName);
            // TODO: this can probably be a type other than GObject, however if
            // the GIR XML doesn't specify a type, GObject should be the default
            var prerequisiteTypeName = typeof(GISharp.GObject.Object).FullName;
            var typeArg = AttributeArgument(ParseExpression($"typeof({prerequisiteTypeName})"));
            var attr = Attribute(attrName).AddArgumentListArguments(typeArg);
            yield return AttributeList().AddAttributes(attr);
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

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMembers ()
        {
            return PropertyInfos.SelectMany (x => x.AllDeclarations)
                .Concat (VirtualMethodInfos.SelectMany (x => x.AllDeclarations));
        }
    }
}
