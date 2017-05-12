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
        public sealed class SafeHandle : SafeOpaqueHandle
		{
			public static SafeHandle Zero = _Zero.Value;
			static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            public int Value {
                get {
                    return handle.ToInt32 ();
                }
                set {
                    SetHandle ((IntPtr)value);
                }
            }

            public SafeHandle (IntPtr handle, Transfer ownership) : this ()
            {
                SetHandle (handle);
            }

            public SafeHandle ()
            {
                GC.SuppressFinalize (this);
            }

            public override bool IsInvalid => false;

            protected override bool ReleaseHandle () => true;
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        public int Value => Handle.Value;

        public OpaqueInt (SafeHandle handle) : base (handle)
        {
        }

        static SafeHandle New (int value)
        {
            return new SafeHandle { Value = value };
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
