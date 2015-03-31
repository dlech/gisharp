using System;

namespace GISharp.Core
{
    /// <summary>
    /// Wrapper for an opaque struct that is "owned".
    /// </summary>
    /// <remarks>>
    /// "Owned" means that it is not reference counted. It has Copy and Free
    /// methods.
    /// </remarks>
    public abstract class OwnedOpaque : INativeObject
    {
        public IntPtr Handle { get; protected set; }

        protected OwnedOpaque (IntPtr handle)
        {
            Handle = handle;
        }
    }
}

