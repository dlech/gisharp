
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
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
    public delegate void LogFunc(Utf8 logDomain, LogLevelFlags logLevel, Utf8 message);

    public static class LogFuncFactory
    {
        class UserData
        {
            public LogFunc Func;
            public UnmanagedLogFunc UnamangedFunc;
            public UnmanagedDestroyNotify Destroy;
            public CallbackScope Scope;
        }

        public static LogFunc Create(UnmanagedLogFunc logFunc_, IntPtr userData_)
        {
            return new LogFunc((logDomain, logLevel, message) => {
                var logDomain_ = logDomain?.Handle ?? throw new ArgumentNullException(nameof(logDomain));
                var message_ = message?.Handle ?? throw new ArgumentNullException(nameof(message));
                logFunc_(logDomain_, logLevel, message_, userData_);
            });
        }

        public static (UnmanagedLogFunc, UnmanagedDestroyNotify, IntPtr) Create(LogFunc func, CallbackScope scope) {
            var data = new UserData {
                Func = func,
                UnamangedFunc = UnmanagedCallback,
                Destroy = Destroy,
                Scope = scope
            };
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnamangedFunc, data.Destroy, (IntPtr)gcHandle);
        }

        static void UnmanagedCallback(IntPtr logDomain_, LogLevelFlags logLevel_, IntPtr message_, IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                var logDomain = Opaque.GetInstance<Utf8>(logDomain_, Transfer.None);
                var message = Opaque.GetInstance<Utf8>(message_, Transfer.None);
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
