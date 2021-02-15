// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GIRepository
{
    unsafe partial class Typelib
    {
        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_typelib_free((UnmanagedStruct*)handle);
            }
            base.Dispose(disposing);
        }
    }
}
