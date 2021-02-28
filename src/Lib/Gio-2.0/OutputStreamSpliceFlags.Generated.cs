// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="OutputStreamSpliceFlags.xmldoc" path="declaration/member[@name='OutputStreamSpliceFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GOutputStreamSpliceFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum OutputStreamSpliceFlags
    {
        /// <include file="OutputStreamSpliceFlags.xmldoc" path="declaration/member[@name='OutputStreamSpliceFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="OutputStreamSpliceFlags.xmldoc" path="declaration/member[@name='OutputStreamSpliceFlags.CloseSource']/*" />
        CloseSource = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="OutputStreamSpliceFlags.xmldoc" path="declaration/member[@name='OutputStreamSpliceFlags.CloseTarget']/*" />
        CloseTarget = 0b0000_0000_0000_0000_0000_0000_0000_0010
    }

    /// <summary>
    /// Extension methods for <see cref="OutputStreamSpliceFlags"/>.
    /// </summary>
    public static unsafe partial class OutputStreamSpliceFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_output_stream_splice_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_output_stream_splice_flags_get_type();
    }
}