// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='FileOutputStreamClass']/*" />
    public class FileOutputStreamClass : GISharp.Lib.Gio.OutputStreamClass
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="FileOutputStreamClass"/>.
        /// </summary>
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            public readonly GISharp.Lib.Gio.OutputStreamClass.UnmanagedStruct ParentClass;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Tell']/*" />
            public readonly System.IntPtr Tell;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanSeek']/*" />
            public readonly System.IntPtr CanSeek;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Seek']/*" />
            public readonly System.IntPtr Seek;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanTruncate']/*" />
            public readonly System.IntPtr CanTruncate;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.TruncateFn']/*" />
            public readonly System.IntPtr TruncateFn;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfo']/*" />
            public readonly System.IntPtr QueryInfo;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfoAsync']/*" />
            public readonly System.IntPtr QueryInfoAsync;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfoFinish']/*" />
            public readonly System.IntPtr QueryInfoFinish;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetEtag']/*" />
            public readonly System.IntPtr GetEtag;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved1']/*" />
            public readonly System.IntPtr GReserved1;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved2']/*" />
            public readonly System.IntPtr GReserved2;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved3']/*" />
            public readonly System.IntPtr GReserved3;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved4']/*" />
            public readonly System.IntPtr GReserved4;

            /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved5']/*" />
            public readonly System.IntPtr GReserved5;
#pragma warning restore CS0169, CS0649
        }

        static FileOutputStreamClass()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Tell));
            RegisterVirtualMethod(tellOffset, TellMarshal.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekMarshal.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Seek));
            RegisterVirtualMethod(seekOffset, SeekMarshal.Create);
            System.Int32 canTruncateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanTruncate));
            RegisterVirtualMethod(canTruncateOffset, CanTruncateMarshal.Create);
            System.Int32 truncateFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.TruncateFn));
            RegisterVirtualMethod(truncateFnOffset, TruncateFnMarshal.Create);
            System.Int32 queryInfoOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.QueryInfo));
            RegisterVirtualMethod(queryInfoOffset, QueryInfoMarshal.Create);
            System.Int32 queryInfoAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.QueryInfoAsync));
            RegisterVirtualMethod(queryInfoAsyncOffset, QueryInfoAsyncMarshal.Create);
            System.Int32 queryInfoFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.QueryInfoFinish));
            RegisterVirtualMethod(queryInfoFinishOffset, QueryInfoFinishMarshal.Create);
            System.Int32 getEtagOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetEtag));
            RegisterVirtualMethod(getEtagOffset, GetEtagMarshal.Create);
        }

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='Tell']/*" />
        public delegate System.Int64 Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int64 UnmanagedTell(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='CanSeek']/*" />
        public delegate System.Boolean CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), stream);
                        var ret = doCanSeek();
                        var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='Seek']/*" />
        public delegate void Seek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var offset = (System.Int64)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), stream);
                        doSeek(offset, type, cancellable);
                        return GISharp.Runtime.Boolean.True;
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='CanTruncate']/*" />
        public delegate System.Boolean CanTruncate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanTruncate(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="CanTruncate"/> methods.
        /// </summary>
        public static class CanTruncateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanTruncate(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doCanTruncate = (CanTruncate)methodInfo.CreateDelegate(typeof(CanTruncate), stream);
                        var ret = doCanTruncate();
                        var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanTruncate;
            }
        }

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='TruncateFn']/*" />
        public delegate void TruncateFn(System.Int64 size, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTruncateFn(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
System.Int64 size,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="TruncateFn"/> methods.
        /// </summary>
        public static class TruncateFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTruncateFn(System.IntPtr stream_, System.Int64 size_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var size = (System.Int64)size_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doTruncateFn = (TruncateFn)methodInfo.CreateDelegate(typeof(TruncateFn), stream);
                        doTruncateFn(size, cancellable);
                        return GISharp.Runtime.Boolean.True;
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

                return unmanagedTruncateFn;
            }
        }

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='QueryInfo']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedQueryInfo(
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoAsync']/*" />
        public delegate void QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedQueryInfoAsync(
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var attributes = new GISharp.Lib.GLib.UnownedUtf8(attributes_, -1);
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == System.IntPtr.Zero ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='QueryInfoFinish']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedQueryInfoFinish(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
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
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
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

        /// <include file="FileOutputStreamClass.xmldoc" path="declaration/member[@name='GetEtag']/*" />
        public delegate GISharp.Lib.GLib.Utf8 GetEtag();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetEtag(
/* <type name="FileOutputStream" type="GFileOutputStream*" managed-name="FileOutputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="GetEtag"/> methods.
        /// </summary>
        public static class GetEtagMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetEtag Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetEtag(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileOutputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doGetEtag = (GetEtag)methodInfo.CreateDelegate(typeof(GetEtag), stream);
                        var ret = doGetEtag();
                        var ret_ = ret.Take();
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

                return unmanagedGetEtag;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public FileOutputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}