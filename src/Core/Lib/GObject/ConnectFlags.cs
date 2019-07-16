using System;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The connection flags are used to specify the behaviour of a signal's
    /// connection.
    /// </summary>
    [Flags]
    public enum ConnectFlags
    {
        /// <summary>
        /// whether the handler should be called before or after the
        ///  default handler of the signal.
        /// </summary>
        After = 1,
        /// <summary>
        /// whether the instance and data should be swapped when
        ///  calling the handler; see g_signal_connect_swapped() for an example.
        /// </summary>
        Swapped = 2
    }
}
