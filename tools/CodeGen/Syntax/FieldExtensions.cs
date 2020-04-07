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
            var type = field.Type.UnmanagedType.ToSyntax();
            if (field.Callback != null) {
                type = typeof(IntPtr).ToSyntax();
            }
            else if (!field.Type.IsPointer && !field.Type.ManagedType.IsValueType) {
                type = ParseTypeName($"{field.Type.ManagedType}.Struct");
            }
            else if (field.Type.IsPointer && field.Type.ManagedType.IsValueType
                    && field.Type.ManagedType != typeof(IntPtr)) {
                type = ParseTypeName($"{field.Type.ManagedType}*");
            }
            var variable = VariableDeclarator(field.ManagedName);
            var variableDeclaration = VariableDeclaration(type)
                .AddVariables(variable);

            var syntax = FieldDeclaration(variableDeclaration)
                .WithModifiers(field.GetCommonAccessModifiers())
                .WithAttributeLists(field.GetCommonAttributeLists())
                .WithLeadingTrivia(field.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

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
            var offset = field.ManagedName.ToCamelCase() + "Offset";
            var marshal = field.Callback.ManagedName + "Marshal";
            var expression = $"RegisterVirtualMethod({offset}, {marshal}.Create)";
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
            var warningDisable = PragmaWarningDirectiveTrivia(Token(DisableKeyword), true)
                .AddErrorCodes(ParseExpression("CS0649"));
            structMembers = structMembers.Replace(firstMember, firstMember
                .WithLeadingTrivia(firstMember.GetLeadingTrivia()
                    .Prepend(EndOfLine("\n"))
                    .Prepend(Trivia(warningDisable))));

            var warningRestore = warningDisable.WithDisableOrRestoreKeyword(Token(RestoreKeyword));
            var lastMember = structMembers.Last();
            structMembers = structMembers.Replace(lastMember, lastMember
                .WithTrailingTrivia(lastMember.GetTrailingTrivia()
                    .Append(Trivia(warningRestore))
                    .Append(EndOfLine("\n"))));

            return StructDeclaration("Struct")
                .AddModifiers(Token(UnsafeKeyword))
                .WithMembers(structMembers)
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// Unmanaged data structure
                /// </summary>
                "));
        }
    }
}
