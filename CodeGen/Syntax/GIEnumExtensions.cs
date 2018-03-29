using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class GIEnumExtensions
    {
        /// <summary>
        /// Gets the C# enum declaration for a GIR enumeration
        /// </summary>
        public static EnumDeclarationSyntax GetEnumDeclaration(this GIEnum @enum)
        {
            return EnumDeclaration(@enum.ManagedName)
                .AddModifiers(Token(PublicKeyword))
                .WithAttributeLists(@enum.GetEnumAttributeLists())
                .WithLeadingTrivia(@enum.Doc.GetDocCommentTrivia());
        }

        static SyntaxList<AttributeListSyntax> GetEnumAttributeLists(this GIEnum @enum)
        {
            var list = @enum.GetGTypeAttributeLists();

            if (@enum is Bitfield) {
                var flagsAttribute = Attribute(ParseName(typeof(FlagsAttribute).FullName));
                list = list.Add(AttributeList().AddAttributes(flagsAttribute));
            }

            if (@enum.ErrorDomain != null) {
                var attrName = ParseName(typeof(GErrorDomainAttribute).FullName);
                var domainArg = ParseExpression($"\"{@enum.ErrorDomain}\"");
                var domainAttribute = Attribute(attrName)
                    .AddArgumentListArguments(AttributeArgument(domainArg));
                list = list.Add(AttributeList().AddAttributes(domainAttribute));
            }

            return list;
        }

        /// <summary>
        /// Gets the C# enum member declarations for a GIR enumeration
        /// </summary>
        public static SeparatedSyntaxList<EnumMemberDeclarationSyntax> GetEnumMembers(this GIEnum @enum)
        {
            var members = @enum.Members.Select(x => x.GetDeclaration()
                .WithLeadingTrivia(x.Doc.GetDocCommentTrivia()));
            return SeparatedList(members);
        }

        /// <summary>
        /// Gets the C# extension class declaration for a GIR enumeration
        /// </summary>
        public static ClassDeclarationSyntax GetExtClassDeclaration(this GIEnum @enum)
        {
            var name = @enum.ManagedName +
                (@enum.ErrorDomain == null ? "Extensions" : "Domain");

            return ClassDeclaration(name)
                .AddModifiers(Token(PublicKeyword), Token(PartialKeyword));
        }

        /// <summary>
        /// Gets the C# extension class member declarations for a GIR enumeration
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetExtClassMembers(this GIEnum @enum)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddRange(@enum.Constants.GetMemberDeclarations())
                .AddRange(@enum.ManagedProperties.GetMemberDeclarations())
                .AddRange(@enum.Functions.GetMemberDeclarations())
                .AddRange(@enum.Methods.GetMemberDeclarations());

            if (@enum.GTypeName != null) {
                members = members.Insert(0, @enum.GetGTypeFieldDeclaration());
            }

            return List(members);
        }
    }
}
