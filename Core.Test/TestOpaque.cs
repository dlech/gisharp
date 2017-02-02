using System;
using GISharp.Runtime;

namespace GISharp.Core.Test
{
    public sealed class TestOpaque : Opaque
    {
        public sealed class SafeTestOpaqueHandle : SafeHandleZeroIsInvalid
        {
            public int Value {
                get {
                    return handle.ToInt32 ();
                }
                set {
                    SetHandle ((IntPtr)value);
                }
            }

            public SafeTestOpaqueHandle (IntPtr handle, Transfer ownership)
            {
                SetHandle (handle);
            }

            protected override bool ReleaseHandle ()
            {
                return true;
            }
        }

        public new SafeTestOpaqueHandle Handle {
            get {
                return (SafeTestOpaqueHandle)base.Handle;
            }
        }

        public int Value { get { return Handle.Value; } }

        public TestOpaque (SafeTestOpaqueHandle handle) : base (handle)
        {
        }

        static SafeTestOpaqueHandle New (int value)
        {
            return new SafeTestOpaqueHandle ((IntPtr)value, Transfer.Full);
        }

        public TestOpaque (int value) : this (New (value))
        {
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
