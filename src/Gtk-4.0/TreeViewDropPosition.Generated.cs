// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TreeViewDropPosition.xmldoc" path="declaration/member[@name='TreeViewDropPosition']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTreeViewDropPosition", IsProxyForUnmanagedType = true)]
    public enum TreeViewDropPosition
    {
        /// <include file="TreeViewDropPosition.xmldoc" path="declaration/member[@name='TreeViewDropPosition.Before']/*" />
        Before = 0,
        /// <include file="TreeViewDropPosition.xmldoc" path="declaration/member[@name='TreeViewDropPosition.After']/*" />
        After = 1,
        /// <include file="TreeViewDropPosition.xmldoc" path="declaration/member[@name='TreeViewDropPosition.IntoOrBefore']/*" />
        IntoOrBefore = 2,
        /// <include file="TreeViewDropPosition.xmldoc" path="declaration/member[@name='TreeViewDropPosition.IntoOrAfter']/*" />
        IntoOrAfter = 3
    }

    /// <summary>
    /// Extension methods for <see cref="TreeViewDropPosition"/>.
    /// </summary>
    public static partial class TreeViewDropPositionExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_tree_view_drop_position_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_tree_view_drop_position_get_type();
    }
}