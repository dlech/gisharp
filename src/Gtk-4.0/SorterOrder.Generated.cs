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
    public static partial class SorterOrderExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_sorter_order_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_sorter_order_get_type();
    }
}