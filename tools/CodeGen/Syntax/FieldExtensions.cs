using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
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
        public static FieldDeclarationSyntax GetDeclaration(this Field field, bool forUnmanagedStruct)
        {
            var type = field.Type.UnmanagedType.ToSyntax();
            var variable = VariableDeclarator(field.ManagedName);

            if (field.Callback is not null) {
                type = typeof(IntPtr).ToSyntax();
            }
            else if (field.Type is Gir.Array array && array.FixedSize >= 0) {
                var elementType = array.TypeParameters.Single().UnmanagedType;

                // FIXME: this won't work on 32-bit systems.
                // Need to return multiple field declarations if type can't
                // be used be used with fixed keyword
                if (elementType == typeof(IntPtr)) {
                    elementType = typeof(long);
                }

                var allowedTypes = new[] {
                    typeof(bool),
                    typeof(byte),
                    typeof(char),
                    typeof(short),
                    typeof(int),
                    typeof(long),
                    typeof(sbyte),
                    typeof(ushort),
                    typeof(uint),
                    typeof(ulong),
                    typeof(float),
                    typeof(double),
                };
                if (!allowedTypes.Contains(elementType)) {
                    throw new NotImplementedException("fixed size buffer with unsupported type");
                }

                variable = variable.AddArgumentListArguments(
                    Argument(LiteralExpression(NumericLiteralExpression, Literal(array.FixedSize)))
                );
                type = elementType.ToSyntax();
            }
            else if (!field.Type.IsPointer && !field.Type.ManagedType.IsValueType) {
                type = ParseTypeName($"{field.Type.ManagedType}.UnmanagedStruct");
            }
            else if (field.Type.IsPointer && field.Type.ManagedType.IsValueType
                    && field.Type.ManagedType != typeof(IntPtr)) {
                type = ParseTypeName($"{field.Type.ManagedType}*");
            }
            var variableDeclaration = VariableDeclaration(type)
                .AddVariables(variable);

            var syntax = FieldDeclaration(variableDeclaration)
                .WithModifiers(field.GetModifiers(forUnmanagedStruct))
                .WithAttributeLists(field.GetCommonAttributeLists())
                .WithLeadingTrivia(field.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        private static SyntaxTokenList GetModifiers(this Field field, bool forUnmanagedStruct)
        {
            var list = TokenList();

            if (forUnmanagedStruct) {
                if (field.IsPrivate) {
                    list = list.Add(Token(PrivateKeyword));
                }
                else {
                    list = list.Add(Token(PublicKeyword));
                }
            }
            else {
                list = list.AddRange(field.GetCommonAccessModifiers());
            }

            if (field.Type is Gir.Array array && array.FixedSize >= 0) {
                list = list.Add(Token(FixedKeyword));
            }
            // readonly can't be combined with fixed
            else if (!field.IsWriteable) {
                list = list.Add(Token(ReadOnlyKeyword));
            }

            return list;
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
            var valueExpression = ParseExpression(string.Format("({0}){1}.{2}<UnmanagedStruct>(nameof(UnmanagedStruct.{3}))",
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
        public static StructDeclarationSyntax GetStructDeclaration(
            this IEnumerable<Field> fields, bool forUnmanagedStruct = true)
        {
            var structMembers = List<MemberDeclarationSyntax>()
                .AddRange(fields.Select(x => x.GetDeclaration(forUnmanagedStruct)));

            var firstMember = structMembers.First();
            var warningDisable = PragmaWarningDirectiveTrivia(Token(DisableKeyword), true)
                .AddErrorCodes(ParseExpression("CS0169"), ParseExpression("CS0649"));
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

            var declaringType = (GIRegisteredType)fields.First().ParentNode;

            return StructDeclaration("UnmanagedStruct")
                .AddModifiers(Token(PublicKeyword), Token(UnsafeKeyword))
                .WithMembers(structMembers)
                .WithLeadingTrivia(ParseLeadingTrivia($@"/// <summary>
                /// The unmanaged data structure for <see cref=""{declaringType.ManagedName}""/>.
                /// </summary>
                "));
        }
    }
}
