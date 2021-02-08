// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkMessageType", IsProxyForUnmanagedType = true)]
    public enum MessageType
    {
        /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType.Info']/*" />
        Info = 0,
        /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType.Warning']/*" />
        Warning = 1,
        /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType.Question']/*" />
        Question = 2,
        /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType.Error']/*" />
        Error = 3,
        /// <include file="MessageType.xmldoc" path="declaration/member[@name='MessageType.Other']/*" />
        Other = 4
    }

    /// <summary>
    /// Extension methods for <see cref="MessageType"/>.
    /// </summary>
    public static partial class MessageTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_message_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_message_type_get_type();
    }
}