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
                var checkArgsMethod = function.GetCheckArgsMethodDeclaration();
                yield return checkArgsMethod;

                yield return function.GetExternMethodDeclaration();
                if (!function.IsPInvokeOnly) {
                    yield return function.GetStaticMethodDeclaration()
                        .WithBody(Block(function.GetInvokeStatements(function.CIdentifier)));
                }

                if (function.FinishFor is not null) {
                    yield return function.GetFinishMethodDeclaration()
                        .WithBody(Block(function.GetFinishMethodStatements()));
                    foreach (var f in function.GetFinishDelegateFields()) {
                        yield return f;
                    }
                }

            }

            return List<MemberDeclarationSyntax>(getMembers());
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
