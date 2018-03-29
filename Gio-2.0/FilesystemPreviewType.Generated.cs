// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Indicates a hint from the file system whether files should be
    /// previewed in a file manager. Returned as the value of the key
    /// #G_FILE_ATTRIBUTE_FILESYSTEM_USE_PREVIEW.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFilesystemPreviewType", IsProxyForUnmanagedType = true)]
    public enum FilesystemPreviewType
    {
        /// <summary>
        /// Only preview files if user has explicitly requested it.
        /// </summary>
        IfAlways = 0,
        /// <summary>
        /// Preview files if user has requested preview of "local" files.
        /// </summary>
        IfLocal = 1,
        /// <summary>
        /// Never preview files.
        /// </summary>
        Never = 2
    }

    public partial class FilesystemPreviewTypeExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_filesystem_preview_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_filesystem_preview_type_get_type();
    }
}