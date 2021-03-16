// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TextExtendSelection.xmldoc" path="declaration/member[@name='TextExtendSelection']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTextExtendSelection", IsProxyForUnmanagedType = true)]
    public enum TextExtendSelection
    {
        /// <include file="TextExtendSelection.xmldoc" path="declaration/member[@name='TextExtendSelection.Word']/*" />
        Word = 0,
        /// <include file="TextExtendSelection.xmldoc" path="declaration/member[@name='TextExtendSelection.Line']/*" />
        Line = 1
    }

    /// <summary>
    /// Extension methods for <see cref="TextExtendSelection"/>.
    /// </summary>
    public static unsafe partial class TextExtendSelectionExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_text_extend_selection_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_text_extend_selection_get_type();
    }
}