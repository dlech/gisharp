// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Version.xmldoc" path="declaration/member[@name='Version']/*" />
    public static unsafe partial class Version
    {
        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.CompileTimeBinaryAge']/*" />
        public const System.Int32 CompileTimeBinaryAge = 3;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.CompileTimeInterfaceAge']/*" />
        public const System.Int32 CompileTimeInterfaceAge = 3;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.majorVersion']/*" />
        private const System.Int32 majorVersion = 4;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.microVersion']/*" />
        private const System.Int32 microVersion = 3;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.minorVersion']/*" />
        private const System.Int32 minorVersion = 0;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.RunTimeBinaryAge']/*" />
        public static uint RunTimeBinaryAge { get => GetRunTimeBinaryAge(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.RunTimeInterfaceAge']/*" />
        public static uint RunTimeInterfaceAge { get => GetRunTimeInterfaceAge(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MajorVersion']/*" />
        private static uint MajorVersion { get => GetMajorVersion(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MicroVersion']/*" />
        private static uint MicroVersion { get => GetMicroVersion(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MinorVersion']/*" />
        private static uint MinorVersion { get => GetMinorVersion(); }

        /// <summary>
        /// Checks that the GTK library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// %GTK_MAJOR_VERSION, %GTK_MINOR_VERSION, %GTK_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GTK the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </para>
        /// <para>
        /// This function is primarily for GTK modules; the module
        /// can call this function to check that it wasn’t loaded
        /// into an incompatible version of GTK. However, such a
        /// check isn’t completely reliable, since the module may be
        /// linked against an old version of GTK and calling the
        /// old version of gtk_check_version(), but still get loaded
        /// into an application using a newer version of GTK.
        /// </para>
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
        /// %NULL if the GTK library is compatible with the
        ///   given version, or a string describing the version mismatch.
        ///   The returned string is owned by GTK and should not be modified
        ///   or freed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* gtk_check_version(
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
        public static GISharp.Lib.GLib.NullableUnownedUtf8 Check(uint requiredMajor, uint requiredMinor, uint requiredMicro)
        {
            CheckCheckArgs(requiredMajor, requiredMinor, requiredMicro);
            var requiredMajor_ = (uint)requiredMajor;
            var requiredMinor_ = (uint)requiredMinor;
            var requiredMicro_ = (uint)requiredMicro;
            var ret_ = gtk_check_version(requiredMajor_,requiredMinor_,requiredMicro_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Returns the binary age as passed to `libtool`
        /// when building the GTK library the process is running against.
        /// If `libtool` means nothing to you, don't
        /// worry about it.
        /// </summary>
        /// <returns>
        /// the binary age of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint gtk_get_binary_age();
        static partial void CheckGetRunTimeBinaryAgeArgs();

        private static uint GetRunTimeBinaryAge()
        {
            CheckGetRunTimeBinaryAgeArgs();
            var ret_ = gtk_get_binary_age();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the interface age as passed to `libtool`
        /// when building the GTK library the process is running against.
        /// If `libtool` means nothing to you, don't
        /// worry about it.
        /// </summary>
        /// <returns>
        /// the interface age of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint gtk_get_interface_age();
        static partial void CheckGetRunTimeInterfaceAgeArgs();

        private static uint GetRunTimeInterfaceAge()
        {
            CheckGetRunTimeInterfaceAgeArgs();
            var ret_ = gtk_get_interface_age();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the major version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 3.)
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is in the library, so it represents the GTK library
        /// your code is running against. Contrast with the %GTK_MAJOR_VERSION
        /// macro, which represents the major version of the GTK headers you
        /// have included when compiling your code.
        /// </para>
        /// </remarks>
        /// <returns>
        /// the major version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint gtk_get_major_version();
        static partial void CheckGetMajorVersionArgs();

        private static uint GetMajorVersion()
        {
            CheckGetMajorVersionArgs();
            var ret_ = gtk_get_major_version();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the micro version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 5.)
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is in the library, so it represents the GTK library
        /// your code is are running against. Contrast with the
        /// %GTK_MICRO_VERSION macro, which represents the micro version of the
        /// GTK headers you have included when compiling your code.
        /// </para>
        /// </remarks>
        /// <returns>
        /// the micro version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint gtk_get_micro_version();
        static partial void CheckGetMicroVersionArgs();

        private static uint GetMicroVersion()
        {
            CheckGetMicroVersionArgs();
            var ret_ = gtk_get_micro_version();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the minor version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 1.)
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is in the library, so it represents the GTK library
        /// your code is are running against. Contrast with the
        /// %GTK_MINOR_VERSION macro, which represents the minor version of the
        /// GTK headers you have included when compiling your code.
        /// </para>
        /// </remarks>
        /// <returns>
        /// the minor version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint gtk_get_minor_version();
        static partial void CheckGetMinorVersionArgs();

        private static uint GetMinorVersion()
        {
            CheckGetMinorVersionArgs();
            var ret_ = gtk_get_minor_version();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }
    }
}