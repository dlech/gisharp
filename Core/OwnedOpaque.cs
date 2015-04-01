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
    public abstract class OwnedOpaque<T> : INativeObject, IDisposable where T : OwnedOpaque<T>
    {
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

        public abstract T Copy ();
        public abstract void Free ();

        public void Dispose ()
        {
            Dispose (true);
        }

        protected void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                if (Owned) {
                    Free ();
                }
                Handle = IntPtr.Zero;
            }
        }
    }
}
