// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Zero-terminated string with unspecified character encoding.
    /// </summary>
    public unsafe class ByteString : Opaque, IEquatable<ByteString>
    {
        private int length;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ByteString(IntPtr handle, Transfer ownership) : this(handle, -1, ownership)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ByteString(IntPtr handle, int length, Transfer ownership) : base(handle)
        {
            if (ownership != Transfer.Full) {
                this.handle = (IntPtr)g_strdup((byte*)handle);
                GMarshal.PopUnhandledException();
            }
            this.length = length;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte* g_strdup(byte* ptr);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                GMarshal.Free(handle);
            }
            base.Dispose(disposing);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_strcmp0(byte* str1, byte* str2);

        /// <inheritdoc/>
        public bool Equals(ByteString? other)
        {
            var str1_ = (byte*)UnsafeHandle;
            var str2_ = (byte*)(other?.UnsafeHandle ?? IntPtr.Zero);
            var ret_ = g_strcmp0(str1_, str2_);
            GMarshal.PopUnhandledException();
            return ret_ == 0;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => Equals(obj as ByteString);

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();
    }
}
