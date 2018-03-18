using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
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

        internal static IEnumerable<StatementSyntax> GetVirtualMethodRegisterStatements(this Field field)
        {
            yield return LocalDeclarationStatement(field.GetOffsetDeclaration());
            yield return ExpressionStatement(field.GetRegisterVirtualFunctionExpression());
        }

        // Gets a variable declaration like:
        // IntPtr xxxOffset = Marshal.OffsetOf<Struct>(nameof(Struct.xxx));
        static VariableDeclarationSyntax GetOffsetDeclaration(this Field field)
        {
            var variableType = ParseTypeName(typeof(int).FullName);
            var variableName = field.ManagedName.ToCamelCase() + "Offset";
            var valueExpression = ParseExpression(string.Format("({0}){1}.{2}<Struct>(nameof(Struct.{3}))",
                variableType,
                typeof(Marshal),
                nameof(Marshal.OffsetOf),
                field.ManagedName));

            var declaration = VariableDeclaration(variableType)
                    .AddVariables(VariableDeclarator(variableName)
                        .WithInitializer(EqualsValueClause(valueExpression)));

            return declaration;
        }

        static ExpressionSyntax GetRegisterVirtualFunctionExpression(this Field field)
        {
            var offsetName = field.ManagedName.ToCamelCase() + "Offset";
            var factoryName = field.Callback.ManagedName + "Factory";
            var expression = $"RegisterVirtualMethod({offsetName}, {factoryName}.Create)";
            return ParseExpression(expression);
        }

        /// <summary>
        /// Gets a struct declaration containing all of the specified fields
        /// </summary>
        public static StructDeclarationSyntax GetStructDeclaration(this IEnumerable<Field> fields)
        {
            var structMembers = List<MemberDeclarationSyntax>()
                .AddRange(fields.Select(x => x.GetDeclaration()));
            var firstMember = structMembers.First();
            structMembers = structMembers.Replace(firstMember, firstMember
                .WithLeadingTrivia(ParseLeadingTrivia("#pragma warning disable CS0649\n")));
            var lastMember = structMembers.Last();
            structMembers = structMembers.Replace(lastMember, lastMember
                .WithTrailingTrivia(ParseTrailingTrivia("#pragma warning restore CS0649")));

            return StructDeclaration("Struct").WithMembers(structMembers);
        }
    }
}
