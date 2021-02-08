// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class ParametersExtensions
    {
        public static ParameterListSyntax GetParameterList(this Parameters parameters, string suffix = "_")
        {
            return ParameterList(SeparatedList(parameters.Select(x => x.GetParameter(suffix))));
        }

        public static ArgumentListSyntax GetArgumentList(this Parameters parameters, string suffix = "")
        {
            return ArgumentList(SeparatedList(parameters.Select(x => x.GetArgument(suffix))));
        }
    }
}
