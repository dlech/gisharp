// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="FilterMatch.xmldoc" path="declaration/member[@name='FilterMatch']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkFilterMatch", IsProxyForUnmanagedType = true)]
    public enum FilterMatch
    {
        /// <include file="FilterMatch.xmldoc" path="declaration/member[@name='FilterMatch.Some']/*" />
        Some = 0,
        /// <include file="FilterMatch.xmldoc" path="declaration/member[@name='FilterMatch.None']/*" />
        None = 1,
        /// <include file="FilterMatch.xmldoc" path="declaration/member[@name='FilterMatch.All']/*" />
        All = 2
    }

    /// <summary>
    /// Extension methods for <see cref="FilterMatch"/>.
    /// </summary>
    public static unsafe partial class FilterMatchExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_filter_match_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_filter_match_get_type();
    }
}