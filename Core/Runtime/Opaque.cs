using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// Managed objects that wrap a unmanaged GLib data structures must implement this.
    /// </summary>
    public abstract class Opaque : IDisposable
    {
        protected bool IsDisposed;

        IntPtr _Handle;
        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public IntPtr Handle { 
            get {
                AssertNotDisposed ();
                return _Handle;
            }
            protected set {
                _Handle = value;
            }
        }

        static bool GetNullHandleIsInstance<T> () {
            return GetNullHandleIsInstance (typeof(T));
        }

        static bool GetNullHandleIsInstance (Type type) {
            var attr = type.GetCustomAttribute <NullHandleIsInstanceAttribute> ();
            return attr != null;
        }

        ~Opaque ()
        {
            Dispose (false);
        }

        /// <summary>
        /// Releases all resource used by the <see cref="Opaque"/> object.
        /// </summary>
        /// <remarks>
        /// Call <see cref="Dispose()"/> when you are finished using the <see cref="Opaque"/>. The <see cref="Dispose()"/>
        /// method leaves the <see cref="Opaque"/> in an unusable state. After calling <see cref="Dispose()"/>, you must
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

        /// <summary>
        /// Dispose the specified disposing.
        /// </summary>
        /// <param name="disposing"><c>true</c> if called from the <see cref="Dispose()"/> method,
        /// <c>false</c> if called from a finalizer.</param>
        protected virtual void Dispose (bool disposing)
        {
            IsDisposed = true;
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
            if (IsDisposed) {
                throw new ObjectDisposedException (GetType ().Name);
            }
        }

        static object getInstanceLock = new object ();

        public static T GetInstance<T> (IntPtr handle, Transfer ownership, Type typeHint = null) where T : Opaque
        {
            if (handle == IntPtr.Zero && !GetNullHandleIsInstance<T> ()) {
                return null;
            }
            lock (getInstanceLock) {
                var obj = ReferenceCountedOpaque.TryGetExisting (handle) as T;
                if (obj != null) {
                    if (ownership != Transfer.None) {
                        // we already have a reference, so we don't need another one.
                        (obj as ReferenceCountedOpaque).Unref ();
                    }
                    return obj;
                }

                obj = (T)Activator.CreateInstance (typeHint ?? typeof (T),
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, new object[] { handle, ownership }, null);
                return obj;
            }
        }
    }

    public sealed class WrappedStruct<T> : OwnedOpaque where T : struct
    {
        public T Value {
            get {
                return Marshal.PtrToStructure<T> (Handle);
            }
            set {
                Marshal.StructureToPtr<T> (value, Handle, false);
            }
        }

        WrappedStruct (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public WrappedStruct () : this (GMarshal.Alloc (Marshal.SizeOf<T> ()), Transfer.All)
        {
        }

        public WrappedStruct (T value) : this ()
        {
            Value = value;
        }

        protected override void Free ()
        {
            GMarshal.Free (Handle);
        }
    }
}
