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
        public new class SafeHandle : Object.SafeHandle
        {
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initially_unowned_get_type ();

        static GType getGType ()
        {
            return g_initially_unowned_get_type ();
        }

        public InitiallyUnowned (SafeHandle handle) : base (handle)
        {
        }
    }
}
