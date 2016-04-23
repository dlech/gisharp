using System;

namespace GISharp.GObject
{
    /// <summary>
    /// The #GSignalInvocationHint structure is used to pass on additional information
    /// to callbacks during a signal emission.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    struct SignalInvocationHint
    {
        /// <summary>
        /// The signal id of the signal invoking the callback
        /// </summary>
        public System.UInt32 SignalId;

        /// <summary>
        /// The detail passed on for this emission
        /// </summary>
        public GISharp.GLib.Quark Detail;

        /// <summary>
        /// The stage the signal emission is currently in, this
        ///  field will contain one of %G_SIGNAL_RUN_FIRST,
        ///  %G_SIGNAL_RUN_LAST or %G_SIGNAL_RUN_CLEANUP.
        /// </summary>
        public GISharp.GObject.SignalFlags RunType;
    }
}
