// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkAssistantPageType", IsProxyForUnmanagedType = true)]
    public enum AssistantPageType
    {
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Content']/*" />
        Content = 0,
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Intro']/*" />
        Intro = 1,
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Confirm']/*" />
        Confirm = 2,
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Summary']/*" />
        Summary = 3,
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Progress']/*" />
        Progress = 4,
        /// <include file="AssistantPageType.xmldoc" path="declaration/member[@name='AssistantPageType.Custom']/*" />
        Custom = 5
    }

    /// <summary>
    /// Extension methods for <see cref="AssistantPageType"/>.
    /// </summary>
    public static partial class AssistantPageTypeExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_assistant_page_type_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_assistant_page_type_get_type();
    }
}