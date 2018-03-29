namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Information about a specific attribute.
    /// </summary>
    public partial struct FileAttributeInfo
    {
#pragma warning disable CS0649
        /// <summary>
        /// the name of the attribute.
        /// </summary>
        private System.IntPtr name;

        /// <summary>
        /// the <see cref="FileAttributeType"/> type of the attribute.
        /// </summary>
        public GISharp.Lib.Gio.FileAttributeType Type;

        /// <summary>
        /// a set of <see cref="FileAttributeInfoFlags"/>.
        /// </summary>
        public GISharp.Lib.Gio.FileAttributeInfoFlags Flags;
#pragma warning restore CS0649
    }
}