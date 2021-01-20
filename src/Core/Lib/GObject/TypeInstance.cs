// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    public abstract class TypeInstance : Opaque
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="TypeInstance"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe struct UnmanagedStruct
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
        protected TypeInstance(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Gets the <see cref="GType"/> for this instance.
        /// </summary>
        public unsafe GType GetGType()
        {
            var typeInstance = (UnmanagedStruct*)Handle;
            return typeInstance->GClass->GType;
        }

        /// <summary>
        /// Gets the <see cref="TypeClass"/> for this instance.
        /// </summary>
        public unsafe TypeClass GetTypeClass() => TypeClass.Get(GetGType());
    }
}
