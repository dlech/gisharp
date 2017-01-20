using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// Flags to be passed to <see cref="Object.BindProperty(string,Object,string,BindingFlags)"/>.
    /// </summary>
    /// <remarks>
    /// This enumeration can be extended at later date.
    /// </remarks>
    [Since ("2.26")]
    [Flags, GType ("GBindingFlags", IsWrappedNativeType = true)]
    public enum BindingFlags
    {
        /// <summary>
        /// The default binding; if the source property
        /// changes, the target property is updated with its value.
        /// </summary>
        Default = 0x0,

        /// <summary>
        /// Bidirectional binding; if either the
        /// property of the source or the property of the target changes,
        /// the other is updated.
        /// </summary>
        Bidirectional = 0x1,

        /// <summary>
        /// Synchronize the values of the source and
        /// target properties when creating the binding; the direction of
        /// the synchronization is always from the source to the target.
        /// </summary>
        SyncCreate = 0x2,

        /// <summary>
        /// If the two properties being bound are
        /// booleans, setting one to <c>true</c> will result in the other being
        /// set to <c>false</c> and vice versa. This flag will only work for
        /// boolean properties, and cannot be used when passing custom
        /// transformation functions to <see cref="Object.BindProperty(string,Object,string,BindingFlags)"/>.
        /// </summary>
        InvertBoolean = 0x4,
    }

    public static class BindingFlagsExtensions
    {
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_binding_flags_get_type ();

        static GType getGType ()
        {
            return g_binding_flags_get_type ();
        }
    }
}
