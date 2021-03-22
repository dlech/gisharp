// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed. #GAsyncReadyCallback
    /// callbacks from #GTask are guaranteed to be invoked in a later
    /// iteration of the
    /// [thread-default main context][g-main-context-push-thread-default]
    /// where the #GTask was created. All other users of
    /// #GAsyncReadyCallback must likewise call it asynchronously in a
    /// later iteration of the main context.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedAsyncReadyCallback(
    /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject,
    /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <include file="AsyncReadyCallback.xmldoc" path="declaration/member[@name='AsyncReadyCallback']/*" />
    public delegate void AsyncReadyCallback(GISharp.Lib.GObject.Object? sourceObject, GISharp.Lib.Gio.IAsyncResult res);

    /// <summary>
    /// Class for marshalling <see cref="AsyncReadyCallback"/> methods.
    /// </summary>
    public static unsafe class AsyncReadyCallbackMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="AsyncReadyCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.AsyncReadyCallback FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.Object? sourceObject, GISharp.Lib.Gio.IAsyncResult res)
            {
                var sourceObject_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)(sourceObject?.UnsafeHandle ?? System.IntPtr.Zero);
                var res_ = (GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*)res.UnsafeHandle;
                callback_(sourceObject_, res_, userData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static void Callback(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res_, System.IntPtr userData_)
        {
            try
            {
                var sourceObject = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)sourceObject_, GISharp.Runtime.Transfer.None);
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)res_, GISharp.Runtime.Transfer.None)!;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((AsyncReadyCallback, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                userData.Invoke(sourceObject, res);
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