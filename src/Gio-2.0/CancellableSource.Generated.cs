// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="CancellableSource.xmldoc" path="declaration/member[@name='CancellableSource']/*" />
    public sealed unsafe partial class CancellableSource : GISharp.Lib.GLib.Source
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CancellableSource(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        static partial void CheckNewArgs(GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Creates a source that triggers if @cancellable is cancelled and
        /// calls its callback of type #GCancellableSourceFunc. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a %NULL #GCancellable,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the #GCancellable.
        /// </remarks>
        /// <param name="cancellable">
        /// a #GCancellable, or %NULL
        /// </param>
        /// <returns>
        /// the new #GSource.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Source" type="GSource*" managed-name="GISharp.Lib.GLib.Source" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Source.UnmanagedStruct* g_cancellable_source_new(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable);

        [GISharp.Runtime.SinceAttribute("2.28")]
        static GISharp.Lib.GLib.Source.UnmanagedStruct* New(GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckNewArgs(cancellable);
            var cancellable_ = (GISharp.Lib.Gio.Cancellable.UnmanagedStruct*)(cancellable?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_cancellable_source_new(cancellable_);
            return ret_;
        }

        /// <include file="CancellableSource.xmldoc" path="declaration/member[@name='CancellableSource.CancellableSource(GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public CancellableSource(GISharp.Lib.Gio.Cancellable? cancellable = null) : this((System.IntPtr)New(cancellable), GISharp.Runtime.Transfer.Full)
        {
        }
    }
}