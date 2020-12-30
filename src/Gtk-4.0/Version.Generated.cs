// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Version.xmldoc" path="declaration/member[@name='Version']/*" />
    public static partial class Version
    {
        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.CompileTimeBinaryAge']/*" />
        public const System.Int32 CompileTimeBinaryAge = 0;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.CompileTimeInterfaceAge']/*" />
        public const System.Int32 CompileTimeInterfaceAge = 0;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.majorVersion']/*" />
        private const System.Int32 majorVersion = 4;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.microVersion']/*" />
        private const System.Int32 microVersion = 0;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.minorVersion']/*" />
        private const System.Int32 minorVersion = 0;

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.RunTimeBinaryAge']/*" />
        public static System.UInt32 RunTimeBinaryAge { get => GetRunTimeBinaryAge(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.RunTimeInterfaceAge']/*" />
        public static System.UInt32 RunTimeInterfaceAge { get => GetRunTimeInterfaceAge(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MajorVersion']/*" />
        private static System.UInt32 MajorVersion { get => GetMajorVersion(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MicroVersion']/*" />
        private static System.UInt32 MicroVersion { get => GetMicroVersion(); }

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.MinorVersion']/*" />
        private static System.UInt32 MinorVersion { get => GetMinorVersion(); }

        static partial void CheckCheckArgs(System.UInt32 requiredMajor, System.UInt32 requiredMinor, System.UInt32 requiredMicro);

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
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// 
        /// This function is primarily for GTK modules; the module
        /// can call this function to check that it wasn’t loaded
        /// into an incompatible version of GTK. However, such a
        /// check isn’t completely reliable, since the module may be
        /// linked against an old version of GTK and calling the
        /// old version of gtk_check_version(), but still get loaded
        /// into an application using a newer version of GTK.
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
        /* transfer-ownership:none nullable:1 direction:out */
        private static extern unsafe System.IntPtr gtk_check_version(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMajor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMinor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMicro);

        /// <include file="Version.xmldoc" path="declaration/member[@name='Version.Check(System.UInt32,System.UInt32,System.UInt32)']/*" />
        public static unsafe GISharp.Lib.GLib.NullableUnownedUtf8 Check(System.UInt32 requiredMajor, System.UInt32 requiredMinor, System.UInt32 requiredMicro)
        {
            CheckCheckArgs(requiredMajor, requiredMinor, requiredMicro);
            var requiredMajor_ = (System.UInt32)requiredMajor;
            var requiredMinor_ = (System.UInt32)requiredMinor;
            var requiredMicro_ = (System.UInt32)requiredMicro;
            var ret_ = gtk_check_version(requiredMajor_,requiredMinor_,requiredMicro_);
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        static partial void CheckGetRunTimeBinaryAgeArgs();

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
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 gtk_get_binary_age();

        private static unsafe System.UInt32 GetRunTimeBinaryAge()
        {
            CheckGetRunTimeBinaryAgeArgs();
            var ret_ = gtk_get_binary_age();
            var ret = (System.UInt32)ret_;
            return ret;
        }

        static partial void CheckGetRunTimeInterfaceAgeArgs();

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
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 gtk_get_interface_age();

        private static unsafe System.UInt32 GetRunTimeInterfaceAge()
        {
            CheckGetRunTimeInterfaceAgeArgs();
            var ret_ = gtk_get_interface_age();
            var ret = (System.UInt32)ret_;
            return ret;
        }

        static partial void CheckGetMajorVersionArgs();

        /// <summary>
        /// Returns the major version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 3.)
        /// </summary>
        /// <remarks>
        /// This function is in the library, so it represents the GTK library
        /// your code is running against. Contrast with the %GTK_MAJOR_VERSION
        /// macro, which represents the major version of the GTK headers you
        /// have included when compiling your code.
        /// </remarks>
        /// <returns>
        /// the major version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 gtk_get_major_version();

        private static unsafe System.UInt32 GetMajorVersion()
        {
            CheckGetMajorVersionArgs();
            var ret_ = gtk_get_major_version();
            var ret = (System.UInt32)ret_;
            return ret;
        }

        static partial void CheckGetMicroVersionArgs();

        /// <summary>
        /// Returns the micro version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 5.)
        /// </summary>
        /// <remarks>
        /// This function is in the library, so it represents the GTK library
        /// your code is are running against. Contrast with the
        /// %GTK_MICRO_VERSION macro, which represents the micro version of the
        /// GTK headers you have included when compiling your code.
        /// </remarks>
        /// <returns>
        /// the micro version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 gtk_get_micro_version();

        private static unsafe System.UInt32 GetMicroVersion()
        {
            CheckGetMicroVersionArgs();
            var ret_ = gtk_get_micro_version();
            var ret = (System.UInt32)ret_;
            return ret;
        }

        static partial void CheckGetMinorVersionArgs();

        /// <summary>
        /// Returns the minor version number of the GTK library.
        /// (e.g. in GTK version 3.1.5 this is 1.)
        /// </summary>
        /// <remarks>
        /// This function is in the library, so it represents the GTK library
        /// your code is are running against. Contrast with the
        /// %GTK_MINOR_VERSION macro, which represents the minor version of the
        /// GTK headers you have included when compiling your code.
        /// </remarks>
        /// <returns>
        /// the minor version number of the GTK library
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 gtk_get_minor_version();

        private static unsafe System.UInt32 GetMinorVersion()
        {
            CheckGetMinorVersionArgs();
            var ret_ = gtk_get_minor_version();
            var ret = (System.UInt32)ret_;
            return ret;
        }
    }
}