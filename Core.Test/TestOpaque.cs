using System;
using GISharp.Runtime;

namespace GISharp.Core.Test
{
    public sealed class TestOpaque : Opaque
    {
        public int Value { get { return Handle.ToInt32 (); } }

        public TestOpaque (IntPtr handle, Transfer ownership)
        {
            Handle = handle;
        }

        public TestOpaque (int value)
        {
            Handle = (IntPtr)value;
        }

        public static explicit operator int (TestOpaque instance)
        {
            return instance.Value;
        }

        public static explicit operator TestOpaque (int value)
        {
            return new TestOpaque (value);
        }

        public override string ToString ()
        {
            return string.Format ("[TestOpaque: Value={0}]", Value);
        }

        public override bool Equals (object obj)
        {
            var other = obj as TestOpaque;
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
