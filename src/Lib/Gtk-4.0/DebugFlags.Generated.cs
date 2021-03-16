// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkDebugFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum DebugFlags : uint
    {
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Text']/*" />
        Text = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Tree']/*" />
        Tree = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Keybindings']/*" />
        Keybindings = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Modules']/*" />
        Modules = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Geometry']/*" />
        Geometry = 0b0000_0000_0000_0000_0000_0000_0001_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Icontheme']/*" />
        Icontheme = 0b0000_0000_0000_0000_0000_0000_0010_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Printing']/*" />
        Printing = 0b0000_0000_0000_0000_0000_0000_0100_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Builder']/*" />
        Builder = 0b0000_0000_0000_0000_0000_0000_1000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.SizeRequest']/*" />
        SizeRequest = 0b0000_0000_0000_0000_0000_0001_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.NoCssCache']/*" />
        NoCssCache = 0b0000_0000_0000_0000_0000_0010_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Interactive']/*" />
        Interactive = 0b0000_0000_0000_0000_0000_0100_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Touchscreen']/*" />
        Touchscreen = 0b0000_0000_0000_0000_0000_1000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Actions']/*" />
        Actions = 0b0000_0000_0000_0000_0001_0000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Layout']/*" />
        Layout = 0b0000_0000_0000_0000_0010_0000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Snapshot']/*" />
        Snapshot = 0b0000_0000_0000_0000_0100_0000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.Constraints']/*" />
        Constraints = 0b0000_0000_0000_0000_1000_0000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.BuilderObjects']/*" />
        BuilderObjects = 0b0000_0000_0000_0001_0000_0000_0000_0000,
        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlags.A11y']/*" />
        A11y = 0b0000_0000_0000_0010_0000_0000_0000_0000
    }

    /// <summary>
    /// Extension methods for <see cref="DebugFlags"/>.
    /// </summary>
    public static unsafe partial class DebugFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = gtk_debug_flags_get_type();

        /// <include file="DebugFlags.xmldoc" path="declaration/member[@name='DebugFlagsExtensions.Current']/*" />
        public static GISharp.Lib.Gtk.DebugFlags Current { get => GetCurrent(); set => SetCurrent(value); }

        /// <summary>
        /// Returns the GTK debug flags that are currently active.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is intended for GTK modules that want
        /// to adjust their debug output based on GTK debug flags.
        /// </para>
        /// </remarks>
        /// <returns>
        /// the GTK debug flags.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DebugFlags" type="GtkDebugFlags" managed-name="DebugFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.Gtk.DebugFlags gtk_get_debug_flags();
        static partial void CheckGetCurrentArgs();

        private static GISharp.Lib.Gtk.DebugFlags GetCurrent()
        {
            CheckGetCurrentArgs();
            var ret_ = gtk_get_debug_flags();
            var ret = (GISharp.Lib.Gtk.DebugFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Sets the GTK debug flags.
        /// </summary>
        /// <param name="flags">
        /// the debug flags to set
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void gtk_set_debug_flags(
        /* <type name="DebugFlags" type="GtkDebugFlags" managed-name="DebugFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gtk.DebugFlags flags);
        static partial void CheckSetCurrentArgs(GISharp.Lib.Gtk.DebugFlags flags);

        private static void SetCurrent(GISharp.Lib.Gtk.DebugFlags flags)
        {
            CheckSetCurrentArgs(flags);
            var flags_ = (GISharp.Lib.Gtk.DebugFlags)flags;
            gtk_set_debug_flags(flags_);
        }

        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType gtk_debug_flags_get_type();
    }
}