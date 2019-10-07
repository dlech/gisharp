using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class GIRegisteredTypeExtensions
    {
        /// <summary>
        /// Gets the field declaration for the _GType field.
        /// </summary>
        public static FieldDeclarationSyntax GetGTypeFieldDeclaration(this GIRegisteredType type)
        {
            if (type.GTypeName == null) {
                throw new InvalidOperationException("Type is not a GType");
            }
            // emits: static readonly GType _GType = xxx_get_type();
            var typeName = typeof(GType).ToSyntax();
            var identifier = ParseToken("_GType");
            var expression = ParseExpression($"{type.GTypeGetter}()");

            return FieldDeclaration(VariableDeclaration(typeName)
                    .AddVariables(VariableDeclarator(identifier)
                        .WithInitializer(EqualsValueClause(expression))))
                .AddModifiers(Token(PrivateKeyword), Token(StaticKeyword), Token(ReadOnlyKeyword));
        }

        public static SyntaxList<AttributeListSyntax> GetGTypeAttributeLists(this GIRegisteredType type)
        {
            var list = type.GetCommonAttributeLists();

            // If type is a GType, then decorate it with the GTypeAttribute
            if (type.GTypeName != null) {
                var attrName = ParseName(typeof(GTypeAttribute).FullName);

                var name = $"\"{type.GTypeName}\"";
                var nameArg = AttributeArgument(ParseExpression(name));

                var isProxy = string.Format("{0} = true",
                    nameof(GTypeAttribute.IsProxyForUnmanagedType));
                var isProxyArg = AttributeArgument(ParseExpression(isProxy));

                list = list.Add(AttributeList().AddAttributes(Attribute(attrName)
                    .AddArgumentListArguments(nameArg, isProxyArg)));
            }

            // If a type has an associate GType struct, decorate it with the GTypeStructAttribute
            if (type.GTypeStruct != null) {
                var attrName = ParseName(typeof(GTypeStructAttribute).FullName);
                var typeArg = AttributeArgument(ParseExpression($"typeof({type.GTypeStruct})"));

                list = list.Add(AttributeList().AddAttributes(Attribute(attrName).
                    AddArgumentListArguments(typeArg)));
            }

            return list;
        }
    }
}
