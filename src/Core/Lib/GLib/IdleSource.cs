// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// <see cref="Source"/> that runs when the event loop is idle.
    /// </summary>
    internal sealed unsafe class IdleSource : Source
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
        static extern UnmanagedStruct* g_idle_source_new();

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
        static UnmanagedStruct* New()
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
        internal IdleSource() : this((IntPtr)New(), Transfer.Full)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal IdleSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }
    }
}
