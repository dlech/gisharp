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
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR alias
        /// </summary>
        public static CompilationUnitSyntax GetCompilationUnit(this Repository repository)
        {
            var @namespace = repository.Namespace.GetDeclaration()
                .WithMembers(repository.Namespace.GetMembers());
            return CompilationUnit().AddMembers(@namespace);
        }
    }
}
