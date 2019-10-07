// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="IOStreamSpliceFlags.xmldoc" path="declaration/member[@name='IOStreamSpliceFlags']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    [GISharp.Runtime.GTypeAttribute("GIOStreamSpliceFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum IOStreamSpliceFlags
    {
        /// <include file="IOStreamSpliceFlags.xmldoc" path="declaration/member[@name='IOStreamSpliceFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="IOStreamSpliceFlags.xmldoc" path="declaration/member[@name='IOStreamSpliceFlags.CloseStream1']/*" />
        CloseStream1 = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="IOStreamSpliceFlags.xmldoc" path="declaration/member[@name='IOStreamSpliceFlags.CloseStream2']/*" />
        CloseStream2 = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="IOStreamSpliceFlags.xmldoc" path="declaration/member[@name='IOStreamSpliceFlags.WaitForBoth']/*" />
        WaitForBoth = 0b0000_0000_0000_0000_0000_0000_0000_0100
    }

    /// <summary>
    /// Extension methods for <see cref="IOStreamSpliceFlags"/>.
    /// </summary>
    public partial class IOStreamSpliceFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_io_stream_splice_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_io_stream_splice_flags_get_type();
    }
}