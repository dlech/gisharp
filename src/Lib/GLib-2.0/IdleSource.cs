// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class IdleSource
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_source_set_callback(
            UnmanagedStruct* source,
            delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean> func,
            IntPtr data,
            delegate* unmanaged[Cdecl]<IntPtr, void> notify);

        /// <summary>
        /// Sets the callback function for a source. The callback for a source is
        /// called from the source's dispatch function.
        /// </summary>
        /// <param name="func">
        /// the managed callback
        /// </param>
        public void SetCallback(SourceFunc func)
        {
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, Runtime.Boolean>)&SourceFuncMarshal.Callback;
            var data_ = (IntPtr)GCHandle.Alloc((func, CallbackScope.Notified));
            var notify_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
            g_source_set_callback(source_, func_, data_, notify_);
        }
    }
}
