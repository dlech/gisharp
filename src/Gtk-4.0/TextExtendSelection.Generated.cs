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
    public static partial class TextExtendSelectionExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_text_extend_selection_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_text_extend_selection_get_type();
    }
}