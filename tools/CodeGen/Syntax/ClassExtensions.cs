// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Gets the C# class declaration for a GIR class
        /// </summary>
        public static ClassDeclarationSyntax GetClassDeclaration(this Class @class)
        {
            var identifier = @class.ManagedName;
            return ClassDeclaration(identifier)
                .WithAttributeLists(@class.GetGTypeAttributeLists())
                .WithModifiers(@class.GetModifiers())
                .WithBaseList(@class.GetBaseList())
                .WithLeadingTrivia(@class.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        static SyntaxTokenList GetModifiers(this Class @class)
        {
            var list = TokenList(Token(PublicKeyword));

            if (@class.IsAbstract) {
                list = list.Add(Token(AbstractKeyword));
            }

            if (@class.GTypeStruct is null) {
                // if there is no GType Struct, then we know this class cannot
                // be inherited, so call it sealed
                list = list.Add(Token(SealedKeyword));
            }

            list = list.Add(Token(UnsafeKeyword));

            // partial *must* be last
            list = list.Add(Token(PartialKeyword));

            return list;
        }

        static BaseListSyntax GetBaseList(this Class @class)
        {
            var parentType = @class.ParentType?.GetManagedType() ?? "GISharp.Lib.GObject.TypeInstance";
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(ParseTypeName(parentType)))
                .AddRange(@class.Implements
                    .Select(x => SimpleBaseType(ParseTypeName(x.Interface.GetManagedType()))))
                .AddRange(@class.Functions.GetBaseListTypes())
                .AddRange(@class.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR class
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Class @class)
        {
            var members = List<MemberDeclarationSyntax>()
                .Add(@class.Fields.GetStructDeclaration().AddModifiers(Token(NewKeyword)))
                .AddRange(@class.Constants.GetMemberDeclarations())
                .AddRange(@class.Properties.GetMemberDeclarations())
                .AddRange(@class.ManagedProperties.GetMemberDeclarations())
                .AddIf(!@class.IsCustomDefaultConstructor, () => @class.GetDefaultConstructor())
                .AddRange(@class.Constructors.GetMemberDeclarations())
                .AddRange(@class.Signals.GetMemberDeclarations())
                .AddRange(@class.Implements.GetSignalMemberDeclarations())
                .AddRange(@class.Functions.GetMemberDeclarations())
                .AddRange(@class.Methods.GetMemberDeclarations())
                .AddRange(@class.VirtualMethods.GetMemberDeclarations())
                .AddRange(@class.Implements.GetVirtualMethodMemberDeclarations());

            if (@class.GTypeName is not null) {
                members = members.Insert(0, @class.GetGTypeFieldDeclaration());
            }

            return members;
        }
    }
}
