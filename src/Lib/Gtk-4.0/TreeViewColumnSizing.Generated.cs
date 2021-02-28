// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TreeViewColumnSizing.xmldoc" path="declaration/member[@name='TreeViewColumnSizing']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTreeViewColumnSizing", IsProxyForUnmanagedType = true)]
    public enum TreeViewColumnSizing
    {
        /// <include file="TreeViewColumnSizing.xmldoc" path="declaration/member[@name='TreeViewColumnSizing.GrowOnly']/*" />
        GrowOnly = 0,
        /// <include file="TreeViewColumnSizing.xmldoc" path="declaration/member[@name='TreeViewColumnSizing.Autosize']/*" />
        Autosize = 1,
        /// <include file="TreeViewColumnSizing.xmldoc" path="declaration/member[@name='TreeViewColumnSizing.Fixed']/*" />
        Fixed = 2
    }

    /// <summary>
    /// Extension methods for <see cref="TreeViewColumnSizing"/>.
    /// </summary>
    public static unsafe partial class TreeViewColumnSizingExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_tree_view_column_sizing_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_tree_view_column_sizing_get_type();
    }
}