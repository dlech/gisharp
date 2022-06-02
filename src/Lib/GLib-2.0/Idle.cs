// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Idle
    {
        /// <summary>
        /// Adds a function to be called whenever there are no higher priority
        /// events pending.  If the function returns <c>false</c> it is automatically
        /// removed from the list of event sources and will not be called again.
        /// </summary>
        /// <remarks>
        /// This internally creates a main loop source using <see cref="IdleSource.New()"/>
        /// and attaches it to the global <see cref="MainContext"/> using <see cref="Source.Attach"/>, so
        /// the callback will be invoked in whichever thread is running that main
        /// context. You can do these steps manually if you need greater control or to
        /// use a custom main context.
        /// </remarks>
        /// <param name="function">
        /// function to call
        /// </param>
        /// <param name="data">
        /// handle that can be used to remove the source with <see cref="RemoveByData"/>
        /// </param>
        /// <param name="priority">
        /// the priority of the idle source. Typically this will be in the
        /// range between <see cref="Priority.DefaultIdle"/> and <see cref="Priority.HighIdle"/>.
        /// </param>
        public static void Add(SourceFunc function, out IntPtr data, int priority = Priority.DefaultIdle)
        {
            var function_ = (delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean>)&SourceFuncMarshal.Callback;
            var functionHandle = GCHandle.Alloc((function, CallbackScope.Notified));
            data = (IntPtr)functionHandle;
            var notify_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
            _ = g_idle_add_full(priority, function_, data, notify_);
            GMarshal.PopUnhandledException();
        }
    }
}
