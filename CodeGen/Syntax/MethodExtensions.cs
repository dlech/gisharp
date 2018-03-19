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
                    yield return method.GetInstanceMethodDeclaration()
                        .WithBody(Block(method.GetInvokeStatements(method.CIdentifier)));
                }

                if (method.IsRef) {
                    // if there is an unmanaged ref method, use it to override the
                    // managed Take() method
                    var takeReturnType = ParseTypeName(typeof(IntPtr).FullName);
                    var takeExpression = ParseExpression($"{method.CIdentifier}(Handle)");
                    var takeOverride = MethodDeclaration(takeReturnType, "Take")
                        .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                        .WithExpressionBody(ArrowExpressionClause(takeExpression))
                        .WithSemicolonToken(Token(SemicolonToken));
                    yield return takeOverride;
                }
            }

            return List<MemberDeclarationSyntax>(getMembers());
        }

        /// <summary>
        /// Gets the C# instance method declaration for a GIR method
        /// </summary>
        public static MethodDeclarationSyntax GetInstanceMethodDeclaration(this Method method)
        {
            var returnType = method.ReturnValue.Type.ManagedType.ToSyntax();
            if (method.ReturnValue.IsSkip) {
                returnType = ParseTypeName("void");
            }

            var syntax = MethodDeclaration(returnType, method.ManagedName)
                .WithModifiers(method.GetAccessModifiers())
                .WithAttributeLists(method.GetCommonAttributeLists())
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithBody(Block());

            if (method.IsExtensionMethod) {
                syntax = syntax.AddModifiers(Token(StaticKeyword));
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

            syntax = syntax.WithLeadingTrivia(trivia);

            return syntax;
        }

        /// <summary>
        /// Appends base types for interfaces implemented by methods to a class
        /// declaration, if any.
        /// </summary>
        public static SeparatedSyntaxList<BaseTypeSyntax> GetBaseListTypes(this IEnumerable<Method> methods)
        {
            var list = SeparatedList<BaseTypeSyntax>();
            foreach (var method in methods) {
                var type = method.ParentNode;
                if (method.IsEquals) {
                    // if we have an Equals method, then we implement the IEquatable<T> interface
                    var typeName = string.Concat(typeof(IEquatable<>).FullName.TakeWhile(x => x != '`'));
                    typeName = string.Format ("{0}<{1}>", typeName, type.ManagedName);
                    list = list.Add(SimpleBaseType(ParseTypeName(typeName)));
                }
                if (method.IsCompare) {
                    // if we have an Compare method, then we implement the IComparable<T> interface
                    var typeName = string.Concat(typeof(IComparable<>).FullName.TakeWhile(x => x != '`'));
                    typeName = string.Format("{0}<{1}>", typeName, type.ManagedName);
                    list = list.Add(SimpleBaseType(ParseTypeName(typeName)));
                }
            }
            return list;
        }
    }
}
