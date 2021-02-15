// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="Typelib.xmldoc" path="declaration/member[@name='Typelib']/*" />
    public sealed unsafe partial class Typelib : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <include file="Typelib.xmldoc" path="declaration/member[@name='Typelib.Namespace']/*" />
        public GISharp.Lib.GLib.UnownedUtf8 Namespace { get => GetNamespace(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Typelib(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_typelib_free(
/* <type name="Typelib" type="GITypelib*" managed-name="Typelib" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib);
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Byte* g_typelib_get_namespace(
/* <type name="Typelib" type="GITypelib*" managed-name="Typelib" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib);
        partial void CheckGetNamespaceArgs();

        private GISharp.Lib.GLib.UnownedUtf8 GetNamespace()
        {
            CheckGetNamespaceArgs();
            var typelib_ = (GISharp.Lib.GIRepository.Typelib.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_typelib_get_namespace(typelib_);
            var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_typelib_symbol(
/* <type name="Typelib" type="GITypelib*" managed-name="Typelib" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib,
/* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.Byte* symbolName,
/* <type name="gpointer" type="gpointer*" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:out caller-allocates:1 */
System.IntPtr* symbol);
        partial void CheckTrySymbolArgs(GISharp.Lib.GLib.UnownedUtf8 symbolName);

        /// <include file="Typelib.xmldoc" path="declaration/member[@name='Typelib.TrySymbol(GISharp.Lib.GLib.UnownedUtf8,System.IntPtr)']/*" />
        public System.Boolean TrySymbol(GISharp.Lib.GLib.UnownedUtf8 symbolName, out System.IntPtr symbol)
        {
            fixed (System.IntPtr* symbol_ = &symbol)
            {
                CheckTrySymbolArgs(symbolName);
                var typelib_ = (GISharp.Lib.GIRepository.Typelib.UnmanagedStruct*)UnsafeHandle;
                var symbolName_ = (System.Byte*)symbolName.UnsafeHandle;
                var ret_ = g_typelib_symbol(typelib_,symbolName_,symbol_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }
    }
}