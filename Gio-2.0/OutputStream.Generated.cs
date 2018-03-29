namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="OutputStream"/> has functions to write to a stream (<see cref="OutputStream.Write"/>),
    /// to close a stream (<see cref="OutputStream.Close"/>) and to flush pending writes
    /// (<see cref="OutputStream.Flush"/>).
    /// </summary>
    /// <remarks>
    /// To copy the content of an input stream to an output stream without
    /// manually handling the reads and writes, use <see cref="OutputStream.Splice"/>.
    /// 
    /// See the documentation for #GIOStream for details of thread safety of
    /// streaming APIs.
    /// 
    /// All of these functions have async variants too.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GOutputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(OutputStreamClass))]
    public abstract partial class OutputStream : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_output_stream_get_type();

        unsafe protected new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.Object.Struct ParentInstance;
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// Checks if an output stream has already been closed.
        /// </summary>
        public System.Boolean IsClosed { get => GetIsClosed(); }

        /// <summary>
        /// Checks if an output stream is being closed. This can be
        /// used inside e.g. a flush implementation to see if the
        /// flush (or other i/o operation) is called from within
        /// the closing operation.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public System.Boolean IsClosing { get => GetIsClosing(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected OutputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_output_stream_get_type();

        /// <summary>
        /// Clears the pending flag on @stream.
        /// </summary>
        /// <param name="stream">
        /// output stream
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_clear_pending(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Clears the pending flag on <paramref name="stream"/>.
        /// </summary>
        public unsafe void ClearPending()
        {
            var stream_ = Handle;
            g_output_stream_clear_pending(stream_);
        }

        /// <summary>
        /// Closes the stream, releasing resources related to it.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return %G_IO_ERROR_CLOSED.
        /// Closing a stream multiple times will not return an error.
        /// 
        /// Closing a stream will automatically flush any outstanding buffers in the
        /// stream.
        /// 
        /// Streams will be automatically closed when the last reference
        /// is dropped, but you might want to call this function to make sure
        /// resources are released as early as possible.
        /// 
        /// Some streams might keep the backing store of the stream (e.g. a file descriptor)
        /// open after the stream is closed. See the documentation for the individual
        /// stream for details.
        /// 
        /// On failure the first error that happened will be reported, but the close
        /// operation will finish as much as possible. A stream that failed to
        /// close will still return %G_IO_ERROR_CLOSED for all operations. Still, it
        /// is important to check and report the error to the user, otherwise
        /// there might be a loss of data as all data might not be written.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// Cancelling a close will still leave the stream closed, but there some streams
        /// can use a faster close that doesn't block to e.g. check errors. On
        /// cancellation (as with any error) there is no guarantee that all written
        /// data will reach the target.
        /// </remarks>
        /// <param name="stream">
        /// A #GOutputStream.
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE on failure
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_close(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Closes the stream, releasing resources related to it.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return <see cref="IOErrorEnum.Closed"/>.
        /// Closing a stream multiple times will not return an error.
        /// 
        /// Closing a stream will automatically flush any outstanding buffers in the
        /// stream.
        /// 
        /// Streams will be automatically closed when the last reference
        /// is dropped, but you might want to call this function to make sure
        /// resources are released as early as possible.
        /// 
        /// Some streams might keep the backing store of the stream (e.g. a file descriptor)
        /// open after the stream is closed. See the documentation for the individual
        /// stream for details.
        /// 
        /// On failure the first error that happened will be reported, but the close
        /// operation will finish as much as possible. A stream that failed to
        /// close will still return <see cref="IOErrorEnum.Closed"/> for all operations. Still, it
        /// is important to check and report the error to the user, otherwise
        /// there might be a loss of data as all data might not be written.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// Cancelling a close will still leave the stream closed, but there some streams
        /// can use a faster close that doesn't block to e.g. check errors. On
        /// cancellation (as with any error) there is no guarantee that all written
        /// data will reach the target.
        /// </remarks>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void Close(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_output_stream_close(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Requests an asynchronous close of the stream, releasing resources
        /// related to it. When the operation is finished @callback will be
        /// called. You can then call g_output_stream_close_finish() to get
        /// the result of the operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see g_output_stream_close().
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GOutputStream.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
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
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_close_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Requests an asynchronous close of the stream, releasing resources
        /// related to it. When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="OutputStream.CloseFinish"/> to get
        /// the result of the operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="OutputStream.Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        public unsafe System.Threading.Tasks.Task CloseAsync(System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Object>();
            var callback_ = closeAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_close_async(stream_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Closes an output stream.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if stream was successfully closed, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_close_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void CloseFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Object>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                g_output_stream_close_finish(stream_, result_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                completionSource.SetResult(null);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback closeAsyncCallbackDelegate = CloseFinish;

        /// <summary>
        /// Forces a write of all user-space buffered data for the given
        /// @stream. Will block during the operation. Closing the stream will
        /// implicitly cause a flush.
        /// </summary>
        /// <remarks>
        /// This function is optional for inherited classes.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE on error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_flush(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Forces a write of all user-space buffered data for the given
        /// <paramref name="stream"/>. Will block during the operation. Closing the stream will
        /// implicitly cause a flush.
        /// </summary>
        /// <remarks>
        /// This function is optional for inherited classes.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// </remarks>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void Flush(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_output_stream_flush(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Forces an asynchronous write of all user-space buffered data for
        /// the given @stream.
        /// For behaviour details see g_output_stream_flush().
        /// </summary>
        /// <remarks>
        /// When the operation is finished @callback will be
        /// called. You can then call g_output_stream_flush_finish() to get the
        /// result of the operation.
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
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
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_flush_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:3 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Forces an asynchronous write of all user-space buffered data for
        /// the given <paramref name="stream"/>.
        /// For behaviour details see <see cref="OutputStream.Flush"/>.
        /// </summary>
        /// <remarks>
        /// When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="OutputStream.FlushFinish"/> to get the
        /// result of the operation.
        /// </remarks>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task FlushAsync(System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Object>();
            var callback_ = flushAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_flush_async(stream_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes flushing an output stream.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="result">
        /// a GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if flush operation succeeded, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_flush_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void FlushFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Object>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                g_output_stream_flush_finish(stream_, result_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                completionSource.SetResult(null);
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback flushAsyncCallbackDelegate = FlushFinish;

        /// <summary>
        /// Checks if an output stream has pending actions.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <returns>
        /// %TRUE if @stream has pending actions.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_output_stream_has_pending(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an output stream has pending actions.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="stream"/> has pending actions.
        /// </returns>
        public unsafe System.Boolean HasPending()
        {
            var stream_ = Handle;
            var ret_ = g_output_stream_has_pending(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if an output stream has already been closed.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <returns>
        /// %TRUE if @stream is closed. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_output_stream_is_closed(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an output stream has already been closed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="stream"/> is closed. <c>false</c> otherwise.
        /// </returns>
        private unsafe System.Boolean GetIsClosed()
        {
            var stream_ = Handle;
            var ret_ = g_output_stream_is_closed(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if an output stream is being closed. This can be
        /// used inside e.g. a flush implementation to see if the
        /// flush (or other i/o operation) is called from within
        /// the closing operation.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <returns>
        /// %TRUE if @stream is being closed. %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_output_stream_is_closing(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an output stream is being closed. This can be
        /// used inside e.g. a flush implementation to see if the
        /// flush (or other i/o operation) is called from within
        /// the closing operation.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="stream"/> is being closed. <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        private unsafe System.Boolean GetIsClosing()
        {
            var stream_ = Handle;
            var ret_ = g_output_stream_is_closing(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets @stream to have actions pending. If the pending flag is
        /// already set or @stream is closed, it will return %FALSE and set
        /// @error.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if pending was previously unset and is now set.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_set_pending(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Sets <paramref name="stream"/> to have actions pending. If the pending flag is
        /// already set or <paramref name="stream"/> is closed, it will return <c>false</c> and set
        /// <paramref name="error"/>.
        /// </summary>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void SetPending()
        {
            var stream_ = Handle;
            var error_ = System.IntPtr.Zero;
            g_output_stream_set_pending(stream_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Splices an input stream into an output stream.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="source">
        /// a #GInputStream.
        /// </param>
        /// <param name="flags">
        /// a set of #GOutputStreamSpliceFlags.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a #gssize containing the size of the data spliced, or
        ///     -1 if an error occurred. Note that if the number of bytes
        ///     spliced is greater than %G_MAXSSIZE, then that will be
        ///     returned, and there is no way to determine the actual number
        ///     of bytes spliced.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_splice(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr source,
        /* <type name="OutputStreamSpliceFlags" type="GOutputStreamSpliceFlags" managed-name="OutputStreamSpliceFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.OutputStreamSpliceFlags flags,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Splices an input stream into an output stream.
        /// </summary>
        /// <param name="source">
        /// a <see cref="InputStream"/>.
        /// </param>
        /// <param name="flags">
        /// a set of <see cref="OutputStreamSpliceFlags"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a #gssize containing the size of the data spliced, or
        ///     -1 if an error occurred. Note that if the number of bytes
        ///     spliced is greater than %G_MAXSSIZE, then that will be
        ///     returned, and there is no way to determine the actual number
        ///     of bytes spliced.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe System.Int32 Splice(GISharp.Lib.Gio.InputStream source, GISharp.Lib.Gio.OutputStreamSpliceFlags flags, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var source_ = source?.Handle ?? throw new System.ArgumentNullException(nameof(source));
            var flags_ = (GISharp.Lib.Gio.OutputStreamSpliceFlags)flags;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_output_stream_splice(stream_,source_,flags_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Splices a stream asynchronously.
        /// When the operation is finished @callback will be called.
        /// You can then call g_output_stream_splice_finish() to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// For the synchronous, blocking version of this function, see
        /// g_output_stream_splice().
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="source">
        /// a #GInputStream.
        /// </param>
        /// <param name="flags">
        /// a set of #GOutputStreamSpliceFlags.
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
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gssize" type="gssize" managed-name="System.Int32" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_splice_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr source,
        /* <type name="OutputStreamSpliceFlags" type="GOutputStreamSpliceFlags" managed-name="OutputStreamSpliceFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.OutputStreamSpliceFlags flags,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Splices a stream asynchronously.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="OutputStream.SpliceFinish"/> to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// For the synchronous, blocking version of this function, see
        /// <see cref="OutputStream.Splice"/>.
        /// </remarks>
        /// <param name="source">
        /// a <see cref="InputStream"/>.
        /// </param>
        /// <param name="flags">
        /// a set of <see cref="OutputStreamSpliceFlags"/>.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<System.Int32> SpliceAsync(GISharp.Lib.Gio.InputStream source, GISharp.Lib.Gio.OutputStreamSpliceFlags flags, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var source_ = source?.Handle ?? throw new System.ArgumentNullException(nameof(source));
            var flags_ = (GISharp.Lib.Gio.OutputStreamSpliceFlags)flags;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = spliceAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_splice_async(stream_, source_, flags_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream splice operation.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a #gssize of the number of bytes spliced. Note that if the
        ///     number of bytes spliced is greater than %G_MAXSSIZE, then that
        ///     will be returned, and there is no way to determine the actual
        ///     number of bytes spliced.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_splice_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void SpliceFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_output_stream_splice_finish(stream_,result_,&error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = (System.Int32)ret_;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback spliceAsyncCallbackDelegate = SpliceFinish;

        /// <summary>
        /// Tries to write @count bytes from @buffer into the stream. Will block
        /// during the operation.
        /// </summary>
        /// <remarks>
        /// If count is 0, returns 0 and does nothing. A value of @count
        /// larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes written to the stream is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. on a partial I/O error, or if there is not enough
        /// storage in the stream. All writes block until at least one byte
        /// is written or an error occurs; 0 is never returned (unless
        /// @count is 0).
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error -1 is returned and @error is set accordingly.
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="count">
        /// the number of bytes to write
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes written, or -1 on error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_write(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Tries to write <paramref name="count"/> bytes from <paramref name="buffer"/> into the stream. Will block
        /// during the operation.
        /// </summary>
        /// <remarks>
        /// If count is 0, returns 0 and does nothing. A value of <paramref name="count"/>
        /// larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes written to the stream is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. on a partial I/O error, or if there is not enough
        /// storage in the stream. All writes block until at least one byte
        /// is written or an error occurs; 0 is never returned (unless
        /// <paramref name="count"/> is 0).
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error -1 is returned and <paramref name="error"/> is set accordingly.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <returns>
        /// Number of bytes written, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe System.Int32 Write(GISharp.Runtime.IArray<System.Byte> buffer, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_output_stream_write(stream_,buffer_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to write @count bytes from @buffer into the stream. Will block
        /// during the operation.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_output_stream_write(), except it tries to
        /// write as many bytes as requested, only stopping on an error.
        /// 
        /// On a successful write of @count bytes, %TRUE is returned, and @bytes_written
        /// is set to @count.
        /// 
        /// If there is an error during the operation %FALSE is returned and @error
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_written will be set to the number of bytes that were
        /// successfully written before the error was encountered.  This
        /// functionality is only available from C.  If you need it from another
        /// language then you must write your own loop around
        /// g_output_stream_write().
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="count">
        /// the number of bytes to write
        /// </param>
        /// <param name="bytesWritten">
        /// location to store the number of bytes that was
        ///     written to the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE if there was an error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_write_all(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* bytesWritten,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Tries to write <paramref name="count"/> bytes from <paramref name="buffer"/> into the stream. Will block
        /// during the operation.
        /// </summary>
        /// <remarks>
        /// This function is similar to <see cref="OutputStream.Write"/>, except it tries to
        /// write as many bytes as requested, only stopping on an error.
        /// 
        /// On a successful write of <paramref name="count"/> bytes, <c>true</c> is returned, and <paramref name="bytesWritten"/>
        /// is set to <paramref name="count"/>.
        /// 
        /// If there is an error during the operation <c>false</c> is returned and <paramref name="error"/>
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns <c>false</c> (and sets <paramref name="error"/>) then
        /// <paramref name="bytesWritten"/> will be set to the number of bytes that were
        /// successfully written before the error was encountered.  This
        /// functionality is only available from C.  If you need it from another
        /// language then you must write your own loop around
        /// <see cref="OutputStream.Write"/>.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="bytesWritten">
        /// location to store the number of bytes that was
        ///     written to the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void WriteAll(GISharp.Runtime.IArray<System.Byte> buffer, out System.Int32 bytesWritten, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            System.UIntPtr bytesWritten_;
            var error_ = System.IntPtr.Zero;
            g_output_stream_write_all(stream_, buffer_, count_, &bytesWritten_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            bytesWritten = (System.Int32)bytesWritten_;
        }

        /// <summary>
        /// Request an asynchronous write of @count bytes from @buffer into
        /// the stream. When the operation is finished @callback will be called.
        /// You can then call g_output_stream_write_all_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous version of g_output_stream_write_all().
        /// 
        /// Call g_output_stream_write_all_finish() to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// Note that no copy of @buffer will be made, so it must stay valid
        /// until @callback is called.
        /// </remarks>
        /// <param name="stream">
        /// A #GOutputStream
        /// </param>
        /// <param name="buffer">
        /// the buffer containing the data to write
        /// </param>
        /// <param name="count">
        /// the number of bytes to write
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_write_all_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous write of <paramref name="count"/> bytes from <paramref name="buffer"/> into
        /// the stream. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="OutputStream.WriteAllFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous version of <see cref="OutputStream.WriteAll"/>.
        /// 
        /// Call <see cref="OutputStream.WriteAllFinish"/> to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// Note that no copy of <paramref name="buffer"/> will be made, so it must stay valid
        /// until <paramref name="callback"/> is called.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public unsafe System.Threading.Tasks.Task<System.Int32> WriteAllAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = writeAllAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_write_all_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream write operation started with
        /// g_output_stream_write_all_async().
        /// </summary>
        /// <remarks>
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_written will be set to the number of bytes that were
        /// successfully written before the error was encountered.  This
        /// functionality is only available from C.  If you need it from another
        /// language then you must write your own loop around
        /// g_output_stream_write_async().
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult
        /// </param>
        /// <param name="bytesWritten">
        /// location to store the number of bytes that was written to the stream
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE on success, %FALSE if there was an error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_output_stream_write_all_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* bytesWritten,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void WriteAllFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                System.UIntPtr bytesWritten_;
                var error_ = System.IntPtr.Zero;
                g_output_stream_write_all_finish(stream_, result_, &bytesWritten_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var bytesWritten = (System.Int32)bytesWritten_;
                completionSource.SetResult((bytesWritten));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback writeAllAsyncCallbackDelegate = WriteAllFinish;

        /// <summary>
        /// Request an asynchronous write of @count bytes from @buffer into
        /// the stream. When the operation is finished @callback will be called.
        /// You can then call g_output_stream_write_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a
        /// %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes written will be passed to the
        /// @callback. It is not an error if this is not the same as the
        /// requested size, as it can happen e.g. on a partial I/O error,
        /// but generally we try to write as many bytes as requested.
        /// 
        /// You are guaranteed that this method will never fail with
        /// %G_IO_ERROR_WOULD_BLOCK - if @stream can't accept more data, the
        /// method will just wait until this changes.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// 
        /// For the synchronous, blocking version of this function, see
        /// g_output_stream_write().
        /// 
        /// Note that no copy of @buffer will be made, so it must stay valid
        /// until @callback is called. See g_output_stream_write_bytes_async()
        /// for a #GBytes version that will automatically hold a reference to
        /// the contents (without copying) for the duration of the call.
        /// </remarks>
        /// <param name="stream">
        /// A #GOutputStream.
        /// </param>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="count">
        /// the number of bytes to write
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gssize" type="gssize" managed-name="System.Int32" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_write_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <array length="1" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr buffer,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr count,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous write of <paramref name="count"/> bytes from <paramref name="buffer"/> into
        /// the stream. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="OutputStream.WriteFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes written will be passed to the
        /// <paramref name="callback"/>. It is not an error if this is not the same as the
        /// requested size, as it can happen e.g. on a partial I/O error,
        /// but generally we try to write as many bytes as requested.
        /// 
        /// You are guaranteed that this method will never fail with
        /// <see cref="IOErrorEnum.WouldBlock"/> - if <paramref name="stream"/> can't accept more data, the
        /// method will just wait until this changes.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// 
        /// For the synchronous, blocking version of this function, see
        /// <see cref="OutputStream.Write"/>.
        /// 
        /// Note that no copy of <paramref name="buffer"/> will be made, so it must stay valid
        /// until <paramref name="callback"/> is called. See <see cref="OutputStream.WriteBytesAsync"/>
        /// for a #GBytes version that will automatically hold a reference to
        /// the contents (without copying) for the duration of the call.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<System.Int32> WriteAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = writeAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_write_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// A wrapper function for g_output_stream_write() which takes a
        /// #GBytes as input.  This can be more convenient for use by language
        /// bindings or in other cases where the refcounted nature of #GBytes
        /// is helpful over a bare pointer interface.
        /// </summary>
        /// <remarks>
        /// However, note that this function may still perform partial writes,
        /// just like g_output_stream_write().  If that occurs, to continue
        /// writing, you will need to create a new #GBytes containing just the
        /// remaining bytes, using g_bytes_new_from_bytes(). Passing the same
        /// #GBytes instance multiple times potentially can result in duplicated
        /// data in the output stream.
        /// </remarks>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="bytes">
        /// the #GBytes to write
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes written, or -1 on error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_write_bytes(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr bytes,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// A wrapper function for <see cref="OutputStream.Write"/> which takes a
        /// #GBytes as input.  This can be more convenient for use by language
        /// bindings or in other cases where the refcounted nature of #GBytes
        /// is helpful over a bare pointer interface.
        /// </summary>
        /// <remarks>
        /// However, note that this function may still perform partial writes,
        /// just like <see cref="OutputStream.Write"/>.  If that occurs, to continue
        /// writing, you will need to create a new #GBytes containing just the
        /// remaining bytes, using g_bytes_new_from_bytes(). Passing the same
        /// #GBytes instance multiple times potentially can result in duplicated
        /// data in the output stream.
        /// </remarks>
        /// <param name="bytes">
        /// the #GBytes to write
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <returns>
        /// Number of bytes written, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe System.Int32 WriteBytes(GISharp.Lib.GLib.Bytes bytes, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var bytes_ = bytes?.Handle ?? throw new System.ArgumentNullException(nameof(bytes));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_output_stream_write_bytes(stream_,bytes_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// This function is similar to g_output_stream_write_async(), but
        /// takes a #GBytes as input.  Due to the refcounted nature of #GBytes,
        /// this allows the stream to avoid taking a copy of the data.
        /// </summary>
        /// <remarks>
        /// However, note that this function may still perform partial writes,
        /// just like g_output_stream_write_async(). If that occurs, to continue
        /// writing, you will need to create a new #GBytes containing just the
        /// remaining bytes, using g_bytes_new_from_bytes(). Passing the same
        /// #GBytes instance multiple times potentially can result in duplicated
        /// data in the output stream.
        /// 
        /// For the synchronous, blocking version of this function, see
        /// g_output_stream_write_bytes().
        /// </remarks>
        /// <param name="stream">
        /// A #GOutputStream.
        /// </param>
        /// <param name="bytes">
        /// The bytes to write
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="userData">
        /// the data to pass to callback function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="gssize" type="gssize" managed-name="System.Int32" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_output_stream_write_bytes_async(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr bytes,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// This function is similar to <see cref="OutputStream.WriteAsync"/>, but
        /// takes a #GBytes as input.  Due to the refcounted nature of #GBytes,
        /// this allows the stream to avoid taking a copy of the data.
        /// </summary>
        /// <remarks>
        /// However, note that this function may still perform partial writes,
        /// just like <see cref="OutputStream.WriteAsync"/>. If that occurs, to continue
        /// writing, you will need to create a new #GBytes containing just the
        /// remaining bytes, using g_bytes_new_from_bytes(). Passing the same
        /// #GBytes instance multiple times potentially can result in duplicated
        /// data in the output stream.
        /// 
        /// For the synchronous, blocking version of this function, see
        /// <see cref="OutputStream.WriteBytes"/>.
        /// </remarks>
        /// <param name="bytes">
        /// The bytes to write
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<System.Int32> WriteBytesAsync(GISharp.Lib.GLib.Bytes bytes, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var bytes_ = bytes?.Handle ?? throw new System.ArgumentNullException(nameof(bytes));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = writeBytesAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_output_stream_write_bytes_async(stream_, bytes_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes a stream write-from-#GBytes operation.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a #gssize containing the number of bytes written to the stream.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_write_bytes_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void WriteBytesFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_output_stream_write_bytes_finish(stream_,result_,&error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = (System.Int32)ret_;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback writeBytesAsyncCallbackDelegate = WriteBytesFinish;

        /// <summary>
        /// Finishes a stream write operation.
        /// </summary>
        /// <param name="stream">
        /// a #GOutputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a #gssize containing the number of bytes written to the stream.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_output_stream_write_finish(
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void WriteFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_output_stream_write_finish(stream_,result_,&error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = (System.Int32)ret_;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback writeAsyncCallbackDelegate = WriteFinish;

        /// <summary>
        /// Requests an asynchronous close of the stream, releasing resources
        /// related to it. When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="OutputStream.CloseFinish"/> to get
        /// the result of the operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="OutputStream.Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedCloseAsync))]
        protected virtual unsafe void DoCloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedCloseAsync>(_GType)(stream_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Closes an output stream.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if stream was successfully closed, <c>false</c> otherwise.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedCloseFinish))]
        protected virtual unsafe void DoCloseFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedCloseFinish>(_GType)(stream_, result_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedCloseFn))]
        protected virtual unsafe void DoCloseFn(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedCloseFn>(_GType)(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Forces a write of all user-space buffered data for the given
        /// <paramref name="stream"/>. Will block during the operation. Closing the stream will
        /// implicitly cause a flush.
        /// </summary>
        /// <remarks>
        /// This function is optional for inherited classes.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// </remarks>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <returns>
        /// <c>true</c> on success, <c>false</c> on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedFlush))]
        protected virtual unsafe void DoFlush(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedFlush>(_GType)(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Forces an asynchronous write of all user-space buffered data for
        /// the given <paramref name="stream"/>.
        /// For behaviour details see <see cref="OutputStream.Flush"/>.
        /// </summary>
        /// <remarks>
        /// When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="OutputStream.FlushFinish"/> to get the
        /// result of the operation.
        /// </remarks>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/> to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedFlushAsync))]
        protected virtual unsafe void DoFlushAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedFlushAsync>(_GType)(stream_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes flushing an output stream.
        /// </summary>
        /// <param name="result">
        /// a GAsyncResult.
        /// </param>
        /// <returns>
        /// <c>true</c> if flush operation succeeded, <c>false</c> otherwise.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedFlushFinish))]
        protected virtual unsafe void DoFlushFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedFlushFinish>(_GType)(stream_, result_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Splices an input stream into an output stream.
        /// </summary>
        /// <param name="source">
        /// a <see cref="InputStream"/>.
        /// </param>
        /// <param name="flags">
        /// a set of <see cref="OutputStreamSpliceFlags"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a #gssize containing the size of the data spliced, or
        ///     -1 if an error occurred. Note that if the number of bytes
        ///     spliced is greater than %G_MAXSSIZE, then that will be
        ///     returned, and there is no way to determine the actual number
        ///     of bytes spliced.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedSplice))]
        protected virtual unsafe System.Int32 DoSplice(GISharp.Lib.Gio.InputStream source, GISharp.Lib.Gio.OutputStreamSpliceFlags flags, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var source_ = source?.Handle ?? throw new System.ArgumentNullException(nameof(source));
            var flags_ = (GISharp.Lib.Gio.OutputStreamSpliceFlags)flags;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedSplice>(_GType)(stream_,source_,flags_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Splices a stream asynchronously.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="OutputStream.SpliceFinish"/> to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// For the synchronous, blocking version of this function, see
        /// <see cref="OutputStream.Splice"/>.
        /// </remarks>
        /// <param name="source">
        /// a <see cref="InputStream"/>.
        /// </param>
        /// <param name="flags">
        /// a set of <see cref="OutputStreamSpliceFlags"/>.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="callback">
        /// a <see cref="AsyncReadyCallback"/>.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedSpliceAsync))]
        protected virtual unsafe void DoSpliceAsync(GISharp.Lib.Gio.InputStream source, GISharp.Lib.Gio.OutputStreamSpliceFlags flags, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var source_ = source?.Handle ?? throw new System.ArgumentNullException(nameof(source));
            var flags_ = (GISharp.Lib.Gio.OutputStreamSpliceFlags)flags;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedSpliceAsync>(_GType)(stream_, source_, flags_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes an asynchronous stream splice operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// a #gssize of the number of bytes spliced. Note that if the
        ///     number of bytes spliced is greater than %G_MAXSSIZE, then that
        ///     will be returned, and there is no way to determine the actual
        ///     number of bytes spliced.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedSpliceFinish))]
        protected virtual unsafe System.Int32 DoSpliceFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedSpliceFinish>(_GType)(stream_,result_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Request an asynchronous write of <paramref name="count"/> bytes from <paramref name="buffer"/> into
        /// the stream. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="OutputStream.WriteFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes written will be passed to the
        /// <paramref name="callback"/>. It is not an error if this is not the same as the
        /// requested size, as it can happen e.g. on a partial I/O error,
        /// but generally we try to write as many bytes as requested.
        /// 
        /// You are guaranteed that this method will never fail with
        /// <see cref="IOErrorEnum.WouldBlock"/> - if <paramref name="stream"/> can't accept more data, the
        /// method will just wait until this changes.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads
        /// to implement asynchronicity, so they are optional for inheriting
        /// classes. However, if you override one you must override all.
        /// 
        /// For the synchronous, blocking version of this function, see
        /// <see cref="OutputStream.Write"/>.
        /// 
        /// Note that no copy of <paramref name="buffer"/> will be made, so it must stay valid
        /// until <paramref name="callback"/> is called. See <see cref="OutputStream.WriteBytesAsync"/>
        /// for a #GBytes version that will automatically hold a reference to
        /// the contents (without copying) for the duration of the call.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="ioPriority">
        /// the io priority of the request.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedWriteAsync))]
        protected virtual unsafe void DoWriteAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? System.IntPtr.Zero, buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedWriteAsync>(_GType)(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes a stream write operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// a #gssize containing the number of bytes written to the stream.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedWriteFinish))]
        protected virtual unsafe System.Int32 DoWriteFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedWriteFinish>(_GType)(stream_,result_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to write <paramref name="count"/> bytes from <paramref name="buffer"/> into the stream. Will block
        /// during the operation.
        /// </summary>
        /// <remarks>
        /// If count is 0, returns 0 and does nothing. A value of <paramref name="count"/>
        /// larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes written to the stream is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. on a partial I/O error, or if there is not enough
        /// storage in the stream. All writes block until at least one byte
        /// is written or an error occurs; 0 is never returned (unless
        /// <paramref name="count"/> is 0).
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error -1 is returned and <paramref name="error"/> is set accordingly.
        /// </remarks>
        /// <param name="buffer">
        /// the buffer containing the data to write.
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        /// <returns>
        /// Number of bytes written, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(OutputStreamClass.UnmanagedWriteFn))]
        protected virtual unsafe System.Int32 DoWriteFn(GISharp.Runtime.IArray<System.Byte> buffer, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? System.IntPtr.Zero, buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<OutputStreamClass.UnmanagedWriteFn>(_GType)(stream_,buffer_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }
    }
}