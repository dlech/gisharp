

using System;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

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

            var managedType = returnValue.Type.ManagedType;
            var syntax = managedType.ToSyntax();

            if (managedType == typeof(Utf8) && returnValue.TransferOwnership == "none") {
                var utf8Type = returnValue.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                syntax = ParseTypeName($"{utf8Type}");
            }
            else if (managedType.IsGenericType && managedType.GetGenericTypeDefinition() == typeof(CArray<>) && returnValue.TransferOwnership == "none") {
                syntax = typeof(ReadOnlySpan<>).MakeGenericType(managedType.GetGenericArguments()).ToSyntax();
            }
            else if (managedType.IsGenericType && managedType.GetGenericTypeDefinition() == typeof(CPtrArray<>) && returnValue.TransferOwnership == "none") {
                syntax = typeof(UnownedCPtrArray<>).MakeGenericType(managedType.GetGenericArguments()).ToSyntax();
            }
            else if (returnValue.IsNullable && !managedType.IsValueType && !managedType.IsPointer) {
                syntax = NullableType(syntax);
            }

            // when the unmanaged function returns a value type as a pointer,
            // we need to make it nullable
            if (returnValue.Type.IsPointer && !(returnValue.Type is Gir.Array) && managedType.IsValueType && managedType != typeof(IntPtr)) {
                syntax = ParseTypeName(syntax.ToString() + "?");
            }

            return syntax;
        }
    }
}
