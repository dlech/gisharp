// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Orientation.xmldoc" path="declaration/member[@name='Orientation']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkOrientation", IsProxyForUnmanagedType = true)]
    public enum Orientation
    {
        /// <include file="Orientation.xmldoc" path="declaration/member[@name='Orientation.Horizontal']/*" />
        Horizontal = 0,
        /// <include file="Orientation.xmldoc" path="declaration/member[@name='Orientation.Vertical']/*" />
        Vertical = 1
    }

    /// <summary>
    /// Extension methods for <see cref="Orientation"/>.
    /// </summary>
    public static partial class OrientationExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_orientation_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_orientation_get_type();
    }
}