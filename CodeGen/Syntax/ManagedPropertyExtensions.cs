using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ManagedExtensions
    {
        /// <summary>
        /// Gets the C# property declaration for a GIR managed (not GObject) property
        /// </summary>
        public static PropertyDeclarationSyntax GetDeclaration(this ManagedProperty property)
        {
            var type = property.Type.ManagedType.ToSyntax();

            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithModifiers(property.GetAccessModifiers())
                .WithAttributeLists(property.GetCommonAttributeLists())
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia());

            var getter = property.Getter;
            if (getter is Function) {
                syntax = syntax.AddModifiers(Token(StaticKeyword));
            }

            var getterExpression = ParseExpression($"{getter.ManagedName}()");
            var getAccessor = AccessorDeclaration(GetAccessorDeclaration)
                .WithExpressionBody(ArrowExpressionClause(getterExpression))
                .WithSemicolonToken(Token(SemicolonToken));
            syntax = syntax.AddAccessorListAccessors(getAccessor);

            var setter = property.Setter;
            if (setter != null) {
                var setterExpression = ParseExpression($"{setter.ManagedName}(value)");
                var setAccessor = AccessorDeclaration(SetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(setterExpression))
                    .WithSemicolonToken(Token(SemicolonToken));
                // TODO: it is possible that setter might have different access modifier
                syntax = syntax.AddAccessorListAccessors(setAccessor);
            }

            return syntax;
        }
    }
}
