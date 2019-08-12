// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='FileAttributeType']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeType", IsProxyForUnmanagedType = true)]
    public enum FileAttributeType
    {
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Invalid']/*" />
        Invalid = 0,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='String']/*" />
        String = 1,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='ByteString']/*" />
        ByteString = 2,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Boolean']/*" />
        Boolean = 3,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Uint32']/*" />
        Uint32 = 4,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Int32']/*" />
        Int32 = 5,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Uint64']/*" />
        Uint64 = 6,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Int64']/*" />
        Int64 = 7,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='Object']/*" />
        Object = 8,
        /// <include file="FileAttributeType.xmldoc" path="declaration/member[@name='StringArray']/*" />
        [GISharp.Runtime.SinceAttribute("2.22")]
        StringArray = 9
    }

    /// <summary>
    /// Extension methods for <see cref="FileAttributeType"/>.
    /// </summary>
    public partial class FileAttributeTypeExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_type_get_type();
    }
}