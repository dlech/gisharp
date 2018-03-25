
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    public sealed class IdleSource : Source
    {
        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_idle_source_new();

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed. Note that the default priority for idle sources is
        /// <see cref="Priority.DefaultIdle"/>, as compared to other sources which
        /// have a default priority of <see cref="Priority.Default"/>.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        static IntPtr New()
        {
            var ret = g_idle_source_new();
            return ret;
        }

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed. Note that the default priority for idle sources is
        /// <see cref="Priority.DefaultIdle"/>, as compared to other sources which
        /// have a default priority of <see cref="Priority.Default"/>.
        /// </remarks>
        public IdleSource() : this(New(), Transfer.Full)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IdleSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public void SetCallback(SourceFunc func)
        {
            SetCallback<SourceFunc, UnmanagedSourceFunc>(func, SourceFuncFactory.Create);
        }
    }
}
