using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    /// <summary>
    /// Flags to be passed to <see cref="GISharp.Core.Object.BindProperty"/>.
    /// </summary>
    /// <remarks>
    /// This enumeration can be extended at later date.
    /// </remarks>
    [Since ("2.26")]
    [Flags, GType (Name = "GBindingFlags", IsWrappedNativeType = true)]
    public enum BindingFlags
    {
        /// <summary>
        /// The default binding; if the source property
        ///   changes, the target property is updated with its value.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Bidirectional binding; if either the
        ///   property of the source or the property of the target changes,
        ///   the other is updated.
        /// </summary>
        Bidirectional = 1,

        /// <summary>
        /// Synchronize the values of the source and
        ///   target properties when creating the binding; the direction of
        ///   the synchronization is always from the source to the target.
        /// </summary>
        SyncCreate = 2,

        /// <summary>
        /// If the two properties being bound are
        ///   booleans, setting one to <c>true</c> will result in the other being
        ///   set to <c>false</c> and vice versa. This flag will only work for
        ///   boolean properties, and cannot be used when passing custom
        ///   transformation functions to <see cref="GISharp.Core.Object.BindProperty"/>.
        /// </summary>
        InvertBoolean = 4,
    }

    public static class BindingFlagsExtensions
    {
        static BindingFlagsExtensions()
        {
            GType.Register(typeof(BindingFlags));
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_binding_flags_get_type ();

        static GType getGType ()
        {
            return g_binding_flags_get_type ();
        }
    }
}
