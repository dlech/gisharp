using System;

namespace GISharp.Core
{
    /// <summary>
    /// Base class for reference counted opaque structs
    /// </summary>
    public abstract class ReferenceCountedOpaque<T> : IWrappedNative, IDisposable where T : ReferenceCountedOpaque<T>
    {
        bool isDisposed;

        /// <summary>
        /// Gets the pointer to the unmanaged GLib struct.
        /// </summary>
        /// <value>The pointer.</value>
        public IntPtr Handle { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceCountedOpaque"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        /// <remarks>
        /// This is indened for use by bindings. You should normally call
        /// <see cref="MarshalG.PtrToReferenceCountedOpaque"/> instead.
        protected ReferenceCountedOpaque (IntPtr handle)
        {
            Handle = handle;
        }

        ~ReferenceCountedOpaque ()
        {
            Dispose (false);
        }

        /// <summary>
        /// Releases all resource used by the <see cref="Opaque"/> object.
        /// </summary>
        /// <remarks>
        /// Call <see cref="Dispose"/> when you are finished using the <see cref="Opaque"/>. The <see cref="Dispose"/>
        /// method leaves the <see cref="Opaque"/> in an unusable state. After calling <see cref="Dispose"/>, you must
        /// release all references to the <see cref="Opaque"/> so the garbage collector can reclaim the memory that the
        /// <see cref="Opaque"/> was occupying.
        ///
        /// For reference counted unmanaged types, the unmanged object will be unrefed.
        /// If the unmanaged object has a free function and we owned the object, the
        /// unmanaged object will be freed.
        /// </remarks>
        public void Dispose ()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if (isDisposed) {
                return;
            }
            isDisposed = true;
            if (Handle != IntPtr.Zero) {
                Unref ();
                Handle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Assert that the object has not been disposed.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if this object has already been disposed.</exception>
        /// <remarks>
        /// All public methods should call this so we don't operate on a disposed object.
        /// </remarks>
        protected void AssertNotDisposed ()
        {
            if (isDisposed) {
                throw new ObjectDisposedException (GetType ().Name);
            }
        }

        /// <summary>
        /// Inrease the reference count of a reference counted object.
        /// </summary>
        /// <remarks>
        /// Types that are reference counted must override this method.
        /// Has no effect for other types.
        /// </remarks>
        public abstract void Ref ();

        /// <summary>
        /// Decrease the reference count of a reference counted object.
        /// </summary>
        /// <remarks>
        /// Types that are reference counted must override this method.
        /// Has no effect for other types.
        /// </remarks>
        public abstract void Unref ();

        public override bool Equals (object obj)
        {
            var otherOpaque = obj as ReferenceCountedOpaque<T>;
            if (otherOpaque != null) {
                return Handle == otherOpaque.Handle;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            return Handle.GetHashCode ();
        }
    }
}
