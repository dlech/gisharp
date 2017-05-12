using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using GISharp.GObject;
using System.Linq;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base type for wrapping unmanged pointers
    /// </summary>
    public abstract class Opaque : IDisposable
    {
        static readonly Dictionary<IntPtr, WeakReference<Opaque>> instanceMap;
        static readonly object instanceMapLock;

        static Opaque ()
        {
            instanceMap = new Dictionary<IntPtr, WeakReference<Opaque>> ();
            instanceMapLock = new object ();
        }

        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public SafeOpaqueHandle Handle { get; protected set; }

        protected Opaque (SafeOpaqueHandle handle)
        {
            lock (instanceMapLock) {
                Handle = handle;
                instanceMap.Add (handle.DangerousGetHandle (), new WeakReference<Opaque> (this));
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
            lock (instanceMapLock) {
                instanceMap.Remove (Handle.DangerousGetHandle ());
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
                if (instanceMap.TryGetValue (handle, out var value)) {
                    if (value.TryGetTarget (out var instance)) {
                        return (T)instance;
                    }
                    instanceMap.Remove (handle);
                }
                return null;
            }
        }

        public static T GetOrCreate<T> (SafeOpaqueHandle handle) where T : Opaque
        {
            var ptr = handle.DangerousGetHandle ();
            if (ptr == IntPtr.Zero) {
                return null;
            }
            lock (instanceMap) {
                var instance = TryGetExisting<T> (ptr);
                if (instance != null) {
                    handle.Dispose ();
                    return instance;
                }
                var type = handle.GetType ().DeclaringType;
                instance = (T)Activator.CreateInstance (type, handle);
                return instance;
            }
        }

        public static T GetOrCreate<T> (IntPtr handle, Transfer ownership) where T : Opaque
        {
            if (typeof (OpaqueInt).GetTypeInfo ().IsAssignableFrom (typeof (T))) {
                var ret = new OpaqueInt (handle.ToInt32 ());
                return (T)(object)ret;
            }
            if (handle == IntPtr.Zero) {
                return null;
            }
            lock (instanceMapLock) {
                var safeHandleType = typeof (T).GetSafeHandleType ();
                // FIXME: this could result in unnecessary copying if we already have an existing managed instance
                var safeHandle = (SafeOpaqueHandle)Activator.CreateInstance (safeHandleType, handle, ownership);
                var instance = TryGetExisting<T> (handle);
                if (instance != null) {
                    safeHandle.Dispose ();
                    return instance;
                }
                var type = typeof (T);
                if (typeof (TypeInstance).GetTypeInfo ().IsAssignableFrom (typeof (T))) {
                    var gtype = Marshal.PtrToStructure<GType> (Marshal.ReadIntPtr (handle));
                    type = GType.TypeOf (gtype);
                }
                instance = (T)Activator.CreateInstance (type, safeHandle);
                return instance;
            }
        }
    }

    public static class OpaqueExtensions
    {
        public static Type GetSafeHandleType (this Type type)
        {
            return type.GetTypeInfo ().GetNestedType ("SafeHandle");
        }
    }
}
