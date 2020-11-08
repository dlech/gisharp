// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='IOStreamClass']/*" />
    public class IOStreamClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.ParentClass']/*" />
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GetInputStream']/*" />
            public System.IntPtr GetInputStream;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GetOutputStream']/*" />
            public System.IntPtr GetOutputStream;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.CloseFn']/*" />
            public System.IntPtr CloseFn;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.CloseAsync']/*" />
            public System.IntPtr CloseAsync;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.CloseFinish']/*" />
            public System.IntPtr CloseFinish;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved1']/*" />
            public System.IntPtr GReserved1;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved2']/*" />
            public System.IntPtr GReserved2;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved3']/*" />
            public System.IntPtr GReserved3;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved4']/*" />
            public System.IntPtr GReserved4;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved5']/*" />
            public System.IntPtr GReserved5;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved6']/*" />
            public System.IntPtr GReserved6;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved7']/*" />
            public System.IntPtr GReserved7;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved8']/*" />
            public System.IntPtr GReserved8;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved9']/*" />
            public System.IntPtr GReserved9;

            /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='Struct.GReserved10']/*" />
            public System.IntPtr GReserved10;
#pragma warning restore CS0649
        }

        static IOStreamClass()
        {
            System.Int32 getInputStreamOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetInputStream));
            RegisterVirtualMethod(getInputStreamOffset, GetInputStreamMarshal.Create);
            System.Int32 getOutputStreamOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.GetOutputStream));
            RegisterVirtualMethod(getOutputStreamOffset, GetOutputStreamMarshal.Create);
            System.Int32 closeFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFn));
            RegisterVirtualMethod(closeFnOffset, CloseFnMarshal.Create);
            System.Int32 closeAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseAsync));
            RegisterVirtualMethod(closeAsyncOffset, CloseAsyncMarshal.Create);
            System.Int32 closeFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFinish));
            RegisterVirtualMethod(closeFinishOffset, CloseFinishMarshal.Create);
        }

        /// <include file="IOStreamClass.xmldoc" path="declaration/member[@name='GetInputStream']/*" />
        public delegate GISharp.Lib.Gio.InputStream GetInputStream();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetInputStream(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="GetInputStream"/> methods.
        /// </summary>
        public static class GetInputStreamMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetInputStream Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetInputStream(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doGetInputStream = (GetInputStream)methodInfo.CreateDelegate(typeof(GetInputStream), stream);
                        var ret = doGetInputStream();
                        var ret_ = ret.Handle;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

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
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedGetOutputStream(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream);

        /// <summary>
        /// Class for marshalling <see cref="GetOutputStream"/> methods.
        /// </summary>
        public static class GetOutputStreamMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedGetOutputStream Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedGetOutputStream(System.IntPtr stream_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var doGetOutputStream = (GetOutputStream)methodInfo.CreateDelegate(typeof(GetOutputStream), stream);
                        var ret = doGetOutputStream();
                        var ret_ = ret.Handle;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.IntPtr);
                }

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
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFn(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="CloseFn"/> methods.
        /// </summary>
        public static class CloseFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCloseFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFn(System.IntPtr stream_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseFn = (CloseFn)methodInfo.CreateDelegate(typeof(CloseFn), stream);
                        doCloseFn(cancellable);
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
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedCloseAsync(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
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
/* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="CloseAsync"/> methods.
        /// </summary>
        public static class CloseAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCloseAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedCloseAsync(System.IntPtr stream_, System.Int32 ioPriority_, System.IntPtr cancellable_, System.IntPtr callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == System.IntPtr.Zero ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseAsync = (CloseAsync)methodInfo.CreateDelegate(typeof(CloseAsync), stream);
                        doCloseAsync(ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

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
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFinish(
/* <type name="IOStream" type="GIOStream*" managed-name="IOStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="CloseFinish"/> methods.
        /// </summary>
        public static class CloseFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCloseFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFinish(System.IntPtr stream_, System.IntPtr result_, ref System.IntPtr error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.IOStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None)!;
                        var doCloseFinish = (CloseFinish)methodInfo.CreateDelegate(typeof(CloseFinish), stream);
                        doCloseFinish(result);
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

                return unmanagedCloseFinish;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public IOStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}