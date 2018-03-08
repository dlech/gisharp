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
                yield return function.GetExternMethodDeclaration();
                if (!function.IsPInvokeOnly) {
                    yield return function.GetStaticMethodDeclaration()
                        .WithBody(Block(function.GetInvokeStatements(function.CIdentifier)));
                }
            }

            return List<MemberDeclarationSyntax>(getMembers());
        }
    }
}
