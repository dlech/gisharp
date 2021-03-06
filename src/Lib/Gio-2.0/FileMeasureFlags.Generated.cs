// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileMeasureFlags.xmldoc" path="declaration/member[@name='FileMeasureFlags']/*" />
    [GISharp.Runtime.SinceAttribute("2.38")]
    [GISharp.Runtime.GTypeAttribute("GFileMeasureFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileMeasureFlags : uint
    {
        /// <include file="FileMeasureFlags.xmldoc" path="declaration/member[@name='FileMeasureFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="FileMeasureFlags.xmldoc" path="declaration/member[@name='FileMeasureFlags.ReportAnyError']/*" />
        ReportAnyError = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="FileMeasureFlags.xmldoc" path="declaration/member[@name='FileMeasureFlags.ApparentSize']/*" />
        ApparentSize = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="FileMeasureFlags.xmldoc" path="declaration/member[@name='FileMeasureFlags.NoCrossMountPoint']/*" />
        NoCrossMountPoint = 0b0000_0000_0000_0000_0000_0000_0000_1000
    }

    /// <summary>
    /// Extension methods for <see cref="FileMeasureFlags"/>.
    /// </summary>
    public static unsafe partial class FileMeasureFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = g_file_measure_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_file_measure_flags_get_type();
    }
}