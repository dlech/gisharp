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
            var returnType = callback.ReturnValue.GirType.ManagedType.ToSyntax();
            if (callback.ReturnValue.IsSkip) {
                returnType = ParseTypeName("void");
            }
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
            var returnType = callback.ReturnValue.GirType.UnmanagedType.ToSyntax();
            var identifier = "Unmanaged" + callback.ManagedName;

            var girTrivia = TriviaList(callback.ReturnValue.GetGirXmlTrivia(),
                EndOfLine("\n"), callback.ReturnValue.GetAnnotationTrivia());

             // get parameters, injecting some comments along the way
            var parameterList = ParameterList(SeparatedList(callback.Parameters
                .Select(x => x.GetParameter()
                    .WithLeadingTrivia(TriviaList(x.GetGirXmlTrivia(), EndOfLine("\n"),
                        x.GetAnnotationTrivia(), EndOfLine("\n"))))));

            var attrName = ParseName(typeof(UnmanagedFunctionPointerAttribute).FullName);
            var attrArg = ParseExpression($"{typeof(CallingConvention).FullName}.{nameof(CallingConvention.Cdecl)}");
            var attr = Attribute(attrName)
                .AddArgumentListArguments(AttributeArgument(attrArg));

            return DelegateDeclaration(returnType, identifier)
                .AddModifiers(Token(PublicKeyword).WithLeadingTrivia(girTrivia))
                .WithAttributeLists(callback.GetCommonAttributeLists())
                .AddAttributeLists(AttributeList().AddAttributes(attr))
                .WithParameterList(parameterList)
                .WithLeadingTrivia(callback.Doc.GetDocCommentTrivia());
        }

        /// <summary>
        /// Gets a method declaration that calls a managed virtual method
        /// </summary>
        public static MethodDeclarationSyntax GetVirtualMethodDeclaration(this Callback callback)
        {
            var returnType = callback.ReturnValue.GirType.UnmanagedType.ToSyntax();

            var method = MethodDeclaration(returnType, "On" + callback.ManagedName)
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetVirtualMethodStatements()));

            return method;
        }
        static IEnumerable<StatementSyntax> GetVirtualMethodStatements(this Callback callback)
        {
            var tryStatement = TryStatement();

            var instanceParam = callback.Parameters.InstanceParameter;

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != GIDirection.Out)
                .Prepend(instanceParam))
            {
                var marshalStatement = arg.GetMarshalUnmanagedToManagedStatement();
                tryStatement = tryStatement.AddBlockStatements(marshalStatement);
            }

            var invokeMethod = $"{instanceParam.ManagedName}.On{callback.ManagedName}";
            var invokeStatement = callback.GetInvocationStatement(invokeMethod);
            tryStatement = tryStatement.AddBlockStatements(invokeStatement);

            foreach (var arg in callback.ManagedParameters.Where(x => x.Direction != GIDirection.In)) {
                var statement = arg.GetMarshalManagedToUnmanagedStatement(false);
                tryStatement = tryStatement.AddBlockStatements(statement);
            }

            if (callback.ReturnValue.GirType.UnmanagedType != typeof(void)) {
                var statement = callback.ReturnValue.GetMarshalManagedToUnmanagedStatement();
                tryStatement = tryStatement.AddBlockStatements(statement);

                var returnStatement = ReturnStatement(ParseExpression("ret_"));
                tryStatement = tryStatement.AddBlockStatements(returnStatement);
            }

            var returnDefault = default(StatementSyntax);
            if (callback.ReturnValue.GirType.UnmanagedType != typeof(void)) {
                var returnType = callback.ReturnValue.GirType.UnmanagedType.ToSyntax();
                returnDefault = ParseStatement($"return default({returnType});\n");
            }

            // if the method has an error parameter, we can propagate any
            // GErrorException thrown by the managed callback

            if (callback.ThrowsGErrorException) {
                var gErrorException = typeof(GISharp.Runtime.GErrorException).FullName;
                var propagateError = ParseStatement(string.Format("{0}.{1}(ref {2}_, ex.{3});\n",
                    typeof(GISharp.Runtime.GMarshal).FullName,
                    nameof(GISharp.Runtime.GMarshal.PropagateError),
                    callback.Parameters.ErrorParameter.ManagedName,
                    nameof(GISharp.Runtime.GErrorException.Error)));

                var gErrorExceptionStatements = List<StatementSyntax>().Add(propagateError);
                if (returnDefault != null) {
                    gErrorExceptionStatements = gErrorExceptionStatements.Add(returnDefault);
                }

                tryStatement = tryStatement.AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(ParseTypeName(gErrorException), ParseToken("ex")))
                    .WithBlock(Block(gErrorExceptionStatements)));
            }

            // otherwise, we just have to log an unhandled exception since we
            // are returning to unmanaged code, which doesn't know about
            // managed exceptions

            var exception = typeof(Exception).FullName;
            var logUnhandledException = ParseStatement(string.Format("{0}.{1}(ex);\n",
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException)));

            var exceptionStatements = List<StatementSyntax>().Add(logUnhandledException);

            foreach (var arg in callback.Parameters.Where(x => x.Direction == GIDirection.Out)) {
                var type = arg.GirType.UnmanagedType.ToSyntax();
                if (arg.GirType.ManagedType.IsValueType) {
                    type = arg.GirType.ManagedType.ToSyntax();
                }
                var expression = ParseExpression($"{arg.ManagedName}_ = default({type})");
                exceptionStatements = exceptionStatements.Add(ExpressionStatement(expression));
            }

            if (returnDefault != null) {
                exceptionStatements = exceptionStatements.Add(returnDefault);
            }

            tryStatement = tryStatement.AddCatches(CatchClause()
                .WithDeclaration(CatchDeclaration(ParseTypeName(exception), ParseToken("ex")))
                .WithBlock(Block(exceptionStatements)));

            yield return tryStatement;
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
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException));
            yield return TryStatement()
                .WithBlock(Block(callback.GetCallbackTryStatements()))
                .AddCatches(CatchClause()
                    .WithDeclaration(CatchDeclaration(catchType, ParseToken("ex")))
                    .WithBlock(Block(ParseStatement(catchStatement))));
            
            if (callback.ReturnValue.GirType.UnmanagedType != typeof(void)) {
                var returnType = callback.ReturnValue.GirType.UnmanagedType.ToSyntax();
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

            var skipReturnValue = callback.ThrowsGErrorException && callback.ReturnValue.GirType.UnmanagedType == typeof(bool);

            yield return callback.GetInvocationStatement($"{dataParamName}.ManagedDelegate", skipReturnValue);

            yield return ParseStatement(string.Format(@"if ({0}.Scope == {1}.{2}) {{
                    Destroy({0}_);
                }}
                ", dataParamName,
                typeof(CallbackScope).FullName,
                nameof(CallbackScope.Async)));

            if (skipReturnValue) {
                // callbacks that throw and return bool should always return true
                yield return ParseStatement("return true;\n");
            }
            else if (callback.ReturnValue.GirType.UnmanagedType != typeof(void)) {
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
            if (!skipReturnValue && callback.ReturnValue.GirType.ManagedType != typeof(void)) {
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
        public static ClassDeclarationSyntax GetFactoryDeclaration(this Callback callback)
        {
            var identifier = callback.ManagedName + "Factory";
            var syntax = ClassDeclaration(identifier)
               .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
               .WithMembers(List(callback.GetFactoryClassMembers()))
               .WithLeadingTrivia(callback.GetFactoryDocumentationCommentTrivia());
            return syntax;
        }

        static IEnumerable<MemberDeclarationSyntax> GetFactoryClassMembers(this Callback callback)
        {
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
                .AddMembers(managedDelegateField, unmanagedDelegateField, notifyField, scopeField);
            yield return dataClass;

            // emit Create() method for unmanged>managed

            var createUserDataType = typeof(IntPtr).FullName;
            var createMethodParams = $"({unmanagedQualifiedName} callback, {createUserDataType} userData)";
            var createReturnType = qualifiedName;
            var createMethod = MethodDeclaration(createReturnType, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(createMethodParams))
                .WithBody(Block(callback.GetFactoryCreateMethodStatements()));
            yield return createMethod;

            // emit Create() method for managed>unmanaged

            var create2MethodParams = $"({qualifiedName} callback, {scopeType} scope)";
            var create2ReturnType = ParseTypeName(string.Format("({0}, {1}, {2})",
                unmanagedQualifiedName,
                typeof(UnmanagedDestroyNotify).FullName,
                typeof(IntPtr).FullName));
            var create2Method = MethodDeclaration(create2ReturnType, "Create")
                .AddModifiers(Token(PublicKeyword), Token(StaticKeyword))
                .WithParameterList(ParseParameterList(create2MethodParams))
                .WithBody(Block(callback.GetFactoryCreate2MethodStatements()))
                .WithLeadingTrivia(callback.GetFactoryCreate2MethodDocumentationCommentTrivia());
            yield return create2Method;

            // emit unmanaged callback method

            var callbackReturnType = callback.ReturnValue.GirType.UnmanagedType.ToSyntax();
            var callbackMethod = MethodDeclaration(callbackReturnType, "UnmanagedCallback")
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(callback.Parameters.GetParameterList())
                .WithBody(Block(callback.GetCallbackStatements()));
            yield return callbackMethod;

            // emit destroy notify method

            var destroyReturnType = ParseTypeName("void");
            var destroyParamList = ParseParameterList($"({typeof(IntPtr).FullName} userData_)");

            var destroyTryStatement = ParseStatement(string.Format(@"try {{
                var gcHandle = ({0})userData_;
                gcHandle.Free();
            }}
            catch ({1} ex) {{
                {2}.{3}(ex);
            }}
            ", typeof(GCHandle).FullName,
                typeof(Exception).FullName,
                typeof(Log).FullName,
                nameof(Log.LogUnhandledException)));

            var destroyMethod = MethodDeclaration(destroyReturnType, "Destroy")
                .AddModifiers(Token(StaticKeyword))
                .WithParameterList(destroyParamList)
                .WithBody(Block(destroyTryStatement));

            yield return destroyMethod;
        }

        static IEnumerable<StatementSyntax> GetFactoryCreateMethodStatements(this Callback callback)
        {
            var nullCheck = ParseStatement(string.Format(@"if (callback == null) {{
                throw new {0}(nameof(callback));
            }}
            ", typeof(ArgumentNullException).FullName));
            yield return nullCheck;

            var userDataParam = callback.Parameters.Single(x => x.ClosureIndex >= 0);
            var userDataExpression = ParseExpression($"var {userDataParam.ManagedName}_ = userData");
            var body = Block(callback.GetInvokeStatements("callback")
                .Prepend(ExpressionStatement(userDataExpression)));

            var paramList = callback.ManagedParameters.GetParameterList();
            var lambdaExpression = ParenthesizedLambdaExpression(body)
                .WithParameterList(paramList);

            var newExpression = ObjectCreationExpression(callback.GetQualifiedName())
                .AddArgumentListArguments(Argument(lambdaExpression));

            yield return ReturnStatement(newExpression);
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
                typeof(IntPtr).FullName,
                typeof(GCHandle).FullName,
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
                typeof(CallbackScope).FullName,
                nameof(CallbackScope.Call),
                nameof(CallbackScope.Async));

            return ParseLeadingTrivia(comments);
        }
    }
}
