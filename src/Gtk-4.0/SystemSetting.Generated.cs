// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSystemSetting", IsProxyForUnmanagedType = true)]
    public enum SystemSetting
    {
        /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting.Dpi']/*" />
        Dpi = 0,
        /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting.FontName']/*" />
        FontName = 1,
        /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting.FontConfig']/*" />
        FontConfig = 2,
        /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting.Display']/*" />
        Display = 3,
        /// <include file="SystemSetting.xmldoc" path="declaration/member[@name='SystemSetting.IconTheme']/*" />
        IconTheme = 4
    }

    /// <summary>
    /// Extension methods for <see cref="SystemSetting"/>.
    /// </summary>
    public static partial class SystemSettingExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_system_setting_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_system_setting_get_type();
    }
}