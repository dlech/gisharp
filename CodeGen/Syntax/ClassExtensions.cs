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
                .WithLeadingTrivia(@class.Doc.GetDocCommentTrivia());
        }

        static SyntaxTokenList GetModifiers(this Class @class)
        {
            var list = TokenList(Token(PublicKeyword));

            if (@class.IsAbstract) {
                list = list.Add(Token(AbstractKeyword));
            }

            if (@class.GTypeStruct == null) {
                // if there is no GType Struct, then we know this class cannot
                // be inherited, so call it sealed
                list = list.Add(Token(SealedKeyword));
            }

            // partial *must* be last
            list = list.Add(Token(PartialKeyword));

            return list;
        }

        static BaseListSyntax GetBaseList(this Class @class)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(@class.ParentType.ToSyntax()))
                .AddRange(@class.Implements.Select(x => SimpleBaseType(x.Type.ToSyntax())))
                .AddRange(@class.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR class
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Class @class)
        {
            var members = List<MemberDeclarationSyntax>();

            if (@class.GTypeStruct != null) {
                // if there is a gtype struct, then there should be instance struct
                // fields as well
                members = members.Add(@class.Fields.GetStructDeclaration()
                    .AddModifiers(Token(ProtectedKeyword), Token(NewKeyword)));
            }

            members = members
                .AddRange(@class.Constants.Select(x => x.GetDeclaration()))
                .AddRange(@class.Properties.Select(x => x.GetDeclaration()))
                .AddRange(@class.ManagedProperties.Select(x => x.GetDeclaration()))
                .Add(@class.GetDefaultConstructor())
                .AddRange(@class.Constructors.SelectMany(x => x.GetClassMembers()))
                .AddRange(@class.Signals.SelectMany(x => x.GetClassMembers()))
                .AddRange(@class.Functions.SelectMany(x => x.GetClassMembers()))
                .AddRange(@class.Methods.SelectMany(x => x.GetClassMembers()))
                .AddRange(@class.VirtualMethods.SelectMany(x => x.GetClassMembers()))
                .AddRange(@class.Implements.SelectMany(x => x.GetVirtualMethodImplementations()));

            if (@class.GTypeName != null) {
                members = members.Insert(0, @class.GetGTypeFieldDeclaration());
            }

            return members;
        }

        static ConstructorDeclarationSyntax GetDefaultConstructor(this Class @class)
        {
            var parameterList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr), typeof(Transfer)));
            var argList = ParseArgumentList("(handle, ownership)");

            var accessModifier = @class.IsAbstract ? Token(ProtectedKeyword) : Token(PublicKeyword);

            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            var constructor = ConstructorDeclaration(@class.ManagedName)
                .AddModifiers(accessModifier)
                .WithParameterList(parameterList)
                .WithInitializer(initializer)
                .WithBody(Block());
            return constructor;
        }

    }
}
