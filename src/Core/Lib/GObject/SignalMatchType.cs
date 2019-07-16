using System;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The match types specify what g_signal_handlers_block_matched(),
    /// g_signal_handlers_unblock_matched() and g_signal_handlers_disconnect_matched()
    /// match signals by.
    /// </summary>
    [Flags]
    public enum SignalMatchType
    {
        /// <summary>
        /// The signal id must be equal.
        /// </summary>
        Id = 0x01,

        /// <summary>
        /// The signal detail be equal.
        /// </summary>
        Detail = 0x02,

        /// <summary>
        /// The closure must be the same.
        /// </summary>
        Closure = 0x04,

        /// <summary>
        /// The C closure callback must be the same.
        /// </summary>
        Func = 0x08,

        /// <summary>
        /// The closure data must be the same.
        /// </summary>
        Data = 0x10,

        /// <summary>
        /// Only unblocked signals may matched.
        /// </summary>
        Unblocked = 0x20,
    }
}
