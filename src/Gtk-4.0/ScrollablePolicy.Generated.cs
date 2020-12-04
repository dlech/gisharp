// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ScrollablePolicy.xmldoc" path="declaration/member[@name='ScrollablePolicy']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkScrollablePolicy", IsProxyForUnmanagedType = true)]
    public enum ScrollablePolicy
    {
        /// <include file="ScrollablePolicy.xmldoc" path="declaration/member[@name='ScrollablePolicy.Minimum']/*" />
        Minimum = 0,
        /// <include file="ScrollablePolicy.xmldoc" path="declaration/member[@name='ScrollablePolicy.Natural']/*" />
        Natural = 1
    }

    /// <summary>
    /// Extension methods for <see cref="ScrollablePolicy"/>.
    /// </summary>
    public static partial class ScrollablePolicyExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_scrollable_policy_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_scrollable_policy_get_type();
    }
}