// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkConstraintVflParserError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gtk-constraint-vfl-parser-error-quark")]
    public enum ConstraintVflParserError
    {
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidSymbol']/*" />
        InvalidSymbol = 0,
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidAttribute']/*" />
        InvalidAttribute = 1,
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidView']/*" />
        InvalidView = 2,
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidMetric']/*" />
        InvalidMetric = 3,
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidPriority']/*" />
        InvalidPriority = 4,
        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserError.InvalidRelation']/*" />
        InvalidRelation = 5
    }

    /// <summary>
    /// Extension methods for <see cref="ConstraintVflParserError"/>.
    /// </summary>
    public static unsafe partial class ConstraintVflParserErrorDomain
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_constraint_vfl_parser_error_get_type();

        /// <include file="ConstraintVflParserError.xmldoc" path="declaration/member[@name='ConstraintVflParserErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark gtk_constraint_vfl_parser_error_quark();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_constraint_vfl_parser_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_constraint_vfl_parser_error_get_type();
    }
}