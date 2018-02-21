using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using GISharp.CodeGen.Reflection;
using GISharp.CodeGen.Syntax;
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
    public class ClassInfo : TypeDeclarationInfo
    {
        /// <summary>
        /// Indicates if this is a static class.
        /// </summary>
        /// <value><c>true</c> if this is a static class.</value>
        public bool IsStaticClass => Element.Name == gs + "static-class";

        /// <summary>
        /// Indicates if this class is derived from GObject
        /// </summary>
        public bool IsGObject => Element.Name == gi + "class";

        /// <summary>
        /// Indicates if this class is sealed
        /// </summary>
        public bool IsSealed {
            get {
                if (Element.Attribute (glib + "type-struct") == null) {
                    // if there is not a GType struct, this this is type is
                    // "final" and not meant to be inherited
                    return true;
                }
                if (!IsGObject) {
                    // for now, only GObjects can be inherited
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Indicates if this class is abstract
        /// </summary>
        public bool IsAbstract => Element.Attribute("abstract").AsBool();

        /// <summary>
        /// Gets the parent type for a GType struct
        /// </summary>
        public Type GTypeStructParent {
            get {
                var firstField = Element.Elements(gi + "field").First();
                var parentType = GirType.ResolveType (firstField.Attribute (gs + "managed-type").Value, Element.Document);
                return parentType;
            }
        }

        public bool HasDefaultConstructor {
            get {
                return Element.Attribute (gs + "default-constructor").AsBool (!IsStaticClass);
            }
        }

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
        /// Initializes a new instance of the <see cref="ClassInfo"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="declaringMember">Declaring member.</param>
        /// <exception cref="ArgumentException">If the element is not an element that declares a class.</exception>
        public ClassInfo (XElement element, MemberInfo declaringMember)
            : base (element, declaringMember)
        {
            if (element.Name != gi + "class" && element.Name != gi + "record" && element.Name != gs + "static-class") {
                throw new ArgumentException ("Requires <gi:class>, <gi:record> or <gs:static-class> element.", nameof(element));
            }
            if (element.Name == gi + "record" && element.Attribute (gs + "opaque") == null) {
                throw new ArgumentException("<gi:record> element must be opaque.", nameof(element));
            }
            if (element.Name == gi + "record" && element.Attribute(glib + "is-gtype-struct-for") != null) {
                throw new ArgumentException("<gi:record> element cannot be GType struct.", nameof(element));
            }
            _ClassMembers = new Lazy<SyntaxList<MemberDeclarationSyntax>>(() => List(GetClassMemberDeclarations()));
            _BaseList = new Lazy<BaseListSyntax>(() => BaseList(SeparatedList(GetBaseTypes())));
            _ClassDeclaration = new Lazy<ClassDeclarationSyntax>(GetClassDeclaration);
            _DefaultConstructor = new Lazy<ConstructorDeclarationSyntax>(GetDefaultConstructor);
        }

        protected override IEnumerable<SyntaxToken> GetModifiers ()
        {
            // get the access modifier
            foreach (var baseModifier in base.GetModifiers ()) {
                yield return baseModifier;
            }

            // deal with instantiability and inheritance
            if (IsStaticClass) {
                yield return Token (SyntaxKind.StaticKeyword);
            } else if (IsAbstract) {
                yield return Token (SyntaxKind.AbstractKeyword);
            } else if (IsSealed) {
                yield return Token (SyntaxKind.SealedKeyword);
            }

            // everything is partial so some parts can be implemented manually if needed
            yield return Token (SyntaxKind.PartialKeyword);
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
                Console.WriteLine("Skipping {0} ({1}) due to error: {2}",
                    QualifiedName, Element.Name.LocalName, ex.Message);
                yield break;
            }

            yield return declaration;
        }

        MethodDeclarationSyntax GetGTypeStructCreateInterfaceInfoMethod ()
        {
            var method = MethodDeclaration (
                ParseTypeName (typeof(GISharp.GObject.InterfaceInfo).FullName),
                nameof (GISharp.GObject.TypeInterface.CreateInterfaceInfo))
                .AddModifiers (
                    Token (SyntaxKind.PublicKeyword),
                    Token (SyntaxKind.OverrideKeyword))
                .AddParameterListParameters (
                             Parameter (ParseToken ("type"))
                    .WithType (ParseTypeName (typeof(Type).FullName)))
                .AddBodyStatements (
                    ParseStatement (@"var ret = new GISharp.GObject.InterfaceInfo {
                InterfaceInit = InterfaceInit,
            };"),
                    ParseStatement ("return ret;"));

            return method;
        }

        MethodDeclarationSyntax GetGTypeStructInterfaceInitMethod()
        {
            var method = MethodDeclaration(
                PredefinedType(Token (SyntaxKind.VoidKeyword)),
                "InterfaceInit")
                .AddModifiers(Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters (
                    Parameter (ParseToken ("gIface"))
                        .WithType (ParseTypeName (typeof(IntPtr).FullName)),
                    Parameter (ParseToken ("userData"))
                        .WithType (ParseTypeName (typeof(IntPtr).FullName)))
                .WithBody (Block (GetGTypeStructInterfaceInitStatements ()));

            return method;
        }

        IEnumerable<StatementSyntax> GetGTypeStructInterfaceInitStatements ()
        {
            const string structName = "Struct";
            string statement;
            foreach (var f in FieldInfos.Where(x => x.IsCallback)) {
                var methodName = f.ManagedName;
                var delegateName = "Unmanaged" + f.CallbackInfo.ManagedName;
                var prefix = methodName.ToCamelCase ();

                statement = string.Format ("var {0}Offset = {1}.OffsetOf<{2}> (nameof ({2}.{3}));\n",
                    prefix, typeof(Marshal).FullName, structName, methodName);
                yield return ParseStatement (statement);

                statement = string.Format ("var {0}Ptr = {1}.GetFunctionPointerForDelegate<{2}.{3}> ({4});\n",
                    prefix, typeof(Marshal).FullName, structName, delegateName, methodName);
                yield return ParseStatement (statement);

                statement = string.Format ("{0}.WriteIntPtr (gIface, (int){1}Offset, {1}Ptr);\n",
                    typeof(Marshal).FullName, prefix);
                yield return ParseStatement (statement);
            }
        }

        IEnumerable<MethodDeclarationSyntax> GetGTypeInterfaceMethodImpls ()
        {
            foreach (var f in FieldInfos.Where(x => x.IsCallback)) {
                var methodName = f.ManagedName;
                var returnType = f.CallbackInfo.MethodInfo.UnmanagedReturnParameterInfo.TypeInfo.Type;

                var method = MethodDeclaration (returnType, methodName)
                    .AddModifiers (Token (SyntaxKind.StaticKeyword))
                    .WithParameterList (f.CallbackInfo.MethodInfo.UnmanagedParameterList)
                    .WithBody (Block (f.CallbackInfo.MethodInfo.VirtualMethodImplStatements));

                yield return method;
            }
        }

        MethodDeclarationSyntax GetGTypeStructGetInfoMethod ()
        {
            var method = MethodDeclaration (
                ParseTypeName (typeof(GISharp.GObject.TypeInfo).FullName),
                nameof (GISharp.GObject.TypeClass.GetTypeInfo))
                .AddModifiers (
                    Token (SyntaxKind.PublicKeyword),
                    Token (SyntaxKind.OverrideKeyword))
                .AddParameterListParameters (
                    Parameter (ParseToken ("type"))
                    .WithType (ParseTypeName (typeof(Type).FullName)))
                .AddBodyStatements (
                    ParseStatement ($"throw new {typeof(NotImplementedException).FullName} ();"));

            return method;
        }

        IEnumerable<BaseTypeSyntax> GetBaseTypes ()
        {
            var opaqueTypeName = Element.Attribute (gs + "opaque")?.Value;
            if (opaqueTypeName != null) {
                switch (opaqueTypeName) {
                case "owned":
                    opaqueTypeName = typeof(GISharp.Runtime.Opaque).FullName;
                    break;
                case "static":
                    opaqueTypeName = typeof(GISharp.Runtime.Opaque).FullName;
                    break;
                case "gtype-struct":
                    opaqueTypeName = GTypeStructParent.FullName;
                    break;
                default:
                    var message = $"Unknown opaque type '{opaqueTypeName}'";
                    throw new Exception (message);
                }
                yield return SimpleBaseType (ParseTypeName (opaqueTypeName));
            }
            if (IsGObject) {
                var parent = Element.Attribute ("parent")?.Value;
                if (parent == null) {
                    yield return SimpleBaseType (
                        ParseTypeName (typeof(GISharp.Runtime.Opaque).FullName));
                } else {
                    var parentType = GirType.ResolveType (parent, Element.Document);
                    yield return SimpleBaseType (ParseTypeName (parentType.FullName));
                }
                foreach (var ifaceElement in Element.Elements(gi + "implements")) {
                    var type = GirType.ResolveType("I" + ifaceElement.Attribute("name").Value,
                        Element.Document);
                    yield return SimpleBaseType(ParseTypeName(type.FullName));
                }
            }
            if (MethodInfos.Any (x => x.IsEquals)) {
                var typeName = string.Concat (typeof(IEquatable<>).FullName.TakeWhile (x => x != '`'));
                typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                yield return SimpleBaseType (ParseTypeName (typeName));
            }
            if (MethodInfos.Any (x => x.IsCompare)) {
                var typeName = string.Concat (typeof(IComparable<>).FullName.TakeWhile (x => x != '`'));
                typeName = string.Format ("{0}<{1}>", typeName, ManagedName);
                yield return SimpleBaseType (ParseTypeName (typeName));
            }
        }

        IEnumerable<MemberDeclarationSyntax> GetClassMemberDeclarations ()
        {
            foreach (var d in GTypeMembers) {
                yield return d;
            }
            foreach (var d in NestedTypeInfos.SelectMany(x => x.AllDeclarations)) {
                yield return d;
            }
            foreach (var d in ConstantInfos.SelectMany(x => x.AllDeclarations)) {
                yield return d;
            }
            foreach (var d in FieldInfos.SelectMany(x => x.AllDeclarations)) {
                yield return d;
            }
            foreach (var d in PropertyInfos.SelectMany(x => x.ClassDeclarations)) {
                yield return d;
            }
            if (HasDefaultConstructor) {
                yield return DefaultConstructor;
            }
            foreach (var d in MethodInfos.SelectMany (x => x.AllDeclarations)) {
                yield return d;
            }

            // create explicit implementation of GInterfaces by calling the
            // static methods associated with the interface
            foreach (var ifaceElement in Element.Elements(gi + "implements")) {
                var type = GirType.ResolveType("I" + ifaceElement.Attribute("name").Value,
                    Element.Document);
                var staticTypeName = $"{type.Namespace}.{type.Name.Substring(1)}";
                foreach (var method in type.GetMethods()) {
                    var returnType = method.ReturnType.ToSyntax();
                    var parameterList = method.GetParameters().ToSyntax(true);
                    var arguments = ArgumentList()
                        .WithArguments(SeparatedList(method.GetParameters()
                            .Select(x => Argument(ParseExpression(x.Name)))
                            .Prepend(Argument(ThisExpression()))));
                    var extensionMethod = ParseExpression($"{staticTypeName}.{method.Name}");
                    var invokeExpression = InvocationExpression(extensionMethod, arguments);
                    var invokeStatement = (method.ReturnType == typeof(void)) ?
                        (StatementSyntax)ExpressionStatement(invokeExpression) :
                        (StatementSyntax)ReturnStatement(invokeExpression);

                    yield return MethodDeclaration(returnType, method.Name)
                        .AddModifiers(Token(PublicKeyword))
                        .WithParameterList(parameterList)
                        .WithBody(Block(invokeStatement))
                        .WithLeadingTrivia(ParseLeadingTrivia("/// <inheritdoc />\n"));
                }
            }
        }

        ConstructorDeclarationSyntax GetDefaultConstructor()
        {
            var modifiers = TokenList ();
            if (IsAbstract) {
                modifiers = modifiers.Add (Token (SyntaxKind.ProtectedKeyword));
            } else {
                modifiers = modifiers.Add (Token (SyntaxKind.PublicKeyword));
            }
            var paramerList = ParseParameterList(string.Format("({0} handle, {1} ownership)",
                typeof(IntPtr).FullName, typeof(GISharp.Runtime.Transfer).FullName));
            var argList = ParseArgumentList("(handle, ownership)");
            var initializer = ConstructorInitializer (SyntaxKind.BaseConstructorInitializer)
                .WithArgumentList (argList);
            var body = Block();
            var copyMethod = this.MethodInfos.SingleOrDefault(x => x.IsCopy);
            if (copyMethod != null) {
                var copyStatement = ParseStatement(string.Format(@"if (ownership != {0}.{1}) {{
                        this.handle = {2}(handle);
                    }}",
                    typeof(GISharp.Runtime.Transfer).FullName,
                    nameof(GISharp.Runtime.Transfer.None),
                    copyMethod.PinvokeIdentifier));
                body = body.AddStatements(copyStatement);
            }
            var constructor = ConstructorDeclaration(Identifier)
                .WithModifiers (modifiers)
                .WithParameterList (paramerList)
                .WithInitializer(initializer)
                .WithBody(body);
            return constructor;
        }
    }
}
