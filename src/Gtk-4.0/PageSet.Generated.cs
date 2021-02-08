// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PageSet.xmldoc" path="declaration/member[@name='PageSet']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPageSet", IsProxyForUnmanagedType = true)]
    public enum PageSet
    {
        /// <include file="PageSet.xmldoc" path="declaration/member[@name='PageSet.All']/*" />
        All = 0,
        /// <include file="PageSet.xmldoc" path="declaration/member[@name='PageSet.Even']/*" />
        Even = 1,
        /// <include file="PageSet.xmldoc" path="declaration/member[@name='PageSet.Odd']/*" />
        Odd = 2
    }

    /// <summary>
    /// Extension methods for <see cref="PageSet"/>.
    /// </summary>
    public static unsafe partial class PageSetExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_page_set_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_page_set_get_type();
    }
}