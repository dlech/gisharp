namespace GISharp.Lib.GLib
{
    /// <summary>
    /// An enumeration specifying the base position for a
    /// g_io_channel_seek_position() operation.
    /// </summary>
    public enum SeekType
    {
        /// <summary>
        /// the current position in the file.
        /// </summary>
        Current = 0,
        /// <summary>
        /// the start of the file.
        /// </summary>
        Start = 1,
        /// <summary>
        /// the end of the file.
        /// </summary>
        End = 2
    }
}