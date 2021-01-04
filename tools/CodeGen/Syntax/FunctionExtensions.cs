using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class FunctionExtensions
    {
        /// <summary>
        /// Gets the C# class member declarations for a GIR method
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Function function)
        {
            IEnumerable<MemberDeclarationSyntax> getMembers()
            {
                var checkArgsMethod = function.GetCheckArgsMethodDeclaration();
                yield return checkArgsMethod;

                yield return function.GetExternMethodDeclaration();
                if (!function.IsPInvokeOnly) {
                    yield return function.GetStaticMethodDeclaration()
                        .WithBody(Block(function.GetInvokeStatements(function.CIdentifier)));
                }

                if (function.IsCompare) {
                    yield return function.GetIComparableInterfaceMethodDeclaration();
                }

                if (function.FinishFor is not null) {
                    yield return function.GetFinishMethodDeclaration()
                        .WithBody(Block(function.GetFinishMethodStatements()));
                    foreach (var f in function.GetFinishDelegateFields()) {
                        yield return f;
                    }
                }

            }

            return List(getMembers());
        }

        /// <summary>
        /// Appends base types for interfaces implemented by functions to a class
        /// declaration, if any.
        /// </summary>
        public static SeparatedSyntaxList<BaseTypeSyntax> GetBaseListTypes(this IEnumerable<Function> functions)
        {
            var list = SeparatedList<BaseTypeSyntax>();
            foreach (var function in functions) {
                var type = (GIRegisteredType)function.ParentNode;
                if (function.IsCompare) {
                    // if we have an Compare method, then we implement the IComparable<T> interface
                    var typeName = string.Concat(typeof(IComparable<>).FullName.TakeWhile(x => x != '`'));
                    typeName = string.Format("{0}<{1}>", typeName, type.ManagedName);
                    list = list.Add(SimpleBaseType(ParseTypeName(typeName)));
                }
            }
            return list;
        }

        /// <summary>
        /// Gets a CompareTo() method implementation for <see cref="IComparable{T}"/>.
        /// </summary>
        static MethodDeclarationSyntax GetIComparableInterfaceMethodDeclaration(this Function function)
        {
            var argType = function.ManagedParameters.Last().Type.ManagedType;
            var otherParamType = argType.ToSyntax();
            var nullCheck = "";

            if (!argType.IsValueType) {
                otherParamType = NullableType(otherParamType);
                nullCheck = $"?? throw new System.ArgumentNullException(nameof(other))";
            }

            var declaration = MethodDeclaration(ParseName("System.Int32"), "CompareTo")
                .AddModifiers(Token(PublicKeyword))
                .AddParameterListParameters(Parameter(Identifier("other")).WithType(otherParamType))
                .AddBodyStatements(
                    ReturnStatement(ParseExpression($"{function.ManagedName}(this, other{nullCheck})"))
                )
                .WithLeadingTrivia(ParseLeadingTrivia($@"/// <inheritdoc/>
                /// <seealso cref=""GISharp.Lib.{function.Namespace.Name}.{function.ManagedName}""/>
                "));

            return declaration;
        }

        static SyntaxList<StatementSyntax> GetFinishMethodStatements(this Function function)
        {
            return List(function.GetFinishMethodStatements(function.FinishForFunction, function.CIdentifier));
        }

        static IEnumerable<FieldDeclarationSyntax> GetFinishDelegateFields(this Function function)
        {
            var identifier = function.FinishForFunction.ManagedName.ToCamelCase() + "Callback";
            return function.GetFinishDelegateFields(identifier);
        }

        /// <summary>
        /// Gets the member declarations for the functions, logging a warning
        /// for any exceptions that are thrown.
        /// </summary>
        internal static SyntaxList<MemberDeclarationSyntax> GetMemberDeclarations(this IEnumerable<Function> functions)
        {
            var list = List<MemberDeclarationSyntax>();

            foreach (var function in functions) {
                try {
                    list = list.AddRange(function.GetClassMembers());
                }
                catch (Exception ex) {
                    function.LogException(ex);
                }
            }

            return list;
        }
    }
}
