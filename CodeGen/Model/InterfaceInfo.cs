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
        BaseListSyntax _BaseList;
        /// <summary>
        /// Gets the base list syntax for the interface declaration.
        /// </summary>
        /// <value>The base list.</value>
        public BaseListSyntax BaseList {
            get {
                if (_BaseList == null) {
                    var types = SeparatedList<BaseTypeSyntax> (GetBaseTypes ());
                    _BaseList = BaseList (types);
                }
                return _BaseList;
            }
        }

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
                    _InterfaceExtensionsMembers = List<MemberDeclarationSyntax> (MethodInfos.SelectMany (mi => mi.Declarations));
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
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            var interfaceDeclaration = InterfaceDeclaration (Identifier)
                .WithAttributeLists (AttributeLists)
                .WithModifiers (Modifiers)
                .WithBaseList (BaseList)
                .WithMembers (InterfaceMembers)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return interfaceDeclaration;

            var interfaceExtensionsModifiers = SyntaxFactory.TokenList ()
                .Add (SyntaxFactory.Token (SyntaxKind.PublicKeyword))
                .Add (SyntaxFactory.Token (SyntaxKind.StaticKeyword));
            var interfaceExtenstionsDeclaration = SyntaxFactory.ClassDeclaration (Identifier.Text + "Extensions")
                .WithModifiers (interfaceExtensionsModifiers)
                .WithMembers (InterfaceExtensionsMembers);
            yield return interfaceExtenstionsDeclaration;
        }

        IEnumerable<BaseTypeSyntax> GetBaseTypes ()
        {
            if (Element.Descendants (gi + "prerequisite").Any ()) {
                foreach (var prerequisite in Element.Descendants (gi + "prerequisite")) {
                    var type = GirType.ResolveType (prerequisite.Attribute ("name").Value, Element.Document);
                    yield return SimpleBaseType (ParseTypeName (type.FullName));
                }
            } else {
                yield return SimpleBaseType (ParseTypeName (typeof(GISharp.Runtime.IObject).FullName));
            }
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMembers ()
        {
            return PropertyInfos.SelectMany (x => x.Declarations)
                .Concat (VirtualMethodInfos.SelectMany (x => x.Declarations));
        }
    }
}
