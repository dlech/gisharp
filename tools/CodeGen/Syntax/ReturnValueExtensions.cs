// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.CodeGen.Gir;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

namespace GISharp.CodeGen.Syntax
{
    public static class ReturnValueExtensions
    {
        /// <summary>
        /// Gets the return type name, fixed up to account for the possibility
        /// that it is skipped or that it is a pointer to a value type.
        /// </summary>
        internal static TypeSyntax GetManagedTypeName(this ReturnValue returnValue)
        {
            if (returnValue.ParentNode is GICallable callable && callable.IsAsync)
            {
                var task = "System.Threading.Tasks.Task";
                var returnTypes = returnValue.GetAsyncReturnTypes();
                if (returnTypes.Skip(1).Any())
                {
                    task += $"<System.ValueTuple<{string.Join(", ", returnTypes)}>>";
                }
                else if (returnTypes.Any())
                {
                    task += $"<{string.Join(", ", returnTypes)}>";
                }
                return ParseTypeName(task);
            }

            if (returnValue.IsSkip)
            {
                return PredefinedType(Token(VoidKeyword));
            }

            var managedType = returnValue.GetSpecializedManagedType();
            var syntax = ParseTypeName(managedType);

            if (returnValue.IsRefReturn())
            {
                syntax = RefType(syntax).WithReadOnlyKeyword(Token(ReadOnlyKeyword));
            }

            if (
                returnValue.IsNullable
                && !returnValue.Type.IsValueType()
                && !managedType.Contains("Unowned", StringComparison.Ordinal)
                && !managedType.StartsWith("System.Span", StringComparison.Ordinal)
                && !managedType.StartsWith("System.ReadOnlySpan", StringComparison.Ordinal)
            )
            {
                syntax = NullableType(syntax);
            }

            return syntax;
        }

        public static bool IsRefReturn(this ReturnValue returnValue)
        {
            if (!returnValue.Type.IsValueType())
            {
                return false;
            }

            if (returnValue.Type.GetManagedType() == "System.IntPtr")
            {
                return false;
            }

            if (!returnValue.Type.IsPointer)
            {
                return false;
            }

            if (returnValue.TransferOwnership != "none")
            {
                throw new NotSupportedException(
                    "Don't know how to free pointer to unmanaged struct."
                );
            }

            return true;
        }

        internal static IEnumerable<string> GetAsyncReturnTypes(this ReturnValue returnValue)
        {
            var callable = returnValue.Ancestors.OfType<GICallable>().Single();
            var finishFunction = callable.IsFinish
                ? callable
                : (GICallable)
                    callable.ParentNode.Element
                        .Elements()
                        .Select(x => GirNode.GetNode(x))
                        .Single(x => x is GICallable c && c.ManagedName == callable.AsyncFinish);
            var returnTypes = finishFunction.ManagedParameters
                .Where(x => x.Direction != "in")
                .Select(x => x.Type.GetManagedType());
            if (!finishFunction.ReturnValue.IsSkip && finishFunction.ReturnValue.GirName != "none")
            {
                returnTypes = returnTypes.Prepend(finishFunction.ReturnValue.Type.GetManagedType());
            }
            return returnTypes;
        }
    }
}
