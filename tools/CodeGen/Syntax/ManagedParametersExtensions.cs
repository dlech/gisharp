using System;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ManagedParametersExtensions
    {
        public static ParameterListSyntax GetParameterList(this ManagedParameters parameters)
        {
            return ParameterList(SeparatedList(parameters.Select(x => x.GetParameter())));
        }

        public static ArgumentListSyntax GetArgumentList(this ManagedParameters parameters, string suffix = "", bool declareOutVars = true)
        {
            return ArgumentList(SeparatedList(parameters.Select(x => x.GetArgument(suffix, declareOutVars))));
        }
    }
}
