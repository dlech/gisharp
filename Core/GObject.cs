using System;

namespace GISharp.Core
{
    public class GObject : Opaque
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
