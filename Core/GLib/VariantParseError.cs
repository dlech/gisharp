using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// Error codes returned by parsing text-format GVariants.
    /// </summary>
    [GErrorDomain ("g-variant-parse-error-quark")]
    public enum VariantParseError
    {
        /// <summary>
        /// generic error (unused)
        /// </summary>
        Failed = 0,
        /// <summary>
        /// a non-basic #GVariantType was given where a basic type was expected
        /// </summary>
        BasicTypeExpected = 1,
        /// <summary>
        /// cannot infer the #GVariantType
        /// </summary>
        CannotInferType = 2,
        /// <summary>
        /// an indefinite #GVariantType was given where a definite type was expected
        /// </summary>
        DefiniteTypeExpected = 3,
        /// <summary>
        /// extra data after parsing finished
        /// </summary>
        InputNotAtEnd = 4,
        /// <summary>
        /// invalid character in number or unicode escape
        /// </summary>
        InvalidCharacter = 5,
        /// <summary>
        /// not a valid #GVariant format string
        /// </summary>
        InvalidFormatString = 6,
        /// <summary>
        /// not a valid object path
        /// </summary>
        InvalidObjectPath = 7,
        /// <summary>
        /// not a valid type signature
        /// </summary>
        InvalidSignature = 8,
        /// <summary>
        /// not a valid #GVariant type string
        /// </summary>
        InvalidTypeString = 9,
        /// <summary>
        /// could not find a common type for array entries
        /// </summary>
        NoCommonType = 10,
        /// <summary>
        /// the numerical value is out of range of the given type
        /// </summary>
        NumberOutOfRange = 11,
        /// <summary>
        /// the numerical value is out of range for any type
        /// </summary>
        NumberTooBig = 12,
        /// <summary>
        /// cannot parse as variant of the specified type
        /// </summary>
        TypeError = 13,
        /// <summary>
        /// an unexpected token was encountered
        /// </summary>
        UnexpectedToken = 14,
        /// <summary>
        /// an unknown keyword was encountered
        /// </summary>
        UnknownKeyword = 15,
        /// <summary>
        /// unterminated string constant
        /// </summary>
        UnterminatedStringConstant = 16,
        /// <summary>
        /// no value given
        /// </summary>
        ValueExpected = 17
    }

    public static class VariantParseErrorDomain
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_variant_parse_error_quark();

        public static Quark Quark {
            get {
                var ret = g_variant_parse_error_quark();
                return ret;
            }
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.40")]
        static extern IntPtr g_variant_parse_error_print_context(IntPtr error, IntPtr sourceStr);

        /// <summary>
        /// Pretty-prints a message showing the context of a <see cref="Variant"/>
        /// parse error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// 
        /// The message will typically look something like one of the following:
        /// <code>
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// </code>
        /// or
        /// <code>
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// </code>
        /// The format of the message may change in a future version.
        /// 
        /// <paramref name="error"/> must have come from a failed attempt to
        /// <see cref="Variant.Parse(VariantType, Utf8)"/> and <paramref name="sourceStr"/>
        /// must be exactly the same string that caused the error.
        /// </remarks>
        /// <param name="error">
        /// a <see cref="Error"/> from the <see cref="VariantParseError"/> domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message.
        /// </returns>
        [Since("2.40")]
        public static Utf8 PrintContext(this Error error, Utf8 sourceStr)
        {
            var error_ = error?.Handle ?? throw new ArgumentNullException(nameof(error));
            if (error.Domain != Quark) {
                throw new ArgumentException("Requires VariantParseError", nameof(error));
            }
            var sourceStr_ = sourceStr?.Handle ?? throw new ArgumentNullException(nameof(sourceStr));
            var ret_ = g_variant_parse_error_print_context(error_, sourceStr_);
            var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }
    }
}
