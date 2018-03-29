// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// The data types for file attributes.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileAttributeType", IsProxyForUnmanagedType = true)]
    public enum FileAttributeType
    {
        /// <summary>
        /// indicates an invalid or uninitalized type.
        /// </summary>
        Invalid = 0,
        /// <summary>
        /// a null terminated UTF8 string.
        /// </summary>
        String = 1,
        /// <summary>
        /// a zero terminated string of non-zero bytes.
        /// </summary>
        ByteString = 2,
        /// <summary>
        /// a boolean value.
        /// </summary>
        Boolean = 3,
        /// <summary>
        /// an unsigned 4-byte/32-bit integer.
        /// </summary>
        Uint32 = 4,
        /// <summary>
        /// a signed 4-byte/32-bit integer.
        /// </summary>
        Int32 = 5,
        /// <summary>
        /// an unsigned 8-byte/64-bit integer.
        /// </summary>
        Uint64 = 6,
        /// <summary>
        /// a signed 8-byte/64-bit integer.
        /// </summary>
        Int64 = 7,
        /// <summary>
        /// a #GObject.
        /// </summary>
        Object = 8,
        /// <summary>
        /// a <c>null</c> terminated char **.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        StringArray = 9
    }

    public partial class FileAttributeTypeExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_type_get_type();
    }
}