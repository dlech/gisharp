using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class ParameterInfoExtensions
    {
        public static ParameterListSyntax ToSyntax(this IEnumerable<ParameterInfo> parameters, bool withType)
        {
            var parameterSyntaxes = parameters.Select(x => x.ToSyntax(withType));
            return ParameterList(SeparatedList(parameterSyntaxes));
        }

        public static ParameterSyntax ToSyntax(this ParameterInfo parameter, bool withType)
        {
            var syntax = Parameter(ParseToken(parameter.Name));
            if (withType) {
                syntax = syntax.WithType(parameter.ParameterType.ToSyntax());
            }
            return syntax;
        }
    }
}