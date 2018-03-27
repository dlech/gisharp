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
            return DelegateDeclaration(returnType, identifier)
                .AddModifiers(Token(PublicKeyword))
                .WithAttributeLists(callback.GetCommonAttributeLists())
                .WithParameterList(callback.ManagedParameters.GetParameterList())
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

            var instanceParam = callback.Parameters.InstanceParameter;

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != "out")
                .Prepend(instanceParam))
            {
                var marshalStatement = arg.GetMarshalUnmanagedToManagedStatement();
                tryStatement = tryStatement.AddBlockStatements(marshalStatement);
            }

            var invokeMethod = $"do{callback.ManagedName}";
            var getDelegate = string.Format("var {0} = ({1})methodInfo.CreateDelegate(typeof({1}), {2})",
                invokeMethod,
                callback.ManagedName,
                instanceParam.ManagedName);
            var getDelegateStatement = ExpressionStatement(ParseExpression(getDelegate));
            tryStatement = tryStatement.AddBlockStatements(getDelegateStatement);

            var returnsValue = !callback.ReturnValue.IsSkip && callback.ReturnValue.Type.UnmanagedType != typeof(void);

            var invokeStatement = callback.GetInvocationStatement(invokeMethod, !returnsValue);
            tryStatement = tryStatement.AddBlockStatements(invokeStatement);

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != "in")) {
                var statement = arg.GetMarshalManagedToUnmanagedStatement(false);
                tryStatement = tryStatement.AddBlockStatements(statement);
            }

            if (returnsValue) {
                var statement = callback.ReturnValue.GetMarshalManagedToUnmanagedStatement();
                tryStatement = tryStatement.AddBlockStatements(statement);

                var returnStatement = ReturnStatement(ParseExpression("ret_"));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }
            else if (callback.ReturnValue.Type.UnmanagedType == typeof(bool)) {
                var returnStatement = ReturnStatement(ParseExpression("true"));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }

            // if the method has an error parameter, we can propagate any
            // GErrorException thrown by the managed callback

            if (callback.ThrowsGErrorException) {
                var gErrorException = typeof(GISharp.Runtime.GErrorException).FullName;
                var propagateError = ParseStatement(string.Format("{0}.{1}({2}_, ex.{3});\n",
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

            foreach (var arg in callback.Parameters.Where(x => x.Direction == "out")) {
                var type = arg.Type.UnmanagedType.ToSyntax();
                if (arg.Type.ManagedType.IsValueType) {
                    type = arg.Type.ManagedType.ToSyntax();
                }
                var expression = ParseExpression($"{arg.ManagedName}_ = default({type})");
                exceptionStatements = exceptionStatements.Add(ExpressionStatement(expression));
            }

            tryStatement = tryStatement.AddCatches(CatchClause()
                .WithDeclaration(CatchDeclaration(ParseTypeName(exception), ParseToken("ex")))
                .WithBlock(Block(exceptionStatements)));

            yield return tryStatement;

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
            
            if (callback.ReturnValue.Type.UnmanagedType != typeof(void)) {
                var returnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
                var expression = ParseExpression($"default({returnType})");
                yield return ReturnStatement(expression);
            }
        }

        static IEnumerable<StatementSyntax> GetCallbackTryStatements(this Callback callback)
        {
            foreach(var arg in callback.ManagedParameters) {
                yield return arg.GetMarshalUnmanagedToManagedStatement();
            }

            var dataParam = callback.Parameters.RegularParameters.SingleOrDefault(x => x.ClosureIndex >= 0);
            var dataParamName = dataParam.ManagedName;

            var ghHandleType = typeof(GCHandle).FullName;
            yield return ParseStatement($"var gcHandle = ({ghHandleType}){dataParamName}_;\n");
            yield return ParseStatement($"var {dataParamName} = (UserData)gcHandle.Target;\n");

            var skipReturnValue = callback.ThrowsGErrorException && callback.ReturnValue.Type.UnmanagedType == typeof(bool);

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
                yield return callback.ReturnValue.GetMarshalManagedToUnmanagedStatement();
                yield return ReturnStatement(ParseExpression("ret_"));;
            }
        }

        static StatementSyntax GetInvocationStatement(this Callback callback, string methodName = null, bool skipReturnValue = false)
        {
            var invokeExpression = InvocationExpression(IdentifierName(methodName ?? callback.ManagedName));
            var argList = callback.ManagedParameters.GetArgumentList();
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
        public static ClassDeclarationSyntax GetDelegateFactoryDeclaration(this Callback callback)
        {
            var identifier = callback.ManagedName + "Factory";
            var syntax = ClassDeclaration(identifier)
               .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
               .WithLeadingTrivia(callback.GetFactoryDocumentationCommentTrivia());
            return syntax;
        }

        /// <summary>
        /// Gets the C# delegate factory class members for a GIR callback of a
        /// virtual method
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetVirtualMethodDelegateFactoryMembers(this Callback callback)
        {
            return List<MemberDeclarationSyntax>()
                .Add(callback.GetVirtualMethodDelegateFactoryUnmangedCreateMethod());
        }

        static MethodDeclarationSyntax GetVirtualMethodDelegateFactoryUnmangedCreateMethod(this Callback callback)
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
            var identifier = callback.ManagedName.ToCamelCase();
            yield return LocalFunctionStatement(returnType, identifier)
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetVirtualMethodStatements()));

            yield return ReturnStatement(ParseExpression(identifier));
        }

        /// <summary>
        /// Gets the C# delegate factory class members for a GIR callback
        /// </summary>
        public static SyntaxList<MemberDeclarationSyntax> GetCallbackDelegateFactoryMembers(this Callback callback)
        {
            var list = List<MemberDeclarationSyntax>();

            var qualifiedName = callback.GetQualifiedName();
            var unmanagedQualifiedName = callback.GetQualifiedName(true);

            // emit nested private Data class

            var managedDelegateField = FieldDeclaration(VariableDeclaration(qualifiedName)
                    .AddVariables(VariableDeclarator("ManagedDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var unmanagedDelegateField = FieldDeclaration(VariableDeclaration(unmanagedQualifiedName)
                    .AddVariables(VariableDeclarator("UnmanagedDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var notifyType = typeof(UnmanagedDestroyNotify).ToSyntax();
            var notifyField = FieldDeclaration(VariableDeclaration(notifyType)
                    .AddVariables(VariableDeclarator("DestroyDelegate")))
                .AddModifiers(Token(PublicKeyword));
            var scopeType = typeof(CallbackScope).ToSyntax();
            var scopeField = FieldDeclaration(VariableDeclaration(scopeType)
                    .AddVariables(VariableDeclarator("Scope")))
                .AddModifiers(Token(PublicKeyword));
            var dataClass = ClassDeclaration("UserData")
                .AddModifiers(Token(UnsafeKeyword))
                .AddMembers(managedDelegateField, unmanagedDelegateField, notifyField, scopeField);
            list = list.Add(dataClass);

            // emit Create() method for unmanged>managed

            var createUserDataType = typeof(IntPtr).FullName;
            var createMethodParams = $"({unmanagedQualifiedName} callback, {createUserDataType} userData)";
            var createReturnType = qualifiedName;
            var createMethod = MethodDeclaration(createReturnType, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(createMethodParams))
                .WithBody(Block(callback.GetFactoryCreateMethodStatements()));
            list = list.Add(createMethod);

            // emit Create() method for managed>unmanaged

            var create2MethodParams = $"({qualifiedName} callback, {scopeType} scope)";
            var create2ReturnType = ParseTypeName(string.Format("({0}, {1}, {2})",
                unmanagedQualifiedName,
                typeof(UnmanagedDestroyNotify),
                typeof(IntPtr)));
            var create2Method = MethodDeclaration(create2ReturnType, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword), Token(UnsafeKeyword))
                .WithParameterList(ParseParameterList(create2MethodParams))
                .WithBody(Block(callback.GetFactoryCreate2MethodStatements()))
                .WithLeadingTrivia(callback.GetFactoryCreate2MethodDocumentationCommentTrivia());
            list = list.Add(create2Method);

            // emit unmanaged callback method

            var callbackReturnType = callback.ReturnValue.Type.UnmanagedType.ToSyntax();
            var callbackMethod = MethodDeclaration(callbackReturnType, "UnmanagedCallback")
                .AddModifiers(Token(StaticKeyword), Token(UnsafeKeyword))
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetCallbackStatements()));
            list = list.Add(callbackMethod);

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

            return list;
        }

        static IEnumerable<StatementSyntax> GetFactoryCreateMethodStatements(this Callback callback)
        {
            var nullCheck = ParseStatement(string.Format(@"if (callback == null) {{
                throw new {0}(nameof(callback));
            }}
            ", typeof(ArgumentNullException)));
            yield return nullCheck;

            var userDataParam = callback.Parameters.Single(x => x.ClosureIndex >= 0);
            var userDataExpression = ParseExpression($"var {userDataParam.ManagedName}_ = userData");
            var body = Block(callback.GetInvokeStatements("callback")
                .Prepend(ExpressionStatement(userDataExpression)));

            var paramList = callback.ManagedParameters.GetParameterList();

            // remove default values
            paramList = paramList.WithParameters(SeparatedList(paramList.Parameters
                .Select(x => x.WithDefault(default(EqualsValueClauseSyntax)))));

            var returnType = callback.ReturnValue.GetManagedTypeName();
            yield return LocalFunctionStatement(returnType, "callback_")
                .AddModifiers(Token(UnsafeKeyword))
                .WithParameterList(paramList)
                .WithBody(body);

            yield return ReturnStatement(ParseExpression("callback_"));
        }

        static IEnumerable<StatementSyntax> GetFactoryCreate2MethodStatements(this Callback callback)
        {
            const string template = @"var userData = new UserData {{
    ManagedDelegate = callback ?? throw new {0}(nameof(callback)),
    UnmanagedDelegate = UnmanagedCallback,
    DestroyDelegate = Destroy,
    Scope = scope
}};
";
            var userDataStatement = string.Format(template, typeof(ArgumentNullException).FullName);
            yield return ParseStatement(userDataStatement);

            var gcHandleStatement = string.Format("var userData_ = ({0}){1}.{2}(userData);\n",
                typeof(IntPtr),
                typeof(GCHandle),
                nameof(GCHandle.Alloc));
            yield return ParseStatement(gcHandleStatement);

            const string returnExpression = "(userData.UnmanagedDelegate, userData.DestroyDelegate, userData_)";
            yield return ReturnStatement(ParseExpression(returnExpression));
        }

        static SyntaxTriviaList GetFactoryDocumentationCommentTrivia(this Callback callback)
        {
            const string template = @"/// <summary>
/// Factory for creating <see cref=""{0}""/> methods.
/// </summary>
";
            var comments = string.Format(template, callback.ManagedName);
            return ParseLeadingTrivia(comments);
        }

        static SyntaxTriviaList GetFactoryCreate2MethodDocumentationCommentTrivia(this Callback callback)
        {
            const string template = @"/// <summary>
/// Wraps a <see cref=""{0}""/> in an anonymous method that can
/// be passed to unmanaged code.
/// </summary>
/// <param name=""method"">The managed method to wrap.</param>
/// <param name=""scope"">The lifetime scope of the callback.</param>
/// <returns>
/// A tuple containing the unmanaged callback, the unmanaged
/// notify function and a pointer to the user data.
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
