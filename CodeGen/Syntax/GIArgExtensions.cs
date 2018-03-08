using System;
using System.Collections.Generic;
using System.IO;
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

namespace GISharp.CodeGen.Syntax
{
    public static class GIArgExtensions
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace gs = GISharp.CodeGen.Globals.GISharpNamespace;

        public static ParameterSyntax GetParameter(this GIArg arg, string suffix = "")
        {
            var managed = arg.ParentNode is ManagedParameters;
            var type = managed ? arg.GirType.ManagedType : arg.GirType.UnmanagedType;

            if (!managed && arg.Direction != GIDirection.In && arg.GirType.ManagedType.IsValueType) {
                // if an unmanaged out or ref parameter is a ValueType, then we
                // can pass it directly
                type = arg.GirType.ManagedType;
            }

            var identifier = ParseToken(arg.ManagedName + suffix);

            IEnumerable<SyntaxToken> getModifiers()
            {
                if (arg is ReturnValue) {
                    yield break;
                }
                if (arg.Direction == GIDirection.InOut) {
                    yield return Token(RefKeyword);
                } else if (arg.Direction == GIDirection.Out) {
                    yield return Token(OutKeyword);
                } else if (arg.IsParams) {
                    yield return Token(ParamsKeyword);
                } else if (arg.ParentNode is ManagedParameters && arg is InstanceParameter) {
                    yield return Token(ThisKeyword);
                }
            }

            var syntax = Parameter(identifier)
                // .WithAttributeLists(AttributeLists)
                .WithModifiers(TokenList(getModifiers()))
                .WithType(type.ToSyntax());
            if (arg.ParentNode is ManagedParameters && arg.DefaultValue != null) {
                var @default = EqualsValueClause(ParseExpression(arg.DefaultValue));
                syntax = syntax.WithDefault(@default);
            }
            return syntax;
        }

        public static ArgumentSyntax GetArgument(this GIArg arg, string suffix = "")
        {
            var expression = arg.ManagedName + suffix;

            if (arg.Direction == GIDirection.InOut) {
                expression = "ref " + expression;
            }
            else if (arg.Direction == GIDirection.Out) {
                expression = "out var " + expression;
            }

            return Argument(ParseExpression(expression));
        }

        public static StatementSyntax GetMarshalManagedToUnmanagedStatement(this GIArg arg, bool declareVariable = true)
        {
            ExpressionSyntax expression;
            var type = arg.GirType.ManagedType;

            if (type.IsValueType) {
                // value types are used directly
                expression = ParseExpression($"{arg.ManagedName}_ = {arg.ManagedName}");
            }
            else if (type.IsOpaque() || type.IsGInterface()) {
                var nullValue = arg.IsNullable ? "System.IntPtr.Zero" :
                    $"throw new System.ArgumentNullException(nameof({arg.ManagedName}))";
                var getter = arg.Ownership == Transfer.None ? "Handle" : "Take()";
                expression = ParseExpression($"{arg.ManagedName}_ = {arg.ManagedName}?.{getter} ?? {nullValue}");
            }
            else if (arg.GirType is Gir.Array array) {
                var takeData = arg.Ownership == Transfer.Full;
                var getter = takeData ? "TakeData()" : "Data";
                var nullValue = arg.IsNullable ? "System.IntPtr.Zero" :
                    $"throw new System.ArgumentNullException(nameof({arg.ManagedName}))";
                getter = $"{arg.ManagedName}?.{getter} ?? {nullValue}";
                var lengthIdentifier = "";
                var lengthType = "int";
                if (array.LengthIndex >= 0) {
                    var lengthArg = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    lengthIdentifier = lengthArg.ManagedName;
                    lengthType = lengthArg.GirType.ManagedType.FullName;
                }
                if (!takeData) {
                    var lengthGetter = $"{arg.ManagedName}?.Length ?? 0";
                    getter = $"({getter}, {lengthGetter})";
                }
                expression = ParseExpression($"({arg.ManagedName}_, {lengthIdentifier}_) = ((System.IntPtr, {lengthType}))({getter})");
            }
            else if (type.IsDelegate()) {
                var destroyArg = arg.Callable.Parameters.RegularParameters.ElementAtOrDefault(arg.DestroyIndex);
                var destroy = destroyArg?.ManagedName ?? (arg.Scope == CallbackScope.Call ? "destroy" : "");
                var userDataArg = arg.Callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var scope = $"{typeof(CallbackScope).FullName}.{arg.Scope}";
                var factory = $"{type.FullName}Factory";
                var getter = $"{factory}.Create({arg.ManagedName}, {scope})";
                var identifiers = $"{arg.ManagedName}_, {destroy}_, {userData}_";
                expression = ParseExpression($"({identifiers}) = {getter}");
            }
            else {
                expression = ParseExpression($"throw new System.NotImplementedException(\"GetMarshalManagedToUnmanagedStatement\")");
                declareVariable = false;
            }
            if (declareVariable) {
                expression = ParseExpression("var " + expression);
            }
            return ExpressionStatement(expression);
        }

