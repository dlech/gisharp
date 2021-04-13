// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ConstantExtensions
    {
        /// <summary>
        /// Gets a C# field declaration for a GIR constant
        /// </summary>
        public static FieldDeclarationSyntax GetDeclaration(this Constant constant)
        {
            var type = constant.Type.GetManagedType();
            if (type == "GISharp.Lib.GLib.Utf8") {
                type = "string";
            }

            var value = GetValueAsLiteralExpression(type, constant.Value);
            var variable = VariableDeclarator(constant.ManagedName)
                .WithInitializer(EqualsValueClause(value));
            var variableDeclaration = VariableDeclaration(ParseTypeName(type))
                .AddVariables(variable);

            var syntax = FieldDeclaration(variableDeclaration)
                .WithModifiers(constant.GetCommonAccessModifiers().Add(Token(ConstKeyword)))
                .WithAttributeLists(constant.GetCommonAttributeLists())
                .WithLeadingTrivia(constant.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        static LiteralExpressionSyntax GetValueAsLiteralExpression(string type, string value)
        {
            return type switch {
                "bool" => value switch {
                    "true" => LiteralExpression(TrueLiteralExpression),
                    "false" => LiteralExpression(FalseLiteralExpression),
                    _ => throw new ArgumentException($"Unknown bool constant value '{value}'", value),
                },
                "byte" => LiteralExpression(NumericLiteralExpression, Literal(byte.Parse(value))),
                "sbyte" => LiteralExpression(NumericLiteralExpression, Literal(sbyte.Parse(value))),
                "short" => LiteralExpression(NumericLiteralExpression, Literal(short.Parse(value))),
                "ushort" => LiteralExpression(NumericLiteralExpression, Literal(ushort.Parse(value))),
                "int" => LiteralExpression(NumericLiteralExpression, Literal(int.Parse(value))),
                "uint" => LiteralExpression(NumericLiteralExpression, Literal(uint.Parse(value))),
                "long" => LiteralExpression(NumericLiteralExpression, Literal(long.Parse(value))),
                "ulong" => LiteralExpression(NumericLiteralExpression, Literal(ulong.Parse(value))),
                "float" => LiteralExpression(NumericLiteralExpression, Literal(float.Parse(value))),
                "double" => LiteralExpression(NumericLiteralExpression, Literal(double.Parse(value))),
                "string" => LiteralExpression(StringLiteralExpression, Literal(value)),
                _ => throw new ArgumentException($"Bad constant type: {type}", nameof(type)),
            };
        }

        /// <summary>
        /// Gets the member declarations for the constants, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Constant> constants)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var constant in constants) {
                try {
                    list = list.Add(constant.GetDeclaration());
                }
                catch (Exception ex) {
                    constant.LogException(ex);
                }
            }

            return list;
        }
    }
}
