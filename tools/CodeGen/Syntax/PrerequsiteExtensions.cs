// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class PrerequisiteExtensions
    {
        /// <summary>
        /// Gets the C# base type for a GIR prerequisite
        /// </summary>
        public static BaseTypeSyntax GetBaseType(this Prerequisite prerequisite)
        {
            return SimpleBaseType(ParseTypeName(prerequisite.Type.GetManagedType()));
        }
    }
}
