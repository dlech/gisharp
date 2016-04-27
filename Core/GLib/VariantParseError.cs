using System;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// Error codes returned by parsing text-format GVariants.
    /// </summary>
    [ErrorDomain ("g-variant-parse-error-quark")]
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
}
