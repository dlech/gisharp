// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GAsyncInitable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(AsyncInitableIface))]
    public unsafe partial interface IAsyncInitable : GISharp.Lib.GObject.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Runtime.GType _GType = g_async_initable_get_type();

        /// <summary>
        /// Helper function for constructing #GAsyncInitable object. This is
        /// similar to g_object_newv() but also initializes the object asynchronously.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the initialization is finished, @callback will be called. You can
        /// then call g_async_initable_new_finish() to get the new object and check
        /// for any errors.
        /// </para>
        /// </remarks>
        /// <param name="objectType">
        /// a #GType supporting #GAsyncInitable.
        /// </param>
        /// <param name="nParameters">
        /// the number of parameters in @parameters
        /// </param>
        /// <param name="parameters">
        /// the parameters to use to construct the object
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the operation
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback to call when the initialization is
        ///     finished
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.ObsoleteAttribute("Use g_object_new_with_properties() and\ng_async_initable_init_async() instead. See #GParameter for more information.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.54")]
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_async_initable_newv_async(
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.GType objectType,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint nParameters,
        /* <type name="GObject.Parameter" type="GParameter*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Parameter* parameters,
        /* <type name="gint" type="int" /> */
        /* transfer-ownership:none direction:in */
        int ioPriority,
        /* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:6 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        static partial void CheckNewAsyncArgs(GISharp.Runtime.GType objectType, uint nParameters, ref GISharp.Lib.GObject.Parameter parameters, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.NewAsync(GISharp.Runtime.GType,uint,GISharp.Lib.GObject.Parameter,int,GISharp.Lib.Gio.Cancellable?)']/*" />
        [System.ObsoleteAttribute("Use g_object_new_with_properties() and\ng_async_initable_init_async() instead. See #GParameter for more information.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.54")]
        [GISharp.Runtime.SinceAttribute("2.22")]
        public static System.Threading.Tasks.Task<GISharp.Lib.GObject.Object> NewAsync(GISharp.Runtime.GType objectType, uint nParameters, ref GISharp.Lib.GObject.Parameter parameters, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            fixed (GISharp.Lib.GObject.Parameter* parameters_ = &parameters)
            {
                CheckNewAsyncArgs(objectType, nParameters, ref parameters, ioPriority, cancellable);
                var objectType_ = (GISharp.Runtime.GType)objectType;
                var nParameters_ = (uint)nParameters;
                var ioPriority_ = (int)ioPriority;
                var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
                var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GObject.Object>();
                var callback_ = (delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&NewFinish;
                var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
                g_async_initable_newv_async(objectType_, nParameters_, parameters_, ioPriority_, cancellable_, callback_, userData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                return completionSource.Task;
            }
        }

        /// <summary>
        /// Finishes the async construction for the various g_async_initable_new
        /// calls, returning the created object or %NULL on error.
        /// </summary>
        /// <param name="initable">
        /// the #GAsyncInitable from the callback
        /// </param>
        /// <param name="res">
        /// the #GAsyncResult from the callback
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly created #GObject,
        ///      or %NULL on error. Free with g_object_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_async_initable_new_finish(
        /* <type name="AsyncInitable" type="GAsyncInitable*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct* initable,
        /* <type name="AsyncResult" type="GAsyncResult*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void NewFinish(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res_, System.IntPtr userData_)
        {
            try
            {
                var initable_ = (GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct*)sourceObject_;
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GObject.Object>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                var ret_ = g_async_initable_new_finish(initable_,res_,&error_);
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Lib.GLib.Error.Exception(error));
                    return;
                }
                var ret = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_async_initable_get_type();

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.DoInitAsync(int,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncInitableIface.UnmanagedInitAsync))]
        void DoInitAsync(int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.DoInitFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncInitableIface.UnmanagedInitFinish))]
        void DoInitFinish(GISharp.Lib.Gio.IAsyncResult res);
    }

    /// <summary>
    /// Extension methods for <see cref="IAsyncInitable"/>
    /// </summary>
    public static unsafe partial class AsyncInitable
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// Starts asynchronous initialization of the object implementing the
        /// interface. This must be done before any real use of the object after
        /// initial construction. If the object also implements #GInitable you can
        /// optionally call g_initable_init() instead.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is intended for language bindings. If writing in C,
        /// g_async_initable_new_async() should typically be used instead.
        /// </para>
        /// <para>
        /// When the initialization is finished, @callback will be called. You can
        /// then call g_async_initable_init_finish() to get the result of the
        /// initialization.
        /// </para>
        /// <para>
        /// Implementations may also support cancellation. If @cancellable is not
        /// %NULL, then initialization can be cancelled by triggering the cancellable
        /// object from another thread. If the operation was cancelled, the error
        /// %G_IO_ERROR_CANCELLED will be returned. If @cancellable is not %NULL, and
        /// the object doesn't support cancellable initialization, the error
        /// %G_IO_ERROR_NOT_SUPPORTED will be returned.
        /// </para>
        /// <para>
        /// As with #GInitable, if the object is not initialized, or initialization
        /// returns with an error, then all operations on the object except
        /// g_object_ref() and g_object_unref() are considered to be invalid, and
        /// have undefined behaviour. They will often fail with g_critical() or
        /// g_warning(), but this must not be relied on.
        /// </para>
        /// <para>
        /// Callers should not assume that a class which implements #GAsyncInitable can
        /// be initialized multiple times; for more information, see g_initable_init().
        /// If a class explicitly supports being initialized multiple times,
        /// implementation requires yielding all subsequent calls to init_async() on the
        /// results of the first call.
        /// </para>
        /// <para>
        /// For classes that also support the #GInitable interface, the default
        /// implementation of this method will run the g_initable_init() function
        /// in a thread, so if you want to support asynchronous initialization via
        /// threads, just implement the #GAsyncInitable interface without overriding
        /// any interface methods.
        /// </para>
        /// </remarks>
        /// <param name="initable">
        /// a #GAsyncInitable.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the operation
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_async_initable_init_async(
        /* <type name="AsyncInitable" type="GAsyncInitable*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct* initable,
        /* <type name="gint" type="int" /> */
        /* transfer-ownership:none direction:in */
        int ioPriority,
        /* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        static partial void CheckInitAsyncArgs(this GISharp.Lib.Gio.IAsyncInitable initable, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='AsyncInitable.InitAsync(GISharp.Lib.Gio.IAsyncInitable,int,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public static System.Threading.Tasks.Task InitAsync(this GISharp.Lib.Gio.IAsyncInitable initable, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckInitAsyncArgs(initable, ioPriority, cancellable);
            var initable_ = (GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct*)initable.UnsafeHandle;
            var ioPriority_ = (int)ioPriority;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.ValueTuple>();
            var callback_ = (delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&InitFinish;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_async_initable_init_async(initable_, ioPriority_, cancellable_, callback_, userData_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes asynchronous initialization and returns the result.
        /// See g_async_initable_init_async().
        /// </summary>
        /// <param name="initable">
        /// a #GAsyncInitable.
        /// </param>
        /// <param name="res">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful. If an error has occurred, this function
        /// will return %FALSE and set @error appropriately if present.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_async_initable_init_finish(
        /* <type name="AsyncInitable" type="GAsyncInitable*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct* initable,
        /* <type name="AsyncResult" type="GAsyncResult*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void InitFinish(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* res_, System.IntPtr userData_)
        {
            try
            {
                var initable_ = (GISharp.Lib.Gio.AsyncInitable.UnmanagedStruct*)sourceObject_;
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.ValueTuple>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                g_async_initable_init_finish(initable_, res_, &error_);
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Lib.GLib.Error.Exception(error));
                    return;
                }
                completionSource.SetResult(default(System.ValueTuple));
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }
    }
}