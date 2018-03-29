namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="InputStream"/> has functions to read from a stream (<see cref="InputStream.Read"/>),
    /// to close a stream (<see cref="InputStream.Close"/>) and to skip some content
    /// (<see cref="InputStream.Skip"/>).
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
    [GISharp.Runtime.GTypeAttribute("GInputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(InputStreamClass))]
    public abstract partial class InputStream : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_input_stream_get_type();

        unsafe protected new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.Object.Struct ParentInstance;
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        public System.Boolean IsClosed { get => GetIsClosed(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected InputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_input_stream_get_type();

        /// <summary>
        /// Clears the pending flag on @stream.
        /// </summary>
        /// <param name="stream">
        /// input stream
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_input_stream_clear_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Clears the pending flag on <paramref name="stream"/>.
        /// </summary>
        public unsafe void ClearPending()
        {
            var stream_ = Handle;
            g_input_stream_clear_pending(stream_);
        }

        /// <summary>
        /// Closes the stream, releasing resources related to it.
        /// </summary>
        /// <remarks>
        /// Once the stream is closed, all other operations will return %G_IO_ERROR_CLOSED.
        /// Closing a stream multiple times will not return an error.
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
        /// is important to check and report the error to the user.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// Cancelling a close will still leave the stream closed, but some streams
        /// can use a faster close that doesn't block to e.g. check errors.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
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
        static extern unsafe System.Boolean g_input_stream_close(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /// is important to check and report the error to the user.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// Cancelling a close will still leave the stream closed, but some streams
        /// can use a faster close that doesn't block to e.g. check errors.
        /// </remarks>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void Close(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_input_stream_close(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished @callback will be called.
        /// You can then call g_input_stream_close_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see g_input_stream_close().
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
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
        static extern unsafe void g_input_stream_close_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.CloseFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="InputStream.Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
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
            g_input_stream_close_async(stream_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes closing a stream asynchronously, started from g_input_stream_close_async().
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the stream was closed successfully.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_input_stream_close_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
                g_input_stream_close_finish(stream_, result_, &error_);
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
        /// Checks if an input stream has pending actions.
        /// </summary>
        /// <param name="stream">
        /// input stream.
        /// </param>
        /// <returns>
        /// %TRUE if @stream has pending actions.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_input_stream_has_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an input stream has pending actions.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="stream"/> has pending actions.
        /// </returns>
        public unsafe System.Boolean HasPending()
        {
            var stream_ = Handle;
            var ret_ = g_input_stream_has_pending(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        /// <param name="stream">
        /// input stream.
        /// </param>
        /// <returns>
        /// %TRUE if the stream is closed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_input_stream_is_closed(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Checks if an input stream is closed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream is closed.
        /// </returns>
        private unsafe System.Boolean GetIsClosed()
        {
            var stream_ = Handle;
            var ret_ = g_input_stream_is_closed(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to read @count bytes from the stream into the buffer starting at
        /// @buffer. Will block during this read.
        /// </summary>
        /// <remarks>
        /// If count is zero returns zero and does nothing. A value of @count
        /// larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes read into the buffer is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. Zero is returned on end of file
        /// (or if @count is zero),  but never otherwise.
        /// 
        /// The returned @buffer is not a nul-terminated string, it can contain nul bytes
        /// at any position, and this function doesn't nul-terminate the @buffer.
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
        /// a #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes read, or -1 on error, or 0 on end of file.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_input_stream_read(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /// Tries to read <paramref name="count"/> bytes from the stream into the buffer starting at
        /// <paramref name="buffer"/>. Will block during this read.
        /// </summary>
        /// <remarks>
        /// If count is zero returns zero and does nothing. A value of <paramref name="count"/>
        /// larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer is returned.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// The returned <paramref name="buffer"/> is not a nul-terminated string, it can contain nul bytes
        /// at any position, and this function doesn't nul-terminate the <paramref name="buffer"/>.
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
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes read, or -1 on error, or 0 on end of file.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe System.Int32 Read(GISharp.Runtime.IArray<System.Byte> buffer, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_read(stream_,buffer_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to read @count bytes from the stream into the buffer starting at
        /// @buffer. Will block during this read.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_input_stream_read(), except it tries to
        /// read as many bytes as requested, only stopping on an error or end of stream.
        /// 
        /// On a successful read of @count bytes, or if we reached the end of the
        /// stream,  %TRUE is returned, and @bytes_read is set to the number of bytes
        /// read into @buffer.
        /// 
        /// If there is an error during the operation %FALSE is returned and @error
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_read will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around g_input_stream_read().
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
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
        static extern unsafe System.Boolean g_input_stream_read_all(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /* direction:out caller-allocates:0 transfer-ownership:full */
        System.UIntPtr* bytesRead,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Tries to read <paramref name="count"/> bytes from the stream into the buffer starting at
        /// <paramref name="buffer"/>. Will block during this read.
        /// </summary>
        /// <remarks>
        /// This function is similar to <see cref="InputStream.Read"/>, except it tries to
        /// read as many bytes as requested, only stopping on an error or end of stream.
        /// 
        /// On a successful read of <paramref name="count"/> bytes, or if we reached the end of the
        /// stream,  <c>true</c> is returned, and <paramref name="bytesRead"/> is set to the number of bytes
        /// read into <paramref name="buffer"/>.
        /// 
        /// If there is an error during the operation <c>false</c> is returned and <paramref name="error"/>
        /// is set to indicate the error status.
        /// 
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns <c>false</c> (and sets <paramref name="error"/>) then
        /// <paramref name="bytesRead"/> will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around <see cref="InputStream.Read"/>.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe void ReadAll(GISharp.Runtime.IArray<System.Byte> buffer, out System.Int32 bytesRead, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            System.UIntPtr bytesRead_;
            var error_ = System.IntPtr.Zero;
            g_input_stream_read_all(stream_, buffer_, count_, &bytesRead_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            bytesRead = (System.Int32)bytesRead_;
        }

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into the
        /// buffer starting at @buffer.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous equivalent of g_input_stream_read_all().
        /// 
        /// Call g_input_stream_read_all_finish() to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long)
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
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
        static extern unsafe void g_input_stream_read_all_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the
        /// buffer starting at <paramref name="buffer"/>.
        /// </summary>
        /// <remarks>
        /// This is the asynchronous equivalent of <see cref="InputStream.ReadAll"/>.
        /// 
        /// Call <see cref="InputStream.ReadAllFinish"/> to collect the result.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long)
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public unsafe System.Threading.Tasks.Task<System.Int32> ReadAllAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = readAllAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_all_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream read operation started with
        /// g_input_stream_read_all_async().
        /// </summary>
        /// <remarks>
        /// As a special exception to the normal conventions for functions that
        /// use #GError, if this function returns %FALSE (and sets @error) then
        /// @bytes_read will be set to the number of bytes that were successfully
        /// read before the error was encountered.  This functionality is only
        /// available from C.  If you need it from another language then you must
        /// write your own loop around g_input_stream_read_async().
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult
        /// </param>
        /// <param name="bytesRead">
        /// location to store the number of bytes that was read from the stream
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
        static extern unsafe System.Boolean g_input_stream_read_all_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        System.UIntPtr* bytesRead,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void ReadAllFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                System.UIntPtr bytesRead_;
                var error_ = System.IntPtr.Zero;
                g_input_stream_read_all_finish(stream_, result_, &bytesRead_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var bytesRead = (System.Int32)bytesRead_;
                completionSource.SetResult((bytesRead));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readAllAsyncCallbackDelegate = ReadAllFinish;

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into the buffer
        /// starting at @buffer. When the operation is finished @callback will be called.
        /// You can then call g_input_stream_read_finish() to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on @stream, and will
        /// result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if @count is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
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
        static extern unsafe void g_input_stream_read_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the buffer
        /// starting at <paramref name="buffer"/>. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.ReadFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on <paramref name="stream"/>, and will
        /// result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<System.Int32> ReadAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? throw new System.ArgumentNullException(nameof(buffer)), buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = readAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_async(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Like g_input_stream_read(), this tries to read @count bytes from
        /// the stream in a blocking fashion. However, rather than reading into
        /// a user-supplied buffer, this will create a new #GBytes containing
        /// the data that was read. This may be easier to use from language
        /// bindings.
        /// </summary>
        /// <remarks>
        /// If count is zero, returns a zero-length #GBytes and does nothing. A
        /// value of @count larger than %G_MAXSSIZE will cause a
        /// %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, a new #GBytes is returned. It is not an error if the
        /// size of this object is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. A zero-length #GBytes is
        /// returned on end of file (or if @count is zero), but never
        /// otherwise.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error %NULL is returned and @error is set accordingly.
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="count">
        /// maximum number of bytes that will be read from the stream. Common
        /// values include 4096 and 8192.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a new #GBytes, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_input_stream_read_bytes(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
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
        /// Like <see cref="InputStream.Read"/>, this tries to read <paramref name="count"/> bytes from
        /// the stream in a blocking fashion. However, rather than reading into
        /// a user-supplied buffer, this will create a new #GBytes containing
        /// the data that was read. This may be easier to use from language
        /// bindings.
        /// </summary>
        /// <remarks>
        /// If count is zero, returns a zero-length #GBytes and does nothing. A
        /// value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, a new #GBytes is returned. It is not an error if the
        /// size of this object is not the same as the requested size, as it
        /// can happen e.g. near the end of a file. A zero-length #GBytes is
        /// returned on end of file (or if <paramref name="count"/> is zero), but never
        /// otherwise.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// 
        /// On error <c>null</c> is returned and <paramref name="error"/> is set accordingly.
        /// </remarks>
        /// <param name="count">
        /// maximum number of bytes that will be read from the stream. Common
        /// values include 4096 and 8192.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a new #GBytes, or <c>null</c> on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public unsafe GISharp.Lib.GLib.Bytes ReadBytes(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_read_bytes(stream_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Bytes>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Request an asynchronous read of @count bytes from the stream into a
        /// new #GBytes. When the operation is finished @callback will be
        /// called. You can then call g_input_stream_read_bytes_finish() to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed
        /// on @stream, and will result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a
        /// %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the new #GBytes will be passed to the callback. It is
        /// not an error if this is smaller than the requested size, as it can
        /// happen e.g. near the end of a file, but generally we try to read as
        /// many bytes as requested. Zero is returned on end of file (or if
        /// @count is zero), but never otherwise.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
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
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_input_stream_read_bytes_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
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
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into a
        /// new #GBytes. When the operation is finished <paramref name="callback"/> will be
        /// called. You can then call <see cref="InputStream.ReadBytesFinish"/> to get the
        /// result of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed
        /// on <paramref name="stream"/>, and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a
        /// <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the new #GBytes will be passed to the callback. It is
        /// not an error if this is smaller than the requested size, as it can
        /// happen e.g. near the end of a file, but generally we try to read as
        /// many bytes as requested. Zero is returned on end of file (or if
        /// <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding I/O request with higher priority (lower numerical
        /// value) will be executed before an outstanding request with lower
        /// priority. Default priority is %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be read from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public unsafe System.Threading.Tasks.Task<GISharp.Lib.GLib.Bytes> ReadBytesAsync(System.Int32 count, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GLib.Bytes>();
            var callback_ = readBytesAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_read_bytes_async(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous stream read-into-#GBytes operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the newly-allocated #GBytes, or %NULL on error
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Bytes" type="GBytes*" managed-name="GISharp.Lib.GLib.Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_input_stream_read_bytes_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void ReadBytesFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.GLib.Bytes>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_read_bytes_finish(stream_,result_,&error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Bytes>(ret_, GISharp.Runtime.Transfer.Full);
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readBytesAsyncCallbackDelegate = ReadBytesFinish;

        /// <summary>
        /// Finishes an asynchronous stream read operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// number of bytes read in, or -1 on error, or 0 on end of file.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_input_stream_read_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void ReadFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_read_finish(stream_,result_,&error_);
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

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback readAsyncCallbackDelegate = ReadFinish;

        /// <summary>
        /// Sets @stream to have actions pending. If the pending flag is
        /// already set or @stream is closed, it will return %FALSE and set
        /// @error.
        /// </summary>
        /// <param name="stream">
        /// input stream
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
        static extern unsafe System.Boolean g_input_stream_set_pending(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
            g_input_stream_set_pending(stream_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Tries to skip @count bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to g_input_stream_read(), from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_input_stream_skip(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
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
        /// Tries to skip <paramref name="count"/> bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to <see cref="InputStream.Read"/>, from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe System.Int32 Skip(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_input_stream_skip(stream_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Request an asynchronous skip of @count bytes from the stream.
        /// When the operation is finished @callback will be called.
        /// You can then call g_input_stream_skip_finish() to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in %G_IO_ERROR_PENDING errors.
        /// 
        /// A value of @count larger than %G_MAXSSIZE will cause a %G_IO_ERROR_INVALID_ARGUMENT error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if @count is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="stream">
        /// A #GInputStream.
        /// </param>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
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
        static extern unsafe void g_input_stream_skip_async(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
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
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Request an asynchronous skip of <paramref name="count"/> bytes from the stream.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.SkipFinish"/> to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<System.Int32> SkipAsync(System.Int32 count, System.Int32 ioPriority = GISharp.Lib.GLib.Priority.Default, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<System.Int32>();
            var callback_ = skipAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_input_stream_skip_async(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes a stream skip operation.
        /// </summary>
        /// <param name="stream">
        /// a #GInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the size of the bytes skipped, or %-1 on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_input_stream_skip_finish(
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void SkipFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<System.Int32>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_input_stream_skip_finish(stream_,result_,&error_);
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

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback skipAsyncCallbackDelegate = SkipFinish;

        /// <summary>
        /// Requests an asynchronous closes of the stream, releasing resources related to it.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.CloseFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// For behaviour details see <see cref="InputStream.Close"/>.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional cancellable object
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseAsync))]
        protected virtual unsafe void DoCloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedCloseAsync>(_GType)(stream_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes closing a stream asynchronously, started from <see cref="InputStream.CloseAsync"/>.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the stream was closed successfully.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseFinish))]
        protected virtual unsafe void DoCloseFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedCloseFinish>(_GType)(stream_, result_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedCloseFn))]
        protected virtual unsafe void DoCloseFn(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedCloseFn>(_GType)(stream_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Request an asynchronous read of <paramref name="count"/> bytes from the stream into the buffer
        /// starting at <paramref name="buffer"/>. When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.ReadFinish"/> to get the result of the
        /// operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed on <paramref name="stream"/>, and will
        /// result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes read into the buffer will be passed to the
        /// callback. It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to read
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero),  but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value) will
        /// be executed before an outstanding request with lower priority. Default
        /// priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to implement
        /// asynchronicity, so they are optional for inheriting classes. However, if you
        /// override one you must override all.
        /// </remarks>
        /// <param name="buffer">
        /// a buffer to
        ///     read data into (which should be at least count bytes long).
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority]
        /// of the request.
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadAsync))]
        protected virtual unsafe void DoReadAsync(GISharp.Runtime.IArray<System.Byte> buffer, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var (buffer_, count_) = ((System.IntPtr, System.UIntPtr))((buffer?.Data ?? System.IntPtr.Zero, buffer?.Length ?? 0));
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedReadAsync>(_GType)(stream_, buffer_, count_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes an asynchronous stream read operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// number of bytes read in, or -1 on error, or 0 on end of file.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadFinish))]
        protected virtual unsafe System.Int32 DoReadFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedReadFinish>(_GType)(stream_,result_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedReadFn))]
        protected virtual unsafe System.Int32 DoReadFn(System.IntPtr buffer, System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var buffer_ = (System.IntPtr)buffer;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedReadFn>(_GType)(stream_,buffer_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Tries to skip <paramref name="count"/> bytes from the stream. Will block during the operation.
        /// </summary>
        /// <remarks>
        /// This is identical to <see cref="InputStream.Read"/>, from a behaviour standpoint,
        /// but the bytes that are skipped are not returned to the user. Some
        /// streams have an implementation that is more efficient than reading the data.
        /// 
        /// This function is optional for inherited classes, as the default implementation
        /// emulates it using read.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// Number of bytes skipped, or -1 on error
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkip))]
        protected virtual unsafe System.Int32 DoSkip(System.Int32 count, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedSkip>(_GType)(stream_,count_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Request an asynchronous skip of <paramref name="count"/> bytes from the stream.
        /// When the operation is finished <paramref name="callback"/> will be called.
        /// You can then call <see cref="InputStream.SkipFinish"/> to get the result
        /// of the operation.
        /// </summary>
        /// <remarks>
        /// During an async request no other sync and async calls are allowed,
        /// and will result in <see cref="IOErrorEnum.Pending"/> errors.
        /// 
        /// A value of <paramref name="count"/> larger than %G_MAXSSIZE will cause a <see cref="IOErrorEnum.InvalidArgument"/> error.
        /// 
        /// On success, the number of bytes skipped will be passed to the callback.
        /// It is not an error if this is not the same as the requested size, as it
        /// can happen e.g. near the end of a file, but generally we try to skip
        /// as many bytes as requested. Zero is returned on end of file
        /// (or if <paramref name="count"/> is zero), but never otherwise.
        /// 
        /// Any outstanding i/o request with higher priority (lower numerical value)
        /// will be executed before an outstanding request with lower priority.
        /// Default priority is %G_PRIORITY_DEFAULT.
        /// 
        /// The asynchronous methods have a default fallback that uses threads to
        /// implement asynchronicity, so they are optional for inheriting classes.
        /// However, if you override one, you must override all.
        /// </remarks>
        /// <param name="count">
        /// the number of bytes that will be skipped from the stream
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][io-priority] of the request
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkipAsync))]
        protected virtual unsafe void DoSkipAsync(System.Int32 count, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var count_ = (System.UIntPtr)count;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedSkipAsync>(_GType)(stream_, count_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finishes a stream skip operation.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// the size of the bytes skipped, or %-1 on error.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(InputStreamClass.UnmanagedSkipFinish))]
        protected virtual unsafe System.Int32 DoSkipFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<InputStreamClass.UnmanagedSkipFinish>(_GType)(stream_,result_,&error_);
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