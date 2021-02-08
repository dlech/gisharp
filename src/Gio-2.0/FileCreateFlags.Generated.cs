// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileCreateFlags.xmldoc" path="declaration/member[@name='FileCreateFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileCreateFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileCreateFlags
    {
        /// <include file="FileCreateFlags.xmldoc" path="declaration/member[@name='FileCreateFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="FileCreateFlags.xmldoc" path="declaration/member[@name='FileCreateFlags.Private']/*" />
        Private = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="FileCreateFlags.xmldoc" path="declaration/member[@name='FileCreateFlags.ReplaceDestination']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        ReplaceDestination = 0b0000_0000_0000_0000_0000_0000_0000_0010
    }

    /// <summary>
    /// Extension methods for <see cref="FileCreateFlags"/>.
    /// </summary>
    public static partial class FileCreateFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_create_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType g_file_create_flags_get_type();
    }
}