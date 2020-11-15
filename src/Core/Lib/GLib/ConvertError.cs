using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Error codes returned by character set conversion routines.
    /// </summary>
    [GErrorDomain("g_convert_error")]
    public enum ConvertError
    {
        /// <summary>
        /// Conversion between the requested character
        ///     sets is not supported.
        /// </summary>
        NoConversion = 0,
        /// <summary>
        /// Invalid byte sequence in conversion input;
        ///    or the character sequence could not be represented in the target
        ///    character set.
        /// </summary>
        IllegalSequence = 1,
        /// <summary>
        /// Conversion failed for some reason.
        /// </summary>
        Failed = 2,
        /// <summary>
        /// Partial character sequence at end of input.
        /// </summary>
        PartialInput = 3,
        /// <summary>
        /// URI is invalid.
        /// </summary>
        BadUri = 4,
        /// <summary>
        /// Pathname is not an absolute path.
        /// </summary>
        NotAbsolutePath = 5,
        /// <summary>
        /// No memory available.
        /// </summary>
        [Since("2.40")]
        NoMemory = 6,
        /// <summary>
        /// An embedded NUL character is present in
        ///     conversion output where a NUL-terminated string is expected.
        /// </summary>
        [Since("2.56")]
        EmbeddedNul = 7
    }

    /// <summary>
    /// Error domain for character set conversions.
    ///</summary>
    /// <remarks>
    /// Errors in this domain will be from the <see cref="ConvertError" />
    /// enumeration. See <see cref="Error" /> for information on error domains.
    /// </remarks>
    public static class ConvertErrorDomain
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_convert_error_quark();

        /// <summary>
        /// Error quark for <see cref="ConvertError"/> domain.
        /// </summary>
        public static Quark Quark => g_convert_error_quark();
    }
}
