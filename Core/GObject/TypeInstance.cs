using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract class TypeInstance : Opaque
    {
        public abstract class SafeTypeInstanceHandle : SafeHandleZeroIsInvalid
        {
            protected struct TypeInstanceStruct
            {
                public IntPtr GClass;
            }

            public IntPtr GClass {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var ret = Marshal.ReadIntPtr (handle);
                    return ret;
                }
            }
        }

        public new SafeTypeInstanceHandle Handle {
            get {
                return (SafeTypeInstanceHandle)base.Handle;
            }
        }

        protected TypeInstance (SafeTypeInstanceHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_type_instance_get_private (
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            SafeTypeInstanceHandle instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType privateType);

        public IntPtr GetPrivate (GType privateType)
        {
            var ret = g_type_instance_get_private (Handle, privateType);
            return ret;
        }
    }
}
