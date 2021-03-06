// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute for decorating classes that wrap a GType struct.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true)]
    public sealed class GTypeStructAttribute : Attribute
    {
        /// <summary>
        /// The glib type struct that is used to declare this class in unmanaged
        /// code.
        /// </summary>
        public Type GTypeStruct { get; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public GTypeStructAttribute(Type gtypeStruct)
        {
            GTypeStruct = gtypeStruct;
        }
    }
}
