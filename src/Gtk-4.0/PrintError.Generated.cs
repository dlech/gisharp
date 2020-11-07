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
    public static partial class PrintErrorDomain
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_print_error_get_type();

        /// <include file="PrintError.xmldoc" path="declaration/member[@name='PrintErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();

        /// <summary>
        /// Registers an error quark for #GtkPrintOperation if necessary.
        /// </summary>
        /// <returns>
        /// The error quark used for #GtkPrintOperation errors.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Lib.GLib.Quark gtk_print_error_quark();

        private static unsafe GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_print_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_print_error_get_type();
    }
}