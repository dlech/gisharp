// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for indicating in which version an API was introduced.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class SinceAttribute : Attribute
    {
        /// <summary>
        /// Gets the version in which the API was introduced.
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public SinceAttribute(string version)
        {
            Version = Version.Parse(version);
        }
    }
}
