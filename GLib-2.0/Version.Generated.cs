namespace GISharp.Lib.GLib
{
    public static partial class Version
    {
        /// <summary>
        /// The major version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #glib_major_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 major = 2;

        /// <summary>
        /// The minor version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_minor_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 minor = 56;

        /// <summary>
        /// The micro version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_micro_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 micro = 0;

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
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr glib_check_version(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMajor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMinor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMicro);

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
        /// <paramref name="requiredMajor"/>.required_minor.<paramref name="requiredMicro"/>. Second
        /// the running library must be binary compatible with the
        /// version <paramref name="requiredMajor"/>.required_minor.<paramref name="requiredMicro"/>
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
        /// <c>null</c> if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static unsafe GISharp.Lib.GLib.Utf8 Check(System.UInt32 requiredMajor, System.UInt32 requiredMinor, System.UInt32 requiredMicro)
        {
            var requiredMajor_ = (System.UInt32)requiredMajor;
            var requiredMinor_ = (System.UInt32)requiredMinor;
            var requiredMicro_ = (System.UInt32)requiredMicro;
            var ret_ = glib_check_version(requiredMajor_,requiredMinor_,requiredMicro_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }
}