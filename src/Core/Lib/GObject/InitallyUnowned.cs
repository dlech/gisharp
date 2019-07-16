using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// All the fields in the GInitiallyUnowned structure
    /// are private to the #GInitiallyUnowned implementation and should never be
    /// accessed directly.
    /// </summary>
    [GType ("GInitiallyUnowned", IsProxyForUnmanagedType = true)]
    [GTypeStruct (typeof(InitiallyUnownedClass))]
    public class InitiallyUnowned : Object
    {
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initially_unowned_get_type ();

        static readonly GType _GType = g_initially_unowned_get_type ();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public InitiallyUnowned (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
