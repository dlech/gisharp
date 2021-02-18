// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    [GISharp.Runtime.GTypeAttribute("GFileIOStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(FileIOStreamClass))]
    public unsafe partial class FileIOStream : GISharp.Lib.Gio.IOStream, GISharp.Lib.Gio.ISeekable
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_io_stream_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.Gio.IOStream.UnmanagedStruct ParentInstance;

            /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.Priv']/*" />
            private readonly System.IntPtr Priv;
#pragma warning restore CS0169, CS0649
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.Etag']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public GISharp.Lib.GLib.Utf8 Etag { get => GetEtag(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileIOStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_file_io_stream_get_type();

        /// <summary>
        /// Gets the entity tag for the file when it has been written.
        /// This must be called after the stream has been written
        /// and closed, as the etag can change while writing.
        /// </summary>
        /// <param name="stream">
        /// a #GFileIOStream.
        /// </param>
        /// <returns>
        /// the entity tag for the stream.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern System.Byte* g_file_io_stream_get_etag(
        /* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream);
        partial void CheckGetEtagArgs();

        [GISharp.Runtime.SinceAttribute("2.22")]
        private GISharp.Lib.GLib.Utf8 GetEtag()
        {
            CheckGetEtagArgs();
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_file_io_stream_get_etag(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Queries a file io stream for the given @attributes.
        /// This function blocks while querying the stream. For the asynchronous
        /// version of this function, see g_file_io_stream_query_info_async().
        /// While the stream is blocked, the stream will set the pending flag
        /// internally, and any other operations on the stream will fail with
        /// %G_IO_ERROR_PENDING.
        /// </summary>
        /// <remarks>
        /// Can fail if the stream was already closed (with @error being set to
        /// %G_IO_ERROR_CLOSED), the stream has pending operations (with @error being
        /// set to %G_IO_ERROR_PENDING), or if querying info is not supported for
        /// the stream's interface (with @error being set to %G_IO_ERROR_NOT_SUPPORTED). I
        /// all cases of failure, %NULL will be returned.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be set, and %NULL will
        /// be returned.
        /// </remarks>
        /// <param name="stream">
        /// a #GFileIOStream.
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
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileInfo.UnmanagedStruct* g_file_io_stream_query_info(
        /* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* attributes,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        partial void CheckQueryInfoArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.QueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoArgs(attributes, cancellable);
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (System.Byte*)attributes.UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_file_io_stream_query_info(stream_,attributes_,cancellable_,&error_);
            if (error_ != null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Asynchronously queries the @stream for a #GFileInfo. When completed,
        /// @callback will be called with a #GAsyncResult which can be used to
        /// finish the operation with g_file_io_stream_query_info_finish().
        /// </summary>
        /// <remarks>
        /// For the synchronous version of this function, see
        /// g_file_io_stream_query_info().
        /// </remarks>
        /// <param name="stream">
        /// a #GFileIOStream.
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
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Threading.Tasks.Task">
*   <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" />
* </type> */
        /* transfer-ownership:none direction:in */
        private static extern void g_file_io_stream_query_info_async(
        /* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* attributes,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="AsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        System.IntPtr callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        partial void CheckQueryInfoAsyncArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,System.Int32,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        public System.Threading.Tasks.Task<GISharp.Lib.Gio.FileInfo> QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoAsyncArgs(attributes, ioPriority, cancellable);
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (System.Byte*)attributes.UnsafeHandle;
            var ioPriority_ = (System.Int32)ioPriority;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>();
            var callback_ = (System.IntPtr)(delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&QueryInfoFinish;
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(completionSource);
            g_file_io_stream_query_info_async(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
            return completionSource.Task;
        }

        /// <summary>
        /// Finalizes the asynchronous query started
        /// by g_file_io_stream_query_info_async().
        /// </summary>
        /// <param name="stream">
        /// a #GFileIOStream.
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
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileInfo.UnmanagedStruct* g_file_io_stream_query_info_finish(
        /* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
        /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        private static void QueryInfoFinish(GISharp.Lib.GObject.Object.UnmanagedStruct* sourceObject_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, System.IntPtr userData_)
        {
            try
            {
                var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)sourceObject_;
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                var ret_ = g_file_io_stream_query_info_finish(stream_,result_,&error_);
                if (error_ != null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoCanSeek()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedCanSeek))]
        protected virtual System.Boolean DoCanSeek()
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedCanSeek>(_GType)!(stream_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoCanTruncate()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedCanTruncate))]
        protected virtual System.Boolean DoCanTruncate()
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedCanTruncate>(_GType)!(stream_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoGetEtag()']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedGetEtag))]
        protected virtual GISharp.Lib.GLib.Utf8 DoGetEtag()
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedGetEtag>(_GType)!(stream_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedQueryInfo))]
        protected virtual GISharp.Lib.Gio.FileInfo DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (System.Byte*)attributes.UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedQueryInfo>(_GType)!(stream_,attributes_,cancellable_,&error_);
            if (error_ != null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,System.Int32,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedQueryInfoAsync))]
        protected virtual void DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (System.Byte*)attributes.UnsafeHandle;
            var ioPriority_ = (System.Int32)ioPriority;
            var (callback_, _, userData_) = GISharp.Lib.Gio.AsyncReadyCallbackMarshal.ToUnmanagedFunctionPointer(callback, GISharp.Runtime.CallbackScope.Async);
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedQueryInfoAsync>(_GType)!(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedQueryInfoFinish))]
        protected virtual GISharp.Lib.Gio.FileInfo DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var result_ = (GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*)result.UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedQueryInfoFinish>(_GType)!(stream_,result_,&error_);
            if (error_ != null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoSeek(System.Int64,GISharp.Lib.GLib.SeekType,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedSeek))]
        protected virtual void DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var offset_ = (System.Int64)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedSeek>(_GType)!(stream_, offset_, type_, cancellable_, &error_);
            if (error_ != null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoTell()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedTell))]
        protected virtual System.Int64 DoTell()
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedTell>(_GType)!(stream_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <include file="FileIOStream.xmldoc" path="declaration/member[@name='FileIOStream.DoTruncateFn(System.Int64,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileIOStreamClass.UnmanagedTruncateFn))]
        protected virtual void DoTruncateFn(System.Int64 size, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileIOStream.UnmanagedStruct*)UnsafeHandle;
            var size_ = (System.Int64)size;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileIOStreamClass.UnmanagedTruncateFn>(_GType)!(stream_, size_, cancellable_, &error_);
            if (error_ != null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
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