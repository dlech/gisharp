using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Interface for unmanaged pointers.
    /// </summary>
    public interface IOpaque
    {
        /// <summary>
        /// Gets the handle to the unmanged data structure
        /// </summary>
        IntPtr Handle { get; }
    }
}
