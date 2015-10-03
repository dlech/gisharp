using System;
using System.Collections.Generic;

namespace GISharp.Core
{
    /// <summary>
    /// Base class for reference counted opaque structs
    /// </summary>
    public abstract class ReferenceCountedOpaque
        : Opaque, IDisposable
    {
        static Dictionary<IntPtr, WeakReference> objectMap = new Dictionary<IntPtr, WeakReference> ();
        static object lockObj = new object ();

        protected ReferenceCountedOpaque (IntPtr handle, Transfer ownership)
        {
            if (handle == IntPtr.Zero) {
                throw new NotSupportedException ();
            }
            if (ownership == Transfer.Container) {
                throw new NotSupportedException ();
            }
            Handle = handle;
            lock (lockObj) {
                    objectMap.Add (handle, new WeakReference (this));
                    if (ownership == Transfer.None) {
                        Ref ();
                    }
            }
        }

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

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed) {
                lock (lockObj) {
                    objectMap.Remove (Handle);
                    Unref ();
                }
            }
            base.Dispose (disposing);
        }

        public static T TryGetExisting<T> (IntPtr handle) where T : ReferenceCountedOpaque
        {
            return TryGetExisting (handle) as T;
        }

        public static ReferenceCountedOpaque TryGetExisting (IntPtr handle)
        {
            lock (lockObj) {
                WeakReference weakRef;
                if (objectMap.TryGetValue (handle, out weakRef)) {
                    if (weakRef.IsAlive) {
                        return weakRef.Target as ReferenceCountedOpaque;
                    }
                }
            }
            return null;
        }
    }
}
