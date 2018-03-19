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
    public static class PropertyExtensions
    {
        /// <summary>
        /// Gets the C# property declaration for a GIR property
        /// </summary>
        public static PropertyDeclarationSyntax GetDeclaration(this Property property)
        {
            var type = property.Type.ManagedType.ToSyntax();
            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithModifiers(property.GetAccessModifiers())
                .WithAttributeLists(property.GetCommonAttributeLists())
                .AddAttributeLists(property.GetGPropertyAttributeList())
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia());

            if (property.IsReadable) {
                var getAccessor = AccessorDeclaration(GetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(property.GetGetExpression()))
                    .WithSemicolonToken(Token(SemicolonToken));
                syntax = syntax.AddAccessorListAccessors(getAccessor);
            }

            if (property.IsWriteable) {
                var setAccessor = AccessorDeclaration(SetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(property.GetSetExpression()))
                    .WithSemicolonToken(Token(SemicolonToken));
                syntax = syntax.AddAccessorListAccessors(setAccessor);
            }

            return syntax;
        }

        static ExpressionSyntax GetGetExpression(this Property property)
        {
            var type = property.Type.ManagedType.ToSyntax();
            var expression = $"({type})GetProperty(\"{property.GirName}\")";
            return ParseExpression(expression); 
        }

        static ExpressionSyntax GetSetExpression(this Property property)
        {
            var expression = $"SetProperty(\"{property.GirName}\", value)";
            return ParseExpression(expression); 
        }

        /// <summary>
        /// Gets the C# interface property declaration for a GIR property
        /// </summary>
        public static PropertyDeclarationSyntax GetInterfaceDeclaration(this Property property)
        {
            var type = property.Type.ManagedType.ToSyntax();
            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithAttributeLists(property.GetCommonAttributeLists())
                .AddAttributeLists(property.GetGPropertyAttributeList())
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia());

            if (property.IsReadable) {
                var getAccessor = AccessorDeclaration(GetAccessorDeclaration)
                    .WithSemicolonToken(Token(SemicolonToken));
                syntax = syntax.AddAccessorListAccessors(getAccessor);
            }

            if (property.IsWriteable) {
                var setAccessor = AccessorDeclaration(SetAccessorDeclaration)
                    .WithSemicolonToken(Token(SemicolonToken));
                syntax = syntax.AddAccessorListAccessors(setAccessor);
            }

            return syntax;
        }

        static AttributeListSyntax GetGPropertyAttributeList(this Property property)
        {
            // create the attribute
            var attrName = ParseName(typeof(GPropertyAttribute).FullName);
            var nameArg = ParseExpression($"\"{property.GirName}\"");
            var attr = Attribute(attrName)
                .AddArgumentListArguments(AttributeArgument(nameArg));

            // add optional Construct = GPropertyConstruct.X argument
            var construct = GPropertyConstruct.No;
            if (property.Construct) {
                construct = GPropertyConstruct.Yes;
            }
            if (property.ConstructOnly) {
                construct = GPropertyConstruct.Only;
            }
            if (construct != GPropertyConstruct.No) {
                var constructType = $"{typeof(GPropertyConstruct)}.{construct}";
                var constructArg = AttributeArgument(ParseExpression(nameof(GPropertyAttribute.Construct)));
                constructArg = constructArg.WithExpression(AssignmentExpression(SimpleAssignmentExpression,
                    constructArg.Expression, ParseExpression(constructType)));
                attr = attr.AddArgumentListArguments(constructArg);
            }

            return AttributeList().AddAttributes(attr);
        }
    }
}
