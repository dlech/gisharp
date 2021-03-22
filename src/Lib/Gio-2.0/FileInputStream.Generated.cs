// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileInputStream", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(FileInputStreamClass))]
    public unsafe partial class FileInputStream : GISharp.Lib.Gio.InputStream, GISharp.Lib.Gio.ISeekable
    {
        private static readonly GISharp.Runtime.GType _GType = g_file_input_stream_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentInstance']/*" />
            public readonly GISharp.Lib.Gio.InputStream.UnmanagedStruct ParentInstance;

            /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='UnmanagedStruct.Priv']/*" />
            internal readonly System.IntPtr Priv;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileInputStream(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_file_input_stream_get_type();

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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileInfo.UnmanagedStruct* g_file_input_stream_query_info(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileInputStream.UnmanagedStruct* stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* attributes,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        partial void CheckQueryInfoArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.QueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        public GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoArgs(attributes, cancellable);
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (byte*)attributes.UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_file_input_stream_query_info(stream_,attributes_,cancellable_,&error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Lib.Gio.FileInfo.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Queries the stream information asynchronously.
        /// When the operation is finished @callback will be called.
        /// You can then call g_file_input_stream_query_info_finish()
        /// to get the result of the operation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// For the synchronous version of this function,
        /// see g_file_input_stream_query_info().
        /// </para>
        /// <para>
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be set
        /// </para>
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
        /* transfer-ownership:none direction:in */
        private static extern void g_file_input_stream_query_info_async(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileInputStream.UnmanagedStruct* stream,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* attributes,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int ioPriority,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
        /* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="AsyncReadyCallback" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);
        partial void CheckQueryInfoAsyncArgs(GISharp.Lib.GLib.UnownedUtf8 attributes, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,int,GISharp.Lib.Gio.Cancellable?)']/*" />
        public System.Threading.Tasks.Task<GISharp.Lib.Gio.FileInfo> QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, int ioPriority, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckQueryInfoAsyncArgs(attributes, ioPriority, cancellable);
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (byte*)attributes.UnsafeHandle;
            var ioPriority_ = (int)ioPriority;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var completionSource = new System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>();
            var callback_ = (delegate* unmanaged[Cdecl] <GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&QueryInfoFinish;
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileInfo.UnmanagedStruct* g_file_input_stream_query_info_finish(
        /* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileInputStream.UnmanagedStruct* stream,
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
                var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)sourceObject_;
                var userData = (System.Runtime.InteropServices.GCHandle)userData_;
                var completionSource = (System.Threading.Tasks.TaskCompletionSource<GISharp.Lib.Gio.FileInfo>)userData.Target!;
                userData.Free();
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                var ret_ = g_file_input_stream_query_info_finish(stream_,result_,&error_);
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                    completionSource.SetException(new GISharp.Runtime.GErrorException(error));
                    return;
                }
                var ret = GISharp.Lib.Gio.FileInfo.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
                completionSource.SetResult((ret));
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.LogUnhandledException(ex);
            }
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoCanSeek()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedCanSeek))]
        protected virtual bool DoCanSeek()
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedCanSeek>(_GType)!(stream_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfo))]
        protected virtual GISharp.Lib.Gio.FileInfo DoQueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (byte*)attributes.UnsafeHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfo>(_GType)!(stream_,attributes_,cancellable_,&error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Lib.Gio.FileInfo.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8,int,GISharp.Lib.Gio.AsyncReadyCallback?,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfoAsync))]
        protected virtual void DoQueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var attributes_ = (byte*)attributes.UnsafeHandle;
            var ioPriority_ = (int)ioPriority;
            var callback_ = callback is null ? default : (delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>)&GISharp.Lib.Gio.AsyncReadyCallbackMarshal.Callback;
            var callbackHandle = callback is null ? default : System.Runtime.InteropServices.GCHandle.Alloc((callback, GISharp.Runtime.CallbackScope.Async));
            var userData_ = (System.IntPtr)callbackHandle;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfoAsync>(_GType)!(stream_, attributes_, ioPriority_, cancellable_, callback_, userData_);
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedQueryInfoFinish))]
        protected virtual GISharp.Lib.Gio.FileInfo DoQueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result)
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var result_ = (GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*)result.UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedQueryInfoFinish>(_GType)!(stream_,result_,&error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Lib.Gio.FileInfo.GetInstance<GISharp.Lib.Gio.FileInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoSeek(long,GISharp.Lib.GLib.SeekType,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedSeek))]
        protected virtual void DoSeek(long offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var offset_ = (long)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedSeek>(_GType)!(stream_, offset_, type_, cancellable_, &error_);
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <include file="FileInputStream.xmldoc" path="declaration/member[@name='FileInputStream.DoTell()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(FileInputStreamClass.UnmanagedTell))]
        protected virtual long DoTell()
        {
            var stream_ = (GISharp.Lib.Gio.FileInputStream.UnmanagedStruct*)UnsafeHandle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<FileInputStreamClass.UnmanagedTell>(_GType)!(stream_);
            var ret = (long)ret_;
            return ret;
        }

        bool GISharp.Lib.Gio.ISeekable.DoCanSeek()
        {
            throw new System.NotImplementedException();
        }

        bool GISharp.Lib.Gio.ISeekable.DoCanTruncate()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoSeek(long offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable)
        {
            throw new System.NotImplementedException();
        }

        long GISharp.Lib.Gio.ISeekable.DoTell()
        {
            throw new System.NotImplementedException();
        }

        void GISharp.Lib.Gio.ISeekable.DoTruncateFn(long offset, GISharp.Lib.Gio.Cancellable? cancellable)
        {
            throw new System.NotImplementedException();
        }
    }
}