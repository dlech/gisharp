// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkIconViewDropPosition", IsProxyForUnmanagedType = true)]
    public enum IconViewDropPosition
    {
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.NoDrop']/*" />
        NoDrop = 0,
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.DropInto']/*" />
        DropInto = 1,
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.DropLeft']/*" />
        DropLeft = 2,
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.DropRight']/*" />
        DropRight = 3,
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.DropAbove']/*" />
        DropAbove = 4,
        /// <include file="IconViewDropPosition.xmldoc" path="declaration/member[@name='IconViewDropPosition.DropBelow']/*" />
        DropBelow = 5
    }

    /// <summary>
    /// Extension methods for <see cref="IconViewDropPosition"/>.
    /// </summary>
    public static unsafe partial class IconViewDropPositionExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_icon_view_drop_position_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_icon_view_drop_position_get_type();
    }
}