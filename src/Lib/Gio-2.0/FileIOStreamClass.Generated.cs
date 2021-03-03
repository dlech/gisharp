// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='FileIOStreamClass']/*" />
    public unsafe class FileIOStreamClass : GISharp.Lib.Gio.IOStreamClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            public readonly GISharp.Lib.Gio.IOStreamClass.UnmanagedStruct ParentClass;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Tell']/*" />
            public readonly System.IntPtr Tell;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanSeek']/*" />
            public readonly System.IntPtr CanSeek;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Seek']/*" />
            public readonly System.IntPtr Seek;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanTruncate']/*" />
            public readonly System.IntPtr CanTruncate;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.TruncateFn']/*" />
            public readonly System.IntPtr TruncateFn;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfo']/*" />
            public readonly System.IntPtr QueryInfo;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfoAsync']/*" />
            public readonly System.IntPtr QueryInfoAsync;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.QueryInfoFinish']/*" />
            public readonly System.IntPtr QueryInfoFinish;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetEtag']/*" />
            public readonly System.IntPtr GetEtag;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved1']/*" />
            public readonly System.IntPtr GReserved1;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved2']/*" />
            public readonly System.IntPtr GReserved2;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved3']/*" />
            public readonly System.IntPtr GReserved3;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved4']/*" />
            public readonly System.IntPtr GReserved4;

            /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved5']/*" />
            public readonly System.IntPtr GReserved5;
#pragma warning restore CS0169, CS0649
        }

        static FileIOStreamClass()
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

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='Tell']/*" />
        public delegate long Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate long UnmanagedTell(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="Tell"/> methods.
        /// </summary>
        public static unsafe class TellMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                long unmanagedTell(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doTell = (Tell)methodInfo.CreateDelegate(typeof(Tell), stream); var ret = doTell(); var ret_ = (long)ret; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(long); }

                return unmanagedTell;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='CanSeek']/*" />
        public delegate System.Boolean CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="CanSeek"/> methods.
        /// </summary>
        public static unsafe class CanSeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanSeek(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), stream); var ret = doCanSeek(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCanSeek;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='Seek']/*" />
        public delegate void Seek(long offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
long offset,
/* <type name="GLib.SeekType" type="GSeekType" managed-name="GISharp.Lib.GLib.SeekType" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.SeekType type,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="Seek"/> methods.
        /// </summary>
        public static unsafe class SeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedSeek(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_, long offset_, GISharp.Lib.GLib.SeekType type_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var offset = (long)offset_; var type = (GISharp.Lib.GLib.SeekType)type_; var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), stream); doSeek(offset, type, cancellable); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedSeek;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='CanTruncate']/*" />
        public delegate System.Boolean CanTruncate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanTruncate(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="CanTruncate"/> methods.
        /// </summary>
        public static unsafe class CanTruncateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanTruncate(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doCanTruncate = (CanTruncate)methodInfo.CreateDelegate(typeof(CanTruncate), stream); var ret = doCanTruncate(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCanTruncate;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='TruncateFn']/*" />
        public delegate void TruncateFn(long size, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTruncateFn(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
long size,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="TruncateFn"/> methods.
        /// </summary>
        public static unsafe class TruncateFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTruncateFn(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_, long size_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var size = (long)size_; var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doTruncateFn = (TruncateFn)methodInfo.CreateDelegate(typeof(TruncateFn), stream); doTruncateFn(size, cancellable); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedTruncateFn;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='QueryInfo']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfo(GISharp.Lib.GLib.UnownedUtf8 attributes, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate GISharp.Lib.Gio.FileInfo.UnmanagedStruct* UnmanagedQueryInfo(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
/* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
byte* attributes,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfo"/> methods.
        /// </summary>
        public static unsafe class QueryInfoMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedQueryInfo Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.FileInfo.UnmanagedStruct* unmanagedQueryInfo(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_, byte* attributes_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var attributes = new GISharp.Lib.GLib.UnownedUtf8(attributes_); var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doQueryInfo = (QueryInfo)methodInfo.CreateDelegate(typeof(QueryInfo), stream); var ret = doQueryInfo(attributes, cancellable); var ret_ = (GISharp.Lib.Gio.FileInfo.UnmanagedStruct*)ret.Take(); return ret_; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.Gio.FileInfo.UnmanagedStruct*); }

                return unmanagedQueryInfo;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='QueryInfoAsync']/*" />
        public delegate void QueryInfoAsync(GISharp.Lib.GLib.UnownedUtf8 attributes, int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedQueryInfoAsync(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
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
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfoAsync"/> methods.
        /// </summary>
        public static unsafe class QueryInfoAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedQueryInfoAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedQueryInfoAsync(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_, byte* attributes_, int ioPriority_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var attributes = new GISharp.Lib.GLib.UnownedUtf8(attributes_); var ioPriority = (int)ioPriority_; var callback = callback_ is null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_); var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doQueryInfoAsync = (QueryInfoAsync)methodInfo.CreateDelegate(typeof(QueryInfoAsync), stream); doQueryInfoAsync(attributes, ioPriority, callback, cancellable); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedQueryInfoAsync;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='QueryInfoFinish']/*" />
        public delegate GISharp.Lib.Gio.FileInfo QueryInfoFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate GISharp.Lib.Gio.FileInfo.UnmanagedStruct* UnmanagedQueryInfoFinish(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="QueryInfoFinish"/> methods.
        /// </summary>
        public static unsafe class QueryInfoFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedQueryInfoFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.FileInfo.UnmanagedStruct* unmanagedQueryInfoFinish(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)result_, GISharp.Runtime.Transfer.None)!; var doQueryInfoFinish = (QueryInfoFinish)methodInfo.CreateDelegate(typeof(QueryInfoFinish), stream); var ret = doQueryInfoFinish(result); var ret_ = (GISharp.Lib.Gio.FileInfo.UnmanagedStruct*)ret.Take(); return ret_; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.Gio.FileInfo.UnmanagedStruct*); }

                return unmanagedQueryInfoFinish;
            }
        }

        /// <include file="FileIOStreamClass.xmldoc" path="declaration/member[@name='GetEtag']/*" />
        public delegate GISharp.Lib.GLib.Utf8 GetEtag();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        public unsafe delegate byte* UnmanagedGetEtag(
/* <type name="FileIOStream" type="GFileIOStream*" managed-name="FileIOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="GetEtag"/> methods.
        /// </summary>
        public static unsafe class GetEtagMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetEtag Create(System.Reflection.MethodInfo methodInfo)
            {
                byte* unmanagedGetEtag(GISharp.Lib.Gio.FileIOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileIOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doGetEtag = (GetEtag)methodInfo.CreateDelegate(typeof(GetEtag), stream); var ret = doGetEtag(); var ret_ = (byte*)ret.Take(); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(byte*); }

                return unmanagedGetEtag;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileIOStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}