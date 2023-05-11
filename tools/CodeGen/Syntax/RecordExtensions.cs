// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class RecordExtensions
    {
        /// <summary>
        /// Gets the C# struct declaration for a GIR record
        /// </summary>
        public static StructDeclarationSyntax GetStructDeclaration(this Record record)
        {
            var identifier = record.GirName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(UnsafeKeyword), Token(PartialKeyword))
                .WithAttributeLists(record.GetGTypeAttributeLists())
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Record record)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddIf(
                    record.GTypeName is not null && record.GTypeGetter != "intern",
                    () => record.GetGTypeFieldDeclaration()
                )
                .AddRange(record.Constants.GetMemberDeclarations())
                .AddRange(record.Fields.GetStructDeclaration(forUnmanagedStruct: false).Members)
                .AddRange(record.ManagedProperties.GetMemberDeclarations())
                .AddRange(record.Functions.GetMemberDeclarations())
                .AddRange(record.Methods.GetMemberDeclarations());

            return members;
        }

        /// <summary>
        /// Gets the C# struct declaration for a GIR record
        /// </summary>
        public static ClassDeclarationSyntax GetClassDeclaration(this Record record)
        {
            var identifier = record.GirName;

            var syntax = ClassDeclaration(identifier)
                .WithModifiers(
                    TokenList(
                        record
                            .GetInheritanceModifiers(Token(SealedKeyword))
                            .Prepend(Token(PublicKeyword))
                            .Append(Token(UnsafeKeyword))
                            .Append(Token(PartialKeyword))
                    )
                )
                .WithBaseList(record.GetBaseList())
                .WithAttributeLists(record.GetGTypeAttributeLists())
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        static BaseListSyntax GetBaseList(this Record record)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(ParseTypeName(record.BaseType)))
                .AddRange(record.Functions.GetBaseListTypes())
                .AddRange(record.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Record record)
        {
            var fieldStructModifiers = new List<SyntaxToken>();
            if (record.BaseType != typeof(Opaque).FullName)
            {
                fieldStructModifiers.Add(Token(NewKeyword));
            }

            var members = List<MemberDeclarationSyntax>()
                .AddIf(
                    record.GTypeName is not null && record.GTypeGetter != "intern",
                    () => record.GetGTypeFieldDeclaration()
                )
                .Add(
                    record.Fields
                        .GetStructDeclaration()
                        .AddModifiers(fieldStructModifiers.ToArray())
                )
                .AddRange(record.Constants.GetMemberDeclarations())
                .AddRange(record.ManagedProperties.GetMemberDeclarations())
                .AddIf(!record.IsCustomDefaultConstructor, () => record.GetDefaultConstructor())
                .AddRange(record.Constructors.GetMemberDeclarations())
                .AddRange(record.Functions.GetMemberDeclarations())
                .AddRange(record.Methods.GetMemberDeclarations());

            return members;
        }

        public static ClassDeclarationSyntax GetGTypeStructClassDeclaration(this Record record)
        {
            var syntax = ClassDeclaration(record.GirName)
                .WithAttributeLists(record.GetGTypeAttributeLists())
                .WithModifiers(record.GetGTypeStructModifiers())
                .WithBaseList(record.GetGTypeStructBaseList())
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        static SyntaxTokenList GetGTypeStructModifiers(this Record record)
        {
            var list = TokenList(Token(PublicKeyword));

            if (
                record.IsGTypeStructFor is not null
                && record.BaseType == "GISharp.Lib.GObject.TypeInterface"
            )
            {
                // interfaces cannot be inherited
                list = list.Add(Token(SealedKeyword));
            }

            list = list.Add(Token(UnsafeKeyword));
            list = list.Add(Token(PartialKeyword));

            return list;
        }

        static BaseListSyntax GetGTypeStructBaseList(this Record record)
        {
            var parentType = ParseTypeName(record.BaseType);
            return BaseList().AddTypes(SimpleBaseType(parentType));
        }

        public static SyntaxList<MemberDeclarationSyntax> GetGTypeStructClassMembers(
            this Record record
        )
        {
            var list = List<MemberDeclarationSyntax>();

            // create a struct that contains the unmanaged fields

            var structDeclaration = record.Fields
                .GetStructDeclaration()
                .AddModifiers(Token(NewKeyword));

            list = list.Add(structDeclaration);

            list = list.Add(record.GetGTypeStructStaticConstructor());

            // emit the unmanaged delegate types for callback fields

            foreach (var f in record.Fields.Where(x => x.Callback is not null))
            {
                try
                {
                    list = list.Add(f.Callback.GetManagedDeclaration($"_{f.Callback.ManagedName}"))
                        .Add(f.Callback.GetUnmanagedDeclaration())
                        .Add(
                            f.Callback
                                .GetDelegateMarshalDeclaration()
                                .WithMembers(f.Callback.GetVirtualMethodDelegateMarshalMembers())
                        );
                }
                catch (Exception ex)
                {
                    f.LogException(ex);
                }
            }

            // add the default constructor

            if (!record.IsCustomDefaultConstructor)
            {
                list = list.Add(record.GetDefaultConstructor());
            }

            list = list.AddRange(record.Constructors.GetMemberDeclarations())
                .AddRange(record.Functions.GetMemberDeclarations())
                .AddRange(record.Methods.GetMemberDeclarations());

            return list;
        }

        static ConstructorDeclarationSyntax GetGTypeStructStaticConstructor(this Record record)
        {
            var constructor = ConstructorDeclaration(record.GirName)
                .AddModifiers(Token(StaticKeyword));

            constructor = constructor.AddBodyStatements(
                record.Fields
                    .Where(x => x.Callback is not null)
                    .SelectMany(x => x.GetVirtualMethodRegisterStatements())
                    .ToArray()
            );

            return constructor;
        }
    }
}
