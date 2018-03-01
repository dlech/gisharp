using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// These functions provide support for outputting messages.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// The default log domain.
        /// </summary>
        /// <remarks>
        /// This value should only be used by applications. Libraries should
        /// define a unique domain.
        /// </remarks>
        public const string DefaultDomain = "";

        /// <summary>
        /// GLib log levels that are considered fatal by default.
        /// </summary>
        /// <remarks>
        /// This is not used if structured logging is enabled; see Using Structured Logging.
        /// </remarks>
        public const LogLevelFlags DefaultFatalMask = LogLevelFlags.Recursion | LogLevelFlags.Error;

        /// <summary>
        /// Log levels below 1&lt;&lt;LevelUserShift are used by GLib.
        /// Higher bits can be used for user-defined log levels.
        /// </summary>
        public const int LogLevelUserShift = 8;

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_log (IntPtr logDomain, LogLevelFlags logLevel, IntPtr format);

        static void Log_ (string logDomain, LogLevelFlags logLevel, string format, params object[] args)
        {
            using (var logDomainUtf8 = new Utf8(logDomain))
            using (var formatUtf8 = new Utf8(string.Format (format, args))) {
                g_log(logDomainUtf8.Handle, logLevel, formatUtf8.Handle);
            }
        }

        public static void Message (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Message, format, args);
        }

        public static void Warning (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Warning, format, args);
        }

        public static void Critical (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Critical, format, args);
        }

        public static void Error (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Error, format, args);
        }

        public static void Info (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Info, format, args);
        }

        public static void Debug (string format, params object[] args)
        {
            Log_ (DefaultDomain, LogLevelFlags.Debug, format, args);
        }

        /// <summary>
        /// Log an unhandled exception.
        /// </summary>
        /// <remarks>
        /// This is to be used in callbacks from unmanaged code. Unmanaged C
        /// code does not know about managed exceptions. So all exceptions in
        /// callbacks need to be caught and this function should be called.
        /// </remarks>
        public static void LogUnhandledException (this Exception ex, [CallerMemberName]string caller = "")
        {
            try {
                var domain = ex?.TargetSite?.Module?.Name;
                Log_(domain, LogLevelFlags.Critical, "Unhandled exception in {0}\n{1}", caller, ex);
            } catch {
                // This must absolutely not throw an exception
            }
        }

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   application.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest.
        /// 
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message, or %NULL for the
        /// default "" application domain
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        /// <param name="unusedData">
        /// data passed from g_log() which is unused
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_default_handler (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr logDomain,
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr message,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr unusedData);

        /// <summary>
        /// The default log handler set up by GLib; <see cref="SetHandler"/>
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls abort(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// 
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   application.
        /// 
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// 
        /// stderr is used for levels <see cref="LogLevelFlags.Error"/>, <see cref="LogLevelFlags.Critical"/>,
        /// <see cref="LogLevelFlags.Warning"/> and <see cref="LogLevelFlags.Message"/>. stdout is used for
        /// the rest.
        /// 
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain of the message, or <c>null</c> for the
        /// default "" application domain
        /// </param>
        /// <param name="logLevel">
        /// the level of the message
        /// </param>
        /// <param name="message">
        /// the message
        /// </param>
        public static void DefaultHandler(Utf8 logDomain, LogLevelFlags logLevel, Utf8 message)
        {
            var logDomain_ = logDomain?.Handle ?? IntPtr.Zero;
            var message_ = message?.Handle ?? IntPtr.Zero;
            g_log_default_handler(logDomain_, logLevel, message_, IntPtr.Zero);
        }

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <remarks>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_remove_handler (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr logDomain,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint handlerId);

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <remarks>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        /// in <see cref="SetHandler"/>
        /// </param>
        public static void RemoveHandler(Utf8 logDomain, uint handlerId)
        {
            var logDomain_ = logDomain?.Handle ?? throw new ArgumentNullException(nameof(logDomain));
            g_log_remove_handler(logDomain_, handlerId);
        }

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// 
        /// Libraries should not call this function, as it affects all messages logged
        /// by a process, including those from other libraries.
        /// 
        /// Structured log messages (using g_log_structured() and
        /// g_log_structured_array()) are fatal only if the default log writer is used;
        /// otherwise it is up to the writer function to determine which log messages
        /// are fatal. See [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        static extern LogLevelFlags g_log_set_always_fatal (
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags fatalMask);

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// <see cref="LogLevelFlags.Error"/> is always fatal.
        /// </summary>
        /// <remarks>
        /// You can also make some message levels fatal at runtime by setting
        /// the <c>G_DEBUG</c> environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// 
        /// Libraries should not call this function, as it affects all messages logged
        /// by a process, including those from other libraries.
        /// 
        /// Structured log messages (using g_log_structured() and
        /// g_log_structured_array()) are fatal only if the default log writer is used;
        /// otherwise it is up to the writer function to determine which log messages
        /// are fatal. See [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        /// of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        public static LogLevelFlags SetAlwaysFatal (LogLevelFlags fatalMask)
        {
            var ret = g_log_set_always_fatal (fatalMask);
            return ret;
        }

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <remarks>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <returns>
        /// the previous default log handler
        /// </returns>
        [Since ("2.6")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogFunc" type="GLogFunc" managed-name="LogFunc" /> */
        /* */
        static extern IntPtr g_log_set_default_handler (
            /* <type name="LogFunc" type="GLogFunc" managed-name="LogFunc" /> */
            /* transfer-ownership:none closure:1 */
            UnmanagedLogFunc logFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        static GCHandle defaultHandler;

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// <see cref="DefaultHandler"/> as default log handler.
        /// </summary>
        /// <remarks>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        [Since ("2.6")]
        public static void SetDefaultHandler (LogFunc logFunc)
        {
            if (logFunc == null) {
                throw new ArgumentNullException (nameof (logFunc));
            }
            var oldHandler = defaultHandler;
            if (logFunc == DefaultHandler) {
                g_log_set_default_handler (g_log_default_handler, IntPtr.Zero);
                defaultHandler = default(GCHandle);
            } else {
                // this function does not fix the GIR callback scope pattern
                // so we have to do some special memory management ourselves
                var (logFunc_, _, userData_) = LogFuncFactory.Create(logFunc, CallbackScope.Unknown);
                g_log_set_default_handler (logFunc_, userData_);
                defaultHandler = (GCHandle)userData_;
            }
            if (oldHandler.IsAllocated) {
                oldHandler.Free ();
            }
        }

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// This has no effect on structured log messages (using g_log_structured() or
        /// g_log_structured_array()). To change the fatal behaviour for specific log
        /// messages, programs must install a custom log writer function using
        /// g_log_set_writer_func(). See
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        static extern LogLevelFlags g_log_set_fatal_mask (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr logDomain,
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags fatalMask);

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// <see cref="LogLevelFlags.Error"/> is always fatal.
        /// </summary>
        /// <remarks>
        /// This has no effect on structured log messages (using g_log_structured() or
        /// g_log_structured_array()). To change the fatal behaviour for specific log
        /// messages, programs must install a custom log writer function using
        /// g_log_set_writer_func(). See
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="fatalMask">
        /// the new fatal mask
        /// </param>
        /// <returns>
        /// the old fatal mask for the log domain
        /// </returns>
        public static LogLevelFlags SetFatalMask(Utf8 logDomain, LogLevelFlags fatalMask)
        {
            var logDomain_ = logDomain?.Handle ?? throw new ArgumentNullException(nameof(logDomain));
            var ret = g_log_set_fatal_mask(logDomain_, fatalMask);
            return ret;
        }

        /// <summary>
        /// Like g_log_sets_handler(), but takes a destroy notify for the @user_data.
        /// </summary>
        /// <remarks>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///     application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///     To handle fatal and recursive messages as well, combine
        ///     the log levels with the #G_LOG_FLAG_FATAL and
        ///     #G_LOG_FLAG_RECURSION bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <param name="userData">
        /// data passed to the log handler
        /// </param>
        /// <param name="destroy">
        /// destroy notify for @user_data, or %NULL
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        [Since ("2.46")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_log_set_handler_full (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr logDomain,
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevels,
            /* <type name="LogFunc" type="GLogFunc" managed-name="LogFunc" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            UnmanagedLogFunc logFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify destroy);

        /// <summary>
        /// Sets the log handler for a domain and a set of log levels. To handle
        /// fatal and recursive messages the <paramref name="logLevels"/> parameter
        /// must be combined with the <see cref="LogLevelFlags.Fatal"/> and
        /// <see cref="LogLevelFlags.Recursion"/> bit flags.
        /// </summary>
        /// <remarks>
        /// Note that since the <see cref="LogLevelFlags.Error"/> log level is always fatal, if
        /// you want to set a handler for this log level you must combine it with
        /// <see cref="LogLevelFlags.Fatal"/>.
        /// 
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// 
        /// Here is an example for adding a log handler for all warning messages
        /// in the default domain:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler (NULL, G_LOG_LEVEL_WARNING | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all critical messages from GTK+:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("Gtk", G_LOG_LEVEL_CRITICAL | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// ]|
        /// 
        /// This example adds a log handler for all messages from GLib:
        /// |[&lt;!-- language="C" --&gt;
        /// g_log_set_handler ("GLib", G_LOG_LEVEL_MASK | G_LOG_FLAG_FATAL
        ///                    | G_LOG_FLAG_RECURSION, my_log_handler, NULL);
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or <c>null</c> for the default ""
        /// application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        /// To handle fatal and recursive messages as well, combine
        /// the log levels with the <see cref="LogLevelFlags.Fatal"/> and
        /// <see cref="LogLevelFlags.Recursion"/> bit flags.
        /// </param>
        /// <param name="logFunc">
        /// the log handler function
        /// </param>
        /// <returns>
        /// the id of the new handler
        /// </returns>
        [Since ("2.46")]
        public static uint SetHandler(Utf8 logDomain, LogLevelFlags logLevels, LogFunc logFunc)
        {
            var logDomain_ = logDomain?.Handle ?? throw new ArgumentNullException(nameof(logFunc));
            var (logFunc_, destroy_, userData_) = LogFuncFactory.Create(logFunc, CallbackScope.Notified);
            var ret = g_log_set_handler_full(logDomain_, logLevels, logFunc_, userData_, destroy_);
            return ret;
        }
    }
}
