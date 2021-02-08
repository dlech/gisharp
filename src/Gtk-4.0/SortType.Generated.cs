// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SortType.xmldoc" path="declaration/member[@name='SortType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSortType", IsProxyForUnmanagedType = true)]
    public enum SortType
    {
        /// <include file="SortType.xmldoc" path="declaration/member[@name='SortType.Ascending']/*" />
        Ascending = 0,
        /// <include file="SortType.xmldoc" path="declaration/member[@name='SortType.Descending']/*" />
        Descending = 1
    }

    /// <summary>
    /// Extension methods for <see cref="SortType"/>.
    /// </summary>
    public static partial class SortTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_sort_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_sort_type_get_type();
    }
}