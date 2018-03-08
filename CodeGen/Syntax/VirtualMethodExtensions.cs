using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class VirtualMethodExtensions
    {
        public static IEnumerable<MethodDeclarationSyntax> GetClassMembers(this VirtualMethod method)
        {
            var returnType = method.ReturnValue.GirType.ManagedType.ToSyntax();
            var gtypeStruct = method.ParentNode.GTypeStruct;
            var invoker = $"{typeof(TypeClass).FullName}.GetInstance<{gtypeStruct}>(_GType).{method.ManagedName}Delegate";

            yield return MethodDeclaration(returnType, method.ManagedName)
                .WithAttributeLists(method.GetCommonAttributeLists())
                .AddModifiers(Token(InternalKeyword), Token(ProtectedKeyword), Token(VirtualKeyword))
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithBody(Block(method.GetInvokeStatements(invoker)))
                .WithLeadingTrivia(TriviaList()
                    .AddRange(method.Doc.GetDocCommentTrivia())
                    .AddRange(method.ManagedParameters.RegularParameters
                        .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                    .AddRange(method.ReturnValue.Doc.GetDocCommentTrivia())
                    .AddRange(method.GetGErrorExceptionDocCommentTrivia()));
        }

        /// <summary>
        /// Gets the C# interface method declaration for a GIR virtual method
        /// </summary>
        public static MethodDeclarationSyntax GetInterfaceDeclaration(this VirtualMethod method)
        {
            var returnType = method.ReturnValue.GirType.ManagedType.ToSyntax();
            return MethodDeclaration(returnType, method.ManagedName)
                .WithAttributeLists(method.GetCommonAttributeLists())
                .WithParameterList(method.ManagedParameters.GetParameterList())
                .WithSemicolonToken(Token(SemicolonToken))
                .WithLeadingTrivia(TriviaList()
                    .AddRange(method.Doc.GetDocCommentTrivia())
                    .AddRange(method.ManagedParameters.RegularParameters
                        .SelectMany(x => x.Doc.GetDocCommentTrivia()))
                    .AddRange(method.ReturnValue.Doc.GetDocCommentTrivia())
                    .AddRange(method.GetGErrorExceptionDocCommentTrivia()));
        }
    }
}
