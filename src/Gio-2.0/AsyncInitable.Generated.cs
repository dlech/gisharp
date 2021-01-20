// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GAsyncInitable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(AsyncInitableIface))]
    public partial interface IAsyncInitable : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_async_initable_get_type();

        static partial void CheckNewAsyncArgs(GISharp.Lib.GObject.GType objectType, System.UInt32 nParameters, GISharp.Lib.GObject.Parameter parameters, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Helper function for constructing #GAsyncInitable object. This is
        /// similar to g_object_newv() but also initializes the object asynchronously.
        /// </summary>
        /// <remarks>
        /// When the initialization is finished, @callback will be called. You can
        /// then call g_async_initable_new_finish() to get the new object and check
        /// for any errors.
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
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void g_async_initable_newv_async(
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType objectType,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 nParameters,
        /* <type name="GObject.Parameter" type="GParameter*" managed-name="GISharp.Lib.GObject.Parameter" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Parameter parameters,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:6 direction:in */
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.NewAsync(GISharp.Lib.GObject.GType,System.UInt32,GISharp.Lib.GObject.Parameter,System.Int32,GISharp.Lib.Gio.Cancellable?)']/*" />
        [System.ObsoleteAttribute("Use g_object_new_with_properties() and\ng_async_initable_init_async() instead. See #GParameter for more information.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.54")]
        [GISharp.Runtime.SinceAttribute("2.22")]
        public static unsafe System.Threading.Tasks.Task<GISharp.Lib.GObject.Object> NewAsync(GISharp.Lib.GObject.GType objectType, System.UInt32 nParameters, GISharp.Lib.GObject.Parameter parameters, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckNewAsyncArgs(objectType, nParameters, parameters, ioPriority, cancellable);
            var objectType_ = (GISharp.Lib.GObject.GType)objectType;
            var nParameters_ = (System.UInt32)nParameters;
            var parameters_ = (GISharp.Lib.GObject.Parameter)parameters;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GObject.Object>();
            var callback_ = newAsyncCallback_;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_async_initable_newv_async(objectType_, nParameters_, parameters_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_async_initable_get_type();

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.DoInitAsync(System.Int32,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncInitableIface.UnmanagedInitAsync))]
        void DoInitAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='IAsyncInitable.DoInitFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(AsyncInitableIface.UnmanagedInitFinish))]
        void DoInitFinish(GISharp.Lib.Gio.IAsyncResult res);
    }

    /// <summary>
    /// Extension methods for <see cref="IAsyncInitable"/>
    /// </summary>
    public static partial class AsyncInitable
    {
        /// <summary>
        /// Starts asynchronous initialization of the object implementing the
        /// interface. This must be done before any real use of the object after
        /// initial construction. If the object also implements #GInitable you can
        /// optionally call g_initable_init() instead.
        /// </summary>
        /// <remarks>
        /// This method is intended for language bindings. If writing in C,
        /// g_async_initable_new_async() should typically be used instead.
        /// 
        /// When the initialization is finished, @callback will be called. You can
        /// then call g_async_initable_init_finish() to get the result of the
        /// initialization.
        /// 
        /// Implementations may also support cancellation. If @cancellable is not
        /// %NULL, then initialization can be cancelled by triggering the cancellable
        /// object from another thread. If the operation was cancelled, the error
        /// %G_IO_ERROR_CANCELLED will be returned. If @cancellable is not %NULL, and
        /// the object doesn't support cancellable initialization, the error
        /// %G_IO_ERROR_NOT_SUPPORTED will be returned.
        /// 
        /// As with #GInitable, if the object is not initialized, or initialization
        /// returns with an error, then all operations on the object except
        /// g_object_ref() and g_object_unref() are considered to be invalid, and
        /// have undefined behaviour. They will often fail with g_critical() or
        /// g_warning(), but this must not be relied on.
        /// 
        /// Callers should not assume that a class which implements #GAsyncInitable can
        /// be initialized multiple times; for more information, see g_initable_init().
        /// If a class explicitly supports being initialized multiple times,
        /// implementation requires yielding all subsequent calls to init_async() on the
        /// results of the first call.
        /// 
        /// For classes that also support the #GInitable interface, the default
        /// implementation of this method will run the g_initable_init() function
        /// in a thread, so if you want to support asynchronous initialization via
        /// threads, just implement the #GAsyncInitable interface without overriding
        /// any interface methods.
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
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void g_async_initable_init_async(
        /* <type name="AsyncInitable" type="GAsyncInitable*" managed-name="AsyncInitable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr initable,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        static partial void CheckInitAsyncArgs(this GISharp.Lib.Gio.IAsyncInitable initable, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="AsyncInitable.xmldoc" path="declaration/member[@name='AsyncInitable.InitAsync(GISharp.Lib.Gio.IAsyncInitable,System.Int32,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe static System.Threading.Tasks.Task InitAsync(this GISharp.Lib.Gio.IAsyncInitable initable, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckInitAsyncArgs(initable, ioPriority, cancellable);
            var initable_ = initable.Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>();
            var callback_ = initAsyncCallback_;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_async_initable_init_async(initable_, ioPriority_, cancellable_, callback_, userData_);
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
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        private static extern unsafe GISharp.Runtime.Boolean g_async_initable_init_finish(
        /* <type name="AsyncInitable" type="GAsyncInitable*" managed-name="AsyncInitable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr initable,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static unsafe void InitFinish(System.IntPtr initable_, System.IntPtr res_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>)userData.Target!;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                g_async_initable_init_finish(initable_, res_, ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                completionSource.SetResult(GISharp.Runtime.Void.Default);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback initAsyncCallbackDelegate = InitFinish;
        static readonly System.IntPtr initAsyncCallback_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<GISharp.Lib.Gio.UnmanagedAsyncReadyCallback>(initAsyncCallbackDelegate);

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
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_async_initable_new_finish(
        /* <type name="AsyncInitable" type="GAsyncInitable*" managed-name="AsyncInitable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr initable,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr res,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static unsafe void NewFinish(System.IntPtr initable_, System.IntPtr res_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GObject.Object>)userData.Target!;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_async_initable_new_finish(initable_,res_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.Full)!;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback newAsyncCallbackDelegate = NewFinish;
        static readonly System.IntPtr newAsyncCallback_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<GISharp.Lib.Gio.UnmanagedAsyncReadyCallback>(newAsyncCallbackDelegate);
    }
}