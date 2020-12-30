// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ShortcutActionFlags.xmldoc" path="declaration/member[@name='ShortcutActionFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkShortcutActionFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum ShortcutActionFlags
    {
        /// <include file="ShortcutActionFlags.xmldoc" path="declaration/member[@name='ShortcutActionFlags.Exclusive']/*" />
        Exclusive = 0b0000_0000_0000_0000_0000_0000_0000_0001
    }

    /// <summary>
    /// Extension methods for <see cref="ShortcutActionFlags"/>.
    /// </summary>
    public static partial class ShortcutActionFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_shortcut_action_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_shortcut_action_flags_get_type();
    }
}