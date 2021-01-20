// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkButtonsType", IsProxyForUnmanagedType = true)]
    public enum ButtonsType
    {
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.None']/*" />
        None = 0,
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.Ok']/*" />
        Ok = 1,
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.Close']/*" />
        Close = 2,
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.Cancel']/*" />
        Cancel = 3,
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.YesNo']/*" />
        YesNo = 4,
        /// <include file="ButtonsType.xmldoc" path="declaration/member[@name='ButtonsType.OkCancel']/*" />
        OkCancel = 5
    }

    /// <summary>
    /// Extension methods for <see cref="ButtonsType"/>.
    /// </summary>
    public static partial class ButtonsTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_buttons_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_buttons_type_get_type();
    }
}