

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    public sealed class TimeoutSource : Source
    {
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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_timeout_source_new(
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
        static IntPtr New(uint interval)
        {
            var ret = g_timeout_source_new(interval);
            return ret;
        }

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
        public TimeoutSource(uint interval) : this(New(interval), Transfer.Full)
        {
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
        [Since("2.14")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_timeout_source_new_seconds(
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
        [Since("2.14")]
        public static IntPtr NewSeconds(uint interval)
        {
            var ret = g_timeout_source_new_seconds(interval);
            return ret;
        }

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
        public static TimeoutSource Seconds(uint interval)
        {
            var ret_ = NewSeconds(interval);
            var ret = new TimeoutSource(ret_, Transfer.Full);
            return ret;
        }

        public TimeoutSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public void SetCallback(SourceFunc func)
        {
            SetCallback<SourceFunc, UnmanagedSourceFunc>(func, UnmanagedSourceFuncFactory.Create);
        }
    }
}
