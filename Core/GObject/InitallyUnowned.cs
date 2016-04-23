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
    [GTypeAttribute (Name = "GInitiallyUnowned", IsWrappedNativeType = true)]
    public class InitiallyUnowned : Object
    {
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initially_unowned_get_type ();

        static GType getGType ()
        {
            return g_initially_unowned_get_type ();
        }

        protected InitiallyUnowned (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : ObjectClass
    {
        InitiallyUnownedClass (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
