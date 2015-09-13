using System;

namespace GISharp.Core
{
    /// <summary>
    /// Static opaque wraps a struct that is not reference counted and cannot
    /// be freed or copied.
    /// </summary>
    public abstract class StaticOpaque<T> : IWrappedNative where T : StaticOpaque<T>
    {
        public IntPtr Handle { get; protected set; }

        protected StaticOpaque (IntPtr handle)
        {
            Handle = handle;
        }
    }
}

