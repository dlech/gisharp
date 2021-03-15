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
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedCancellableSourceFunc(
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr userData);

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
            bool managedCallback(GISharp.Lib.Gio.Cancellable? cancellable)
            {
                var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
                var ret_ = callback_(cancellable_,userData_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Runtime.Boolean Callback(GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, System.IntPtr userData_)
        {
            try
            {
                var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((CancellableSourceFunc, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                var ret = userData.Invoke(cancellable);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }

                var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }
    }
}