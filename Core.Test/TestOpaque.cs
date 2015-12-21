using System;

namespace GISharp.Core.Test
{
    sealed class TestOpaque : Opaque
    {
        public int Value { get { return Handle.ToInt32 (); } }

        TestOpaque (IntPtr handle, Transfer ownership)
        {
            Handle = handle;
        }

        public TestOpaque (int value)
        {
            Handle = (IntPtr)value;
        }
    }
}
