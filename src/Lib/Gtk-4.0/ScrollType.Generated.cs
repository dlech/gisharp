// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkScrollType", IsProxyForUnmanagedType = true)]
    public enum ScrollType
    {
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.None']/*" />
        None = 0,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.Jump']/*" />
        Jump = 1,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepBackward']/*" />
        StepBackward = 2,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepForward']/*" />
        StepForward = 3,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageBackward']/*" />
        PageBackward = 4,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageForward']/*" />
        PageForward = 5,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepUp']/*" />
        StepUp = 6,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepDown']/*" />
        StepDown = 7,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageUp']/*" />
        PageUp = 8,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageDown']/*" />
        PageDown = 9,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepLeft']/*" />
        StepLeft = 10,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.StepRight']/*" />
        StepRight = 11,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageLeft']/*" />
        PageLeft = 12,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.PageRight']/*" />
        PageRight = 13,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.Start']/*" />
        Start = 14,
        /// <include file="ScrollType.xmldoc" path="declaration/member[@name='ScrollType.End']/*" />
        End = 15
    }

    /// <summary>
    /// Extension methods for <see cref="ScrollType"/>.
    /// </summary>
    public static unsafe partial class ScrollTypeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_scroll_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_scroll_type_get_type();
    }
}