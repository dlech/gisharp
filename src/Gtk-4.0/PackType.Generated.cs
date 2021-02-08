// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PackType.xmldoc" path="declaration/member[@name='PackType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPackType", IsProxyForUnmanagedType = true)]
    public enum PackType
    {
        /// <include file="PackType.xmldoc" path="declaration/member[@name='PackType.Start']/*" />
        Start = 0,
        /// <include file="PackType.xmldoc" path="declaration/member[@name='PackType.End']/*" />
        End = 1
    }

    /// <summary>
    /// Extension methods for <see cref="PackType"/>.
    /// </summary>
    public static partial class PackTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_pack_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_pack_type_get_type();
    }
}