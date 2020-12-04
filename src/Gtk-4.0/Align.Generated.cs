// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Align.xmldoc" path="declaration/member[@name='Align']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkAlign", IsProxyForUnmanagedType = true)]
    public enum Align
    {
        /// <include file="Align.xmldoc" path="declaration/member[@name='Align.Fill']/*" />
        Fill = 0,
        /// <include file="Align.xmldoc" path="declaration/member[@name='Align.Start']/*" />
        Start = 1,
        /// <include file="Align.xmldoc" path="declaration/member[@name='Align.End']/*" />
        End = 2,
        /// <include file="Align.xmldoc" path="declaration/member[@name='Align.Center']/*" />
        Center = 3,
        /// <include file="Align.xmldoc" path="declaration/member[@name='Align.Baseline']/*" />
        Baseline = 4
    }

    /// <summary>
    /// Extension methods for <see cref="Align"/>.
    /// </summary>
    public static partial class AlignExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_align_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_align_get_type();
    }
}