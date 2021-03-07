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
    public unsafe delegate int UnmanagedCompareDataFunc(
    /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr a,
    /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr b,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <include file="CompareDataFunc.xmldoc" path="declaration/member[@name='CompareDataFunc']/*" />
    public delegate int CompareDataFunc(System.IntPtr a, System.IntPtr b);

    /// <summary>
    /// Class for marshalling <see cref="CompareDataFunc"/> methods.
    /// </summary>
    public static unsafe class CompareDataFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="CompareDataFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.CompareDataFunc FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, System.IntPtr, int> callback_, System.IntPtr userData_)
        {
            int managedCallback(System.IntPtr a, System.IntPtr b)
            {
                var a_ = (System.IntPtr)a;
                var b_ = (System.IntPtr)b;
                var ret_ = callback_(a_,b_,userData_);
                var ret = (int)ret_;
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static int Callback(System.IntPtr a_, System.IntPtr b_, System.IntPtr userData_)
        {
            try
            {
                var a = (System.IntPtr)a_;
                var b = (System.IntPtr)b_;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((CompareDataFunc, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                var ret = userData.Invoke(a, b);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }

                var ret_ = (int)ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(int);
        }
    }
}