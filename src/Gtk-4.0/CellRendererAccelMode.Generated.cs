// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="CellRendererAccelMode.xmldoc" path="declaration/member[@name='CellRendererAccelMode']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkCellRendererAccelMode", IsProxyForUnmanagedType = true)]
    public enum CellRendererAccelMode
    {
        /// <include file="CellRendererAccelMode.xmldoc" path="declaration/member[@name='CellRendererAccelMode.Gtk']/*" />
        Gtk = 0,
        /// <include file="CellRendererAccelMode.xmldoc" path="declaration/member[@name='CellRendererAccelMode.Other']/*" />
        Other = 1
    }

    /// <summary>
    /// Extension methods for <see cref="CellRendererAccelMode"/>.
    /// </summary>
    public static unsafe partial class CellRendererAccelModeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_cell_renderer_accel_mode_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_cell_renderer_accel_mode_get_type();
    }
}