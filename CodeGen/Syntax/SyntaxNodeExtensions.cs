using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Syntax
{
    public static class SyntaxNodeExtensions
    {
        static string GetCallableName(SyntaxToken identifier, ParameterListSyntax parameterList)
        {
            var builder = new StringBuilder(identifier.Text);
            builder.Append("(");
            builder.AppendJoin(",", parameterList.Parameters.Select(x => x.Type));
            builder.Append(")");
            return builder.ToString();
        }

        static string GetConstructordName(ConstructorDeclarationSyntax constructor)
        {
            return GetCallableName(constructor.Identifier, constructor.ParameterList);
        }

        static string GetMethodName(MethodDeclarationSyntax method)
        {
            return GetCallableName(method.Identifier, method.ParameterList);
        }

        public static string GetMemberDeclarationName(this SyntaxNode node)
        {
            switch (node) {
            case ClassDeclarationSyntax @class:
                return @class.Identifier.Text;
            case ConstructorDeclarationSyntax constructor:
                return GetConstructordName(constructor);
            case DelegateDeclarationSyntax @delegate:
                return @delegate.Identifier.Text;
            case EnumDeclarationSyntax @enum:
                return @enum.Identifier.Text;
            case EnumMemberDeclarationSyntax member:
                return member.Identifier.Text;
            case EventDeclarationSyntax @event:
                return @event.Identifier.Text;
            case EventFieldDeclarationSyntax eventField:
                return eventField.Declaration.Variables.First().Identifier.Text;
            case FieldDeclarationSyntax field:
                return field.Declaration.Variables.First().Identifier.Text;
            case InterfaceDeclarationSyntax @interface:
                return @interface.Identifier.Text;
            case PropertyDeclarationSyntax property:
                return property.Identifier.Text;
            case MethodDeclarationSyntax method:
                return GetMethodName(method);
            case StructDeclarationSyntax @struct:
                return @struct.Identifier.Text;
            }

            throw new ArgumentException($"Unknown syntax type {node.GetType()}", nameof(node));
        }
    }
}