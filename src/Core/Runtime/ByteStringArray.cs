// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null-terminated array of null-terminated strings of unspecified character encoding.
    /// </summary>
    public unsafe class ByteStringArray : Boxed, IEquatable<ByteStringArray>
    {
        private int length;

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint g_strv_length(byte** str_array);

        /// <summary>
        /// Gets the length of the array, not including the zero-termination.
        /// </summary>
        /// <remarks>
        /// If the length is not already known, it will be determined by iterating the array.
        /// </remarks>
        public int Length {
            get {
                if (length < 0) {
                    length = (int)g_strv_length((byte**)UnsafeHandle);
                    GMarshal.PopUnhandledException();
                }
                return length;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ByteStringArray(IntPtr handle, Transfer ownership) : this(handle, -1, ownership)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ByteStringArray(IntPtr handle, int length, Transfer ownership) : base(handle)
        {
            if (ownership != Transfer.Full) {
                this.handle = IntPtr.Zero;
                GC.SuppressFinalize(this);
                throw new NotSupportedException();
            }

            this.length = length;
        }

        private static byte** NewFromManaged(byte[][] source)
        {
            // allocate the array
            var ret = (byte**)GMarshal.Alloc(IntPtr.Size * (source.Length + 1));

            // copy each bytestring
            for (int i = 0; i < source.Length; i++) {
                ret[i] = (byte*)GMarshal.Alloc(source[i].Length + 1);
                Marshal.Copy(source[i], 0, (IntPtr)ret[i], source[i].Length);
                // null termination for bytestring
                ret[i][source[i].Length] = 0;
            }

            // null termination for array
            ret[source.Length] = null;

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ByteStringArray"/> in unmanaged memory.
        /// </summary>
        /// <param name="source">
        /// The source data (should not contain bytes with value of 0).
        /// </param>
        public ByteStringArray(byte[][] source)
            : this((IntPtr)NewFromManaged(source), source.Length, Transfer.Full)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_strfreev(IntPtr strv);

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_strfreev(handle);
                GMarshal.PopUnhandledException();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets a ref to the unmanaged pointer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe ref readonly IntPtr GetPinnableReference()
        {
            return ref Unsafe.AsRef<IntPtr>((void*)UnsafeHandle);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern Boolean g_strv_equal(
            byte** strv1,
            byte** strv2);

        /// <summary>
        /// Checks if <paramref name="strv1"/> and <paramref name="strv2"/>
        ///contain exactly the same elements in exactly the same order.
        /// </summary>
        private static bool Equal(UnownedZeroTerminatedCPtrArray<ByteString> strv1, UnownedZeroTerminatedCPtrArray<ByteString> strv2)
        {
            var strv1_ = (byte**)strv1.UnsafeHandle;
            var strv2_ = (byte**)strv2.UnsafeHandle;
            var ret_ = g_strv_equal(strv1_, strv2_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <inheritdoc/>
        public bool Equals(ByteStringArray? other)
        {
            if (other is null) {
                return this is null;
            }
            var ret = Equal(this, other);
            return ret;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is WeakZeroTerminatedCPtrArray<ByteString> weak) {
                return Equal(this, weak);
            }
            return Equals(obj as ByteStringArray);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => handle.GetHashCode();

        /// <summary>
        /// Gets an unowned reference to this instance.
        /// </summary>
        public UnownedZeroTerminatedCPtrArray<ByteString> AsUnowned() => new(handle, length, Transfer.None);

        /// <summary>
        /// Coverts <see cref="ByteStringArray"/> to <see cref="UnownedZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/>.
        /// </summary>
        public static implicit operator UnownedZeroTerminatedCPtrArray<ByteString>(ByteStringArray value) => value.AsUnowned();
    }
}
