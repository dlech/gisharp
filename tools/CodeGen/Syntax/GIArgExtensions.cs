// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Object = GISharp.Lib.GObject.Object;
using Signal = GISharp.CodeGen.Gir.Signal;

namespace GISharp.CodeGen.Syntax
{
    public static class GIArgExtensions
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        /// <summary>
        /// Gets the managed type. If the arg is a buffer type, it gets the
        // specialized type taking into account arg attributes such as nullability,
        /// direction, ownership, etc.
        /// </summary>
        public static System.Type GetSpecializedManagedType(this GIArg arg)
        {
            var type = arg.Type.ManagedType;
            var isAsync = arg.Ancestors.Any(x => x is GICallable callable && callable.IsAsync);

            if (type == typeof(Utf8)) {
                if (arg.Direction == "out" && arg.IsCallerAllocates) {
                    if (isAsync) {
                        return typeof(Memory<byte>);
                    }
                    return typeof(Span<byte>);
                }
                if (arg.TransferOwnership == "none") {
                    return arg.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                }
            }

            if (type.IsGenericType) {
                var genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(Lib.GLib.List<>)) {
                    if (arg.TransferOwnership == "container") {
                        return typeof(WeakList<>).MakeGenericType(type.GetGenericArguments());
                    }
                    if (arg.TransferOwnership == "none") {
                        return typeof(UnownedList<>).MakeGenericType(type.GetGenericArguments());
                    }
                }
                else if (genericType == typeof(SList<>)) {
                    if (arg.TransferOwnership == "container") {
                        return typeof(WeakSList<>).MakeGenericType(type.GetGenericArguments());
                    }
                    if (arg.TransferOwnership == "none") {
                        return typeof(UnownedSList<>).MakeGenericType(type.GetGenericArguments());
                    }
                }
                else if (genericType == typeof(CArray<>)) {
                    if (isAsync) {
                        if (arg.Direction == "out" && arg.IsCallerAllocates) {
                            return typeof(Memory<>).MakeGenericType(type.GetGenericArguments());
                        }
                        return typeof(ReadOnlyMemory<>).MakeGenericType(type.GetGenericArguments());
                    }
                    if (arg.Direction == "out" && arg.IsCallerAllocates) {
                        return typeof(Span<>).MakeGenericType(type.GetGenericArguments());
                    }
                    if (arg.TransferOwnership == "none") {
                        return typeof(ReadOnlySpan<>).MakeGenericType(type.GetGenericArguments());
                    }
                }
                else if (genericType == typeof(CPtrArray<>)) {
                    if (arg.Direction == "out" && arg.IsCallerAllocates) {
                        throw new NotImplementedException("Not sure how to handle caller allocated pointer array");
                    }
                    if (arg.TransferOwnership == "none") {
                        return typeof(UnownedCPtrArray<>).MakeGenericType(type.GetGenericArguments());
                    }
                }
            }

