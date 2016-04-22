using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Static opaque wraps a struct that is not reference counted and cannot
    /// be freed or copied.
    /// </summary>
    public abstract class StaticOpaque : Opaque
    {
        protected StaticOpaque (IntPtr handle, Transfer ownership)
        {
            if (ownership != Transfer.None) {
                throw new ArgumentException ("StaticOpaque types cannot be owned.");
            }
            Handle = handle;
        }
    }
}
