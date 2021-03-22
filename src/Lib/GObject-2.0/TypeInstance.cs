// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class TypeInstance
    {
        /// <summary>
        /// Gets the <see cref="GType"/> for this instance.
        /// </summary>
        public GType GetGType()
        {
            var typeInstance = (UnmanagedStruct*)UnsafeHandle;
            return typeInstance->GClass->GType;
        }

        /// <summary>
        /// Gets the <see cref="TypeClass"/> for this instance.
        /// </summary>
        public TypeClass GetTypeClass() => TypeClass.Get(GetGType());
    }
}
