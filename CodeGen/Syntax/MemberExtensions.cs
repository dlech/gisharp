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
    public static class MemberExtensions
    {
        /// <summary>
        /// Gets the C# enum member declaration for a GIR member
        /// </summary>
        public static EnumMemberDeclarationSyntax GetDeclaration(this Member member)
        {
            var value = ParseExpression(member.Value);
            return EnumMemberDeclaration(member.ManagedName)
                .WithEqualsValue(EqualsValueClause(value))
                .WithAttributeLists(member.GetCommonAttributeLists());
            // TODO: add an attribute for nick?
        }
    }
}
