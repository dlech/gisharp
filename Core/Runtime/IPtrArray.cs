
using System;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    /// <summary>
    /// Common interface for arrays of <see cref="Opaque"/> items.
    /// </summary>
    public interface IPtrArray<T> : IReadOnlyList<T> where T : Opaque
    {
        /// <summary>
        /// Gets a pointer to the array in unmanaged memory.
        /// </summary>
        IntPtr Data { get; }

        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        int Length { get; }
    }
}
