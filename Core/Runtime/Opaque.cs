using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base type for wrapping unmanged pointers
    /// </summary>
    public abstract class Opaque : IDisposable
    {
        static Dictionary<IntPtr, WeakReference<Opaque>> instanceMap =
            new Dictionary<IntPtr, WeakReference<Opaque>> ();
        static object instanceMapLock = new object ();
        
        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public SafeHandle Handle { get; protected set; }

        protected Opaque (SafeHandle handle)
        {
            lock (instanceMapLock) {
                instanceMap.Add (handle.DangerousGetHandle (), new WeakReference<Opaque> (this));
                Handle = handle;
            }
        }

        /// <summary>
        /// Releases all resource used by the <see cref="Opaque"/> object.
        /// </summary>
        /// <remarks>
        /// Call <see cref="Dispose()"/> when you are finished using the <see cref="Opaque"/>. The <see cref="Dispose()"/>
        /// method leaves the <see cref="Opaque"/> in an unusable state. After calling <see cref="Dispose()"/>, you must
        /// release all references to the <see cref="Opaque"/> so the garbage collector can reclaim the memory that the
        /// <see cref="Opaque"/> was occupying.
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
            if (disposing) {
                Handle.Dispose ();
            }
        }

        protected void AssertNotDisposed ()
        {
            if (Handle.IsClosed) {
                throw new ObjectDisposedException (null);
            }
        }

        public static T TryGetExisting<T> (IntPtr handle) where T : Opaque
        {
            lock (instanceMapLock) {
                WeakReference<Opaque> value;
                if (instanceMap.TryGetValue (handle, out value)) {
                    Opaque instance;
                    if (value.TryGetTarget (out instance)) {
                        if (!instance.Handle.IsClosed) {
                            return (T)instance;
                        }
                    }
                }
                return null;
            }
        }

        public static T GetInstance<T> (IntPtr handle, Transfer ownership, Type typeHint = null) where T : Opaque
        {
            if (handle == IntPtr.Zero) {
                return null;
            }
            lock (instanceMapLock) {
                var instance = TryGetExisting<T> (handle);
                if (instance != null) {
                    return instance;
                }
                throw new NotImplementedException ();
            }
        }
    }

    public static class OpaqueExtensions
    {
        public static Type GetHandleType (this Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            var typeInfo = type.GetTypeInfo ();
            if (!typeof(Opaque).GetTypeInfo ().IsAssignableFrom (typeInfo)) {
                var msg = $"Type must inherit from {nameof (Opaque)}";
                throw new ArgumentException (msg, nameof (type));
            }
            var propInfo = typeInfo.GetProperty (nameof (Opaque.Handle));
            return propInfo.PropertyType;
        }
    }
}
