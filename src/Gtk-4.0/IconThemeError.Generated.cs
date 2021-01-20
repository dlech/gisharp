// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="IconThemeError.xmldoc" path="declaration/member[@name='IconThemeError']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkIconThemeError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gtk-icon-theme-error-quark")]
    public enum IconThemeError
    {
        /// <include file="IconThemeError.xmldoc" path="declaration/member[@name='IconThemeError.NotFound']/*" />
        NotFound = 0,
        /// <include file="IconThemeError.xmldoc" path="declaration/member[@name='IconThemeError.Failed']/*" />
        Failed = 1
    }

    /// <summary>
    /// Extension methods for <see cref="IconThemeError"/>.
    /// </summary>
    public static partial class IconThemeErrorDomain
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_icon_theme_error_get_type();

        /// <include file="IconThemeError.xmldoc" path="declaration/member[@name='IconThemeErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Lib.GLib.Quark gtk_icon_theme_error_quark();

        private static unsafe GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_icon_theme_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_icon_theme_error_get_type();
    }
}