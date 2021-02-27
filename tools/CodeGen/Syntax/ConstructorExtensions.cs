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
    public static class ConstructorExtensions
    {
        /// <summary>
        /// Gets the C# class member declarations for a GIR constructor
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Constructor constructor)
        {
            IEnumerable<MemberDeclarationSyntax> getMembers()
            {
                yield return constructor.GetCheckArgsMethodDeclaration();
                if (constructor.IsCheckReturn) {
                    yield return constructor.GetCheckReturnMethodDeclaration();
                }

                yield return constructor.GetExternMethodDeclaration();
                if (!constructor.IsPInvokeOnly) {
                    yield return constructor.GetStaticMethodDeclaration()
                        .WithModifiers(TokenList(Token(StaticKeyword))) // strip access modifiers
                        .WithBody(constructor.GetInvokeBlock(constructor.CIdentifier));
                    if (!constructor.HasCustomConstructor) {
                        yield return constructor.GetConstructorDeclaration();
                    }
                }
            }

            return List(getMembers());
        }

        /// <summary>
        /// Gets the C# constructor declarations for a GIR constructor
        /// </summary>
        public static ConstructorDeclarationSyntax GetConstructorDeclaration(this Constructor constructor)
        {
            var staticMethod = ParseExpression(constructor.ManagedName);
            var handleArg = Argument(CastExpression(ParseTypeName("System.IntPtr"),
                InvocationExpression(staticMethod)
                    .WithArgumentList(constructor.ManagedParameters.GetArgumentList())));

            var ownership = constructor.ReturnValue.GetOwnershipTransfer();
            var ownershipArg = Argument(ownership);

            var initializer = ConstructorInitializer(ThisConstructorInitializer)
                .AddArgumentListArguments(handleArg, ownershipArg);

            var declaringType = (GIRegisteredType)constructor.ParentNode;
            var syntax = ConstructorDeclaration(declaringType.ManagedName)
                .AddModifiers(Token(PublicKeyword))
                .WithInitializer(initializer)
                .WithAttributeLists(constructor.GetCommonAttributeLists())
                .WithParameterList(constructor.ManagedParameters.GetParameterList())
                .WithBody(Block());

            var trivia = TriviaList()
                .AddRange(constructor.Doc.GetDocCommentTrivia())
                .AddRange(constructor.ManagedParameters.RegularParameters
                    .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                .AddRange(constructor.GetGErrorExceptionDocCommentTrivia());

            syntax = syntax.WithLeadingTrivia(trivia)
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        /// <summary>
        /// Gets the member declarations for the constructors, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Constructor> constructors)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var constructor in constructors) {
                try {
                    list = list.AddRange(constructor.GetClassMembers());
                }
                catch (Exception ex) {
                    constructor.LogException(ex);
                }
            }

            return list;
        }
    }
}
