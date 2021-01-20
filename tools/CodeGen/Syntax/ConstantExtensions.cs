// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
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
            var type = constant.Type.ManagedType;
            if (type == typeof(Utf8)) {
                type = typeof(string);
            }

            var value = GetValueAsLiteralExpression(type.FullName, constant.Value);
            var variable = VariableDeclarator(constant.ManagedName)
                .WithInitializer(EqualsValueClause(value));
            var variableDeclaration = VariableDeclaration(type.ToSyntax())
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
            string message;

            switch (type) {
            case "bool":
            case "System.Boolean":
                switch (value) {
                case "true":
                    return LiteralExpression(TrueLiteralExpression);
                case "false":
                    return LiteralExpression(FalseLiteralExpression);
                default:
                    message = $"Unknown bool constant value '{value}'";
                    throw new ArgumentException(message, value);
                }
            case "byte":
            case "System.Byte":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(byte.Parse(value)));
            case "sbyte":
            case "System.SByte":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(sbyte.Parse(value)));
            case "short":
            case "System.Int16":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(short.Parse(value)));
            case "ushort":
            case "System.UInt16":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(ushort.Parse(value)));
            case "int":
            case "System.Int32":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(int.Parse(value)));
            case "uint":
            case "System.Uint32":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(uint.Parse(value)));
            case "long":
            case "System.Int64":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(long.Parse(value)));
            case "ulong":
            case "System.UInt64":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(ulong.Parse(value)));
            case "float":
            case "System.Float":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(float.Parse(value)));
            case "double":
            case "System.Double":
                return LiteralExpression(NumericLiteralExpression,
                    Literal(double.Parse(value)));
            case "string":
            case "System.String":
                return LiteralExpression(StringLiteralExpression,
                    Literal(value));
            default:
                message = $"Bad constant type: {type}";
                throw new ArgumentException(message, nameof(type));
            }
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
