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
    public class StructInfo : TypeDeclarationInfo
    {
        SyntaxList<MemberDeclarationSyntax>? _StructMembers;
        public SyntaxList<MemberDeclarationSyntax> StructMembers {
            get {
                if (!_StructMembers.HasValue) {
                    _StructMembers = List (GetStructMemberDeclarations ());
                }
                return _StructMembers.Value;
            }
        }

        public StructInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "alias" && element.Name != gi + "record" && element.Name != gi + "union") {
                throw new ArgumentException ("Requires <alias>, <record> or <union> element.", nameof(element));
            }
            if (element.Name == gi + "record" && element.Attribute (gs + "opaque") != null) {
                throw new ArgumentException ("<record> element must not be opaque.", nameof(element));
            }
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }
            var structLayoutAttrName = ParseName (typeof(StructLayoutAttribute).FullName);
            var layoutKind = (Element.Name == gi + "union") ? LayoutKind.Explicit : LayoutKind.Sequential;
            var structLayoutAttrArgListText = string.Format ("({0}.{1})", typeof(LayoutKind).FullName, layoutKind);
            var structLayoutAttrArgList = ParseAttributeArgumentList (structLayoutAttrArgListText);
            var structLayoutAttr = Attribute (structLayoutAttrName)
                .WithArgumentList (structLayoutAttrArgList);
            yield return AttributeList ().AddAttributes (structLayoutAttr);
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }
            yield return Token (SyntaxKind.PartialKeyword);
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetDeclarations ()
        {
            MemberDeclarationSyntax structDeclaration;
            try {
                structDeclaration = StructDeclaration (Identifier)
                    .WithModifiers (Modifiers)
                    .WithMembers (StructMembers)
                    .WithAttributeLists (AttributeLists)
                    .WithLeadingTrivia (DocumentationCommentTriviaList);
            } catch (Exception ex) {
                Console.WriteLine ("Skipping {0} due to exception: {1}",
                                   QualifiedName, ex.Message);
                yield break;
            }
            yield return structDeclaration;
        }

        IEnumerable<MemberDeclarationSyntax> GetStructMemberDeclarations ()
        {
            return NestedTypeInfos.SelectMany (x => x.Declarations)
                .Concat(FieldInfos.SelectMany (x => x.Declarations))
                .Concat (MethodInfos.SelectMany (x => x.Declarations));
        }
    }
}
