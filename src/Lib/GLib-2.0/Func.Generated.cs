// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of functions passed to g_list_foreach() and
    /// g_slist_foreach().
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedFunc(
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr data,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr userData);

    /// <include file="Func.xmldoc" path="declaration/member[@name='Func']/*" />
    public delegate void Func(System.IntPtr data);

    /// <summary>
    /// Class for marshalling <see cref="Func"/> methods.
    /// </summary>
    public static unsafe class FuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="Func"/>.
        /// </summary>
        public static GISharp.Lib.GLib.Func FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(System.IntPtr data)
            {
                var data_ = (System.IntPtr)data;
                callback_(data_, userData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static void Callback(System.IntPtr data_, System.IntPtr userData_)
        {
            try
            {
                var data = (System.IntPtr)data_;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((Func, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                userData.Invoke(data);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }
    }
}