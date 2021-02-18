// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="CClosure"/> is a specialization of <see cref="Closure"/> for C function callbacks.
    /// </summary>
    public sealed unsafe class CClosure : Closure
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="CClosure"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new struct UnmanagedStruct
        {
            /// <summary>
            /// the <see cref="Closure"/>
            /// </summary>
            public Closure.UnmanagedStruct Closure;

            /// <summary>
            /// the callback function
            /// </summary>
            public IntPtr Callback;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CClosure(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern Closure.UnmanagedStruct* g_cclosure_new(
            delegate* unmanaged[Cdecl]<void> callbackFunc,
            IntPtr userData,
            delegate* unmanaged[Cdecl]<IntPtr, Closure.UnmanagedStruct*, void> destroyNotify
        );

        private static Closure.UnmanagedStruct* New(Delegate callbackFunc)
        {
            if (callbackFunc is null) {
                throw new ArgumentNullException(nameof(callbackFunc));
            }

            var callbackFunc_ = (delegate* unmanaged[Cdecl]<void>)callbackFunc.GetCClosureUnmanagedFunctionPointer();
            var userData_ = (IntPtr)GCHandle.Alloc(new CClosureData(callbackFunc));
            var destroyNotify_ = (delegate* unmanaged[Cdecl]<IntPtr, Closure.UnmanagedStruct*, void>)&ManagedDestroyNotify;
            var ret_ = g_cclosure_new(callbackFunc_, userData_, destroyNotify_);
            return ret_;
        }

        /// <summary>
        /// Creates a new closure which invokes <paramref name="callbackFunc"/>
        /// </summary>
        public CClosure(Delegate callbackFunc) : this((IntPtr)New(callbackFunc), Transfer.None)
        {
            var marshalGeneric = (delegate* unmanaged[Cdecl]<Closure.UnmanagedStruct*, Value*, uint, Value*, IntPtr, IntPtr, void>)NativeLibrary.GetExport(NativeLibrary.Load(Platform.LibraryName("gobject-2.0")), "g_cclosure_marshal_generic");
            g_closure_set_marshal(handle, marshalGeneric);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void ManagedDestroyNotify(IntPtr userData_, Closure.UnmanagedStruct* closure_)
        {
            try {
                GCHandle.FromIntPtr(userData_).Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }
}
