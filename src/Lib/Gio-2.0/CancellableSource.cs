// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    unsafe partial class CancellableSource
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_source_set_callback(
            Source.UnmanagedStruct* source,
            delegate* unmanaged[Cdecl]<Cancellable.UnmanagedStruct*, IntPtr, Runtime.Boolean> func,
            IntPtr data,
            delegate* unmanaged[Cdecl]<IntPtr, void> notify);

        /// <summary>
        /// Sets the callback function for a <see cref="Source"/> created with
        /// <see cref="New"/>.
        /// </summary>
        public static void SetCallback(this Source source, CancellableSourceFunc func)
        {
            var source_ = (Source.UnmanagedStruct*)source.UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<Cancellable.UnmanagedStruct*, IntPtr, Runtime.Boolean>)&CancellableSourceFuncMarshal.Callback;
            var funcHandle = GCHandle.Alloc((func, CallbackScope.Notified));
            var data_ = (IntPtr)funcHandle;
            var notify_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
            g_source_set_callback(source_, func_, data_, notify_);
            GMarshal.PopUnhandledException();
        }
    }
}
