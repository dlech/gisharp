// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Encapsulates an unhandled exception thrown in a callback to unmanaged code.
    /// </summary>
    public sealed class UnhandledException : Exception
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="ex">
        /// The unhandled exception. This will be set to the inner exception.
        /// </param>
        public UnhandledException(Exception ex) : base("Unhandled exception", ex)
        {
        }
    }
}
