// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="WrapMode.xmldoc" path="declaration/member[@name='WrapMode']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkWrapMode", IsProxyForUnmanagedType = true)]
    public enum WrapMode
    {
        /// <include file="WrapMode.xmldoc" path="declaration/member[@name='WrapMode.None']/*" />
        None = 0,
        /// <include file="WrapMode.xmldoc" path="declaration/member[@name='WrapMode.Char']/*" />
        Char = 1,
        /// <include file="WrapMode.xmldoc" path="declaration/member[@name='WrapMode.Word']/*" />
        Word = 2,
        /// <include file="WrapMode.xmldoc" path="declaration/member[@name='WrapMode.WordChar']/*" />
        WordChar = 3
    }

    /// <summary>
    /// Extension methods for <see cref="WrapMode"/>.
    /// </summary>
    public static partial class WrapModeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_wrap_mode_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_wrap_mode_get_type();
    }
}