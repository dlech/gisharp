// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TextDirection.xmldoc" path="declaration/member[@name='TextDirection']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTextDirection", IsProxyForUnmanagedType = true)]
    public enum TextDirection
    {
        /// <include file="TextDirection.xmldoc" path="declaration/member[@name='TextDirection.None']/*" />
        None = 0,
        /// <include file="TextDirection.xmldoc" path="declaration/member[@name='TextDirection.Ltr']/*" />
        Ltr = 1,
        /// <include file="TextDirection.xmldoc" path="declaration/member[@name='TextDirection.Rtl']/*" />
        Rtl = 2
    }

    /// <summary>
    /// Extension methods for <see cref="TextDirection"/>.
    /// </summary>
    public static unsafe partial class TextDirectionExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_text_direction_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_text_direction_get_type();
    }
}