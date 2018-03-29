namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Indicates the file's on-disk type.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileType", IsProxyForUnmanagedType = true)]
    public enum FileType
    {
        /// <summary>
        /// File's type is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// File handle represents a regular file.
        /// </summary>
        Regular = 1,
        /// <summary>
        /// File handle represents a directory.
        /// </summary>
        Directory = 2,
        /// <summary>
        /// File handle represents a symbolic link
        ///    (Unix systems).
        /// </summary>
        SymbolicLink = 3,
        /// <summary>
        /// File is a "special" file, such as a socket, fifo,
        ///    block device, or character device.
        /// </summary>
        Special = 4,
        /// <summary>
        /// File is a shortcut (Windows systems).
        /// </summary>
        Shortcut = 5,
        /// <summary>
        /// File is a mountable location.
        /// </summary>
        Mountable = 6
    }

    public partial class FileTypeExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_type_get_type();
    }
}