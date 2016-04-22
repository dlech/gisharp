using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Wrapper for an opaque struct that is "owned".
    /// </summary>
    /// <remarks>>
    /// "Owned" means that it is not reference counted. It has a Free method.
    /// </remarks>
    public abstract class OwnedOpaque : Opaque, IDisposable
    {
        public bool Owned { get; protected set; }

        protected OwnedOpaque (IntPtr handle, Transfer ownership)
        {
            if (ownership == Transfer.Container) {
                throw new NotSupportedException ();
            }
            Handle = handle;
            if (ownership != Transfer.None) {
                Owned = true;
            }
        }

        ~OwnedOpaque ()
        {
            Dispose (false);
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
