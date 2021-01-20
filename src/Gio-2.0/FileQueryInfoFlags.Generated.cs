// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileQueryInfoFlags.xmldoc" path="declaration/member[@name='FileQueryInfoFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileQueryInfoFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileQueryInfoFlags
    {
        /// <include file="FileQueryInfoFlags.xmldoc" path="declaration/member[@name='FileQueryInfoFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="FileQueryInfoFlags.xmldoc" path="declaration/member[@name='FileQueryInfoFlags.NoFollowSymlinks']/*" />
        NoFollowSymlinks = 0b0000_0000_0000_0000_0000_0000_0000_0001
    }

    /// <summary>
    /// Extension methods for <see cref="FileQueryInfoFlags"/>.
    /// </summary>
    public static partial class FileQueryInfoFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_query_info_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_file_query_info_flags_get_type();
    }
}