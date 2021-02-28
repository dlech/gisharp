// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkBuilderError", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("gtk-builder-error-quark")]
    public enum BuilderError
    {
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidTypeFunction']/*" />
        InvalidTypeFunction = 0,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.UnhandledTag']/*" />
        UnhandledTag = 1,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.MissingAttribute']/*" />
        MissingAttribute = 2,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidAttribute']/*" />
        InvalidAttribute = 3,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidTag']/*" />
        InvalidTag = 4,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.MissingPropertyValue']/*" />
        MissingPropertyValue = 5,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidValue']/*" />
        InvalidValue = 6,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.VersionMismatch']/*" />
        VersionMismatch = 7,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.DuplicateId']/*" />
        DuplicateId = 8,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.ObjectTypeRefused']/*" />
        ObjectTypeRefused = 9,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.TemplateMismatch']/*" />
        TemplateMismatch = 10,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidProperty']/*" />
        InvalidProperty = 11,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidSignal']/*" />
        InvalidSignal = 12,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidId']/*" />
        InvalidId = 13,
        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderError.InvalidFunction']/*" />
        InvalidFunction = 14
    }

    /// <summary>
    /// Extension methods for <see cref="BuilderError"/>.
    /// </summary>
    public static unsafe partial class BuilderErrorDomain
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_builder_error_get_type();

        /// <include file="BuilderError.xmldoc" path="declaration/member[@name='BuilderErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark gtk_builder_error_quark();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = gtk_builder_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_builder_error_get_type();
    }
}