// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkArrowType", IsProxyForUnmanagedType = true)]
    public enum ArrowType
    {
        /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType.Up']/*" />
        Up = 0,
        /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType.Down']/*" />
        Down = 1,
        /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType.Left']/*" />
        Left = 2,
        /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType.Right']/*" />
        Right = 3,
        /// <include file="ArrowType.xmldoc" path="declaration/member[@name='ArrowType.None']/*" />
        None = 4
    }

    /// <summary>
    /// Extension methods for <see cref="ArrowType"/>.
    /// </summary>
    public static partial class ArrowTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_arrow_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_arrow_type_get_type();
    }
}