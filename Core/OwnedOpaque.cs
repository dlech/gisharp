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
    public abstract class OwnedOpaque<T> : Opaque, IDisposable where T : OwnedOpaque<T>
    {
        public bool Owned { get; internal set; }

        ~OwnedOpaque ()
        {
            Dispose (false);
        }

        public virtual T Copy ()
        {
            throw new NotImplementedException ();
        }

        protected abstract void Free ();

        protected override void Dispose (bool disposing)
        {
            if (!IsDisposed) {
                if (Owned) {
                    Free ();
                }
            }
            base.Dispose (disposing);
        }
    }
}
