using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GISharp.Core
{
    /// <summary>
    /// Managed objects that wrap a unmanaged GLib data structures must implement this.
    /// </summary>
    public interface IWrappedNative
    {
        /// <summary>
        /// Gets the pointer to the unmanaged GLib data structure.
        /// </summary>
        /// <value>The pointer.</value>
        IntPtr Handle { get; }
    }

    public static class WrappedNativeExtensions
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

        public WrappedStruct (IntPtr handle) : base (handle)
        {
        }

        public WrappedStruct () : base (IntPtr.Zero)
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
