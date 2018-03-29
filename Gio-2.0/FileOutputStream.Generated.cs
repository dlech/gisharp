namespace GISharp.Lib.Gio
{
    /// <summary>
    /// GFileOutputStream provides output streams that write their
    /// content to a file.
    /// </summary>
    /// <remarks>
    /// GFileOutputStream implements <see cref="ISeekable"/>, which allows the output
    /// stream to jump to arbitrary positions in the file and to truncate
    /// the file, provided the filesystem of the file supports these
    /// operations.
    /// 
    /// To find the position of a file output stream, use <see cref="ISeekable.Tell"/>.
    /// To find out if a file output stream supports seeking, use
    /// <see cref="ISeekable.CanSeek"/>.To position a file output stream, use
    /// <see cref="ISeekable.Seek"/>. To find out if a file output stream supports
    /// truncating, use <see cref="ISeekable.CanTruncate"/>. To truncate a file output
    /// stream, use <see cref="ISeekable.Truncate"/>.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GFileOutputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(FileOutputStreamClass))]
    public partial class FileOutputStream : GISharp.Lib.Gio.OutputStream, GISharp.Lib.Gio.ISeekable
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_output_stream_get_type();

        unsafe protected new struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.Gio.OutputStream.Struct ParentInstance;
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// Gets the entity tag for the file when it has been written.
        /// This must be called after the stream has been written
        /// and closed, as the etag can change while writing.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 Etag { get => GetEtag(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileOutputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_output_stream_get_type();

        /// <summary>
        /// Gets the entity tag for the file when it has been written.
        /// This must be called after the stream has been written
        /// and closed, as the etag can change while writing.
        /// </summary>
        /// <param name="stream">
        /// a #GFileOutputStream.
        /// </param>
        /// <returns>
        /// the entity tag for the stream.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_output_stream_get_etag(
        /* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream);

        /// <summary>
        /// Gets the entity tag for the file when it has been written.
        /// This must be called after the stream has been written
        /// and closed, as the etag can change while writing.
        /// </summary>
        /// <returns>
        /// the entity tag for the stream.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetEtag()
        {
            var stream_ = Handle;
            var ret_ = g_file_output_stream_get_etag(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries a file output stream for the given @attributes.
        /// This function blocks while querying the stream. For the asynchronous
        /// version of this function, see g_file_output_stream_query_info_async().
        /// While the stream is blocked, the stream will set the pending flag
        /// internally, and any other operations on the stream will fail with
        /// %G_IO_ERROR_PENDING.
        /// </summary>
        /// <remarks>
        /// Can fail if the stream was already closed (with @error being set to
        /// %G_IO_ERROR_CLOSED), the stream has pending operations (with @error being
        /// set to %G_IO_ERROR_PENDING), or if querying info is not supported for
        /// the stream's interface (with @error being set to %G_IO_ERROR_NOT_SUPPORTED). In
        /// all cases of failure, %NULL will be returned.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be set, and %NULL will
        /// be returned.
        /// </remarks>
        /// <param name="stream">
        /// a #GFileOutputStream.
        /// </param>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a #GFileInfo for the @stream, or %NULL on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_output_stream_query_info(
        /* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attributes,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Queries a file output stream for the given <paramref name="attributes"/>.
        /// This function blocks while querying the stream. For the asynchronous
        /// version of this function, see <see cref="FileOutputStream.QueryInfoAsync"/>.
        /// While the stream is blocked, the stream will set the pending flag
        /// internally, and any other operations on the stream will fail with
        /// <see cref="IOErrorEnum.Pending"/>.
        /// </summary>
        /// <remarks>
        /// Can fail if the stream was already closed (with <paramref name="error"/> being set to
        /// <see cref="IOErrorEnum.Closed"/>), the stream has pending operations (with <paramref name="error"/> being
        /// set to <see cref="IOErrorEnum.Pending"/>), or if querying info is not supported for
        /// the stream's interface (with <paramref name="error"/> being set to <see cref="IOErrorEnum.NotSupported"/>). In
        /// all cases of failure, <c>null</c> will be returned.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be set, and <c>null</c> will
        /// be returned.
        /// </remarks>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a <see cref="FileInfo"/> for the <paramref name="stream"/>, or <c>null</c> on error.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.Utf8 attributes, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes?.Handle ?? throw new System.ArgumentNullException(nameof(attributes));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_file_output_stream_query_info(stream_,attributes_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Asynchronously queries the @stream for a #GFileInfo. When completed,
        /// @callback will be called with a #GAsyncResult which can be used to
        /// finish the operation with g_file_output_stream_query_info_finish().
        /// </summary>
        /// <remarks>
        /// For the synchronous version of this function, see
        /// g_file_output_stream_query_info().
        /// </remarks>
        /// <param name="stream">
        /// a #GFileOutputStream.
        /// </param>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][gio-GIOScheduler] of the request
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
*   <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_output_stream_query_info_async(
        /* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attributes,
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
        /// Asynchronously queries the <paramref name="stream"/> for a <see cref="FileInfo"/>. When completed,
        /// <paramref name="callback"/> will be called with a <see cref="IAsyncResult"/> which can be used to
        /// finish the operation with <see cref="FileOutputStream.QueryInfoFinish"/>.
        /// </summary>
        /// <remarks>
        /// For the synchronous version of this function, see
        /// <see cref="FileOutputStream.QueryInfo"/>.
        /// </remarks>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][gio-GIOScheduler] of the request
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        public unsafe System.Threading.Tasks.Task<GISharp.Lib.Gio.FileInfo> QueryInfoAsync(GISharp.Lib.GLib.Utf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes?.Handle ?? throw new System.ArgumentNullException(nameof(attributes));
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>();
            var callback_ = queryInfoAsyncCallbackDelegate;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_file_output_stream_query_info_async(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finalizes the asynchronous query started
        /// by g_file_output_stream_query_info_async().
        /// </summary>
        /// <param name="stream">
        /// a #GFileOutputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// A #GFileInfo for the finished query.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_output_stream_query_info_finish(
        /* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        static unsafe void QueryInfoFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>)userData.Target;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_file_output_stream_query_info_finish(stream_,result_,&error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full);
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback queryInfoAsyncCallbackDelegate = QueryInfoFinish;

        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedCanSeek))]
        protected virtual unsafe System.Boolean DoCanSeek()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedCanSeek>(_GType)(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedCanTruncate))]
        protected virtual unsafe System.Boolean DoCanTruncate()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedCanTruncate>(_GType)(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the entity tag for the file when it has been written.
        /// This must be called after the stream has been written
        /// and closed, as the etag can change while writing.
        /// </summary>
        /// <returns>
        /// the entity tag for the stream.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedGetEtag))]
        protected virtual unsafe GISharp.Lib.GLib.Utf8 DoGetEtag()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedGetEtag>(_GType)(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Queries a file output stream for the given <paramref name="attributes"/>.
        /// This function blocks while querying the stream. For the asynchronous
        /// version of this function, see <see cref="FileOutputStream.QueryInfoAsync"/>.
        /// While the stream is blocked, the stream will set the pending flag
        /// internally, and any other operations on the stream will fail with
        /// <see cref="IOErrorEnum.Pending"/>.
        /// </summary>
        /// <remarks>
        /// Can fail if the stream was already closed (with <paramref name="error"/> being set to
        /// <see cref="IOErrorEnum.Closed"/>), the stream has pending operations (with <paramref name="error"/> being
        /// set to <see cref="IOErrorEnum.Pending"/>), or if querying info is not supported for
        /// the stream's interface (with <paramref name="error"/> being set to <see cref="IOErrorEnum.NotSupported"/>). In
        /// all cases of failure, <c>null</c> will be returned.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be set, and <c>null</c> will
        /// be returned.
        /// </remarks>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// a <see cref="FileInfo"/> for the <paramref name="stream"/>, or <c>null</c> on error.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedQueryInfo))]
        protected virtual unsafe GISharp.Lib.Gio.FileInfo DoQueryInfo(GISharp.Lib.GLib.Utf8 attributes, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes?.Handle ?? throw new System.ArgumentNullException(nameof(attributes));
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedQueryInfo>(_GType)(stream_,attributes_,cancellable_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Asynchronously queries the <paramref name="stream"/> for a <see cref="FileInfo"/>. When completed,
        /// <paramref name="callback"/> will be called with a <see cref="IAsyncResult"/> which can be used to
        /// finish the operation with <see cref="FileOutputStream.QueryInfoFinish"/>.
        /// </summary>
        /// <remarks>
        /// For the synchronous version of this function, see
        /// <see cref="FileOutputStream.QueryInfo"/>.
        /// </remarks>
        /// <param name="attributes">
        /// a file attribute query string.
        /// </param>
        /// <param name="ioPriority">
        /// the [I/O priority][gio-GIOScheduler] of the request
        /// </param>
        /// <param name="callback">
        /// callback to call when the request is satisfied
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedQueryInfoAsync))]
        protected virtual unsafe void DoQueryInfoAsync(GISharp.Lib.GLib.Utf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes?.Handle ?? throw new System.ArgumentNullException(nameof(attributes));
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = callback == null ? (default(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedQueryInfoAsync>(_GType)(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <summary>
        /// Finalizes the asynchronous query started
        /// by <see cref="FileOutputStream.QueryInfoAsync"/>.
        /// </summary>
        /// <param name="result">
        /// a <see cref="IAsyncResult"/>.
        /// </param>
        /// <returns>
        /// A <see cref="FileInfo"/> for the finished query.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedQueryInfoFinish))]
        protected virtual unsafe GISharp.Lib.Gio.FileInfo DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result?.Handle ?? throw new System.ArgumentNullException(nameof(result));
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedQueryInfoFinish>(_GType)(stream_,result_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedSeek))]
        protected virtual unsafe void DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var offset_ = (System.Int64)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedSeek>(_GType)(stream_, offset_, type_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedTell))]
        protected virtual unsafe System.Int64 DoTell()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedTell>(_GType)(stream_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileOutputStreamClass.UnmanagedTruncateFn))]
        protected virtual unsafe void DoTruncateFn(System.Int64 size, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var stream_ = Handle;
            var size_ = (System.Int64)size;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileOutputStreamClass.UnmanagedTruncateFn>(_GType)(stream_, size_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        System.Boolean GISharp.Lib.Gio.ISeekable.DoCanSeek()
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.ISeekable.DoCanTruncate()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable)
        {
            throw new System.NotImplementedException();
        }

        System.Int64 GISharp.Lib.Gio.ISeekable.DoTell()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoTruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable cancellable)
        {
            throw new System.NotImplementedException();
        }
    }
}