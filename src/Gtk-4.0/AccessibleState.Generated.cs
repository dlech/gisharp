// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkAccessibleState", IsProxyForUnmanagedType = true)]
    public enum AccessibleState
    {
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Busy']/*" />
        Busy = 0,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Checked']/*" />
        Checked = 1,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Disabled']/*" />
        Disabled = 2,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Expanded']/*" />
        Expanded = 3,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Hidden']/*" />
        Hidden = 4,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Invalid']/*" />
        Invalid = 5,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Pressed']/*" />
        Pressed = 6,
        /// <include file="AccessibleState.xmldoc" path="declaration/member[@name='AccessibleState.Selected']/*" />
        Selected = 7
    }

    /// <summary>
    /// Extension methods for <see cref="AccessibleState"/>.
    /// </summary>
    public static partial class AccessibleStateExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_accessible_state_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_accessible_state_get_type();
    }
}