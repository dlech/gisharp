// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract unsafe class TypeInstance : Opaque
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="TypeInstance"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct UnmanagedStruct
        {
            /// <summary>
            /// Pointer to GObjectClass
            /// </summary>
            public TypeClass.UnmanagedStruct* GClass;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected TypeInstance(IntPtr handle) : base(handle)
        {
        }

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
