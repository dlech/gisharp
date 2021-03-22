// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Binding
    {
        /// <summary>
        /// Explicitly releases the binding between the source and the target
        /// property expressed by this instance. This object can no longer
        /// be used after calling <see cref="Unbind"/> (it becomes disposed).
        /// </summary>
        [Since("2.38")]
        public void Unbind()
        {
            // Note: this releases a reference to handle
            var binding_ = (UnmanagedStruct*)UnsafeHandle;
            g_binding_unbind(binding_);
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
