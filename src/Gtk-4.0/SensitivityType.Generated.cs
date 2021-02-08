// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="SensitivityType.xmldoc" path="declaration/member[@name='SensitivityType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkSensitivityType", IsProxyForUnmanagedType = true)]
    public enum SensitivityType
    {
        /// <include file="SensitivityType.xmldoc" path="declaration/member[@name='SensitivityType.Auto']/*" />
        Auto = 0,
        /// <include file="SensitivityType.xmldoc" path="declaration/member[@name='SensitivityType.On']/*" />
        On = 1,
        /// <include file="SensitivityType.xmldoc" path="declaration/member[@name='SensitivityType.Off']/*" />
        Off = 2
    }

    /// <summary>
    /// Extension methods for <see cref="SensitivityType"/>.
    /// </summary>
    public static unsafe partial class SensitivityTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_sensitivity_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_sensitivity_type_get_type();
    }
}