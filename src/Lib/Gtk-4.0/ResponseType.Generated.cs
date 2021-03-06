// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkResponseType", IsProxyForUnmanagedType = true)]
    public enum ResponseType
    {
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.None']/*" />
        None = -1,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Reject']/*" />
        Reject = -2,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Accept']/*" />
        Accept = -3,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.DeleteEvent']/*" />
        DeleteEvent = -4,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Ok']/*" />
        Ok = -5,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Cancel']/*" />
        Cancel = -6,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Close']/*" />
        Close = -7,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Yes']/*" />
        Yes = -8,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.No']/*" />
        No = -9,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Apply']/*" />
        Apply = -10,
        /// <include file="ResponseType.xmldoc" path="declaration/member[@name='ResponseType.Help']/*" />
        Help = -11
    }

    /// <summary>
    /// Extension methods for <see cref="ResponseType"/>.
    /// </summary>
    public static unsafe partial class ResponseTypeExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_response_type_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_response_type_get_type();
    }
}