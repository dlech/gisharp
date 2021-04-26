// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GdkPixbuf
{
    /// <include file="PixbufAlphaMode.xmldoc" path="declaration/member[@name='PixbufAlphaMode']/*" />
    [System.ObsoleteAttribute("There is no user of GdkPixbufAlphaMode in GdkPixbuf,\n  and the Xlib utility functions have been split out to their own\n  library, gdk-pixbuf-xlib")]
    [GISharp.Runtime.DeprecatedSinceAttribute("2.42")]
    [GISharp.Runtime.GTypeAttribute("GdkPixbufAlphaMode", IsProxyForUnmanagedType = true)]
    public enum PixbufAlphaMode
    {
        /// <include file="PixbufAlphaMode.xmldoc" path="declaration/member[@name='PixbufAlphaMode.Bilevel']/*" />
        Bilevel = 0,
        /// <include file="PixbufAlphaMode.xmldoc" path="declaration/member[@name='PixbufAlphaMode.Full']/*" />
        Full = 1
    }

    /// <summary>
    /// Extension methods for <see cref="PixbufAlphaMode"/>.
    /// </summary>
    public static unsafe partial class PixbufAlphaModeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gdk_pixbuf_alpha_mode_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gdk_pixbuf-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gdk_pixbuf_alpha_mode_get_type();
    }
}