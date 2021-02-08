// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
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
            if (returnValue.IsSkip) {
                return ParseTypeName("void");
            }

            var managedType = returnValue.GetSpecializedManagedType();
            var syntax = managedType.ToSyntax();

            if (returnValue.IsRefReturn()) {
                syntax = RefType(syntax).WithReadOnlyKeyword(Token(ReadOnlyKeyword));
            }

            if (returnValue.IsNullable && !managedType.IsValueType) {
                syntax = NullableType(syntax);
            }

            return syntax;
        }

        public static bool IsRefReturn(this ReturnValue returnValue)
        {
            var managedType = returnValue.Type.ManagedType;

            if (!managedType.IsValueType) {
                return false;
            }

            if (managedType == typeof(IntPtr)) {
                return false;
            }

            if (!returnValue.Type.IsPointer) {
                return false;
            }

            if (returnValue.TransferOwnership != "none") {
                throw new NotSupportedException("Don't know how to free pointer to unmanaged struct.");
            }

            return true;
        }
    }
}
