// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond']/*" />
    public unsafe partial struct Cond
    {
#pragma warning disable CS0169, CS0649
        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.P']/*" />
        public readonly System.IntPtr P;

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.I']/*" />
        public fixed System.UInt32 I[2];
#pragma warning restore CS0169, CS0649
        /// <summary>
        /// If threads are waiting for @cond, all of them are unblocked.
        /// If no threads are waiting for @cond, this function has no effect.
        /// It is good practice to lock the same mutex as the waiting threads
        /// while calling this function, though not required.
        /// </summary>
        /// <param name="cond">
        /// a #GCond
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_cond_broadcast(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond);
        partial void CheckBroadcastArgs();

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.Broadcast()']/*" />
        public void Broadcast()
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckBroadcastArgs();
                var cond_ = this_;
                g_cond_broadcast(cond_);
            }
        }

        /// <summary>
        /// Frees the resources allocated to a #GCond with g_cond_init().
        /// </summary>
        /// <remarks>
        /// This function should not be used with a #GCond that has been
        /// statically allocated.
        /// 
        /// Calling g_cond_clear() for a #GCond on which threads are
        /// blocking leads to undefined behaviour.
        /// </remarks>
        /// <param name="cond">
        /// an initialised #GCond
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_cond_clear(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond);
        partial void CheckClearArgs();

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.Clear()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public void Clear()
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckClearArgs();
                var cond_ = this_;
                g_cond_clear(cond_);
            }
        }

        /// <summary>
        /// Initialises a #GCond so that it can be used.
        /// </summary>
        /// <remarks>
        /// This function is useful to initialise a #GCond that has been
        /// allocated as part of a larger structure.  It is not necessary to
        /// initialise a #GCond that has been statically allocated.
        /// 
        /// To undo the effect of g_cond_init() when a #GCond is no longer
        /// needed, use g_cond_clear().
        /// 
        /// Calling g_cond_init() on an already-initialised #GCond leads
        /// to undefined behaviour.
        /// </remarks>
        /// <param name="cond">
        /// an uninitialized #GCond
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_cond_init(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond);
        partial void CheckInitArgs();

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.Init()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public void Init()
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckInitArgs();
                var cond_ = this_;
                g_cond_init(cond_);
            }
        }

        /// <summary>
        /// If threads are waiting for @cond, at least one of them is unblocked.
        /// If no threads are waiting for @cond, this function has no effect.
        /// It is good practice to hold the same lock as the waiting thread
        /// while calling this function, though not required.
        /// </summary>
        /// <param name="cond">
        /// a #GCond
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_cond_signal(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond);
        partial void CheckSignalArgs();

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.Signal()']/*" />
        public void Signal()
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckSignalArgs();
                var cond_ = this_;
                g_cond_signal(cond_);
            }
        }

        /// <summary>
        /// Atomically releases @mutex and waits until @cond is signalled.
        /// When this function returns, @mutex is locked again and owned by the
        /// calling thread.
        /// </summary>
        /// <remarks>
        /// When using condition variables, it is possible that a spurious wakeup
        /// may occur (ie: g_cond_wait() returns even though g_cond_signal() was
        /// not called).  It's also possible that a stolen wakeup may occur.
        /// This is when g_cond_signal() is called, but another thread acquires
        /// @mutex before this thread and modifies the state of the program in
        /// such a way that when g_cond_wait() is able to return, the expected
        /// condition is no longer met.
        /// 
        /// For this reason, g_cond_wait() must always be used in a loop.  See
        /// the documentation for #GCond for a complete example.
        /// </remarks>
        /// <param name="cond">
        /// a #GCond
        /// </param>
        /// <param name="mutex">
        /// a #GMutex that is currently locked
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_cond_wait(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond,
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex);
        partial void CheckWaitArgs(GISharp.Lib.GLib.Mutex mutex);

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.Wait(GISharp.Lib.GLib.Mutex)']/*" />
        public void Wait(GISharp.Lib.GLib.Mutex mutex)
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckWaitArgs(mutex);
                var cond_ = this_;
                var mutex_ = &mutex;
                g_cond_wait(cond_, mutex_);
            }
        }

        /// <summary>
        /// Waits until either @cond is signalled or @end_time has passed.
        /// </summary>
        /// <remarks>
        /// As with g_cond_wait() it is possible that a spurious or stolen wakeup
        /// could occur.  For that reason, waiting on a condition variable should
        /// always be in a loop, based on an explicitly-checked predicate.
        /// 
        /// %TRUE is returned if the condition variable was signalled (or in the
        /// case of a spurious wakeup).  %FALSE is returned if @end_time has
        /// passed.
        /// 
        /// The following code shows how to correctly perform a timed wait on a
        /// condition variable (extending the example presented in the
        /// documentation for #GCond):
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// gpointer
        /// pop_data_timed (void)
        /// {
        ///   gint64 end_time;
        ///   gpointer data;
        /// 
        ///   g_mutex_lock (&amp;data_mutex);
        /// 
        ///   end_time = g_get_monotonic_time () + 5 * G_TIME_SPAN_SECOND;
        ///   while (!current_data)
        ///     if (!g_cond_wait_until (&amp;data_cond, &amp;data_mutex, end_time))
        ///       {
        ///         // timeout has passed.
        ///         g_mutex_unlock (&amp;data_mutex);
        ///         return NULL;
        ///       }
        /// 
        ///   // there is data for us
        ///   data = current_data;
        ///   current_data = NULL;
        /// 
        ///   g_mutex_unlock (&amp;data_mutex);
        /// 
        ///   return data;
        /// }
        /// ]|
        /// 
        /// Notice that the end time is calculated once, before entering the
        /// loop and reused.  This is the motivation behind the use of absolute
        /// time on this API -- if a relative time of 5 seconds were passed
        /// directly to the call and a spurious wakeup occurred, the program would
        /// have to start over waiting again (which would lead to a total wait
        /// time of more than 5 seconds).
        /// </remarks>
        /// <param name="cond">
        /// a #GCond
        /// </param>
        /// <param name="mutex">
        /// a #GMutex that is currently locked
        /// </param>
        /// <param name="endTime">
        /// the monotonic time to wait until
        /// </param>
        /// <returns>
        /// %TRUE on a signal, %FALSE on a timeout
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_cond_wait_until(
        /* <type name="Cond" type="GCond*" managed-name="Cond" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Cond* cond,
        /* <type name="Mutex" type="GMutex*" managed-name="Mutex" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Mutex* mutex,
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 endTime);
        partial void CheckWaitUntilArgs(GISharp.Lib.GLib.Mutex mutex, System.Int64 endTime);

        /// <include file="Cond.xmldoc" path="declaration/member[@name='Cond.WaitUntil(GISharp.Lib.GLib.Mutex,System.Int64)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public System.Boolean WaitUntil(GISharp.Lib.GLib.Mutex mutex, System.Int64 endTime)
        {
            fixed (GISharp.Lib.GLib.Cond* this_ = &this)
            {
                CheckWaitUntilArgs(mutex, endTime);
                var cond_ = this_;
                var mutex_ = &mutex;
                var endTime_ = (System.Int64)endTime;
                var ret_ = g_cond_wait_until(cond_,mutex_,endTime_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }
        }
    }
}