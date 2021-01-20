// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkEventControllerScrollFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum EventControllerScrollFlags
    {
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.None']/*" />
        None = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.Vertical']/*" />
        Vertical = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.Horizontal']/*" />
        Horizontal = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.Discrete']/*" />
        Discrete = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.Kinetic']/*" />
        Kinetic = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="EventControllerScrollFlags.xmldoc" path="declaration/member[@name='EventControllerScrollFlags.BothAxes']/*" />
        BothAxes = 0b0000_0000_0000_0000_0000_0000_0000_0011
    }

    /// <summary>
    /// Extension methods for <see cref="EventControllerScrollFlags"/>.
    /// </summary>
    public static partial class EventControllerScrollFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_event_controller_scroll_flags_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType gtk_event_controller_scroll_flags_get_type();
    }
}