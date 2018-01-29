using System;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// The signal flags are used to specify a signal's behavior, the overall
    /// signal description outlines how especially the RUN flags control the
    /// stages of a signal emission.
    /// </summary>
    [Flags]
    public enum SignalFlags
    {
        /// <summary>
        /// Invoke the object method handler in the first emission stage.
        /// </summary>
        RunFirst = 0x00000001,

        /// <summary>
        /// Invoke the object method handler in the third emission stage.
        /// </summary>
        RunLast = 0x00000002,

        /// <summary>
        /// Invoke the object method handler in the last emission stage.
        /// </summary>
        RunCleanup = 0x00000004,

        /// <summary>
        /// Signals being emitted for an object while currently being in
        /// emission for this very object will not be emitted recursively,
        /// but instead cause the first emission to be restarted.
        /// </summary>
        NoRecurse = 0x00000008,

        /// <summary>
        /// This signal supports "::detail" appendices to the signal name
        /// upon handler connections and emissions.
        /// </summary>
        Detailed = 0x00000010,

        /// <summary>
        /// Action signals are signals that may freely be emitted on alive
        ///  objects from user code via g_signal_emit() and friends, without
        ///  the need of being embedded into extra code that performs pre or
        ///  post emission adjustments on the object. They can also be thought
        ///  of as object methods which can be called generically by
        ///  third-party code.
        /// </summary>
        Action = 0x00000020,

        /// <summary>
        /// No emissions hooks are supported for this signal.
        /// </summary>
        NoHooks = 0x00000040,

        /// <summary>
        /// Varargs signal emission will always collect the
        /// arguments, even if there are no signal handlers connected.
        /// </summary>
        [Since("2.30")]
        MustCollect = 0x00000080,

        /// <summary>
        /// The signal is deprecated and will be removed
        /// in a future version. A warning will be generated if it is connected
        /// while running with <c>G_ENABLE_DIAGNOSTIC=1</c>.
        /// </summary>
        [Since("2.32")]
        Deprecated = 0x00000100,
    }
}
