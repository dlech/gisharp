using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GObject;
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
            var identifier = record.ManagedName;
            return StructDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(PartialKeyword))
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Record record)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(record.Constants.GetMemberDeclarations())
                .AddRange(record.Fields.GetStructDeclaration().Members)
                .AddRange(record.ManagedProperties.GetMemberDeclarations())
                .AddRange(record.Functions.GetMemberDeclarations())
                .AddRange(record.Methods.GetMemberDeclarations());
        }

        /// <summary>
        /// Gets the C# struct declaration for a GIR record
        /// </summary>
        public static ClassDeclarationSyntax GetClassDeclaration(this Record record)
        {
            var identifier = record.ManagedName;

            var syntax = ClassDeclaration(identifier)
                .AddModifiers(Token(PublicKeyword), Token(SealedKeyword), Token(PartialKeyword))
                .WithBaseList(record.GetBaseList())
                .WithAttributeLists(record.GetGTypeAttributeLists())
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia())
                .WithAdditionalAnnotations(new SyntaxAnnotation("extern doc"));

            return syntax;
        }

        static BaseListSyntax GetBaseList(this Record record)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(record.BaseType.ToSyntax()))
                .AddRange(record.Functions.GetBaseListTypes())
                .AddRange(record.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Record record)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddRange(record.Constants.GetMemberDeclarations())
                .AddRange(record.ManagedProperties.GetMemberDeclarations())
                .Add(record.GetDefaultConstructor())
                .AddRange(record.Constructors.GetMemberDeclarations())
                .AddRange(record.Functions.GetMemberDeclarations())
                .AddRange(record.Methods.GetMemberDeclarations());

            if (record.Fields.Any()) {
                members = members.Insert(0, record.Fields.GetStructDeclaration());
            }

            if (record.GTypeName is not null) {
                members = members.Insert(0, record.GetGTypeFieldDeclaration());
            }

            return members;
        }

        static ConstructorDeclarationSyntax GetDefaultConstructor(this Record record)
        {
            var parameterList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr), typeof(Transfer)));
            var argList = ParseArgumentList("(handle, ownership)");

            if (record.GTypeName is not null) {
                // GType records inherit from GBoxed, so they need an extra arg
                var gtypeArg = Argument(ParseExpression("_GType"));
                argList = argList.WithArguments(argList.Arguments.Insert(0, gtypeArg));
            }

            var arg = ParseExpression($"{typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)}");
            var attr = Attribute(ParseName(typeof(EditorBrowsableAttribute).ToString()))
                .AddArgumentListArguments(AttributeArgument(arg));
            var attributeList = AttributeList().AddAttributes(attr);

            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            var constructor = ConstructorDeclaration(record.ManagedName)
                .AddAttributeLists(attributeList)
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(parameterList)
                .WithInitializer(initializer)
                .WithBody(Block())
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// For internal runtime use only.
                /// </summary>
                "));
            return constructor;
        }

        public static ClassDeclarationSyntax GetGTypeStructClassDeclaration(this Record record)
        {
            var syntax = ClassDeclaration(record.ManagedName)
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

            if (record.IsGTypeStructFor is not null &&
                record.BaseType == typeof(TypeInterface)) {
                // interfaces cannot be inherited
                list = list.Add(Token(SealedKeyword));
            }

            return list;
        }

        static BaseListSyntax GetGTypeStructBaseList(this Record record)
        {
            var parentType = record.BaseType.ToSyntax();
            return BaseList().AddTypes(SimpleBaseType(parentType));
        }

        public static SyntaxList<MemberDeclarationSyntax> GetGTypeStructClassMembers(this Record record)
        {
            var list = List<MemberDeclarationSyntax>();

            // create a struct that contains the unmanaged fields

            var structDeclaration = record.Fields.GetStructDeclaration()
                .AddModifiers(Token(NewKeyword));

            list = list.Add(structDeclaration);

            list = list.Add(record.GetGTypeStructStaticConstructor());

            // emit the unmanaged delegate types for callback fields

            foreach (var f in record.Fields.Where(x => x.Callback is not null)) {
                try {
                    list = list.Add(f.Callback.GetManagedDeclaration())
                        .Add(f.Callback.GetUnmanagedDeclaration())
                        .Add(f.Callback.GetDelegateMarshalDeclaration()
                            .WithMembers(f.Callback.GetVirtualMethodDelegateMarshalMembers()));
                }
                catch (Exception ex) {
                    f.LogException(ex);
                }
            }

            // add the default constructor

            list = list.Add(record.GetGTypeStructDefaultConstructor());

            return list;
        }

        static ConstructorDeclarationSyntax GetGTypeStructStaticConstructor(this Record record)
        {
            var constructor = ConstructorDeclaration(record.ManagedName)
                .AddModifiers(Token(StaticKeyword));

            constructor = constructor.AddBodyStatements(record.Fields
                .Where(x => x.Callback is not null)
                .SelectMany(x => x.GetVirtualMethodRegisterStatements()).ToArray());

            return constructor;
        }

        static ConstructorDeclarationSyntax GetGTypeStructDefaultConstructor(this Record record)
        {
            var paramerList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr),
                typeof(GISharp.Runtime.Transfer)));
            var argList = ParseArgumentList("(handle, ownership)");
            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            return ConstructorDeclaration(record.ManagedName)
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(paramerList)
                .WithInitializer(initializer)
                .WithBody(Block())
                .WithLeadingTrivia(ParseLeadingTrivia(@"/// <summary>
                /// For internal runtime use only.
                /// </summary>
                "));
        }
    }
}
