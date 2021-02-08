// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Justification.xmldoc" path="declaration/member[@name='Justification']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkJustification", IsProxyForUnmanagedType = true)]
    public enum Justification
    {
        /// <include file="Justification.xmldoc" path="declaration/member[@name='Justification.Left']/*" />
        Left = 0,
        /// <include file="Justification.xmldoc" path="declaration/member[@name='Justification.Right']/*" />
        Right = 1,
        /// <include file="Justification.xmldoc" path="declaration/member[@name='Justification.Center']/*" />
        Center = 2,
        /// <include file="Justification.xmldoc" path="declaration/member[@name='Justification.Fill']/*" />
        Fill = 3
    }

    /// <summary>
    /// Extension methods for <see cref="Justification"/>.
    /// </summary>
    public static partial class JustificationExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_justification_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_justification_get_type();
    }
}