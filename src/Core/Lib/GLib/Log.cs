// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using Microsoft.Extensions.Logging;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// These functions provide support for outputting messages.
    /// </summary>
    public static unsafe class Log
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

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_log(IntPtr logDomain, LogLevelFlags logLevel, IntPtr format, IntPtr arg);

        static readonly Utf8 stringFormat = "%s";
        static readonly IntPtr stringFormat_ = stringFormat.UnsafeHandle;

        static void Log_(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, NullableUnownedUtf8 message)
        {
            g_log(logDomain.UnsafeHandle, logLevel, stringFormat_, message.UnsafeHandle);
        }

        /// <summary>
        /// A convenience function to log a normal message.
        /// </summary>
        public static void Message(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Message, message);
        }

        /// <summary>
        /// A convenience function to log a warning message. The message
        /// should typically <i>not</i> be translated to the user's language.
        /// </summary>
        /// <remarks>
        /// This is not intended for end user error reporting. Use of
        /// <see cref="Error"/> is preferred for that instead, as it allows
        /// calling functions to perform actions conditional on the type of error.
        ///
        /// Warning messages are intended to be used in the event of unexpected
        /// external conditions (system misconfiguration, missing files, other
        /// trusted programs violating protocol, invalid contents in trusted
        /// files, etc.)
        ///
        /// If attempting to deal with programmer errors (for example, incorrect
        /// function parameters) then you should use <see cref="Critical"/> instead.
        ///
        /// You can make warnings fatal at runtime by setting the <c>G_DEBUG</c>
        /// environment variable.
        /// </remarks>
        public static void Warning(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Warning, message);
        }

        /// <summary>
        /// Logs a "critical warning" (<see cref="LogLevelFlags.Critical"/>).
        /// The message should typically <i>not</i> be translated to the user's
        /// language.
        /// </summary>
        /// <remarks>
        /// Critical warnings are intended to be used in the event of an error
        /// that originated in the current process (a programmer error). Logging
        /// of a critical error is by definition an indication of a bug somewhere
        /// in the current program (or its libraries).
        ///
        /// You can make critical warnings fatal at runtime by setting the
        /// <c>G_DEBUG</c> environment variable (see Running GLib Applications).
        /// You can also use <see cref="Log.SetAlwaysFatal"/>.
        /// </remarks>
        public static void Critical(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Critical, message);
        }

        // GLib will abort the program after logging the error
#pragma warning disable CS8763
        /// <summary>
        /// A convenience function to log an error message. The message
        /// should typically <i>not</i> be translated to the user's language.
        /// </summary>
        /// <remarks>
        /// This is not intended for end user error reporting. Use of
        /// <see cref="Error"/> is preferred for that instead, as it allows
        /// calling functions to perform actions conditional on the type of error.
        ///
        /// Error messages are always fatal, resulting in a call to
        /// G_BREAKPOINT() to terminate the application. This function will
        /// result in a core dump; don't use it for errors you expect. Using
        /// this function indicates a bug in your program, i.e. an assertion
        /// failure.
        /// </remarks>
        [DoesNotReturn]
        public static void Error(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Error, message);
        }
