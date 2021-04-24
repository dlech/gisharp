// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
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
        public static string GetSpecializedManagedType(this GIArg arg)
        {
            var type = arg.Type.GetManagedType();
            var isAsync = arg.Ancestors.Any(x => x is GICallable callable && callable.IsAsync);

            // special case for hash functions to match .NET object.GetHash() return value
            if (arg is ReturnValue returnValue && returnValue.Callable is Method method && method.IsHash) {
                return typeof(int).FullName;
            }

            if (arg.Type.GirName == "utf8") {
                if (arg.Direction == "out" && arg.IsCallerAllocates) {
                    if (isAsync) {
                        return "System.Memory<byte>";
                    }
                    return "System.Span<byte>";
                }
                if (arg.TransferOwnership == "container") {
                    throw new NotSupportedException("can't treat string as container");
                }
                if (arg.TransferOwnership == "none") {
                    if (arg.IsNullable) {
                        return "GISharp.Lib.GLib.NullableUnownedUtf8";
                    }
                    return "GISharp.Lib.GLib.UnownedUtf8";
                }
                return type;
            }

            var isZeroTerminated = false;

            // special case for fully owned zero terminated arrays of zero terminated strings
            if (arg.Type is Gir.Array array) {
                isZeroTerminated = array.IsZeroTerminated;

                if (array.GirName is null && isZeroTerminated && arg.TransferOwnership == "full") {
                    var elementType = array.TypeParameters.Single();
                    if (elementType.IsString()) {
                        return $"GISharp.Lib.GLib.Strv<{elementType.GetManagedType()}>";
                    }
                }
            }

            if (arg.Type.TypeParameters.Any() && arg.Type.GirName != "GLib.ByteArray" && arg.Type.GirName != "bytestring") {
                // arrays of structs need to use unmanaged type since it may be a
                // different size compared to managed type
                var useUnmanagedElementType = false;

                if (type == "GISharp.Runtime.CArray") {
                    useUnmanagedElementType = true;
                    // TODO: probably need check TransferOwnership == "in" on special types
                    if (isAsync) {
                        if (isZeroTerminated) {
                            throw new NotSupportedException("don't know how to handle zero-terminated CArray in async");
                        }
                        if (arg.Direction == "out" && arg.IsCallerAllocates) {
                            type = "System.Memory";
                        }
                        else {
                            type = "System.ReadOnlyMemory";
                        }
                    }
                    else if (arg.Direction == "out" && arg.IsCallerAllocates) {
                        if (isZeroTerminated) {
                            throw new NotSupportedException("don't know how to handle caller allocated zero-terminated CArray");
                        }
                        type = "System.Span";
                    }
                    else if (!isZeroTerminated && arg.TransferOwnership == "none") {
                        type = "System.ReadOnlySpan";
                    }
                    else if (isZeroTerminated) {
                        if (arg.TransferOwnership == "none") {
                            if (arg.IsNullable) {
                                type = type.Replace("CArray", "NullableUnownedZeroTerminatedCArray");
                            }
                            else {
                                type = type.Replace("CArray", "UnownedZeroTerminatedCArray");
                            }
                        }
                        else {
                            type = type.Replace("CArray", "ZeroTerminatedCArray");
                        }
                    }
                }
                else {
                    if (isZeroTerminated) {
                        if (type == "GISharp.Runtime.CPtrArray") {
                            type = type.Replace("CPtrArray", "ZeroTerminatedCPtrArray");
                        }
                        else {
                            throw new NotSupportedException($"don't know how to handle zero-terminated {type}");
                        }
                    }

                    if (arg.Direction == "out" && arg.IsCallerAllocates) {
                        throw new NotImplementedException("Not sure how to handle caller allocated pointer array");
                    }

                    if (arg.Type.GirName == "GLib.Array") {
                        useUnmanagedElementType = true;
                    }

                    // Reference-counted containsers can only be weak or fully owned
                    // since it is trivial to take a reference to the container.
                    // Other container types also have an unowned version to avoid
                    // copying the container.
                    var lastDot = type.LastIndexOf('.') + 1;
                    if (arg.TransferOwnership == "none" && (
                        type == "GISharp.Runtime.CPtrArray" ||
                        type == "GISharp.Runtime.ZeroTerminatedCPtrArray" ||
                        type == "GISharp.Lib.GLib.List" ||
                        type == "GISharp.Lib.GLib.SList"
                    )) {
                        type = $"{type[..lastDot]}Unowned{type[lastDot..]}";
                    }
                    else if (arg.TransferOwnership != "full") {
                        type = $"{type[..lastDot]}Weak{type[lastDot..]}";
                    }
                }

                // append the type parameters to the type
                var typeParameters = arg.Type.TypeParameters.Select(x =>
                    useUnmanagedElementType ? x.GetUnmanagedType() : x.GetManagedType());
                type += $"<{string.Join(", ", typeParameters)}>";
            }

            return type;
        }

        public static ParameterSyntax GetParameter(this GIArg arg, string suffix = "")
        {
            if (arg is ReturnValue) {
                throw new ArgumentException("Return value can't be a parameter", nameof(arg));
            }

            var managed = arg.ParentNode is ManagedParameters;
            var type = managed ? arg.GetSpecializedManagedType() : arg.Type.GetUnmanagedType();

            if (!managed && arg.Direction != "in" && !arg.IsCallerAllocatesBuffer()) {
                type += "*";
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
                else if (arg.Direction == "in" && arg.IsByRefValueType()) {
                    // TODO: make const and attribute on its own so it can be overridden
                    if (arg.Type.CType.Contains("const")) {
                        yield return Token(InKeyword);
                    }
                    else {
                        yield return Token(RefKeyword);
                    }
                }
            }

            var syntax = Parameter(identifier)
                // .WithAttributeLists(AttributeLists)
                .WithModifiers(TokenList(getModifiers()))
                .WithType(ParseTypeName(type));

            if (arg.IsNullable && !arg.Type.IsValueType() && !type.Contains('*') &&
                    type != "System.IntPtr" && !type.Contains("Unowned", StringComparison.Ordinal) &&
                    !type.StartsWith("System.Span", StringComparison.Ordinal) &&
                    !type.StartsWith("System.ReadOnlySpan", StringComparison.Ordinal)) {
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
                    expression = $"ref {expression}";
                }
                else if (arg.Direction == "out" && !arg.IsCallerAllocatesBuffer()) {
                    var @var = declareOutVars ? "var " : "";
                    expression = $"out {@var}{expression}";
                }
                else if (arg.Direction == "in" && arg.IsByRefValueType()) {
                    if (!arg.Type.CType.Contains("const")) {
                        expression = $"ref {expression}";
                    }
                }
            }

            if (arg.ParentNode is Parameters) {
                if (arg.Direction != "in" && !arg.IsCallerAllocates && !(arg.Direction == "inout" && arg.Type.IsValueType())) {
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
            return LocalDeclarationStatement(
                VariableDeclaration(ParseTypeName(arg.Type.GetUnmanagedType()))
                    .AddVariables(VariableDeclarator(arg.ManagedName + "_"))
            );
        }

        public static StatementSyntax[] GetMarshalManagedToUnmanagedStatements(this GIArg arg, out FixedStatementSyntax fixedStatement, bool declareVariable = true)
        {
            fixedStatement = null;

            var @var = declareVariable ? "var " : (arg.Direction != "in" && !arg.IsCallerAllocates ? "*" : "");

            var expressions = new List<ExpressionSyntax>();
            var type = arg.GetSpecializedManagedType();
            var unmanagedName = arg.ManagedName + "_";
            var unmanagedType = arg.Type.GetUnmanagedType();

            // explicit cast expression to unmanaged type
            var unmanagedCast = $"({unmanagedType})";

            if (arg.Type is Gir.Array array && array.GirName is null && !type.Contains("GISharp.Lib.GLib.Strv")) {
                var isSpanLike = arg.TransferOwnership == "none";
                var takeData = arg.TransferOwnership == "full";
                var isAsync = arg.Ancestors.Any(x => x is GICallable callable && callable.IsAsync);

                if (!takeData && !isAsync) {
                    var isPtrArray = type.Contains(nameof(CPtrArray), StringComparison.Ordinal);
                    var dataType = ParseTypeName(isPtrArray ? "System.IntPtr*" : unmanagedType);
                    fixedStatement = FixedStatement(
                        VariableDeclaration(dataType).AddVariables(
                            VariableDeclarator($"{arg.ManagedName}Data_")
                                .WithInitializer(EqualsValueClause(ParseExpression(arg.ManagedName)))
                        ),
                        Block()
                    );
                }

                if (takeData) {
                    expressions.Add(ParseExpression(
                        $"var ({arg.ManagedName}Data_, {arg.ManagedName}Length_) = {arg.ManagedName}{(arg.IsNullable ? "?.TakeData() ?? (System.IntPtr.Zero, 0)" : ".TakeData()")}"
                    ));
                }

                var getter = $"{unmanagedCast}{arg.ManagedName}Data_";
                if (isAsync) {
                    // TODO: add MemoryHandle to AsyncState and free later.
                    getter = $"{unmanagedCast}{arg.ManagedName}.Pin().Pointer";
                }

                expressions.Add(ParseExpression($"{@var}{unmanagedName} = {getter}"));

                if (array.LengthIndex >= 0) {
                    var lengthArg = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    var lengthIdentifier = lengthArg.ManagedName;
                    var lengthType = lengthArg.Type.GetUnmanagedType();
                    var lengthGetter = (arg.IsNullable && !isSpanLike) ? $"{arg.ManagedName}?.Length ?? 0" : $"{arg.ManagedName}.Length";
                    if (takeData) {
                        lengthGetter = $"{arg.ManagedName}Length_";
                    }

                    // if there is another parameter before this one that shares the
                    // same length arg, then verify that the length of this arg
                    // matches the first
                    if (arg.Callable.ManagedParameters.TakeWhile(x => x != arg)
                        .Where(x => x.Type is Gir.Array a && a.LengthIndex == array.LengthIndex)
                        .FirstOrDefault() is GIArg first
                    ) {
                        // TODO: change expressions list to statements list so we
                        // can have a proper if statement
                        var exception = $"System.ArgumentException(\"Length length of {arg.ManagedName} must be the same as {first.ManagedName}\", nameof({arg.ManagedName}))";
                        expressions.Add(ParseExpression(
                            $"{lengthIdentifier}_ = {lengthIdentifier}_ == ({lengthType}){lengthGetter} ? {lengthIdentifier}_ : throw new {exception}"
                        ));
                    }
                    else {
                        expressions.Add(ParseExpression(
                            $"{@var}{lengthIdentifier}_ = ({lengthType}){lengthGetter}"
                        ));
                    }
                }
            }
            else if (arg.Type.IsOpaque()) {
                if (arg.Type.GirName == "utf8" && arg.TransferOwnership == "none") {
                    expressions.Add(ParseExpression($"{@var}{unmanagedName} = {unmanagedCast}{arg.ManagedName}.UnsafeHandle"));
                }
                else {
                    var getter = arg.TransferOwnership == "none" ? "UnsafeHandle" : "Take()";
                    expressions.Add(arg.IsNullable ?
                        ParseExpression($"{@var}{unmanagedName} = {unmanagedCast}({arg.ManagedName}?.{getter} ?? System.IntPtr.Zero)") :
                        ParseExpression($"{@var}{unmanagedName} = {unmanagedCast}{arg.ManagedName}.{getter}"));
                }
            }
            else if (arg.Type.IsValueType()) {
                // value types are used directly
                if ((arg.Direction == "out" && arg.IsCallerAllocates) || arg.Direction == "inout") {
                    fixedStatement = FixedStatement(
                        VariableDeclaration(ParseTypeName($"{unmanagedType}*"))
                            .AddVariables(VariableDeclarator(unmanagedName)
                                .WithInitializer(EqualsValueClause(ParseExpression($"&{arg.ManagedName}")))
                        ),
                        Block());
                }
                else if (arg.Direction == "in" && arg.IsByRefValueType()) {
                    // basically same as above without "*" added to unmanaged type
                    fixedStatement = FixedStatement(
                        VariableDeclaration(ParseTypeName($"{unmanagedType}"))
                            .AddVariables(VariableDeclarator(unmanagedName)
                                .WithInitializer(EqualsValueClause(ParseExpression($"&{arg.ManagedName}")))
                        ),
                        Block());
                }
                else if (unmanagedType.Contains('*')) {
                    expressions.Add(ParseExpression($"{@var}{unmanagedName} = &{arg.ManagedName}"));
                }
                else if (arg.Type.GirName == "gboolean") {
                    expressions.Add(ParseExpression($"{@var}{unmanagedName} = {typeof(BooleanExtensions)}.{nameof(BooleanExtensions.ToBoolean)}({arg.ManagedName})"));
                }
                else if (arg.Type.GirName == "gunichar") {
                    // System.Text.Rune doesn't have cast from Rune operators
                    expressions.Add(ParseExpression($"{@var}{unmanagedName} = {unmanagedCast}{arg.ManagedName}.Value"));
                }
                else {
                    expressions.Add(ParseExpression($"{@var}{unmanagedName} = {unmanagedCast}{arg.ManagedName}"));
                }
            }
            else if (arg.Type.Interface is Callback callback) {
                if (arg.Callable.Parameters.RegularParameters.ElementAtOrDefault(arg.ClosureIndex) is Parameter userData) {
                    // if the callback is a closure (has user data) then we use the
                    // unmanaged callers only callback and pass the managed callback
                    // GC handle as the user data.

                    var nullCheck = arg.IsNullable ? $"{arg.ManagedName} is null ? default : " : "";

                    expressions.Add(ParseExpression(
                        $"{@var}{unmanagedName} = {nullCheck}{unmanagedCast}&{type}Marshal.Callback"
                    ));
                    expressions.Add(ParseExpression(
                        $"var {arg.ManagedName}Handle = {nullCheck}{typeof(GCHandle)}.Alloc(({arg.ManagedName}, GISharp.Runtime.CallbackScope.{arg.Scope.ToPascalCase()}))"
                    ));
                    expressions.Add(ParseExpression(
                        $"{@var}{userData.ManagedName}_ = (System.IntPtr){arg.ManagedName}Handle"
                    ));
                }
                else {
                    throw new NotImplementedException("need to handle callback without user data");
                }

                if (arg.Callable.Parameters.RegularParameters.ElementAtOrDefault(arg.DestroyIndex) is Parameter destroy) {
                    var nullCheck = arg.IsNullable ? $"{arg.ManagedName} is null ? default : " : "";
                    expressions.Add(ParseExpression(
                        $"{@var}{destroy.ManagedName}_ = {nullCheck}({destroy.Type.GetUnmanagedType()})&GISharp.Runtime.GMarshal.DestroyGCHandle"
                    ));
                }
                else if (arg.Scope == "notified") {
                    throw new Exception("notified scope without destroy index");
                }
            }
            else {
                expressions.Add(ParseExpression($"throw new System.NotImplementedException(\"{nameof(GetMarshalManagedToUnmanagedStatements)}\")"));
            }

            return expressions.Select(x => ExpressionStatement(x)).ToArray();
        }

        public static StatementSyntax[] GetMarshalUnmanagedToManagedStatements(this GIArg arg, bool declareVariable = true)
        {
            var expressions = new List<ExpressionSyntax>();
            var type = arg.GetSpecializedManagedType();
            var @var = declareVariable ? "var " : "";
            var ownership = arg.GetOwnershipTransfer();

            if (type.Contains("GISharp.Lib.GLib.Strv")) {
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
                var getter = $"new {type}((System.IntPtr){arg.ManagedName}_, {lengthArg}, {ownership})";

                if (type.Contains("Unowned", StringComparison.Ordinal) || type.Contains("Span", StringComparison.Ordinal)) {
                    getter = $"new {type}({arg.ManagedName}_, {lengthArg})";
                }

                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {getter}"));
            }
            else if (type.Contains("Unowned", StringComparison.Ordinal)) {
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = new {type}({arg.ManagedName}_)"));
            }
            else if (arg.Type.IsValueType()) {
                // value types are used directly
                if ((arg is ReturnValue returnValue && returnValue.IsRefReturn()) || (arg.Direction == "in" && arg.IsByRefValueType())) {
                    // TODO: consider "readonly" here if arg type is const
                    expressions.Add(ParseExpression($"ref {@var}{arg.ManagedName} = ref System.Runtime.CompilerServices.Unsafe.AsRef<{type}>({arg.ManagedName}_)"));
                }
                else if (arg.Type.GirName == "gboolean") {
                    expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {typeof(BooleanExtensions)}.{nameof(BooleanExtensions.IsTrue)}({arg.ManagedName}_)"));
                }
                else {
                    expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = ({type}){arg.ManagedName}_"));
                }
            }
            else if (arg.Type.Interface is Interface) {
                var getInstance = "GISharp.Lib.GObject.Object.GetInstance";
                var nullable = arg.IsNullable ? "?" : "";
                var notNullable = arg.IsNullable ? "" : "!";
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = ({type}{nullable}){getInstance}((System.IntPtr){arg.ManagedName}_, {ownership}){notNullable}"));
            }
            else if (arg.Type.Interface is Callback) {
                var userDataArg = arg.Callable.Parameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var marshal = $"{type}Marshal";
                var getter = $"{marshal}.FromPointer({arg.ManagedName}_, {userData}_)";
                if (arg.IsNullable) {
                    getter = $"{arg.ManagedName}_ is null ? default({type}) : {getter}";
                }
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {getter}"));
            }
            else if (arg.Type.IsOpaque()) {
                var notNullable = arg.IsNullable ? "" : "!";
                expressions.Add(ParseExpression($"{@var}{arg.ManagedName} = {type}.GetInstance<{type}>((System.IntPtr){arg.ManagedName}_, {ownership}){notNullable}"));
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
            if (arg.Type.GirName == "bytestring") {
                return true;
            }
            if (arg.Type is Gir.Array) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tests if arg managed type is a value type and it is passed by reference
        /// to unmanaged code.
        /// </summary>
        public static bool IsByRefValueType(this GIArg arg)
        {
            if (!arg.Type.IsValueType()) {
                return false;
            }

            if (!arg.Type.IsPointer) {
                return false;
            }

            if (arg.Type.GetUnmanagedType() == "System.IntPtr") {
                return false;
            }

            return true;
        }
    }
}
