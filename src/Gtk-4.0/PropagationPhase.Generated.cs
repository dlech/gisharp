// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="PropagationPhase.xmldoc" path="declaration/member[@name='PropagationPhase']/*" />
    [GISharp.Runtime.GTypeAttribute("GtkPropagationPhase", IsProxyForUnmanagedType = true)]
    public enum PropagationPhase
    {
        /// <include file="PropagationPhase.xmldoc" path="declaration/member[@name='PropagationPhase.None']/*" />
        None = 0,
        /// <include file="PropagationPhase.xmldoc" path="declaration/member[@name='PropagationPhase.Capture']/*" />
        Capture = 1,
        /// <include file="PropagationPhase.xmldoc" path="declaration/member[@name='PropagationPhase.Bubble']/*" />
        Bubble = 2,
        /// <include file="PropagationPhase.xmldoc" path="declaration/member[@name='PropagationPhase.Target']/*" />
        Target = 3
    }

    /// <summary>
    /// Extension methods for <see cref="PropagationPhase"/>.
    /// </summary>
    public static unsafe partial class PropagationPhaseExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = gtk_propagation_phase_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType gtk_propagation_phase_get_type();
    }
}