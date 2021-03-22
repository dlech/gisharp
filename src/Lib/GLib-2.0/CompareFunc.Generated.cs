// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values.  The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gint" type="gint" managed-name="System.Int32" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate int UnmanagedCompareFunc(
    /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr a,
    /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr b);

    /// <include file="CompareFunc.xmldoc" path="declaration/member[@name='CompareFunc']/*" />
    public delegate int CompareFunc(System.IntPtr a, System.IntPtr b);

    /// <summary>
    /// Class for marshalling <see cref="CompareFunc"/> methods.
    /// </summary>
    public static unsafe class CompareFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="CompareFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.CompareFunc FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, int> callback_, System.IntPtr userData_)
        {
            int managedCallback(System.IntPtr a, System.IntPtr b)
            {
                var a_ = (System.IntPtr)a;
                var b_ = (System.IntPtr)b;
                var ret_ = callback_(a_,b_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = (int)ret_;
                return ret;
            }

            return managedCallback;
        }
    }
}