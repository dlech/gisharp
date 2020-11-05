using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            // partial *must* be last
            list = list.Add(Token(PartialKeyword));

            return list;
        }

        static BaseListSyntax GetBaseList(this Class @class)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(@class.ParentType.ToSyntax()))
                .AddRange(@class.Implements.Select(x => SimpleBaseType(x.ManagedType.ToSyntax())))
                .AddRange(@class.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR class
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Class @class)
        {
            var members = List<MemberDeclarationSyntax>();

            if (@class.Fields.Any()) {
                members = members.Add(@class.Fields.GetStructDeclaration()
                    .AddModifiers(Token(ProtectedKeyword), Token(NewKeyword)));
            }

            members = members
                .AddRange(@class.Constants.GetMemberDeclarations())
                .AddRange(@class.Properties.GetMemberDeclarations())
                .AddRange(@class.ManagedProperties.GetMemberDeclarations())
                .Add(@class.GetDefaultConstructor())
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

        static ConstructorDeclarationSyntax GetDefaultConstructor(this Class @class)
        {
            var parameterList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr), typeof(Transfer)));
            var argList = ParseArgumentList("(handle, ownership)");

            var arg = ParseExpression($"{typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)}");
            var attr = Attribute(ParseName(typeof(EditorBrowsableAttribute).ToString()))
                .AddArgumentListArguments(AttributeArgument(arg));
            var attributeList = AttributeList().AddAttributes(attr);

            var accessModifier = @class.IsAbstract ? Token(ProtectedKeyword) : Token(PublicKeyword);

            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            var constructor = ConstructorDeclaration(@class.ManagedName)
                .AddAttributeLists(attributeList)
                .AddModifiers(accessModifier)
                .WithParameterList(parameterList)
                .WithInitializer(initializer)
                .WithBody(Block())
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// For internal runtime use only.
                /// </summary>
                "));
            return constructor;
        }

    }
}
