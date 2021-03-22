// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintError']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPrintError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gtk-print-error-quark")]
    public enum PrintError
    {
        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintError.General']/*" />
        General = 0,
        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintError.InternalError']/*" />
        InternalError = 1,
        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintError.Nomem']/*" />
        Nomem = 2,
        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintError.InvalidFile']/*" />
        InvalidFile = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PrintError"/>.
    /// </summary>
    public static unsafe partial class PrintErrorDomain
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_print_error_get_type();

        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        /// <summary>
        /// Registers an error quark for #GtkPrintOperation if necessary.
        /// </summary>
        /// <returns>
        /// The error quark used for #GtkPrintOperation errors.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark gtk_print_error_quark();
        static partial void CheckGetQuarkArgs();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_print_error_quark();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_print_error_get_type();
    }
}