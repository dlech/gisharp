// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileMonitorFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileMonitorFlags : uint
    {
        /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags.WatchMounts']/*" />
        WatchMounts = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags.SendMoved']/*" />
        [System.ObsoleteAttribute]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.46")]
        SendMoved = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags.WatchHardLinks']/*" />
        [GISharp.Runtime.SinceAttribute("2.36")]
        WatchHardLinks = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="FileMonitorFlags.xmldoc" path="declaration/member[@name='FileMonitorFlags.WatchMoves']/*" />
        [GISharp.Runtime.SinceAttribute("2.46")]
        WatchMoves = 0b0000_0000_0000_0000_0000_0000_0000_1000
    }

    /// <summary>
    /// Extension methods for <see cref="FileMonitorFlags"/>.
    /// </summary>
    public static unsafe partial class FileMonitorFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = g_file_monitor_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_file_monitor_flags_get_type();
    }
}