// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="NotebookTab.xmldoc" path="declaration/member[@name='NotebookTab']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkNotebookTab", IsProxyForUnmanagedType = true)]
    public enum NotebookTab
    {
        /// <include file="NotebookTab.xmldoc" path="declaration/member[@name='NotebookTab.First']/*" />
        First = 0,
        /// <include file="NotebookTab.xmldoc" path="declaration/member[@name='NotebookTab.Last']/*" />
        Last = 1
    }

    /// <summary>
    /// Extension methods for <see cref="NotebookTab"/>.
    /// </summary>
    public static partial class NotebookTabExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_notebook_tab_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_notebook_tab_get_type();
    }
}