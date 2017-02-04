using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Internal;

namespace GISharp.Runtime
{
    /// <summary>
    /// The base class for all GISharp SafeHandles. These are used to wrap
    /// unmanaged handles to ensure that they are properly released.
    /// </summary>
    public abstract class SafeOpaqueHandle : SafeHandle
    {
        readonly static ConcurrentBag<SafeOpaqueHandle> finalizedHandles;

        static SafeOpaqueHandle ()
        {
            finalizedHandles = new ConcurrentBag<SafeOpaqueHandle> ();
            GcNotification.Register (ReleaseFinalizedHandles, null);
        }

        // See notes in Dispose(bool). We can't run ReleaseHandle() in a
        // critical finalizer, so finalized handles are collected in
        // finalizedHandles and then this method is called when the garbage
        // collector runs. This method runs in the GC Finalizer Thread.
        static bool ReleaseFinalizedHandles (object state)
        {
            SafeOpaqueHandle handle;
            while (finalizedHandles.TryTake (out handle)) {
                try {
                    // Note: the handle object here may not be fully initalized
                    // (e.g. the constructor threw an exception). It should be
                    // safe to call Dispose() here anyway because it will do
                    // nothing if the handle is invalid, or will release it if
                    // the handle is valid, which is a good thing. On the other
                    // hand, if this turns out to cause problems, we should
                    // make a wrapper around base.Dispose(false) and call that
                    // instead.
                    handle.Dispose ();
                } catch (Exception ex) {
                    if (UnhandledFinalizerException != null) {
                        UnhandledFinalizerException (null, new UnhandledExceptionEventArgs (ex));
                    }
                }
            }
            return true;
        }

        public sealed class UnhandledExceptionEventArgs : EventArgs
        {
            public Exception Exception { get; private set; }

            public UnhandledExceptionEventArgs (Exception ex)
            {
                Exception = ex;
            }
        }

        /// <summary>
        /// Occurs when an exception is thrown during the release of a handle
        /// on the finalizer thread. This should be used for debugging only.
        /// </summary>
        static event EventHandler<UnhandledExceptionEventArgs> UnhandledFinalizerException;

        public override bool IsInvalid {
            get {
                return handle == IntPtr.Zero;
            }
        }

        protected SafeOpaqueHandle () : base (IntPtr.Zero, true)
        {
        }

        protected override void Dispose (bool disposing)
        {
            // This has the effect of preventing ReleaseHandle() from being
            // called from the finalizer thread. We don't want this to happen
            // because the finalizer is run in a Constrained Execution Region.
            // Many *_unref() functions can result in calling back to managed
            // code, which can cause crashes or other mayhem if this happens
            // in the critical execution region. So, we collect these handles
            // to be released later by other means. If a handle was flagged
            // as invalid, this method will not be called by the finalizer,
            // so we don't need to worry about releasing handles that we don't
            // actually own.
            if (disposing) {
                base.Dispose (true);
            } else {
                finalizedHandles.Add (this);
            }
        }
    }
}
