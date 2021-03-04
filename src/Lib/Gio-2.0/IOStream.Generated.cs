// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GIOStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(IOStreamClass))]
    public abstract unsafe partial class IOStream : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_io_stream_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="IOStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.GObject.Object.UnmanagedStruct ParentInstance;

            /// <include file="IOStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.Priv']/*" />
            private readonly System.IntPtr Priv;
#pragma warning restore CS0169, CS0649
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.IsClosed_']/*" />
        [GISharp.Runtime.GPropertyAttribute("closed")]
        public System.Boolean IsClosed_ { get => (System.Boolean)GetProperty("closed")!; }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.InputStream_']/*" />
        [GISharp.Runtime.GPropertyAttribute("input-stream")]
        public GISharp.Lib.Gio.InputStream? InputStream_ { get => (GISharp.Lib.Gio.InputStream?)GetProperty("input-stream")!; }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.OutputStream_']/*" />
        [GISharp.Runtime.GPropertyAttribute("output-stream")]
        public GISharp.Lib.Gio.OutputStream? OutputStream_ { get => (GISharp.Lib.Gio.OutputStream?)GetProperty("output-stream")!; }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.InputStream']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public GISharp.Lib.Gio.InputStream InputStream { get => GetInputStream(); }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.OutputStream']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public GISharp.Lib.Gio.OutputStream OutputStream { get => GetOutputStream(); }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.IsClosed']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Boolean IsClosed { get => GetIsClosed(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected IOStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_io_stream_get_type();

        /// <summary>
        /// Finishes an asynchronous io stream splice operation.
        /// </summary>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_splice_finish(
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void SpliceFinish(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                g_io_stream_splice_finish(result_, &error_);
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
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

        /// <summary>
        /// Clears the pending flag on @stream.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_io_stream_clear_pending(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);
        partial void CheckClearPendingArgs();

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.ClearPending()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void ClearPending()
        {
            CheckClearPendingArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            g_io_stream_clear_pending(stream_);
        }

        /// <summary>
        /// Closes the stream, releasing resources related to it. This will also
        /// close the individual input and output streams, if they are not already
        /// closed.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return
        /// %G_IO_ERROR_CLOSED. Closing a stream multiple times will not
        /// return an error.
        /// 
        /// Closing a stream will automatically flush any outstanding buffers
        /// in the stream.
        /// 
        /// Streams will be automatically closed when the last reference
        /// is dropped, but you might want to call this function to make sure
        /// resources are released as early as possible.
        /// 
        /// Some streams might keep the backing store of the stream (e.g. a file
        /// descriptor) open after the stream is closed. See the documentation for
        /// the individual stream for details.
        /// 
        /// On failure the first error that happened will be reported, but the
        /// close operation will finish as much as possible. A stream that failed
        /// to close will still return %G_IO_ERROR_CLOSED for all operations.
        /// Still, it is important to check and report the error to the user,
        /// otherwise there might be a loss of data as all data might not be written.
        /// 
        /// If @cancellable is not NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// Cancelling a close will still leave the stream closed, but some streams
        /// can use a faster close that doesn't block to e.g. check errors.
        /// 
        /// The default implementation of this method just calls close on the
        /// individual input/output streams.
        /// </remarks>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE on failure
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_close(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        partial void CheckCloseArgs(GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.Close(GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void Close(GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckCloseArgs(cancellable);
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            g_io_stream_close(stream_, cancellable_, &error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Requests an asynchronous close of the stream, releasing resources
        /// related to it. When the operation is finished @callback will be
        /// called. You can then call g_io_stream_close_finish() to get
        /// the result of the operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see g_io_stream_close().
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_io_stream_close_async(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="AsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        partial void CheckCloseAsyncArgs(int ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.CloseAsync(int,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Threading.Tasks.Task CloseAsync(int ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckCloseAsyncArgs(ioPriority, cancellable);
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ioPriority_ = (int)ioPriority;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>();
            var callback_ = (delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&CloseFinish;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_io_stream_close_async(stream_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Closes a stream.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if stream was successfully closed, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_close_finish(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void CloseFinish(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, System.IntPtr userData_)
        {
            try
            {
                var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)sourceObject_;
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                g_io_stream_close_finish(stream_, result_, &error_);
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
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

        /// <summary>
        /// Gets the input stream for this object. This is used
        /// for reading.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <returns>
        /// a #GInputStream, owned by the #GIOStream.
        /// Do not free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.Gio.InputStream.UnmanagedStruct* g_io_stream_get_input_stream(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);
        partial void CheckGetInputStreamArgs();

        [GISharp.Runtime.SinceAttribute("2.22")]
        private GISharp.Lib.Gio.InputStream GetInputStream()
        {
            CheckGetInputStreamArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_io_stream_get_input_stream(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Gets the output stream for this object. This is used for
        /// writing.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <returns>
        /// a #GOutputStream, owned by the #GIOStream.
        /// Do not free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.Gio.OutputStream.UnmanagedStruct* g_io_stream_get_output_stream(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);
        partial void CheckGetOutputStreamArgs();

        [GISharp.Runtime.SinceAttribute("2.22")]
        private GISharp.Lib.Gio.OutputStream GetOutputStream()
        {
            CheckGetOutputStreamArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_io_stream_get_output_stream(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.OutputStream>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Checks if a stream has pending actions.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <returns>
        /// %TRUE if @stream has pending actions.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_has_pending(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);
        partial void CheckHasPendingArgs();

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.HasPending()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Boolean HasPending()
        {
            CheckHasPendingArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_io_stream_has_pending(stream_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Checks if a stream is closed.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <returns>
        /// %TRUE if the stream is closed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_is_closed(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);
        partial void CheckGetIsClosedArgs();

        [GISharp.Runtime.SinceAttribute("2.22")]
        private System.Boolean GetIsClosed()
        {
            CheckGetIsClosedArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_io_stream_is_closed(stream_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Sets @stream to have actions pending. If the pending flag is
        /// already set or @stream is closed, it will return %FALSE and set
        /// @error.
        /// </summary>
        /// <param name="stream">
        /// a #GIOStream
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if pending was previously unset and is now set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        private static extern GISharp.Runtime.Boolean g_io_stream_set_pending(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        partial void CheckSetPendingArgs();

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.SetPending()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public void SetPending()
        {
            CheckSetPendingArgs();
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            g_io_stream_set_pending(stream_, &error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Asynchronously splice the output stream of @stream1 to the input stream of
        /// @stream2, and splice the output stream of @stream2 to the input stream of
        /// @stream1.
        /// </summary>
        /// <remarks>
        /// When the operation is finished @callback will be called.
        /// You can then call g_io_stream_splice_finish() to get the
        /// result of the operation.
        /// </remarks>
        /// <param name="stream1">
        /// a #GIOStream.
        /// </param>
        /// <param name="stream2">
        /// a #GIOStream.
        /// </param>
        /// <param name="flags">
        /// a set of #GIOStreamSpliceFlags.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// a #GAsyncReadyCallback.
        /// </param>
        /// <param name="userData">
        /// user data passed to @callback.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_io_stream_splice_async(
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream1,
        /* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream2,
        /* <type name="IOStreamSpliceFlags" type="GIOStreamSpliceFlags" managed-name="IOStreamSpliceFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.IOStreamSpliceFlags flags,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="AsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        partial void CheckSpliceAsyncArgs(GISharp.Lib.Gio.IOStream stream2, GISharp.Lib.Gio.IOStreamSpliceFlags flags, int ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.SpliceAsync(GISharp.Lib.Gio.IOStream,GISharp.Lib.Gio.IOStreamSpliceFlags,int,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public System.Threading.Tasks.Task SpliceAsync(GISharp.Lib.Gio.IOStream stream2, GISharp.Lib.Gio.IOStreamSpliceFlags flags, int ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckSpliceAsyncArgs(stream2, flags, ioPriority, cancellable);
            var stream1_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var stream2_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)stream2.UnsafeHandle;
            var flags_ = (GISharp.Lib.Gio.IOStreamSpliceFlags)flags;
            var ioPriority_ = (int)ioPriority;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Runtime.Void>();
            var callback_ = (delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&SpliceFinish;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_io_stream_splice_async(stream1_, stream2_, flags_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.DoCloseAsync(int,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IOStreamClass.UnmanagedCloseAsync))]
        protected virtual void DoCloseAsync(int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ioPriority_ = (int)ioPriority;
            var callback_ = callback is null ? default : (delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&GISharp.Lib.Gio.AsyncReadyCallbackMarshal.Callback;
            var callbackHandle = callback is null ? default : System.Runtime.InteropServices.GCHandle.Alloc((callback, GISharp.Runtime.CallbackScope.Async));
            var userData_ = (System.IntPtr)callbackHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<IOStreamClass.UnmanagedCloseAsync>(_GType)!(stream_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.DoCloseFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IOStreamClass.UnmanagedCloseFinish))]
        protected virtual void DoCloseFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var result_ = (GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*)result.UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<IOStreamClass.UnmanagedCloseFinish>(_GType)!(stream_, result_, &error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.DoCloseFn(GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IOStreamClass.UnmanagedCloseFn))]
        protected virtual void DoCloseFn(GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<IOStreamClass.UnmanagedCloseFn>(_GType)!(stream_, cancellable_, &error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.DoGetInputStream()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IOStreamClass.UnmanagedGetInputStream))]
        protected virtual GISharp.Lib.Gio.InputStream DoGetInputStream()
        {
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<IOStreamClass.UnmanagedGetInputStream>(_GType)!(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <include file="IOStream.xmldoc" path="declaration/member[@name='IOStream.DoGetOutputStream()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IOStreamClass.UnmanagedGetOutputStream))]
        protected virtual GISharp.Lib.Gio.OutputStream DoGetOutputStream()
        {
            var stream_ = (GISharp.Lib.Gio.IOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<IOStreamClass.UnmanagedGetOutputStream>(_GType)!(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.OutputStream>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }
    }
}