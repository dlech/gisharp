using System;

namespace GISharp.Core
{
    public class GObject : INativeObject
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
