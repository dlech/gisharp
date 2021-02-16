// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
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
            if (type.GTypeName is null) {
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
            if (type.GTypeName is not null) {
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
            if (type.GTypeStruct is not null) {
                var attrName = ParseName(typeof(GTypeStructAttribute).FullName);
                var typeArg = AttributeArgument(ParseExpression($"typeof({type.GTypeStruct})"));

                list = list.Add(AttributeList().AddAttributes(Attribute(attrName).
                    AddArgumentListArguments(typeArg)));
            }

            return list;
        }

        public static ConstructorDeclarationSyntax GetDefaultConstructor(this GIRegisteredType type)
        {
            var parameterList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr), typeof(Transfer)));
            var argList = ParseArgumentList("(handle, ownership)");

            var arg = ParseExpression($"{typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)}");
            var attr = Attribute(ParseName(typeof(EditorBrowsableAttribute).ToString()))
                .AddArgumentListArguments(AttributeArgument(arg));
            var attributeList = AttributeList().AddAttributes(attr);

            // abstract classes can't have public constructors
            var accessModifier = (type is Class @class && @class.IsAbstract) ?
                Token(ProtectedKeyword) : Token(PublicKeyword);

            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            var body = Block();

            if (type.Methods.SingleOrDefault(x => x.IsRef || x.IsCopy) is Method method) {
                initializer = initializer.WithArgumentList(ParseArgumentList("(handle)"));
                body = body.AddStatements(IfStatement(ParseExpression(
                    $"ownership == {typeof(Transfer)}.{nameof(Transfer.None)}"
                ), Block(ExpressionStatement(ParseExpression(
                    $"this.handle = (System.IntPtr){method.CIdentifier}((UnmanagedStruct*)handle)"
                )))));
            }
            else if (type is Record && type.GTypeName is not null) {
                throw new ArgumentException("Boxed GType should have ref or copy function.");
            }

            var constructor = ConstructorDeclaration(type.ManagedName)
                .AddAttributeLists(attributeList)
                .AddModifiers(accessModifier)
                .WithParameterList(parameterList)
                .WithInitializer(initializer)
                .WithBody(body)
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// For internal runtime use only.
                /// </summary>
                "));
            return constructor;
        }
    }
}
