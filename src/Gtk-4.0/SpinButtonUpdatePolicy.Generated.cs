// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SpinButtonUpdatePolicy.xmldoc" path="declaration/member[@name='SpinButtonUpdatePolicy']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSpinButtonUpdatePolicy", IsProxyForUnmanagedType = true)]
    public enum SpinButtonUpdatePolicy
    {
        /// <include file="SpinButtonUpdatePolicy.xmldoc" path="declaration/member[@name='SpinButtonUpdatePolicy.Always']/*" />
        Always = 0,
        /// <include file="SpinButtonUpdatePolicy.xmldoc" path="declaration/member[@name='SpinButtonUpdatePolicy.IfValid']/*" />
        IfValid = 1
    }

    /// <summary>
    /// Extension methods for <see cref="SpinButtonUpdatePolicy"/>.
    /// </summary>
    public static partial class SpinButtonUpdatePolicyExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_spin_button_update_policy_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_spin_button_update_policy_get_type();
    }
}