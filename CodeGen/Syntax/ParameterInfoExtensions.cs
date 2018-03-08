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

            return syntax;
        }
    }
}