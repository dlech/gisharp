// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class AliasExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR alias
        /// </summary>
        public static StructDeclarationSyntax GetStructDeclaration(this Alias alias)
        {
            var identifier = alias.ManagedName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(UnsafeKeyword), Token(PartialKeyword))
                .WithLeadingTrivia(alias.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        public static ClassDeclarationSyntax GetClassDeclaration(this Alias alias)
        {
            var identifier = alias.ManagedName;
            return ClassDeclaration(identifier)
                .WithModifiers(TokenList(
                    alias.GetInheritanceModifiers(Token(SealedKeyword))
                    .Prepend(Token(PublicKeyword))
                    .Append(Token(UnsafeKeyword))
                    .Append(Token(PartialKeyword))
                ))
                .AddBaseListTypes(SimpleBaseType(ParseTypeName(alias.Type.GetManagedType())))
                .WithLeadingTrivia(alias.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Alias alias)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(alias.Constants.GetMemberDeclarations())
                .AddRange(alias.Fields.GetStructDeclaration(forUnmanagedStruct: false).Members)
                .AddRange(alias.ManagedProperties.GetMemberDeclarations())
                .AddRange(alias.Functions.GetMemberDeclarations())
                .AddRange(alias.Methods.GetMemberDeclarations());
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Alias alias)
        {
            var members = List<MemberDeclarationSyntax>()
                .Add(alias.Fields.GetStructDeclaration().AddModifiers(Token(NewKeyword)))
                .AddRange(alias.Constants.GetMemberDeclarations())
                .AddRange(alias.ManagedProperties.GetMemberDeclarations())
                .AddIf(!alias.IsCustomDefaultConstructor, () => alias.GetDefaultConstructor())
                .AddRange(alias.Constructors.GetMemberDeclarations())
                .AddRange(alias.Functions.GetMemberDeclarations())
                .AddRange(alias.Methods.GetMemberDeclarations());

            return members;
        }
    }
}
