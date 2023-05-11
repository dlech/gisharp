// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ContentFit.xmldoc" path="declaration/member[@name='ContentFit']/*" />
    [GISharp.Runtime.SinceAttribute("4.8")]
    [GISharp.Runtime.GTypeAttribute("GtkContentFit", IsProxyForUnmanagedType = true)]
    public enum ContentFit
    {
        /// <include file="ContentFit.xmldoc" path="declaration/member[@name='ContentFit.Fill']/*" />
        Fill = 0,
        /// <include file="ContentFit.xmldoc" path="declaration/member[@name='ContentFit.Contain']/*" />
        Contain = 1,
        /// <include file="ContentFit.xmldoc" path="declaration/member[@name='ContentFit.Cover']/*" />
        Cover = 2,
        /// <include file="ContentFit.xmldoc" path="declaration/member[@name='ContentFit.ScaleDown']/*" />
        ScaleDown = 3
    }

    /// <summary>
    /// Extension methods for <see cref="ContentFit"/>.
    /// </summary>
    public static unsafe partial class ContentFitExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_content_fit_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_content_fit_get_type();
    }
}