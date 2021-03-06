// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PrintOperationAction.xmldoc" path="declaration/member[@name='PrintOperationAction']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPrintOperationAction", IsProxyForUnmanagedType = true)]
    public enum PrintOperationAction
    {
        /// <include file="PrintOperationAction.xmldoc" path="declaration/member[@name='PrintOperationAction.PrintDialog']/*" />
        PrintDialog = 0,
        /// <include file="PrintOperationAction.xmldoc" path="declaration/member[@name='PrintOperationAction.Print']/*" />
        Print = 1,
        /// <include file="PrintOperationAction.xmldoc" path="declaration/member[@name='PrintOperationAction.Preview']/*" />
        Preview = 2,
        /// <include file="PrintOperationAction.xmldoc" path="declaration/member[@name='PrintOperationAction.Export']/*" />
        Export = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PrintOperationAction"/>.
    /// </summary>
    public static unsafe partial class PrintOperationActionExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_print_operation_action_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_print_operation_action_get_type();
    }
}