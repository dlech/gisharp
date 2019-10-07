// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileType", IsProxyForUnmanagedType = true)]
    public enum FileType
    {
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Unknown']/*" />
        Unknown = 0,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Regular']/*" />
        Regular = 1,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Directory']/*" />
        Directory = 2,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.SymbolicLink']/*" />
        SymbolicLink = 3,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Special']/*" />
        Special = 4,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Shortcut']/*" />
        Shortcut = 5,
        /// <include file="FileType.xmldoc" path="declaration/member[@name='FileType.Mountable']/*" />
        Mountable = 6
    }

    /// <summary>
    /// Extension methods for <see cref="FileType"/>.
    /// </summary>
    public partial class FileTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_file_type_get_type();
    }
}