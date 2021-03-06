// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SorterOrder.xmldoc" path="declaration/member[@name='SorterOrder']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSorterOrder", IsProxyForUnmanagedType = true)]
    public enum SorterOrder
    {
        /// <include file="SorterOrder.xmldoc" path="declaration/member[@name='SorterOrder.Partial']/*" />
        Partial = 0,
        /// <include file="SorterOrder.xmldoc" path="declaration/member[@name='SorterOrder.None']/*" />
        None = 1,
        /// <include file="SorterOrder.xmldoc" path="declaration/member[@name='SorterOrder.Total']/*" />
        Total = 2
    }

    /// <summary>
    /// Extension methods for <see cref="SorterOrder"/>.
    /// </summary>
    public static unsafe partial class SorterOrderExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_sorter_order_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_sorter_order_get_type();
    }
}