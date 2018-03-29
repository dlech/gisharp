namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Flags specifying the behaviour of an attribute.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileAttributeInfoFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum FileAttributeInfoFlags
    {
        /// <summary>
        /// no flags set.
        /// </summary>
        None = 0,
        /// <summary>
        /// copy the attribute values when the file is copied.
        /// </summary>
        CopyWithFile = 1,
        /// <summary>
        /// copy the attribute values when the file is moved.
        /// </summary>
        CopyWhenMoved = 2
    }

    public partial class FileAttributeInfoFlagsExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_info_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_info_flags_get_type();
    }
}