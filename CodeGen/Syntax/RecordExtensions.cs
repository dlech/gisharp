using System;
using System.Collections.Generic;
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
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia());
        }

        /// <summary>
        /// Gets the C# struct member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetStructMembers(this Record record)
        {
            return List<MemberDeclarationSyntax>()
                .AddRange(record.Constants.Select(x => x.GetDeclaration()))
                .AddRange(record.Fields.Select(x => x.GetDeclaration()))
                // TODO: add delegate declarations for fields that are callbacks
                .AddRange(record.ManagedProperties.Select(x => x.GetDeclaration()))
                .AddRange(record.Functions.SelectMany(x => x.GetClassMembers()))
                .AddRange(record.Methods.SelectMany(x => x.GetClassMembers()));
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
                .WithAttributeLists(record.GetGTypeAttributeLists());

            if (record.Doc != null) {
                syntax = syntax.WithLeadingTrivia(record.Doc.GetDocCommentTrivia());
            }

            return syntax;
        }

        static BaseListSyntax GetBaseList(this Record record)
        {
            var list = SeparatedList<BaseTypeSyntax>()
                .Add(SimpleBaseType(record.BaseType.ToSyntax()))
                .AddRange(record.Methods.GetBaseListTypes());
            return BaseList(list);
        }

        /// <summary>
        /// Gets the C# class member declarations for a GIR record
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetClassMembers(this Record record)
        {
            var members = List<MemberDeclarationSyntax>()
                .AddRange(record.Constants.Select(x => x.GetDeclaration()))
                .AddRange(record.ManagedProperties.Select(x => x.GetDeclaration()))
                .Add(record.GetDefaultConstructor())
                .AddRange(record.Constructors.SelectMany(x => x.GetClassMembers()))
                .AddRange(record.Functions.SelectMany(x => x.GetClassMembers()))
                .AddRange(record.Methods.SelectMany(x => x.GetClassMembers()));

            if (record.GTypeName != null) {
                members = members.Insert(0, record.GetGTypeFieldDeclaration());
            }

            return List<MemberDeclarationSyntax>(members);
        }

        static ConstructorDeclarationSyntax GetDefaultConstructor(this Record record)
        {
            var parameterList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr).FullName, typeof(Transfer).FullName));
            var argList = ParseArgumentList("(handle, ownership)");

            if (record.GTypeName != null) {
                // GType records inherit from GBoxed, so they need an extra arg
                var gtypeArg = Argument(ParseExpression("_GType"));
                argList = argList.WithArguments(argList.Arguments.Insert(0, gtypeArg));
            }

            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            var constructor = ConstructorDeclaration(record.ManagedName)
                .AddModifiers(Token(PublicKeyword))
                .WithParameterList(parameterList)
                .WithInitializer(initializer)
                .WithBody(Block());
            return constructor;
        }

        public static ClassDeclarationSyntax GetGTypeStructClassDeclaration(this Record record)
        {
            var syntax = ClassDeclaration(record.ManagedName)
                .WithAttributeLists(record.GetGTypeAttributeLists())
                .WithModifiers(record.GetGTypeStructModifiers())
                .WithBaseList(record.GetGTypeStructBaseList())
                .WithLeadingTrivia(record.Doc.GetDocCommentTrivia());

            return syntax;
        }

        static SyntaxTokenList GetGTypeStructModifiers(this Record record)
        {
            var list = TokenList(Token(PublicKeyword));

            if (record.IsGTypeStructFor != null &&
                record.BaseType == typeof(TypeInterface))
            {
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

        static MethodDeclarationSyntax GetGTypeStructCreateInterfaceInfoMethod(this Record record)
        {
            var method = MethodDeclaration(
                ParseTypeName(typeof(InterfaceInfo).FullName),
                nameof(TypeInterface.CreateInterfaceInfo))
                .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                .AddParameterListParameters(Parameter(ParseToken("type"))
                    .WithType(ParseTypeName(typeof(System.Type).FullName)))
                .AddBodyStatements(
                    ParseStatement(string.Format(@"var ret = new {0} {{
                        InterfaceInit = InterfaceInit,
                    }};
                    ", typeof(InterfaceInfo).FullName)),
                    ParseStatement("return ret;"));

            return method;
        }

        static MethodDeclarationSyntax GetGTypeStructInterfaceInitMethod(this Record record)
        {
            var method = MethodDeclaration(
                PredefinedType(Token(VoidKeyword)), "InterfaceInit")
                .AddModifiers(Token(StaticKeyword))
                .AddParameterListParameters(
                    Parameter(ParseToken("gIface"))
                        .WithType(ParseTypeName(typeof(IntPtr).FullName)),
                    Parameter(ParseToken("userData"))
                        .WithType(ParseTypeName(typeof(IntPtr).FullName)))
                .WithBody(Block(record.GetGTypeStructInterfaceInitStatements()));

            return method;
        }

        static IEnumerable<StatementSyntax> GetGTypeStructInterfaceInitStatements(this Record record)
        {
            foreach (var f in record.Fields.Where(x => x.Callback != null)) {
                var methodName = f.ManagedName;
                var delegateName = "Unmanaged" + f.Callback.ManagedName;
                var prefix = methodName.ToCamelCase();

                var statement = string.Format("{0}.WriteIntPtr(gIface, (int){1}Offset, {1}Delegate_);\n",
                    typeof(Marshal).FullName, prefix);
                yield return ParseStatement(statement);
            }
        }

        static MethodDeclarationSyntax GetGTypeStructGetInfoMethod(this Record record)
        {
            var method = MethodDeclaration(
                ParseTypeName(typeof(GISharp.Lib.GObject.TypeInfo).FullName),
                nameof(TypeClass.GetTypeInfo))
                .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                .AddParameterListParameters(Parameter(ParseToken("type"))
                    .WithType(ParseTypeName(typeof(System.Type).FullName)))
                .AddBodyStatements(
                    ParseStatement($"throw new {typeof(NotImplementedException).FullName} ();"));

            return method;
        }

        public static SyntaxList<MemberDeclarationSyntax> GetGTypeStructClassMembers(this Record record)
        {
            var list = List<MemberDeclarationSyntax>();

            // emit helpers for marshalling fields
            foreach (var f in record.Fields) {
                list = list.Add(f.GetOffsetDeclaration());
                if (f.Callback != null) {
                    list = list.Add(f.GetDelegateDeclaration());
                    list = list.Add(f.GetDelegatePtrDeclaration());
                }
            }

            // emit a struct that matches the unmanaged data struct
            var structMembers = List<MemberDeclarationSyntax>()
                .AddRange(record.Fields.Select(x => x.GetDeclaration()));
            var firstMember = structMembers.First();
            structMembers = structMembers.Replace(firstMember, firstMember
                .WithLeadingTrivia(ParseLeadingTrivia("#pragma warning disable CS0649\n")));
            var lastMember = structMembers.Last();
            structMembers = structMembers.Replace(lastMember, lastMember
                .WithTrailingTrivia(ParseTrailingTrivia("#pragma warning restore CS0649")));
            var structDeclaration = StructDeclaration("Struct")
                .AddModifiers(Token(NewKeyword))
                .WithMembers(structMembers);

            if (record.BaseType != typeof(TypeInterface)) {
                structDeclaration = structDeclaration.AddModifiers(Token(ProtectedKeyword));
            }

            list = list.Add(structDeclaration);

            // emit the unmanaged delegate types for callback fields
            foreach (var f in record.Fields.Where(x => x.Callback != null)) {
                list = list.Add(f.Callback.GetUnmanagedDeclaration());
                list = list.Add(f.GetUnmanagedCallbackGetter());
            }

            list = list.Add(record.GetGTypeStructDefaultConstructor());
            // taking advantage of the fact that GObject interfaces can't inherit,
            // so parent will always be GISharp.Lib.GObject.TypeInterface for
            // interfaces.
            if (record.BaseType == typeof(TypeInterface)) {
                list = list.Add(record.GetGTypeStructCreateInterfaceInfoMethod());
                list = list.Add(record.GetGTypeStructInterfaceInitMethod());
            }
            else {
                list = list.Add(record.GetGTypeStructGetInfoMethod());
            }

            list = list.AddRange(record.Fields.Where(x => x.Callback != null)
                .Select(x => x.Callback.GetVirtualMethodDeclaration()));

            return list;
        }

        static ConstructorDeclarationSyntax GetGTypeStructDefaultConstructor(this Record record)
        {
            var modifiers = TokenList().Add(Token(PublicKeyword));
            var paramerList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr).FullName,
                typeof(GISharp.Runtime.Transfer).FullName));
            var argList = ParseArgumentList("(handle, ownership)");
            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            return ConstructorDeclaration(record.ManagedName)
                .WithModifiers(modifiers)
                .WithParameterList(paramerList)
                .WithInitializer(initializer)
                .WithBody(Block());
        }
    }
}
