using System;

namespace GISharp.Core
{
    /// <summary>
    /// Base class for reference counted opaque structs
    /// </summary>
    public abstract class ReferenceCountedOpaque<T>
        : Opaque, IDisposable where T : ReferenceCountedOpaque<T>
    {
        /// <summary>
        /// Inrease the reference count of a reference counted object.
        /// </summary>
        /// <remarks>
        /// Types that are reference counted must override this method.
        /// Has no effect for other types.
        /// </remarks>
        internal protected abstract void Ref ();

        /// <summary>
        /// Decrease the reference count of a reference counted object.
        /// </summary>
        /// <remarks>
        /// Types that are reference counted must override this method.
        /// Has no effect for other types.
        /// </remarks>
        internal protected abstract void Unref ();

        public override bool Equals (object obj)
        {
            AssertNotDisposed ();
            var otherOpaque = obj as ReferenceCountedOpaque<T>;
            if (otherOpaque != null) {
                return Handle == otherOpaque.Handle;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            AssertNotDisposed ();
            return Handle.GetHashCode ();
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed) {
                Unref ();
            }
            base.Dispose (disposing);
        }
    }
}
