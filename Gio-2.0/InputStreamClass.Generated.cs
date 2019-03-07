// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    public class InputStreamClass : GISharp.Lib.GObject.ObjectClass
    {
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public System.IntPtr ReadFn;
            public System.IntPtr Skip;
            public System.IntPtr CloseFn;
            public System.IntPtr ReadAsync;
            public System.IntPtr ReadFinish;
            public System.IntPtr SkipAsync;
            public System.IntPtr SkipFinish;
            public System.IntPtr CloseAsync;
            public System.IntPtr CloseFinish;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static InputStreamClass()
        {
            System.Int32 readFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadFn));
            RegisterVirtualMethod(readFnOffset, ReadFnFactory.Create);
            System.Int32 skipOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Skip));
            RegisterVirtualMethod(skipOffset, SkipFactory.Create);
            System.Int32 closeFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFn));
            RegisterVirtualMethod(closeFnOffset, CloseFnFactory.Create);
            System.Int32 readAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadAsync));
            RegisterVirtualMethod(readAsyncOffset, ReadAsyncFactory.Create);
            System.Int32 readFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.ReadFinish));
            RegisterVirtualMethod(readFinishOffset, ReadFinishFactory.Create);
            System.Int32 skipAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.SkipAsync));
            RegisterVirtualMethod(skipAsyncOffset, SkipAsyncFactory.Create);
            System.Int32 skipFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.SkipFinish));
            RegisterVirtualMethod(skipFinishOffset, SkipFinishFactory.Create);
            System.Int32 closeAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseAsync));
            RegisterVirtualMethod(closeAsyncOffset, CloseAsyncFactory.Create);
            System.Int32 closeFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CloseFinish));
            RegisterVirtualMethod(closeFinishOffset, CloseFinishFactory.Create);
        }

        public delegate System.Int32 ReadFn(System.IntPtr buffer, System.Int32 count, GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedReadFn(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gpointer" type="void*" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr buffer,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="ReadFn"/> methods.
        /// </summary>
        public static class ReadFnFactory
        {
            public static unsafe UnmanagedReadFn Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedReadFn(System.IntPtr stream_, System.IntPtr buffer_, System.UIntPtr count_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var buffer = (System.IntPtr)buffer_;
                        var count = (System.Int32)count_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadFn = (ReadFn)methodInfo.CreateDelegate(typeof(ReadFn), stream);
                        var ret = doReadFn(buffer, count, cancellable);
                        var ret_ = (System.IntPtr)ret;
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

                return unmanagedReadFn;
            }
        }

        public delegate System.Int32 Skip(System.Int32 count, GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedSkip(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="Skip"/> methods.
        /// </summary>
        public static class SkipFactory
        {
            public static unsafe UnmanagedSkip Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedSkip(System.IntPtr stream_, System.UIntPtr count_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var count = (System.Int32)count_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkip = (Skip)methodInfo.CreateDelegate(typeof(Skip), stream);
                        var ret = doSkip(count, cancellable);
                        var ret_ = (System.IntPtr)ret;
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

                return unmanagedSkip;
            }
        }

        public delegate void CloseFn(GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate System.Boolean UnmanagedCloseFn(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="CloseFn"/> methods.
        /// </summary>
        public static class CloseFnFactory
        {
            public static unsafe UnmanagedCloseFn Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean unmanagedCloseFn(System.IntPtr stream_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCloseFn = (CloseFn)methodInfo.CreateDelegate(typeof(CloseFn), stream);
                        doCloseFn(cancellable);
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

                return unmanagedCloseFn;
            }
        }

        public delegate void ReadAsync(GISharp.Runtime.IArray<System.Byte>? buffer, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedReadAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <array length="2" zero-terminated="0" type="void*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr buffer,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="gint" type="int" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 ioPriority,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:6 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:6 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="ReadAsync"/> methods.
        /// </summary>
        public static class ReadAsyncFactory
        {
            public static unsafe UnmanagedReadAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedReadAsync(System.IntPtr stream_, System.IntPtr buffer_, System.UIntPtr count_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var buffer = GISharp.Runtime.CArray.GetInstance<System.Byte>(buffer_, (int)count_, GISharp.Runtime.Transfer.None);
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doReadAsync = (ReadAsync)methodInfo.CreateDelegate(typeof(ReadAsync), stream);
                        doReadAsync(buffer, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedReadAsync;
            }
        }

        public delegate System.Int32 ReadFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedReadFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="ReadFinish"/> methods.
        /// </summary>
        public static class ReadFinishFactory
        {
            public static unsafe UnmanagedReadFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedReadFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None)!;
                        var doReadFinish = (ReadFinish)methodInfo.CreateDelegate(typeof(ReadFinish), stream);
                        var ret = doReadFinish(result);
                        var ret_ = (System.IntPtr)ret;
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

                return unmanagedReadFinish;
            }
        }

        public delegate void SkipAsync(System.Int32 count, System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedSkipAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.UIntPtr count,
/* <type name="gint" type="int" managed-name="System.Int32" /> */
/* transfer-ownership:none direction:in */
System.Int32 ioPriority,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="AsyncReadyCallback" type="GAsyncReadyCallback" managed-name="UnmanagedAsyncReadyCallback" /> */
/* transfer-ownership:none nullable:1 allow-none:1 scope:async closure:5 direction:in */
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:5 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="SkipAsync"/> methods.
        /// </summary>
        public static class SkipAsyncFactory
        {
            public static unsafe UnmanagedSkipAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedSkipAsync(System.IntPtr stream_, System.UIntPtr count_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var count = (System.Int32)count_;
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSkipAsync = (SkipAsync)methodInfo.CreateDelegate(typeof(SkipAsync), stream);
                        doSkipAsync(count, ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedSkipAsync;
            }
        }

        public delegate System.Int32 SkipFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.IntPtr UnmanagedSkipFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="SkipFinish"/> methods.
        /// </summary>
        public static class SkipFinishFactory
        {
            public static unsafe UnmanagedSkipFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.IntPtr unmanagedSkipFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None)!;
                        var doSkipFinish = (SkipFinish)methodInfo.CreateDelegate(typeof(SkipFinish), stream);
                        var ret = doSkipFinish(result);
                        var ret_ = (System.IntPtr)ret;
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

                return unmanagedSkipFinish;
            }
        }

        public delegate void CloseAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedCloseAsync(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
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
GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback,
/* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
System.IntPtr userData);

        /// <summary>
        /// Factory for creating <see cref="CloseAsync"/> methods.
        /// </summary>
        public static class CloseAsyncFactory
        {
            public static unsafe UnmanagedCloseAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedCloseAsync(System.IntPtr stream_, System.Int32 ioPriority_, System.IntPtr cancellable_, GISharp.Lib.Gio.UnmanagedAsyncReadyCallback? callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == null ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackFactory.Create(callback_, userData_);
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

        public delegate void CloseFinish(GISharp.Lib.Gio.IAsyncResult result);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate System.Boolean UnmanagedCloseFinish(
/* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr stream,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr result,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
System.IntPtr* error);

        /// <summary>
        /// Factory for creating <see cref="CloseFinish"/> methods.
        /// </summary>
        public static class CloseFinishFactory
        {
            public static unsafe UnmanagedCloseFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean unmanagedCloseFinish(System.IntPtr stream_, System.IntPtr result_, System.IntPtr* error_)
                {
                    try
                    {
                        var stream = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(stream_, GISharp.Runtime.Transfer.None)!;
                        var result = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(result_, GISharp.Runtime.Transfer.None)!;
                        var doCloseFinish = (CloseFinish)methodInfo.CreateDelegate(typeof(CloseFinish), stream);
                        doCloseFinish(result);
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

                return unmanagedCloseFinish;
            }
        }

        public InputStreamClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}