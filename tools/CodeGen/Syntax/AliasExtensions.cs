// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System.Collections.Generic;
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
        /// Gets the C# class member declarations for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Alias alias)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddIf(alias.Type.GirName != "utf8" && alias.Type.GirName != "filename" && alias.Type.GirName != "bytestring", () =>
                    alias.Fields.GetStructDeclaration().AddModifiers(Token(NewKeyword)))
                .AddRange(alias.Constants.GetMemberDeclarations())
                .AddRange(alias.ManagedProperties.GetMemberDeclarations())
                .AddIf(!alias.IsCustomDefaultConstructor, () => alias.GetDefaultConstructor())
                .AddRange(alias.Constructors.GetMemberDeclarations())
                .AddRange(alias.Functions.GetMemberDeclarations())
                .AddRange(alias.Methods.GetMemberDeclarations());

            return members;
        }

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

        /// <summary>
        /// Gets the C# struct member declarations for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Alias alias)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(alias.Constants.GetMemberDeclarations())
                .Add(alias.GetValueFieldDeclaration())
                .Add(alias.GetValueValidationMethodDeclaration())
                .Add(alias.GetConstructorDeclaration())
                .AddRange(alias.GetExplicitCastOperatorDeclarations())
                .AddRange(alias.ManagedProperties.GetMemberDeclarations())
                .AddRange(alias.Functions.GetMemberDeclarations())
                .AddRange(alias.Methods.GetMemberDeclarations());
        }

        /// <summary>
        /// Gets the value field declaration for an alias that is a struct.
        /// </summary>
        /// <remarks>
        /// Something like:
        /// <code>
        /// private readonly int value;
        /// </code>
        /// </remarks>
        private static FieldDeclarationSyntax GetValueFieldDeclaration(this Alias alias)
        {
            return FieldDeclaration(
                VariableDeclaration(ParseTypeName(alias.Type.GetUnmanagedType()))
                    .AddVariables(VariableDeclarator("value"))
            ).AddModifiers(Token(PrivateKeyword), Token(ReadOnlyKeyword));
        }

        /// <summary>
        /// Gets the value validation method declaration for an alias that is a struct.
        /// </summary>
        /// <remarks>
        /// Something like:
        /// <code>
        /// static partial void ValidateValue(int value);
        /// </code>
        /// </remarks>
        private static MethodDeclarationSyntax GetValueValidationMethodDeclaration(this Alias alias)
        {
            return MethodDeclaration(ParseTypeName("void"), "ValidateValue")
                .AddModifiers(Token(StaticKeyword), Token(PartialKeyword))
                .AddParameterListParameters(Parameter(Identifier("value"))
                    .WithType(ParseTypeName(alias.Type.GetUnmanagedType())))
                .WithSemicolonToken(Token(SemicolonToken));
        }

        /// <summary>
        /// Gets the constructor declaration for an alias that is a struct.
        /// </summary>
        /// <remarks>
        /// Something like:
        /// <code>
        /// public IntAlias(int value)
        /// {
        ///     ValidateValue(value);
        ///     this.value = value;
        /// }
        /// </code>
        /// </remarks>
        private static ConstructorDeclarationSyntax GetConstructorDeclaration(this Alias alias)
        {
            return ConstructorDeclaration(alias.GirName)
                .AddParameterListParameters(Parameter(Identifier("value"))
                    .WithType(ParseTypeName(alias.Type.GetUnmanagedType())
                ))
                .AddModifiers(Token(PublicKeyword))
                .AddBodyStatements(
                    ExpressionStatement(ParseExpression(
                        "ValidateValue(value)"
                    )),
                    ExpressionStatement(ParseExpression(
                        "this.value = value"
                    ))
                )
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// Creates a new instance.
                /// </summary>
                "));
        }

        /// <summary>
        /// Gets the explicit cast declarations for an alias that is a struct.
        /// </summary>
        /// <remarks>
        /// Something like:
        /// <code>
        /// public static explicit operator IntAlias(int value)
        /// {
        ///     return new IntAlias(value);
        /// }
        ///
        /// public static explicit operator int(IntAlias value)
        /// {
        ///     return value.value;
        /// }
        /// </code>
        /// </remarks>
        private static IEnumerable<ConversionOperatorDeclarationSyntax>
            GetExplicitCastOperatorDeclarations(this Alias alias)
        {
            yield return ConversionOperatorDeclaration(
                Token(ExplicitKeyword), ParseTypeName(alias.GirName)
            )
            .AddParameterListParameters(Parameter(Identifier("value"))
                .WithType(ParseTypeName(alias.Type.GetUnmanagedType())))
            .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
            .AddBodyStatements(ReturnStatement(ParseExpression(
                $"new {alias.GirName}(value)"
            )))
            .WithLeadingTrivia(ParseLeadingTrivia($@"/// <summary>
            /// Converts to <see cref=""{alias.GirName}""/> from the underlying type.
            /// </summary>
            "));

            yield return ConversionOperatorDeclaration(
                Token(ExplicitKeyword), ParseTypeName(alias.Type.GetUnmanagedType())
            )
            .AddParameterListParameters(Parameter(Identifier("value"))
                .WithType(ParseTypeName(alias.GirName)))
            .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
            .AddBodyStatements(ReturnStatement(ParseExpression(
                "value.value"
            )))
            .WithLeadingTrivia(ParseLeadingTrivia($@"/// <summary>
            /// Converts from <see cref=""{alias.GirName}""/> to the underlying type.
            /// </summary>
            "));
        }
    }
}
