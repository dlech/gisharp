using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// All the fields in the GInitiallyUnowned structure
    /// are private to the #GInitiallyUnowned implementation and should never be
    /// accessed directly.
    /// </summary>
    [GType ("GInitiallyUnowned", IsWrappedNativeType = true)]
    [GTypeStruct (typeof(InitiallyUnownedClass))]
    public class InitiallyUnowned : Object
    {
        public class SafeInitiallyUnownedHandle : SafeObjectHandle
        {
            public SafeInitiallyUnownedHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeInitiallyUnownedHandle Handle {
            get {
                return (SafeInitiallyUnownedHandle)base.Handle;
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initially_unowned_get_type ();

        static GType getGType ()
        {
            return g_initially_unowned_get_type ();
        }

        public InitiallyUnowned (SafeInitiallyUnownedHandle handle) : base (handle)
        {
        }
    }
}
