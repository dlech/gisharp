// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    ///
    /// This is not used if structured logging is enabled; see
    /// [Using Structured Logging][using-structured-logging].
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void UnmanagedLogFunc(
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        IntPtr logDomain,
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        LogLevelFlags logLevel,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        IntPtr message,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:3 */
        IntPtr userData);

    /// <summary>
    /// Specifies the prototype of log handler functions.
    /// </summary>
    /// <remarks>
    /// The default log handler, g_log_default_handler(), automatically appends a
    /// new-line character to @message when printing it. It is advised that any
    /// custom log handler functions behave similarly, so that logging calls in user
    /// code do not need modifying to add a new-line character to the message if the
    /// log handler is changed.
    ///
    /// This is not used if structured logging is enabled; see
    /// [Using Structured Logging][using-structured-logging].
    /// </remarks>
    public delegate void LogFunc(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, NullableUnownedUtf8 message);

    /// <summary>
    /// Functions for marshaling <see cref="LogFunc"/>.
    /// </summary>
    public static class LogFuncFactory
    {
        class UserData
        {
            public readonly LogFunc Func;
            public readonly UnmanagedLogFunc UnmanagedFunc;
            public readonly UnmanagedDestroyNotify Destroy;
            public readonly CallbackScope Scope;

            public UserData(LogFunc func, UnmanagedLogFunc unmanagedFunc, UnmanagedDestroyNotify destroy, CallbackScope scope)
            {
                Func = func;
                UnmanagedFunc = unmanagedFunc;
                Destroy = destroy;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanged function pointer to a managed delegate.
        /// </summary>
        public static LogFunc Create(UnmanagedLogFunc logFunc_, IntPtr userData_)
        {
            return new LogFunc((logDomain, logLevel, message) => {
                var logDomain_ = logDomain.Handle;
                var message_ = message.Handle;
                logFunc_(logDomain_, logLevel, message_, userData_);
            });
        }

        /// <summary>
        /// Marshals a managed function delegate to an unmanged function pointer.
        /// </summary>
        public static (UnmanagedLogFunc, UnmanagedDestroyNotify, IntPtr) Create(LogFunc func, CallbackScope scope) {
            var data = new UserData(func, UnmanagedCallback, Destroy, scope);
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnmanagedFunc, data.Destroy, (IntPtr)gcHandle);
        }

        static void UnmanagedCallback(IntPtr logDomain_, LogLevelFlags logLevel_, IntPtr message_, IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var userData = (UserData)gcHandle.Target!;
                var logDomain = new NullableUnownedUtf8(logDomain_, -1);
                var message = new NullableUnownedUtf8(message_, -1);
                userData.Func(logDomain, logLevel_, message);
                if (userData.Scope == CallbackScope.Async) {
                    gcHandle.Free();
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void Destroy(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }
}
