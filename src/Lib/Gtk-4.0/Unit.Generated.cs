// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Unit.xmldoc" path="declaration/member[@name='Unit']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkUnit", IsProxyForUnmanagedType = true)]
    public enum Unit
    {
        /// <include file="Unit.xmldoc" path="declaration/member[@name='Unit.None']/*" />
        None = 0,
        /// <include file="Unit.xmldoc" path="declaration/member[@name='Unit.Points']/*" />
        Points = 1,
        /// <include file="Unit.xmldoc" path="declaration/member[@name='Unit.Inch']/*" />
        Inch = 2,
        /// <include file="Unit.xmldoc" path="declaration/member[@name='Unit.Mm']/*" />
        Mm = 3
    }

    /// <summary>
    /// Extension methods for <see cref="Unit"/>.
    /// </summary>
    public static unsafe partial class UnitExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_unit_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_unit_get_type();
    }
}