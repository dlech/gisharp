// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System.Threading;

namespace GISharp.Lib.GLib
{
    unsafe partial class MainLoop
    {
        /// <summary>
        /// Runs a main loop until <see cref="Quit"/> is called on the loop.
        /// If this is called for the thread of the loop's <see cref="MainContext"/>
        /// it will process events from the loop, otherwise it will simply wait.
        /// </summary>
        /// <remarks>
        /// This also has the effect of setting the <see cref="SynchronizationContext"/>
        /// so that .NET async works transparently with the <see cref="MainLoop"/>.
        /// </remarks>
        public void Run()
        {
            var loop_ = (UnmanagedStruct*)UnsafeHandle;
            var oldSyncContext = SynchronizationContext.Current;
            try {
                var newSyncContext = Context.SynchronizationContext;
                SynchronizationContext.SetSynchronizationContext(newSyncContext);
                g_main_loop_run(loop_);
            }
            finally {
                SynchronizationContext.SetSynchronizationContext(oldSyncContext);
            }
        }
    }
}
