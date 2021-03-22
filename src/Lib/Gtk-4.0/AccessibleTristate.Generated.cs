// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="AccessibleTristate.xmldoc" path="declaration/member[@name='AccessibleTristate']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkAccessibleTristate", IsProxyForUnmanagedType = true)]
    public enum AccessibleTristate
    {
        /// <include file="AccessibleTristate.xmldoc" path="declaration/member[@name='AccessibleTristate.False']/*" />
        False = 0,
        /// <include file="AccessibleTristate.xmldoc" path="declaration/member[@name='AccessibleTristate.True']/*" />
        True = 1,
        /// <include file="AccessibleTristate.xmldoc" path="declaration/member[@name='AccessibleTristate.Mixed']/*" />
        Mixed = 2
    }

    /// <summary>
    /// Extension methods for <see cref="AccessibleTristate"/>.
    /// </summary>
    public static unsafe partial class AccessibleTristateExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_accessible_tristate_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_accessible_tristate_get_type();
    }
}