// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of a function used to test two values for
    /// equality. The function should return %TRUE if both values are equal
    /// and %FALSE otherwise.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedEqualFunc(
    /* <type name="gpointer" type="gconstpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr a,
    /* <type name="gpointer" type="gconstpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr b);

    /// <include file="EqualFunc.xmldoc" path="declaration/member[@name='EqualFunc']/*" />
    public delegate bool EqualFunc(System.IntPtr a, System.IntPtr b);

    /// <summary>
    /// Class for marshalling <see cref="EqualFunc"/> methods.
    /// </summary>
    public static unsafe class EqualFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="EqualFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.EqualFunc FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            bool managedCallback(System.IntPtr a, System.IntPtr b)
            {
                var a_ = (System.IntPtr)a;
                var b_ = (System.IntPtr)b;
                var ret_ = callback_(a_,b_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }

            return managedCallback;
        }
    }
}