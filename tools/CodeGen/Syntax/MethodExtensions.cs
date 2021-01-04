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
                    var checkArgs = method.GetCheckArgsMethodDeclaration();
                    yield return checkArgs;
                    var declaration = method.GetInstanceMethodDeclaration()
                        .WithBody(Block(method.GetInvokeStatements(method.CIdentifier)));

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
                    var takeExpression = ParseExpression($"{method.CIdentifier}(Handle)");
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

                if (method.IsEqual && !method.IsExtensionMethod) {
                    yield return method.GetOverrideEqualsMethodDeclaration();
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

        static SyntaxTokenList GetAccessModifiers(this Method method)
        {
            if ((method.IsHash || method.IsToString) && !method.IsExtensionMethod) {
                return TokenList(Token(PublicKeyword), Token(OverrideKeyword));
            }

            return method.GetCommonAccessModifiers().Add(Token(UnsafeKeyword));
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
