// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class LogWriter
    {
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
        /// log writer function
        /// </param>
        [Since("2.50")]
        public static void SetFunc(LogWriterFunc func)
        {
            if (isFuncSet) {
                throw new InvalidOperationException("Log writer function can only be set once.");
            }
            // If using one of the default functions, pass the unmanged function
            // pointer instead of wrapping the managed version.
            if (func == Default) {
                var func_ = (delegate* unmanaged[Cdecl]<LogLevelFlags, LogField*, nuint, IntPtr, LogWriterOutput>)CLibrary.GetSymbol("glib-2.0", nameof(g_log_writer_default));
                g_log_set_writer_func(func_, IntPtr.Zero, null);
            }
            else if (func == Journald) {
                var func_ = (delegate* unmanaged[Cdecl]<LogLevelFlags, LogField*, nuint, IntPtr, LogWriterOutput>)CLibrary.GetSymbol("glib-2.0", nameof(g_log_writer_journald));
                g_log_set_writer_func(func_, IntPtr.Zero, null);
            }
            else if (func == StandardStreams) {
                var func_ = (delegate* unmanaged[Cdecl]<LogLevelFlags, LogField*, nuint, IntPtr, LogWriterOutput>)CLibrary.GetSymbol("glib-2.0", nameof(g_log_writer_standard_streams));
                g_log_set_writer_func(func_, IntPtr.Zero, null);
            }
            else {
                var func_ = (delegate* unmanaged[Cdecl]<LogLevelFlags, LogField*, nuint, IntPtr, LogWriterOutput>)&LogWriterFuncMarshal.Callback;
                var userData_ = (IntPtr)GCHandle.Alloc(func);
                var userDataFree_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
                g_log_set_writer_func(func_, userData_, userDataFree_);
            }
            isFuncSet = true;
        }

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
        [Since("2.50")]
        public static LogWriterOutput Default(LogLevelFlags logLevel, ReadOnlySpan<LogField> fields)
        {
            fixed (LogField* fields_ = fields) {
                var nFields_ = (nuint)fields.Length;
                var ret = g_log_writer_default(logLevel, fields_, nFields_, IntPtr.Zero);
                return ret;
            }
        }

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
        [Since("2.50")]
        public static LogWriterOutput Journald(LogLevelFlags logLevel, ReadOnlySpan<LogField> fields)
        {
            fixed (LogField* fields_ = fields) {
                var nFields_ = (nuint)fields.Length;
                var ret = g_log_writer_journald(logLevel, fields_, nFields_, IntPtr.Zero);
                return ret;
            }
        }

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
        [Since("2.50")]
        public static LogWriterOutput StandardStreams(LogLevelFlags logLevel, ReadOnlySpan<LogField> fields)
        {
            fixed (LogField* fields_ = fields) {
                var nFields_ = (nuint)fields.Length;
                var ret = g_log_writer_standard_streams(logLevel, fields_, nFields_, IntPtr.Zero);
                return ret;
            }
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
        [Since("2.50")]
        public static Utf8 FormatFields(LogLevelFlags logLevel, IDictionary<Utf8, Utf8> fields, bool useColor = false)
        {
            var fieldsArray = fields.Select(x => new LogField(x.Key, x.Value)).ToArray();
            return FormatFields(logLevel, fieldsArray, useColor);
        }
    }
}
