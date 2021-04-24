// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using Microsoft.Extensions.Logging;

namespace GISharp.Lib.GLib
{
    unsafe partial class Log
    {
        /// <summary>
        /// The default log domain.
        /// </summary>
        /// <remarks>
        /// This value should only be used by applications. Libraries should
        /// define a unique domain.
        /// </remarks>
        public const string DefaultDomain = "";

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_log(IntPtr logDomain, LogLevelFlags logLevel, IntPtr format, IntPtr arg);

        static readonly Utf8 stringFormat = "%s";
        static readonly IntPtr stringFormat_ = stringFormat.UnsafeHandle;

        static void Log_(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, NullableUnownedUtf8 message)
        {
            g_log(logDomain.UnsafeHandle, logLevel, stringFormat_, message.UnsafeHandle);
            GMarshal.PopUnhandledException();
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
        /// You can also use <see cref="SetAlwaysFatal"/>.
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
            var logDomain_ = (byte*)logDomain.UnsafeHandle;
            var message_ = (byte*)message.UnsafeHandle;
            g_log_default_handler(logDomain_, logLevel, message_, IntPtr.Zero);
            GMarshal.PopUnhandledException();
        }

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
                var logFunc_ = (delegate* unmanaged[Cdecl]<byte*, LogLevelFlags, byte*, IntPtr, void>)CLibrary.GetSymbol("glib-2.0", "g_log_default_handler");
                g_log_set_default_handler(logFunc_, IntPtr.Zero);
                GMarshal.PopUnhandledException();
                defaultHandler = default;
            }
            else {
                // this function does not fix the GIR callback scope pattern
                // so we have to do some special memory management ourselves
                var logFunc_ = (delegate* unmanaged[Cdecl]<byte*, LogLevelFlags, byte*, IntPtr, void>)&LogFuncMarshal.Callback;
                defaultHandler = GCHandle.Alloc((logFunc, CallbackScope.Unknown));
                var userData_ = (IntPtr)defaultHandler;
                g_log_set_default_handler(logFunc_, userData_);
                GMarshal.PopUnhandledException();
            }
            if (oldHandler.IsAllocated) {
                oldHandler.Free();
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
        public static void Structured(LogLevelFlags logLevel, IDictionary<Utf8, Utf8> fields)
        {
            LogField* fields_ = stackalloc LogField[fields.Count];
            var nFields_ = (nuint)fields.Count;
            nuint i = 0;
            foreach (var item in fields) {
                fields_[i] = new LogField(item.Key, item.Value);
                i++;
            }
            g_log_structured_array(logLevel, fields_, nFields_);
            GMarshal.PopUnhandledException();
        }

        static void Structured(LogLevelFlags logLevel, string message, string codeFile, int codeLine, string codeFunc)
        {
            var fields = new Dictionary<Utf8, Utf8> {
                { "MESSAGE", message },
                { "CODE_FILE", codeFile },
                { "CODE_LINE", codeLine.ToString () },
                { "CODE_FUNC", codeFunc }
            };

            Structured(logLevel, fields);
        }

        static partial void CheckVariantArgs(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, Variant fields)
        {
            if (fields.Type != VariantType.VariantDictionary) {
                throw new ArgumentException("Requires VariantType.VarDict", nameof(fields));
            }
        }
    }
}
