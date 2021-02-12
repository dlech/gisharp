// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

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
        /// Gets a partial static method declaration for checking managed arguments.
        /// </summary>
        internal static MethodDeclarationSyntax GetCheckArgsMethodDeclaration(this GICallable callable)
        {
            var declaration = MethodDeclaration(IdentifierName("void"), $"Check{callable.ManagedName}Args")
                .AddModifiers(Token(StaticKeyword), Token(PartialKeyword))
                .AddParameterListParameters(callable.ManagedParameters.Where(x => x.Direction != "out")
                    .Select(x => x.GetParameter()).ToArray()
                ).WithSemicolonToken(Token(SemicolonToken));
            return declaration;
        }

        /// <summary>
        /// Gets a partial static method declaration for checking managed return value.
        /// </summary>
        internal static MethodDeclarationSyntax GetCheckReturnMethodDeclaration(this GICallable callable)
        {
            var declaration = MethodDeclaration(IdentifierName("void"), $"Check{callable.ManagedName}Return")
                .AddModifiers(Token(PartialKeyword))
                .WithSemicolonToken(Token(SemicolonToken));

            if (callable is Constructor) {
                declaration = declaration.AddParameterListParameters(
                    Parameter(Identifier("ret_")).WithType(ParseTypeName("System.IntPtr"))
                );
            }
            else if (callable.IsAsync) {
                throw new NotSupportedException("doesn't make sense to check return of async methods");
            }
            else if (
                callable.ReturnValue.Type.UnmanagedType != typeof(void) &&
                !callable.ReturnValue.IsSkip
            ) {
                var type = callable.ReturnValue.Type.ManagedType.ToSyntax();
                if (callable.ReturnValue.IsNullable) {
                    type = NullableType(type);
                }
                declaration = declaration.AddParameterListParameters(
                    Parameter(Identifier("ret")).WithType(type)
                );
            }

            return declaration;
        }

        /// <summary>
        /// Gets statements for invoking a callable
        /// </summary>
        /// <remarks>
        /// This generates the required code to invoke an unmanaged callable
        /// from managed code, including marshsalling all of the arguments.
        /// </remarks>
        /// <param name="callable">The GIR callable node</param>
        /// <param name="invokeMethod">An expression describing the pinvoke method</param>
        internal static BlockSyntax GetInvokeBlock(this GICallable callable, string invokeMethod, bool checkArgs = true)
        {
            var block = Block();
            var fixedStatements = new System.Collections.Generic.List<FixedStatementSyntax>();

            // might need to do some extra arg checks first

            // call check arg method
            if (checkArgs) {
                var expression = ParseExpression($"Check{callable.ManagedName}Args");
                var invocation = InvocationExpression(expression);
                foreach (var arg in callable.ManagedParameters.Where(x => x.Direction != "out")) {
                    var item = Argument(ParseExpression(arg.ManagedName));
                    invocation = invocation.AddArgumentListArguments(item);
                }
                block = block.AddStatements(ExpressionStatement(invocation));
            }

            // marshal managed parameters to unmanaged parameters

            var managedParameters = callable.ManagedParameters.Cast<GIArg>();

            if (callable is Method || callable is VirtualMethod) {
                var instanceParameter = callable.Parameters.InstanceParameter;
                if (callable is Method method && method.IsExtensionMethod) {
                    // add the instance parameter to the list to be marshalled
                    managedParameters = managedParameters.Prepend(instanceParameter);
                }
                else {
                    var identifier = instanceParameter.ManagedName;
                    var managedType = instanceParameter.Type.ManagedType;
                    var unmanagedType = instanceParameter.Type.UnmanagedType.ToSyntax();
                    if (managedType.IsValueType) {
                        if (instanceParameter.Type.UnmanagedType.IsPointer && managedType != typeof(IntPtr)) {
                            // struct passed by reference
                            var statement = ExpressionStatement(ParseExpression($"var {identifier}_ = this_"));
                            fixedStatements.Add(FixedStatement(
                                VariableDeclaration(unmanagedType)
                                    .AddVariables(VariableDeclarator("this_")
                                        .WithInitializer(EqualsValueClause(
                                            ParseExpression("&this")
                                        ))),
                                Block()
                            ));
                            block = block.AddStatements(statement.WithTrailingTrivia(EndOfLine("\n")));
                        }
                        else {
                            // struct passed by value
                            var expression = ParseExpression($"var {identifier}_ = this");
                            block = block.AddStatements(ExpressionStatement(expression));
                        }
                    }
                    else {
                        // opaque type passed by reference
                        var expression = ParseExpression($"var {identifier}_ = ({unmanagedType})UnsafeHandle");
                        block = block.AddStatements(ExpressionStatement(expression));
                    }
                }
            }

            foreach (var arg in callable.ManagedParameters.Where(x => x.Direction != "out" || x.IsCallerAllocates)) {
                block = block.AddStatements(arg.GetMarshalManagedToUnmanagedStatements(out var fixedStatement));
                if (fixedStatement != null) {
                    fixedStatements.Add(fixedStatement);
                }
            }

            foreach (var arg in callable.Parameters.Where(x => x.Direction == "out" && !x.IsCallerAllocates)) {
                block = block.AddStatements(arg.GetOutVariableDeclaration());
            }

            if (callable.IsAsync) {
                var returnType = callable.ReturnValue.Type.ManagedType;
                var completionType = returnType.IsGenericType
                    ? typeof(TaskCompletionSource<>).MakeGenericType(returnType.GenericTypeArguments)
                    : typeof(TaskCompletionSource<Runtime.Void>);

                var completionVarExpression = $"var completionSource = new {completionType.ToSyntax()}()";
                block = block.AddStatements(ExpressionStatement(ParseExpression(completionVarExpression)));

                var callbackArg = callable.Parameters.Single(x => x.Type.CType == "GAsyncReadyCallback");
                var callbackDelegateName = callable.ManagedName.ToCamelCase() + "Callback_";
                var callbackExpression = $"var {callbackArg.ManagedName}_ = {callbackDelegateName}";
                block = block.AddStatements(ExpressionStatement(ParseExpression(callbackExpression)));

                var userDataArg = callable.Parameters.RegularParameters.ElementAt(callbackArg.ClosureIndex);
                var userDataExpression = $"var {userDataArg.ManagedName}_ = ({typeof(IntPtr)}){typeof(GCHandle)}.Alloc(completionSource)";
                block = block.AddStatements(ExpressionStatement(ParseExpression(userDataExpression)));
            }

            if (callable.ThrowsGErrorException) {
                // error parameters are always ref, so we need to initialize it with a value
                var errorArg = callable.Parameters.ErrorParameter.ManagedName;
                var expression = ParseExpression($"var {errorArg}_ = default({typeof(Error.UnmanagedStruct).ToSyntax()}*)");
                block = block.AddStatements(ExpressionStatement(expression));
            }

            // emit the PInvoke statement to call into unmanaged code

            var invocationExpression = ParseExpression(invokeMethod);

            invocationExpression = InvocationExpression(invocationExpression)
                .WithArgumentList(callable.Parameters.GetArgumentList("_"));

            if (callable.ReturnValue.Type.UnmanagedType != typeof(void) && !callable.ReturnValue.IsSkip) {
                invocationExpression = ParseExpression($"var ret_ = {invocationExpression}");
            }

            block = block.AddStatements(ExpressionStatement(invocationExpression));

            // If callback scope for any parameter was "call", then we need to
            // free the unmanaged delegate

            foreach (var arg in callable.Parameters.Where(x => x.Scope == "call")) {
                var marshalExpression = ParseExpression(string.Format(
                    "var destroy = {0}.{1}<{2}>(destroy_)",
                    typeof(Marshal),
                    nameof(Marshal.GetDelegateForFunctionPointer),
                    typeof(UnmanagedDestroyNotify)
                ));
                block = block.AddStatements(ExpressionStatement(marshalExpression));

                var userDataArg = callable.Parameters.RegularParameters.ElementAt(arg.ClosureIndex);
                var nullCheck = arg.IsNullable ? "?.Invoke" : "!.Invoke";
                var invokeExpression = ParseExpression($"destroy{nullCheck}({userDataArg.ManagedName}_)");
                block = block.AddStatements(ExpressionStatement(invokeExpression));
            }

            // Check for GError and throw GErrorException

            if (callable.ThrowsGErrorException) {
                var errorArg = callable.Parameters.ErrorParameter.ManagedName;
                var condition = ParseExpression($"{errorArg}_ != null");
                var getter = $"{typeof(Opaque)}.{nameof(Opaque.GetInstance)}<{typeof(Error)}>";
                var ownership = $"{typeof(Transfer)}.{nameof(Transfer.Full)}";
                var marshalExpression = ParseExpression($"var {errorArg} = {getter}((System.IntPtr){errorArg}_, {ownership})");
                var marshalStatement = ExpressionStatement(marshalExpression);
                var exception = typeof(GErrorException);
                var exceptionExpression = ParseExpression($"new {exception}({errorArg})");
                var throwStatement = ThrowStatement(exceptionExpression);
                block = block.AddStatements(IfStatement(condition, Block(marshalStatement, throwStatement)));
            }

            // marshal out args back to managed args

            foreach (var p in callable.ManagedParameters.RegularParameters.Where(x => x.Direction != "in" && !x.IsCallerAllocates)) {
                block = block.AddStatements(p.GetMarshalUnmanagedToManagedStatements(false));
            }

            // emit the return statement

            if (callable is Constructor constructor) {
                if (callable.IsCheckReturn) {
                    var expression = ParseExpression($"Check{callable.ManagedName}Return(ret_)");
                    block = block.AddStatements(ExpressionStatement(expression));
                }
                // constructor static methods return the unmanaged value directly
                // for use in the actual C# constructor
                block = block.AddStatements(ReturnStatement(ParseExpression("ret_")));
            }
            else if (callable.IsAsync) {
                block = block.AddStatements(ReturnStatement(ParseExpression("completionSource.Task")));
            }
            else if (callable.ReturnValue.Type.UnmanagedType != typeof(void) && !callable.ReturnValue.IsSkip) {
                foreach (var s in callable.ReturnValue.GetMarshalUnmanagedToManagedStatements()) {
                    block = block.AddStatements(s);
                }
                if (callable.IsCheckReturn) {
                    var expression = ParseExpression($"Check{callable.ManagedName}Return(ret)");
                    block = block.AddStatements(ExpressionStatement(expression));
                }
                var @ref = callable.ReturnValue.IsRefReturn() ? "ref " : "";
                block = block.AddStatements(ReturnStatement(ParseExpression($"{@ref}ret")));
            }

            foreach (var s in fixedStatements) {
                block = Block(s.WithStatement(block));
            }

            return block;
        }

        /// <summary>
        /// Gets XML doc comment for thowing a GErrorException or default trivia
        /// if the callable does not throw.
        /// </summary>
        public static SyntaxTriviaList GetGErrorExceptionDocCommentTrivia(this GICallable callable)
        {
            if (!callable.ThrowsGErrorException) {
                return default;
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
            var parameterList = string.Format("({0} sourceObject_, {1} {2}_, System.IntPtr userData_)",
                typeof(Lib.GObject.Object.UnmanagedStruct).MakePointerType().ToSyntax(),
                "GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*",
                resultParameter.ManagedName);
            return MethodDeclaration(ParseTypeName("void"), callable.ManagedName)
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(ParseParameterList(parameterList));
        }

        /// <summary>
        /// Gets a method statements for an async finish method implementation
        /// </summary>
        internal static IEnumerable<StatementSyntax> GetFinishMethodStatements(this GICallable callable, GICallable asyncCallable, string invokeMethod)
        {
            var tryStatement = TryStatement();

            if (callable.Parameters.InstanceParameter is not null) {
                var instanceName = callable.Parameters.InstanceParameter.ManagedName;
                var instanceType = callable.Parameters.InstanceParameter.Type.UnmanagedType.ToSyntax();
                tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(
                    $"var {instanceName}_ = ({instanceType})sourceObject_"
                )));
            }

            var gcHandleExpression = $"var userData = ({typeof(GCHandle)})userData_";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(gcHandleExpression)));

            var returnType = asyncCallable.ReturnValue.Type.ManagedType;
            var completionType = returnType.IsGenericType
                    ? typeof(TaskCompletionSource<>).MakeGenericType(returnType.GenericTypeArguments)
                    : typeof(TaskCompletionSource<Runtime.Void>);
            var targetExpression = $"var completionSource = ({completionType.ToSyntax()})userData.Target!";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(targetExpression)));

            var gcHandleFreeExpression = "userData.Free()";
            tryStatement = tryStatement.AddBlockStatements(ExpressionStatement(ParseExpression(gcHandleFreeExpression)));

            foreach (var arg in callable.Parameters.RegularParameters.Where(x => x.Direction == "out" && !x.IsCallerAllocates)) {
                tryStatement = tryStatement.AddBlockStatements(arg.GetOutVariableDeclaration());
            }

            if (callable.ThrowsGErrorException) {
                var errorParameter = callable.Parameters.ErrorParameter.ManagedName;
                var errorExpression = ParseExpression($"var {errorParameter}_ = default({typeof(Error.UnmanagedStruct).ToSyntax()}*)");
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
                var ifErrorStatement = string.Format(@"if ({0}_ != null) {{
                        var {0} = {1}.{2}<{3}>((System.IntPtr){0}_, {4}.{5});
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

            var returnValue = returnValues.Any() ? $"({string.Join(", ", returnValues)})" : $"{typeof(Runtime.Void)}.{nameof(Runtime.Void.Default)}";
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

        /// <summary>
        /// Gets a statement that invokes a managed callback.
        /// </summary>
        static StatementSyntax GetInvokeManagedCallbackStatement(this GICallable callable, string methodName = null, bool skipReturnValue = false)
        {
            var invokeExpression = InvocationExpression(IdentifierName(methodName ?? callable.ManagedName));
            var argList = callable.ManagedParameters.GetArgumentList();
            if (callable.ParentNode is Field) {
                // The first parameter is the instance parameter for a virtual
                // method, so skip it
                argList = ArgumentList(SeparatedList(argList.Arguments.Skip(1)));
            }
            invokeExpression = invokeExpression.WithArgumentList(argList);

            StatementSyntax statement = ExpressionStatement(invokeExpression);
            if (!skipReturnValue && callable.ReturnValue.Type.ManagedType != typeof(void)) {
                statement = LocalDeclarationStatement(
                    VariableDeclaration(ParseTypeName("var"))
                    .AddVariables(VariableDeclarator(ParseToken("ret"))
                        .WithInitializer(EqualsValueClause(invokeExpression))));
            }
            return statement;
        }

        static NameSyntax GetCallbackDelegateType(this GICallable callable, bool unmanged = false)
        {
            if (callable is Signal) {
                return ParseName($"{callable.ManagedName}Handler");
            }

            var @namespace = ParseName($"GISharp.Lib.{callable.Namespace.Name}");
            var prefix = unmanged ? "Unmanaged" : "";
            var name = IdentifierName(prefix + callable.ManagedName);
            return QualifiedName(@namespace, name);
        }

        /// <summary>
        /// Gets the statements for implementing an unmanaged callback function
        /// </summary>
        static IEnumerable<StatementSyntax> GetCallbackStatements(this GICallable callable)
        {
            var catchType = ParseTypeName(typeof(Exception).FullName);
            var catchStatement = ExpressionStatement(ParseExpression(string.Format("{0}.{1}(ex)",
                typeof(Log),
                nameof(Log.LogUnhandledException))));
            yield return TryStatement()
                .WithBlock(callable.GetCallbackTryBlock())
                .AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(catchType, ParseToken("ex")))
                    .WithBlock(Block(catchStatement)));

            if (callable.ReturnValue.Type.UnmanagedType != typeof(void)) {
                var returnType = callable.ReturnValue.Type.UnmanagedType.ToSyntax();
                var expression = ParseExpression($"default({returnType})");
                yield return ReturnStatement(expression);
            }
        }

        static BlockSyntax GetCallbackTryBlock(this GICallable callable)
        {
            var block = Block();
            var fixedStatements = new System.Collections.Generic.List<FixedStatementSyntax>();

            foreach (var arg in callable.ManagedParameters) {
                foreach (var s in arg.GetMarshalUnmanagedToManagedStatements()) {
                    block = block.AddStatements(s);
                }
            }

            var dataParam = callable.Parameters.RegularParameters.Single(x => x.ClosureIndex >= 0);
            var dataParamName = dataParam.ManagedName;

            var ghHandleType = typeof(GCHandle).FullName;
            block = block.AddStatements(
                ExpressionStatement(ParseExpression($"var gcHandle = ({ghHandleType}){dataParamName}_")),
                ExpressionStatement(ParseExpression($"var {dataParamName} = (UserData)gcHandle.Target!")));

            var skipReturnValue = callable.ThrowsGErrorException && callable.ReturnValue.Type.UnmanagedType == typeof(Runtime.Boolean);

            block = block.AddStatements(
                callable.GetInvokeManagedCallbackStatement($"{dataParamName}.Callback", skipReturnValue),
                ParseStatement(string.Format(@"if ({0}.Scope == {1}.{2}) {{
                        gcHandle.Free();
                    }}
                    ", dataParamName,
                    typeof(CallbackScope),
                    nameof(CallbackScope.Async))));

            if (skipReturnValue) {
                // callbacks that throw and return bool should always return true
                block = block.AddStatements(ReturnStatement(ParseExpression("GISharp.Runtime.Boolean.True")));
            }
            else if (callable.ReturnValue.Type.UnmanagedType != typeof(void)) {
                block = block.AddStatements(callable.ReturnValue.GetMarshalManagedToUnmanagedStatements(out var fixedStatement));
                if (fixedStatement != null) {
                    fixedStatements.Add(fixedStatement);
                }
                block = block.AddStatements(ReturnStatement(ParseExpression("ret_")));
            }

            foreach (var s in fixedStatements) {
                block = Block(s.WithStatement(block));
            }

            return block;
        }

        static IEnumerable<StatementSyntax> GetMarshalFromPointerMethodStatements(this GICallable callable)
        {
            var marshalToPointerExpression = ParseExpression(
                $"({callable.GetUnmanagedDelegateType()})callback_"
            );
            yield return LocalDeclarationStatement(VariableDeclaration(IdentifierName("var"))
                .AddVariables(VariableDeclarator("unmanagedCallback")
                    .WithInitializer(EqualsValueClause(marshalToPointerExpression))));

            // some callbacks have their own name for the user data parameter
            var userDataParam = callable.Parameters.SingleOrDefault(x => x.ClosureIndex >= 0);
            if (userDataParam != null && userDataParam.ManagedName != "userData") {
                yield return ExpressionStatement(ParseExpression($"var {userDataParam.ManagedName}_ = userData_"));
            }

            var paramList = callable.ManagedParameters.GetParameterList();

            // remove default values
            paramList = paramList.WithParameters(SeparatedList(paramList.Parameters
                .Select(x => x.WithDefault(default))));

            var returnType = callable.ReturnValue.GetManagedTypeName();
            yield return LocalFunctionStatement(returnType, "managedCallback")
                .WithParameterList(paramList)
                .WithBody(callable.GetInvokeBlock("unmanagedCallback", checkArgs: false));

            yield return ReturnStatement(ParseExpression("managedCallback"));
        }

        static TypeSyntax GetUnmanagedDelegateType(this GICallable callable)
        {
            // scrape the types from GetParameterList() so that we are assured
            // to get the same types and modifiers
            var typeArgs = callable.Parameters.GetParameterList().Parameters
                .Select(x => $"{x.Modifiers.ToFullString()} {x.Type.ToFullString()}".TrimStart())
                .Append(callable.ReturnValue.Type.UnmanagedType.ToSyntax().ToFullString());
            return ParseTypeName($"delegate* unmanaged[Cdecl]<{string.Join(", ", typeArgs)}>");
        }

        static IEnumerable<StatementSyntax> GetMarshalToPointerMethodStatements(this GICallable callable)
        {
            yield return IfStatement(ParseExpression("callback == null"),
                Block(ReturnStatement(ParseExpression("default"))));

            yield return ExpressionStatement(ParseExpression(
                $"var userData = new UserData(({callable.GetCallbackDelegateType()})callback, scope)"
            ));

            yield return ExpressionStatement(ParseExpression(
                $"var callback_ = (System.IntPtr)({callable.GetUnmanagedDelegateType().ToFullString()})&ManagedCallback"
            ));

            yield return ExpressionStatement(ParseExpression(
                $"var destroy_ = {typeof(GMarshal)}.{nameof(GMarshal.DestroyGCHandleFunctionPointer)}"
            ));

            yield return ExpressionStatement(ParseExpression(
                "var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData)"
            ));

            yield return ReturnStatement(ParseExpression("(callback_, destroy_, userData_)"));
        }

        /// <summary>
        /// Gets the C# delegate factory class members for a GIR callback
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetCallbackDelegateMarshalClassMembers(this GICallable callable)
        {
            var list = List<MemberDeclarationSyntax>();

            // emit nested private UserData record type

            var callbackType = callable.GetCallbackDelegateType();
            var scopeType = typeof(CallbackScope).ToSyntax();
            var userDataRecordDeclaration = RecordDeclaration(Token(RecordKeyword), "UserData")
                .AddParameterListParameters(
                    Parameter(Identifier("Callback")).WithType(callbackType),
                    Parameter(Identifier("Scope")).WithType(scopeType)
                )
                .WithSemicolonToken(Token(SemicolonToken));
            list = list.Add(userDataRecordDeclaration);

            // emit FromPointer() method for unmanged>managed

            var fromPointerMethodParams = $"({typeof(IntPtr)} callback_, {typeof(IntPtr)} userData_)";
            var fromPointerReturnType = callbackType;
            var fromPointerMethod = MethodDeclaration(fromPointerReturnType, "FromPointer")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(fromPointerMethodParams))
                .WithBody(Block(callable.GetMarshalFromPointerMethodStatements()));
            list = list.Add(fromPointerMethod);

            // emit ToUnmanagedFunctionPointer() method for managed>unmanaged

            var toPointerMethodParams = $"(System.Delegate callback, {scopeType} scope)";
            var toPointerReturnType = ParseTypeName(string.Format("({0} callback_, {0} notify_, {0} userData_)", typeof(IntPtr)));
            var toPointerMethod = MethodDeclaration(toPointerReturnType, "ToUnmanagedFunctionPointer")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(toPointerMethodParams))
                .WithBody(Block(callable.GetMarshalToPointerMethodStatements()));
            list = list.Add(toPointerMethod);

            // emit unmanaged callback method

            var unmanagedCallersOnlyAttribute = Attribute(ParseName($"{typeof(UnmanagedCallersOnlyAttribute)}"))
                .AddArgumentListArguments(AttributeArgument(ParseExpression(
                    "CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) }"
                )));
            var callbackReturnType = callable.ReturnValue.Type.UnmanagedType.ToSyntax();
            var callbackMethod = MethodDeclaration(callbackReturnType, "ManagedCallback")
                .AddModifiers(Token(StaticKeyword))
                .AddAttributeLists(AttributeList().AddAttributes(unmanagedCallersOnlyAttribute))
                .WithParameterList(callable.Parameters.GetParameterList())
                .WithBody(Block(callable.GetCallbackStatements()));
            list = list.Add(callbackMethod);

            return list;
        }

        /// <summary>
        /// Gets the C# class declaration for the factory class of a GIR callback.
        /// </summary>
        public static ClassDeclarationSyntax GetDelegateMarshalDeclaration(this GICallable callable)
        {
            var identifier = callable.ManagedName;
            if (callable is Signal) {
                identifier += "Handler";
            }
            identifier += "Marshal";
            var syntax = ClassDeclaration(identifier)
               .AddModifiers(Token(PrivateKeyword), Token(StaticKeyword), Token(UnsafeKeyword));
            return syntax;
        }
    }
}
