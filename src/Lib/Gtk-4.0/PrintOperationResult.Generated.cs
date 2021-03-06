// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PrintOperationResult.xmldoc" path="declaration/member[@name='PrintOperationResult']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPrintOperationResult", IsProxyForUnmanagedType = true)]
    public enum PrintOperationResult
    {
        /// <include file="PrintOperationResult.xmldoc" path="declaration/member[@name='PrintOperationResult.Error']/*" />
        Error = 0,
        /// <include file="PrintOperationResult.xmldoc" path="declaration/member[@name='PrintOperationResult.Apply']/*" />
        Apply = 1,
        /// <include file="PrintOperationResult.xmldoc" path="declaration/member[@name='PrintOperationResult.Cancel']/*" />
        Cancel = 2,
        /// <include file="PrintOperationResult.xmldoc" path="declaration/member[@name='PrintOperationResult.InProgress']/*" />
        InProgress = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PrintOperationResult"/>.
    /// </summary>
    public static unsafe partial class PrintOperationResultExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_print_operation_result_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_print_operation_result_get_type();
    }
}