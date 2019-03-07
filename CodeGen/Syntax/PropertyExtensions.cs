using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public static class PropertyExtensions
    {
        /// <summary>
        /// Gets the C# property declaration for a GIR property
        /// </summary>
        public static PropertyDeclarationSyntax GetDeclaration(this Property property)
        {
            var type = property.Type.ManagedType.ToSyntax();

            // TODO: is there a way to tell if properties are not nullable?
            if (property.Type.ManagedType == typeof(Utf8) && property.Ownership == Transfer.None) {
                type = ParseTypeName($"{typeof(NullableUnownedUtf8)}");
            }
            else if (!property.Type.ManagedType.IsValueType) {
                type = NullableType(type);
            }

            var syntax = PropertyDeclaration(type, property.ManagedName)
                .WithModifiers(property.GetCommonAccessModifiers())
                .WithAttributeLists(property.GetAttributeLists())
                .AddAttributeLists(property.GetGPropertyAttributeList())
                .WithLeadingTrivia(property.Doc.GetDocCommentTrivia());

            if (property.IsReadable) {
                var getAccessor = AccessorDeclaration(GetAccessorDeclaration)
                    .WithExpressionBody(ArrowExpressionClause(property.GetGetExpression(type)))
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

        static SyntaxList<AttributeListSyntax> GetAttributeLists(this Property property)
        {
            var list = property.GetCommonAttributeLists();

            if (!property.IsReadable && property.IsConstructOnly) {
                var arg = ParseExpression($"{typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)}");
                var attr = Attribute(ParseName(typeof(EditorBrowsableAttribute).ToString()))
                    .AddArgumentListArguments(AttributeArgument(arg));
                list = list.Insert(0, AttributeList().AddAttributes(attr));
            }

            return list;
        }

        static ExpressionSyntax GetGetExpression(this Property property, TypeSyntax type)
        {
            var getter = $"({type})GetProperty";
            if (property.Type.ManagedType == typeof(Utf8) && property.Ownership == Transfer.None) {
                getter = nameof(GISharp.Lib.GObject.Object.GetUnownedUtf8Property);
            }
            var expression = $"{getter}(\"{property.GirName}\")";
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

            // TODO: is there a way to tell if properties are not nullable?
            if (property.Type.ManagedType == typeof(Utf8) && property.Ownership == Transfer.None) {
                type = ParseTypeName($"{typeof(NullableUnownedUtf8)}");
            }
            else if (!property.Type.ManagedType.IsValueType) {
                type = NullableType(type);
            }

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
            if (property.IsConstruct) {
                construct = GPropertyConstruct.Yes;
            }
            if (property.IsConstructOnly) {
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

        /// <summary>
        /// Gets the member declarations for the properties, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Property> properties, bool forInterface = false)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var property in properties) {
                try {
                    if (forInterface) {
                        list = list.Add(property.GetInterfaceDeclaration());
                    }
                    else {
                        list = list.Add(property.GetDeclaration());
                    }
                }
                catch (Exception ex) {
                    property.LogException(ex);
                }
            }

            return list;
        }
    }
}
