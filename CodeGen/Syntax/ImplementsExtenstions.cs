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
    public static class ImplementsExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetVirtualMethodImplementations(this Implements implements)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var m in implements.ManagedType.GetMethods()) {
                var returnType = m.ReturnType.ToSyntax();
                var name = $"{implements.ManagedType.ToSyntax()}.{m.Name}";
                var method = MethodDeclaration(returnType, name)
                    .WithParameterList(m.GetParameters().ToSyntax())
                    .WithBody(Block(ThrowStatement(ParseExpression("new System.NotImplementedException()"))));
                list = list.Add(method);
            }

            return list;
        }

        /// <summary>
        /// Gets the member declarations for the implementses, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Implements> implementses)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var implements in implementses) {
                try {
                    list = list.AddRange(implements.GetVirtualMethodImplementations());
                }
                catch (Exception ex) {
                    implements.LogException(ex);
                }
            }

            return list;
        }
    }
}
