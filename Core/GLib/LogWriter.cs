using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    public static class LogWriter
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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_set_writer_func (
            /* <type name="LogWriterFunc" type="GLogWriterFunc" managed-name="LogWriterFunc" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 */
            NativeLogWriterFunc func,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 closure:0 */
            IntPtr userData,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async destroy:0 */
            NativeDestroyNotify userDataFree);

        static bool isFuncSet;

        /// <summary>
        /// Set a writer function which will be called to format and write out each log
        /// message. Each program should set a writer function, or the default writer
        /// (<see cref="Default"/>) will be used.
        /// </summary>
        /// <remarks>
        /// Libraries <b>must not</b> call this function — only programs are allowed to
        /// install a writer function, as there must be a single, central point where
        /// log messages are formatted and outputted.
        /// 
        /// There can only be one writer function. It is an error to set more than one.
        /// </remarks>
        /// <param name="func">
        /// log writer function, which must not be <c>null</c>
        /// </param>
        [Since ("2.50")]
        public static void SetFunc (LogWriterFunc func)
        {
            if (func == null) {
                throw new ArgumentNullException (nameof (func));
            }
            if (isFuncSet) {
                throw new InvalidOperationException ("Log writer function can only be set once.");
            }
            // If using one of the default functions, pass the unmanged function
            // pointer instead of wrapping the managed version.
            if (func == Default) {
                g_log_set_writer_func (g_log_writer_default, IntPtr.Zero, null);
            } else if (func == Journald) {
                g_log_set_writer_func (g_log_writer_journald, IntPtr.Zero, null);
            } else if (func == StandardStreams) {
                g_log_set_writer_func (g_log_writer_standard_streams, IntPtr.Zero, null);
            } else {
                var (func_, userDataFree_, userData_) = NativeLogWriterFuncFactory.CreateNotifyDelegate (func);
                g_log_set_writer_func (func_, userData_, userDataFree_);
            }
            isFuncSet = true;
        }

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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none */
        static extern LogWriterOutput g_log_writer_default (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)] LogField[] fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr nFields,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        /// <summary>
        /// Format a structured log message and output it to the default log destination
        /// for the platform. On Linux, this is typically the systemd journal, falling
        /// back to <c>stdout</c> or <c>stderr</c> if running from the terminal or if output is
        /// being redirected to a file.
        /// </summary>
        /// <remarks>
        /// Support for other platform-specific logging mechanisms may be added in
        /// future. Distributors of GLib may modify this function to impose their own
        /// (documented) platform-specific log writing policies.
        /// 
        /// This is suitable for use as a <see cref="LogWriterFunc"/>, and is the default writer used
        /// if no other is set using <see cref="SetFunc"/>.
        /// 
        /// As with g_log_default_handler(), this function drops debug and informational
        /// messages unless their log domain (or <c>all</c>) is listed in the space-separated
        /// <c>G_MESSAGES_DEBUG</c> environment variable.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        /// the log message
        /// </param>
        /// <returns>
        /// <see cref="LogWriterOutput.Handled"/> on success, <see cref="LogWriterOutput.Unhandled"/> otherwise
        /// </returns>
        [Since ("2.50")]
        public static LogWriterOutput Default (LogLevelFlags logLevel, LogField[] fields)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof(fields));
            }
            var ret = g_log_writer_default (logLevel, fields, (UIntPtr)fields.Length, IntPtr.Zero);
            return ret;
        }

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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_log_writer_format_fields (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)] LogField[] fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr nFields,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool useColor);

        /// <summary>
        /// Format a structured log message as a string suitable for outputting to the
        /// terminal (or elsewhere). This will include the values of all fields it knows
        /// how to interpret, which includes <c>MESSAGE</c> and <c>GLIB_DOMAIN</c> (see the
        /// documentation for g_log_structured()). It does not include values from
        /// unknown fields.
        /// </summary>
        /// <remarks>
        /// The returned string does **not** have a trailing new-line character.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        /// the log message
        /// </param>
        /// <param name="useColor">
        /// <c>true</c> to use ANSI color escape sequences when formatting the
        /// message, <c>false</c> to not
        /// </param>
        /// <returns>
        /// string containing the formatted log message
        /// </returns>
        [Since ("2.50")]
        public static string FormatFields (LogLevelFlags logLevel, LogField[] fields, bool useColor = false)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof(fields));
            }
            var ret_ = g_log_writer_format_fields (logLevel, fields, (UIntPtr)fields.Length, useColor);
            var ret = GMarshal.LocalePtrToString (ret_, true);
            return ret;
        }

        /// <summary>
        /// Format a structured log message as a string suitable for outputting to the
        /// terminal (or elsewhere). This will include the values of all fields it knows
        /// how to interpret, which includes <c>MESSAGE</c> and <c>GLIB_DOMAIN</c> (see the
        /// documentation for g_log_structured()). It does not include values from
        /// unknown fields.
        /// </summary>
        /// <remarks>
        /// The returned string does <b>not</b> have a trailing new-line character.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        /// the log message
        /// </param>
        /// <param name="useColor">
        /// <c>true</c> to use ANSI color escape sequences when formatting the
        /// message, <c>false</c> to not
        /// </param>
        /// <returns>
        /// string containing the formatted log message
        /// </returns>
        [Since ("2.50")]
        public static string FormatFields (LogLevelFlags logLevel, IDictionary<string, string> fields, bool useColor = false)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof (fields));
            }
            var fields_ = new LogField[fields.Count];
            var i = 0;
            foreach (var item in fields) {
                fields_[i].Key = GMarshal.StringToUtf8Ptr (item.Key);
                fields_[i].Value = GMarshal.StringToUtf8Ptr (item.Value);
                fields_[i].Length = new IntPtr (-1);
                i++;
            }
            try {
                return FormatFields (logLevel, fields_, useColor);
            } finally {
                foreach (var item in fields_) {
                    GMarshal.Free (item.Key);
                    GMarshal.Free (item.Value);
                }
            }
        }

        /// <summary>
        /// Check whether the given @output_fd file descriptor is a connection to the
        /// systemd journal, or something else (like a log file or `stdout` or
        /// `stderr`).
        /// </summary>
        /// <param name="outputFd">
        /// output file descriptor to check
        /// </param>
        /// <returns>
        /// %TRUE if @output_fd points to the journal, %FALSE otherwise
        /// </returns>
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_log_writer_is_journald (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int outputFd);

        /// <summary>
        /// Check whether the given <paramref name="outputFd"/> file descriptor is a connection to the
        /// systemd journal, or something else (like a log file or <c>stdout<c/> or
        /// <c>stderr</c>).
        /// </summary>
        /// <param name="outputFd">
        /// output file descriptor to check
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="outputFd"/> points to the journal, <c>false</c> otherwise
        /// </returns>
        [Since ("2.50")]
        public static bool IsJournald (int outputFd)
        {
            var ret = g_log_writer_is_journald (outputFd);
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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none */
        static extern LogWriterOutput g_log_writer_journald (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)] LogField[] fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr nFields,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        /// <summary>
        /// Format a structured log message and send it to the systemd journal as a set
        /// of key–value pairs. All fields are sent to the journal, but if a field has
        /// length zero (indicating program-specific data) then only its key will be
        /// sent.
        /// </summary>
        /// <remarks>
        /// This is suitable for use as a <see cref="LogWriterFunc"/>.
        /// 
        /// If GLib has been compiled without systemd support, this function is still
        /// defined, but will always return <see cref="LogWriterOutput.Unhandled"/>.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        /// the log message
        /// </param>
        /// <returns>
        /// <see cref="LogWriterOutput.Handled"/> on success, <see cref="LogWriterOutput.Unhandled"/> otherwise
        /// </returns>
        [Since ("2.50")]
        public static LogWriterOutput Journald (LogLevelFlags logLevel, LogField[] fields)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof(fields));
            }
            var ret = g_log_writer_journald (logLevel, fields, (UIntPtr)fields.Length, IntPtr.Zero);
            return ret;
        }

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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogWriterOutput" type="GLogWriterOutput" managed-name="LogWriterOutput" /> */
        /* transfer-ownership:none */
        static extern LogWriterOutput g_log_writer_standard_streams (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)]LogField[] fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr nFields,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        /// <summary>
        /// Format a structured log message and print it to either <c>stdout</c> or <c>stderr</c>,
        /// depending on its log level. <see cref="LogLevelFlags.Info"/> and <see cref="LogLevelFlags.Debug"/> messages
        /// are sent to <c>stdout</c>; all other log levels are sent to <c>stderr</c>. Only fields
        /// which are understood by this function are included in the formatted string
        /// which is printed.
        /// </summary>
        /// <remarks>
        /// If the output stream supports ANSI color escape sequences, they will be used
        /// in the output.
        /// 
        /// A trailing new-line character is added to the log message when it is printed.
        /// 
        /// This is suitable for use as a <see cref="LogWriterFunc"/>.
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data forming
        /// the log message
        /// </param>
        /// <returns>
        /// <see cref="LogWriterOutput.Handled"/> on success, <see cref="LogWriterOutput.Unhandled"/> otherwise
        /// </returns>
        [Since ("2.50")]
        public static LogWriterOutput StandardStreams (LogLevelFlags logLevel, LogField[] fields)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof(fields));
            }
            var ret = g_log_writer_standard_streams (logLevel, fields, (UIntPtr)fields.Length, IntPtr.Zero);
            return ret;
        }

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
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            static extern bool g_log_writer_supports_color (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int outputFd);

        /// <summary>
        /// Check whether the given <paramref name="outputFd"/> file descriptor supports ANSI color
        /// escape sequences. If so, they can safely be used when formatting log
        /// messages.
        /// </summary>
        /// <param name="outputFd">
        /// output file descriptor to check
        /// </param>
        /// <returns>
        /// <c>true</c> if ANSI color escapes are supported, <c>false</c> otherwise
        /// </returns>
        [Since ("2.50")]
        public static bool SupportsColor (int outputFd)
        {
            var ret = g_log_writer_supports_color (outputFd);
            return ret;
        }


        /// <summary>
        /// Log a message with structured data. The message will be passed through to the
        /// log writer set by the application using g_log_set_writer_func(). If the
        /// message is fatal (i.e. its log level is %G_LOG_LEVEL_ERROR), the program will
        /// be aborted at the end of this function.
        /// </summary>
        /// <remarks>
        /// See g_log_structured() for more documentation.
        /// 
        /// This assumes that @log_level is already present in @fields (typically as the
        /// `PRIORITY` field).
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data to add
        ///    to the log message
        /// </param>
        /// <param name="nFields">
        /// number of elements in the @fields array
        /// </param>
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_structured_array (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)] LogField[] fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr nFields);

        /// <summary>
        /// Log a message with structured data. The message will be passed through to the
        /// log writer set by the application using <see cref="SetFunc"/>. If the
        /// message is fatal (i.e. its log level is <see cref="LogLevelFlags.Error"/>), the program will
        /// be aborted at the end of this function.
        /// </summary>
        /// <remarks>
        /// See g_log_structured() for more documentation.
        /// 
        /// This assumes that <paramref name="logLevel"/> is already present in
        /// <paramref name="fields"/> (typically as the <c>PRIORITY</c> field).
        /// </remarks>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// key–value pairs of structured data to add
        /// to the log message
        /// </param>
        [Since ("2.50")]
        public static void Log (LogLevelFlags logLevel, LogField[] fields)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof(fields));
            }
            g_log_structured_array (logLevel, fields, (UIntPtr)fields.Length);
        }

        [Since ("2.50")]
        public static void Log (LogLevelFlags logLevel, IDictionary<string, string> fields)
        {
            var fields_ = new LogField[fields.Count];
            int i = 0;
            foreach (var item in fields) {
                fields_[i].Key = GMarshal.StringToUtf8Ptr (item.Key);
                fields_[i].Value = GMarshal.StringToUtf8Ptr (item.Value);
                fields_[i].Length = new IntPtr (-1);
                i++;
            }
            g_log_structured_array (logLevel, fields_, (UIntPtr)fields_.Length);
            foreach (var item in fields_) {
                GMarshal.Free (item.Key);
                GMarshal.Free (item.Value);
            }
        }

        static void Log (LogLevelFlags logLevel, string message, string codeFile, int codeLine, string codeFunc)
        {
            var fields = new Dictionary<string, string> {
                { "MESSAGE", message },
                { "CODE_FILE", codeFile },
                { "CODE_LINE", codeLine.ToString () },
                { "CODE_FUNC", codeFunc }
            };

            Log (logLevel, fields);
        }

        [Since ("2.50")]
        public static void Message (string message, 
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Message, message, file, line, member);
        }

        [Since ("2.50")]
        public static void Warning (string message,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Warning, message, file, line, member);
        }

        [Since ("2.50")]
        public static void Critical (string message,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Critical, message, file, line, member);
        }

        [Since ("2.50")]
        public static void Error (string message,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Error, message, file, line, member);
        }

        [Since ("2.50")]
        public static void Info (string message,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Info, message, file, line, member);
        }

        [Since ("2.50")]
        public static void Debug (string message,
                                    [CallerFilePath] string file = "",
                                    [CallerLineNumber] int line = 0,
                                    [CallerMemberName] string member = "")
        {
            Log (LogLevelFlags.Debug, message, file, line, member);
        }

        [Since ("2.50")]
        public static void DebugHere ([CallerFilePath] string file = "",
                                      [CallerLineNumber] int line = 0,
                                      [CallerMemberName] string member = "")
        {
            var message = string.Format ($"{Environment.TickCount}: {file}:{line}:{member}()");
            Log (LogLevelFlags.Debug, message, file, line, member);
        }

        /// <summary>
        /// Log a message with structured data, accepting the data within a #GVariant. This
        /// version is especially useful for use in other languages, via introspection.
        /// </summary>
        /// <remarks>
        /// The only mandatory item in the @fields dictionary is the "MESSAGE" which must
        /// contain the text shown to the user.
        /// 
        /// The values in the @fields dictionary are likely to be of type String
        /// (#G_VARIANT_TYPE_STRING). Array of bytes (#G_VARIANT_TYPE_BYTESTRING) is also
        /// supported. In this case the message is handled as binary and will be forwarded
        /// to the log writer as such. The size of the array should not be higher than
        /// %G_MAXSSIZE. Otherwise it will be truncated to this size. For other types
        /// g_variant_print() will be used to convert the value into a string.
        /// 
        /// For more details on its usage and about the parameters, see g_log_structured().
        /// </remarks>
        /// <param name="logDomain">
        /// log domain, usually %G_LOG_DOMAIN
        /// </param>
        /// <param name="logLevel">
        /// log level, either from #GLogLevelFlags, or a user-defined
        ///    level
        /// </param>
        /// <param name="fields">
        /// a dictionary (#GVariant of the type %G_VARIANT_TYPE_VARDICT)
        /// containing the key-value pairs of message data.
        /// </param>
        [Since ("2.50")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_variant (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr logDomain,
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            IntPtr fields);

        /// <summary>
        /// Log a message with structured data, accepting the data within a #GVariant. This
        /// version is especially useful for use in other languages, via introspection.
        /// </summary>
        /// <remarks>
        /// The only mandatory item in the @fields dictionary is the "MESSAGE" which must
        /// contain the text shown to the user.
        /// 
        /// The values in the @fields dictionary are likely to be of type String
        /// (<see cref="VariantType.String"/>). Array of bytes (<see cref="VariantType.ByteString"/>) is also
        /// supported. In this case the message is handled as binary and will be forwarded
        /// to the log writer as such. The size of the array should not be higher than
        /// %G_MAXSSIZE. Otherwise it will be truncated to this size. For other types
        /// <see cref="Variant.Print"/> will be used to convert the value into a string.
        /// 
        /// For more details on its usage and about the parameters, see g_log_structured().
        /// </remarks>
        /// <param name="logDomain">
        /// log domain, usually <see cref="Log.DefaultDomain"/>
        /// </param>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// a dictionary (<see cref="Variant"/> of the type <see cref="VariantType.VariantDictionary"/>)
        /// containing the key-value pairs of message data.
        /// </param>
        [Since ("2.50")]
        public static void Log (string logDomain, LogLevelFlags logLevel, Variant fields)
        {
            if (fields == null) {
                throw new ArgumentNullException (nameof (fields));
            }
            if (fields.Type != VariantType.VariantDictionary) {
                throw new ArgumentException ("Requires VariantType.VarDict", nameof (fields));
            }
            var logDomain_ = GMarshal.StringToUtf8Ptr (logDomain);
            var fields_ = fields.Handle;
            g_log_variant (logDomain_, logLevel, fields.Handle);
            GC.KeepAlive (fields);
            GMarshal.Free (logDomain_);
        }
    }
}
