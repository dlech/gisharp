namespace GISharp.Lib.Gio
{
    public sealed partial class CancellableSource : GISharp.Lib.GLib.Source
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CancellableSource(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_cancellable_source_new(
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable);

        /// <summary>
        /// Creates a source that triggers if <paramref name="cancellable"/> is cancelled and
        /// calls its callback of type <see cref="CancellableSourceFunc"/>. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a <c>null</c> <see cref="Cancellable"/>,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the <see cref="Cancellable"/>.
        /// </remarks>
        /// <param name="cancellable">
        /// a <see cref="Cancellable"/>, or <c>null</c>
        /// </param>
        /// <returns>
        /// the new #GSource.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        static unsafe System.IntPtr New(GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_cancellable_source_new(cancellable_);
            return ret_;
        }

        /// <summary>
        /// Creates a source that triggers if <paramref name="cancellable"/> is cancelled and
        /// calls its callback of type <see cref="CancellableSourceFunc"/>. This is
        /// primarily useful for attaching to another (non-cancellable) source
        /// with g_source_add_child_source() to add cancellability to it.
        /// </summary>
        /// <remarks>
        /// For convenience, you can call this with a <c>null</c> <see cref="Cancellable"/>,
        /// in which case the source will never trigger.
        /// 
        /// The new #GSource will hold a reference to the <see cref="Cancellable"/>.
        /// </remarks>
        /// <param name="cancellable">
        /// a <see cref="Cancellable"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        public CancellableSource(GISharp.Lib.Gio.Cancellable cancellable = null) : this(New(cancellable), GISharp.Runtime.Transfer.Full)
        {
        }
    }
}