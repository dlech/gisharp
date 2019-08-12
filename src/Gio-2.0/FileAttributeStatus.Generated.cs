// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='FileAttributeStatus']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeStatus", IsProxyForUnmanagedType = true)]
    public enum FileAttributeStatus
    {
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='Unset']/*" />
        Unset = 0,
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='Set']/*" />
        Set = 1,
        /// <include file="FileAttributeStatus.xmldoc" path="declaration/member[@name='ErrorSetting']/*" />
        ErrorSetting = 2
    }

    /// <summary>
    /// Extension methods for <see cref="FileAttributeStatus"/>.
    /// </summary>
    public partial class FileAttributeStatusExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_status_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_status_get_type();
    }
}