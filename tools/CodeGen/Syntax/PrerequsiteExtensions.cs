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
    public static class PrerequisiteExtensions
    {
        /// <summary>
        /// Gets the C# base type for a GIR prerequisite
        /// </summary>
        public static BaseTypeSyntax GetBaseType(this Prerequisite prerequisite)
        {
            return SimpleBaseType(prerequisite.ManagedType.ToSyntax());
        }
    }
}
