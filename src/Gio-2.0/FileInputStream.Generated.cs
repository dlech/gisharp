// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileInputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(FileInputStreamClass))]
    public partial class FileInputStream : GISharp.Lib.Gio.InputStream, GISharp.Lib.Gio.ISeekable
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_input_stream_get_type();

        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe protected new struct Struct
        {
#pragma warning disable CS0649
            /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='Struct.ParentInstance']/*" />
            public GISharp.Lib.Gio.InputStream.Struct ParentInstance;

            /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='Struct.Priv']/*" />
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileInputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_file_input_stream_get_type();

        /// <summary>
        /// Queries a file input stream the given @attributes. This function blocks
        /// while querying the stream. For the asynchronous (non-blocking) version
        /// of this function, see g_file_input_stream_query_info_async(). While the
        /// stream is blocked, the stream will set the pending flag internally, and
        /// any other operations on the stream will fail with %G_IO_ERROR_PENDING.
        /// </summary>
        /// <param name="stream">
        /// a #GFileInputStream.
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
        /// a #GFileInfo, or %NULL on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_file_input_stream_query_info(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
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
        ref System.IntPtr error);
        static partial void CheckQueryInfoArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.QueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        public unsafe GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoArgs(attributes, cancellable);
            var stream_ = Handle;
            var attributes_ = attributes.Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_file_input_stream_query_info(stream_,attributes_,cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Queries the stream information asynchronously.
        /// When the operation is finished @callback will be called.
        /// You can then call g_file_input_stream_query_info_finish()
        /// to get the result of the operation.
        /// </summary>
        /// <remarks>
        /// For the synchronous version of this function,
        /// see g_file_input_stream_query_info().
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be set
        /// </remarks>
        /// <param name="stream">
        /// a #GFileInputStream.
        /// </param>
        /// <param name="attributes">
        /// a file attribute query string.
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
*   <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void g_file_input_stream_query_info_async(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
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
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        static partial void CheckQueryInfoAsyncArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,System.Int32,GISharp.Lib.Gio.Cancellable?)']/*" />
        public unsafe System.Threading.Tasks.Task<GISharp.Lib.Gio.FileInfo> QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoAsyncArgs(attributes, ioPriority, cancellable);
            var stream_ = Handle;
            var attributes_ = attributes.Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>();
            var callback_ = queryInfoAsyncCallback_;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_file_input_stream_query_info_async(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finishes an asynchronous info query operation.
        /// </summary>
        /// <param name="stream">
        /// a #GFileInputStream.
        /// </param>
        /// <param name="result">
        /// a #GAsyncResult.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// #GFileInfo.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_file_input_stream_query_info_finish(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        static unsafe void QueryInfoFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr userData_)
        {
            try
            {
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>)userData.Target!;
                userData.Free();
                var error_ = System.IntPtr.Zero;
                var ret_ = g_file_input_stream_query_info_finish(stream_,result_,ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full)!;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback queryInfoAsyncCallbackDelegate = QueryInfoFinish;
        static readonly System.IntPtr queryInfoAsyncCallback_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<GISharp.Lib.Gio.UnmanagedAsyncReadyCallback>(queryInfoAsyncCallbackDelegate);

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoCanSeek()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedCanSeek))]
        protected virtual unsafe System.Boolean DoCanSeek()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedCanSeek>(_GType)!(stream_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfo))]
        protected virtual unsafe GISharp.Lib.Gio.FileInfo DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes.Handle;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfo>(_GType)!(stream_,attributes_,cancellable_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,System.Int32,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfoAsync))]
        protected virtual unsafe void DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = Handle;
            var attributes_ = attributes.Handle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = GISharp.Lib.Gio.AsyncReadyCallbackMarshal.ToPointer(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfoAsync>(_GType)!(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfoFinish))]
        protected virtual unsafe GISharp.Lib.Gio.FileInfo DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = Handle;
            var result_ = result.Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfoFinish>(_GType)!(stream_,result_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoSeek(System.Int64,GISharp.Lib.GLib.SeekType,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedSeek))]
        protected virtual unsafe void DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = Handle;
            var offset_ = (System.Int64)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedSeek>(_GType)!(stream_, offset_, type_, cancellable_, ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoTell()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedTell))]
        protected virtual unsafe System.Int64 DoTell()
        {
            var stream_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedTell>(_GType)!(stream_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        System.Boolean GISharp.Lib.Gio.ISeekable.DoCanSeek()
        {
            throw new System.NotImplementedException();
        }

        System.Boolean GISharp.Lib.Gio.ISeekable.DoCanTruncate()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable)
        {
            throw new System.NotImplementedException();
        }

        System.Int64 GISharp.Lib.Gio.ISeekable.DoTell()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoTruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable? cancellable)
        {
            throw new System.NotImplementedException();
        }
    }
}