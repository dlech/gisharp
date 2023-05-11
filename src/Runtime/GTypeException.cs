// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

namespace GISharp.Runtime
{
    /// <summary>
    /// Exception that indicates an error in the GType system.
    /// </summary>
    /// <remarks>
    /// Usually these errors indicate a programmer error and should probably not
    /// be caught or ignored.
    /// </remarks>
    [System.Serializable]
    public sealed class GTypeException : System.Exception
    {
        /// <inheritdoc/>
        public GTypeException(string message)
            : base(message) { }

        /// <inheritdoc/>
        public GTypeException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
