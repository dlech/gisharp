// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>


namespace GISharp.Lib.Gio
{
    unsafe partial class CancellableSource
    {
        /// <inheritdoc />
        public void SetCallback(CancellableSourceFunc func)
        {
            throw new System.NotImplementedException("need to update code gen for GSource");
            // SetCallback(func, CancellableSourceFuncMarshal.ToUnmanagedFunctionPointer);
        }
    }
}
