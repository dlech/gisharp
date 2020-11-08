// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='AsyncInitableIface']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    public sealed class AsyncInitableIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='Struct.GIface']/*" />
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;

            /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='Struct.InitAsync']/*" />
            public System.IntPtr InitAsync;

            /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='Struct.InitFinish']/*" />
            public System.IntPtr InitFinish;
#pragma warning restore CS0649
        }

        static AsyncInitableIface()
        {
            System.Int32 initAsyncOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.InitAsync));
            RegisterVirtualMethod(initAsyncOffset, InitAsyncMarshal.Create);
            System.Int32 initFinishOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.InitFinish));
            RegisterVirtualMethod(initFinishOffset, InitFinishMarshal.Create);
        }

        /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='InitAsync']/*" />
        public delegate void InitAsync(System.Int32 ioPriority, GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedInitAsync(
/* <type name="AsyncInitable" type="GAsyncInitable*" managed-name="AsyncInitable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr initable,
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
        /// Class for marshalling <see cref="InitAsync"/> methods.
        /// </summary>
        public static class InitAsyncMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedInitAsync Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedInitAsync(System.IntPtr initable_, System.Int32 ioPriority_, System.IntPtr cancellable_, System.IntPtr callback_, System.IntPtr userData_)
                {
                    try
                    {
                        var initable = (GISharp.Lib.Gio.IAsyncInitable)GISharp.Lib.GObject.Object.GetInstance(initable_, GISharp.Runtime.Transfer.None)!;
                        var ioPriority = (System.Int32)ioPriority_;
                        var callback = callback_ == System.IntPtr.Zero ? default(GISharp.Lib.Gio.AsyncReadyCallback) : GISharp.Lib.Gio.AsyncReadyCallbackMarshal.FromPointer(callback_, userData_);
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doInitAsync = (InitAsync)methodInfo.CreateDelegate(typeof(InitAsync), initable);
                        doInitAsync(ioPriority, callback, cancellable);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return unmanagedInitAsync;
            }
        }

        /// <include file="AsyncInitableIface.xmldoc" path="declaration/member[@name='InitFinish']/*" />
        public delegate void InitFinish(GISharp.Lib.Gio.IAsyncResult res);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedInitFinish(
/* <type name="AsyncInitable" type="GAsyncInitable*" managed-name="AsyncInitable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr initable,
/* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr res,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="InitFinish"/> methods.
        /// </summary>
        public static class InitFinishMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedInitFinish Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedInitFinish(System.IntPtr initable_, System.IntPtr res_, ref System.IntPtr error_)
                {
                    try
                    {
                        var initable = (GISharp.Lib.Gio.IAsyncInitable)GISharp.Lib.GObject.Object.GetInstance(initable_, GISharp.Runtime.Transfer.None)!;
                        var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None)!;
                        var doInitFinish = (InitFinish)methodInfo.CreateDelegate(typeof(InitFinish), initable);
                        doInitFinish(res);
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

                return unmanagedInitFinish;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public AsyncInitableIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}