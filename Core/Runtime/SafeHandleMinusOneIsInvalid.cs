using System;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public abstract class SafeHandleMinusOneIsInvalid : SafeHandle
    {
        public override bool IsInvalid {
            get {
                return handle == (IntPtr)(-1);
            }
        }

        protected SafeHandleMinusOneIsInvalid () : base ((IntPtr)(-1), true)
        {
        }
    }
}
