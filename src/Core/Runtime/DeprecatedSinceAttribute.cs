// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

﻿using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Indicates the library version in which the attribute target was deprecated.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DeprecatedSinceAttribute : Attribute
    {
        /// <summary>
        /// The version when the target was deprecated.
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="version">
        /// The version.
        /// </param>
        public DeprecatedSinceAttribute(string version)
        {
            Version = Version.Parse(version);
        }
    }
}
