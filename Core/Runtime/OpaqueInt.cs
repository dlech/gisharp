using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Wraps an inteter in an Opaque.
    /// </summary>
    /// <remarks>
    /// This is the equivelent of GLib's GINT_TO_POINTER() and GPOINTER_TO_INT().
    /// </remarks>
    public sealed class OpaqueInt : Opaque
    {
        public sealed class SafeOpaqueIntHandle : SafeOpaqueHandle
        {
            public int Value {
                get {
                    return handle.ToInt32 ();
                }
                set {
                    SetHandle ((IntPtr)value);
                }
            }

            public override bool IsInvalid {
                get {
                    return false;
                }
            }

            public SafeOpaqueIntHandle (IntPtr handle, Transfer ownership)
            {
                SetHandle (handle);
                GC.SuppressFinalize (this);
            }

            protected override bool ReleaseHandle ()
            {
                return true;
            }
        }

        public new SafeOpaqueIntHandle Handle {
            get {
                return (SafeOpaqueIntHandle)base.Handle;
            }
        }

        public int Value { get { return Handle.Value; } }

        public OpaqueInt (SafeOpaqueIntHandle handle) : base (handle, false)
        {
        }

        static SafeOpaqueIntHandle New (int value)
        {
            return new SafeOpaqueIntHandle ((IntPtr)value, Transfer.Full);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueInt"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public OpaqueInt (int value) : this (New (value))
        {
        }

        public static implicit operator int (OpaqueInt instance)
        {
            return instance.Value;
        }

        public static implicit operator OpaqueInt (int value)
        {
            return new OpaqueInt (value);
        }

        public override string ToString ()
        {
            return string.Format ("[OpaqueInt: Value={0}]", Value);
        }

        public override bool Equals (object obj)
        {
            var other = obj as OpaqueInt;
            if (other == null) {
                return this == null;
            }
            return Value == other.Value;
        }

        public override int GetHashCode ()
        {
            return Value.GetHashCode ();
        }
    }
}
