
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    public static class Timeout
    {
        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// <c>false</c>, at which point the timeout is automatically destroyed and
        /// the function will not be called again.  The @notify function is
        /// called when the timeout is destroyed.  The first call to the
        /// function will be at the end of the first @interval.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle the return value and memory management of @data.
        /// 
        /// This internally creates a main loop source using g_timeout_source_new()
        /// and attaches it to the global #GMainContext using g_source_attach(), so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in milliseconds
        ///             (1/1000ths of a second)
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_timeout_add_full (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint interval,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            NativeSourceFunc function,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:async */
            NativeDestroyNotify notify);

        /// <summary>
        /// Sets a function to be called at regular intervals, with the given
        /// priority.  The function is called repeatedly until it returns
        /// <c>false</c>, at which point the timeout is automatically destroyed and
        /// the function will not be called again. The first call to the
        /// function will be at the end of the first <paramref name="interval"/>.
        /// </summary>
        /// <remarks>
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given interval
        /// (it does not try to 'catch up' time lost in delays).
        /// 
        /// This internally creates a main loop source using <see cref="CreateSource"/>
        /// and attaches it to the global <see cref="MainContext"/> using <see cref="Source.Attach"/>, so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// </remarks>
        /// <param name="interval">
        /// The time between calls to the function, in milliseconds
        /// (1/1000ths of a second).
        /// </param>
        /// <param name="function">
        /// Function to call.
        /// </param>
        /// <param name="priority">
        /// The priority of the timeout source. Typically this will be in
        /// the range between <see cref="Priority.Default"/> and <see cref="Priority.High"/>.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        public static uint Add (uint interval, SourceFunc function, int priority = Priority.Default)
        {
            if (function == null) {
                throw new ArgumentNullException (nameof(function));
            }
            var (function_, notify_, data_) = NativeSourceFuncFactory.CreateNotifyDelegate (function);
            var ret = g_timeout_add_full (priority, interval, function_, data_, notify_);
            return ret;
        }

        /// <summary>
        /// Sets a function to be called at regular intervals, with @priority.
        /// The function is called repeatedly until it returns <c>false</c>, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike g_timeout_add(), this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the @interval to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given @interval
        /// 
        /// See [memory management of sources][mainloop-memory-management] for details
        /// on how to handle the return value and memory management of @data.
        /// 
        /// If you want timing more precise than whole seconds, use g_timeout_add()
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of g_timeout_add_seconds() is preferred over g_timeout_add().
        /// 
        /// This internally creates a main loop source using
        /// g_timeout_source_new_seconds() and attaches it to the main loop context
        /// using g_source_attach(). You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        ///            the range between #G_PRIORITY_DEFAULT and #G_PRIORITY_HIGH.
        /// </param>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// data to pass to @function
        /// </param>
        /// <param name="notify">
        /// function to call when the timeout is removed, or %NULL
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [Since ("2.14")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_timeout_add_seconds_full (
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int priority,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint interval,
            /* <type name="SourceFunc" type="GSourceFunc" managed-name="SourceFunc" /> */
            /* transfer-ownership:none scope:notified closure:3 destroy:4 */
            NativeSourceFunc function,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 scope:async */
            NativeDestroyNotify notify);

        /// <summary>
        /// Sets a function to be called at regular intervals, with <paramref name="priority"/>.
        /// The function is called repeatedly until it returns <c>false</c>, at which
        /// point the timeout is automatically destroyed and the function will
        /// not be called again.
        /// </summary>
        /// <remarks>
        /// Unlike <see cref="Add"/>, this function operates at whole second granularity.
        /// The initial starting point of the timer is determined by the implementation
        /// and the implementation is expected to group multiple timers together so that
        /// they fire all at the same time.
        /// To allow this grouping, the <paramref name="interval"/> to the first timer is rounded
        /// and can deviate up to one second from the specified interval.
        /// Subsequent timer iterations will generally run at the specified interval.
        /// 
        /// Note that timeout functions may be delayed, due to the processing of other
        /// event sources. Thus they should not be relied on for precise timing.
        /// After each call to the timeout function, the time of the next
        /// timeout is recalculated based on the current time and the given <paramref name="interval"/>
        /// 
        /// If you want timing more precise than whole seconds, use <see cref="Add"/>
        /// instead.
        /// 
        /// The grouping of timers to fire at the same time results in a more power
        /// and CPU efficient behavior so if your timer is in multiples of seconds
        /// and you don't require the first timer exactly one second from now, the
        /// use of <see cref="AddSeconds"/> is preferred over <see cref="Add"/>.
        /// 
        /// This internally creates a main loop source using
        /// <see cref="CreateSourceSeconds"/> and attaches it to the main loop context
        /// using <see cref="Source.Attach"/>. You can do these steps manually if you need
        /// greater control.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.
        /// </remarks>
        /// <param name="interval">
        /// the time between calls to the function, in seconds
        /// </param>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="priority">
        /// the priority of the timeout source. Typically this will be in
        /// the range between <see cref="Priority.Default"/> and <see cref="Priority.High"/>.
        /// </param>
        /// <returns>
        /// the ID (greater than 0) of the event source.
        /// </returns>
        [Since ("2.14")]
        public static uint AddSeconds (uint interval, SourceFunc function, int priority = Priority.Default)
        {
            if (function == null) {
                throw new ArgumentNullException (nameof(function));
            }
            var (function_, notify_, data_) = NativeSourceFuncFactory.CreateNotifyDelegate (function);
            var ret = g_timeout_add_seconds_full (priority, interval, function_, data_, notify_);
            return ret;
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.  See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_timeout_source_new (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint interval);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed.
        /// 
        /// The interval given is in terms of monotonic time, not wall clock
        /// time.
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in milliseconds.
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        public static Source CreateSource (uint interval)
        {
            var ret_ = g_timeout_source_new (interval);
            var ret = Opaque.GetInstance<Source> (ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// See g_get_monotonic_time().
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [Since ("2.14")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_timeout_source_new_seconds (
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint interval);

        /// <summary>
        /// Creates a new timeout source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed.
        /// 
        /// The scheduling granularity/accuracy of this timeout source will be
        /// in seconds.
        /// 
        /// The interval given in terms of monotonic time, not wall clock time.
        /// </remarks>
        /// <param name="interval">
        /// the timeout interval in seconds
        /// </param>
        /// <returns>
        /// the newly-created timeout source
        /// </returns>
        [Since ("2.14")]
        public static Source CreateSourceSeconds (uint interval)
        {
            var ret_ = g_timeout_source_new_seconds (interval);
            var ret = Opaque.GetInstance<Source> (ret_, Transfer.Full);
            return ret;
        }
    }
}
