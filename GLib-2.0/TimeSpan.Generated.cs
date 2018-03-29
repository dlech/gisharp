namespace GISharp.Lib.GLib
{
    public partial struct TimeSpan
    {
        /// <summary>
        /// Evaluates to a time span of one day.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Day = 86400000000L;

        /// <summary>
        /// Evaluates to a time span of one hour.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Hour = 3600000000L;

        /// <summary>
        /// Evaluates to a time span of one millisecond.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Millisecond = 1000L;

        /// <summary>
        /// Evaluates to a time span of one minute.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Minute = 60000000L;

        /// <summary>
        /// Evaluates to a time span of one second.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Second = 1000000L;
    }
}