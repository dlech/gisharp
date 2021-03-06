// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TextSearchFlags.xmldoc" path="declaration/member[@name='TextSearchFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTextSearchFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum TextSearchFlags : uint
    {
        /// <include file="TextSearchFlags.xmldoc" path="declaration/member[@name='TextSearchFlags.VisibleOnly']/*" />
        VisibleOnly = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="TextSearchFlags.xmldoc" path="declaration/member[@name='TextSearchFlags.TextOnly']/*" />
        TextOnly = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="TextSearchFlags.xmldoc" path="declaration/member[@name='TextSearchFlags.CaseInsensitive']/*" />
        CaseInsensitive = 0b0000_0000_0000_0000_0000_0000_0000_0100
    }

    /// <summary>
    /// Extension methods for <see cref="TextSearchFlags"/>.
    /// </summary>
    public static unsafe partial class TextSearchFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_text_search_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_text_search_flags_get_type();
    }
}