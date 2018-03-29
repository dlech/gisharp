namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Disambiguates a given time in two ways.
    /// </summary>
    /// <remarks>
    /// First, specifies if the given time is in universal or local time.
    /// 
    /// Second, if the time is in local time, specifies if it is local
    /// standard time or local daylight time.  This is important for the case
    /// where the same local time occurs twice (during daylight savings time
    /// transitions, for example).
    /// </remarks>
    public enum TimeType
    {
        /// <summary>
        /// the time is in local standard time
        /// </summary>
        Standard = 0,
        /// <summary>
        /// the time is in local daylight time
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// the time is in UTC
        /// </summary>
        Universal = 2
    }
}