using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

using GISharp.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using Mono.Options;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen
{
    class MainClass
    {
        internal const string parentNamespace = "GISharp";

        static void PrintHelpAndExit (OptionSet options, int exitCode = 0)
        {
            var writer = exitCode == 0 ? Console.Out : Console.Error;
            writer.WriteLine ("Usage: mono GICodeGen.exe [-r <repository-name> [-g <gir-directory>] [-f <fixup-file>] [-o <output-file>] | -h | -v]");
            writer.WriteLine ();
            options.WriteOptionDescriptions (writer);
            Environment.Exit (exitCode);
        }

        static void PrintVersionAndExit ()
        {
            var assembly = Assembly.GetExecutingAssembly ();
            var assemblyName = assembly.GetName ();
            Console.WriteLine ("{0} v{1}", assemblyName.Name, assemblyName.Version);
            Environment.Exit (0);
        }

        public static void Main (string[] args)
        {
            string repositoryName = null;
            string girDirectory = null;
            string fixupFile = null;
            string outputFile = null;

            OptionSet options = null;
            options = new OptionSet () { {
                    "h|help",
                    "Print this message.",
                    v => PrintHelpAndExit (options)
                }, {
                    "v|version",
                    "Print the program version infomation.",
                    v => PrintVersionAndExit ()
                }, {
                    "r=|repository=",
                    "The repository to generate. Essentially this is the name of the .gir file without the .gir extension.",
                    v => repositoryName = v
                }, {
                    "g=|gir-dir=",
                    "The directory where the .gir file is located. By default /usr/share/gir-1.0/ will be used.",
                    v => girDirectory = v
                }, {
                    "f=|fixup=",
                    "The name of the .girfixup file. By default '<namespace>.girfixup' will be used.",
                    v => fixupFile = v
                }, {
                    "o=|output=",
                    "The name of the output file. By default './<namespace>/Generated.cs' will be used.",
                    v => outputFile = v
                },
            };
            var extraArgs = options.Parse (args);
            if (repositoryName == null || extraArgs.Any ()) {
                Console.Error.WriteLine ("Bad arguments.");
                Console.Error.WriteLine ();
                PrintHelpAndExit (options, 1);
            }

            // Analysis disable ConstantNullCoalescingCondition
            var girFile = Path.Combine (girDirectory ?? "/usr/share/gir-1.0/", repositoryName + ".gir");
            fixupFile = fixupFile ?? repositoryName + ".girfixup";
            outputFile = outputFile ?? Path.Combine (repositoryName, "Generated");
            // Analysis restore ConstantNullCoalescingCondition

            Console.WriteLine ("Generating code for '{0}'.", Path.GetFullPath (girFile));
            Console.WriteLine ("Using fixup file '{0}'.", Path.GetFullPath (fixupFile));
            Console.WriteLine ("Creating output file '{0}'.", Path.GetFullPath (outputFile));

            var xmlDoc = XDocument.Load (girFile);
            xmlDoc.ApplyMoveFile (fixupFile);
            xmlDoc.ApplyBuiltinFixup ();

            var codeCompileUnit = xmlDoc.CreateFromGir ();
            using (var outFileStream = File.Open (outputFile, FileMode.Create))
            using (var writer = new StreamWriter (outFileStream)) {
                var workspace = MSBuildWorkspace.Create ();
                Formatter.Format (codeCompileUnit, workspace).GetText ().Write (writer);
            }
        }
    }

    static class ExtensionMethods
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        public static CompilationUnitSyntax AddNamespace (this CompilationUnitSyntax syntax, string @namespace, IEnumerable<Type> types)
        {
            if (@namespace == null) {
                throw new ArgumentNullException (nameof(@namespace));
            }
            if (types == null) {
                throw new ArgumentNullException (nameof(types));
            }

            var namespaceSyntax = NamespaceDeclaration (
                  QualifiedName (
                      ParseName (MainClass.parentNamespace),
                      IdentifierName (@namespace)))
                .AddTypes (types);

            return syntax.AddMembers (namespaceSyntax);
        }

        public static NamespaceDeclarationSyntax AddTypes (this NamespaceDeclarationSyntax syntax, IEnumerable<Type> types)
        {
            if (types == null) {
                throw new ArgumentNullException (nameof(types));
            }

            var @namespace = syntax.Name.ToString ();

            foreach (var type in types) {
                if (type.Namespace != @namespace) {
                    var message = string.Format ("Type '{0}' does not have namespace {1}.", type.FullName, @namespace);
                    throw new ArgumentException (message, nameof(types));
                }
                if (type.IsEnum) {
                    syntax = syntax.AddEnum (type);
                } else if (typeof(Delegate).IsAssignableFrom (type)) {
                    syntax = syntax.AddDelegate (type);
                } else if (type.IsClass) {
                    syntax = syntax.AddClass (type);
                } else if (type.IsInterface) {
                    syntax = syntax.AddInterface (type);
                } else if (type.IsValueType) {
                    syntax = syntax.AddStruct (type);
                }
            }

            return syntax;
        }

        public static NamespaceDeclarationSyntax AddEnum (this NamespaceDeclarationSyntax syntax, Type type)
        {
            if (!type.IsEnum) {
                throw new ArgumentException ("Requires an enum type.", nameof(type));
            }

            var @enum = EnumDeclaration (type.Name)
                .WithModifiers (type.GetModifiers ())
                .WithAttributeLists (type.GetAttributeLists ())
                .WithMembers (type.GetEnumMembers ())
                .WithLeadingTrivia (type.GetDocumentationComments ());

            return syntax.AddMembers (@enum);
        }

        public static NamespaceDeclarationSyntax AddDelegate (this NamespaceDeclarationSyntax syntax, Type type)
        {
            if (!typeof(Delegate).IsAssignableFrom (type)) {
                throw new ArgumentException ("Requires a delegate type.", nameof(type));
            }
            var unmanagedMethod = type.GetMethod ("InvokeNative");
            if (unmanagedMethod == null) {
                throw new ArgumentException ("Missing InvokeNative method for delegate.", nameof(type));
            }
            var managedMethod = type.GetMethod ("Invoke");
            if (managedMethod == null) {
                throw new ArgumentException ("Missing Invoke method for delegate.", nameof(type));
            }

            var returnType = ParseTypeName (unmanagedMethod.ReturnType.GetFixedUpName ());
            var unmanagedDelegate = DelegateDeclaration (returnType, type.Name + "Native")
                .WithModifiers (unmanagedMethod.GetModifiers ())
                .WithAttributeLists (unmanagedMethod.GetAttributeLists ())
                .WithParameterList (unmanagedMethod.GetParameterList ())
                .WithLeadingTrivia (unmanagedMethod.GetDocumentationComments ());
            syntax = syntax.AddMembers (unmanagedDelegate);

            returnType = ParseTypeName (managedMethod.ReturnType.GetFixedUpName ());
            var managedDelegate = DelegateDeclaration (returnType, type.Name)
                .WithModifiers (managedMethod.GetModifiers ())
                .WithAttributeLists (managedMethod.GetAttributeLists ())
                .WithParameterList (managedMethod.GetParameterList ())
                .WithLeadingTrivia (managedMethod.GetDocumentationComments ());
            syntax = syntax.AddMembers (managedDelegate);

            return syntax;
        }

        public static NamespaceDeclarationSyntax AddClass (this NamespaceDeclarationSyntax syntax, Type type)
        {
            if (!type.IsClass) {
                throw new ArgumentException ("Requires a class type.", nameof(type));
            }

            var @class = ClassDeclaration (type.Name)
                .WithModifiers (type.GetModifiers ())
                .WithAttributeLists (type.GetAttributeLists ())
                .AddBaseTypes (type)
                .AddFields (type.GetFields ())
                .AddProperties (type.GetProperties ())
                .AddDefaultConstructor (type)
                .AddConstructors (type.GetConstructors ())
                .AddMethods (type.GetMethods ())
                .WithLeadingTrivia (type.GetDocumentationComments ());
            return syntax.AddMembers (@class);
        }

        public static NamespaceDeclarationSyntax AddInterface (this NamespaceDeclarationSyntax syntax, Type type)
        {
            if (!type.IsInterface) {
                throw new ArgumentException ("Requires a interface type.", nameof(type));
            }

            var @interface = InterfaceDeclaration (type.Name);

            return syntax.AddMembers (@interface);
        }

        public static NamespaceDeclarationSyntax AddStruct (this NamespaceDeclarationSyntax syntax, Type type)
        {
            if (!type.IsValueType || type.IsEnum || type.IsPrimitive) {
                throw new ArgumentException ("Requires a struct type.", nameof(type));
            }

            var @struct = StructDeclaration (type.Name)
                .WithModifiers (type.GetModifiers ())
                .WithAttributeLists (type.GetAttributeLists ())
                .AddFields (type.GetFields ())
                .AddProperties (type.GetProperties ())
                .AddMethods (type.GetMethods ())
                .WithLeadingTrivia (type.GetDocumentationComments ());

            return syntax.AddMembers (@struct);
        }

        public static T AddProperties<T> (this T syntax, PropertyInfo[] properties) where T : TypeDeclarationSyntax
        {
            foreach (var info in properties) {
                var accessorList = SyntaxFactory.AccessorList ();
                SyntaxTokenList? modifers = null;
                if (info.CanRead) {
                    // the getter modifiers are used to decorate the property rather than the accessor, so save them for later.
                    modifers = info.GetMethod.GetModifiers ();
                    var getter = SyntaxFactory.AccessorDeclaration (SyntaxKind.GetAccessorDeclaration)
                        .WithBody (info.GetMethod.GetBody ());
                    accessorList = accessorList.AddAccessors (getter);
                }
                if (info.CanWrite) {
                    var setterModifiers = info.SetMethod.GetModifiers ();
                    if (!modifers.HasValue) {
                        // we shouldn't have set-only classes, but just in case...
                        modifers = setterModifiers;
                    }
                    var setter = SyntaxFactory.AccessorDeclaration (SyntaxKind.SetAccessorDeclaration)
                        .WithBody (info.SetMethod.GetBody ());

                    // we only need to add modifers to the setter if they are different from the getter
                    if (setterModifiers.ToString () != modifers.ToString ()) {
                        // if this is a static property, we can't have the static modifer on the setter as well
                        var staticIndex = setterModifiers.IndexOf (SyntaxKind.StaticKeyword);
                        if (staticIndex >= 0) {
                            setterModifiers = setterModifiers.RemoveAt (staticIndex);
                        }
                        setter = setter.WithModifiers (setterModifiers);
                    }
                    accessorList = accessorList.AddAccessors (setter);
                }

                var property = SyntaxFactory.PropertyDeclaration (SyntaxFactory.ParseTypeName (info.PropertyType.GetFixedUpName ()), SyntaxFactory.Identifier (info.Name))
                    .WithModifiers (modifers.Value)
                    .WithAttributeLists (info.GetAttributeLists ())
                    .WithLeadingTrivia (info.GetDocumentationComments ())
                    .WithAccessorList (accessorList);
                syntax = syntax.AddMembers (property);
            }
            return syntax;
        }

        public static ClassDeclarationSyntax AddDefaultConstructor (this ClassDeclarationSyntax syntax, Type type)
        {
            if (!type.SafeGetInterfaces ().Contains (typeof(IWrappedNative))) {
                return syntax;
            }

            var defaultConstructor = SyntaxFactory.ConstructorDeclaration (SyntaxFactory.Identifier(type.Name))
                .WithModifiers (SyntaxFactory.TokenList (SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList (SyntaxFactory.ParameterList()
                    .AddParameters (SyntaxFactory.Parameter (SyntaxFactory.Identifier("handle"))
                        .WithType(SyntaxFactory.ParseTypeName(typeof(IntPtr).FullName))))
                .WithInitializer (SyntaxFactory.ConstructorInitializer (SyntaxKind.BaseConstructorInitializer)
                    .AddArgumentListArguments(SyntaxFactory.Argument (SyntaxFactory.ParseExpression("handle"))))
                .WithBody (SyntaxFactory.Block ());

            return syntax.AddMembers (defaultConstructor);
        }

        public static string GetFixedUpName (this Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof(type));
            }

            if (type == typeof(void)) {
                // C# can't use System.Void
                return "void";
            }

            if (type.IsByRef) {
                return type.GetElementType ().FullName;
            }

            if (type.IsGenericType) {
                var parameters = string.Join (", ", type.GenericTypeArguments.Select (a => a.FullName));
                return string.Format ("{0}<{1}>", type.FullName.Substring(0, type.FullName.IndexOf ('`')), parameters);
            }

            return type.FullName;
        }

        public static ParameterListSyntax GetParameterList (this MethodBase info)
        {
            var list = SyntaxFactory.ParameterList ();

            foreach (var p in info.GetParameters ()) {
                var parameter = SyntaxFactory.Parameter (SyntaxFactory.Identifier (p.Name))
                    .WithType (SyntaxFactory.ParseTypeName (p.ParameterType.GetFixedUpName ()))
                    .WithModifiers (p.GetModifiers ())
                    .WithAttributeLists (p.GetAttributeLists ())
                    .WithLeadingTrivia (
                        // put each parameter on a new line for better readability since we are using full type names
                        SyntaxFactory.EndOfLine("\n"),
                        SyntaxFactory.Whitespace ("\t"));
                if (p.HasDefaultValue) {
                    parameter = parameter.WithDefault (SyntaxFactory.EqualsValueClause (SyntaxFactory.ParseExpression (p.DefaultValue.ToString ())));
                }
                list = list.AddParameters (parameter);
            }

            return list;
        }

        public static SyntaxTokenList GetModifiers (this ParameterInfo info)
        {
            var list = TokenList ();

            if (info.ParameterType.IsByRef) {
                if (info.IsOut) {
                    list = list.Add (Token (SyntaxKind.OutKeyword));
                } else {
                    list = list.Add (Token (SyntaxKind.RefKeyword));
                }
            }

            return list;
        }

        public static SyntaxTokenList GetModifiers (this MemberInfo info) {
            var list = TokenList ();

            var type = info as Type;
            if (type != null) {
                if (type.IsPublic) {
                    list = list.Add (Token (SyntaxKind.PublicKeyword));
                }
                if (type.IsAbstract && type.IsSealed) {
                    list = list.Add (Token (SyntaxKind.StaticKeyword));
                }
                if (!type.IsEnum && !typeof(Delegate).IsAssignableFrom (type)) {
                    // partial *must* be the last token in the list
                    list = list.Add (Token (SyntaxKind.PartialKeyword));
                }
            }
            var field = info as FieldInfo;
            if (field != null) {
                if (field.IsPublic) {
                    list = list.Add (Token (SyntaxKind.PublicKeyword));
                }
                if (field.IsFamily) {
                    list = list.Add (Token (SyntaxKind.ProtectedKeyword));
                }
                if (field.IsAssembly) {
                    list = list.Add (Token (SyntaxKind.InternalKeyword));
                }
                if (field.IsLiteral) {
                    // const *must* be the last token in the list
                    list = list.Add (Token (SyntaxKind.ConstKeyword));
                }
            }
            var method = info as MethodBase;
            if (method != null) {
                if (method.IsPublic) {
                    list = list.Add (Token (SyntaxKind.PublicKeyword));
                }
                if (method.IsFamily) {
                    list = list.Add (Token (SyntaxKind.ProtectedKeyword));
                }
                if (method.IsAssembly) {
                    list = list.Add (Token (SyntaxKind.InternalKeyword));
                }
                if (method.IsStatic) {
                    list = list.Add (Token (SyntaxKind.StaticKeyword));
                }
                if (method.Attributes.HasFlag (MethodAttributes.PinvokeImpl)) {
                    list = list.Add (Token (SyntaxKind.ExternKeyword));
                }
                if (method.IsHideBySig && method.Attributes.HasFlag (MethodAttributes.ReuseSlot)) {
                    list = list.Add (Token (SyntaxKind.OverrideKeyword));
                }
            }

            return list;
        }

        public static SeparatedSyntaxList<EnumMemberDeclarationSyntax> GetEnumMembers (this Type type)
        {
            var list = SeparatedList<EnumMemberDeclarationSyntax> ();

            foreach (var field in type.GetFields ()) {
                var value = LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal ((int)field.GetValue (null)));
                // TODO: would be nice to use hex here for bitfields
                var member = EnumMemberDeclaration (field.Name)
                    .WithEqualsValue(EqualsValueClause (value))
                    .WithAttributeLists (field.GetAttributeLists ())
                    .WithLeadingTrivia (field.GetDocumentationComments ());
                list = list.Add (member);
            }

            return list;
        }

        public static SyntaxList<AttributeListSyntax> GetAttributeLists (this ICustomAttributeProvider info, string target = null)
        {
            var listOfLists = SyntaxFactory.List<AttributeListSyntax> ();

            foreach (CustomAttributeData attr in info.GetCustomAttributes (false)) {;
                var name = attr.AttributeType.FullName;
                if (name.EndsWith ("Attribute", StringComparison.Ordinal)) {
                    name = name.Remove (name.Length - "Attribute".Length);
                }
                var argList = SyntaxFactory.AttributeArgumentList ();
                foreach (var arg in attr.ConstructorArguments) {
                    var argSyntax = SyntaxFactory.AttributeArgument (
                        arg.Value.ToExpression ());
                    argList = argList.AddArguments (argSyntax);
                }
                foreach (var arg in attr.NamedArguments) {
                    var argSyntax = SyntaxFactory.AttributeArgument (
                        SyntaxFactory.NameEquals (arg.MemberName),
                        null,
                        arg.TypedValue.Value.ToExpression ());
                    argList = argList.AddArguments (argSyntax);
                }

                var attrList = SyntaxFactory.AttributeList ()
                    .WithAttributes (SyntaxFactory.SeparatedList<AttributeSyntax> ()
                        .Add (SyntaxFactory.Attribute (SyntaxFactory.ParseName (name))
                            .WithArgumentList(argList)));
                if (target != null) {
                    attrList = attrList.WithTarget (SyntaxFactory.AttributeTargetSpecifier (SyntaxFactory.Identifier (target)));
                }

                listOfLists = listOfLists.Add (attrList);
            }

            var methodInfo = info as MethodInfo;
            if (methodInfo != null) {
                listOfLists = listOfLists.AddRange (methodInfo.ReturnTypeCustomAttributes.GetAttributeLists ("return"));
            }

            // for parameters, combine attribute lists into a single attribute list
            var parameterInfo = info as ParameterInfo;
            if (parameterInfo != null && listOfLists.Any ()) {
                listOfLists = SyntaxFactory.List<AttributeListSyntax> ()
                    .Add (SyntaxFactory.AttributeList ()
                        .AddAttributes (listOfLists.SelectMany (l => l.Attributes).ToArray ()));
            }

            return listOfLists;
        }

        /// <summary>
        /// Converts an object to an approprate ExpressionSyntax
        /// </summary>
        /// <returns>The expression.</returns>
        /// <param name="obj">Object.</param>
        public static ExpressionSyntax ToExpression (this object obj)
        {
            var @bool = obj as bool?;
            if (@bool.HasValue) {
                if (@bool.Value) {
                    return LiteralExpression (
                        SyntaxKind.TrueLiteralExpression,
                        Token (SyntaxKind.TrueKeyword));
                }
                return LiteralExpression (
                    SyntaxKind.FalseLiteralExpression,
                    Token (SyntaxKind.FalseKeyword));
            }
            var @byte = obj as byte?;
            if (@byte.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@byte.Value));
            }
            var @sbyte = obj as sbyte?;
            if (@sbyte.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@sbyte.Value));
            }
            var @short = obj as short?;
            if (@short.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@short.Value));
            }
            var @ushort = obj as ushort?;
            if (@ushort.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@ushort.Value));
            }
            var @int = obj as int?;
            if (@int.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@int.Value));
            }
            var @uint = obj as uint?;
            if (@uint.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@uint.Value));
            }
            var @long = obj as long?;
            if (@long.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@long.Value));
            }
            var @ulong = obj as ulong?;
            if (@ulong.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@ulong.Value));
            }
            var str = obj as string;
            if (str != null) {
                return LiteralExpression (
                    SyntaxKind.StringLiteralExpression,
                    Literal (str));
            }
            var @enum = obj as Enum;
            if (@enum != null) {
                return MemberAccessExpression (
                    SyntaxKind.SimpleMemberAccessExpression,
                    ParseExpression (@enum.GetType ().FullName),
                    IdentifierName (@enum.ToString ()));
            }
            var message = string.Format ("Unexpected type '{0}", obj.GetType ().FullName);
            throw new ArgumentException (message, nameof(obj));
        }

        public static SyntaxTriviaList GetDocumentationComments (this MemberInfo info)
        {
            var girInfo = info as IGirInfo;
            if (girInfo != null) {
                return ParseLeadingTrivia (girInfo.DocumentationComments);
            }
            return TriviaList ();
        }

        public static ClassDeclarationSyntax AddBaseTypes (this ClassDeclarationSyntax syntax, Type type)
        {
            var typeName = SyntaxFactory.ParseTypeName (type.BaseType.GetFixedUpName ());

            if (type != typeof(object)) {
                // Add the base type to the list
                syntax = syntax.AddBaseListTypes (SyntaxFactory.SimpleBaseType (typeName));
            }

            // Add any interfaces to the list
            var interfaces = type.SafeGetInterfaces ().Except (type.BaseType.SafeGetInterfaces ());
            foreach (var ifaceType in interfaces) {
                typeName = SyntaxFactory.ParseTypeName (ifaceType.GetFixedUpName ());
                syntax = syntax.AddBaseListTypes (SyntaxFactory.SimpleBaseType (typeName));
            }

            // put each item on a new line for readability since we are using full type names
            var baseListTypes = syntax.BaseList.Types;
            for (int i = 0; i < baseListTypes.SeparatorCount; i++) {
                baseListTypes = baseListTypes.ReplaceSeparator (
                    baseListTypes.GetSeparator (i),
                    Token (SyntaxKind.CommaToken)
                        .WithTrailingTrivia (EndOfLine ("\n"), Whitespace("\t")));
            }
            syntax = syntax.WithBaseList (syntax.BaseList.WithTypes (baseListTypes));

            return syntax;
        }

        public static T AddConstructors<T> (this T syntax, ConstructorInfo[] constructors) where T : TypeDeclarationSyntax
        {
            foreach (var ctor in constructors) {
                var identifier = SyntaxFactory.Identifier (ctor.Name);
                var member = SyntaxFactory.ConstructorDeclaration (identifier)
                    .WithModifiers (ctor.GetModifiers ())
                    .WithAttributeLists (ctor.GetAttributeLists ())
                    .WithParameterList (ctor.GetParameterList ())
                    .WithLeadingTrivia (ctor.GetDocumentationComments ())
                    .WithBody (ctor.GetBody ());

                var declaringType = ctor.DeclaringType;

                if (ctor.DeclaringType.SafeGetInterfaces ().Contains (typeof(IWrappedNative))) {
                    member = member.WithInitializer (SyntaxFactory.ConstructorInitializer (SyntaxKind.BaseConstructorInitializer)
                        .WithArgumentList (SyntaxFactory.ArgumentList ()
                            .AddArguments (SyntaxFactory.Argument (SyntaxFactory.ParseExpression ("System.IntPtr.Zero")))));
                }

                syntax = syntax.AddMembers (member);
            }

            return syntax;
        }

        public static T AddMethods<T> (this T syntax, MethodInfo[] methods) where T : TypeDeclarationSyntax
        {
            foreach (var method in methods) {
                var returnType = SyntaxFactory.ParseTypeName (method.ReturnType.GetFixedUpName ());
                var identifier = SyntaxFactory.Identifier (method.Name);
                var member = SyntaxFactory.MethodDeclaration (returnType, identifier)
                    .WithModifiers (method.GetModifiers ())
                    .WithAttributeLists (method.GetAttributeLists ())
                    .WithParameterList (method.GetParameterList ())
                    .WithLeadingTrivia (method.GetDocumentationComments ());
                if (method.Attributes.HasFlag (MethodAttributes.PinvokeImpl)) {
                    member = member.WithSemicolonToken (SyntaxFactory.Token (SyntaxKind.SemicolonToken));
                } else {
                    member = member.WithBody (method.GetBody ());
                }
                syntax = syntax.AddMembers (member);
            }

            var type = methods.FirstOrDefault ()?.DeclaringType;
            if (type != null) {
                var typeName = type.GetFixedUpName ();
                foreach (var iface in type.SafeGetInterfaces ()) {
                    if (iface.FullName == typeof(IEquatable<>).MakeGenericType (type).FullName) {
                        syntax = syntax.AddMembers (
                            CreateOverrideEqualsMethod (typeName),
                            // TODO: find hash method or do something else.
                            CreateOverrideGetHashCodeMethod ("base.GetHashCode ()"),
                            CreateEqualityOperator (typeName),
                            CreateInequalityOperator (typeName));
                    }
                    if (iface.FullName == typeof(IComparable<>).MakeGenericType (type).FullName) {
                        syntax = syntax.AddMembers (
                            CreateCompareToOperator ("<", typeName),
                            CreateCompareToOperator ("<=", typeName),
                            CreateCompareToOperator (">=", typeName),
                            CreateCompareToOperator (">", typeName));
                    }
                }
            }

            return syntax;
        }

        public static BlockSyntax GetBody (this MethodBase info)
        {
            var body = SyntaxFactory.Block ();

            foreach (var param in info.GetParameters ().Where (p => !p.IsOut)) {
                // this is in and inout parameters
                // TODO: add statment to marshal managed to unmanged
            }
            foreach (var param in info.GetParameters ().Where (p => p.ParameterType.IsByRef)) {
                // this is inout and out parameters
                // TODO: add statment to marshal unmanaged to manged
                if (param.IsOut) {
                    var defaultExpression = string.Format ("default({0})", param.ParameterType.GetFixedUpName ());
                    var outStatement = SyntaxFactory.ExpressionStatement (
                        SyntaxFactory.AssignmentExpression (SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.IdentifierName (param.Name), SyntaxFactory.ParseExpression (defaultExpression)));
                    body = body.AddStatements (outStatement);
                }
            }

            var methodInfo = info as MethodInfo;
            if (methodInfo != null) {
                if (methodInfo.ReturnType != typeof(void)) {
                    var defaultExpression = string.Format ("default({0})", methodInfo.ReturnType.GetFixedUpName ());
                    var outStatement = SyntaxFactory.ReturnStatement ()
                    .WithExpression (SyntaxFactory.ParseExpression (defaultExpression));
                    body = body.AddStatements (outStatement);
                }
            }

            return body;
        }

        public static T AddFields<T> (this T syntax, FieldInfo[] fields) where T : TypeDeclarationSyntax
        {
            foreach (var field in fields) {

                var variable = VariableDeclarator (field.Name);

                if (field.IsStatic && field.IsLiteral) {
                    variable = variable.WithInitializer(EqualsValueClause (field.GetValue (null).ToExpression ()));
                }

                var variableDeclaration = VariableDeclaration (ParseTypeName (field.FieldType.GetFixedUpName ()))
                    .AddVariables (variable);

               var fieldSyntax = FieldDeclaration (variableDeclaration)
                    .WithModifiers (field.GetModifiers ())
                    .WithAttributeLists(field.GetAttributeLists ())
                    .WithLeadingTrivia (field.GetDocumentationComments ());
                syntax = syntax.AddMembers (fieldSyntax);
            }
            return syntax;
        }

        public static CompilationUnitSyntax CreateFromGir (this XDocument gir)
        {
            var compilationUnit = CompilationUnit ()
                .AddUsings (
                    UsingDirective (
                        ParseName ("System")),
                    UsingDirective (
                        ParseName ("System.Runtime.InteropServices")))
                .AddNamespaces (gir.Descendants (gi + "namespace"));

            return compilationUnit;
        }

        public static CompilationUnitSyntax AddNamespaces (this CompilationUnitSyntax compilationUnit, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                compilationUnit = compilationUnit.AddNamespace (element);
            }
            return compilationUnit;
        }

        public static CompilationUnitSyntax AddNamespace (this CompilationUnitSyntax compilationUnit, XElement element)
        {
            if (element.Name != gi + "namespace") {
                throw new ArgumentException ("Expecting 'namespace' element.", nameof(element));
            }

            var name = QualifiedName (
                IdentifierName (MainClass.parentNamespace),
                IdentifierName (element.Attribute (gs + "managed-name").Value));

            var @namespace = NamespaceDeclaration (name)
                .AddCallbacks (element.Elements (gi + "callback"))
                .AddConstantsClass (element.Elements (gi + "constant"))
                .AddAliases (element.Elements (gi + "alias"))
                .AddEnumerations (element.Elements (gi + "bitfield"))
                .AddEnumerations (element.Elements (gi + "enumeration"))
                .AddRecords (element.Elements (gi + "record"))
                .AddUnions (element.Elements (gi + "union"))
                .AddStaticClasses (element.Elements (gs + "static-class"));

            return compilationUnit.AddMembers (@namespace);
        }

        /// <summary>
        /// Adds the callbacks to the namespace.
        /// </summary>
        /// <returns>The new namespace object.</returns>
        /// <param name="namespace">The current namespace object.</param>
        /// <param name="elements">The 'callback' elements to add.</param>
        public static NamespaceDeclarationSyntax AddCallbacks (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                // each delegate has a version for passing to/from unmanaged code
                @namespace = @namespace.AddMembers (element.GetDelegateDeclaration (managed: false));
                // and a version for use with managed code
                @namespace = @namespace.AddMembers (element.GetDelegateDeclaration (managed: true));
            }

            return @namespace;
        }

        /// <summary>
        /// Adds a global constants class to a namespace.
        /// </summary>
        /// <returns>The the new namespace object.</returns>
        /// <param name="namespace">The current namespace object.</param>
        /// <param name="elements">The 'constant' elements to add.</param>
        public static NamespaceDeclarationSyntax AddConstantsClass (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            var constantsClass = ClassDeclaration ("Constants")
                .AddModifiers (ParseTokens ("public static partial").ToArray ())
                .AddMembers (elements.Select (e => e.GetConstantField ()).ToArray ());

           return @namespace.AddMembers (constantsClass);
        }

        /// <summary>
        /// Adds type declarations for aliases to the namespace
        /// </summary>
        /// <returns>The the new namespace object.</returns>
        /// <param name="namespace">The current namespace object.</param>
        /// <param name="elements">The 'alias' elements to add.</param>
        public static NamespaceDeclarationSyntax AddAliases (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                @namespace = @namespace.AddAlias (element);
            }
            return @namespace;
        }

        public static NamespaceDeclarationSyntax AddAlias (this NamespaceDeclarationSyntax @namespace, XElement element)
        {
            if (element.Name != gi + "alias") {
                throw new ArgumentException ("Requires an 'alias' element.", "element");
            }

            var alias = StructDeclaration (element.Attribute (gs + "managed-name").Value)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddModifiers (ParseToken ("partial"))
                .AddMembersFromElement (element)
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return @namespace.AddMembers (alias);
        }

        public static NamespaceDeclarationSyntax AddEnumerations (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                @namespace = @namespace.AddEnumeration (element);
            }
            return @namespace;
        }

        public static NamespaceDeclarationSyntax AddEnumeration (this NamespaceDeclarationSyntax @namespace, XElement element)
        {
            if (element.Name != gi + "bitfield" && element.Name != gi + "enumeration") {
                throw new ArgumentException ("Requires a 'bitfield' or 'enumeration' element.", "element");
            }

            var enumeration = EnumDeclaration (element.Attribute (gs + "managed-name").Value)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddMembers (element.GetEnumMembers ().ToArray ())
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return @namespace.AddMembers (enumeration);

            // TODO: add a static class with extenstion methods if there are "functions" element children.
        }

        public static NamespaceDeclarationSyntax AddRecords (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                @namespace = @namespace.AddRecord (element);
            }
            return @namespace;
        }

        public static NamespaceDeclarationSyntax AddRecord (this NamespaceDeclarationSyntax @namespace, XElement element)
        {
            if (element.Name != gi + "record") {
                throw new ArgumentException ("Requires a 'record' element.", "element");
            }

            var name = element.Attribute (gs + "managed-name").Value;

            if (element.Attribute (gs + "opaque") == null) {
                var @struct = StructDeclaration (name)
                    .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                    .AddModifiers (ParseToken ("partial"))
                    .AddMembersFromElement (element)
                    .AddAttributeLists (element.GetAttributes ().ToArray ())
                    .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

                return @namespace.AddMembers (@struct);
            }

            var @class = ClassDeclaration (name)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddModifiers (ParseToken ("partial"))
                .AddBaseTypeForRecord (element)
                .AddMembersFromElement (element)
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return @namespace.AddMembers (@class);
        }

        public static NamespaceDeclarationSyntax AddUnions (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                @namespace = @namespace.AddUnion (element);
            }
            return @namespace;
        }

        public static NamespaceDeclarationSyntax AddUnion (this NamespaceDeclarationSyntax @namespace, XElement element)
        {
            if (element.Name != gi + "union") {
                throw new ArgumentException ("Requires a 'union' element.", "element");
            }

            var union = ClassDeclaration (element.Attribute (gs + "managed-name").Value)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddMembersFromElement (element)
                .AddModifiers (ParseToken ("partial"))
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return @namespace.AddMembers (union);
        }

        public static NamespaceDeclarationSyntax AddStaticClasses (this NamespaceDeclarationSyntax @namespace, IEnumerable<XElement> elements)
        {
            foreach (var element in elements) {
                @namespace = @namespace.AddStaticClass (element);
            }
            return @namespace;
        }

        public static NamespaceDeclarationSyntax AddStaticClass (this NamespaceDeclarationSyntax @namespace, XElement element)
        {
            if (element.Name != gs + "static-class") {
                throw new ArgumentException ("Requires a 'static-class' element.", "element");
            }

            var staticClass = ClassDeclaration (element.Attribute (gs + "managed-name").Value)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddModifiers (ParseTokens ("static partial").ToArray ())
                .AddMembersFromElement (element)
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return @namespace.AddMembers (staticClass);
        }

        public static IEnumerable<EnumMemberDeclarationSyntax> GetEnumMembers (this XElement parent)
        {
            foreach (var child in parent.Elements (gi + "member")) {
                var enumMember = EnumMemberDeclaration (child.Attribute (gs + "managed-name").Value)
                    .WithEqualsValue (EqualsValueClause (
                        LiteralExpression (SyntaxKind.NumericLiteralExpression,
                            Literal (int.Parse (child.Attribute ("value").Value)))))
                    .AddAttributeLists (child.GetAttributes ().ToArray ())
                    .WithLeadingTrivia (child.GetDocumentationCommentTrivia ().ToArray ());
                yield return enumMember;
            }
        }

        public static T AddMembersFromElement<T> (this T syntax, XElement parent) where T : TypeDeclarationSyntax
        {
            foreach (var child in parent.Elements (gi + "constant")) {
                syntax = syntax.AddMembers (child.GetConstantField ());
            }
            if (parent.Attribute (gs + "opaque") == null) {
                // hide fields in opaque types
                foreach (var child in parent.Elements (gi + "field")) {
                    syntax = syntax.AddField (child);
                }
            }
            var @class = syntax as ClassDeclarationSyntax;
            if (@class != null && !@class.Modifiers.Select (m => m.Text).Contains ("static")) {
                syntax = @class.AddFromNativeConstructor () as T;
            }
            var callables = parent.Elements (gi + "constructor")
                .Union (parent.Elements (gi + "method"))
                .Union (parent.Elements (gi + "function"));
            foreach (var child in callables) {
                syntax = syntax.AddMembers (child.ToPinvokeMethod ());
                if (!child.Attribute (gs + "pinvoke-only").AsBool ()) {
                    syntax = syntax.AddManagedWrapperForCallable (child);
                }
            }
            return syntax;
        }

        public static FieldDeclarationSyntax GetConstantField (this XElement element)
        {
            if (element.Name != gi + "constant") {
                throw new ArgumentException ("Requires a 'constant' element.", "element");
            }

            var type = ParseTypeName (element.Attribute (gs + "managed-type").Value);
            var variable = VariableDeclarator (element.Attribute (gs + "managed-name").Value);
            var value = element.GetValueAsLiteral ();

            var constant = FieldDeclaration (VariableDeclaration (type)
                .AddVariables(variable.WithInitializer (EqualsValueClause (value))))
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddModifiers (ParseToken ("const"))
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return constant;
        }

        public static T AddField<T> (this T syntax, XElement element) where T : TypeDeclarationSyntax
        {
            if (element.Name != gi + "field") {
                throw new ArgumentException ("Requires a 'field' element.", "element");
            }

            TypeSyntax type;
            var callback = element.Element (gi + "callback");
            if (callback != null) {
                var @delegate = callback.GetDelegateDeclaration (false);
                type = ParseTypeName (@delegate.Identifier.ToString ());
                syntax = syntax.AddMembers (@delegate);
            } else {
                type = ParseTypeName (element.Attribute (gs + "managed-type").Value);
            }
            var variable = VariableDeclarator (element.Attribute (gs + "managed-name").Value);

            var field = FieldDeclaration (
                               VariableDeclaration (type).AddVariables (variable))
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ());

            return syntax.AddMembers (field);
        }

        public static MethodDeclarationSyntax ToPinvokeMethod (this XElement element)
        {
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "constructor") {
                throw new ArgumentException ("Requires a 'function', 'method' or 'constructor' element.", "element");
            }

            var returnType = element.GetReturnType (false);
            var name = element.Attribute (c + "identifier").Value;

            var pinvoke = MethodDeclaration (returnType, name)
                .WithParameters (element, managed: false)
                .AddModifiers (ParseTokens ("static extern").ToArray ())
                .AddPinvokeAttributes (element)
                .WithSemicolonToken (Token (SyntaxKind.SemicolonToken))
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia (managed: false));

            return pinvoke;
        }

        public static MethodDeclarationSyntax AddPinvokeAttributes (this MethodDeclarationSyntax syntax, XElement element)
        {
            syntax = syntax.AddAttribute ("DllImport",
                "(Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)");

            var returnElement = element.Element (gi + "return-value");

            if (returnElement.GetLengthIndex () >= 0) {
                // need to add one to the index if there is an instance parameter
                var offset = element.Parent.Name == gi + "method" ? 1 : 0;
                syntax = syntax.AddAttribute ("MarshalAs",
                    string.Format ("(UnmanagedType.LPArray, SizeParamIndex = {0})",
                        returnElement.GetLengthIndex () + offset),
                    "return");
            }
            if (returnElement.GetFixedSize () >= 0) {
                syntax = syntax.AddAttribute ("MarshalAs",
                    string.Format ("(UnmanagedType.LPArray, SizeConst = {0})",
                        returnElement.GetFixedSize ()),
                    "return");
            }

            return syntax;
        }

        public static BlockSyntax AddArgumentCheckStatements (this BlockSyntax syntax, XElement element)
        {
            var parametersElement = element.Element (gs + "managed-parameters");

            if (parametersElement != null) {
                var parameters = parametersElement.Elements (gi + "parameter")
                    .Where (p => p.Attribute ("direction").AsString ("in") != "out")
                    .Where (p => !GirType.GetType (p.Attribute (gs + "managed-type").Value, element.Document).IsValueType)
                    // TODO: Do we also need to check for the obsolete "allow-none"?
                    .Where (p => !p.Attribute ("nullable").AsBool ()).ToList ();
                foreach (var p in parameters) {
                    var statement = ParseStatement (
                        string.Format (@"if ({0} == null) {{
                            throw new ArgumentNullException (""{0}"");
                        }}", p.Attribute (gs + "managed-name").Value));
                    syntax = syntax.AddStatements (statement);
                }
            }

            return syntax;
        }

        public static T AddManagedWrapperForCallable<T> (this T syntax, XElement element) where T : TypeDeclarationSyntax
        {
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "constructor") {
                throw new ArgumentException ("Requires a 'function', 'method' or 'constructor' element.", "element");
            }

            var returnType = element.GetReturnType (true);
            var name = element.Attribute (gs + "managed-name").Value;
            var parentName = element.Parent.Attribute (gs + "managed-name").Value;
            var isStatic = element.Name == gi + "function";

            var body = Block ()
                .AddArgumentCheckStatements (element)
                .AddInputParamArrayLenthAssignmentStatements (element)
                .AddPinvokeStatement (element);
            if (element.Name != gi + "constructor" && returnType.ToString () != "void") {
                body = body.AddStatements (ReturnStatement ()
                    .WithExpression (ParseExpression (
                    string.Format ("default({0})", returnType))));
            }

            if (element.Name == gi + "constructor") {
                // handle constructors
                var constructor = ConstructorDeclaration (parentName)
                    .WithParameters (element, managed: true)
                    .WithInitializer(ConstructorInitializer(
                        SyntaxKind.BaseConstructorInitializer)
                        .AddArgumentListArguments(Argument(
                            ParseName ("IntPtr.Zero"))))
                    .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                    .AddAttributeLists (element.GetAttributes ().ToArray ())
                    .WithLeadingTrivia (element.GetDocumentationCommentTrivia ())
                    .WithBody (body);

                return syntax.AddMembers (constructor);
            }

            if (name.StartsWith ("Get", StringComparison.Ordinal) || name.StartsWith ("Is", StringComparison.Ordinal)) {
                // handle getters
                if (!element.EnumerateParameters (managed: true).Any ()) {
                    // getters do not have any parameters (other than possibly 'instance-parameter')
                    var propertyName = name;
                    if (propertyName.StartsWith ("Get", StringComparison.Ordinal)) {
                        // drop the "Get" but keep the "Is"
                        propertyName = name.Substring (3);
                    }
                    var property = PropertyDeclaration (returnType, propertyName)
                        .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                        .AddModifiers (ParseToken (isStatic ? "static" : ""))
                        .AddAttributeLists (element.GetAttributes ().ToArray ())
                        .WithLeadingTrivia (element.GetDocumentationCommentTrivia ())
                        .AddAccessorListAccessors (AccessorDeclaration (SyntaxKind.GetAccessorDeclaration)
                            .WithBody (body));

                    return syntax.AddMembers (property);
                }
            }

            if (name.StartsWith ("Set", StringComparison.Ordinal)) {
                // handle setters
                if (element.EnumerateParameters (managed: true).Count () == 1) {
                    // setters have one parameter
                    var propertyName = name.Substring (3);
                    // find the matching property. This assumes the Gir was in alphabetical order and the
                    // getter has already been created.
                    var property = syntax.Members.OfType<PropertyDeclarationSyntax> ()
                        .SingleOrDefault (p => p.Identifier.Text == propertyName || p.Identifier.Text == "Is" + propertyName);
                    var parameter = element.Element (gs + "managed-parameters").Element (gi + "parameter");
                    var parameterName = parameter.Attribute (gs + "managed-name").Value;
                    var parameterType = parameter.Attribute (gs + "managed-type").Value;
                    if (property != null && property.Type.ToString () == parameterType) {
                        var setter = AccessorDeclaration (SyntaxKind.SetAccessorDeclaration)
                            // We need to replace the parameter name with the "value" keyword in the body
                            .WithBody (body.ReplaceTokens (body.DescendantTokens ().Where (t => t.Text == parameterName),
                                (t1, t2) => ParseToken ("value")));

                        return syntax.ReplaceNode (property, property.AddAccessorListAccessors (setter));
                    }
                    // we don't want write-only properties, so if a matching property with a getter was not
                    // found, just fall through to the "regular" method creation.
                }
            }

            // handle "regular" functions and methods
            var method = MethodDeclaration (returnType, name)
                .WithParameters (element, managed: true)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddModifiers (ParseToken (isStatic ? "static" : ""))
                .AddAttributeLists (element.GetAttributes ().ToArray ())
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia ())
                .WithBody (body);

            var methodList = new System.Collections.Generic.List<MemberDeclarationSyntax> ();

            if (element.Attribute (gs + "special-func") != null) {
                switch (element.Attribute (gs + "special-func").Value) {
                case "free":
                case "copy":
                case "ref":
                case "unref":
                case "to-string":
                    method = method.AddModifiers (ParseToken ("override"));
                    break;
                case "equal":
                    string hashFunc = "Handle.GetHashCode ()";
                    var hashFuncElement = element.Parent.Elements ()
                        .SingleOrDefault (e => e.Attribute (gs + "special-func").AsString () == "hash");
                    if (hashFuncElement != null) {
                        hashFunc = "(int)Hash ()";
                    }
                    methodList.Add (CreateOverrideEqualsMethod (parentName));
                    methodList.Add (CreateOverrideGetHashCodeMethod (hashFunc));
                    methodList.Add (CreateEqualityOperator (parentName));
                    methodList.Add (CreateInequalityOperator (parentName));
                    break;
                case "compare":
                    syntax = syntax.AddBaseListType (string.Format ("IComparable<{0}>", parentName));
                    methodList.Add (CreateCompareToOperator ("<", parentName));
                    methodList.Add (CreateCompareToOperator ("<=", parentName));
                    methodList.Add (CreateCompareToOperator (">=", parentName));
                    methodList.Add (CreateCompareToOperator (">", parentName));
                    break;
                }
            }

            methodList.Insert (0, method);

            return syntax.AddMembers (methodList.ToArray ());
        }

        public static BlockSyntax AddInputParamArrayLenthAssignmentStatements (this BlockSyntax syntax, XElement element)
        {
            var parametersElement = element.Element (gi + "parameters");

            if (parametersElement != null) {
                var parameters = parametersElement.Elements (gi + "parameter")
                    .Where (p => p.Attribute ("direction").AsString ("in") != "out").ToList ();
                var arrayParameters = parameters.Where (p => p.GetLengthIndex () >= 0)
                    .Select (p => new Tuple<XElement,XElement> (p, parameters[p.GetLengthIndex ()]));
                foreach (var p in arrayParameters) {
                    var statement = LocalDeclarationStatement (VariableDeclaration (
                        ParseTypeName ("var"))
                        .AddVariables (VariableDeclarator (
                            ParseToken (p.Item2.Attribute (gs + "managed-name").Value))
                            .WithInitializer (EqualsValueClause (
                                ParseExpression (
                                    string.Format ("({0}){1}.Length",
                                        p.Item2.Attribute (gs + "unmanaged-type").Value,
                                        p.Item1.Attribute (gs + "managed-name").Value))))));
                    syntax = syntax.AddStatements (statement);
                }
            }

            return syntax;
        }

        public static BlockSyntax AddPinvokeStatement (this BlockSyntax syntax, XElement element)
        {
            if (element.Name != gi + "function" && element.Name != gi + "method" && element.Name != gi + "constructor") {
                throw new ArgumentException ("Requires a 'function', 'method' or 'constructor' element.", "element");
            }

            var pinvokeExpression = InvocationExpression (
                IdentifierName (element.Attribute (c + "identifier").Value));
            var parametersElement = element.Element (gi + "parameters");
            if (parametersElement != null) {
                var argumentList = ArgumentList ();
                foreach (var p in element.EnumerateParameters (managed: false)) {
                    var name = p.Attribute (gs + "managed-name").Value;
                    if (p.Name == gi + "instance-parameter") {
                        name = "Handle";
                    }
                    var arg = Argument (ParseExpression (name));
                    argumentList = argumentList.AddArguments (arg);
                }
                pinvokeExpression = pinvokeExpression.WithArgumentList (argumentList);
            }

            StatementSyntax statement = ExpressionStatement (pinvokeExpression);
            if (element.GetReturnType (managed: false).ToString () != "void") {
                statement = LocalDeclarationStatement (
                    VariableDeclaration (ParseTypeName ("var"))
                    .AddVariables (VariableDeclarator (ParseToken ("ret"))
                        .WithInitializer (EqualsValueClause (pinvokeExpression))));
            }

            return syntax.AddStatements (statement);
        }

        public static MethodDeclarationSyntax CreateOverrideEqualsMethod (string type)
        {
            var syntax = MethodDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("Equals"))
                .WithModifiers (TokenList (
                    ParseTokens ("public override")))
                .WithParameterList (ParseParameterList ("(object obj)"))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (
                            string.Format ("return Equals (obj as {0});", type))));
            return syntax;
        }

        public static MethodDeclarationSyntax CreateOverrideGetHashCodeMethod (string hashFunc)
        {
            var syntax = MethodDeclaration (
                ParseTypeName ("int"),
                ParseToken ("GetHashCode"))
                .WithModifiers (TokenList (
                    ParseTokens ("public override")))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (
                            string.Format ("return {0};", hashFunc))));
            return syntax;
        }

        public static OperatorDeclarationSyntax CreateEqualityOperator (string type)
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("=="))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", type)))
                .WithBody (Block ()
                    .AddStatements (
                        ParseStatement (@"
                            if ((object)one == null) {
                                return (object)two == null;
                            }"),
                        ParseStatement (
                            "return one.Equals (two);")));
            return syntax;
        }

        public static OperatorDeclarationSyntax CreateInequalityOperator (string type)
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken ("!="))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", type)))
                .WithBody (Block ()
                    .AddStatements (ParseStatement (
                        "return !(one == two);")));
            return syntax;
        }

        public static OperatorDeclarationSyntax CreateCompareToOperator (string @operator, string type)
        {
            var syntax = OperatorDeclaration (
                ParseTypeName ("bool"),
                ParseToken (@operator))
                .WithModifiers (TokenList (
                    ParseTokens ("public static")))
                .WithParameterList (ParseParameterList (
                    string.Format ("({0} one, {0} two)", type)))
                .WithBody (Block ()
                    .AddStatements (ParseStatement (
                        string.Format ("return one.CompareTo (two) {0} 0;", @operator))));

            return syntax;
        }

        public static ClassDeclarationSyntax AddBaseTypeForRecord (this ClassDeclarationSyntax syntax, XElement element)
        {
            if (element.Name != gi + "record") {
                throw new ArgumentException ("Requires a 'record' element.", "element");
            }

            var name = element.Attribute (gs + "managed-name").Value;

            switch (element.Attribute (gs + "opaque").Value) {
            case "ref-counted":
                return syntax.AddBaseListType (string.Format ("GISharp.Core.ReferenceCountedOpaque<{0}>", name));
            case "owned":
                return syntax.AddBaseListType (string.Format ("GISharp.Core.OwnedOpaque<{0}>", name));
            case "static":
                return syntax.AddBaseListType (string.Format ("GISharp.Core.StaticOpaque<{0}>", name));
            }

            return syntax;
        }

        public static T AddBaseListType<T> (this T syntax, string typeName) where T : TypeDeclarationSyntax
        {
            var addBaseListTypes = syntax.GetType ().GetMethod ("AddBaseListTypes");
            if (addBaseListTypes == null) {
                throw new ArgumentException ("Requires AddBaseListTypes method", "syntax");
            }

            var baseType = SimpleBaseType (ParseTypeName (typeName));

            return (T)addBaseListTypes.Invoke (syntax, new [] { new [] { baseType } });
        }

        public static ParameterSyntax GetParameter (this XElement element, bool managed, bool includeDefault)
        {
            if (element.Name != gi + "instance-parameter" && element.Name != gi + "parameter") {
                throw new ArgumentException ("Requires 'instance-parameter' or 'parameter' element.", "element");
            }

            var type = ParseTypeName (element.Attribute (gs + (managed ? "managed-type" : "unmanaged-type")).Value);
            var identifier = Identifier (element.Attribute (gs + "managed-name").Value);

            var parameter = Parameter (identifier)
                .WithType (type)
                .AddModifiers (element.GetParameterModiferToken ());

            if (managed && includeDefault && element.Attribute (gs + "default") != null) {
                parameter = parameter.WithDefault (EqualsValueClause (
                    ParseExpression (element.Attribute (gs + "default").Value)));
            }

            return parameter;
        }

        public static SyntaxToken GetParameterModiferToken (this XElement element)
        {
            var directionAttribute = element.Attribute ("direction");

            if (directionAttribute != null) {
                switch (directionAttribute.Value) {
                case  "out":
                    return Token (SyntaxKind.OutKeyword);
                case "inout":
                    return Token (SyntaxKind.RefKeyword);
                }
            }
            return ParseToken ("");
        }

        public static TypeSyntax GetReturnType (this XElement parent, bool managed)
        {
            var returnValueElement = parent.Element (gi + "return-value");
            if (returnValueElement == null) {
                throw new ArgumentException ("Requires 'return-value' child element.", "parent");
            }

            string typeName;
            if (managed) {
                if (returnValueElement.Attribute ("skip").AsBool ()) {
                    typeName = "void";
                } else {
                    typeName = returnValueElement.Attribute (gs + ("managed-type")).Value;
                }
            } else {
                typeName = returnValueElement.Attribute (gs + ("unmanaged-type")).Value;
            }

            var syntax = ParseTypeName (typeName);

            return syntax;
        }

        public static IEnumerable<SyntaxToken> GetAccessModifiersAsTokens (this XElement element)
        {
            if (element.Attribute (gs + "access-modifier") == null) {
                return ParseTokens ("public");
            }

            return ParseTokens (element.Attribute (gs + "access-modifier").Value);
        }

        public static SyntaxTriviaList GetDocumentationCommentTrivia (this XElement element, bool managed = true)
        {
            string line;
            var builder = new StringBuilder ();
            if (element.Element (gi + "doc") != null) {
                using (var reader = new StringReader (element.Element (gi + "doc").Value)) {
                    builder.AppendLine ("/// <summary>");
                    while ((line = reader.ReadLine ()) != null) {
                        // summary is only the first paragraph
                        if (string.IsNullOrWhiteSpace (line)) {
                            break;
                        }
                        builder.AppendFormat ("/// {0}", new XText (line));
                        builder.AppendLine ();
                    }
                    builder.AppendLine ("/// </summary>");
                    if (line != null) {
                        // if there are more lines, they go in the remarks
                        builder.AppendLine ("/// <remarks>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </remarks>");
                    }
                }
            }
            if (element.Element (gi + "parameters") != null) {
                foreach (var paramElement in element.EnumerateParameters (managed)) {
                    if (paramElement.Element (gi + "doc") != null) {
                        using (var reader = new StringReader (paramElement.Element (gi + "doc").Value)) {
                            builder.AppendFormat ("/// <param name=\"{0}\">",
                                paramElement.Attribute (gs + "managed-name").Value.Replace ("@", ""));
                            builder.AppendLine ();
                            while ((line = reader.ReadLine ()) != null) {
                                builder.AppendFormat ("/// {0}", new XText (line));
                                builder.AppendLine ();
                            }
                            builder.AppendLine ("/// </param>");
                        }
                    }
                }
            }
            if (element.Element (gi + "return-value") != null) {
                if (element.Element (gi + "return-value").Element (gi + "doc") != null) {
                    using (var reader = new StringReader (element.Element (gi + "return-value").Element (gi + "doc").Value)) {
                        builder.AppendLine ("/// <returns>");
                        while ((line = reader.ReadLine ()) != null) {
                            builder.AppendFormat ("/// {0}", new XText (line));
                            builder.AppendLine ();
                        }
                        builder.AppendLine ("/// </returns>");
                    }
                }
            }
            var triviaList = ParseLeadingTrivia (builder.ToString ());

            return triviaList;
        }

        public static DelegateDeclarationSyntax GetDelegateDeclaration (this XElement element, bool managed)
        {
            if (element.Name != gi + "callback") {
                throw new ArgumentException ("Requires a 'callback' element", "element");
            }

            var returnType = ParseTypeName (element.Element (gi + "return-value").Attribute (gs + "managed-type").Value);
            var name = element.Attribute (gs + "managed-name").Value + (managed ? "" : "Native");

            var @delegate = DelegateDeclaration (returnType, name)
                .WithParameters (element, managed)
                .AddModifiers (element.GetAccessModifiersAsTokens ().ToArray ())
                .AddAttribute ("UnmanagedFunctionPointer", "(CallingConvention.Cdecl)")
                .WithLeadingTrivia (element.GetDocumentationCommentTrivia (managed).ToArray ());

            return @delegate;
        }

        public static T WithParameters<T> (this T syntax, XElement element, bool managed) where T : MemberDeclarationSyntax
        {
            if (element == null) {
                return syntax;
            }

            var parameterList = ParameterList ();

            foreach (var child in element.EnumerateParameters (managed)) {
                parameterList = parameterList.AddParameters (child.GetParameter (managed, managed));
            }

            return (T) syntax.GetType ().GetMethod ("WithParameterList").Invoke (syntax, new [] { parameterList });
        }

        public static IEnumerable<XElement> EnumerateParameters (this XElement element, bool managed)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }

            var childElementName = managed ? gs + "managed-parameters" : gi + "parameters";
            var parametersElement = element.Element (childElementName);

            if (parametersElement == null) {
                if (element.Element (gi + "return-value") != null) {
                    // if we have a <return-value>, then we can assume that this is a
                    // proper node and just does not have any parameters.
                    // Alternatly, we could check if this is function/method/constructor/callback
                    yield break;
                }
                var message = string.Format ("Expecting element with <{0}> child element.", childElementName.LocalName);
                throw new ArgumentException (message, nameof(element));
            }

            var instanceParameter = parametersElement.Element (gi + "instance-parameter");
            if (instanceParameter != null) {
                yield return instanceParameter;
            }
            foreach (var parameter in parametersElement.Elements (gi + "parameter")) {
                yield return parameter;
            }
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes (this XElement element)
        {
            if (element.Attribute ("deprecated").AsBool ()) {
                var obsoleteAttribute = Attribute (
                    ParseName ("Obsolete"));

                var message = new StringBuilder ();
                var docDeprecated = element.Element (gi + "doc-deprecated");
                if (docDeprecated != null) {
                    message.Append (docDeprecated.Value);
                }
                var deprecatedSince = element.Attribute ("deprecated-since");
                if (deprecatedSince != null) {
                    if (message.Length > 0) {
                        message.Append (" ");
                    }
                    message.Append (deprecatedSince.Value);
                }
                if (message.Length > 0) {
                    obsoleteAttribute = obsoleteAttribute.AddArgumentListArguments (
                        AttributeArgument (
                            LiteralExpression (SyntaxKind.StringLiteralExpression,
                                Literal (message.ToString ()))));
                }

                yield return AttributeList ().AddAttributes (obsoleteAttribute);
            }

            if (element.Attribute ("version") != null) {
                var sinceAttribute = Attribute (ParseName ("GISharp.Core.Since"))
                    .WithArgumentList (AttributeArgumentList ()
                        .AddArguments (AttributeArgument (
                            LiteralExpression (SyntaxKind.StringLiteralExpression,
                                Literal (element.Attribute ("version").Value)))));

                yield return AttributeList ().AddAttributes (sinceAttribute);
            }

            if (element.Name == gi + "alias") {
                var structLayoutAttribute = Attribute (ParseName ("StructLayout"))
                    .WithArgumentList (ParseAttributeArgumentList ("(LayoutKind.Sequential)"));
                yield return AttributeList ().AddAttributes (structLayoutAttribute);
            }

            if (element.Name == gi + "bitfield") {
                var flagsAttribute = Attribute (ParseName ("Flags"));
                yield return AttributeList ().AddAttributes (flagsAttribute);
            }

            if (element.Attribute (glib + "error-domain") != null) {
                var errorDomainAttribute = Attribute (ParseName ("GISharp.Core.ErrorDomain"))
                    .WithArgumentList (ParseAttributeArgumentList (
                        string.Format ("(\"{0}\")", element.Attribute (glib + "error-domain").Value)));
                yield return AttributeList ().AddAttributes (errorDomainAttribute);
            }

            if (element.Name == gi + "union") {
                var structLayoutAttribute = Attribute (ParseName ("StructLayout"))
                    .WithArgumentList (ParseAttributeArgumentList ("(LayoutKind.Explicit)"));
                yield return AttributeList ().AddAttributes (structLayoutAttribute);
            }

            if (element.Name == gi + "field" && element.Parent.Name == gi + "union") {
                var structLayoutAttribute = Attribute (ParseName ("FieldOffset"))
                    .WithArgumentList (ParseAttributeArgumentList ("(0)"));
                yield return AttributeList ().AddAttributes (structLayoutAttribute);
            }
        }

        public static LiteralExpressionSyntax GetValueAsLiteral (this XElement element)
        {
            if (element.Attribute (gs + "managed-type") == null) {
                throw new ArgumentException ("Requires element to have 'managed-type' attribute.");
            }
            if (element.Attribute ("value") == null) {
                throw new ArgumentException ("Requires element to have 'value' attribute.");
            }

            switch (element.Attribute (gs + "managed-type").Value) {
            case "bool":
            case "System.Boolean":
                switch (element.Attribute ("value").Value) {
                case "true":
                    return LiteralExpression (SyntaxKind.TrueLiteralExpression);
                case "false":
                    return LiteralExpression (SyntaxKind.FalseLiteralExpression);
                default:
                    throw new Exception (string.Format ("Unknown bool constant value '{0}'.", element.Attribute ("value").Value));
                }
            case "byte":
            case "System.Byte":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (byte.Parse (element.Attribute ("value").Value)));
            case "sbyte":
            case "System.SByte":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (sbyte.Parse (element.Attribute ("value").Value)));
            case "short":
            case "System.Int16":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (short.Parse (element.Attribute ("value").Value)));
            case "ushort":
            case "System.UInt16":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (ushort.Parse (element.Attribute ("value").Value)));
            case "int":
            case "System.Int32":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (int.Parse (element.Attribute ("value").Value)));
            case "uint":
            case "System.Uint32":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (uint.Parse (element.Attribute ("value").Value)));
            case "long":
            case "System.Int64":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (long.Parse (element.Attribute ("value").Value)));
            case "ulong":
            case "System.UInt64":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (ulong.Parse (element.Attribute ("value").Value)));
            case "float":
            case "System.Float":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (float.Parse (element.Attribute ("value").Value)));
            case "double":
            case "System.Double":
                return LiteralExpression (SyntaxKind.NumericLiteralExpression,
                    Literal (double.Parse (element.Attribute ("value").Value)));
            case "string":
            case "System.String":
                return LiteralExpression (SyntaxKind.StringLiteralExpression,
                    Literal (element.Attribute ("value").Value));
            default:
                throw new Exception (string.Format ("Bad constant type: {0}", element.Attribute (gs + "managed-type").Value));
            }
        }

        public static T AddMembers<T> (this T syntax, params MemberDeclarationSyntax[] declarations) where T : TypeDeclarationSyntax
        {
            var addMembers = syntax.GetType ().GetMethod ("AddMembers");
            if (addMembers == null) {
                throw new ArgumentException ("Syntax node does not have AddMembers method", "syntax");
            }
            return (T)addMembers.Invoke (syntax, new [] { declarations });
        }

        /// <summary>
        /// Adds an AttributeList with a single attribute and optional parameters.
        /// </summary>
        /// <returns>The new Syntax with the attribute added.</returns>
        /// <param name="syntax">A Syntax object that has an AddAttributeLists method.</param>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="target">The target of the attribute (e.g. "return") or null.</param>
        /// <param name="args">The attribute arguments (including the inclosing parentheses).</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T AddAttribute<T> (this T syntax, string name, string args = null, string target = null) where T : SyntaxNode
        {
            var addAttributeLists = syntax.GetType ().GetMethod ("AddAttributeLists");
            if (addAttributeLists == null) {
                throw new ArgumentException ("Requires Syntax with AddAttributeLists method.", "syntax");
            }

            var attribute = Attribute (ParseName (name));
            if (args != null) {
                attribute = attribute.WithArgumentList (
                    ParseAttributeArgumentList (args));
            }

            var attributeList = AttributeList ().AddAttributes (attribute);
            if (target != null) {
                attributeList = attributeList.WithTarget (AttributeTargetSpecifier (
                    ParseToken (target)));
            }

            return (T)addAttributeLists.Invoke (syntax, new [] { new [] { attributeList } });
        }

        public static ClassDeclarationSyntax AddFromNativeConstructor (this ClassDeclarationSyntax syntax)
        {
            var constructor = ConstructorDeclaration (syntax.Identifier)
                .AddModifiers (ParseToken ("public"))
                .WithParameterList (ParseParameterList ("(IntPtr handle)"))
                .WithInitializer (ConstructorInitializer (SyntaxKind.BaseConstructorInitializer)
                    .WithArgumentList (ParseArgumentList ("(handle)")))
                .WithBody (Block ());

            return syntax.AddMembers (constructor);
        }

        public static int GetClosureIndex (this XElement element)
        {
            if (element.Attribute ("closure") == null) {
                return -1;
            }

            return int.Parse (element.Attribute ("closure").Value);
        }

        public static int GetDestroyIndex (this XElement element)
        {
            if (element.Attribute ("destroy") == null) {
                return -1;
            }

            return int.Parse (element.Attribute ("destroy").Value);;
        }

        public static int GetLengthIndex (this XElement element)
        {
            var arrayElement = element.Element (gi + "array");
            if (arrayElement == null || arrayElement.Attribute ("length") == null) {
                return -1;
            }

            return int.Parse (arrayElement.Attribute ("length").Value);
        }

        public static int GetFixedSize (this XElement element)
        {
            var arrayElement = element.Element (gi + "array");
            if (arrayElement == null || arrayElement.Attribute ("fixed-size") == null) {
                return -1;
            }

            return int.Parse (arrayElement.Attribute ("fixed-size").Value);
        }
    }
}
