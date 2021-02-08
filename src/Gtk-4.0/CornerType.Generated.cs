// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="CornerType.xmldoc" path="declaration/member[@name='CornerType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkCornerType", IsProxyForUnmanagedType = true)]
    public enum CornerType
    {
        /// <include file="CornerType.xmldoc" path="declaration/member[@name='CornerType.TopLeft']/*" />
        TopLeft = 0,
        /// <include file="CornerType.xmldoc" path="declaration/member[@name='CornerType.BottomLeft']/*" />
        BottomLeft = 1,
        /// <include file="CornerType.xmldoc" path="declaration/member[@name='CornerType.TopRight']/*" />
        TopRight = 2,
        /// <include file="CornerType.xmldoc" path="declaration/member[@name='CornerType.BottomRight']/*" />
        BottomRight = 3
    }

    /// <summary>
    /// Extension methods for <see cref="CornerType"/>.
    /// </summary>
    public static unsafe partial class CornerTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_corner_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_corner_type_get_type();
    }
}