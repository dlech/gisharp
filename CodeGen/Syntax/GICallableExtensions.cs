using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class GICallableExtensions
    {
        /// <summary>
        /// Gets statements for invoking a callable
        /// </summary>
        /// <remarks>
        /// This generates the required code to invoke an unmanaged callable
        /// from managed code, including marshsalling all of the arguments.
        /// </remarks>
        /// <param name="callable">The GIR callable node</param>
        /// <param name="invokeMethod">An expression describing the pinvoke method</param>
        internal static IEnumerable<StatementSyntax> GetInvokeStatements(this GICallable callable, string invokeMethod)
        {
            // might need to do some extra arg checks first

            if (callable.HasCustomArgCheck) {
                var expression = ParseExpression($"Assert{callable.ManagedName}Args");
                var invocation = InvocationExpression(expression);
                foreach (var arg in callable.ManagedParameters.Where(x => x.Direction != "out")) {
                    var item = Argument(ParseExpression(arg.ManagedName));
                    invocation = invocation.AddArgumentListArguments(item);
                }
                yield return ExpressionStatement(invocation);
            }

            // marshal managed parameters to unmanaged parameters

            var managedParameters = callable.ManagedParameters.Cast<GIArg>();

            if (callable is Method || callable is VirtualMethod) {
                if (callable is Method method && method.IsExtensionMethod) {
                    // add the instance parameter to the list to be marshalled
                    managedParameters = managedParameters.Prepend(callable.Parameters.InstanceParameter);
                }
                else {
                    // marshalling is trivial
                    var identifier = callable.Parameters.InstanceParameter.ManagedName;
                    var handleOrThis = callable.Parameters.InstanceParameter.Type.ManagedType.IsValueType
                        ? "this" : "Handle";
                    var expression = ParseExpression($"var {identifier}_ = {handleOrThis}");
                    yield return ExpressionStatement(expression);
                }
            }

            foreach (var arg in callable.ManagedParameters.Where(x => x.Direction != "out")) {
                foreach (var s in arg.GetMarshalManagedToUnmanagedStatements()) {
                    yield return s;
                }
            }

            if (callable.IsAsync) {
                var returnType = callable.ReturnValue.Type.ManagedType;
                var completionType = returnType.IsGenericType
                    ? typeof(TaskCompletionSource<>).MakeGenericType(returnType.GenericTypeArguments)
                    : typeof(TaskCompletionSource<Unit>);

                var completionVarExpression = $"var completionSource = new {completionType.ToSyntax()}()";
                yield return ExpressionStatement(ParseExpression(completionVarExpression));

                var callbackArg = callable.Parameters.Single(x => x.Type.CType == "GAsyncReadyCallback");
                var callbackDelegateName = callable.ManagedName.ToCamelCase() + "Callback_";
                var callbackExpression = $"var {callbackArg.ManagedName}_ = {callbackDelegateName}";
                yield return ExpressionStatement(ParseExpression(callbackExpression));

                var userDataArg = callable.Parameters.RegularParameters.ElementAt(callbackArg.ClosureIndex);
                var userDataExpression = $"var {userDataArg.ManagedName}_ = ({typeof(IntPtr)}){typeof(GCHandle)}.Alloc(completionSource)";
                yield return ExpressionStatement(ParseExpression(userDataExpression));
            }

            if (callable.ThrowsGErrorException) {
                // error parameters are always ref, so we need to initialize it with a value
                var expression = ParseExpression($"var error_ = System.IntPtr.Zero");
                yield return ExpressionStatement(expression);
            }

            // emit the PInvoke statement to call into unmanaged code

            var invocationExpression = ParseExpression(invokeMethod);

            invocationExpression = InvocationExpression(invocationExpression)
                .WithArgumentList(callable.Parameters.GetArgumentList("_"));

            if (callable.ReturnValue.Type.UnmanagedType != typeof(void) && !callable.ReturnValue.IsSkip) {
                invocationExpression = ParseExpression($"var ret_ = {invocationExpression}");
            }

            yield return ExpressionStatement(invocationExpression);

            // If callback scope for any parameter was "call", then we need to
            // free the unmanaged delegate

            foreach (var arg in callable.Parameters.Where(x => x.Scope == "call")) {
                var marshalExpression = ParseExpression(string.Format(
                    "var destroy = {0}.{1}<{2}>(destroy_)",
                    typeof(Marshal),
                    nameof(Marshal.GetDelegateForFunctionPointer),
                    typeof(UnmanagedDestroyNotify)
                ));
                yield return ExpressionStatement(marshalExpression);

                var userDataArg = callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var nullCheck = arg.IsNullable ? "?.Invoke" : "!.Invoke";
                var invokeExpression = ParseExpression($"destroy{nullCheck}({userDataArg.ManagedName}_)");
                yield return ExpressionStatement(invokeExpression);
            }

            // Check for GError and throw GErrorException

            if (callable.ThrowsGErrorException) {
                var errorArg = callable.Parameters.ErrorParameter.ManagedName + "_";
                var condition = ParseExpression($"{errorArg} != System.IntPtr.Zero");
                var getter = $"{typeof(Opaque)}.{nameof(Opaque.GetInstance)}<{typeof(Error)}>";
                var ownership = $"{typeof(Transfer)}.{nameof(Transfer.Full)}";
                var marshalExpression = ParseExpression($"var error = {getter}({errorArg}, {ownership})");
                var marshalStatement = ExpressionStatement(marshalExpression);
                var exception = typeof(GErrorException);
                var exceptionExpression = ParseExpression($"new {exception}(error)");
                var throwStatement = ThrowStatement(exceptionExpression);
                yield return IfStatement(condition, Block(marshalStatement, throwStatement));
            }

            // marshal out args back to managed args

            foreach (var p in callable.ManagedParameters.RegularParameters.Where(x => x.Direction != "in")) {
                foreach (var s in p.GetMarshalUnmanagedToManagedStatements(false)) {
                    yield return s;
                }
            }

            // emit the return statement

            if (callable is Constructor) {
                // constructor static methods return the unmanaged value directly
                // for use in the actual C# constructor
                yield return ReturnStatement(ParseExpression("ret_"));
            }
            else if (callable.IsAsync) {
                yield return ReturnStatement(ParseExpression("completionSource.Task"));
            }
            else if (callable.ReturnValue.Type.UnmanagedType != typeof(void) && !callable.ReturnValue.IsSkip) {
                foreach (var s in callable.ReturnValue.GetMarshalUnmanagedToManagedStatements()) {
                    yield return s;
                }
                yield return ReturnStatement(ParseExpression("ret"));
            }
        }

        internal static IEnumerable<StatementSyntax> GetStringToUtf8InvokeStatements(this GICallable callable)
        {
            // get the arg list for the invocation expression now so that we can replace
            // the argument names at the same time we are creating the new variables
            var argList = callable.ManagedParameters.GetArgumentList(declareOutVars: false);

            foreach (var p in callable.ManagedParameters.Where(x => x.IsUnownedUtf8())) {
                var n = p.IsNullable ? $"{p.ManagedName} == null ? null : " : "";
                var utf8Identifier = ParseToken($"{p.ManagedName}Utf8");
                var newUtf8 = $"new {typeof(Utf8)}";
                yield return ParseStatement($"using var {utf8Identifier} = {n}{newUtf8}({p.ManagedName});\n");

                var identifier = argList.DescendantNodes().Single(x => x is IdentifierNameSyntax i && i.Identifier.Text == p.ManagedName);
                var type = p.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                var cast = ParseExpression($"({type}){utf8Identifier}");
                argList = argList.ReplaceNode(identifier, cast);
            }

            var expression = InvocationExpression(IdentifierName(callable.ManagedName))
                .WithArgumentList(argList);

            bool isVoid = callable.ReturnValue.Type.UnmanagedType == typeof(void);
            if (callable is Constructor || callable.IsAsync || !callable.ReturnValue.IsSkip && !isVoid) {
                yield return ReturnStatement(expression);
            }
            else {
                yield return ExpressionStatement(expression);
            }
        }

        /// <summary>
        /// Gets XML doc comment for thowing a GErrorException or default trivia
        /// if the callable does not throw.
        /// </summary>
        public static SyntaxTriviaList GetGErrorExceptionDocCommentTrivia(this GICallable callable)
        {
            if (!callable.ThrowsGErrorException) {
                return default(SyntaxTriviaList);
            }
            var builder = new StringBuilder();
            builder.AppendFormat("/// <exception name=\"{0}\">",
                typeof(GErrorException).FullName);
            builder.AppendLine();
            builder.AppendLine("/// On error");
            builder.AppendLine("/// </exception>");

            return ParseLeadingTrivia(builder.ToString());
        }

        /// <summary>
        /// Gets a method declaration for an async finish method implementation
        /// </summary>
        public static MethodDeclarationSyntax GetFinishMethodDeclaration(this GICallable callable)
        {
            var instanceParameter = callable.Parameters.InstanceParameter;
            var resultParameter = callable.Parameters.RegularParameters
                .Single(x => x.Type.CType == "GAsyncResult*");
            var parameterList = string.Format("({0} {1}_, {0} {2}_, {0} userData_)",
                typeof(IntPtr),
                instanceParameter?.ManagedName ?? "sourceObject",
                resultParameter.ManagedName);
            return MethodDeclaration(ParseTypeName("void"), callable.ManagedName)
                .AddModifiers(Token(StaticKeyword), Token(UnsafeKeyword))
                .WithParameterList(ParseParameterList(parameterList));
        }

        /// <summary>
        /// Gets a method statements for an async finish method implementation
        /// </summary>
        internal static IEnumerable<StatementSyntax> GetFinishMethodStatements(this GICallable callable, GICallable asyncCallable, string invokeMethod)
        {
            var tryStatement = TryStatement();

            var gcHandleExpression = $"var userData = ({typeof(GCHandle)})userData_";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(gcHandleExpression)));

            var returnType = asyncCallable.ReturnValue.Type.ManagedType;
            var completionType = returnType.IsGenericType
                    ? typeof(TaskCompletionSource<>).MakeGenericType(returnType.GenericTypeArguments)
                    : typeof(TaskCompletionSource<Unit>);
            var targetExpression = $"var completionSource = ({completionType.ToSyntax()})userData.Target";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(targetExpression)));

            var gcHandleFreeExpression = "userData.Free()";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(gcHandleFreeExpression)));

            if (callable.ThrowsGErrorException) {
                var errorParameter = callable.Parameters.ErrorParameter.ManagedName;
                var errorExpression = ParseExpression($"var {errorParameter}_ = System.IntPtr.Zero");
                tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(errorExpression));
            }

            ExpressionSyntax invocationExpression = InvocationExpression(ParseExpression(invokeMethod))
                .WithArgumentList(callable.Parameters.GetArgumentList("_"));
            if (!callable.ReturnValue.IsSkip && callable.ReturnValue.Type.GirName != "none") {
                invocationExpression = ParseExpression($"var ret_ = {invocationExpression}");
            }
            var invocationStatement = ExpressionStatement(invocationExpression);
            tryStatement = tryStatement.AddBlockStatements(invocationStatement);

            if (callable.ThrowsGErrorException) {
                var errorParameter = callable.Parameters.ErrorParameter.ManagedName;
                var ifErrorStatement = string.Format(@"if ({0}_ != System.IntPtr.Zero) {{
                        var {0} = {1}.{2}<{3}>({0}_, {4}.{5});
                        completionSource.SetException(new {6}({0}));
                        return;
                    }}
                    ",
                    errorParameter,
                    typeof(Opaque),
                    nameof(Opaque.GetInstance),
                    typeof(Error),
                    typeof(Transfer),
                    nameof(Transfer.Full),
                    typeof(GErrorException));
                tryStatement = tryStatement.AddBlockStatements(ParseStatement(ifErrorStatement));
            }

            var returnValues = new System.Collections.Generic.List<string>();

            foreach (var arg in callable.ManagedParameters.RegularParameters.Where(x => x.Direction != "in")) {
                var statements = arg.GetMarshalUnmanagedToManagedStatements();
                tryStatement = tryStatement.AddBlockStatements(statements);
                returnValues.Add(arg.ManagedName);
            }

            if (!callable.ReturnValue.IsSkip && callable.ReturnValue.Type.GirName != "none") {
                var statements = callable.ReturnValue.GetMarshalUnmanagedToManagedStatements();
                tryStatement = tryStatement.AddBlockStatements(statements);
                returnValues.Insert(0, "ret");
            }

            var returnValue = returnValues.Any() ? $"({string.Join(", ", returnValues)})" : $"{typeof(Unit)}.{nameof(Unit.Default)}";
            var returnExpression = ParseExpression($"completionSource.SetResult({returnValue})");
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(returnExpression));

            var catchExpression = $"{typeof(Log)}.{nameof(Log.LogUnhandledException)}(ex)";
            tryStatement = tryStatement.AddCatches(CatchClause()
                .WithDeclaration(CatchDeclaration(ParseTypeName(typeof(Exception).ToString()),
                    ParseToken("ex")))
                .WithBlock(Block(ExpressionStatement(ParseExpression(catchExpression)))));

            yield return tryStatement;
        }

        /// <summary>
        /// Gets a field declaration for a delegate of an async finish method implementation
        /// </summary>
        internal static IEnumerable<FieldDeclarationSyntax> GetFinishDelegateFields(this GICallable callable, string identifier)
        {
            var varType = ParseTypeName("GISharp.Lib.Gio.UnmanagedAsyncReadyCallback");
            var initializerExpression = ParseExpression(callable.ManagedName);
            yield return FieldDeclaration(VariableDeclaration(varType)
                    .AddVariables(VariableDeclarator(identifier + "Delegate")
                        .WithInitializer(EqualsValueClause(initializerExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));

            var marshalExpression = ParseExpression(string.Format(
                "{0}.{1}<{2}>({3})",
                typeof(Marshal),
                nameof(Marshal.GetFunctionPointerForDelegate),
                varType,
                identifier + "Delegate"
            ));
            yield return FieldDeclaration(VariableDeclaration(ParseTypeName(typeof(IntPtr).FullName))
                .AddVariables(VariableDeclarator(identifier + "_")
                    .WithInitializer(EqualsValueClause(marshalExpression))))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));
        }
    }
}
