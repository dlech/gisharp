// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    public class FileInputStreamClass : GISharp.Lib.Gio.InputStreamClass
    {
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.Gio.InputStreamClass.Struct ParentClass;
            public System.IntPtr Tell;
            public System.IntPtr CanSeek;
            public System.IntPtr Seek;
            public System.IntPtr QueryInfo;
            public System.IntPtr QueryInfoAsync;
            public System.IntPtr QueryInfoFinish;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static FileInputStreamClass()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Tell));
            RegisterVirtualMethod(tellOffset, TellFactory.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekFactory.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Seek));
            RegisterVirtualMethod(seekOffset, SeekFactory.Create);
            System.Int32 queryInfoOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfo));
            RegisterVirtualMethod(queryInfoOffset, QueryInfoFactory.Create);
            System.Int32 queryInfoAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfoAsync));
            RegisterVirtualMethod(queryInfoAsyncOffset, QueryInfoAsyncFactory.Create);
            System.Int32 queryInfoFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfoFinish));
            RegisterVirtualMethod(queryInfoFinishOffset, QueryInfoFinishFactory.Create);
        }

        public delegate System.Int64 Tell();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int64 UnmanagedTell(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Factory for creating <see cref="Tell"/> methods.
        /// </summary>
        public static class TellFactory
        {
            public static unsafe UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int64 tell(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var doTell = (Tell)methodInfo.CreateDelegate(typeof(Tell), stream);
                        var ret = doTell();
                        var ret_ = (System.Int64)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Int64);
                }

                return tell;
            }
        }

        public delegate System.Boolean CanSeek();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedCanSeek(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Factory for creating <see cref="CanSeek"/> methods.
        /// </summary>
        public static class CanSeekFactory
        {
            public static unsafe UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean canSeek(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), stream);
                        var ret = doCanSeek();
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return canSeek;
            }
        }

        public delegate void Seek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate System.Boolean UnmanagedSeek(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
System.Int64 offset,
/* <type name="GLib.SeekType" type="GSeekType" managed-name="GISharp.Lib.GLib.SeekType" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.SeekType type,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="Seek"/> methods.
        /// </summary>
        public static class SeekFactory
        {
            public static unsafe UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean seek(System.IntPtr stream_, System.Int64 offset_, GISharp.Lib.GLib.SeekType type_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var offset = (System.Int64)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), stream);
                        doSeek(offset, type, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return seek;
            }
        }

        public delegate GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.Utf8 attributes, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedQueryInfo(
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
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="QueryInfo"/> methods.
        /// </summary>
        public static class QueryInfoFactory
        {
            public static unsafe UnmanagedQueryInfo Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr queryInfo(System.IntPtr stream_, System.IntPtr attributes_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var attributes = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(attributes_, GISharp.Runtime.Transfer.None);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doQueryInfo = (QueryInfo)methodInfo.CreateDelegate(typeof(QueryInfo), stream);
                        var ret = doQueryInfo(attributes, cancellable);
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return queryInfo;
            }
        }

        public delegate void QueryInfoAsync(GISharp.Lib.GLib.Utf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedQueryInfoAsync(
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
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="QueryInfoAsync"/> methods.
        /// </summary>
        public static class QueryInfoAsyncFactory
        {
            public static unsafe UnmanagedQueryInfoAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void queryInfoAsync(System.IntPtr stream_, System.IntPtr attributes_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var attributes = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(attributes_, GISharp.Runtime.Transfer.None);
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doQueryInfoAsync = (QueryInfoAsync)methodInfo.CreateDelegate(typeof(QueryInfoAsync), stream);
                        doQueryInfoAsync(attributes, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return queryInfoAsync;
            }
        }

        public delegate GISharp.Lib.Gio.FileInfo QueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedQueryInfoFinish(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="QueryInfoFinish"/> methods.
        /// </summary>
        public static class QueryInfoFinishFactory
        {
            public static unsafe UnmanagedQueryInfoFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr queryInfoFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None);
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None);
                        var doQueryInfoFinish = (QueryInfoFinish)methodInfo.CreateDelegate(typeof(QueryInfoFinish), stream);
                        var ret = doQueryInfoFinish(result);
                        var ret_ = ret?.Take() ?? throw new System.ArgumentNullException(nameof(ret));
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return queryInfoFinish;
            }
        }

        public FileInputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}