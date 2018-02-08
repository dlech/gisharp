
using System;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    /// <summary>
    /// Common interface for arrays of value types (structs).
    /// </summary>
    public interface IArray<T> : IReadOnlyList<T>
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
        /// Removes the data from the array. Used for transfering ownership
        /// of the data to somewhere else.
        /// </summary>
        /// <returns>
        /// Value tuple containing a pointer to the data and the length
        /// </summary>
        ValueTuple<IntPtr, int> TakeData();
    }
}
