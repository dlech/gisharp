// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PageOrientation.xmldoc" path="declaration/member[@name='PageOrientation']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPageOrientation", IsProxyForUnmanagedType = true)]
    public enum PageOrientation
    {
        /// <include file="PageOrientation.xmldoc" path="declaration/member[@name='PageOrientation.Portrait']/*" />
        Portrait = 0,
        /// <include file="PageOrientation.xmldoc" path="declaration/member[@name='PageOrientation.Landscape']/*" />
        Landscape = 1,
        /// <include file="PageOrientation.xmldoc" path="declaration/member[@name='PageOrientation.ReversePortrait']/*" />
        ReversePortrait = 2,
        /// <include file="PageOrientation.xmldoc" path="declaration/member[@name='PageOrientation.ReverseLandscape']/*" />
        ReverseLandscape = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PageOrientation"/>.
    /// </summary>
    public static unsafe partial class PageOrientationExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_page_orientation_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_page_orientation_get_type();
    }
}