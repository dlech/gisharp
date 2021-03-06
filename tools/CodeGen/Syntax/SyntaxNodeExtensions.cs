// SPDX-License-Identifier: MIT
// Copyright (c) 2019 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GISharp.CodeGen.Syntax
{
    public static class SyntaxNodeExtensions
    {
        static string GetQualifiedName(MemberDeclarationSyntax member, SyntaxToken identifier)
        {
            var typeDecl = (BaseTypeDeclarationSyntax)member.Ancestors().First(x => x is BaseTypeDeclarationSyntax);
            return $"{typeDecl.Identifier.Text}.{identifier.Text}";
        }

        static string GetCallableName(string memberName, ParameterListSyntax parameterList)
        {
            var builder = new StringBuilder(memberName);
            builder.Append('(');
            builder.AppendJoin(',', parameterList.Parameters.Select(x => x.Type));
            builder.Append(')');
            return builder.ToString();
        }

        static string GetConstructorName(ConstructorDeclarationSyntax constructor)
        {
            var name = GetQualifiedName(constructor, constructor.Identifier);
            return GetCallableName(name, constructor.ParameterList);
        }

        static string GetMethodName(MethodDeclarationSyntax method)
        {
            var name = GetQualifiedName(method, method.Identifier);
            return GetCallableName(name, method.ParameterList);
        }

        public static string GetMemberDeclarationName(this SyntaxNode node)
        {
            return node switch {
                ClassDeclarationSyntax @class => @class.Identifier.Text,
                ConstructorDeclarationSyntax constructor => GetConstructorName(constructor),
                DelegateDeclarationSyntax @delegate => @delegate.Identifier.Text,
                EnumDeclarationSyntax @enum => @enum.Identifier.Text,
                EnumMemberDeclarationSyntax member => GetQualifiedName(member, member.Identifier),
                EventDeclarationSyntax @event => GetQualifiedName(@event, @event.Identifier),
                EventFieldDeclarationSyntax eventField => GetQualifiedName(eventField, eventField.Declaration.Variables.First().Identifier),
                FieldDeclarationSyntax field => GetQualifiedName(field, field.Declaration.Variables.First().Identifier),
                InterfaceDeclarationSyntax @interface => @interface.Identifier.Text,
                PropertyDeclarationSyntax property => GetQualifiedName(property, property.Identifier),
                MethodDeclarationSyntax method => GetMethodName(method),
                StructDeclarationSyntax @struct => @struct.Identifier.Text,

                _ => throw new ArgumentException($"Unknown syntax type {node.GetType()}", nameof(node)),
            };
        }
    }
}
