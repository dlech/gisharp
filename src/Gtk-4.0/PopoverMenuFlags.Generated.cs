// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PopoverMenuFlags.xmldoc" path="declaration/member[@name='PopoverMenuFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPopoverMenuFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum PopoverMenuFlags
    {
        /// <include file="PopoverMenuFlags.xmldoc" path="declaration/member[@name='PopoverMenuFlags.Nested']/*" />
        Nested = 0b0000_0000_0000_0000_0000_0000_0000_0001
    }

    /// <summary>
    /// Extension methods for <see cref="PopoverMenuFlags"/>.
    /// </summary>
    public static partial class PopoverMenuFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_popover_menu_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_popover_menu_flags_get_type();
    }
}