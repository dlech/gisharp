// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TreeViewGridLines.xmldoc" path="declaration/member[@name='TreeViewGridLines']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTreeViewGridLines", IsProxyForUnmanagedType = true)]
    public enum TreeViewGridLines
    {
        /// <include file="TreeViewGridLines.xmldoc" path="declaration/member[@name='TreeViewGridLines.None']/*" />
        None = 0,
        /// <include file="TreeViewGridLines.xmldoc" path="declaration/member[@name='TreeViewGridLines.Horizontal']/*" />
        Horizontal = 1,
        /// <include file="TreeViewGridLines.xmldoc" path="declaration/member[@name='TreeViewGridLines.Vertical']/*" />
        Vertical = 2,
        /// <include file="TreeViewGridLines.xmldoc" path="declaration/member[@name='TreeViewGridLines.Both']/*" />
        Both = 3
    }

    /// <summary>
    /// Extension methods for <see cref="TreeViewGridLines"/>.
    /// </summary>
    public static unsafe partial class TreeViewGridLinesExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_tree_view_grid_lines_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_tree_view_grid_lines_get_type();
    }
}