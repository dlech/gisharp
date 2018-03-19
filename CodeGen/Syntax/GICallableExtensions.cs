using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
        public static IEnumerable<StatementSyntax> GetInvokeStatements(this GICallable callable, string invokeMethod)
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
                    var expression = ParseExpression($"var {identifier}_ = Handle");
                    yield return ExpressionStatement(expression);
                }
            }

            foreach (var p in callable.ManagedParameters.Where(x => x.Direction != "out")) {
                yield return p.GetMarshalManagedToUnmanagedStatement();
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

            foreach (var p in callable.Parameters.Where(x => x.Scope == "call")) {
                var destroyParam = "destroy" + p.ManagedName.ToPascalCase();
                var userDataParam = callable.Parameters.ElementAt(p.ClosureIndex).ManagedName;
                var expression = ParseExpression($"{destroyParam}({userDataParam})");
                yield return ExpressionStatement(expression);
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
                yield return p.GetMarshalUnmanagedToManagedStatement(false);
            }

            // emit the return statement

            if (callable is Constructor) {
                // constructor static methods return the unmanaged value directly
                // for use in the actual C# constructor
                yield return ReturnStatement(ParseExpression("ret_"));
            }
            else if (callable.ReturnValue.Type.UnmanagedType != typeof(void) && !callable.ReturnValue.IsSkip) {
                yield return callable.ReturnValue.GetMarshalUnmanagedToManagedStatement();
                yield return ReturnStatement(ParseExpression("ret"));
            }
        }

        /// <summary>
        /// Gets XML doc comment for thowing a GErrorException or default trivia
        /// if the callable does not throw.
        /// </summary>
        public static SyntaxTriviaList GetGErrorExceptionDocCommentTrivia(this GICallable callable)
        {
            if (!callable.ThrowsGErrorException) {
                return default (SyntaxTriviaList);
            }
            var builder = new StringBuilder();
            builder.AppendFormat("/// <exception name=\"{0}\">",
                typeof(GErrorException).FullName);
            builder.AppendLine();
            builder.AppendLine("/// On error");
            builder.AppendLine("/// </exception>");

            return ParseLeadingTrivia(builder.ToString());
        }
    }
}
