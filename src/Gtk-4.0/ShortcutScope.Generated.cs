// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ShortcutScope.xmldoc" path="declaration/member[@name='ShortcutScope']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkShortcutScope", IsProxyForUnmanagedType = true)]
    public enum ShortcutScope
    {
        /// <include file="ShortcutScope.xmldoc" path="declaration/member[@name='ShortcutScope.Local']/*" />
        Local = 0,
        /// <include file="ShortcutScope.xmldoc" path="declaration/member[@name='ShortcutScope.Managed']/*" />
        Managed = 1,
        /// <include file="ShortcutScope.xmldoc" path="declaration/member[@name='ShortcutScope.Global']/*" />
        Global = 2
    }

    /// <summary>
    /// Extension methods for <see cref="ShortcutScope"/>.
    /// </summary>
    public static partial class ShortcutScopeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_shortcut_scope_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_shortcut_scope_get_type();
    }
}