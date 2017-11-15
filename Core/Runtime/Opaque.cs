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
        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public IntPtr Handle { get; protected set; }

        protected Opaque (IntPtr handle)
        {
            Handle = handle;
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
        /// </remarks>
        public void Dispose ()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing)
        {
            Handle = IntPtr.Zero;
        }

        protected void AssertNotDisposed ()
        {
            if (Handle == IntPtr.Zero) {
                throw new ObjectDisposedException (null);
            }
        }

        public static T GetInstance<T> (IntPtr handle, Transfer ownership) where T : Opaque
        {
            var type = typeof(T);

            // special case for OpaqueInt so 0 doesn't become null
            if (type == typeof(OpaqueInt)) {
                var ret = new OpaqueInt ((int)handle);
                return (T)(object)ret;
            }

            if (handle == IntPtr.Zero) {
                return null;
            }

            if (typeof(ReferenceCountedOpaque).GetTypeInfo ().IsAssignableFrom (type)) {
                return ReferenceCountedOpaque.GetOrCreate<T> (handle, ownership);
            }

            if (typeof(TypeInterface).IsAssignableFrom (type)) {
                var gtype = Marshal.PtrToStructure<GType> (handle);
                type = gtype.GetGTypeStruct ();
            }

            return (T)Activator.CreateInstance (type, handle, ownership);
        }
    }
}
