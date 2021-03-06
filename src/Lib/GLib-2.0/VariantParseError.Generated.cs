// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError']/*" />
    [GISharp.Runtime.GErrorDomainAttribute("g-variant-parse-error-quark")]
    public enum VariantParseError
    {
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.Failed']/*" />
        Failed = 0,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.BasicTypeExpected']/*" />
        BasicTypeExpected = 1,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.CannotInferType']/*" />
        CannotInferType = 2,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.DefiniteTypeExpected']/*" />
        DefiniteTypeExpected = 3,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InputNotAtEnd']/*" />
        InputNotAtEnd = 4,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InvalidCharacter']/*" />
        InvalidCharacter = 5,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InvalidFormatString']/*" />
        InvalidFormatString = 6,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InvalidObjectPath']/*" />
        InvalidObjectPath = 7,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InvalidSignature']/*" />
        InvalidSignature = 8,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.InvalidTypeString']/*" />
        InvalidTypeString = 9,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.NoCommonType']/*" />
        NoCommonType = 10,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.NumberOutOfRange']/*" />
        NumberOutOfRange = 11,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.NumberTooBig']/*" />
        NumberTooBig = 12,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.TypeError']/*" />
        TypeError = 13,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.UnexpectedToken']/*" />
        UnexpectedToken = 14,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.UnknownKeyword']/*" />
        UnknownKeyword = 15,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.UnterminatedStringConstant']/*" />
        UnterminatedStringConstant = 16,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.ValueExpected']/*" />
        ValueExpected = 17,
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseError.Recursion']/*" />
        [GISharp.Runtime.SinceAttribute("2.64")]
        Recursion = 18
    }

    /// <summary>
    /// Extension methods for <see cref="VariantParseError"/>.
    /// </summary>
    public static unsafe partial class VariantParseErrorDomain
    {
        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        /// <summary>
        /// Pretty-prints a message showing the context of a #GVariant parse
        /// error within the string for which parsing was attempted.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The resulting string is suitable for output to the console or other
        /// monospace media where newlines are treated in the usual way.
        /// </para>
        /// <para>
        /// The message will typically look something like one of the following:
        /// </para>
        /// <para>
        /// |[
        /// unterminated string constant:
        ///   (1, 2, 3, 'abc
        ///             ^^^^
        /// ]|
        /// </para>
        /// <para>
        /// or
        /// </para>
        /// <para>
        /// |[
        /// unable to find a common type:
        ///   [1, 2, 3, 'str']
        ///    ^        ^^^^^
        /// ]|
        /// </para>
        /// <para>
        /// The format of the message may change in a future version.
        /// </para>
        /// <para>
        /// @error must have come from a failed attempt to g_variant_parse() and
        /// @source_str must be exactly the same string that caused the error.
        /// If @source_str was not nul-terminated when you passed it to
        /// g_variant_parse() then you must add nul termination before using this
        /// function.
        /// </para>
        /// </remarks>
        /// <param name="error">
        /// a #GError from the #GVariantParseError domain
        /// </param>
        /// <param name="sourceStr">
        /// the string that was given to the parser
        /// </param>
        /// <returns>
        /// the printed message
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_variant_parse_error_print_context(
        /* <type name="Error" type="GError*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Error.UnmanagedStruct* error,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* sourceStr);
        static partial void CheckPrintContextArgs(GISharp.Lib.GLib.Error error, GISharp.Runtime.UnownedUtf8 sourceStr);

        /// <include file="VariantParseError.xmldoc" path="declaration/member[@name='VariantParseErrorDomain.PrintContext(GISharp.Lib.GLib.Error,GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public static GISharp.Runtime.Utf8 PrintContext(GISharp.Lib.GLib.Error error, GISharp.Runtime.UnownedUtf8 sourceStr)
        {
            CheckPrintContextArgs(error, sourceStr);
            var error_ = (GISharp.Lib.GLib.Error.UnmanagedStruct*)error.UnsafeHandle;
            var sourceStr_ = (byte*)sourceStr.UnsafeHandle;
            var ret_ = g_variant_parse_error_print_context(error_,sourceStr_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark g_variant_parse_error_quark();
        static partial void CheckGetQuarkArgs();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = g_variant_parse_error_quark();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}