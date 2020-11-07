// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="License.xmldoc" path="declaration/member[@name='License']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkLicense", IsProxyForUnmanagedType = true)]
    public enum License
    {
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Unknown']/*" />
        Unknown = 0,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Custom']/*" />
        Custom = 1,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Gpl20']/*" />
        Gpl20 = 2,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Gpl30']/*" />
        Gpl30 = 3,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Lgpl21']/*" />
        Lgpl21 = 4,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Lgpl30']/*" />
        Lgpl30 = 5,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Bsd']/*" />
        Bsd = 6,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.MitX11']/*" />
        MitX11 = 7,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Artistic']/*" />
        Artistic = 8,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Gpl20Only']/*" />
        Gpl20Only = 9,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Gpl30Only']/*" />
        Gpl30Only = 10,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Lgpl21Only']/*" />
        Lgpl21Only = 11,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Lgpl30Only']/*" />
        Lgpl30Only = 12,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Agpl30']/*" />
        Agpl30 = 13,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Agpl30Only']/*" />
        Agpl30Only = 14,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Bsd3']/*" />
        Bsd3 = 15,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Apache20']/*" />
        Apache20 = 16,
        /// <include file="License.xmldoc" path="declaration/member[@name='License.Mpl20']/*" />
        Mpl20 = 17
    }

    /// <summary>
    /// Extension methods for <see cref="License"/>.
    /// </summary>
    public static partial class LicenseExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_license_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_license_get_type();
    }
}