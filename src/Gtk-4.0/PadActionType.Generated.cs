// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PadActionType.xmldoc" path="declaration/member[@name='PadActionType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPadActionType", IsProxyForUnmanagedType = true)]
    public enum PadActionType
    {
        /// <include file="PadActionType.xmldoc" path="declaration/member[@name='PadActionType.Button']/*" />
        Button = 0,
        /// <include file="PadActionType.xmldoc" path="declaration/member[@name='PadActionType.Ring']/*" />
        Ring = 1,
        /// <include file="PadActionType.xmldoc" path="declaration/member[@name='PadActionType.Strip']/*" />
        Strip = 2
    }

    /// <summary>
    /// Extension methods for <see cref="PadActionType"/>.
    /// </summary>
    public static partial class PadActionTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_pad_action_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_pad_action_type_get_type();
    }
}