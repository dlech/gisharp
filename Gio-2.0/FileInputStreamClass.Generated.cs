// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='FileInputStreamClass']/*" />
    public class FileInputStreamClass : GISharp.Lib.Gio.InputStreamClass
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='ParentClass']/*" />
            public GISharp.Lib.Gio.InputStreamClass.Struct ParentClass;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='Tell']/*" />
            public System.IntPtr Tell;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='CanSeek']/*" />
            public System.IntPtr CanSeek;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='Seek']/*" />
            public System.IntPtr Seek;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfo']/*" />
            public System.IntPtr QueryInfo;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoAsync']/*" />
            public System.IntPtr QueryInfoAsync;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoFinish']/*" />
            public System.IntPtr QueryInfoFinish;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='GReserved1']/*" />
            public System.IntPtr GReserved1;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='GReserved2']/*" />
            public System.IntPtr GReserved2;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='GReserved3']/*" />
            public System.IntPtr GReserved3;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='GReserved4']/*" />
            public System.IntPtr GReserved4;

            /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='GReserved5']/*" />
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static FileInputStreamClass()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Tell));
            RegisterVirtualMethod(tellOffset, TellMarshal.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekMarshal.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Seek));
            RegisterVirtualMethod(seekOffset, SeekMarshal.Create);
            System.Int32 queryInfoOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfo));
            RegisterVirtualMethod(queryInfoOffset, QueryInfoMarshal.Create);
            System.Int32 queryInfoAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfoAsync));
            RegisterVirtualMethod(queryInfoAsyncOffset, QueryInfoAsyncMarshal.Create);
            System.Int32 queryInfoFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.QueryInfoFinish));
            RegisterVirtualMethod(queryInfoFinishOffset, QueryInfoFinishMarshal.Create);
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='Tell']/*" />
        public delegate System.Int64 Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int64 UnmanagedTell(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="Tell"/> methods.
        /// </summary>
        public static class TellMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int64 unmanagedTell(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
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

                return unmanagedTell;
            }
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='CanSeek']/*" />
        public delegate System.Boolean CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="FileInputStream" type="GFileInputStream*" managed-name="FileInputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="CanSeek"/> methods.
        /// </summary>
        public static class CanSeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanSeek(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), stream);
                        var ret = doCanSeek();
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanSeek;
            }
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='Seek']/*" />
        public delegate void Seek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
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
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="Seek"/> methods.
        /// </summary>
        public static class SeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedSeek(System.IntPtr stream_, System.Int64 offset_, GISharp.Lib.GLib.SeekType type_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var offset = (System.Int64)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), stream);
                        doSeek(offset, type, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedSeek;
            }
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfo']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfo"/> methods.
        /// </summary>
        public static class QueryInfoMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedQueryInfo Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedQueryInfo(System.IntPtr stream_, System.IntPtr attributes_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var attributes = new GISharp.Lib.GLib.UnownedUtf8(attributes_, -1);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doQueryInfo = (QueryInfo)methodInfo.CreateDelegate(typeof(QueryInfo), stream);
                        var ret = doQueryInfo(attributes, cancellable);
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedQueryInfo;
            }
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoAsync']/*" />
        public delegate void QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
System.IntPtr callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfoAsync"/> methods.
        /// </summary>
        public static class QueryInfoAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedQueryInfoAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedQueryInfoAsync(System.IntPtr stream_, System.IntPtr attributes_, System.Int32 ioPriority_, System.IntPtr cancellable_, System.IntPtr callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var attributes = new GISharp.Lib.GLib.UnownedUtf8(attributes_, -1);
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doQueryInfoAsync = (QueryInfoAsync)methodInfo.CreateDelegate(typeof(QueryInfoAsync), stream);
                        doQueryInfoAsync(attributes, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedQueryInfoAsync;
            }
        }

        /// <include file="FileInputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoFinish']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
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
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfoFinish"/> methods.
        /// </summary>
        public static class QueryInfoFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedQueryInfoFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedQueryInfoFinish(System.IntPtr stream_, System.IntPtr result_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None)!;
                        var doQueryInfoFinish = (QueryInfoFinish)methodInfo.CreateDelegate(typeof(QueryInfoFinish), stream);
                        var ret = doQueryInfoFinish(result);
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedQueryInfoFinish;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public FileInputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}