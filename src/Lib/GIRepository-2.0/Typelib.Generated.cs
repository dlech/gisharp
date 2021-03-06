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
        public GISharp.Runtime.UnownedUtf8 Namespace { get => GetNamespace(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Typelib(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_typelib_free(
/* <type name="Typelib" type="GITypelib*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_typelib_free((UnmanagedStruct*)handle);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            base.Dispose(disposing);
        }

        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_typelib_get_namespace(
/* <type name="Typelib" type="GITypelib*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib);
        partial void CheckGetNamespaceArgs();

        private GISharp.Runtime.UnownedUtf8 GetNamespace()
        {
            CheckGetNamespaceArgs();
            var typelib_ = (GISharp.Lib.GIRepository.Typelib.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_typelib_get_namespace(typelib_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_typelib_symbol(
/* <type name="Typelib" type="GITypelib*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GIRepository.Typelib.UnmanagedStruct* typelib,
/* <type name="utf8" type="const gchar*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* symbolName,
/* <type name="gpointer" type="gpointer*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:out caller-allocates:1 */
System.IntPtr* symbol);
        partial void CheckTrySymbolArgs(GISharp.Runtime.UnownedUtf8 symbolName);

        /// <include file="Typelib.xmldoc" path="declaration/member[@name='Typelib.TrySymbol(GISharp.Runtime.UnownedUtf8,System.IntPtr)']/*" />
        public bool TrySymbol(GISharp.Runtime.UnownedUtf8 symbolName, out System.IntPtr symbol)
        {
            fixed (System.IntPtr* symbol_ = &symbol)
            {
                CheckTrySymbolArgs(symbolName);
                var typelib_ = (GISharp.Lib.GIRepository.Typelib.UnmanagedStruct*)UnsafeHandle;
                var symbolName_ = (byte*)symbolName.UnsafeHandle;
                var ret_ = g_typelib_symbol(typelib_,symbolName_,symbol_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }
    }
}