// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Log.xmldoc" path="declaration/member[@name='Log']/*" />
    public static unsafe partial class Log
    {
        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.domain']/*" />
        private const sbyte domain = 0;

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.fatalMask']/*" />
        private const int fatalMask = 5;

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.levelUserShift']/*" />
        private const int levelUserShift = 8;

        /// <summary>
        /// The default log handler set up by GLib; g_log_set_default_handler()
        /// allows to install an alternate default log handler.
        /// This is used if no log handler has been set for the particular log
        /// domain and log level combination. It outputs the message to stderr
        /// or stdout and if the log level is fatal it calls G_BREAKPOINT(). It automatically
        /// prints a new-line character after the message, so one does not need to be
        /// manually included in @message.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The behavior of this log handler can be influenced by a number of
        /// environment variables:
        /// </para>
        /// <para>
        /// - `G_MESSAGES_PREFIXED`: A :-separated list of log levels for which
        ///   messages should be prefixed by the program name and PID of the
        ///   application.
        /// </para>
        /// <para>
        /// - `G_MESSAGES_DEBUG`: A space-separated list of log domains for
        ///   which debug and informational messages are printed. By default
        ///   these messages are not printed.
        /// </para>
        /// <para>
        /// stderr is used for levels %G_LOG_LEVEL_ERROR, %G_LOG_LEVEL_CRITICAL,
        /// %G_LOG_LEVEL_WARNING and %G_LOG_LEVEL_MESSAGE. stdout is used for
        /// the rest, unless stderr was requested by
        /// g_log_writer_default_set_use_stderr().
        /// </para>
        /// <para>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </para>
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_log_default_handler(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* logDomain,
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* message,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr unusedData);

        /// <summary>
        /// Removes the log handler.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </para>
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain
        /// </param>
        /// <param name="handlerId">
        /// the id of the handler, which was returned
        ///     in g_log_set_handler()
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_log_remove_handler(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* logDomain,
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        uint handlerId);
        static partial void CheckRemoveHandlerArgs(GISharp.Runtime.UnownedUtf8 logDomain, uint handlerId);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.RemoveHandler(GISharp.Runtime.UnownedUtf8,uint)']/*" />
        public static void RemoveHandler(GISharp.Runtime.UnownedUtf8 logDomain, uint handlerId)
        {
            CheckRemoveHandlerArgs(logDomain, handlerId);
            var logDomain_ = (byte*)logDomain.UnsafeHandle;
            var handlerId_ = (uint)handlerId;
            g_log_remove_handler(logDomain_, handlerId_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the message levels which are always fatal, in any log domain.
        /// When a message with any of these levels is logged the program terminates.
        /// You can only set the levels defined by GLib to be fatal.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also make some message levels fatal at runtime by setting
        /// the `G_DEBUG` environment variable (see
        /// [Running GLib Applications](glib-running.html)).
        /// </para>
        /// <para>
        /// Libraries should not call this function, as it affects all messages logged
        /// by a process, including those from other libraries.
        /// </para>
        /// <para>
        /// Structured log messages (using g_log_structured() and
        /// g_log_structured_array()) are fatal only if the default log writer is used;
        /// otherwise it is up to the writer function to determine which log messages
        /// are fatal. See [Using Structured Logging][using-structured-logging].
        /// </para>
        /// </remarks>
        /// <param name="fatalMask">
        /// the mask containing bits set for each level
        ///     of error which is to be fatal
        /// </param>
        /// <returns>
        /// the old fatal mask
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.LogLevelFlags g_log_set_always_fatal(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags fatalMask);
        static partial void CheckSetAlwaysFatalArgs(GISharp.Lib.GLib.LogLevelFlags fatalMask);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.SetAlwaysFatal(GISharp.Lib.GLib.LogLevelFlags)']/*" />
        public static GISharp.Lib.GLib.LogLevelFlags SetAlwaysFatal(GISharp.Lib.GLib.LogLevelFlags fatalMask)
        {
            CheckSetAlwaysFatalArgs(fatalMask);
            var fatalMask_ = (GISharp.Lib.GLib.LogLevelFlags)fatalMask;
            var ret_ = g_log_set_always_fatal(fatalMask_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.LogLevelFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Installs a default log handler which is used if no
        /// log handler has been set for the particular log domain
        /// and log level combination. By default, GLib uses
        /// g_log_default_handler() as default log handler.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </para>
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
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogFunc" type="GLogFunc" /> */
        /* transfer-ownership:full direction:in */
        private static extern delegate* unmanaged[Cdecl]<byte*, GISharp.Lib.GLib.LogLevelFlags, byte*, System.IntPtr, void> g_log_set_default_handler(
        /* <type name="LogFunc" type="GLogFunc" /> */
        /* transfer-ownership:none closure:1 direction:in */
        delegate* unmanaged[Cdecl]<byte*, GISharp.Lib.GLib.LogLevelFlags, byte*, System.IntPtr, void> logFunc,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Sets the log levels which are fatal in the given domain.
        /// %G_LOG_LEVEL_ERROR is always fatal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This has no effect on structured log messages (using g_log_structured() or
        /// g_log_structured_array()). To change the fatal behaviour for specific log
        /// messages, programs must install a custom log writer function using
        /// g_log_set_writer_func(). See
        /// [Using Structured Logging][using-structured-logging].
        /// </para>
        /// <para>
        /// This function is mostly intended to be used with
        /// %G_LOG_LEVEL_CRITICAL.  You should typically not set
        /// %G_LOG_LEVEL_WARNING, %G_LOG_LEVEL_MESSAGE, %G_LOG_LEVEL_INFO or
        /// %G_LOG_LEVEL_DEBUG as fatal except inside of test programs.
        /// </para>
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.LogLevelFlags g_log_set_fatal_mask(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* logDomain,
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags fatalMask);
        static partial void CheckSetFatalMaskArgs(GISharp.Runtime.UnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags fatalMask);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.SetFatalMask(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GLib.LogLevelFlags)']/*" />
        public static GISharp.Lib.GLib.LogLevelFlags SetFatalMask(GISharp.Runtime.UnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags fatalMask)
        {
            CheckSetFatalMaskArgs(logDomain, fatalMask);
            var logDomain_ = (byte*)logDomain.UnsafeHandle;
            var fatalMask_ = (GISharp.Lib.GLib.LogLevelFlags)fatalMask;
            var ret_ = g_log_set_fatal_mask(logDomain_,fatalMask_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.LogLevelFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Like g_log_set_handler(), but takes a destroy notify for the @user_data.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This has no effect if structured logging is enabled; see
        /// [Using Structured Logging][using-structured-logging].
        /// </para>
        /// </remarks>
        /// <param name="logDomain">
        /// the log domain, or %NULL for the default ""
        ///   application domain
        /// </param>
        /// <param name="logLevels">
        /// the log levels to apply the log handler for.
        ///   To handle fatal and recursive messages as well, combine
        ///   the log levels with the %G_LOG_FLAG_FATAL and
        ///   %G_LOG_FLAG_RECURSION bit flags.
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
        [GISharp.Runtime.SinceAttribute("2.46")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint g_log_set_handler_full(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* logDomain,
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevels,
        /* <type name="LogFunc" type="GLogFunc" /> */
        /* transfer-ownership:none scope:notified closure:3 destroy:4 direction:in */
        delegate* unmanaged[Cdecl]<byte*, GISharp.Lib.GLib.LogLevelFlags, byte*, System.IntPtr, void> logFunc,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData,
        /* <type name="DestroyNotify" type="GDestroyNotify" /> */
        /* transfer-ownership:none scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> destroy);
        static partial void CheckSetHandlerArgs(GISharp.Runtime.NullableUnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags logLevels, GISharp.Lib.GLib.LogFunc logFunc);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.SetHandler(GISharp.Runtime.NullableUnownedUtf8,GISharp.Lib.GLib.LogLevelFlags,GISharp.Lib.GLib.LogFunc)']/*" />
        [GISharp.Runtime.SinceAttribute("2.46")]
        public static uint SetHandler(GISharp.Runtime.NullableUnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags logLevels, GISharp.Lib.GLib.LogFunc logFunc)
        {
            CheckSetHandlerArgs(logDomain, logLevels, logFunc);
            var logDomain_ = (byte*)logDomain.UnsafeHandle;
            var logLevels_ = (GISharp.Lib.GLib.LogLevelFlags)logLevels;
            var logFunc_ = (delegate* unmanaged[Cdecl]<byte*, GISharp.Lib.GLib.LogLevelFlags, byte*, System.IntPtr, void>)&GISharp.Lib.GLib.LogFuncMarshal.Callback;
            var logFuncHandle = System.Runtime.InteropServices.GCHandle.Alloc((logFunc, GISharp.Runtime.CallbackScope.Notified));
            var userData_ = (System.IntPtr)logFuncHandle;
            var destroy_ = (delegate* unmanaged[Cdecl]<System.IntPtr, void>)&GISharp.Runtime.GMarshal.DestroyGCHandle;
            var ret_ = g_log_set_handler_full(logDomain_,logLevels_,logFunc_,userData_,destroy_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Log a message with structured data. The message will be passed through to the
        /// log writer set by the application using g_log_set_writer_func(). If the
        /// message is fatal (i.e. its log level is %G_LOG_LEVEL_ERROR), the program will
        /// be aborted at the end of this function.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See g_log_structured() for more documentation.
        /// </para>
        /// <para>
        /// This assumes that @log_level is already present in @fields (typically as the
        /// `PRIORITY` field).
        /// </para>
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
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_log_structured_array(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="const GLogField*" is-pointer="1">
*   <type name="LogField" type="GLogField" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogField* fields,
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        nuint nFields);
        static partial void CheckStructuredArgs(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.Structured(GISharp.Lib.GLib.LogLevelFlags,System.ReadOnlySpan&lt;GISharp.Lib.GLib.LogField&gt;)']/*" />
        [GISharp.Runtime.SinceAttribute("2.50")]
        public static void Structured(GISharp.Lib.GLib.LogLevelFlags logLevel, System.ReadOnlySpan<GISharp.Lib.GLib.LogField> fields)
        {
            fixed (GISharp.Lib.GLib.LogField* fieldsData_ = fields)
            {
                CheckStructuredArgs(logLevel, fields);
                var logLevel_ = (GISharp.Lib.GLib.LogLevelFlags)logLevel;
                var fields_ = (GISharp.Lib.GLib.LogField*)fieldsData_;
                var nFields_ = (nuint)fields.Length;
                g_log_structured_array(logLevel_, fields_, nFields_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Log a message with structured data, accepting the data within a #GVariant. This
        /// version is especially useful for use in other languages, via introspection.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The only mandatory item in the @fields dictionary is the "MESSAGE" which must
        /// contain the text shown to the user.
        /// </para>
        /// <para>
        /// The values in the @fields dictionary are likely to be of type String
        /// (%G_VARIANT_TYPE_STRING). Array of bytes (%G_VARIANT_TYPE_BYTESTRING) is also
        /// supported. In this case the message is handled as binary and will be forwarded
        /// to the log writer as such. The size of the array should not be higher than
        /// %G_MAXSSIZE. Otherwise it will be truncated to this size. For other types
        /// g_variant_print() will be used to convert the value into a string.
        /// </para>
        /// <para>
        /// For more details on its usage and about the parameters, see g_log_structured().
        /// </para>
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
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_log_variant(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* logDomain,
        /* <type name="LogLevelFlags" type="GLogLevelFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.LogLevelFlags logLevel,
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* fields);
        static partial void CheckVariantArgs(GISharp.Runtime.NullableUnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags logLevel, GISharp.Lib.GLib.Variant fields);

        /// <include file="Log.xmldoc" path="declaration/member[@name='Log.Variant(GISharp.Runtime.NullableUnownedUtf8,GISharp.Lib.GLib.LogLevelFlags,GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.50")]
        public static void Variant(GISharp.Runtime.NullableUnownedUtf8 logDomain, GISharp.Lib.GLib.LogLevelFlags logLevel, GISharp.Lib.GLib.Variant fields)
        {
            CheckVariantArgs(logDomain, logLevel, fields);
            var logDomain_ = (byte*)logDomain.UnsafeHandle;
            var logLevel_ = (GISharp.Lib.GLib.LogLevelFlags)logLevel;
            var fields_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)fields.UnsafeHandle;
            g_log_variant(logDomain_, logLevel_, fields_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}