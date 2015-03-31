using System;

namespace GISharp.Core
{
    public class GType : INativeObject
    {
        public IntPtr Handle { get; private set; }
    }
}
