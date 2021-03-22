// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen.Syntax
{
    public static class NamespaceExtensions
    {
        /// <summary>
        /// Gets the C# namespace declaration for a GIR namespace
        /// </summary>
        public static NamespaceDeclarationSyntax GetDeclaration(this Namespace @namespace)
        {
            var rootNamespace = ParseName("GISharp.Lib");
            var namespaceName = IdentifierName(@namespace.Name);
            var fullName = QualifiedName(rootNamespace, namespaceName);
            return NamespaceDeclaration(fullName);
        }

        static IEnumerable<MemberDeclarationSyntax> GetDeclarations(GIBase type)
        {
            SyntaxList<MemberDeclarationSyntax> extensionMembers;

            switch (type) {
            case Alias alias:
                if (alias.Type.Interface is Callback aliasCallback) {
                    yield return aliasCallback.GetUnmanagedDeclaration(alias.GirName);
                    if (!aliasCallback.IsPInvokeOnly) {
                        yield return aliasCallback.GetManagedDeclaration(alias.GirName);
                        // TODO: how to replace the doc comment summary with alias doc element?
                        yield return aliasCallback.GetDelegateMarshalDeclaration(alias.GirName)
                            .WithMembers(aliasCallback.GetCallbackDelegateMarshalClassMembers(alias.GirName));
                    }
                }
                else if (alias.Type.IsValueType()) {
                    yield return alias.GetStructDeclaration()
                        .WithMembers(alias.GetStructMembers());
                }
                else {
                    yield return alias.GetClassDeclaration()
                    .WithMembers(alias.GetClassMembers());
                }
                break;
            case Bitfield bitfield:
                yield return bitfield.GetEnumDeclaration()
                    .WithMembers(bitfield.GetEnumMembers());
                extensionMembers = bitfield.GetExtClassMembers();
                if (extensionMembers.Any()) {
                    yield return bitfield.GetExtClassDeclaration()
                        .WithMembers(extensionMembers);
                }
                break;
            case Boxed boxed:
                yield return boxed.GetClassDeclaration()
                    .WithMembers(boxed.GetClassMembers());
                break;
            case Callback callback:
                yield return callback.GetUnmanagedDeclaration();
                if (!callback.IsPInvokeOnly) {
                    yield return callback.GetManagedDeclaration();
                    yield return callback.GetDelegateMarshalDeclaration()
                        .WithMembers(callback.GetCallbackDelegateMarshalClassMembers());
                }
                break;
            case Class @class:
                yield return @class.GetClassDeclaration()
                    .WithMembers(@class.GetClassMembers());
                break;
            case Enumeration enumeration:
                yield return enumeration.GetEnumDeclaration()
                    .WithMembers(enumeration.GetEnumMembers());
                extensionMembers = enumeration.GetExtClassMembers();
                if (extensionMembers.Any()) {
                    yield return enumeration.GetExtClassDeclaration()
                        .WithMembers(extensionMembers);
                }
                break;
            case Interface @interface:
                yield return @interface.GetInterfaceDeclaration()
                    .WithMembers(@interface.GetInterfaceMembers());
                yield return @interface.GetExtClassDeclaration()
                    .WithMembers(@interface.GetExtClassMembers());
                break;
            case Record record:
                if (record.IsGTypeStructFor is not null) {
                    yield return record.GetGTypeStructClassDeclaration()
                        .WithMembers(record.GetGTypeStructClassMembers());
                }
                else if (record.IsDisguised) {
                    yield return record.GetClassDeclaration()
                        .WithMembers(record.GetClassMembers());
                }
                else {
                    yield return record.GetStructDeclaration()
                        .WithMembers(record.GetStructMembers());
                }
                break;
            case StaticClass staticClass:
                yield return staticClass.GetClassDeclaration()
                    .WithMembers(staticClass.GetClassMembers());
                break;
            case Union union:
                yield return union.GetStructDeclaration()
                    .WithMembers(union.GetStructMembers());
                break;
            default:
                throw new ArgumentException("Unknown type declaration node", nameof(type));
            }
        }

        /// <summary>
        /// Gets the C# namespace member declarations for a GIR namespace
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetAllMembers(this Namespace @namespace)
        {
            var declarations = @namespace.AllTypes.SelectMany(x => @namespace.GetMembersFor(x));
            return List(declarations);
        }

        /// <summary>
        /// Gets the C# namespace member declarations for a GIR type
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetMembersFor(this Namespace @namespace, GIBase type)
        {
            var list = List<MemberDeclarationSyntax>();

            try {
                list = list.AddRange(GetDeclarations(type));
            }
            catch (Exception ex) {
                type.LogException(ex);
            }

            return list;
        }
    }
}
