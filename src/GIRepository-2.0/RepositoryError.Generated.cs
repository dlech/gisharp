// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryError']/*" />
    [GISharp.Runtime.GErrorDomainAttribute("g-irepository-error-quark")]
    public enum RepositoryError
    {
        /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryError.TypelibNotFound']/*" />
        TypelibNotFound = 0,
        /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryError.NamespaceMismatch']/*" />
        NamespaceMismatch = 1,
        /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryError.NamespaceVersionConflict']/*" />
        NamespaceVersionConflict = 2,
        /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryError.LibraryNotFound']/*" />
        LibraryNotFound = 3
    }

    /// <summary>
    /// Extension methods for <see cref="RepositoryError"/>.
    /// </summary>
    public static unsafe partial class RepositoryErrorDomain
    {
        /// <include file="RepositoryError.xmldoc" path="declaration/member[@name='RepositoryErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        static partial void CheckGetQuarkArgs();
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark g_irepository_error_quark();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = g_irepository_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}