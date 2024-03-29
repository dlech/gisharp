// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class GIFunctionExtensions
    {
        /// <summary>
        /// Gets the C# extern (PInvoke) method declaration for a GIR function
        /// </summary>
        public static MethodDeclarationSyntax GetExternMethodDeclaration(this GIFunction function)
        {
            var girTrivia = TriviaList(
                function.ReturnValue.GetGirXmlTrivia(),
                EndOfLine("\n"),
                function.ReturnValue.GetAnnotationTrivia()
            );

            // get parameters, injecting some comments along the way
            var parameterList = ParameterList(
                SeparatedList(
                    function.Parameters.Select(
                        x =>
                            x.GetParameter()
                                .WithLeadingTrivia(
                                    TriviaList(
                                        x.GetGirXmlTrivia(),
                                        EndOfLine("\n"),
                                        x.GetAnnotationTrivia(),
                                        EndOfLine("\n")
                                    )
                                )
                    )
                )
            );

            var modifiers = TokenList();
            if (function.PinvokeAccessModifiers is string m)
            {
                modifiers = modifiers.AddRange(ParseTokens(m));
            }
            else
            {
                modifiers = modifiers.Add(Token(PrivateKeyword));
            }
            modifiers = modifiers.Add(Token(StaticKeyword)).Add(Token(ExternKeyword));

            // adding girTrivia here makes it appear before the method declaration
            // but after the attribute lists
            modifiers = modifiers.Replace(
                modifiers.First(),
                modifiers.First().WithLeadingTrivia(girTrivia)
            );

            var returnType = ParseTypeName(function.ReturnValue.Type.GetUnmanagedType());
            var syntax = MethodDeclaration(returnType, function.CIdentifier)
                .WithModifiers(modifiers)
                .WithAttributeLists(function.GetCommonAttributeLists())
                .AddAttributeLists(function.GetDllImportAttributeList())
                .WithParameterList(parameterList)
                .WithSemicolonToken(Token(SemicolonToken));

            var trivia = TriviaList()
                .AddRange(function.Doc.GetDocCommentTrivia(false))
                .AddRange(function.Parameters.SelectMany(x => x.Doc.GetDocCommentTrivia(false)))
                .AddRange(function.ReturnValue.Doc.GetDocCommentTrivia(false));

            syntax = syntax.WithLeadingTrivia(trivia);

            return syntax;
        }

        /// <summary>
        /// Gets the C# static method declaration for a GIR function
        /// </summary>
        public static MethodDeclarationSyntax GetStaticMethodDeclaration(this GIFunction function)
        {
            var returnType = function.ReturnValue.GetManagedTypeName();
            var modifiers = TokenList(function.GetCommonAccessModifiers());

            if (function is Constructor)
            {
                // special case for constructors since the static method is only
                // part of the constructor
                returnType = ParseTypeName(function.ReturnValue.Type.GetUnmanagedType());
                modifiers = TokenList();
            }

            modifiers = modifiers.Add(Token(StaticKeyword));

            var syntax = MethodDeclaration(returnType, function.ManagedName)
                .WithModifiers(modifiers)
                .WithAttributeLists(function.GetCommonAttributeLists())
                .WithParameterList(function.ManagedParameters.GetParameterList())
                .WithBody(Block());

            var trivia = TriviaList()
                .AddRange(function.Doc.GetDocCommentTrivia())
                .AddRange(function.ManagedParameters.SelectMany(x => x.Doc.GetDocCommentTrivia()));

            if (returnType.ToString() != "void")
            {
                trivia = trivia.AddRange(function.ReturnValue.Doc.GetDocCommentTrivia());
            }

            trivia = trivia.AddRange(function.GetGErrorExceptionDocCommentTrivia());

            // only set "extern doc" if method is public
            if (
                syntax.Modifiers.Any(
                    x =>
                        x.IsEquivalentTo(Token(PublicKeyword))
                        || x.IsEquivalentTo(Token(ProtectedKeyword))
                )
            )
            {
                syntax = syntax
                    .WithLeadingTrivia(trivia)
                    .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
            }

            return syntax;
        }

        static AttributeListSyntax GetDllImportAttributeList(this GIFunction function)
        {
            var name = ParseName(typeof(DllImportAttribute).FullName);

            var argList = string.Format(
                "(\"{0}\", {1} = {2}.{3})",
                function.DllName,
                nameof(DllImportAttribute.CallingConvention),
                typeof(CallingConvention),
                nameof(CallingConvention.Cdecl)
            );

            var attr = Attribute(name).WithArgumentList(ParseAttributeArgumentList(argList));

            return AttributeList().AddAttributes(attr);
        }
    }
}
