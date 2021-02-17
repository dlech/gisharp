// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for GObject callbacks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate, Inherited = false)]
    public sealed class GCallbackAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public GCallbackAttribute()
        {
        }
    }
}
