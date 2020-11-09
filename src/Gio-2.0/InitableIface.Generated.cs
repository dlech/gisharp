// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="InitableIface.xmldoc" path="declaration/member[@name='InitableIface']/*" />
    [GISharp.Runtime.SinceAttribute("2.22")]
    public sealed class InitableIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <include file="InitableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="InitableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Init']/*" />
            public System.IntPtr Init;
#pragma warning restore CS0649
        }

        static InitableIface()
        {
            System.Int32 initOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Init));
            RegisterVirtualMethod(initOffset, InitMarshal.Create);
        }

        /// <include file="InitableIface.xmldoc" path="declaration/member[@name='Init']/*" />
        public delegate void Init(GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedInit(
/* <type name="Initable" type="GInitable*" managed-name="Initable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr initable,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
ref System.IntPtr error);

        /// <summary>
        /// Class for marshalling <see cref="Init"/> methods.
        /// </summary>
        public static class InitMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedInit Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedInit(System.IntPtr initable_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var initable = (GISharp.Lib.Gio.IInitable)GISharp.Lib.GObject.Object.GetInstance(initable_, GISharp.Runtime.Transfer.None)!;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doInit = (Init)methodInfo.CreateDelegate(typeof(Init), initable);
                        doInit(cancellable);
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

                return unmanagedInit;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public InitableIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}