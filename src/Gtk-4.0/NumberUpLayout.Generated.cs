// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkNumberUpLayout", IsProxyForUnmanagedType = true)]
    public enum NumberUpLayout
    {
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Lrtb']/*" />
        Lrtb = 0,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Lrbt']/*" />
        Lrbt = 1,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Rltb']/*" />
        Rltb = 2,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Rlbt']/*" />
        Rlbt = 3,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Tblr']/*" />
        Tblr = 4,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Tbrl']/*" />
        Tbrl = 5,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Btlr']/*" />
        Btlr = 6,
        /// <include file="NumberUpLayout.xmldoc" path="declaration/member[@name='NumberUpLayout.Btrl']/*" />
        Btrl = 7
    }

    /// <summary>
    /// Extension methods for <see cref="NumberUpLayout"/>.
    /// </summary>
    public static partial class NumberUpLayoutExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_number_up_layout_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_number_up_layout_get_type();
    }
}