using System;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public abstract class SafeHandleZeroIsInvalid : SafeHandle
    {
        public override bool IsInvalid {
            get {
                return handle == IntPtr.Zero;
            }
        }

        protected SafeHandleZeroIsInvalid () : base (IntPtr.Zero, true)
        {
        }
    }
}
