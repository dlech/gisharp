using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    public static class UnixSignal
    {
        /// <summary>
        /// A convenience function for g_unix_signal_source_new(), which
        /// attaches to the default #GMainContext.  You can remove the watch
        /// using g_source_remove().
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <param name="userData">
        /// Data for @handler
        /// </param>
        /// <param name="notify">
        /// #GDestroyNotify for @handler
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [Since ("2.30")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_unix_signal_add_full (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int signum,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            UnmanagedSourceFunc handler,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify notify);

        /// <summary>
        /// A convenience function for <see cref="UnixSignalSource.#ctor"/>, which
        /// attaches to the default <see cref="MainContext"/>.  You can remove the watch
        /// using <see cref="Source.Remove"/>.
        /// </summary>
        /// <param name="priority">
        /// the priority of the signal source. Typically this will be in
        /// the range between <see cref="Priority.Default"/> and <see cref="Priority.High"/>.
        /// </param>
        /// <param name="signum">
        /// Signal number
        /// </param>
        /// <param name="handler">
        /// Callback
        /// </param>
        /// <returns>
        /// An ID (greater than 0) for the event source
        /// </returns>
        [Since ("2.30")]
        public static uint Add (int priority, int signum, SourceFunc handler)
        {
            if (handler == null) {
                throw new ArgumentNullException (nameof(handler));
            }
            var (handler_, notify_, userData_) = SourceFuncFactory.Create(handler, CallbackScope.Notified);
            var ret = g_unix_signal_add_full (priority, signum, handler_, userData_, notify_);
            return ret;
        }
    }
}
