// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// <see cref="Source"/> that runs when the event loop is idle.
    /// </summary>
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

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IdleSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        public void SetCallback(SourceFunc func)
        {
            SetCallback(func, SourceFuncMarshal.ToUnmanagedFunctionPointer);
        }
    }
}
