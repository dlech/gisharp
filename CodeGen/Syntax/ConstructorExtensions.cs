using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ConstructorExtensions
    {
        /// <summary>
        /// Gets the C# class member declarations for a GIR constructor
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Constructor constructor)
        {
            IEnumerable<MemberDeclarationSyntax> getMembers()
            {
                yield return constructor.GetExternMethodDeclaration();
                if (!constructor.IsPInvokeOnly) {
                    yield return constructor.GetStaticMethodDeclaration()
                        .WithModifiers(TokenList(Token(StaticKeyword))) // strip access modifiers
                        .WithBody(Block(constructor.GetInvokeStatements(constructor.CIdentifier)));
                    yield return constructor.GetConstructorDeclaration();
                }
            }

            return List<MemberDeclarationSyntax>(getMembers());
        }

        /// <summary>
        /// Gets the C# constructor declarations for a GIR constructor
        /// </summary>
        public static ConstructorDeclarationSyntax GetConstructorDeclaration(this Constructor constructor)
        {
            var staticMethod = ParseExpression(constructor.ManagedName);
            var handleArg = Argument(InvocationExpression(staticMethod)
                .WithArgumentList(constructor.ManagedParameters.GetArgumentList()));

            var ownership = $"{typeof(Transfer).FullName}.{constructor.ReturnValue.Ownership}";
            var ownershipArg = Argument(ParseExpression(ownership));

            var initializer = ConstructorInitializer(ThisConstructorInitializer)
                .AddArgumentListArguments(handleArg, ownershipArg);

            var syntax = ConstructorDeclaration(constructor.ParentNode.ManagedName)
                .AddModifiers(Token(PublicKeyword))
                .WithInitializer(initializer)
                .WithAttributeLists(constructor.GetCommonAttributeLists())
                .WithParameterList(constructor.ManagedParameters.GetParameterList())
                .WithBody(Block());

            var trivia = TriviaList()
                .AddRange(constructor.Doc.GetDocCommentTrivia())
                .AddRange(constructor.ManagedParameters.RegularParameters
                    .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                .AddRange(constructor.ReturnValue.Doc.GetDocCommentTrivia())
                .AddRange(constructor.GetGErrorExceptionDocCommentTrivia());

            syntax = syntax.WithLeadingTrivia(trivia);

            return syntax;
        }
    }
}