#pragma warning restore CS8763

        /// <summary>
        /// A convenience function to log an informational message. Seldom used.
        /// </summary>
        public static void Info(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Info, message);
        }

        /// <summary>
        /// A convenience function to log a debug message. The message
        /// should typically <i>not</i> be translated to the user's language.
        /// </summary>
        public static void Debug(NullableUnownedUtf8 message)
        {
            Log_(DefaultDomain, LogLevelFlags.Debug, message);
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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_default_handler(
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
        public static void DefaultHandler(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, NullableUnownedUtf8 message)
        {
            var logDomain_ = logDomain.UnsafeHandle;
            var message_ = message.UnsafeHandle;
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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_remove_handler(
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
        public static void RemoveHandler(UnownedUtf8 logDomain, uint handlerId)
        {
            var logDomain_ = logDomain.UnsafeHandle;
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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        static extern LogLevelFlags g_log_set_always_fatal(
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
        public static LogLevelFlags SetAlwaysFatal(LogLevelFlags fatalMask)
        {
            var ret = g_log_set_always_fatal(fatalMask);
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
        [Since("2.6")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogFunc" type="GLogFunc" managed-name="LogFunc" /> */
        /* */
        static extern IntPtr g_log_set_default_handler(
            /* <type name="LogFunc" type="GLogFunc" managed-name="LogFunc" /> */
            /* transfer-ownership:none closure:1 */
            UnmanagedLogFunc logFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        static GCHandle defaultHandler;

        /// <summary>
        /// Class implementing the standard <see cref="ILoggerProvider"/> interface
        /// that uses GLib logging as the backend.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that log levels do not map directly between <see cref="LogLevel"/>
        /// and <see cref="LogLevelFlags"/>. Most importantly, <c>Critical</c>
        /// and <c>Error</c> have opposite meanings.
        /// </para>
        ///
        /// <para>
        /// The full mapping is:
        /// <list type="bullet">
        /// <item><description>
        /// <see cref="LogLevel.Trace"/> => <see cref="LogLevelFlags.Debug"/>
        /// </description></item>
        /// <item><description>
        /// <see cref="LogLevel.Debug"/> => <see cref="LogLevelFlags.Info"/>
        /// </description></item>
        /// <item><description>
        /// <see cref="LogLevel.Information"/> => <see cref="LogLevelFlags.Message"/>
        /// </description></item>
        /// <item><description>
        /// <see cref="LogLevel.Warning"/> => <see cref="LogLevelFlags.Warning"/>
        /// </description></item>
        /// <item><description>
        /// <see cref="LogLevel.Error"/> => <see cref="LogLevelFlags.Critical"/>
        /// </description></item>
        /// <item><description>
        /// <see cref="LogLevel.Critical"/> => <see cref="LogLevelFlags.Error"/>
        /// </description></item>
        /// </list>
        /// </para>
        /// </remarks>
        public sealed class LoggerProvider : ILoggerProvider
        {
            /// <inheritdoc/>

            public ILogger CreateLogger(string categoryName)
            {
                return new Logger(categoryName);
            }

            void IDisposable.Dispose()
            {
            }
        }

        class Logger : ILogger
        {
            readonly Utf8? domain;

            public Logger(string? domain = null)
            {
                if (domain is not null) {
                    this.domain = domain;
                }
            }

            class Scope : IDisposable
            {
                public void Dispose()
                {
                }
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return new Scope();
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                using var message = (Utf8)formatter(state, exception);
                Log_(domain, MapLogLevel(logLevel), message);
            }

            static LogLevelFlags MapLogLevel(LogLevel logLevel)
            {
                return logLevel switch {
                    LogLevel.Trace => LogLevelFlags.Debug,
                    LogLevel.Debug => LogLevelFlags.Info,
                    LogLevel.Information => LogLevelFlags.Message,
                    LogLevel.Warning => LogLevelFlags.Warning,
                    LogLevel.Error => LogLevelFlags.Critical,
                    LogLevel.Critical => LogLevelFlags.Error,
                    LogLevel.None => default,
                    _ => throw new ArgumentException("Unknown log level", nameof(logLevel))
                };
            }
        }

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
        [Since("2.6")]
        public static void SetDefaultHandler(LogFunc logFunc)
        {
            var oldHandler = defaultHandler;
            if (logFunc == DefaultHandler) {
                g_log_set_default_handler(g_log_default_handler, IntPtr.Zero);
                defaultHandler = default;
            }
            else {
                // this function does not fix the GIR callback scope pattern
                // so we have to do some special memory management ourselves
                var (logFunc_, _, userData_) = LogFuncFactory.Create(logFunc, CallbackScope.Unknown);
                g_log_set_default_handler(logFunc_, userData_);
                defaultHandler = (GCHandle)userData_;
            }
            if (oldHandler.IsAllocated) {
                oldHandler.Free();
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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        static extern LogLevelFlags g_log_set_fatal_mask(
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
        public static LogLevelFlags SetFatalMask(UnownedUtf8 logDomain, LogLevelFlags fatalMask)
        {
            var logDomain_ = logDomain.UnsafeHandle;
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
        [Since("2.46")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_log_set_handler_full(
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
        [Since("2.46")]
        public static uint SetHandler(NullableUnownedUtf8 logDomain, LogLevelFlags logLevels, LogFunc logFunc)
        {
            var logDomain_ = logDomain.UnsafeHandle;
            var (logFunc_, destroy_, userData_) = LogFuncFactory.Create(logFunc, CallbackScope.Notified);
            var ret = g_log_set_handler_full(logDomain_, logLevels, logFunc_, userData_, destroy_);
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
        [Since("2.50")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_structured_array(
            /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
            /* transfer-ownership:none */
            LogLevelFlags logLevel,
            /* <array length="2" zero-terminated="0" type="GLogField*">
                <type name="LogField" type="GLogField" managed-name="LogField" />
                </array> */
            /* transfer-ownership:none */
            LogField* fields,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint nFields);

        /// <summary>
        /// Log a message with structured data. The message will be passed through to the
        /// log writer set by the application using <see cref="M:LogWriter.SetFunc"/>. If the
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
        [Since("2.50")]
        public static void Structured(LogLevelFlags logLevel, ReadOnlySpan<LogField> fields)
        {
            fixed (LogField* fields_ = fields) {
                var nFields_ = (nuint)fields.Length;
                g_log_structured_array(logLevel, fields_, nFields_);
            }
        }

        /// <summary>
        /// Log a message with structured data. The message will be passed through to the
        /// log writer set by the application using <see cref="M:LogWriter.SetFunc"/>. If the
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
        [Since("2.50")]
        public static void Structured(LogLevelFlags logLevel, IDictionary<string, string> fields)
        {
            LogField* fields_ = stackalloc LogField[fields.Count];
            var nFields_ = (nuint)fields.Count;
            nuint i = 0;
            foreach (var item in fields) {
                fields_[i].Key = GMarshal.StringToUtf8Ptr(item.Key);
                fields_[i].Value = GMarshal.StringToUtf8Ptr(item.Value);
                fields_[i].Length = new IntPtr(-1);
                i++;
            }
            g_log_structured_array(logLevel, fields_, nFields_);
            for (i = 0; i < nFields_; i++) {
                GMarshal.Free(fields_[i].Key);
                GMarshal.Free(fields_[i].Value);
            }
        }

        static void Structured(LogLevelFlags logLevel, string message, string codeFile, int codeLine, string codeFunc)
        {
            var fields = new Dictionary<string, string> {
                { "MESSAGE", message },
                { "CODE_FILE", codeFile },
                { "CODE_LINE", codeLine.ToString () },
                { "CODE_FUNC", codeFunc }
            };

            Structured(logLevel, fields);
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
        [Since("2.50")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_log_variant(
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
        /// log domain, usually <see cref="DefaultDomain"/>
        /// </param>
        /// <param name="logLevel">
        /// log level, either from <see cref="LogLevelFlags"/>, or a user-defined
        /// level
        /// </param>
        /// <param name="fields">
        /// a dictionary (<see cref="GLib.Variant"/> of the type <see cref="VariantType.VariantDictionary"/>)
        /// containing the key-value pairs of message data.
        /// </param>
        [Since("2.50")]
        public static void Variant(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, Variant fields)
        {
            var logDomain_ = logDomain.UnsafeHandle;
            var fields_ = fields.UnsafeHandle;
            if (fields.Type != VariantType.VariantDictionary) {
                throw new ArgumentException("Requires VariantType.VarDict", nameof(fields));
            }
            g_log_variant(logDomain_, logLevel, fields_);
        }
    }
}
