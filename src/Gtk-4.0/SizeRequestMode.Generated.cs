// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSizeRequestMode", IsProxyForUnmanagedType = true)]
    public enum SizeRequestMode
    {
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.HeightForWidth']/*" />
        HeightForWidth = 0,
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.WidthForHeight']/*" />
        WidthForHeight = 1,
        /// <include file="SizeRequestMode.xmldoc" path="declaration/member[@name='SizeRequestMode.ConstantSize']/*" />
        ConstantSize = 2
    }

    /// <summary>
    /// Extension methods for <see cref="SizeRequestMode"/>.
    /// </summary>
    public static partial class SizeRequestModeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_size_request_mode_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_size_request_mode_get_type();
    }
}