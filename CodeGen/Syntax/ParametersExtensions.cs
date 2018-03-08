using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

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
