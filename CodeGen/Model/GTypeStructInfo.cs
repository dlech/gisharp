﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using GISharp.GObject;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Model
{
    /// <summary>
    /// Wraps elements from a fixed up .gir file that declare a class.
    /// </summary>
    public class GTypeStructInfo : MemberInfo
    {
        /// <summary>
        /// Gets the instance type for this GType struct
        /// </summary>
        public Type InstanceType => _InstanceType.Value;
        readonly Lazy<Type> _InstanceType;

        /// <summary>
        /// Gets the parent type for this GType struct
        /// </summary>
        public Type ParentType => _ParentType.Value;
        readonly Lazy<Type> _ParentType;

        public IReadOnlyList<FieldInfo> FieldInfos => _FieldInfos.Value;
        readonly Lazy<IReadOnlyList<FieldInfo>> _FieldInfos;

        /// <summary>
        /// Gets the list of member declarations for the class
        /// </summary>
        public SyntaxList<MemberDeclarationSyntax> ClassMembers => _ClassMembers.Value;
        readonly Lazy<SyntaxList<MemberDeclarationSyntax>> _ClassMembers;

        /// <summary>
        /// Gets the base list syntax for the class declaration.
        /// </summary>
        public BaseListSyntax BaseList => _BaseList.Value;
        readonly Lazy<BaseListSyntax> _BaseList;

        /// <summary>
        /// Gets the class declaration (no members)
        /// </summary>
        public ClassDeclarationSyntax ClassDeclaration => _ClassDeclaration.Value;
        readonly Lazy<ClassDeclarationSyntax> _ClassDeclaration;

        /// <summary>
        /// Gets the default constructor declaration syntax for the class.
        /// </summary>
        /// <value>The default constructor.</value>
        public ConstructorDeclarationSyntax DefaultConstructor => _DefaultConstructor.Value;
        readonly Lazy<ConstructorDeclarationSyntax> _DefaultConstructor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GTypeStructInfo"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="declaringMember">Declaring member.</param>
        /// <exception cref="ArgumentException">If the element is not an element that declares a GType struct.</exception>
        public GTypeStructInfo(XElement element, MemberInfo declaringMember)
            : base(element, declaringMember)
        {
            if (element.Name != gi + "record" || element.Attribute(glib + "is-gtype-struct-for") == null) {
                throw new ArgumentException("Requires <record glib:is-gtype-struct-for='...'> element.", nameof(element));
            }
            _InstanceType = new Lazy<Type>(GetInstanceType);
            _ParentType = new Lazy<Type>(GetParentType);
            _FieldInfos = new Lazy<IReadOnlyList<FieldInfo>>(() => GetFieldInfos().ToList().AsReadOnly());
            _ClassMembers = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetClassMemberDeclarations()));
            _BaseList = new Lazy<BaseListSyntax>(() => BaseList(SeparatedList(GetBaseTypes())));
            _ClassDeclaration = new Lazy<ClassDeclarationSyntax>(GetClassDeclaration);
            _DefaultConstructor = new Lazy<ConstructorDeclarationSyntax>(GetDefaultConstructor);
        }

        Type GetInstanceType()
        {
            var typeName = Element.Attribute(glib + "is-gtype-struct-for").AsString();
            var instanceType = GirType.ResolveType(typeName, Element.Document);
            return instanceType;
        }

        Type GetParentType()
        {
            return FieldInfos.First().TypeInfo.TypeObject.DeclaringType;
        }

        IEnumerable<FieldInfo> GetFieldInfos()
        {
            return Element.Elements(gi + "field").Select(x => new FieldInfo(x, this));
        }

        internal override IEnumerable<BaseInfo> GetChildInfos()
        {
            return FieldInfos;
        }

        protected override IEnumerable<SyntaxToken> GetModifiers()
        {
            return base.GetModifiers().Concat(GetGTypeClassModifiers());
        }

        IEnumerable<SyntaxToken> GetGTypeClassModifiers()
        {
            if (ParentType == typeof(TypeInterface)) {
                yield return Token(SealedKeyword);
            }
            yield return Token(PartialKeyword);
        }

        IEnumerable<SyntaxToken> GetStructModifiers()
        {
            if (ParentType != typeof(TypeInterface)) {
                yield return Token(ProtectedKeyword);
            }
        }

        ClassDeclarationSyntax GetClassDeclaration()
        {
            var declaration = ClassDeclaration(Identifier)
                .WithAttributeLists(AttributeLists)
                .WithModifiers(Modifiers)
                .WithLeadingTrivia(DocumentationCommentTriviaList);
            if (BaseList.Types.Any()) {
                declaration = declaration.WithBaseList(BaseList);
            }
            return declaration;
        }

        protected override IEnumerable<MemberDeclarationSyntax> GetAllDeclarations()
        {
            ClassDeclarationSyntax declaration;

            try {
                declaration = ClassDeclaration.WithMembers(ClassMembers);
            } catch (Exception ex) {
                Console.Error.WriteLine($"Skipping {QualifiedName} due to error: {ex.Message}");
                yield break;
            }

            yield return declaration;
        }

        MethodDeclarationSyntax GetGTypeStructCreateInterfaceInfoMethod()
        {
            var method = MethodDeclaration(
                ParseTypeName(typeof(GObject.InterfaceInfo).FullName),
                nameof(TypeInterface.CreateInterfaceInfo))
                .AddModifiers(
                    Token(PublicKeyword),
                    Token(OverrideKeyword))
                .AddParameterListParameters(Parameter(ParseToken("type"))
                    .WithType(ParseTypeName(typeof(Type).FullName)))
                .AddBodyStatements(
                    ParseStatement(string.Format(@"var ret = new {0} {{
                        InterfaceInit = InterfaceInit,
                    }};
                    ", typeof(GObject.InterfaceInfo).FullName)),
                    ParseStatement("return ret;"));

            return method;
        }

        MethodDeclarationSyntax GetGTypeStructInterfaceInitMethod()
        {
            var method = MethodDeclaration(
                PredefinedType(Token(VoidKeyword)), "InterfaceInit")
                .AddModifiers(Token(StaticKeyword))
                .AddParameterListParameters(
                    Parameter(ParseToken("gIface"))
                        .WithType(ParseTypeName(typeof(IntPtr).FullName)),
                    Parameter(ParseToken("userData"))
                        .WithType(ParseTypeName(typeof(IntPtr).FullName)))
                .WithBody(Block(GetGTypeStructInterfaceInitStatements()));

            return method;
        }

        IEnumerable<StatementSyntax> GetGTypeStructInterfaceInitStatements()
        {
            const string structName = "Struct";
            string statement;
            foreach (var f in FieldInfos.Where(x => x.IsCallback)) {
                var methodName = f.ManagedName;
                var delegateName = "Unmanaged" + f.CallbackInfo.ManagedName;
                var prefix = methodName.ToCamelCase();

                statement = string.Format("var {0}Offset = {1}.OffsetOf<{2}> (nameof ({2}.{3}));\n",
                    prefix, typeof(Marshal).FullName, structName, methodName);
                yield return ParseStatement(statement);

                statement = string.Format("var {0}Ptr = {1}.GetFunctionPointerForDelegate<{2}.{3}> ({4});\n",
                    prefix, typeof(Marshal).FullName, structName, delegateName, methodName);
                yield return ParseStatement(statement);

                statement = string.Format("{0}.WriteIntPtr(gIface, (int){1}Offset, {1}Ptr);\n",
                    typeof(Marshal).FullName, prefix);
                yield return ParseStatement(statement);
            }
        }

        IEnumerable<MethodDeclarationSyntax> GetGTypeInterfaceMethodImpls()
        {
            foreach (var f in FieldInfos.Where(x => x.IsCallback)) {
                var methodName = f.ManagedName;
                var returnType = f.CallbackInfo.MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type;

                var method = MethodDeclaration(returnType, methodName)
                    .AddModifiers(Token(StaticKeyword))
                    .WithParameterList(f.CallbackInfo.MethodInfo.UnmanagedParameterList)
                    .WithBody(Block(f.CallbackInfo.MethodInfo.VirtualMethodImplStatements));

                yield return method;
            }
        }

        MethodDeclarationSyntax GetGTypeStructGetInfoMethod()
        {
            var method = MethodDeclaration(
                ParseTypeName(typeof(TypeInfo).FullName),
                nameof(TypeClass.GetTypeInfo))
                .AddModifiers(Token(PublicKeyword), Token(OverrideKeyword))
                .AddParameterListParameters(Parameter(ParseToken("type"))
                    .WithType(ParseTypeName(typeof(Type).FullName)))
                .AddBodyStatements(
                    ParseStatement($"throw new {typeof(NotImplementedException).FullName} ();"));

            return method;
        }

        IEnumerable<BaseTypeSyntax> GetBaseTypes()
        {
            yield return SimpleBaseType(ParseTypeName(ParentType.FullName));
        }

        IEnumerable<MemberDeclarationSyntax> GetClassMemberDeclarations()
        {
            var structDeclaration = StructDeclaration("Struct")
                .WithModifiers(TokenList(Token(NewKeyword)))
                .WithMembers(List(FieldInfos.SelectMany(x => x.AllDeclarations)));
            yield return structDeclaration;

            yield return DefaultConstructor;
            // taking advantage of the fact that GObject interfaces can't inherit,
            // so parent will always be GISharp.GObject.TypeInterface for
            // interfaces.
            if (ParentType == typeof(TypeInterface)) {
                yield return GetGTypeStructCreateInterfaceInfoMethod();
                yield return GetGTypeStructInterfaceInitMethod();
                foreach (var m in GetGTypeInterfaceMethodImpls()) {
                    yield return m;
                }
            }
            else {
                yield return GetGTypeStructGetInfoMethod();
            }
        }

        ConstructorDeclarationSyntax GetDefaultConstructor()
        {
            var modifiers = TokenList().Add(Token(PublicKeyword));
            var paramerList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr).FullName,
                typeof(GISharp.Runtime.Transfer).FullName));
            var argList = ParseArgumentList("(handle, ownership)");
            var initializer = ConstructorInitializer(BaseConstructorInitializer)
                .WithArgumentList(argList);
            return ConstructorDeclaration(Identifier)
                .WithModifiers(modifiers)
                .WithParameterList(paramerList)
                .WithInitializer(initializer)
                .WithBody(Block());
        }
    }
}
