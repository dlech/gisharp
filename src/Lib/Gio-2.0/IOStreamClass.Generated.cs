// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='IOStreamClass']/*" />
    public unsafe class IOStreamClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            public readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct ParentClass;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetInputStream']/*" />
            public readonly System.IntPtr GetInputStream;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GetOutputStream']/*" />
            public readonly System.IntPtr GetOutputStream;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseFn']/*" />
            public readonly System.IntPtr CloseFn;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseAsync']/*" />
            public readonly System.IntPtr CloseAsync;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseFinish']/*" />
            public readonly System.IntPtr CloseFinish;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved1']/*" />
            public readonly System.IntPtr GReserved1;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved2']/*" />
            public readonly System.IntPtr GReserved2;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved3']/*" />
            public readonly System.IntPtr GReserved3;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved4']/*" />
            public readonly System.IntPtr GReserved4;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved5']/*" />
            public readonly System.IntPtr GReserved5;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved6']/*" />
            public readonly System.IntPtr GReserved6;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved7']/*" />
            public readonly System.IntPtr GReserved7;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved8']/*" />
            public readonly System.IntPtr GReserved8;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved9']/*" />
            public readonly System.IntPtr GReserved9;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved10']/*" />
            public readonly System.IntPtr GReserved10;
#pragma warning restore CS0169, CS0649
        }

        static IOStreamClass()
        {
            System.Int32 getInputStreamOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetInputStream));
            RegisterVirtualMethod(getInputStreamOffset, GetInputStreamMarshal.Create);
            System.Int32 getOutputStreamOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.GetOutputStream));
            RegisterVirtualMethod(getOutputStreamOffset, GetOutputStreamMarshal.Create);
            System.Int32 closeFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseFn));
            RegisterVirtualMethod(closeFnOffset, CloseFnMarshal.Create);
            System.Int32 closeAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseAsync));
            RegisterVirtualMethod(closeAsyncOffset, CloseAsyncMarshal.Create);
            System.Int32 closeFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseFinish));
            RegisterVirtualMethod(closeFinishOffset, CloseFinishMarshal.Create);
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='GetInputStream']/*" />
        public delegate GISharp.Lib.Gio.InputStream GetInputStream();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Lib.Gio.InputStream.UnmanagedStruct* UnmanagedGetInputStream(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="GetInputStream"/> methods.
        /// </summary>
        public static unsafe class GetInputStreamMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetInputStream Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.InputStream.UnmanagedStruct* unmanagedGetInputStream(GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doGetInputStream = (GetInputStream)methodInfo.CreateDelegate(typeof(GetInputStream), stream); var ret = doGetInputStream(); var ret_ = (GISharp.Lib.Gio.InputStream.UnmanagedStruct*)ret.UnsafeHandle; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.Gio.InputStream.UnmanagedStruct*); }

                return unmanagedGetInputStream;
            }
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='GetOutputStream']/*" />
        public delegate GISharp.Lib.Gio.OutputStream GetOutputStream();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OutputStream" type="GOutputStream*" managed-name="OutputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Lib.Gio.OutputStream.UnmanagedStruct* UnmanagedGetOutputStream(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream);

        /// <summary>
        /// Class for marshalling <see cref="GetOutputStream"/> methods.
        /// </summary>
        public static unsafe class GetOutputStreamMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedGetOutputStream Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Lib.Gio.OutputStream.UnmanagedStruct* unmanagedGetOutputStream(GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var doGetOutputStream = (GetOutputStream)methodInfo.CreateDelegate(typeof(GetOutputStream), stream); var ret = doGetOutputStream(); var ret_ = (GISharp.Lib.Gio.OutputStream.UnmanagedStruct*)ret.UnsafeHandle; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Lib.Gio.OutputStream.UnmanagedStruct*); }

                return unmanagedGetOutputStream;
            }
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='CloseFn']/*" />
        public delegate void CloseFn(GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFn(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="CloseFn"/> methods.
        /// </summary>
        public static unsafe class CloseFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFn(GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doCloseFn = (CloseFn)methodInfo.CreateDelegate(typeof(CloseFn), stream); doCloseFn(cancellable); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCloseFn;
            }
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='CloseAsync']/*" />
        public delegate void CloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedCloseAsync(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
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
/* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="CloseAsync"/> methods.
        /// </summary>
        public static unsafe class CloseAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedCloseAsync(GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream_, System.Int32 ioPriority_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, System.IntPtr callback_, System.IntPtr userData_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var ioPriority = (System.Int32)ioPriority_; var callback = callback_ == System.IntPtr.Zero ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_); var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doCloseAsync = (CloseAsync)methodInfo.CreateDelegate(typeof(CloseAsync), stream); doCloseAsync(ioPriority, callback, cancellable); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedCloseAsync;
            }
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='CloseFinish']/*" />
        public delegate void CloseFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFinish(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="CloseFinish"/> methods.
        /// </summary>
        public static unsafe class CloseFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFinish(GISharp.Lib.Gio.IOStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!; var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)result_, GISharp.Runtime.Transfer.None)!; var doCloseFinish = (CloseFinish)methodInfo.CreateDelegate(typeof(CloseFinish), stream); doCloseFinish(result); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCloseFinish;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public IOStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}