using System;

namespace GISharp.Core
{
    /// <summary>
    /// Destroy notify function.
    /// </summary>
    /// <remarks>
    /// This is only inteneded for use in bindings.
    /// </remarks>
    public delegate void DestroyNotifyNative (IntPtr data);
}
