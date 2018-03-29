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
    public static class StaticClassExtensions
    {
        /// <summary>
        /// Gets the C# class declaration for a GIR gs:static-class
        /// </summary>
        public static ClassDeclarationSyntax GetClassDeclaration(this StaticClass staticClass)
        {
            var identifier = staticClass.ManagedName;
            return ClassDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword), Token(PartialKeyword));
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR gs:static-class
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this StaticClass staticClass)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(staticClass.Constants.GetMemberDeclarations())
                .AddRange(staticClass.Functions.GetMemberDeclarations());
        }
    }
}
