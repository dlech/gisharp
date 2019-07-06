// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// GIOStreamSpliceFlags determine how streams should be spliced.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [GISharp.Runtime.GTypeAttribute("GIOStreamSpliceFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum IOStreamSpliceFlags
    {
        /// <summary>
        /// Do not close either stream.
        /// </summary>
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <summary>
        /// Close the first stream after
        ///     the splice.
        /// </summary>
        CloseStream1 = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <summary>
        /// Close the second stream after
        ///     the splice.
        /// </summary>
        CloseStream2 = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <summary>
        /// Wait for both splice operations to finish
        ///     before calling the callback.
        /// </summary>
        WaitForBoth = 0b0000_0000_0000_0000_0000_0000_0000_0100
    }

    public partial class IOStreamSpliceFlagsExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_io_stream_splice_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_io_stream_splice_flags_get_type();
    }
}