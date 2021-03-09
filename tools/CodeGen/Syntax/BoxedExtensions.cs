// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class BoxedExtensions
    {
        /// <summary>
        /// Gets the C# class declaration for a GIR boxed
        /// </summary>
        public static ClassDeclarationSyntax GetClassDeclaration(this Boxed boxed)
        {
            var identifier = boxed.ManagedName;

            var syntax = ClassDeclaration(identifier)
                .WithModifiers(TokenList(
                    boxed.GetInheritanceModifiers(Token(SealedKeyword))
                    .Prepend(Token(PublicKeyword))
                    .Append(Token(UnsafeKeyword))
                    .Append(Token(PartialKeyword))
                ))
                .WithBaseList(boxed.GetBaseList())
                .WithAttributeLists(boxed.GetGTypeAttributeLists())
                .WithLeadingTrivia(boxed.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        static BaseListSyntax GetBaseList(this Boxed boxed)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(ParseTypeName("GISharp.Lib.GObject.Boxed")))
                .AddRange(boxed.Functions.GetBaseListTypes())
                .AddRange(boxed.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Boxed boxed)
        {
            var fieldStructModifiers = new List<SyntaxToken>();

            var members = List<MemberDeclarationSyntax>()
                .Add(boxed.GetGTypeFieldDeclaration())
                .Add(boxed.Fields.GetStructDeclaration().AddModifiers(fieldStructModifiers.ToArray()))
                .AddRange(boxed.Constants.GetMemberDeclarations())
                .AddRange(boxed.ManagedProperties.GetMemberDeclarations())
                .Add(boxed.GetDefaultConstructor())
                .AddRange(boxed.Constructors.GetMemberDeclarations())
                .AddRange(boxed.Functions.GetMemberDeclarations())
                .AddRange(boxed.Methods.GetMemberDeclarations());

            return members;
        }
    }
}
