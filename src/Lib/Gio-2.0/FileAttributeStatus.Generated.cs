// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='FileAttributeStatus']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeStatus", IsProxyForUnmanagedType = true)]
    public enum FileAttributeStatus
    {
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='FileAttributeStatus.Unset']/*" />
        Unset = 0,
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='FileAttributeStatus.Set']/*" />
        Set = 1,
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='FileAttributeStatus.ErrorSetting']/*" />
        ErrorSetting = 2
    }

    /// <summary>
    /// Extension methods for <see cref="FileAttributeStatus"/>.
    /// </summary>
    public static unsafe partial class FileAttributeStatusExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = g_file_attribute_status_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_file_attribute_status_get_type();
    }
}