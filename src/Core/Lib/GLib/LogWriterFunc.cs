

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Writer function for log entries. A log entry is a collection of one or more
    /// #GLogFields, using the standard [field names from journal
    /// specification](https://www.freedesktop.org/software/systemd/man/systemd.journal-fields.html).
    /// See g_log_structured() for more information.
    /// </summary>
    /// <remarks>
    /// Writer functions must ignore fields which they do not recognise, unless they
    /// can write arbitrary binary output, as field values may be arbitrary binary.
    ///
    /// @log_level is guaranteed to be included in @fields as the `PRIORITY` field,
    /// but is provided separately for convenience of deciding whether or where to
    /// output the log entry.
    /// </remarks>
    [Since("2.50")]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate LogWriterOutput UnmanagedLogWriterFunc(
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
        nuint nFields,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:3 */
        IntPtr userData);

    /// <summary>
    /// Writer function for log entries. A log entry is a collection of one or more
    /// #GLogFields, using the standard [field names from journal
    /// specification](https://www.freedesktop.org/software/systemd/man/systemd.journal-fields.html).
    /// See g_log_structured() for more information.
    /// </summary>
    /// <remarks>
    /// Writer functions must ignore fields which they do not recognise, unless they
    /// can write arbitrary binary output, as field values may be arbitrary binary.
    ///
    /// @log_level is guaranteed to be included in @fields as the `PRIORITY` field,
    /// but is provided separately for convenience of deciding whether or where to
    /// output the log entry.
    /// </remarks>
    [Since("2.50")]
    public delegate LogWriterOutput LogWriterFunc(LogLevelFlags logLevel, ReadOnlySpan<LogField> fields);

    public static class LogWriterFuncFactory
    {
        class UserData
        {
            public readonly LogWriterFunc Func;
            public readonly UnmanagedLogWriterFunc UnmanagedFunc;
            public readonly UnmanagedDestroyNotify UnmanagedNotify;
            public readonly CallbackScope Scope;

            public UserData(LogWriterFunc func, UnmanagedLogWriterFunc unmanagedFunc, UnmanagedDestroyNotify unmanagedNotify, CallbackScope scope)
            {
                Func = func;
                UnmanagedFunc = unmanagedFunc;
                UnmanagedNotify = unmanagedNotify;
                Scope = scope;
            }
        }

        public unsafe static LogWriterFunc Create(UnmanagedLogWriterFunc func, IntPtr userData)
        {
            return new LogWriterFunc((logLevel, fields) => {
                fixed (LogField* fields_ = fields) {
                    var ret = func(logLevel, fields_, (UIntPtr)fields.Length, userData);
                    return ret;
                }
            });
        }

        public static unsafe (UnmanagedLogWriterFunc, UnmanagedDestroyNotify, IntPtr) Create(LogWriterFunc func, CallbackScope scope)
        {
            var data = new UserData(func, UnmanagedFunc, UnmanagedNotify, scope);
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnmanagedFunc, data.UnmanagedNotify, (IntPtr)gcHandle);
        }

        static unsafe LogWriterOutput UnmanagedFunc(LogLevelFlags logLevel_, LogField* fields_, UIntPtr nFields_, IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var fields = new ReadOnlySpan<LogField>(fields_, (int)nFields_);
                var userData = (UserData)gcHandle.Target;
                var ret = userData.Func(logLevel_, fields);
                if (userData.Scope == CallbackScope.Async) {
                    gcHandle.Free();
                }
                return ret;
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        static void UnmanagedNotify(IntPtr userData_)
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