            return type;
        }

        public static ParameterSyntax GetParameter(this GIArg arg, string suffix = "")
        {
            if (arg is ReturnValue) {
                throw new ArgumentException("Return value can't be a parameter", nameof(arg));
            }

            var managed = arg.ParentNode is ManagedParameters;
            var type = managed ? arg.GetSpecializedManagedType() : arg.Type.UnmanagedType;

            if (!managed && arg.Direction != "in" && !arg.IsCallerAllocatesBuffer()) {
                type = type.MakePointerType();
            }

            var identifier = ParseToken(arg.ManagedName + suffix);

            IEnumerable<SyntaxToken> getModifiers()
            {
                // unmanaged parameters don't get modifiers
                if (!managed) {
                    yield break;
                }

                if (arg.Direction == "inout") {
                    yield return Token(RefKeyword);
                }
                else if (arg.Direction == "out" && !arg.IsCallerAllocatesBuffer()) {
                    yield return Token(OutKeyword);
                }
                else if (arg.IsParams) {
                    yield return Token(ParamsKeyword);
                }
                else if (arg is InstanceParameter && !(arg.ParentNode.ParentNode is Signal)) {
                    yield return Token(ThisKeyword);
                }

                // TODO: consider "in" keyword for large struct
            }

            var syntax = Parameter(identifier)
                // .WithAttributeLists(AttributeLists)
                .WithModifiers(TokenList(getModifiers()))
                .WithType(type.ToSyntax());

            if (arg.IsNullable && !type.IsValueType && !type.IsPointer) {
                syntax = syntax.WithType(NullableType(syntax.Type));
            }

            if (arg.ParentNode is ManagedParameters && arg.DefaultValue is not null) {
                var @default = EqualsValueClause(ParseExpression(arg.DefaultValue));
                syntax = syntax.WithDefault(@default);
            }
            return syntax;
        }

        public static ArgumentSyntax GetArgument(this GIArg arg, string suffix = "", bool declareOutVars = true)
        {
            var expression = arg.ManagedName + suffix;

            if (arg.ParentNode is ManagedParameters) {
                if (arg.Direction == "inout") {
                    expression = "ref " + expression;
                }
                else if (arg.Direction == "out" && !arg.IsCallerAllocatesBuffer()) {
                    var @var = declareOutVars ? "var " : "";
                    expression = $"out {@var}" + expression;
                }
            }

            if (arg.ParentNode is Parameters) {
                if (arg.Direction != "in" && !arg.IsCallerAllocates) {
                    expression = "&" + expression;
                }
            }

            return Argument(ParseExpression(expression));
        }

        public static MemberAccessExpressionSyntax GetOwnershipTransfer(this GIArg arg)
        {
            return MemberAccessExpression(SimpleMemberAccessExpression,
                ParseExpression(typeof(Transfer).FullName),
                IdentifierName(arg.TransferOwnership.ToPascalCase()));
        }

        public static LocalDeclarationStatementSyntax GetOutVariableDeclaration(this GIArg arg)
        {
            // TODO: also handle managed type
            var type = arg.Type.UnmanagedType;
            return LocalDeclarationStatement(
                VariableDeclaration(type.ToSyntax())
                    .AddVariables(VariableDeclarator(arg.ManagedName + "_"))
            );
        }

        public static StatementSyntax[] GetMarshalManagedToUnmanagedStatements(this GIArg arg, out FixedStatementSyntax fixedStatement, bool declareVariable = true)
        {
            fixedStatement = null;

            var expressions = new System.Collections.Generic.List<ExpressionSyntax>();
            var type = arg.Type.ManagedType;
            var unmanagedName = arg.ManagedName + "_";
            var unmanagedType = arg.Type.UnmanagedType;

            // explicit cast expression to unmanaged type
            var unmanagedCast = $"({unmanagedType.ToSyntax()})";

            if (arg.Type is Gir.Array array && array.GirName is null && type != typeof(Strv) && type != typeof(FilenameArray)) {
                var isSpanLike = arg.TransferOwnership == "none";
                var takeData = arg.TransferOwnership == "full";
                var isAsync = arg.Ancestors.Any(x => x is GICallable callable && callable.IsAsync);

                if (!takeData && !isAsync) {
                    var isPtrArray = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CPtrArray<>);
                    var dataType = (isPtrArray ? typeof(IntPtr).MakePointerType() : unmanagedType).ToSyntax();
                    fixedStatement = FixedStatement(
                        VariableDeclaration(dataType).AddVariables(
                            VariableDeclarator($"{arg.ManagedName}Data_")
                                .WithInitializer(EqualsValueClause(ParseExpression(arg.ManagedName)))
                        ),
                        Block()
                    );
                }

                var getter = takeData ? "TakeData()" : $"{unmanagedCast}{arg.ManagedName}Data_";
                if (takeData) {
                    getter = arg.IsNullable ?
                        $"{unmanagedCast}({arg.ManagedName}?.{getter} ?? System.IntPtr.Zero)" :
                        $"{unmanagedCast}{arg.ManagedName}.{getter}";
                }
                if (isAsync) {
                    // TODO: add MemoryHandle to AsyncState and free later.
                    getter = $"{unmanagedCast}{arg.ManagedName}.Pin().Pointer";
                }

                expressions.Add(ParseExpression($"{unmanagedName} = {getter}"));

                if (array.LengthIndex >= 0) {
                    var lengthArg = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    var lengthIdentifier = lengthArg.ManagedName;
                    var lengthType = lengthArg.Type.UnmanagedType.ToSyntax();
                    var lengthGetter = (arg.IsNullable && !isSpanLike) ? $"{arg.ManagedName}?.Length ?? 0" : $"{arg.ManagedName}.Length";
                    expressions.Add(ParseExpression($"{lengthIdentifier}_ = ({lengthType}){lengthGetter}"));
                }
            }
            else if (type.IsOpaque() || type.IsGInterface()) {
                if (type == typeof(Utf8) && arg.TransferOwnership == "none") {
                    expressions.Add(ParseExpression($"{unmanagedName} = {unmanagedCast}{arg.ManagedName}.UnsafeHandle"));
                }
                else {
                    var getter = arg.TransferOwnership == "none" ? "UnsafeHandle" : "Take()";
                    expressions.Add(arg.IsNullable ?
                        ParseExpression($"{unmanagedName} = {unmanagedCast}({arg.ManagedName}?.{getter} ?? System.IntPtr.Zero)") :
                        ParseExpression($"{unmanagedName} = {unmanagedCast}{arg.ManagedName}.{getter}"));
                }
            }
            else if (type.IsValueType) {
                // value types are used directly
                if (arg.Direction == "out" && arg.IsCallerAllocates) {
                    fixedStatement = FixedStatement(
                        VariableDeclaration(unmanagedType.MakePointerType().ToSyntax())
                            .AddVariables(VariableDeclarator(unmanagedName)
                                .WithInitializer(EqualsValueClause(ParseExpression($"&{arg.ManagedName}")))
                        ),
                        Block());
                }
                else if (unmanagedType.IsPointer) {
                    expressions.Add(ParseExpression($"{unmanagedName} = &{arg.ManagedName}"));
                }
                else if (type == typeof(bool)) {
                    expressions.Add(ParseExpression($"{unmanagedName} = {typeof(BooleanExtensions)}.{nameof(BooleanExtensions.ToBoolean)}({arg.ManagedName})"));
                }
                else {
                    expressions.Add(ParseExpression($"{unmanagedName} = {unmanagedCast}{arg.ManagedName}"));
                }
            }
            else if (type.IsDelegate()) {
                var destroyArg = arg.Callable.Parameters.RegularParameters.ElementAtOrDefault(arg.DestroyIndex);
                var destroy = destroyArg?.ManagedName ?? (arg.Scope == "call" ? "destroy" : "");
                var userDataArg = arg.Callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var scope = $"{typeof(CallbackScope)}.{arg.Scope.ToPascalCase()}";
                var marshal = $"{type}Marshal";
                var getter = $"{marshal}.ToUnmanagedFunctionPointer({arg.ManagedName}, {scope})";
                var identifiers = $"{unmanagedName}, {destroy}_, {userData}_";
                expressions.Add(ParseExpression($"({identifiers}) = {getter}"));
            }
            else {
                expressions.Add(ParseExpression($"throw new System.NotImplementedException(\"{nameof(GetMarshalManagedToUnmanagedStatements)}\")"));
                declareVariable = false;
            }

            if (declareVariable) {
                expressions = expressions.Select(x => ParseExpression($"var {x}")).ToList();
            }
            else if (arg.Direction != "in" && !arg.IsCallerAllocates) {
                expressions = expressions.Select(x => ParseExpression($"*{x}")).ToList();
            }

            return expressions.Select(x => ExpressionStatement(x)).ToArray();
        }

        public static StatementSyntax[] GetMarshalUnmanagedToManagedStatements(this GIArg arg, bool declareVariable = true)
        {
            var expressions = new System.Collections.Generic.List<ExpressionSyntax>();
            var type = arg.GetSpecializedManagedType();
            var @var = declareVariable ? "var " : "";
            var ownership = arg.GetOwnershipTransfer();

            if (type == typeof(Strv) || type == typeof(FilenameArray)) {
                var lengthArg = "-1";

                if (arg.Type is Gir.Array v && v.LengthIndex >= 0) {
                    // If there is a length provided for Strv, capture it
                    var lengthParameter = arg.Callable.Parameters.RegularParameters.ElementAt(v.LengthIndex);
                    lengthArg = $"(int){lengthParameter.ManagedName}_";
                }

                // TODO: handle nullable case
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = new {type}((System.IntPtr){arg.ManagedName}_, {lengthArg}, {ownership})"));
            }
            else if (arg.Type is Gir.Array array && array.GirName is null) {
                var lengthArg = "-1";
                if (array.LengthIndex >= 0) {
                    var lengthParameter = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    lengthArg = $"(int){lengthParameter.ManagedName}_";
                }
                var getter = $"new {type.ToSyntax()}((System.IntPtr){arg.ManagedName}_, {lengthArg}, {ownership})";

                var genericType = type.GetGenericTypeDefinition();
                if (type.Name.Contains("Unowned", StringComparison.Ordinal) || genericType == typeof(Span<>) || genericType == typeof(ReadOnlySpan<>)) {
                    getter = $"new {type.ToSyntax()}({arg.ManagedName}_, {lengthArg})";
                }

                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {getter}"));
            }
            else if (type.Name.Contains("Unowned", StringComparison.Ordinal)) {
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = new {type.ToSyntax()}({arg.ManagedName}_)"));
            }
            else if (type.IsValueType) {
                // value types are used directly
                if (arg is ReturnValue returnValue && returnValue.IsRefReturn()) {
                    expressions.Add(ParseExpression($"ref readonly {@var}{arg.ManagedName} = ref System.Runtime.CompilerServices.Unsafe.AsRef<{arg.Type.ManagedType}>({arg.ManagedName}_)"));
                }
                else if (type == typeof(bool)) {
                    expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {typeof(BooleanExtensions)}.{nameof(BooleanExtensions.IsTrue)}({arg.ManagedName}_)"));
                }
                else {
                    expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = ({arg.Type.ManagedType}){arg.ManagedName}_"));
                }
            }
            else if (type.IsOpaque()) {
                var getInstance = $"{typeof(Opaque)}.{nameof(Opaque.GetInstance)}";
                var notNullable = arg.IsNullable ? "" : "!";
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {getInstance}<{type.ToSyntax()}>((System.IntPtr){arg.ManagedName}_, {ownership}){notNullable}"));
            }
            else if (type.IsInterface) {
                var getInstance = $"{typeof(Object)}.{nameof(Object.GetInstance)}";
                var nullable = arg.IsNullable ? "?" : "";
                var notNullable = arg.IsNullable ? "" : "!";
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = ({type.ToSyntax()}{nullable}){getInstance}((System.IntPtr){arg.ManagedName}_, {ownership}){notNullable}"));
            }
            else if (type.IsDelegate()) {
                var userDataArg = arg.Callable.Parameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var marshal = $"{arg.Type.ManagedType}Marshal";
                var getter = $"{marshal}.FromPointer({arg.ManagedName}_, {userData}_)";
                if (arg.IsNullable) {
                    var callbackType = arg.Type.ManagedType.ToSyntax();
                    var defaultValue = $"default({callbackType})";
                    getter = $"{arg.ManagedName}_ == System.IntPtr.Zero ? {defaultValue} : {getter}";
                }
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {getter}"));
            }
            else {
                expressions.Add(ParseExpression(
                    $"throw new System.NotImplementedException(\"{nameof(GetMarshalUnmanagedToManagedStatements)}() for {type}\")"
                ));
            }

            return expressions.Select(x => ExpressionStatement(x)).ToArray();
        }


        // create a multi-line comment that contains the type info from the GIR XML file
        public static SyntaxTrivia GetGirXmlTrivia(this GIArg arg)
        {
            var copy = new XElement(arg.Element);
            copy.Descendants(gi + "doc").Remove();
            // Thanks: http://stackoverflow.com/a/14865785/1976323
            foreach (var e in copy.DescendantsAndSelf()) {
                // Stripping the namespace by setting the name of the element to it's localname only
                e.Name = e.Name.LocalName;
                // replacing all attributes with attributes that are not namespaces
                // and their names are set to only the localname
                e.ReplaceAttributes(e.Attributes()
                    .Where(a => !a.IsNamespaceDeclaration)
                    .Select(a => new XAttribute(a.Name.LocalName, a.Value)));
            }
            var comment = $"/* {copy.Elements().Single()} */".Replace("\n", "\n * ");
            return Comment(comment);
        }

        public static SyntaxTrivia GetAnnotationTrivia(this GIArg arg)
        {
            var builder = new StringBuilder("/* ");
            var attrs = arg.Element.Attributes()
                .Where(x => x.Name.Namespace != gs && x.Name != "name");
            foreach (var attr in attrs) {
                builder.AppendFormat("{0}:{1} ", attr.Name.LocalName, attr.Value);
            }
            builder.Append("*/");
            return Comment(builder.ToString());
        }

        public static bool IsUnownedUtf8(this GIArg arg)
        {
            return arg.Type.GirName == "utf8" && arg.TransferOwnership == "none";
        }

        /// <summary>
        /// Returns <c>true</c> if the arg is out, caller-allocates and is a
        /// C array or string.
        /// </summary>
        public static bool IsCallerAllocatesBuffer(this GIArg arg)
        {
            if (arg.Direction != "out") {
                return false;
            }
            if (!arg.IsCallerAllocates) {
                return false;
            }
            if (arg.Type.GirName == "utf8") {
                return true;
            }
            if (arg.Type.GirName == "filename") {
                return true;
            }
            if (arg.Type is Gir.Array) {
                return true;
            }
            return false;
        }
    }
}
