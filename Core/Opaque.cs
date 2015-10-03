using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GISharp.Core
{
    /// <summary>
    /// Managed objects that wrap a unmanaged GLib data structures must implement this.
    /// </summary>
    public abstract class Opaque : IDisposable
    {
        protected bool IsDisposed;

        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        public IntPtr Handle { get; protected set; }

        ~Opaque ()
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

        /// <summary>
        /// Dispose the specified disposing.
        /// </summary>
        /// <param name="disposing"><c>true</c> if called from the <see cref="Dispose"/> method,
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
    }

    public static class OpaquueExtensions
    {
        public static ICustomMarshaler GetCustomMarshaler (this Type type)
        {
            type.Assembly.GetType (type.FullName + "Marshaler", true);
            var getCustomMarshaler = type.GetMethod ("GetCustomMarshaler",
                BindingFlags.Static | BindingFlags.Public,
                null, new Type[] { }, null);
            if (getCustomMarshaler == null) {
                throw new MissingMethodException (type.FullName, "GetCustomMarshaler");
            }
            var customMarshalerType = (Type)getCustomMarshaler.Invoke (null, null);
            var getInstance = customMarshalerType.GetMethod ("GetInstance",
                BindingFlags.Static | BindingFlags.Public,
                null, new [] { typeof(string) }, null);
            if (getInstance == null) {
                throw new MissingMethodException (type.FullName, "GetInstance");
            }
            var customMarshaler = (ICustomMarshaler)getInstance.Invoke (null, new [] { string.Empty });

            return customMarshaler;
        }
    }

    public class WrappedStruct<T> : OwnedOpaque<WrappedStruct<T>> where T : struct
    {
        public T Value {
            get {
                return Marshal.PtrToStructure<T> (Handle);
            }
            set {
                Marshal.StructureToPtr<T> (value, Handle, false);
            }
        }

        public WrappedStruct (IntPtr handle, bool owned)
        {
            Handle = handle;
            Owned = owned;
        }

        public WrappedStruct ()
        {
            Handle = MarshalG.Alloc (Marshal.SizeOf<T> ());
            Owned = true;
        }

        public WrappedStruct (T value) : this ()
        {
            Value = value;
        }

        protected override void Free ()
        {
            MarshalG.Free (Handle);
        }
    }
}
