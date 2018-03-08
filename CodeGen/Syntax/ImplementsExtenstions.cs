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

            foreach (var m in implements.Type.GetMethods()) {
                var returnType = m.ReturnType.ToSyntax();
                var name = $"{implements.Type.ToSyntax()}.{m.Name}";
                var method = MethodDeclaration(returnType, name)
                    .WithParameterList(m.GetParameters().ToSyntax())
                    .WithBody(Block(ThrowStatement(ParseExpression("new System.NotImplementedException()"))));
                list = list.Add(method);
            }

            return list;
        }
    }
}
