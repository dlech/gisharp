// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="EntryIconPosition.xmldoc" path="declaration/member[@name='EntryIconPosition']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkEntryIconPosition", IsProxyForUnmanagedType = true)]
    public enum EntryIconPosition
    {
        /// <include file="EntryIconPosition.xmldoc" path="declaration/member[@name='EntryIconPosition.Primary']/*" />
        Primary = 0,
        /// <include file="EntryIconPosition.xmldoc" path="declaration/member[@name='EntryIconPosition.Secondary']/*" />
        Secondary = 1
    }

    /// <summary>
    /// Extension methods for <see cref="EntryIconPosition"/>.
    /// </summary>
    public static partial class EntryIconPositionExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_entry_icon_position_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_entry_icon_position_get_type();
    }
}