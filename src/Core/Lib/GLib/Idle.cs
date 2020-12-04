
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Functions for creating and adding <see cref="IdleSource"/>s.
    /// </summary>
    public static class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle the return value and memory management of @data.
        ///
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the global #MainContext using g_source_attach(), so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// </remarks>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        /// range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the idle is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_idle_add_full(
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:2 destroy:3 */
            IntPtr function,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:async */
            IntPtr notify);

        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns <c>false</c> it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using <see cref="IdleSource()"/>
        /// and attaches it to the global <see cref="MainContext"/> using <see cref="Source.Attach"/>, so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        /// range between <see cref="Priority.DefaultIdle"/> and <see cref="Priority.HighIdle"/>.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source and a <see cref="Source.UserData" />
        /// handle.
        /// </returns>
        public static (uint id, Source.UserData userData) Add(SourceFunc function, int priority = Priority.DefaultIdle)
        {
            var (function_, notify_, data_) = SourceFuncMarshal.ToUnmanagedFunctionPointer(function, CallbackScope.Notified);
            var ret = g_idle_add_full(priority, function_, data_, notify_);
            var userData = new Source.UserData(data_);
            return (ret, userData);
        }
    }
}
