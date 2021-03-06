// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkStateFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum StateFlags
    {
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Normal']/*" />
        Normal = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Active']/*" />
        Active = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Prelight']/*" />
        Prelight = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Selected']/*" />
        Selected = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Insensitive']/*" />
        Insensitive = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Inconsistent']/*" />
        Inconsistent = 0b0000_0000_0000_0000_0000_0000_0001_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Focused']/*" />
        Focused = 0b0000_0000_0000_0000_0000_0000_0010_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Backdrop']/*" />
        Backdrop = 0b0000_0000_0000_0000_0000_0000_0100_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.DirLtr']/*" />
        DirLtr = 0b0000_0000_0000_0000_0000_0000_1000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.DirRtl']/*" />
        DirRtl = 0b0000_0000_0000_0000_0000_0001_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Link']/*" />
        Link = 0b0000_0000_0000_0000_0000_0010_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Visited']/*" />
        Visited = 0b0000_0000_0000_0000_0000_0100_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.Checked']/*" />
        Checked = 0b0000_0000_0000_0000_0000_1000_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.DropActive']/*" />
        DropActive = 0b0000_0000_0000_0000_0001_0000_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.FocusVisible']/*" />
        FocusVisible = 0b0000_0000_0000_0000_0010_0000_0000_0000,
        /// <include file="StateFlags.xmldoc" path="declaration/member[@name='StateFlags.FocusWithin']/*" />
        FocusWithin = 0b0000_0000_0000_0000_0100_0000_0000_0000
    }

    /// <summary>
    /// Extension methods for <see cref="StateFlags"/>.
    /// </summary>
    public static unsafe partial class StateFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_state_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_state_flags_get_type();
    }
}