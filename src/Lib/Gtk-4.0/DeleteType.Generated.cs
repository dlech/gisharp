// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkDeleteType", IsProxyForUnmanagedType = true)]
    public enum DeleteType
    {
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.Chars']/*" />
        Chars = 0,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.WordEnds']/*" />
        WordEnds = 1,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.Words']/*" />
        Words = 2,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.DisplayLines']/*" />
        DisplayLines = 3,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.DisplayLineEnds']/*" />
        DisplayLineEnds = 4,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.ParagraphEnds']/*" />
        ParagraphEnds = 5,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.Paragraphs']/*" />
        Paragraphs = 6,
        /// <include file="DeleteType.xmldoc" path="declaration/member[@name='DeleteType.Whitespace']/*" />
        Whitespace = 7
    }

    /// <summary>
    /// Extension methods for <see cref="DeleteType"/>.
    /// </summary>
    public static unsafe partial class DeleteTypeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_delete_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_delete_type_get_type();
    }
}