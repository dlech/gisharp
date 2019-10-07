// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeInfoFlags.xmldoc" path="declaration/member[@name='FileAttributeInfoFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeInfoFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileAttributeInfoFlags
    {
        /// <include file="FileAttributeInfoFlags.xmldoc" path="declaration/member[@name='FileAttributeInfoFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="FileAttributeInfoFlags.xmldoc" path="declaration/member[@name='FileAttributeInfoFlags.CopyWithFile']/*" />
        CopyWithFile = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="FileAttributeInfoFlags.xmldoc" path="declaration/member[@name='FileAttributeInfoFlags.CopyWhenMoved']/*" />
        CopyWhenMoved = 0b0000_0000_0000_0000_0000_0000_0000_0010
    }

    /// <summary>
    /// Extension methods for <see cref="FileAttributeInfoFlags"/>.
    /// </summary>
    public partial class FileAttributeInfoFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_info_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_info_flags_get_type();
    }
}