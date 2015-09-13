using System;

namespace GISharp.Core
{
    /// <summary>
    /// Wrapper for an opaque struct that is "owned".
    /// </summary>
    /// <remarks>>
    /// "Owned" means that it is not reference counted. It has Copy and Free
    /// methods.
    /// </remarks>
    public abstract class OwnedOpaque<T> : IWrappedNative, IDisposable where T : OwnedOpaque<T>
    {
        protected bool Disposed;

        public IntPtr Handle { get; protected set; }

        public bool Owned { get; internal set; }

        protected OwnedOpaque (IntPtr handle)
        {
            Handle = handle;
        }

        ~OwnedOpaque ()
        {
            Dispose (false);
        }

        public virtual T Copy ()
        {
            throw new NotImplementedException ();
        }

        protected abstract void Free ();

        public void Dispose ()
        {
            Dispose (true);
        }

        protected void Dispose (bool disposing)
        {
            if (Disposed) {
                return;
            }
            if (Owned) {
                Free ();
            }
            Disposed = true;
        }

        protected void AssertNotDisposed ()
        {
            if (Disposed) {
                throw new ObjectDisposedException ("OwnedOpaque");
            }
        }
    }
}