        public static StatementSyntax GetMarshalUnmanagedToManagedStatement(this GIArg arg, bool declareVariable = true)
        {
            ExpressionSyntax expression;
            var type = arg.GirType.ManagedType;

            if (type.IsValueType) {
                // value types are used directly
                expression = ParseExpression($"{arg.ManagedName} = {arg.ManagedName}_");
            }
            else if (type.IsOpaque()) {
                var getInstance = $"{typeof(Opaque).FullName}.{nameof(Opaque.GetInstance)}";
                var ownership = $"{typeof(Transfer).FullName}.{arg.Ownership}";
                expression = ParseExpression($"{arg.ManagedName} = {getInstance}<{type.ToSyntax()}>({arg.ManagedName}_, {ownership})");
            }
            else if (arg.GirType is Gir.Array array) {
                var elementType = array.ElementType.ManagedType;
                var getter = elementType.IsValueType ? typeof(CArray).FullName : typeof(CPtrArray).FullName;
                var lengthIdentifier = "";
                var lengthType = "int";
                if (array.LengthIndex >= 0) {
                    var lengthArg = arg.Callable.Parameters.RegularParameters.ElementAt(array.LengthIndex);
                    lengthIdentifier = lengthArg.ManagedName;
                    lengthType = lengthArg.GirType.ManagedType.FullName;
                }
                var ownership = $"{typeof(Transfer).FullName}.{arg.Ownership}";
                getter = $"{getter}.GetInstance<{elementType.ToSyntax()}>({arg.ManagedName}_, (int){lengthIdentifier}_, {ownership})";
                expression = ParseExpression($"{arg.ManagedName} = {getter}");
            }
            else if (type.IsInterface) {
                var getInstance = $"{typeof(GObject.Object).FullName}.{nameof(GObject.Object.GetInstance)}";
                var ownership = $"{typeof(Transfer).FullName}.{arg.Ownership}";
                expression = ParseExpression($"{arg.ManagedName} = ({type.ToSyntax()}){getInstance}({arg.ManagedName}_, {ownership})");
            }
            else if (type.IsDelegate()) {
                var userDataArg = arg.Callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var userData = userDataArg.ManagedName;
                var factory = $"{arg.GirType.ManagedType.FullName}Factory";
                var getter = $"{factory}.Create({arg.ManagedName}_, {userData}_)";
                expression = ParseExpression($"{arg.ManagedName} = {getter}");
            }
            else {
                expression = ParseExpression($"throw new System.NotImplementedException(\"GetMarshalUnmanagedToManagedStatement\")");
                declareVariable = false;
            }
            if (declareVariable) {
                expression = ParseExpression("var " + expression);
            }
            return ExpressionStatement(expression);
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
            return Comment(builder.ToString ());
        }
    }
}
