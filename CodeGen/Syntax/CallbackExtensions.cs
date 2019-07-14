using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class CallbackExtensions
    {
        /// <summary>
        /// Gets the C# delegate declaration for the managed version of a GIR callback
        /// </summary>
        public static DelegateDeclarationSyntax GetManagedDeclaration(this Callback callback)
        {
            var returnType = callback.ReturnValue.GetManagedTypeName();
            var identifier = callback.ManagedName;
            var parameterList = callback.ManagedParameters.GetParameterList();
            if (callback.ParentNode is Field) {
                // The first parameter is the instance parameter for a virtual
                // method, so skip it
                parameterList = ParameterList(SeparatedList(parameterList.Parameters.Skip(1)));
            }
            return DelegateDeclaration(returnType, identifier)
                .AddModifiers(Token(PublicKeyword))
                .WithAttributeLists(callback.GetCommonAttributeLists())
                .WithParameterList(parameterList)
                .WithLeadingTrivia(callback.Doc.GetDocCommentTrivia());
        }

        /// <summary>
        /// Gets the C# delegate declaration for the unmanaged version of a GIR callback
        /// </summary>
        public static DelegateDeclarationSyntax GetUnmanagedDeclaration(this Callback callback)
        {
            var returnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
            var identifier = "Unmanaged" + callback.ManagedName;

            var girTrivia = TriviaList(callback.ReturnValue.GetGirXmlTrivia(),
                EndOfLine("\n"), callback.ReturnValue.GetAnnotationTrivia());

            // get parameters, injecting some comments along the way
            var parameterList = ParameterList(SeparatedList(callback.Parameters
                .Select(x => x.GetParameter()
                    .WithLeadingTrivia(TriviaList(x.GetGirXmlTrivia(), EndOfLine("\n"),
                        x.GetAnnotationTrivia(), EndOfLine("\n"))))));

            var attrName = ParseName(typeof(UnmanagedFunctionPointerAttribute).FullName);
            var attrArg = ParseExpression($"{typeof(CallingConvention)}.{nameof(CallingConvention.Cdecl)}");
            var attr = Attribute(attrName)
                .AddArgumentListArguments(AttributeArgument(attrArg));

            return DelegateDeclaration(returnType, identifier)
                .AddModifiers(Token(PublicKeyword).WithLeadingTrivia(girTrivia),
                    Token(UnsafeKeyword))
                .WithAttributeLists(callback.GetCommonAttributeLists())
                .AddAttributeLists(AttributeList().AddAttributes(attr))
                .WithParameterList(parameterList)
                .WithLeadingTrivia(callback.Doc.GetDocCommentTrivia(false));
        }

        static IEnumerable<StatementSyntax> GetVirtualMethodStatements(this Callback callback)
        {
            var tryStatement = TryStatement();

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != "out")) {
                var marshalStatements = arg.GetMarshalUnmanagedToManagedStatements();
                tryStatement = tryStatement.AddBlockStatements(marshalStatements);
            }

            var invokeMethod = $"do{callback.ManagedName}";
            var getDelegate = string.Format("var {0} = ({1})methodInfo.CreateDelegate(typeof({1}), {2})",
                invokeMethod,
                callback.ManagedName,
                callback.ManagedParameters.First().ManagedName);
            var getDelegateStatement = ExpressionStatement(ParseExpression(getDelegate));
            tryStatement = tryStatement.AddBlockStatements(getDelegateStatement);

            var returnsValue = !callback.ReturnValue.IsSkip && callback.ReturnValue.Type.UnmanagedType != typeof(void);

            var invokeStatement = callback.GetInvocationStatement(invokeMethod, !returnsValue);
            tryStatement = tryStatement.AddBlockStatements(invokeStatement);

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != "in")) {
                var statements = arg.GetMarshalManagedToUnmanagedStatements(false);
                tryStatement = tryStatement.AddBlockStatements(statements);
            }

            if (returnsValue) {
                var statements = callback.ReturnValue.GetMarshalManagedToUnmanagedStatements();
                tryStatement = tryStatement.AddBlockStatements(statements);

                var returnStatement = ReturnStatement(ParseExpression("ret_"));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }
            else if (callback.ReturnValue.Type.UnmanagedType == typeof(Runtime.Boolean)) {
                var returnStatement = ReturnStatement(ParseExpression("true"));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }

            // if the method has an error parameter, we can propagate any
            // GErrorException thrown by the managed callback

            if (callback.ThrowsGErrorException) {
                var gErrorException = typeof(GISharp.Runtime.GErrorException).FullName;
                var propagateError = ParseStatement(string.Format("{0}.{1}(ref {2}_, ex.{3});\n",
                    typeof(GISharp.Runtime.GMarshal),
                    nameof(GISharp.Runtime.GMarshal.PropagateError),
                    callback.Parameters.ErrorParameter.ManagedName,
                    nameof(GISharp.Runtime.GErrorException.Error)));

                var gErrorExceptionStatements = List<StatementSyntax>().Add(propagateError);

                tryStatement = tryStatement.AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(ParseTypeName(gErrorException), ParseToken("ex")))
                    .WithBlock(Block(gErrorExceptionStatements)));
            }

            // otherwise, we just have to log an unhandled exception since we
            // are returning to unmanaged code, which doesn't know about
            // managed exceptions

            var exception = typeof(Exception).FullName;
            var logUnhandledException = ParseStatement(string.Format("{0}.{1}(ex);\n",
                typeof(Log),
                nameof(Log.LogUnhandledException)));

            var exceptionStatements = List<StatementSyntax>().Add(logUnhandledException);

            tryStatement = tryStatement.AddCatches(CatchClause()
                .WithDeclaration(CatchDeclaration(ParseTypeName(exception), ParseToken("ex")))
                .WithBlock(Block(exceptionStatements)));

            yield return tryStatement;

            foreach (var p in callback.Parameters.Where(x => x.Direction == "out")) {
                var unmanagedType = p.Type.UnmanagedType;
                if (unmanagedType.IsPointer) {
                    unmanagedType = unmanagedType.GetElementType();
                }
                var parameterType = unmanagedType.ToSyntax();
                var expression = ParseExpression($"{p.ManagedName}_ = default({parameterType})");
                yield return ExpressionStatement(expression);
            }

            if (callback.ReturnValue.Type.UnmanagedType != typeof(void)) {
                var returnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
                yield return ReturnStatement(DefaultExpression(returnType));
            }
        }

        static QualifiedNameSyntax GetQualifiedName(this Callback callback, bool unmanged = false)
        {
            var @namespace = ParseName($"GISharp.Lib.{callback.Namespace.Name}");
            var prefix = unmanged ? "Unmanaged" : "";
            var name = IdentifierName(prefix + callback.ManagedName);
            return QualifiedName(@namespace, name);
        }

        /// <summary>
        /// Gets the statements for implementing an unmanaged callback function
        /// </summary>
        static IEnumerable<StatementSyntax> GetCallbackStatements(this Callback callback)
        {
            var catchType = ParseTypeName(typeof(Exception).FullName);
            var catchStatement = string.Format("{0}.{1}(ex);\n",
                typeof(Log),
                nameof(Log.LogUnhandledException));
            yield return TryStatement()
                .WithBlock(Block(callback.GetCallbackTryStatements()))
                .AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(catchType, ParseToken("ex")))
                    .WithBlock(Block(ParseStatement(catchStatement))));

            foreach (var p in callback.Parameters.Where(x => x.Direction == "out")) {
                var unmanagedType = p.Type.UnmanagedType;
                if (unmanagedType.IsPointer) {
                    unmanagedType = unmanagedType.GetElementType();
                }
                var parameterType = unmanagedType.ToSyntax();
                var expression = ParseExpression($"{p.ManagedName}_ = default({parameterType})");
                yield return ExpressionStatement(expression);
            }

            if (callback.ReturnValue.Type.UnmanagedType != typeof(void)) {
                var returnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
                var expression = ParseExpression($"default({returnType})");
                yield return ReturnStatement(expression);
            }
        }

        static IEnumerable<StatementSyntax> GetCallbackTryStatements(this Callback callback)
        {
            foreach (var arg in callback.ManagedParameters) {
                foreach (var s in arg.GetMarshalUnmanagedToManagedStatements()) {
                    yield return s;
                }
            }

            var dataParam = callback.Parameters.RegularParameters.SingleOrDefault(x => x.ClosureIndex >= 0);
            var dataParamName = dataParam.ManagedName;

            var ghHandleType = typeof(GCHandle).FullName;
            yield return ParseStatement($"var gcHandle = ({ghHandleType}){dataParamName}_;\n");
            yield return ParseStatement($"var {dataParamName} = (UserData)gcHandle.Target;\n");

            var skipReturnValue = callback.ThrowsGErrorException && callback.ReturnValue.Type.UnmanagedType == typeof(Runtime.Boolean);

            yield return callback.GetInvocationStatement($"{dataParamName}.ManagedDelegate", skipReturnValue);

            yield return ParseStatement(string.Format(@"if ({0}.Scope == {1}.{2}) {{
                    Destroy({0}_);
                }}
                ", dataParamName,
                typeof(CallbackScope),
                nameof(CallbackScope.Async)));

            if (skipReturnValue) {
                // callbacks that throw and return bool should always return true
                yield return ParseStatement("return true;\n");
            }
            else if (callback.ReturnValue.Type.UnmanagedType != typeof(void)) {
                foreach (var s in callback.ReturnValue.GetMarshalManagedToUnmanagedStatements()) {
                    yield return s;
                }
                yield return ReturnStatement(ParseExpression("ret_")); ;
            }
        }

        static StatementSyntax GetInvocationStatement(this Callback callback, string methodName = null, bool skipReturnValue = false)
        {
            var invokeExpression = InvocationExpression(IdentifierName(methodName ?? callback.ManagedName));
            var argList = callback.ManagedParameters.GetArgumentList();
            if (callback.ParentNode is Field) {
                // The first parameter is the instance parameter for a virtual
                // method, so skip it
                argList = ArgumentList(SeparatedList(argList.Arguments.Skip(1)));
            }
            invokeExpression = invokeExpression.WithArgumentList(argList);

            StatementSyntax statement = ExpressionStatement(invokeExpression);
            if (!skipReturnValue && callback.ReturnValue.Type.ManagedType != typeof(void)) {
                statement = LocalDeclarationStatement(
                    VariableDeclaration(ParseTypeName("var"))
                    .AddVariables(VariableDeclarator(ParseToken("ret"))
                        .WithInitializer(EqualsValueClause(invokeExpression))));
            }
            return statement;
        }

        /// <summary>
        /// Gets the C# class declaration for the factory class of a GIR callback
        /// </summary>
        public static ClassDeclarationSyntax GetDelegateMarshalDeclaration(this Callback callback)
        {
            var identifier = callback.ManagedName + "Marshal";
            var syntax = ClassDeclaration(identifier)
               .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
               .WithLeadingTrivia(callback.GetDelegateMarshalDocumentationCommentTrivia());
            return syntax;
        }

        /// <summary>
        /// Gets the C# delegate factory class members for a GIR callback of a
        /// virtual method
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetVirtualMethodDelegateMarshalMembers(this Callback callback)
        {
            return List<MemberDeclarationSyntax>()
                .Add(callback.GetVirtualMethodDelegateMarshalToPointerMethod());
        }

        static MethodDeclarationSyntax GetVirtualMethodDelegateMarshalToPointerMethod(this Callback callback)
        {
            var type = ParseTypeName("Unmanaged" + callback.ManagedName);
            var methodInfoParam = Parameter(ParseToken("methodInfo"))
                .WithType(ParseTypeName(typeof(System.Reflection.MethodInfo).FullName));
            return MethodDeclaration(type, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword), Token(UnsafeKeyword))
                .AddParameterListParameters(methodInfoParam)
                .WithBody(Block(callback.GetUnmanagedDelegateCreateStatements()));
        }

        static IEnumerable<StatementSyntax> GetUnmanagedDelegateCreateStatements(this Callback callback)
        {
            var returnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
            var identifier = "unmanaged" + callback.ManagedName.ToPascalCase();
            yield return LocalFunctionStatement(returnType, identifier)
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetVirtualMethodStatements()));

            yield return ReturnStatement(ParseExpression(identifier));
        }

        /// <summary>
        /// Gets the C# delegate factory class members for a GIR callback
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetCallbackDelegateMarshalClassMembers(this Callback callback)
        {
            var list = List<MemberDeclarationSyntax>();

            // emit nested private Data class

            var managedDelegateFieldToken = ParseToken("ManagedDelegate");
            var managedDelegateParamToken = ParseToken(managedDelegateFieldToken.Text.ToCamelCase());
            var managedDelegateFieldType = callback.GetQualifiedName();
            var managedDelegateField = FieldDeclaration(VariableDeclaration(managedDelegateFieldType)
                    .AddVariables(VariableDeclarator(managedDelegateFieldToken)))
                .AddModifiers(Token(PublicKeyword), Token(ReadOnlyKeyword));

            var scopeFieldToken = ParseToken("Scope");
            var scopeParamToken = ParseToken(scopeFieldToken.Text.ToCamelCase());
            var scopeFieldType = typeof(CallbackScope).ToSyntax();
            var scopeField = FieldDeclaration(VariableDeclaration(scopeFieldType)
                    .AddVariables(VariableDeclarator(scopeFieldToken)))
                .AddModifiers(Token(PublicKeyword), Token(ReadOnlyKeyword));

            var constructor = ConstructorDeclaration("UserData")
                .AddModifiers(Token(PublicKeyword))
                .AddParameterListParameters(
                    Parameter(managedDelegateParamToken).WithType(managedDelegateField.Declaration.Type),
                    Parameter(scopeParamToken).WithType(scopeField.Declaration.Type)
                )
                .WithBody(Block())
                .AddBodyStatements(
                    ExpressionStatement(AssignmentExpression(SimpleAssignmentExpression,
                        IdentifierName(managedDelegateFieldToken),
                        IdentifierName(managedDelegateParamToken))),
                    ExpressionStatement(AssignmentExpression(SimpleAssignmentExpression,
                        IdentifierName(scopeFieldToken),
                        IdentifierName(scopeParamToken)))
                );

            var dataClass = ClassDeclaration("UserData")
                .AddMembers(managedDelegateField, scopeField, constructor);
            list = list.Add(dataClass);

            // emit FromPointer() method for unmanged>managed

            var fromPointerMethodParams = $"({typeof(IntPtr)} callback_, {typeof(IntPtr)} userData_)";
            var fromPointerReturnType = managedDelegateFieldType;
            var fromPointerMethod = MethodDeclaration(fromPointerReturnType, "FromPointer")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(fromPointerMethodParams))
                .WithBody(Block(callback.GetMarshalFromPointerMethodStatements()));
            list = list.Add(fromPointerMethod);

            // emit ToPointer() method for managed>unmanaged

            var toPointerMethodParams = $"({managedDelegateFieldType}? callback, {scopeFieldType} scope)";
            var toPointerReturnType = ParseTypeName(string.Format("({0} callback_, {0} notify_, {0} userData_)", typeof(IntPtr)));
            var create2Method = MethodDeclaration(toPointerReturnType, "ToPointer")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword), Token(UnsafeKeyword))
                .WithParameterList(ParseParameterList(toPointerMethodParams))
                .WithBody(Block(callback.GetMarshalToPointerMethodStatements()))
                .WithLeadingTrivia(callback.GetMarshalToPointerMethodDocumentationCommentTrivia());
            list = list.Add(create2Method);

            // emit unmanaged callback method

            var callbackReturnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
            var callbackMethod = MethodDeclaration(callbackReturnType, "UnmanagedCallback")
                .AddModifiers(Token(StaticKeyword), Token(UnsafeKeyword))
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetCallbackStatements()));
            list = list.Add(callbackMethod);

            var callbackDelegateVariable = VariableDeclarator("UnmanagedCallbackDelegate")
                    .WithInitializer(EqualsValueClause(IdentifierName(callbackMethod.Identifier)));
            var callbackDelegateField = FieldDeclaration(VariableDeclaration(callback.GetQualifiedName(true))
                .AddVariables(callbackDelegateVariable))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));
            list = list.Add(callbackDelegateField);

            var callbackMarshalToPointerExpression = ParseExpression(string.Format(
                "{0}.{1}({2})",
                typeof(Marshal),
                nameof(Marshal.GetFunctionPointerForDelegate),
                callbackDelegateVariable.Identifier
            ));
            var callbackPointer = FieldDeclaration(VariableDeclaration(ParseTypeName(typeof(IntPtr).FullName))
                .AddVariables(VariableDeclarator("callback_")
                    .WithInitializer(EqualsValueClause(callbackMarshalToPointerExpression))))
                    .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));
            list = list.Add(callbackPointer);

            // emit destroy notify method

            var destroyReturnType = ParseTypeName("void");
            var destroyParamList = ParseParameterList($"({typeof(IntPtr)} userData_)");

            var destroyTryStatement = ParseStatement(string.Format(@"try {{
                var gcHandle = ({0})userData_;
                gcHandle.Free();
            }}
            catch ({1} ex) {{
                {2}.{3}(ex);
            }}
            ", typeof(GCHandle),
                typeof(Exception),
                typeof(Log),
                nameof(Log.LogUnhandledException)));

            var destroyMethod = MethodDeclaration(destroyReturnType, "Destroy")
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(destroyParamList)
                .WithBody(Block(destroyTryStatement));

            list = list.Add(destroyMethod);

            var destroyDelegateVariable = VariableDeclarator("UnmanagedDestroyDelegate")
                    .WithInitializer(EqualsValueClause(IdentifierName(destroyMethod.Identifier)));
            var destroyDelegateField = FieldDeclaration(VariableDeclaration(ParseTypeName(typeof(UnmanagedDestroyNotify).FullName))
                .AddVariables(destroyDelegateVariable))
                .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));
            list = list.Add(destroyDelegateField);

            var destroyMarshalToPointerExpression = ParseExpression(string.Format(
                "{0}.{1}({2})",
                typeof(Marshal),
                nameof(Marshal.GetFunctionPointerForDelegate),
                destroyDelegateVariable.Identifier
            ));
            var destroyPointer = FieldDeclaration(VariableDeclaration(ParseTypeName(typeof(IntPtr).FullName))
                .AddVariables(VariableDeclarator("destroy_")
                    .WithInitializer(EqualsValueClause(destroyMarshalToPointerExpression))))
                    .AddModifiers(Token(StaticKeyword), Token(ReadOnlyKeyword));
            list = list.Add(destroyPointer);

            return list;
        }

        static IEnumerable<StatementSyntax> GetMarshalFromPointerMethodStatements(this Callback callback)
        {
            var marshalToPointerExpression = ParseExpression(string.Format(
                "{0}.{1}<{2}>(callback_)",
                typeof(Marshal),
                nameof(Marshal.GetDelegateForFunctionPointer),
                callback.GetQualifiedName(true)
            ));
            yield return LocalDeclarationStatement(VariableDeclaration(IdentifierName("var"))
                .AddVariables(VariableDeclarator("unmanagedCallback")
                    .WithInitializer(EqualsValueClause(marshalToPointerExpression))));

            var userDataParam = callback.Parameters.Single(x => x.ClosureIndex >= 0);
            if (userDataParam.ManagedName != "userData") {
                yield return ParseStatement($"var {userDataParam.ManagedName}_ = userData_;\n");
            }

            var paramList = callback.ManagedParameters.GetParameterList();

            // remove default values
            paramList = paramList.WithParameters(SeparatedList(paramList.Parameters
                .Select(x => x.WithDefault(default))));

            var returnType = callback.ReturnValue.GetManagedTypeName();
            yield return LocalFunctionStatement(returnType, "managedCallback")
                .AddModifiers(Token(UnsafeKeyword))
                .WithParameterList(paramList)
                .WithBody(Block(callback.GetInvokeStatements("unmanagedCallback")
                    .Select(x => x.WithTrailingTrivia(EndOfLine("\n")))));

            yield return ReturnStatement(ParseExpression("managedCallback"));
        }

        static IEnumerable<StatementSyntax> GetMarshalToPointerMethodStatements(this Callback callback)
        {
            yield return IfStatement(ParseExpression("callback == null"),
                Block(ReturnStatement(ParseExpression("default"))));

            yield return ParseStatement("var userData = new UserData(callback, scope);\n");

            var gcHandleStatement = string.Format("var userData_ = ({0}){1}.{2}(userData);\n",
                typeof(IntPtr),
                typeof(GCHandle),
                nameof(GCHandle.Alloc));
            yield return ParseStatement(gcHandleStatement);

            const string returnExpression = "(callback_, destroy_, userData_)";
            yield return ReturnStatement(ParseExpression(returnExpression));
        }

        static SyntaxTriviaList GetDelegateMarshalDocumentationCommentTrivia(this Callback callback)
        {
            const string template = @"/// <summary>
/// Class for marshalling <see cref=""{0}""/> methods.
/// </summary>
";
            var comments = string.Format(template, callback.ManagedName);
            return ParseLeadingTrivia(comments);
        }

        static SyntaxTriviaList GetMarshalToPointerMethodDocumentationCommentTrivia(this Callback callback)
        {
            const string template = @"/// <summary>
/// Wraps a <see cref=""{0}""/> in an anonymous method that can
/// be passed to unmanaged code.
/// </summary>
/// <param name=""method"">The managed method to wrap.</param>
/// <param name=""scope"">The lifetime scope of the callback.</param>
/// <returns>
/// A tuple containing a pointer to the unmanaged callback, a pointer to the
/// unmanaged notify function and a pointer to the user data.
/// </returns>
/// <remarks>
/// This function is used to marshal managed callbacks to unmanged
/// code. If the scope is <see cref=""{1}.{2}""/>
/// then it is the caller's responsibility to invoke the notify function
/// when the callback is no longer needed. If the scope is
/// <see cref=""{1}.{3}""/>, then the notify
/// function should be ignored.
/// </remarks>
";
            var comments = string.Format(template,
                callback.ManagedName,
                typeof(CallbackScope),
                nameof(CallbackScope.Call),
                nameof(CallbackScope.Async));

            return ParseLeadingTrivia(comments);
        }
    }
}
