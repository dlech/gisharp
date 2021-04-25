// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

namespace GISharp.Runtime
{
    /// <summary>
    /// Describes the ownership transfer for a parameter, return value or property.
    /// </summary>
    public enum Transfer
    {
        /// <summary>
        /// The recipient does not own the value.
        /// </summary>
        None,

        /// <summary>
        /// The recipient owns the container, but not the elements. (Only meaningful for container types.)
        /// </summary>
        Container,

        /// <summary>
        /// The recipient owns the entire value.
        /// </summary>
        /// <remarks>>
        /// For a refcounted type, this means the recipient owns a ref on the value.
        /// For a container type, this means the recipient owns both container and elements.
        /// </remarks>
        Full,
    }
}
