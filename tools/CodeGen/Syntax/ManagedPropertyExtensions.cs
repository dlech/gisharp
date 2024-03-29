// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ManagedExtensions
    {
        /// <summary>
        /// Gets the C# property declaration for a GIR managed (not GObject) property
        /// </summary>
        public static PropertyDeclarationSyntax GetDeclaration(this ManagedProperty property)
        {
            var type = property.Getter.ReturnValue.GetManagedTypeName();

            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithModifiers(property.GetCommonAccessModifiers())
                .WithAttributeLists(property.GetCommonAttributeLists());

            var getter = property.Getter;
            if (getter is Function)
            {
                syntax = syntax.AddModifiers(Token(StaticKeyword));
            }

            var @ref = getter.ReturnValue.IsRefReturn() ? "ref " : "";
            var getterExpression = ParseExpression($"{@ref}{getter.ManagedName}()");
            var getAccessor = AccessorDeclaration(GetAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(getterExpression))
                .WithSemicolonToken(Token(SemicolonToken));
            syntax = syntax.AddAccessorListAccessors(getAccessor);

            var setter = property.Setter;
            if (setter is not null)
            {
                var nullForgiving = "";
                if (!setter.Parameters.Last().IsNullable && getter.ReturnValue.IsNullable)
                {
                    if (getter.ReturnValue.IsUnownedUtf8())
                    {
                        nullForgiving = ".Value";
                    }
                    else
                    {
                        syntax = syntax.AddAttributeLists(
                            AttributeList()
                                .AddAttributes(
                                    Attribute(ParseName($"{typeof(DisallowNullAttribute)}"))
                                )
                        );
                        nullForgiving = "!"; // work around https://github.com/dotnet/roslyn/issues/38943
                    }
                }

                if (setter.Parameters.Last().IsNullable && !getter.ReturnValue.IsNullable)
                {
                    syntax = syntax.AddAttributeLists(
                        AttributeList()
                            .AddAttributes(Attribute(ParseName($"{typeof(AllowNullAttribute)}")))
                    );
                }

                var setterExpression = ParseExpression(
                    $"{setter.ManagedName}(value{nullForgiving})"
                );
                var setAccessor = AccessorDeclaration(SetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(setterExpression))
                    .WithSemicolonToken(Token(SemicolonToken));
                // TODO: it is possible that setter might have different access modifier
                syntax = syntax.AddAccessorListAccessors(setAccessor);
            }

            syntax = syntax
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        /// <summary>
        /// Gets the member declarations for the properties, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(
            this IEnumerable<ManagedProperty> properties
        )
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var property in properties)
            {
                try
                {
                    list = list.Add(property.GetDeclaration());
                }
                catch (Exception ex)
                {
                    property.LogException(ex);
                }
            }

            return list;
        }
    }
}
