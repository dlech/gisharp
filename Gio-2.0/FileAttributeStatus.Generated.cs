namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Used by g_file_set_attributes_from_info() when setting file attributes.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileAttributeStatus", IsProxyForUnmanagedType = true)]
    public enum FileAttributeStatus
    {
        /// <summary>
        /// Attribute value is unset (empty).
        /// </summary>
        Unset = 0,
        /// <summary>
        /// Attribute value is set.
        /// </summary>
        Set = 1,
        /// <summary>
        /// Indicates an error in setting the value.
        /// </summary>
        ErrorSetting = 2
    }

    public partial class FileAttributeStatusExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_status_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_status_get_type();
    }
}