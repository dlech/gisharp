// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserError']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkFileChooserError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gtk-file-chooser-error-quark")]
    public enum FileChooserError
    {
        /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserError.Nonexistent']/*" />
        Nonexistent = 0,
        /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserError.BadFilename']/*" />
        BadFilename = 1,
        /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserError.AlreadyExists']/*" />
        AlreadyExists = 2,
        /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserError.IncompleteHostname']/*" />
        IncompleteHostname = 3
    }

    /// <summary>
    /// Extension methods for <see cref="FileChooserError"/>.
    /// </summary>
    public static partial class FileChooserErrorDomain
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_file_chooser_error_get_type();

        /// <include file="FileChooserError.xmldoc" path="declaration/member[@name='FileChooserErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();

        /// <summary>
        /// Registers an error quark for #GtkFileChooser if necessary.
        /// </summary>
        /// <returns>
        /// The error quark used for #GtkFileChooser errors.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern unsafe GISharp.Lib.GLib.Quark gtk_file_chooser_error_quark();

        private static unsafe GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_file_chooser_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_file_chooser_error_get_type();
    }
}