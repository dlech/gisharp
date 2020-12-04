// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PickFlags.xmldoc" path="declaration/member[@name='PickFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPickFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum PickFlags
    {
        /// <include file="PickFlags.xmldoc" path="declaration/member[@name='PickFlags.Default']/*" />
        Default = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="PickFlags.xmldoc" path="declaration/member[@name='PickFlags.Insensitive']/*" />
        Insensitive = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="PickFlags.xmldoc" path="declaration/member[@name='PickFlags.NonTargetable']/*" />
        NonTargetable = 0b0000_0000_0000_0000_0000_0000_0000_0010
    }

    /// <summary>
    /// Extension methods for <see cref="PickFlags"/>.
    /// </summary>
    public static partial class PickFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_pick_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_pick_flags_get_type();
    }
}