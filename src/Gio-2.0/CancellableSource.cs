// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


namespace GISharp.Lib.Gio
{
    partial class CancellableSource
    {
        /// <inheritdoc />
        public void SetCallback(CancellableSourceFunc func)
        {
            SetCallback(func, CancellableSourceFuncMarshal.ToUnmanagedFunctionPointer);
        }
    }
}
