using System;

namespace GISharp.Core
{
    public class GObject : IWrappedNative
    {
        public IntPtr Handle { get; private set; }

        public GObject (IntPtr handle)
        {
            Handle = handle;
        }

        public void Ref ()
        {
        }

        public void Unref ()
        {
        }
    }
}
