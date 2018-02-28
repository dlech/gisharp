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
    public class EnumInfo : TypeDeclarationInfo
    {
        List<EnumMemberInfo> _EnumMemberInfos;
        public IReadOnlyList<EnumMemberInfo> EnumMemberInfos {
            get {
                if (_EnumMemberInfos == null) {
                    _EnumMemberInfos = Element.Elements (gi + "member")
                        .Select (x => new EnumMemberInfo (x, this))
                        .ToList ();
                }
                return _EnumMemberInfos.AsReadOnly ();
            }
        }

        SeparatedSyntaxList<EnumMemberDeclarationSyntax>? _EnumMembers;
        public SeparatedSyntaxList<EnumMemberDeclarationSyntax> EnumMembers {
            get {
                if (!_EnumMembers.HasValue) {
                    _EnumMembers = SeparatedList<EnumMemberDeclarationSyntax> ()
                        .AddRange (EnumMemberInfos.Select (x => x.EnumMemberDeclaration));
                }
                return _EnumMembers.Value;
            }
        }

        public EnumInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "enumeration" && element.Name != gi + "bitfield") {
                throw new ArgumentException ("Requires <enumeration> or <bitfield> element.", nameof(element));
            }
        }

        internal override IEnumerable<BaseInfo> GetChildInfos ()
        {
            return EnumMemberInfos;
        }

        protected override IEnumerable<AttributeListSyntax> GetAttributeLists ()
        {
            foreach (var baseAttr in base.GetAttributeLists ()) {
                yield return baseAttr;
            }

            if (Element.Name == gi + "bitfield") {
                var flagsAttrName = ParseName (typeof(FlagsAttribute).FullName);
                var flagsAttr = Attribute (flagsAttrName);
                yield return AttributeList ().AddAttributes (flagsAttr);
            }

            var errorDomain = Element.Attribute (glib + "error-domain")?.Value;
            if (errorDomain != null) {
                var errorDomainAttrName = ParseName (typeof(GISharp.Runtime.GErrorDomainAttribute).FullName);
                var errorDomainAttrArgListText = string.Format ("(\"{0}\")", errorDomain);
                var errorDomainAttrArgList = ParseAttributeArgumentList (errorDomainAttrArgListText);
                var errorDomainAttr = Attribute (errorDomainAttrName)
                    .WithArgumentList (errorDomainAttrArgList);
                yield return AttributeList ().AddAttributes (errorDomainAttr);
            }
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            EnumDeclarationSyntax enumDeclaration;
            ClassDeclarationSyntax enumExtenstionsDeclaration;

            try {
                enumDeclaration = EnumDeclaration (Identifier)
                    .WithModifiers (Modifiers)
                    .WithAttributeLists (AttributeLists)
                    .WithMembers (EnumMembers)
                    .WithLeadingTrivia (DocumentationCommentTriviaList);

                // Methods in an enum are not allowed, so using extension methods instead.
                enumExtenstionsDeclaration = ClassDeclaration (Identifier + "Domain")
                    .AddModifiers (
                        Token (SyntaxKind.PublicKeyword),
                        Token (SyntaxKind.StaticKeyword))
                    .WithMembers (List<MemberDeclarationSyntax> ().AddRange (GetExtensionMembers ()));
            } catch (Exception ex) {
                Console.WriteLine("Skipping {0} ({1}) due to error: {2}",
                    QualifiedName, Element.Name.LocalName, ex.Message);
                yield break;
            }

            yield return enumDeclaration;
            // only create a class if there are members
            if (enumExtenstionsDeclaration.Members.Any ()) {
                yield return enumExtenstionsDeclaration;
            }
        }

        IEnumerable<MemberDeclarationSyntax> GetExtensionMembers()
        {
            return GTypeMembers.Concat(MethodInfos.SelectMany(x => x.AllDeclarations));
        }
    }
}
