using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.CodeGen.Syntax
{
    public static class GIArgExtensions
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace gs = GISharp.CodeGen.Globals.GISharpNamespace;

        public static ParameterSyntax GetParameter(this GIArg arg, string suffix = "", bool unownedUtf8AsString = false)
        {
            var managed = arg.ParentNode is ManagedParameters;
            var type = managed ? arg.Type.ManagedType : arg.Type.UnmanagedType;
            var byRef = false;

            if (arg.Type.UnmanagedType.IsPointer) {
                if (!managed) {
                    type = type.GetElementType();
                }
                byRef = true;
            }

            if (managed && arg.TransferOwnership == "none") {
                if (type == typeof(Utf8)) {
                    if (unownedUtf8AsString) {
                        type = typeof(string);
                    }
                    else {
                        type = arg.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                    }
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CArray<>)) {
                    type = typeof(ReadOnlySpan<>).MakeGenericType(type.GetGenericArguments());
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CPtrArray<>)) {
                    type = typeof(UnownedCPtrArray<>).MakeGenericType(type.GetGenericArguments());
                }
            }

            var identifier = ParseToken(arg.ManagedName + suffix);

            IEnumerable<SyntaxToken> getModifiers()
            {
                if (arg is ReturnValue) {
                    yield break;
                }

                if (arg.ParentNode is Parameters) {
                    if (arg.Direction == "inout") {
                        yield return Token(RefKeyword);
                    }
                    else if (arg.Direction == "out") {
                        yield return Token(OutKeyword);
                    }
                    else if (byRef) {
                        yield return Token(InKeyword);
                    }
                    yield break;
                }

                if (arg.Direction == "inout") {
                    yield return Token(RefKeyword);
                }
                else if (arg.Direction == "out") {
                    yield return Token(OutKeyword);
                }
                else if (arg.IsParams) {
                    yield return Token(ParamsKeyword);
                }
                else if (arg is InstanceParameter) {
                    yield return Token(ThisKeyword);
                }
                else if (byRef && !(arg.Type is Gir.Array)) {
                    yield return Token(InKeyword);
                }
            }

            var syntax = Parameter(identifier)
                // .WithAttributeLists(AttributeLists)
                .WithModifiers(TokenList(getModifiers()))
                .WithType(type.ToSyntax());

            if (arg.IsNullable && !type.IsValueType && !type.IsPointer) {
                syntax = syntax.WithType(NullableType(syntax.Type));
            }

            if (arg.ParentNode is ManagedParameters && arg.DefaultValue != null) {
                var @default = EqualsValueClause(ParseExpression(arg.DefaultValue));
                syntax = syntax.WithDefault(@default);
            }
            return syntax;
        }

        public static ArgumentSyntax GetArgument(this GIArg arg, string suffix = "", bool declareOutVars = true)
        {
            var expression = arg.ManagedName + suffix;

            if (arg.Direction == "inout") {
                expression = "ref " + expression;
            }
            else if (arg.Direction == "out") {
                var var_ = declareOutVars ? "var " : "";
                expression = $"out {var_}" + expression;
            }

            return Argument(ParseExpression(expression));
        }

        public static MemberAccessExpressionSyntax GetOwnershipTransfer(this GIArg arg)
        {
            return MemberAccessExpression(SimpleMemberAccessExpression,
                ParseExpression(typeof(Transfer).FullName),
                IdentifierName(arg.TransferOwnership.ToPascalCase()));
        }

        public static StatementSyntax[] GetMarshalManagedToUnmanagedStatements(this GIArg arg, bool declareVariable = true)
        {
            var expressions = new System.Collections.Generic.List<ExpressionSyntax>();
            var type = arg.Type.ManagedType;

            if (arg.Type is Gir.Array array && array.GirName == null) {
                bool isSpanLike = arg.TransferOwnership == "none";
                if (arg.Type.ManagedType.IsGenericType && arg.Type.ManagedType.GetGenericTypeDefinition() == typeof(CArray<>) && arg.TransferOwnership == "none") {
                    var marshal = $"{typeof(MemoryMarshal)}.{nameof(MemoryMarshal.GetReference)}";
                    expressions.Add(ParseExpression($"{arg.ManagedName}_ = ref {marshal}({arg.ManagedName})"));
                }
                else {
                    var takeData = arg.TransferOwnership == "full";
                    var getter = takeData ? "TakeData()" : "GetPinnableReference()";
                    getter = arg.IsNullable && takeData ?
                        $"{arg.ManagedName}?.{getter} ?? System.IntPtr.Zero" :
                        $"{arg.ManagedName}.{getter}";
                    expressions.Add(ParseExpression($"{arg.ManagedName}_ = ref {getter}"));
                }

                if (array.LengthIndex >= 0) {
                    var lengthArg = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    var lengthIdentifier = lengthArg.ManagedName;
                    var lengthType = lengthArg.Type.UnmanagedType.ToString();
                    var lengthGetter = (arg.IsNullable && !isSpanLike) ? $"{arg.ManagedName}?.Length ?? 0" : $"{arg.ManagedName}.Length";
                    expressions.Add(ParseExpression($"{lengthIdentifier}_ = ({lengthType}){lengthGetter}"));
                }
            }
            else if (type.IsOpaque() || type.IsGInterface()) {
                if (type == typeof(Utf8) && arg.TransferOwnership == "none") {
                    expressions.Add(ParseExpression($"{arg.ManagedName}_ = {arg.ManagedName}.Handle"));
                }
                else {
                    var getter = arg.TransferOwnership == "none" ? "Handle" : "Take()";
                    expressions.Add(arg.IsNullable ?
                        ParseExpression($"{arg.ManagedName}_ = {arg.ManagedName}?.{getter} ?? System.IntPtr.Zero") :
                        ParseExpression($"{arg.ManagedName}_ = {arg.ManagedName}.{getter}"));
                }
            }
            else if (type.IsValueType) {
                // value types are used directly
                var unmanagedType = arg.Type.UnmanagedType;
                if (unmanagedType.IsPointer) {
                    var ref_ = declareVariable ? "ref " : "";
                    expressions.Add(ParseExpression($"{arg.ManagedName}_ = {ref_}{arg.ManagedName}"));
                }
                else {
                    expressions.Add(ParseExpression($"{arg.ManagedName}_ = ({unmanagedType}){arg.ManagedName}"));
                }
            }
            else if (type.IsDelegate()) {
                var destroyArg = arg.Callable.Parameters.RegularParameters.ElementAtOrDefault(arg.DestroyIndex);
                var destroy = destroyArg?.ManagedName ?? (arg.Scope == "call" ? "destroy" : "");
                var userDataArg = arg.Callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var scope = $"{typeof(CallbackScope)}.{arg.Scope.ToPascalCase()}";
                var marshal = $"{type}Marshal";
                var getter = $"{marshal}.ToPointer({arg.ManagedName}, {scope})";
                var identifiers = $"{arg.ManagedName}_, {destroy}_, {userData}_";
                expressions.Add(ParseExpression($"({identifiers}) = {getter}"));
            }
            else {
                expressions.Add(ParseExpression($"throw new System.NotImplementedException(\"{nameof(GetMarshalManagedToUnmanagedStatements)}\")"));
                declareVariable = false;
            }

            if (declareVariable) {
                static string ref_(ExpressionSyntax e)
                {
                    return e.ToString().Contains(" = ref ") ? "ref readonly " : "";
                }
                expressions = expressions.Select(x => ParseExpression($"{ref_(x)}var {x}")).ToList();
            }

            return expressions.Select(x => ExpressionStatement(x)).ToArray();
        }

        public static StatementSyntax[] GetMarshalUnmanagedToManagedStatements(this GIArg arg, bool declareVariable = true)
        {
            var expressions = new System.Collections.Generic.List<ExpressionSyntax>();
            var type = arg.Type.ManagedType;

            if (arg.Type is Gir.Array array && array.GirName == null) {
                var lengthArg = "-1";
                if (array.LengthIndex >= 0) {
                    var lengthParameter = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    lengthArg = $"(int){lengthParameter.ManagedName}_";
                }
                var isSpan = false;
                if (arg.TransferOwnership == "none") {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CArray<>)) {
                        type = typeof(ReadOnlySpan<>).MakeGenericType(type.GetGenericArguments());
                        isSpan = true;
                    }
                    else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(CPtrArray<>)) {
                        type = typeof(UnownedCPtrArray<>).MakeGenericType(type.GetGenericArguments());
                    }
                }
                var ownership = arg.GetOwnershipTransfer();
                var getter = $"new {type.ToSyntax()}((System.IntPtr){arg.ManagedName}_, {lengthArg}, {ownership})";
                if (isSpan) {
                    var create = $"{typeof(MemoryMarshal)}.{nameof(MemoryMarshal.CreateReadOnlySpan)}";
                    var elementType = array.TypeParameters.Single().ManagedType.ToSyntax();
                    var cast = $"{typeof(Unsafe)}.{nameof(Unsafe.AsRef)}";
                    getter = $"{create}<{elementType}>(ref {cast}({arg.ManagedName}_), {lengthArg})";
                }
                expressions.Add(ParseExpression($"{arg.ManagedName} = {getter}"));
            }
            else if (type.IsValueType) {
                // value types are used directly
                if (arg is ReturnValue && arg.Type.IsPointer && type != typeof(IntPtr)) {
                    expressions.Add(ParseExpression($"{arg.ManagedName} = ({arg.ManagedName}_ == null) ? default({arg.Type.ManagedType}?) : ({arg.Type.ManagedType})(*{arg.ManagedName}_)"));
                }
                else {
                    expressions.Add(ParseExpression($"{arg.ManagedName} = ({arg.Type.ManagedType}){arg.ManagedName}_"));
                }
            }
            else if (type.IsOpaque()) {
                // there are some special cases where there are Unowned versions of opaques
                if (type == typeof(Utf8) && arg.TransferOwnership == "none") {
                    var utf8Type = arg.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                    expressions.Add(ParseExpression($"{arg.ManagedName} = new {utf8Type}({arg.ManagedName}_, -1)"));
                }
                else if (type == typeof(Strv) && arg.Type is Gir.Array v && v.LengthIndex >= 0) {
                    // If there is a length provided for Strv, capture it
                    var lengthParameter = arg.Callable.Parameters.RegularParameters.ElementAt(v.LengthIndex);
                    var lengthArg = $"(int){lengthParameter.ManagedName}_";
                    var ownership = arg.GetOwnershipTransfer();
                    // TODO: handle nullable case
                    expressions.Add(ParseExpression($"{arg.ManagedName} = new {typeof(Strv)}({arg.ManagedName}_, {lengthArg}, {ownership})"));
                }
                else {
                    var getInstance = $"{typeof(Opaque)}.{nameof(Opaque.GetInstance)}";
                    var ownership = arg.GetOwnershipTransfer();
                    var notNullable = arg.IsNullable ? "" : "!";
                    expressions.Add(ParseExpression($"{arg.ManagedName} = {getInstance}<{type.ToSyntax()}>({arg.ManagedName}_, {ownership}){notNullable}"));
                }
            }
            else if (type.IsInterface) {
                var getInstance = $"{typeof(Object)}.{nameof(Object.GetInstance)}";
                var ownership = arg.GetOwnershipTransfer();
                var nullable = arg.IsNullable ? "?" : "";
                var notNullable = arg.IsNullable ? "" : "!";
                expressions.Add(ParseExpression($"{arg.ManagedName} = ({type.ToSyntax()}{nullable}){getInstance}({arg.ManagedName}_, {ownership}){notNullable}"));
            }
            else if (type.IsDelegate()) {
                var userDataArg = arg.Callable.Parameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var marshal = $"{arg.Type.ManagedType}Marshal";
                var getter = $"{marshal}.FromPointer({arg.ManagedName}_, {userData}_)";
                if (arg.IsNullable) {
                    var callbackType = arg.Type.ManagedType.ToSyntax();
                    var defaultValue = $"default({callbackType})";
                    getter = $"{arg.ManagedName}_ == null ? {defaultValue} : {getter}";
                }
                expressions.Add(ParseExpression($"{arg.ManagedName} = {getter}"));
            }
            else {
                expressions.Add(ParseExpression($"throw new System.NotImplementedException(\"{nameof(GetMarshalUnmanagedToManagedStatements)}\")"));
                declareVariable = false;
            }

            if (declareVariable) {
                static string ref_(ExpressionSyntax e)
                {
                    return e.ToString().StartsWith("ref ") ? "ref " : "";
                }
                expressions = expressions.Select(x => ParseExpression($"{ref_(x)}var {x}")).ToList();
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
    }
}
