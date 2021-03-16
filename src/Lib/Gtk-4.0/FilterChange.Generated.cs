// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="FilterChange.xmldoc" path="declaration/member[@name='FilterChange']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkFilterChange", IsProxyForUnmanagedType = true)]
    public enum FilterChange
    {
        /// <include file="FilterChange.xmldoc" path="declaration/member[@name='FilterChange.Different']/*" />
        Different = 0,
        /// <include file="FilterChange.xmldoc" path="declaration/member[@name='FilterChange.LessStrict']/*" />
        LessStrict = 1,
        /// <include file="FilterChange.xmldoc" path="declaration/member[@name='FilterChange.MoreStrict']/*" />
        MoreStrict = 2
    }

    /// <summary>
    /// Extension methods for <see cref="FilterChange"/>.
    /// </summary>
    public static unsafe partial class FilterChangeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_filter_change_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_filter_change_get_type();
    }
}