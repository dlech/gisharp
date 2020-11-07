// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="TextViewLayer.xmldoc" path="declaration/member[@name='TextViewLayer']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkTextViewLayer", IsProxyForUnmanagedType = true)]
    public enum TextViewLayer
    {
        /// <include file="TextViewLayer.xmldoc" path="declaration/member[@name='TextViewLayer.BelowText']/*" />
        BelowText = 0,
        /// <include file="TextViewLayer.xmldoc" path="declaration/member[@name='TextViewLayer.AboveText']/*" />
        AboveText = 1
    }

    /// <summary>
    /// Extension methods for <see cref="TextViewLayer"/>.
    /// </summary>
    public static partial class TextViewLayerExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_text_view_layer_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_text_view_layer_get_type();
    }
}