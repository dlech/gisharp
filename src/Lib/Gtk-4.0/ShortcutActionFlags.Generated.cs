// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ShortcutActionFlags.xmldoc" path="declaration/member[@name='ShortcutActionFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkShortcutActionFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum ShortcutActionFlags : uint
    {
        /// <include file="ShortcutActionFlags.xmldoc" path="declaration/member[@name='ShortcutActionFlags.Exclusive']/*" />
        Exclusive = 0b0000_0000_0000_0000_0000_0000_0000_0001
    }

    /// <summary>
    /// Extension methods for <see cref="ShortcutActionFlags"/>.
    /// </summary>
    public static unsafe partial class ShortcutActionFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_shortcut_action_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_shortcut_action_flags_get_type();
    }
}