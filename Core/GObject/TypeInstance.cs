using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract class TypeInstance : ReferenceCountedOpaque
    {
        protected struct TypeInstanceStruct
        {
            public IntPtr GClass;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_type_instance_get_private (
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType privateType);

        public IntPtr GetPrivate (GType privateType)
        {
            var ret = g_type_instance_get_private (Handle, privateType);
            return ret;
        }

        protected TypeInstance (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
