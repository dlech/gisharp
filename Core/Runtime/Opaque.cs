using System;
using System.Runtime.InteropServices;

using GISharp.Lib.GObject;
using GISharp.Lib.GLib;

using Object = GISharp.Lib.GObject.Object;
using System.ComponentModel;

namespace GISharp.Runtime
{
    /// <summary>
    /// Base type for wrapping unmanged pointers
    /// </summary>
    public abstract class Opaque : IOpaque, IDisposable
    {
        /// <summary>
        /// Raw pointer value.
        /// </summary>
        /// <remarks>
        /// This should be treated as write-only by overriding. <see cref="Handle" />
        /// should be used instead when reading to ensure that the pointer is
        /// still valid.
        /// </remarks>
        protected IntPtr handle;

        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public virtual IntPtr Handle {
            get {
                if (handle == IntPtr.Zero) {
                    throw new ObjectDisposedException (null);
                }
                return handle;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Opaque(IntPtr handle, Transfer ownership)
        {
            this.handle = handle;
        }

        /// <inheritdoc />
        ~Opaque ()
        {
            Dispose (false);
        }

        /// <summary>
        /// Take unmanaged handle from this object
        /// </summary>
        /// <remarks>
        /// This object is no longer valid after calling <see cref="Take"/> (it
        /// will throw <see cref="ObjectDisposedException"/>).
        /// </remarks>
        public virtual IntPtr Take()
        {
            var this_ = Handle;
            handle = IntPtr.Zero;
            return this_;
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

        /// <inheritdoc />
        protected virtual void Dispose (bool disposing)
        {
            handle = IntPtr.Zero;
        }

        /// <summary>
        /// Marshals an unmanged pointer to a managed object.
        /// </summary>
        public static T GetInstance<T>(IntPtr handle, Transfer ownership) where T : IOpaque?
        {
            return (T)GetInstance(typeof(T), handle, ownership)!;
        }

        /// <summary>
        /// Marshals an unmanged pointer to a managed object.
        /// </summary>
        public static IOpaque? GetInstance(Type type, IntPtr handle, Transfer ownership)
        {
            // special case for OpaqueInt so 0 doesn't become null
            if (type == typeof(OpaqueInt)) {
                var ret = new OpaqueInt ((int)handle);
                return ret;
            }

            if (handle == IntPtr.Zero) {
                return null;
            }

            if (typeof(Object).IsAssignableFrom (type)) {
                return Object.GetInstance(handle, ownership);
            }

            if (typeof(ParamSpec).IsAssignableFrom (type)) {
                return ParamSpec.GetInstance(handle, ownership);
            }

            if (typeof (Source).IsAssignableFrom (type)) {
                type = typeof (UnmanagedSource);
            }
            else if (typeof(TypeInstance).IsAssignableFrom(type)) {
                var gclassPtr = Marshal.ReadIntPtr(handle);
                var gtype = Marshal.PtrToStructure<GType>(gclassPtr);
                type = gtype.GetGTypeStruct ();
            }
            else if (typeof(TypeClass).IsAssignableFrom(type)) {
                var gtype = Marshal.PtrToStructure<GType> (handle);
                type = gtype.GetGTypeStruct ();
            }
            else if (typeof(TypeInterface).IsAssignableFrom(type)) {
                var gtype = Marshal.PtrToStructure<GType> (handle);
                type = gtype.GetGTypeStruct ();
            }

            return (IOpaque)Activator.CreateInstance(type, handle, ownership);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is Opaque opaque) {
                return handle == opaque.handle;
            }
            return base.Equals(obj);
        }
    }
}
