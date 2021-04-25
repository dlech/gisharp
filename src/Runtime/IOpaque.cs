// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

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
        IntPtr UnsafeHandle { get; }

        /// <summary>
        /// Takes ownership of (or a reference to) the unmanaged data structure
        /// </summary>
        IntPtr Take();
    }
}
