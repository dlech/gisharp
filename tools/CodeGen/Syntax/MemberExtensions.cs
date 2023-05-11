// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System;
using System.Text;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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

            // use binary literal for flags

            if (member.ParentNode is Bitfield)
            {
                var uintValue = member.Value.StartsWith('-')
                    ? (uint)int.Parse(member.Value)
                    : uint.Parse(member.Value);
                var builder = new StringBuilder(Convert.ToString(uintValue, 2));
                while (builder.Length < 32)
                {
                    builder.Insert(0, '0');
                }
                for (int i = 28; i > 0; i -= 4)
                {
                    builder.Insert(i, '_');
                }
                builder.Insert(0, "0b");
                value = ParseExpression(builder.ToString());
            }

            return EnumMemberDeclaration(member.ManagedName)
                .WithEqualsValue(EqualsValueClause(value))
                .WithAttributeLists(member.GetCommonAttributeLists());
            // TODO: add an attribute for nick?
        }
    }
}
