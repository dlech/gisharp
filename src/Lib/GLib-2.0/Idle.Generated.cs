// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Idle.xmldoc" path="declaration/member[@name='Idle']/*" />
    public static unsafe partial class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns %FALSE it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle the return value and memory management of @data.
        /// </para>
        /// <para>
        /// This internally creates a main loop source using g_idle_source_new()
        /// and attaches it to the global #GMainContext using g_source_attach(), so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// </para>
        /// </remarks>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        ///            range between #G_PRIORITY_DEFAULT_IDLE and #G_PRIORITY_HIGH_IDLE.
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint g_idle_add_full(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int priority,
        /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
        /* transfer-ownership:none scope:notified closure:2 destroy:3 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Runtime.Boolean> function,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> notify);
        static partial void CheckAddArgs(GISharp.Lib.GLib.SourceFunc function, int priority = GISharp.Lib.GLib.Priority.DefaultIdle);

        /// <include file="Idle.xmldoc" path="declaration/member[@name='Idle.Add(GISharp.Lib.GLib.SourceFunc,int)']/*" />
        public static uint Add(GISharp.Lib.GLib.SourceFunc function, int priority = GISharp.Lib.GLib.Priority.DefaultIdle)
        {
            CheckAddArgs(function, priority);
            var function_ = (delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Runtime.Boolean>)&GISharp.Lib.GLib.SourceFuncMarshal.Callback;
            var functionHandle = System.Runtime.InteropServices.GCHandle.Alloc((function, GISharp.Runtime.CallbackScope.Notified));
            var data_ = (System.IntPtr)functionHandle;
            var notify_ = (delegate* unmanaged[Cdecl]<System.IntPtr, void>)&GISharp.Runtime.GMarshal.DestroyGCHandle;
            var priority_ = (int)priority;
            var ret_ = g_idle_add_full(priority_,function_,data_,notify_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (uint)ret_;
            return ret;
        }

        /// <summary>
        /// Removes the idle function with the given data.
        /// </summary>
        /// <param name="data">
        /// the data for the idle source's callback.
        /// </param>
        /// <returns>
        /// %TRUE if an idle source was found and removed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_idle_remove_by_data(
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data);
        static partial void CheckRemoveByDataArgs(System.IntPtr data);

        /// <include file="Idle.xmldoc" path="declaration/member[@name='Idle.RemoveByData(System.IntPtr)']/*" />
        public static bool RemoveByData(System.IntPtr data)
        {
            CheckRemoveByDataArgs(data);
            var data_ = (System.IntPtr)data;
            var ret_ = g_idle_remove_by_data(data_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}