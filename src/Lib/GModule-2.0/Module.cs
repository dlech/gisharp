// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GModule
{
    unsafe partial class Module
    {
        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero)
            {
                // REVISIT: should we check the return value and throw an
                // exception if closing failed?
                Close();
            }
        }

        partial void CheckCloseReturn(bool ret)
        {
            // if closing was successful, pointer is no longer valid
            if (ret)
            {
                base.Dispose(true);
            }
        }
    }
}
