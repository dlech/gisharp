namespace GISharp.Lib.Gio
{
    public class CancellableClass : GISharp.Lib.GObject.ObjectClass
    {
        unsafe new protected struct Struct
        {
#pragma warning disable CS0649
            public GISharp.Lib.GObject.ObjectClass.Struct ParentClass;
            public UnmanagedCancelled Cancelled;
            public System.IntPtr GReserved1;
            public System.IntPtr GReserved2;
            public System.IntPtr GReserved3;
            public System.IntPtr GReserved4;
            public System.IntPtr GReserved5;
#pragma warning restore CS0649
        }

        static CancellableClass()
        {
            System.Int32 cancelledOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Cancelled));
            RegisterVirtualMethod(cancelledOffset, CancelledFactory.Create);
        }

        public delegate void Cancelled();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate void UnmanagedCancelled(
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
System.IntPtr cancellable);

        /// <summary>
        /// Factory for creating <see cref="Cancelled"/> methods.
        /// </summary>
        public static class CancelledFactory
        {
            public static unsafe UnmanagedCancelled Create(System.Reflection.MethodInfo methodInfo)
            {
                void cancelled(System.IntPtr cancellable_)
                {
                    try
                    {
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doCancelled = (Cancelled)methodInfo.CreateDelegate(typeof(Cancelled), cancellable);
                        doCancelled();
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }
                }

                return cancelled;
            }
        }

        public CancellableClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}