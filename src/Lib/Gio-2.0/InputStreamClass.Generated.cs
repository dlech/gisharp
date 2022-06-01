// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='InputStreamClass']/*" />
    public unsafe partial class InputStreamClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            public readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct ParentClass;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ReadFn']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, System.IntPtr, nuint, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, nint> ReadFn;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Skip']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, nuint, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, nint> Skip;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseFn']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, GISharp.Runtime.Boolean> CloseFn;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ReadAsync']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, byte**, nuint, int, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>, System.IntPtr, void> ReadAsync;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ReadFinish']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, nint> ReadFinish;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.SkipAsync']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, nuint, int, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>, System.IntPtr, void> SkipAsync;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.SkipFinish']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, nint> SkipFinish;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseAsync']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, int, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void>, System.IntPtr, void> CloseAsync;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.CloseFinish']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.InputStream.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, GISharp.Runtime.Boolean> CloseFinish;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved1']/*" />
            public readonly System.IntPtr GReserved1;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved2']/*" />
            public readonly System.IntPtr GReserved2;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved3']/*" />
            public readonly System.IntPtr GReserved3;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved4']/*" />
            public readonly System.IntPtr GReserved4;

            /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved5']/*" />
            public readonly System.IntPtr GReserved5;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static InputStreamClass()
        {
            int readFnOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ReadFn));
            RegisterVirtualMethod(readFnOffset, ReadFnMarshal.Create);
            int skipOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Skip));
            RegisterVirtualMethod(skipOffset, SkipMarshal.Create);
            int closeFnOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseFn));
            RegisterVirtualMethod(closeFnOffset, CloseFnMarshal.Create);
            int readAsyncOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ReadAsync));
            RegisterVirtualMethod(readAsyncOffset, ReadAsyncMarshal.Create);
            int readFinishOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.ReadFinish));
            RegisterVirtualMethod(readFinishOffset, ReadFinishMarshal.Create);
            int skipAsyncOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.SkipAsync));
            RegisterVirtualMethod(skipAsyncOffset, SkipAsyncMarshal.Create);
            int skipFinishOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.SkipFinish));
            RegisterVirtualMethod(skipFinishOffset, SkipFinishMarshal.Create);
            int closeAsyncOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseAsync));
            RegisterVirtualMethod(closeAsyncOffset, CloseAsyncMarshal.Create);
            int closeFinishOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CloseFinish));
            RegisterVirtualMethod(closeFinishOffset, CloseFinishMarshal.Create);
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_ReadFn']/*" />
        public delegate int _ReadFn(System.IntPtr buffer, int count, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate nint UnmanagedReadFn(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="gpointer" type="void*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr buffer,
/* <type name="gsize" type="gsize" /> */
/* transfer-ownership:none direction:in */
nuint count,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_ReadFn"/> methods.
        /// </summary>
        public static unsafe class ReadFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedReadFn Create(System.Reflection.MethodInfo methodInfo)
            {
                nint unmanagedReadFn(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, System.IntPtr buffer_, nuint count_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var buffer = (System.IntPtr)buffer_;
                        var count = (int)count_;
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadFn = (_ReadFn)methodInfo.CreateDelegate(typeof(_ReadFn), stream);
                        var ret = doReadFn(buffer, count, cancellable);
                        var ret_ = (nint)ret;
                        return ret_;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(nint);
                }

                return unmanagedReadFn;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_Skip']/*" />
        public delegate int _Skip(int count, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate nint UnmanagedSkip(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="gsize" type="gsize" /> */
/* transfer-ownership:none direction:in */
nuint count,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_Skip"/> methods.
        /// </summary>
        public static unsafe class SkipMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSkip Create(System.Reflection.MethodInfo methodInfo)
            {
                nint unmanagedSkip(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, nuint count_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var count = (int)count_;
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkip = (_Skip)methodInfo.CreateDelegate(typeof(_Skip), stream);
                        var ret = doSkip(count, cancellable);
                        var ret_ = (nint)ret;
                        return ret_;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(nint);
                }

                return unmanagedSkip;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_CloseFn']/*" />
        public delegate void _CloseFn(GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFn(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_CloseFn"/> methods.
        /// </summary>
        public static unsafe class CloseFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFn(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseFn = (_CloseFn)methodInfo.CreateDelegate(typeof(_CloseFn), stream);
                        doCloseFn(cancellable);
                        return GISharp.Runtime.Boolean.True;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCloseFn;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_ReadAsync']/*" />
        public delegate void _ReadAsync(System.Span<byte> buffer, int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedReadAsync(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <array length="2" zero-terminated="0" type="void*" is-pointer="1">
*   <type name="guint8" />
* </array> */
/* direction:out caller-allocates:1 transfer-ownership:none nullable:1 */
byte* buffer,
/* <type name="gsize" type="gsize" /> */
/* transfer-ownership:none direction:in */
nuint count,
/* <type name="gint" type="int" /> */
/* transfer-ownership:none direction:in */
int ioPriority,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:6 direction:in */
delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
/* <type name="gpointer" type="gpointer" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:6 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="_ReadAsync"/> methods.
        /// </summary>
        public static unsafe class ReadAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedReadAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedReadAsync(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, byte* buffer_, nuint count_, int ioPriority_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var buffer = new System.Span<byte>(buffer_, (int)count_);
                        var ioPriority = (int)ioPriority_;
                        var callback = callback_ is null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadAsync = (_ReadAsync)methodInfo.CreateDelegate(typeof(_ReadAsync), stream);
                        doReadAsync(buffer, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedReadAsync;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_ReadFinish']/*" />
        public delegate int _ReadFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate nint UnmanagedReadFinish(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="AsyncResult" type="GAsyncResult*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_ReadFinish"/> methods.
        /// </summary>
        public static unsafe class ReadFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedReadFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                nint unmanagedReadFinish(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)result_, GISharp.Runtime.Transfer.None)!;
                        var doReadFinish = (_ReadFinish)methodInfo.CreateDelegate(typeof(_ReadFinish), stream);
                        var ret = doReadFinish(result);
                        var ret_ = (nint)ret;
                        return ret_;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(nint);
                }

                return unmanagedReadFinish;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_SkipAsync']/*" />
        public delegate void _SkipAsync(int count, int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedSkipAsync(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="gsize" type="gsize" /> */
/* transfer-ownership:none direction:in */
nuint count,
/* <type name="gint" type="int" /> */
/* transfer-ownership:none direction:in */
int ioPriority,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
/* <type name="gpointer" type="gpointer" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="_SkipAsync"/> methods.
        /// </summary>
        public static unsafe class SkipAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSkipAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedSkipAsync(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, nuint count_, int ioPriority_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var count = (int)count_;
                        var ioPriority = (int)ioPriority_;
                        var callback = callback_ is null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkipAsync = (_SkipAsync)methodInfo.CreateDelegate(typeof(_SkipAsync), stream);
                        doSkipAsync(count, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedSkipAsync;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_SkipFinish']/*" />
        public delegate int _SkipFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate nint UnmanagedSkipFinish(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="AsyncResult" type="GAsyncResult*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_SkipFinish"/> methods.
        /// </summary>
        public static unsafe class SkipFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSkipFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                nint unmanagedSkipFinish(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)result_, GISharp.Runtime.Transfer.None)!;
                        var doSkipFinish = (_SkipFinish)methodInfo.CreateDelegate(typeof(_SkipFinish), stream);
                        var ret = doSkipFinish(result);
                        var ret_ = (nint)ret;
                        return ret_;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(nint);
                }

                return unmanagedSkipFinish;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_CloseAsync']/*" />
        public delegate void _CloseAsync(int ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedCloseAsync(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="gint" type="int" /> */
/* transfer-ownership:none direction:in */
int ioPriority,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:4 direction:in */
delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback,
/* <type name="gpointer" type="gpointer" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Class for marshalling <see cref="_CloseAsync"/> methods.
        /// </summary>
        public static unsafe class CloseAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedCloseAsync(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, int ioPriority_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.Object.UnmanagedStruct*, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var ioPriority = (int)ioPriority_;
                        var callback = callback_ is null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseAsync = (_CloseAsync)methodInfo.CreateDelegate(typeof(_CloseAsync), stream);
                        doCloseAsync(ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }
                }

                return unmanagedCloseAsync;
            }
        }

        /// <include file="InputStreamClass.xmldoc" path="declaration/member[@name='_CloseFinish']/*" />
        public delegate void _CloseFinish(GISharp.Lib.Gio.IAsyncResult result);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCloseFinish(
/* <type name="InputStream" type="GInputStream*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream,
/* <type name="AsyncResult" type="GAsyncResult*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_CloseFinish"/> methods.
        /// </summary>
        public static unsafe class CloseFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCloseFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCloseFinish(GISharp.Lib.Gio.InputStream.UnmanagedStruct* stream_, GISharp.Lib.Gio.AsyncResult.UnmanagedStruct* result_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var stream = GISharp.Lib.Gio.InputStream.GetInstance<GISharp.Lib.Gio.InputStream>((System.IntPtr)stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)result_, GISharp.Runtime.Transfer.None)!;
                        var doCloseFinish = (_CloseFinish)methodInfo.CreateDelegate(typeof(_CloseFinish), stream);
                        doCloseFinish(result);
                        return GISharp.Runtime.Boolean.True;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCloseFinish;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}