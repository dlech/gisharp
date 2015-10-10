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
        SyntaxList<MemberDeclarationSyntax>? _InterfaceMembers;
        public SyntaxList<MemberDeclarationSyntax> InterfaceMembers {
            get {
                if (!_InterfaceMembers.HasValue) {
                    _InterfaceMembers = List<MemberDeclarationSyntax> (GetInterfaceMembers ());
                }
                return _InterfaceMembers.Value;
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
                .WithMembers (InterfaceMembers)
                .WithLeadingTrivia (DocumentationCommentTriviaList);
            yield return interfaceDeclaration;
        }

        IEnumerable<MemberDeclarationSyntax> GetInterfaceMembers ()
        {
            foreach (var method in MethodInfos) {
                var methodDeclaration = MethodDeclaration (
                    method.ManagedReturnParameterInfo.TypeInfo.Type,
                    method.Identifier)
                    .WithAttributeLists (method.AttributeLists)
                    .WithParameterList (method.ParameterList)
                    .WithSemicolonToken (Token (SyntaxKind.SemicolonToken))
                    .WithLeadingTrivia (method.DocumentationCommentTriviaList);
                yield return methodDeclaration;
            }
        }
    }
}
