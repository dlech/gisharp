using System;

namespace GISharp.Core
{
    public class GType : IWrappedNative
    {
        public IntPtr Handle { get; private set; }
    }
}
