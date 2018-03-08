using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using GISharp.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class FieldExtensions
    {
        /// <summary>
        /// Gets a C# field declaration for a GIR field
        /// </summary>
        public static FieldDeclarationSyntax GetDeclaration(this Field field)
        {
            var type = field.GirType.UnmanagedType.ToSyntax();
            var variable = VariableDeclarator(field.ManagedName);
            var variableDeclaration = VariableDeclaration(type)
                .AddVariables(variable);

            var syntax = FieldDeclaration(variableDeclaration)
                .WithModifiers(field.GetAccessModifiers())
                .WithAttributeLists(field.GetCommonAttributeLists())
                .WithLeadingTrivia(field.Doc.GetDocCommentTrivia());

            return syntax;
        }

        // Gets a field declaration like:
        // static readonly IntPtr xxxOffset = Marshal.OffsetOf<Struct>(nameof(Struct.xxx));
        public static FieldDeclarationSyntax GetOffsetDeclaration(this Field field)
        {
            var variableType = ParseTypeName(typeof(int).FullName);
            var variableName = field.ManagedName.ToCamelCase() + "Offset";
            var valueExpression = ParseExpression(string.Format("({0}){1}.{2}<Struct>(nameof(Struct.{3}))",
                variableType,
                typeof(Marshal).FullName,
                nameof(Marshal.OffsetOf),
                field.ManagedName));

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator(variableName)
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        // Gets a field declaration like:
        // static readonly UnmanagedYyy xxxDelegate = OnYyy;
        public static FieldDeclarationSyntax GetDelegateDeclaration(this Field field)
        {
            if (field.Callback == null) {
                throw new InvalidOperationException("Must be a callback field");
            }

            var variableType = ParseTypeName("Unmanaged" + field.Callback.ManagedName);
            var variableName = field.ManagedName.ToCamelCase() + "Delegate";
            var valueExpression = ParseExpression("On" + field.Callback.ManagedName);

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator(variableName)
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        // Gets a field declaration like:
        // static readonly IntPtr xxxDelegate_ = Marshal.GetFunctionPointerForDelegate(xxxDelegate);
        public static FieldDeclarationSyntax GetDelegatePtrDeclaration(this Field field)
        {
            if (field.Callback == null) {
                throw new InvalidOperationException("Must be a callback field");
            }

            var variableType = ParseTypeName(typeof(IntPtr).FullName);
            var variableName = field.ManagedName.ToCamelCase() + "Delegate";
            var valueExpression = ParseExpression(string.Format("{0}.{1}({2})",
                typeof(Marshal).FullName,
                nameof(Marshal.GetFunctionPointerForDelegate),
                variableName));

            var declaration = FieldDeclaration(VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator($"{variableName}_")
                        .WithInitializer(EqualsValueClause(valueExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            return declaration;
        }

        // Gets a property declaration like:
        // public UnmanagedSomethingChanged OnSomethingChangedDelegate =>
        //      GMarshal.GetVirtualMethodDelegate<UnmanagedSomethingChanged>(Handle, onSomethingChangedOffset);
        public static PropertyDeclarationSyntax GetUnmanagedCallbackGetter(this Field field)
        {
            var typeName = ParseTypeName("Unmanaged" + field.Callback.ManagedName);
            var expression = ParseExpression(string.Format("{0}.{1}<{2}>(Handle, {3})",
                typeof(GMarshal).FullName,
                nameof(GMarshal.GetVirtualMethodDelegate),
                typeName,
                field.GetOffsetDeclaration().Declaration.Variables[0].Identifier));

            return PropertyDeclaration(typeName, field.ManagedName + "Delegate")
                .AddModifiers(Token(PublicKeyword))
                .WithExpressionBody(ArrowExpressionClause(expression)
                    .WithLeadingTrivia(Whitespace("\n")))
                .WithSemicolonToken(Token(SemicolonToken));
        }
    }
}
