// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Strv
    {
        private protected int length;

        /// <summary>
        /// Gets the length of the array, not including the zero-termination.
        /// </summary>
        /// <remarks>
        /// If the length is not already known, it will be determined by iterating the array.
        /// </remarks>
        public int Length
        {
            get
            {
                if (length < 0)
                {
                    length = (int)g_strv_length((UnmanagedStruct*)UnsafeHandle);
                    GMarshal.PopUnhandledException();
                }
                return length;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Strv(IntPtr handle, Transfer ownership)
            : this(handle, -1, ownership) { }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Strv(IntPtr handle, int length, Transfer ownership)
            : base(handle)
        {
            if (ownership != Transfer.Full)
            {
                this.handle = IntPtr.Zero;
                GC.SuppressFinalize(this);
                throw new NotSupportedException();
            }

            this.length = length;
        }

        /// <summary>
        /// Gets a ref to the unmanaged pointer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe ref readonly IntPtr GetPinnableReference()
        {
            return ref Unsafe.AsRef<IntPtr>((void*)UnsafeHandle);
        }
    }

    /// <include file="Strv.xmldoc" path="declaration/member[@name='Strv']/*" />
    public sealed unsafe class Strv<T> : Strv, IEnumerable<T>
        where T : ByteString
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strv(IntPtr handle, int length, Transfer ownership)
            : base(handle, length, ownership) { }

        private static byte** NewFromManaged(byte[][] source)
        {
            // allocate the array
            var ret = (byte**)GMarshal.Alloc(IntPtr.Size * (source.Length + 1));

            // copy each bytestring
            for (int i = 0; i < source.Length; i++)
            {
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
        /// Creates a new unmanaged string array.
        /// </summary>
        public Strv(params byte[][] value)
            : this((IntPtr)NewFromManaged(value), value.Length, Transfer.Full) { }

        static IntPtr* NewFromManaged(string[] value)
        {
            if (value.Any(s => s is null))
            {
                throw new ArgumentException("All array elements must be non-null.", nameof(value));
            }
            var strv_ = (IntPtr*)GMarshal.Alloc((value.Length + 1) * IntPtr.Size);
            for (int i = 0; i < value.Length; i++)
            {
                strv_[i] = new Utf8(value[i]).Take();
            }
            strv_[value.Length] = IntPtr.Zero;
            return strv_;
        }

        /// <summary>
        /// Creates a new unmanaged string array.
        /// </summary>
        /// <remarks>
        /// Strings will be converted to UTF-8 regardless of the type parameter.
        /// </remarks>
        public Strv(params string[] value)
            : this((IntPtr)NewFromManaged(value), value.Length, Transfer.Full) { }

        /// <summary>
        /// Converts <see cref="Strv{T}"/> to <see cref="UnownedZeroTerminatedCPtrArray{T}"/>.
        /// </summary>
        public static implicit operator UnownedZeroTerminatedCPtrArray<T>(Strv<T> strv)
        {
            return new UnownedZeroTerminatedCPtrArray<T>(
                strv.UnsafeHandle,
                strv.length,
                Transfer.None
            );
        }

        /// <summary>
        /// Converts <see cref="Strv{T}"/> to <see cref="UnownedCPtrArray{T}"/>.
        /// </summary>
        public static explicit operator UnownedCPtrArray<T>(Strv<T> strv)
        {
            return new UnownedCPtrArray<T>(strv.UnsafeHandle, strv.Length, Transfer.None);
        }

        IEnumerator<T> GetIEnumerator()
        {
            IntPtr ptr,
                str_;
            for (
                ptr = UnsafeHandle;
                (str_ = Marshal.ReadIntPtr(ptr)) != IntPtr.Zero;
                ptr += IntPtr.Size
            )
            {
                var str = GetInstance<T>(str_, Transfer.None);
                yield return str;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetIEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetIEnumerator();
    }
}
