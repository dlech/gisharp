// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Version.xmldoc" path="declaration/member[@name='Version']/*" />
    public static unsafe partial class Version
    {
        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.major']/*" />
        private const System.Int32 major = 2;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.minor']/*" />
        private const System.Int32 minor = 66;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.micro']/*" />
        private const System.Int32 micro = 2;

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* glib_check_version(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint requiredMajor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint requiredMinor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint requiredMicro);
        static partial void CheckCheckArgs(uint requiredMajor, uint requiredMinor, uint requiredMicro);

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.Check(uint,uint,uint)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static GISharp.Lib.GLib.NullableUnownedUtf8 Check(uint requiredMajor, uint requiredMinor, uint requiredMicro)
        {
            CheckCheckArgs(requiredMajor, requiredMinor, requiredMicro);
            var requiredMajor_ = (uint)requiredMajor;
            var requiredMinor_ = (uint)requiredMinor;
            var requiredMicro_ = (uint)requiredMicro;
            var ret_ = glib_check_version(requiredMajor_,requiredMinor_,requiredMicro_);
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_);
            return ret;
        }
    }
}