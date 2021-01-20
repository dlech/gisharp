// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class ParameterInfoExtensions
    {
        public static ParameterListSyntax ToSyntax(this IEnumerable<ParameterInfo> parameters)
        {
            var parameterSyntaxes = parameters.Select(x => x.ToSyntax());
            return ParameterList(SeparatedList(parameterSyntaxes));
        }

        public static ParameterSyntax ToSyntax(this ParameterInfo parameter)
        {
            var syntax = Parameter(ParseToken(parameter.Name))
                .WithType(parameter.ParameterType.ToSyntax());

            const string nullableAttr = "System.Runtime.CompilerServices.NullableAttribute";
            var isNullable = parameter.GetCustomAttributes().Any(x => x.GetType().FullName == nullableAttr);
            if (isNullable && !parameter.ParameterType.IsValueType && !parameter.ParameterType.IsPointer) {
                syntax = syntax.WithType(NullableType(syntax.Type));
            }

            return syntax;
        }
    }
}