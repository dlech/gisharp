// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

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
    public static class FunctionExtensions
    {
        /// <summary>
        /// Gets the C# class member declarations for a GIR method
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Function function)
        {
            IEnumerable<MemberDeclarationSyntax> getMembers()
            {
                yield return function.GetCheckArgsMethodDeclaration();
                if (function.IsCheckReturn) {
                    yield return function.GetCheckReturnMethodDeclaration();
                }

                yield return function.GetExternMethodDeclaration();
                if (!function.IsPInvokeOnly) {
                    yield return function.GetStaticMethodDeclaration()
                        .WithBody(function.GetInvokeBlock(function.CIdentifier));
                }

                if (function.IsCompare) {
                    yield return function.GetIComparableInterfaceMethodDeclaration();
                    foreach (var op in function.GetComparisonOperatorDeclarations()) {
                        yield return op;
                    }
                }

                if (function.FinishFor is not null) {
                    yield return function.GetFinishMethodDeclaration()
                        .WithBody(Block(function.GetFinishMethodStatements()));
                    foreach (var f in function.GetFinishDelegateFields()) {
                        yield return f;
                    }
                }

            }

            return List(getMembers());
        }

        /// <summary>
        /// Appends base types for interfaces implemented by functions to a class
        /// declaration, if any.
        /// </summary>
        public static SeparatedSyntaxList<BaseTypeSyntax> GetBaseListTypes(this IEnumerable<Function> functions)
        {
            var list = SeparatedList<BaseTypeSyntax>();
            foreach (var function in functions) {
                var type = (GIRegisteredType)function.ParentNode;
                if (function.IsCompare) {
                    // if we have an Compare method, then we implement the IComparable<T> interface
                    var typeName = string.Concat(typeof(IComparable<>).FullName.TakeWhile(x => x != '`'));
                    typeName = string.Format("{0}<{1}>", typeName, type.ManagedName);
                    list = list.Add(SimpleBaseType(ParseTypeName(typeName)));
                }
            }
            return list;
        }

        /// <summary>
        /// Gets a CompareTo() method implementation for <see cref="IComparable{T}"/>.
        /// </summary>
        static MethodDeclarationSyntax GetIComparableInterfaceMethodDeclaration(this Function function)
        {
            if (!function.IsCompare) {
                throw new ArgumentException("function must be flagged as gs:special-func=compare",
                    nameof(function));
            }
            var argType = function.ManagedParameters.Last().Type.ManagedType;
            var otherParamType = argType.ToSyntax();
            var nullCheck = "";

            if (!argType.IsValueType) {
                otherParamType = NullableType(otherParamType);
                nullCheck = $"?? throw new System.ArgumentNullException(nameof(other))";
            }

            var declaringType = (GIRegisteredType)function.ParentNode;
            var declaration = MethodDeclaration(ParseName("System.Int32"), "CompareTo")
                .AddModifiers(Token(PublicKeyword))
                .AddParameterListParameters(Parameter(Identifier("other")).WithType(otherParamType))
                .AddBodyStatements(
                    ReturnStatement(ParseExpression($"{function.ManagedName}(this, other{nullCheck})"))
                )
                .WithLeadingTrivia(ParseLeadingTrivia($@"/// <inheritdoc/>
                /// <seealso cref=""GISharp.Lib.{function.Namespace.Name}.{declaringType.ManagedName}.{function.ManagedName}""/>
                "));

            return declaration;
        }

        /// <summary>
        /// Gets comparison operator declarations for all 4 comparison types.
        /// </summary>
        /// <remarks>
        /// Implementation is like this:
        /// <code>
        /// public static bool operator >(T a, T b)
        /// {
        ///      return Compare(a, b) > 0;
        /// }
        /// </code>
        /// </remarks>
        static IEnumerable<OperatorDeclarationSyntax> GetComparisonOperatorDeclarations(this Function function)
        {
            if (!function.IsCompare) {
                throw new ArgumentException("function must be flagged as gs:special-func=compare",
                    nameof(function));
            }

            var returnType = ParseName("System.Boolean");
            var operators = new[] {
                Token(LessThanToken),
                Token(GreaterThanToken),
                Token(LessThanEqualsToken),
                Token(GreaterThanEqualsToken),
            };

            var parameterList = function.ManagedParameters.GetParameterList();

            foreach (var op in operators) {
                var declaration = OperatorDeclaration(returnType, op)
                    .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                    .WithParameterList(parameterList)
                    .AddBodyStatements(
                        ReturnStatement(ParseExpression(
                            $@"{function.ManagedName}({string.Join(
                                ", ", parameterList.Parameters.Select(x => x.Identifier.ToFullString())
                            )}) {op.ToFullString()} 0"
                        ))
                    )
                    .WithLeadingTrivia(ParseLeadingTrivia("/// <inheritdoc/>\n"));
                yield return declaration;
            }
        }

        static SyntaxList<StatementSyntax> GetFinishMethodStatements(this Function function)
        {
            return List(function.GetFinishMethodStatements(function.FinishForFunction, function.CIdentifier));
        }

        static IEnumerable<FieldDeclarationSyntax> GetFinishDelegateFields(this Function function)
        {
            var identifier = function.FinishForFunction.ManagedName.ToCamelCase() + "Callback";
            return function.GetFinishDelegateFields(identifier);
        }

        /// <summary>
        /// Gets the member declarations for the functions, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Function> functions)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var function in functions) {
                try {
                    list = list.AddRange(function.GetClassMembers());
                }
                catch (Exception ex) {
                    function.LogException(ex);
                }
            }

            return list;
        }
    }
}
