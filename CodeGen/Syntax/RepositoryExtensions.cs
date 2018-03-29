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
        /// Gets the C# compilation unit for all members of a namespace
        /// </summary>
        public static CompilationUnitSyntax GetCompilationUnit(this Repository repository)
        {
            var @namespace = repository.Namespace.GetDeclaration()
                .WithMembers(repository.Namespace.GetAllMembers());
            return CompilationUnit().AddMembers(@namespace);
        }

        /// <summary>
        /// Gets the C# compilation units for all members of a namespace, one
        /// for each type
        /// </summary>
        public static IEnumerable<(string name, CompilationUnitSyntax unit)> GetCompilationUnits(this Repository repository)
        {
            var @namespace = repository.Namespace.GetDeclaration();
            foreach (var type in repository.Namespace.AllTypes) {
                var unit = CompilationUnit().AddMembers(@namespace
                    .WithMembers(repository.Namespace.GetMembersFor(type)));
                yield return (type.GirName, unit);
            }
        }
    }
}
