// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GdkPixbuf
{
    /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError']/*" />
    [GISharp.Runtime.GTypeAttribute("GdkPixbufError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gdk-pixbuf-error-quark")]
    public enum PixbufError
    {
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.CorruptImage']/*" />
        CorruptImage = 0,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.InsufficientMemory']/*" />
        InsufficientMemory = 1,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.BadOption']/*" />
        BadOption = 2,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.UnknownType']/*" />
        UnknownType = 3,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.UnsupportedOperation']/*" />
        UnsupportedOperation = 4,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.Failed']/*" />
        Failed = 5,
        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufError.IncompleteAnimation']/*" />
        IncompleteAnimation = 6
    }

    /// <summary>
    /// Extension methods for <see cref="PixbufError"/>.
    /// </summary>
    public static unsafe partial class PixbufErrorDomain
    {
        private static readonly GISharp.Runtime.GType _GType = gdk_pixbuf_error_get_type();

        /// <include file="PixbufError.xmldoc" path="declaration/member[@name='PixbufErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        [System.Runtime.InteropServices.DllImportAttribute("gdk_pixbuf-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark gdk_pixbuf_error_quark();
        static partial void CheckGetQuarkArgs();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gdk_pixbuf_error_quark();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gdk_pixbuf-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gdk_pixbuf_error_get_type();
    }
}