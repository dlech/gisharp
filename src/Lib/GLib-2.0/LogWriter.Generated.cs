// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="LogWriter.xmldoc" path="declaration/member[@name='LogWriter']/*" />
    public static unsafe partial class LogWriter
    {
        /// <summary>
        /// Set a writer function which will be called to format and write out each log
        /// message. Each program should set a writer function, or the default writer
        /// (g_log_writer_default()) will be used.
        /// </summary>
        /// <remarks>
        /// Libraries **must not** call this function — only programs are allowed to
        /// install a writer function, as there must be a single, central point where
        /// log messages are formatted and outputted.
        /// 
        /// There can only be one writer function. It is an error to set more than one.
        /// </remarks>
        /// <param name="func">
        /// log writer function, which must not be %NULL
        /// </param>
        /// <param name="userData">
        /// user data to pass to @func
        /// </param>
        /// <param name="userDataFree">
        /// function to free @user_data once it’s
        ///    finished with, if non-%NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_log_set_writer_func(
        /* <type name="LogWriterFunc" type="GLogWriterFunc" managed-name="LogWriterFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        delegate* unmanaged[Cdecl]<GISharp.Lib.GLib.LogLevelFlags, GISharp.Lib.GLib.LogField*, nuint, System.IntPtr, GISharp.Lib.GLib.LogWriterOutput> func,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
        /* transfer-ownership:none scope:async destroy:0 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> userDataFree);

        /// <summary>
        /// Format a structured log message and output it to the default log destination
        /// for the platform. On Linux, this is typically the systemd journal, falling
        /// back to `stdout` or `stderr` if running from the terminal or if output is
        /// being redirected to a file.
        /// </summary>
        /// <remarks>
        /// Support for other platform-specific logging mechanisms may be added in
        /// future. Distributors of GLib may modify this function to impose their own
        /// (documented) platform-specific log writing policies.
        /// 
        /// This is suitable for use as a #GLogWriterFunc, and is the default writer used
        /// if no other is set using g_log_set_writer_func().
        /// 
        /// As with g_log_default_handler(), this function drops debug and informational
        /// messages unless their log domain (or `all`) is listed in the space-separated
        /// `G_MESSAGES_DEBUG` environment variable.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        ///    the log message
        /// </param>
        /// <param name="nFields">
        /// number of elements in the @fields array
        /// </param>
        /// <param name="userData">
        /// user data passed to g_log_set_writer_func()
        /// </param>
        /// <returns>
        /// %G_LOG_WRITER_HANDLED on success, %G_LOG_WRITER_UNHANDLED otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.LogWriterOutput g_log_writer_default(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="const GLogField*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="LogField" type="GLogField" managed-name="LogField" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogField* fields,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint nFields,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Format a structured log message as a string suitable for outputting to the
        /// terminal (or elsewhere). This will include the values of all fields it knows
        /// how to interpret, which includes `MESSAGE` and `GLIB_DOMAIN` (see the
        /// documentation for g_log_structured()). It does not include values from
        /// unknown fields.
        /// </summary>
        /// <remarks>
        /// The returned string does **not** have a trailing new-line character. It is
        /// encoded in the character set of the current locale, which is not necessarily
        /// UTF-8.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        ///    the log message
        /// </param>
        /// <param name="nFields">
        /// number of elements in the @fields array
        /// </param>
        /// <param name="useColor">
        /// %TRUE to use ANSI color escape sequences when formatting the
        ///    message, %FALSE to not
        /// </param>
        /// <returns>
        /// string containing the formatted log message, in
        ///    the character set of the current locale
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_log_writer_format_fields(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="const GLogField*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="LogField" type="GLogField" managed-name="LogField" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogField* fields,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint nFields,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean useColor);
        static partial void CheckFormatFieldsArgs(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields, bool useColor);

        /// <include file="LogWriter.xmldoc" path="declaration/member[@name='LogWriter.FormatFields(GISharp.Lib.GLib.LogLevelFlags,System.ReadOnlySpan&lt;GISharp.Lib.GLib.LogField&gt;,bool)']/*" />
        [GISharp.Runtime.SinceAttribute("2.50")]
        public static GISharp.Lib.GLib.Utf8 FormatFields(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields, bool useColor)
        {
            fixed (GISharp.Lib.GLib.LogField* fieldsData_ = fields)
            {
                CheckFormatFieldsArgs(logLevel, fields, useColor);
                var logLevel_ = (GISharp.Lib.GLib.LogLevelFlags)logLevel;
                var fields_ = (GISharp.Lib.GLib.LogField*)fieldsData_;
                var nFields_ = (nuint)fields.Length;
                var useColor_ = GISharp.Runtime.BooleanExtensions.ToBoolean(useColor);
                var ret_ = g_log_writer_format_fields(logLevel_,fields_,nFields_,useColor_);
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
                return ret;
            }
        }

        /// <summary>
        /// Check whether the given @output_fd file descriptor is a connection to the
        /// systemd journal, or something else (like a log file or `stdout` or
        /// `stderr`).
        /// </summary>
        /// <remarks>
        /// Invalid file descriptors are accepted and return %FALSE, which allows for
        /// the following construct without needing any additional error handling:
        /// |[&lt;!-- language="C" --&gt;
        ///   is_journald = g_log_writer_is_journald (fileno (stderr));
        /// ]|
        /// </remarks>
        /// <param name="outputFd">
        /// output file descriptor to check
        /// </param>
        /// <returns>
        /// %TRUE if @output_fd points to the journal, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_log_writer_is_journald(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int outputFd);
        static partial void CheckIsJournaldArgs(int outputFd);

        /// <include file="LogWriter.xmldoc" path="declaration/member[@name='LogWriter.IsJournald(int)']/*" />
        [GISharp.Runtime.SinceAttribute("2.50")]
        public static bool IsJournald(int outputFd)
        {
            CheckIsJournaldArgs(outputFd);
            var outputFd_ = (int)outputFd;
            var ret_ = g_log_writer_is_journald(outputFd_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Format a structured log message and send it to the systemd journal as a set
        /// of key–value pairs. All fields are sent to the journal, but if a field has
        /// length zero (indicating program-specific data) then only its key will be
        /// sent.
        /// </summary>
        /// <remarks>
        /// This is suitable for use as a #GLogWriterFunc.
        /// 
        /// If GLib has been compiled without systemd support, this function is still
        /// defined, but will always return %G_LOG_WRITER_UNHANDLED.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        ///    the log message
        /// </param>
        /// <param name="nFields">
        /// number of elements in the @fields array
        /// </param>
        /// <param name="userData">
        /// user data passed to g_log_set_writer_func()
        /// </param>
        /// <returns>
        /// %G_LOG_WRITER_HANDLED on success, %G_LOG_WRITER_UNHANDLED otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.LogWriterOutput g_log_writer_journald(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="const GLogField*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="LogField" type="GLogField" managed-name="LogField" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogField* fields,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint nFields,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Format a structured log message and print it to either `stdout` or `stderr`,
        /// depending on its log level. %G_LOG_LEVEL_INFO and %G_LOG_LEVEL_DEBUG messages
        /// are sent to `stdout`; all other log levels are sent to `stderr`. Only fields
        /// which are understood by this function are included in the formatted string
        /// which is printed.
        /// </summary>
        /// <remarks>
        /// If the output stream supports ANSI color escape sequences, they will be used
        /// in the output.
        /// 
        /// A trailing new-line character is added to the log message when it is printed.
        /// 
        /// This is suitable for use as a #GLogWriterFunc.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        ///    the log message
        /// </param>
        /// <param name="nFields">
        /// number of elements in the @fields array
        /// </param>
        /// <param name="userData">
        /// user data passed to g_log_set_writer_func()
        /// </param>
        /// <returns>
        /// %G_LOG_WRITER_HANDLED on success, %G_LOG_WRITER_UNHANDLED otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.LogWriterOutput g_log_writer_standard_streams(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="const GLogField*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="LogField" type="GLogField" managed-name="LogField" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogField* fields,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint nFields,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Check whether the given @output_fd file descriptor supports ANSI color
        /// escape sequences. If so, they can safely be used when formatting log
        /// messages.
        /// </summary>
        /// <param name="outputFd">
        /// output file descriptor to check
        /// </param>
        /// <returns>
        /// %TRUE if ANSI color escapes are supported, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_log_writer_supports_color(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int outputFd);
        static partial void CheckSupportsColorArgs(int outputFd);

        /// <include file="LogWriter.xmldoc" path="declaration/member[@name='LogWriter.SupportsColor(int)']/*" />
        [GISharp.Runtime.SinceAttribute("2.50")]
        public static bool SupportsColor(int outputFd)
        {
            CheckSupportsColorArgs(outputFd);
            var outputFd_ = (int)outputFd;
            var ret_ = g_log_writer_supports_color(outputFd_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}