// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSizeRequestMode", IsProxyForUnmanagedType = true)]
    public enum SizeRequestMode
    {
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.HeightForWidth']/*" />
        HeightForWidth = 0,
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.WidthForHeight']/*" />
        WidthForHeight = 1,
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.ConstantSize']/*" />
        ConstantSize = 2
    }

    /// <summary>
    /// Extension methods for <see cref="SizeRequestMode"/>.
    /// </summary>
    public static unsafe partial class SizeRequestModeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_size_request_mode_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_size_request_mode_get_type();
    }
}