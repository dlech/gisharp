// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for decorating methods that wrap a GObject virtual method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class GVirtualMethodAttribute : Attribute
    {
        /// <summary>
        /// The unmanaged delegate type associated with this virtual method
        /// </summary>
        public Type DelegateType { get; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="delegateType">
        /// The unmanaged delegate type associated with this virtual method
        /// </param>
        public GVirtualMethodAttribute(Type delegateType)
        {
            DelegateType = delegateType;
        }
    }
}
