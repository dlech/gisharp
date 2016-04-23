using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    class TypeInstance : StaticOpaque
    {
        internal struct TypeInstance_
        {
            public TypeClass.TypeClass_ GClass;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
            AssertNotDisposed();
            var ret = g_type_instance_get_private(Handle, privateType);
            return ret;
        }

        TypeInstance(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }
    }
}
