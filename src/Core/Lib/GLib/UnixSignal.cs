// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Functions for creating and attaching <see cref="UnixSignalSource"/>s.
    /// </summary>
    public static class UnixSignal
    {
        const int SIGHUP = 1;
        const int SIGINT = 2;
        const int SIGQUIT = 3;

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
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_unix_signal_add_full(
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int signum,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            IntPtr handler,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            IntPtr notify);

        /// <summary>
        /// A convenience function for <see cref="UnixSignalSource(int)"/>, which
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
        /// An ID (greater than 0) for the event source and a <see cref="Source.UserData" />
        /// handle.
        /// </returns>
        [Since("2.30")]
        public static (uint id, Source.UserData userData) Add(int signum, SourceFunc handler, int priority = Priority.Default)
        {
            if (signum != SIGHUP && signum != SIGINT && signum != SIGQUIT) {
                throw new ArgumentException("Only SIGHUP, SIGINT, SIGQUIT allowed", nameof(signum));
            }
            // TODO: add check for SIGUSR1, SIGUSR2, SIGWINCH based on runtime version
            var (handler_, notify_, userData_) = SourceFuncMarshal.ToUnmanagedFunctionPointer(handler, CallbackScope.Notified);
            var ret = g_unix_signal_add_full(priority, signum, handler_, userData_, notify_);
            var sourceHandle = new Source.UserData(userData_);
            return (ret, sourceHandle);
        }
    }
}
