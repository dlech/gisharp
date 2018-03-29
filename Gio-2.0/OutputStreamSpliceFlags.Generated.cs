namespace GISharp.Lib.Gio
{
    /// <summary>
    /// GOutputStreamSpliceFlags determine how streams should be spliced.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GOutputStreamSpliceFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum OutputStreamSpliceFlags
    {
        /// <summary>
        /// Do not close either stream.
        /// </summary>
        None = 0,
        /// <summary>
        /// Close the source stream after
        ///     the splice.
        /// </summary>
        CloseSource = 1,
        /// <summary>
        /// Close the target stream after
        ///     the splice.
        /// </summary>
        CloseTarget = 2
    }

    public partial class OutputStreamSpliceFlagsExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_output_stream_splice_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_output_stream_splice_flags_get_type();
    }
}