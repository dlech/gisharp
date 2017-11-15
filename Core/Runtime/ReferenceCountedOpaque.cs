using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base class for reference counted types.
    /// </summary>
    /// <remarks>
    /// This class maintains a map of unmanged pointers to managed objects so
    /// that we only ever have one managed wrapper for each unmanged struct.
    /// </remarks>
    public abstract class ReferenceCountedOpaque : Opaque
    {
        static readonly Dictionary<IntPtr, WeakReference<Opaque>> instanceMap;
        static readonly object instanceMapLock;

        bool isMapped;

        static ReferenceCountedOpaque ()
        {
            instanceMap = new Dictionary<IntPtr, WeakReference<Opaque>> ();
            instanceMapLock = new object ();
        }

        protected ReferenceCountedOpaque (IntPtr handle) : base (handle)
        {
            if (handle == IntPtr.Zero) {
                throw new ArgumentOutOfRangeException (nameof (handle));
            }
            lock (instanceMapLock) {
                instanceMap.Add (handle, new WeakReference<Opaque> (this));
                isMapped = true;
            }
        }

        protected override void Dispose (bool disposing)
        {
            lock (instanceMapLock) {
                if (isMapped) {
                    instanceMap.Remove (Handle);
                    isMapped = false;
                }
            }
            base.Dispose (disposing);
        }

        protected abstract void Ref ();

        protected abstract void Unref ();

        /// <summary>
        /// Tries to get an existing managed wrapper of an unmanaged pointer.
        /// </summary>
        /// <returns>
        /// The existing instance or <c>null</c> if one does not exist.
        /// </returns>
        internal static T TryGetExisting<T> (IntPtr handle) where T : Opaque
        {
            lock (instanceMapLock) {
                if (instanceMap.TryGetValue (handle, out var value)) {
                    if (value.TryGetTarget (out var instance)) {
                        return (T)instance;
                    }
                    // This should rarely be reached (for example, it could
                    // happen if there was an exception in a finalizer).
                    instanceMap.Remove (handle);
                }
                return null;
            }
        }

        internal static T GetOrCreate<T> (IntPtr handle, Transfer ownership) where T : Opaque
        {
            var type = typeof(T);

            if (handle == IntPtr.Zero) {
                return null;
            }

            lock (instanceMapLock) {
                var instance = TryGetExisting<T> (handle) as ReferenceCountedOpaque;
                if (instance != null) {
                    if (ownership != Transfer.None) {
                        // drop the reference owned by handle since we already
                        // have another reference in instance
                        instance.Unref ();
                    }
                    return (T)(Opaque)instance;
                }

                // special case for GLib.Source because it is weird
                if (type == typeof(GLib.Source)) {
                    type = typeof(GLib.UnmanagedSource);
                }

                // We can use introspection to get the actual type of a TypeInstance
                else if (typeof(TypeInstance).GetTypeInfo ().IsAssignableFrom (type)) {
                    var gtype = Marshal.PtrToStructure<GType> (Marshal.ReadIntPtr (handle));
                    type = GType.TypeOf (gtype);
                }

                // We also need to look up the exact type for TypeClass
                else if (typeof(TypeClass).GetTypeInfo ().IsAssignableFrom (type)) {
                    var gtype = Marshal.PtrToStructure<GType> (Marshal.ReadIntPtr (handle));
                    type = gtype.GetGTypeStruct ();
                }

                instance = (ReferenceCountedOpaque)Activator.CreateInstance (type, handle, ownership);
                return (T)(Opaque)instance;
            }
        }
    }
}
