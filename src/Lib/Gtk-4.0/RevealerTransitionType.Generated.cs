// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkRevealerTransitionType", IsProxyForUnmanagedType = true)]
    public enum RevealerTransitionType
    {
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.None']/*" />
        None = 0,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.Crossfade']/*" />
        Crossfade = 1,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SlideRight']/*" />
        SlideRight = 2,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SlideLeft']/*" />
        SlideLeft = 3,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SlideUp']/*" />
        SlideUp = 4,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SlideDown']/*" />
        SlideDown = 5,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SwingRight']/*" />
        SwingRight = 6,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SwingLeft']/*" />
        SwingLeft = 7,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SwingUp']/*" />
        SwingUp = 8,
        /// <include file="RevealerTransitionType.xmldoc" path="declaration/member[@name='RevealerTransitionType.SwingDown']/*" />
        SwingDown = 9
    }

    /// <summary>
    /// Extension methods for <see cref="RevealerTransitionType"/>.
    /// </summary>
    public static unsafe partial class RevealerTransitionTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_revealer_transition_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_revealer_transition_type_get_type();
    }
}