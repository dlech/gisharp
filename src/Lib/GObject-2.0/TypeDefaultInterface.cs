// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class TypeDefaultInterface
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeDefaultInterface(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership != Transfer.Full) {
                throw new NotSupportedException();
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_type_default_interface_unref((TypeInterface.UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }

            base.Dispose(disposing);
        }
    }
}
