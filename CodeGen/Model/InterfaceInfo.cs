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
        Lazy<BaseListSyntax> _BaseList;

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
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            InterfaceDeclarationSyntax interfaceDeclaration;
            ClassDeclarationSyntax interfaceExtenstionsDeclaration;

            try {
                interfaceDeclaration = InterfaceDeclaration ("I" + Identifier.Text)
                    .WithAttributeLists (AttributeLists)
                    .WithModifiers (Modifiers)
                    .WithMembers (InterfaceMembers)
                    .WithLeadingTrivia (DocumentationCommentTriviaList);
                if (BaseList.ChildNodes().Any()) {
                    interfaceDeclaration = interfaceDeclaration.WithBaseList(BaseList);
                }

                var interfaceExtensionsModifiers = TokenList ()
                    .Add (Token (SyntaxKind.PublicKeyword))
                    .Add (Token (SyntaxKind.StaticKeyword));
                interfaceExtenstionsDeclaration = ClassDeclaration (Identifier)
                    .WithModifiers (interfaceExtensionsModifiers)
                    .WithMembers (InterfaceExtensionsMembers);
            } catch (Exception ex) {
                Console.WriteLine ("Skipping {0} due to error {1}",
                                   QualifiedName, ex.Message);
                yield break;
            }

            yield return interfaceDeclaration;
            yield return interfaceExtenstionsDeclaration;
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

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMembers ()
        {
            return PropertyInfos.SelectMany (x => x.AllDeclarations)
                .Concat (VirtualMethodInfos.SelectMany (x => x.AllDeclarations));
        }
    }
}
