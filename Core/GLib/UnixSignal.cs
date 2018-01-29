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
        /// A convenience function for <see cref="CreateSource"/>, which
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
            var (handler_, notify_, userData_) = UnmanagedSourceFuncFactory.CreateNotifyDelegate (handler);
            var ret = g_unix_signal_add_full (priority, signum, handler_, userData_, notify_);
            return ret;
        }

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [Since ("2.30")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_unix_signal_source_new (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int signum);

        /// <summary>
        /// Create a <see cref="Source"/> that will be dispatched upon delivery of the UNIX
        /// signal <paramref name="signum"/>.  In GLib versions before 2.36, only <c>SIGHUP</c>, <c>SIGINT</c>,
        /// <c>SIGTERM</c> can be monitored.  In GLib 2.36, <c>SIGUSR1</c> and <c>SIGUSR2</c>
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked <see cref="CreateSource"/>.
        /// 
        /// For example, an effective use of this function is to handle <c>SIGTERM</c>
        /// cleanly; flushing any outstanding files, and then calling
        /// <see cref="MainLoop.Quit"/>.  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created <see cref="Source"/>
        /// </returns>
        [Since ("2.30")]
        public static Source CreateSource (int signum)
        {
            var ret_ = g_unix_signal_source_new (signum);
            var ret = Opaque.GetInstance<Source> (ret_, Transfer.Full);
            return ret;
        }
    }
}
