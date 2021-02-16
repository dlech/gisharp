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
    public static class MethodExtensions
    {
        /// <summary>
        /// Gets the C# class member declarations for a GIR method
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Method method)
        {
            IEnumerable<MemberDeclarationSyntax> getMembers()
            {
                yield return method.GetExternMethodDeclaration();
                if (!method.IsPInvokeOnly) {
                    yield return method.GetCheckArgsMethodDeclaration();
                    if (method.IsCheckReturn) {
                        yield return method.GetCheckReturnMethodDeclaration();
                    }

                    var declaration = method.GetInstanceMethodDeclaration()
                        .WithBody(method.GetInvokeBlock(method.CIdentifier));

                    if (method.IsEqual && !method.IsExtensionMethod) {
                        // IEquatable parameter is always nullable so we need
                        // to correct the type and add a null check
                        var otherParam = method.ManagedParameters.RegularParameters.Single();
                        if (!otherParam.IsNullable && !otherParam.Type.ManagedType.IsValueType) {
                            var oldParam = declaration.ParameterList.Parameters.Single();
                            var newParam = oldParam.WithType(NullableType(oldParam.Type));
                            declaration = declaration.ReplaceNode(oldParam, newParam);
                        }
                        if (!otherParam.Type.ManagedType.IsValueType) {
                            declaration = declaration.WithBody(Block(
                                declaration.Body.Statements.Prepend(
                                    IfStatement(
                                        ParseExpression($"{otherParam.ManagedName} is null"),
                                        Block(
                                            ReturnStatement(LiteralExpression(FalseLiteralExpression))
                                        )
                                    )
                                )
                            ));
                        }
                    }

                    yield return declaration;
                }

                if (method.FinishFor is not null) {
                    yield return method.GetFinishMethodDeclaration()
                        .WithBody(Block(method.GetFinishMethodStatements()));
                    foreach (var f in method.GetFinishDelegateField()) {
                        yield return f;
                    }
                }

                if (method.IsRef) {
                    // if there is an unmanaged ref method, use it to override the
                    // managed Take() method
                    var takeReturnType = ParseTypeName(typeof(IntPtr).FullName);
                    var paramType = method.Parameters.InstanceParameter.Type.UnmanagedType.ToSyntax();
                    var takeExpression = ParseExpression($"({takeReturnType}){method.CIdentifier}(({paramType})UnsafeHandle)");
                    var takeOverride = MethodDeclaration(takeReturnType, "Take")
                        .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                        .WithExpressionBody(ArrowExpressionClause(takeExpression))
                        .WithSemicolonToken(Token(SemicolonToken))
                        .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                        /// Takes ownership of the unmanaged pointer without freeing it.
                        /// The managed object can no longer be used (will throw disposed exception).
                        /// </summary>
                        "));
                    yield return takeOverride;
                }

                if (method.IsUnref || method.IsFree) {
                    var disposeMethod = MethodDeclaration(ParseTypeName("void"), "Dispose")
                        .AddParameterListParameters(Parameter(Identifier("disposing"))
                            .WithType(ParseTypeName("bool")))
                        .AddModifiers(Token(ProtectedKeyword), Token(OverrideKeyword))
                        .WithBody(Block(
                            IfStatement(ParseExpression("handle != System.IntPtr.Zero"), Block(
                                ExpressionStatement(ParseExpression($"{method.CIdentifier}((UnmanagedStruct*)handle)"))
                            )),
                            ExpressionStatement(ParseExpression("base.Dispose(disposing)"))
                        ))
                        .WithLeadingTrivia(ParseLeadingTrivia(@"/// <inheritdoc/>
                        "));
                    yield return disposeMethod;
                }

                if (method.IsEqual && !method.IsExtensionMethod) {
                    yield return method.GetOverrideEqualsMethodDeclaration();
                    yield return method.GetEqualityOperatorDeclaration();
                    yield return method.GetInequalityOperatorDeclaration();
                }
            }

            return List(getMembers());
        }

        /// <summary>
        /// Gets the C# instance method declaration for a GIR method
        /// </summary>
        public static MethodDeclarationSyntax GetInstanceMethodDeclaration(this Method method)
        {
            var returnType = method.ReturnValue.GetManagedTypeName();

            var syntax = MethodDeclaration(returnType, method.ManagedName)
                .WithModifiers(method.GetAccessModifiers())
                .WithAttributeLists(method.GetCommonAttributeLists())
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithBody(Block());

            if (method.IsExtensionMethod) {
                syntax = syntax.AddModifiers(Token(StaticKeyword));
            }

            if (method.IsToString && !method.IsExtensionMethod) {
                syntax = syntax.WithReturnType(ParseTypeName(typeof(string).ToString()));
            }

            var triviaParameters = method.ManagedParameters.RegularParameters.Cast<GIArg>();
            if (method.IsExtensionMethod) {
                triviaParameters = triviaParameters.Prepend(method.ManagedParameters.ThisParameter);
            }
            if (!method.ReturnValue.IsSkip) {
                triviaParameters = triviaParameters.Append(method.ReturnValue);
            }

            var trivia = TriviaList()
                .AddRange(method.Doc.GetDocCommentTrivia())
                .AddRange(triviaParameters.SelectMany(x => x.Doc.GetDocCommentTrivia()))
                .AddRange(method.GetGErrorExceptionDocCommentTrivia());

            // only set "extern doc" if method is public
            if (syntax.Modifiers.Any(x => x.IsEquivalentTo(Token(PublicKeyword))
                                       || x.IsEquivalentTo(Token(ProtectedKeyword)))) {
                syntax = syntax.WithLeadingTrivia(trivia)
                    .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
            }

            return syntax;
        }

        /// <summary>
        /// Gets a method declaration that overrides object.Equals.
        /// </summary>
        static MethodDeclarationSyntax GetOverrideEqualsMethodDeclaration(this Method method)
        {
            var type = method.Parameters.InstanceParameter.Type.ManagedType.FullName;
            var identifier = method.Parameters.InstanceParameter.Type.ManagedType.Name.ToCamelCase();
            var syntax = MethodDeclaration(ParseTypeName(typeof(bool).FullName), "Equals")
                .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                .AddParameterListParameters(Parameter(Identifier("other"))
                    .WithType(ParseTypeName($"{typeof(object).FullName}?")))
                .AddBodyStatements(
                    IfStatement(
                        ParseExpression($"other is {type} {identifier}"),
                        Block(ReturnStatement(ParseExpression($"Equals({identifier})")))
                    ),
                    ReturnStatement(ParseExpression($"base.Equals(other)"))
                )
                .WithLeadingTrivia(ParseLeadingTrivia("/// <inheritdoc/>\n"));

            return syntax;
        }

        private static OperatorDeclarationSyntax GetEqualityOperatorDeclaration(this Method method)
        {
            var parameterType = method.ManagedParameters.RegularParameters.Single().Type.ManagedType.ToSyntax();
            return OperatorDeclaration(typeof(bool).ToSyntax(), Token(EqualsEqualsToken))
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .AddParameterListParameters(
                    Parameter(Identifier("a")).WithType(parameterType),
                    Parameter(Identifier("b")).WithType(parameterType)
                )
                .AddBodyStatements(
                    ReturnStatement(ParseExpression("a.Equals(b)"))
                )
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <inheritdoc/>
                "));
        }

        private static OperatorDeclarationSyntax GetInequalityOperatorDeclaration(this Method method)
        {
            var parameterType = method.ManagedParameters.RegularParameters.Single().Type.ManagedType.ToSyntax();
            return OperatorDeclaration(typeof(bool).ToSyntax(), Token(ExclamationEqualsToken))
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .AddParameterListParameters(
                    Parameter(Identifier("a")).WithType(parameterType),
                    Parameter(Identifier("b")).WithType(parameterType)
                )
                .AddBodyStatements(
                    ReturnStatement(ParseExpression("!a.Equals(b)"))
                )
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <inheritdoc/>
                "));
        }

        static SyntaxTokenList GetAccessModifiers(this Method method)
        {
            if ((method.IsHash || method.IsToString) && !method.IsExtensionMethod) {
                return TokenList(Token(PublicKeyword), Token(OverrideKeyword));
            }

            return method.GetCommonAccessModifiers();
        }

        /// <summary>
        /// Appends base types for interfaces implemented by methods to a class
        /// declaration, if any.
        /// </summary>
        public static SeparatedSyntaxList<BaseTypeSyntax> GetBaseListTypes(this IEnumerable<Method> methods)
        {
            var list = SeparatedList<BaseTypeSyntax>();
            foreach (var method in methods) {
                var type = (GIRegisteredType)method.ParentNode;
                if (method.IsEqual) {
                    // if we have an Equals method, then we implement the IEquatable<T> interface
                    var typeName = string.Concat(typeof(IEquatable<>).FullName.TakeWhile(x => x != '`'));
                    typeName = string.Format("{0}<{1}>", typeName, type.ManagedName);
                    list = list.Add(SimpleBaseType(ParseTypeName(typeName)));
                }
            }
            return list;
        }

        static SyntaxList<StatementSyntax> GetFinishMethodStatements(this Method method)
        {
            return List(method.GetFinishMethodStatements(method.FinishForFunction, method.CIdentifier));
        }

        static IEnumerable<FieldDeclarationSyntax> GetFinishDelegateField(this Method method)
        {
            var identifier = method.FinishForFunction.ManagedName.ToCamelCase() + "Callback";
            return method.GetFinishDelegateFields(identifier);
        }

        /// <summary>
        /// Gets the member declarations for the methods, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Method> methods)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var method in methods) {
                try {
                    list = list.AddRange(method.GetClassMembers());
                }
                catch (Exception ex) {
                    method.LogException(ex);
                }
            }

            return list;
        }
    }
}
