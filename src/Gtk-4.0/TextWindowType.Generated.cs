// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTextWindowType", IsProxyForUnmanagedType = true)]
    public enum TextWindowType
    {
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Widget']/*" />
        Widget = 1,
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Text']/*" />
        Text = 2,
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Left']/*" />
        Left = 3,
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Right']/*" />
        Right = 4,
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Top']/*" />
        Top = 5,
        /// <include file="TextWindowType.xmldoc" path="declaration/member[@name='TextWindowType.Bottom']/*" />
        Bottom = 6
    }

    /// <summary>
    /// Extension methods for <see cref="TextWindowType"/>.
    /// </summary>
    public static partial class TextWindowTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_text_window_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_text_window_type_get_type();
    }
}