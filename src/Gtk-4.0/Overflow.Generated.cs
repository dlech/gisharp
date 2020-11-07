// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Overflow.xmldoc" path="declaration/member[@name='Overflow']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkOverflow", IsProxyForUnmanagedType = true)]
    public enum Overflow
    {
        /// <include file="Overflow.xmldoc" path="declaration/member[@name='Overflow.Visible']/*" />
        Visible = 0,
        /// <include file="Overflow.xmldoc" path="declaration/member[@name='Overflow.Hidden']/*" />
        Hidden = 1
    }

    /// <summary>
    /// Extension methods for <see cref="Overflow"/>.
    /// </summary>
    public static partial class OverflowExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_overflow_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_overflow_get_type();
    }
}