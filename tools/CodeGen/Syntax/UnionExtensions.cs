// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class UnionExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR union
        /// </summary>
        public static StructDeclarationSyntax GetStructDeclaration(this Union union)
        {
            var identifier = union.ManagedName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(PartialKeyword))
                .WithLeadingTrivia(union.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR union
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Union union)
        {
            return List<MemberDeclarationSyntax>();
        }
    }
}
