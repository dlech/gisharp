using System;
using System.Threading;

namespace GISharp.GLib
{
    public partial class MainLoop
    {
        /// <summary>
        /// Runs a main loop until <see cref="Quit"/> is called on the loop.
        /// If this is called for the thread of the loop's <see cref="MainContext"/>
        /// it will process events from the loop, otherwise it will simply wait.
        /// </summary>
        public void Run()
        {
            AssertNotDisposed();
            var oldSyncContext = SynchronizationContext.Current;
            try {
                var newSyncContext = new MainLoopSyncronizationContext (Context);
                SynchronizationContext.SetSynchronizationContext (newSyncContext);
                g_main_loop_run(Handle);
            } finally {
                SynchronizationContext.SetSynchronizationContext (oldSyncContext);
            }
        }
    }

    class MainLoopSyncronizationContext : SynchronizationContext
    {
        MainContext context;

        public MainLoopSyncronizationContext (MainContext context = null)
        {
            this.context = context ?? MainContext.Default;
        }

        public override SynchronizationContext CreateCopy ()
        {
            return new MainLoopSyncronizationContext (context);
        }

        public override void Post (SendOrPostCallback d, object state)
        {
            var source = Idle.CreateSource ();
            source.SetCallback (() => {
                d.Invoke (state);
                return Source.Remove;
            });
            source.Attach (context);
        }

        public override void Send (SendOrPostCallback d, object state)
        {
            context.Invoke (() => {
                d.Invoke (state);
                return Source.Remove;
            });
        }
    }
}
