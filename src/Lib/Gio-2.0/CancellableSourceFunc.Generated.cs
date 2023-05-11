// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by g_cancellable_source_new().
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedCancellableSourceFunc(
    /* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr data);

    /// <include file="CancellableSourceFunc.xmldoc" path="declaration/member[@name='CancellableSourceFunc']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    public delegate bool CancellableSourceFunc(GISharp.Lib.Gio.Cancellable? cancellable = null);

    /// <summary>
    /// Class for marshalling <see cref="CancellableSourceFunc"/> methods.
    /// </summary>
    public static unsafe class CancellableSourceFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="CancellableSourceFunc"/>.
        /// </summary>
        public static GISharp.Lib.Gio.CancellableSourceFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, System.IntPtr, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            var data_ = userData_;
            bool managedCallback(GISharp.Lib.Gio.Cancellable? cancellable)
            {
                var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
                var ret_ = callback_(cancellable_,data_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Runtime.Boolean Callback(GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, System.IntPtr data_)
        {
            try
            {
                var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                var dataHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var (data, dataScope) = ((CancellableSourceFunc, GISharp.Runtime.CallbackScope))dataHandle.Target!;
                var ret = data.Invoke(cancellable);
                if (dataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    dataHandle.Free();
                }

                var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }
    }
}