// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SorterChange.xmldoc" path="declaration/member[@name='SorterChange']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSorterChange", IsProxyForUnmanagedType = true)]
    public enum SorterChange
    {
        /// <include file="SorterChange.xmldoc" path="declaration/member[@name='SorterChange.Different']/*" />
        Different = 0,
        /// <include file="SorterChange.xmldoc" path="declaration/member[@name='SorterChange.Inverted']/*" />
        Inverted = 1,
        /// <include file="SorterChange.xmldoc" path="declaration/member[@name='SorterChange.LessStrict']/*" />
        LessStrict = 2,
        /// <include file="SorterChange.xmldoc" path="declaration/member[@name='SorterChange.MoreStrict']/*" />
        MoreStrict = 3
    }

    /// <summary>
    /// Extension methods for <see cref="SorterChange"/>.
    /// </summary>
    public static unsafe partial class SorterChangeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_sorter_change_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_sorter_change_get_type();
    }
}