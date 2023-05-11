// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System.Linq;
using System.Runtime.InteropServices;
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
            var identifier = union.GirName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(UnsafeKeyword), Token(PartialKeyword))
                .AddAttributeLists(
                    AttributeList()
                        .AddAttributes(
                            Attribute(ParseName(typeof(StructLayoutAttribute).FullName))
                                .AddArgumentListArguments(
                                    AttributeArgument(
                                        ParseExpression(
                                            $"{typeof(LayoutKind)}.{nameof(LayoutKind.Explicit)}"
                                        )
                                    )
                                )
                        )
                )
                .WithLeadingTrivia(union.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR union
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Union union)
        {
            var layoutKindAttrList = AttributeList()
                .AddAttributes(
                    Attribute(ParseName(typeof(FieldOffsetAttribute).FullName))
                        .AddArgumentListArguments(
                            AttributeArgument(
                                LiteralExpression(NumericLiteralExpression, Literal(0))
                            )
                        )
                );

            return List<MemberDeclarationSyntax>()
                .AddRange(union.Constants.GetMemberDeclarations())
                .AddRange(
                    List(
                        union.Fields
                            .GetStructDeclaration(forUnmanagedStruct: false)
                            .Members.Select(
                                x =>
                                    x.WithoutLeadingTrivia()
                                        .AddAttributeLists(layoutKindAttrList)
                                        .WithLeadingTrivia(x.GetLeadingTrivia())
                            )
                    )
                )
                .AddRange(union.ManagedProperties.GetMemberDeclarations())
                .AddRange(union.Functions.GetMemberDeclarations())
                .AddRange(union.Methods.GetMemberDeclarations());
        }
    }
}
