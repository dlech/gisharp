// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Ordering.xmldoc" path="declaration/member[@name='Ordering']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkOrdering", IsProxyForUnmanagedType = true)]
    public enum Ordering
    {
        /// <include file="Ordering.xmldoc" path="declaration/member[@name='Ordering.Smaller']/*" />
        Smaller = -1,
        /// <include file="Ordering.xmldoc" path="declaration/member[@name='Ordering.Equal']/*" />
        Equal = 0,
        /// <include file="Ordering.xmldoc" path="declaration/member[@name='Ordering.Larger']/*" />
        Larger = 1
    }

    /// <summary>
    /// Extension methods for <see cref="Ordering"/>.
    /// </summary>
    public static partial class OrderingExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_ordering_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_ordering_get_type();
    }
}