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
    public static class AliasExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR alias
        /// </summary>
        public static StructDeclarationSyntax GetStructDeclaration(this Alias alias)
        {
            var identifier = alias.ManagedName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(PartialKeyword));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR alias
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Alias alias)
        {
            return List<MemberDeclarationSyntax>();
        }
    }
}
