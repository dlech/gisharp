// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="IconLookupFlags.xmldoc" path="declaration/member[@name='IconLookupFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkIconLookupFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum IconLookupFlags : uint
    {
        /// <include file="IconLookupFlags.xmldoc" path="declaration/member[@name='IconLookupFlags.ForceRegular']/*" />
        ForceRegular = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="IconLookupFlags.xmldoc" path="declaration/member[@name='IconLookupFlags.ForceSymbolic']/*" />
        ForceSymbolic = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="IconLookupFlags.xmldoc" path="declaration/member[@name='IconLookupFlags.Preload']/*" />
        Preload = 0b0000_0000_0000_0000_0000_0000_0000_0100
    }

    /// <summary>
    /// Extension methods for <see cref="IconLookupFlags"/>.
    /// </summary>
    public static unsafe partial class IconLookupFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_icon_lookup_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_icon_lookup_flags_get_type();
    }
}