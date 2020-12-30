// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PolicyType.xmldoc" path="declaration/member[@name='PolicyType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPolicyType", IsProxyForUnmanagedType = true)]
    public enum PolicyType
    {
        /// <include file="PolicyType.xmldoc" path="declaration/member[@name='PolicyType.Always']/*" />
        Always = 0,
        /// <include file="PolicyType.xmldoc" path="declaration/member[@name='PolicyType.Automatic']/*" />
        Automatic = 1,
        /// <include file="PolicyType.xmldoc" path="declaration/member[@name='PolicyType.Never']/*" />
        Never = 2,
        /// <include file="PolicyType.xmldoc" path="declaration/member[@name='PolicyType.External']/*" />
        External = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PolicyType"/>.
    /// </summary>
    public static partial class PolicyTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_policy_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_policy_type_get_type();
    }
}