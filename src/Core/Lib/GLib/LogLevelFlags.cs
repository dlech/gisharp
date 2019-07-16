using System;
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Flags specifying the level of log messages.
    /// </summary>
    /// <remarks>
    /// It is possible to change how GLib treats messages of the various
    /// levels using <see cref="Log.SetHandler"/> and <see cref="Log.SetFatalMask"/>.
    /// </remarks>
    [Flags]
    public enum LogLevelFlags
    {
        /// <summary>
        /// internal flag
        /// </summary>
        Recursion = 1,
        /// <summary>
        /// internal flag
        /// </summary>
        Fatal = 2,
        /// <summary>
        /// log level for errors, see g_error().
        ///     This level is also used for messages produced by g_assert().
        /// </summary>
        Error = 4,
        /// <summary>
        /// log level for critical warning messages, see g_critical().
        /// </summary>
        /// <remarks>
        /// This level is also used for messages produced by g_return_if_fail()
        /// and g_return_val_if_fail().
        /// </remarks>
        Critical = 8,
        /// <summary>
        /// log level for warnings, see g_warning()
        /// </summary>
        Warning = 16,
        /// <summary>
        /// log level for messages, see g_message()
        /// </summary>
        Message = 32,
        /// <summary>
        /// log level for informational messages, see g_info()
        /// </summary>
        Info = 64,
        /// <summary>
        /// log level for debug messages, see g_debug()
        /// </summary>
        Debug = 128,
        /// <summary>
        /// a mask including all log levels
        /// </summary>
        Mask = -4
    }
}
