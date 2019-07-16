using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
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
            var type = property.Getter.ReturnValue.GetManagedTypeName();

            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithModifiers(property.GetCommonAccessModifiers())
                .WithAttributeLists(property.GetCommonAttributeLists())
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

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

        /// <summary>
        /// Gets the member declarations for the properties, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<ManagedProperty> properties)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var property in properties) {
                try {
                    list = list.Add(property.GetDeclaration());
                }
                catch (Exception ex) {
                    property.LogException(ex);
                }
            }

            return list;
        }
    }
}
