using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Wraps an integer in an Opaque.
    /// </summary>
    /// <remarks>
    /// This is the equivalent of GLib's GINT_TO_POINTER() and GPOINTER_TO_INT()
    /// macros.
    /// </remarks>
    public sealed class OpaqueInt : Opaque
    {
        public int Value => (int)Handle;

        public OpaqueInt (IntPtr handle) : base (handle)
        {
        }

        static IntPtr New (int value)
        {
            return new IntPtr (value);
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

        protected override void Dispose (bool disposing)
        {
            // there is nothing to free
        }
    }
}
