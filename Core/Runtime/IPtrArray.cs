
using System;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    /// <summary>
    /// Common interface for arrays of <see cref="Opaque"/> items.
    /// </summary>
    public interface IPtrArray<T> : IEnumerable<T> where T : Opaque
    {
        /// <summary>
        /// Gets a pointer to the array in unmanaged memory.
        /// </summary>
        IntPtr Data { get; }

        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the managed proxy for the unmanaged object at <paramref name="index"/>.
        /// </summary>
        /// <param name="index">
        /// The array index
        /// </param>
        T this[int index] { get; }
    }
}
