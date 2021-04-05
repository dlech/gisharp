// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    [GType("GStrv", IsProxyForUnmanagedType = true)]
    unsafe partial class Strv : IEnumerable<Utf8>
    {
        private static readonly GType _GType = g_strv_get_type();

        static IntPtr* NewFromManaged(string[] value)
        {
            if (value.Any(s => s is null)) {
                throw new ArgumentException("All array elements must be non-null.", nameof(value));
            }
            var strv_ = (IntPtr*)GMarshal.Alloc((value.Length + 1) * IntPtr.Size);
            for (int i = 0; i < value.Length; i++) {
                strv_[i] = new Utf8(value[i]).Take();
            }
            strv_[value.Length] = IntPtr.Zero;
            return strv_;
        }

        /// <summary>
        /// Creates a new unmanaged string array.
        /// </summary>
        public Strv(params string[] value) : this((IntPtr)NewFromManaged(value), value.Length, Transfer.Full)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strv(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }

        IEnumerator<Utf8> GetIEnumerator()
        {
            IntPtr ptr, str_;
            for (ptr = UnsafeHandle; (str_ = Marshal.ReadIntPtr(ptr)) != IntPtr.Zero; ptr += IntPtr.Size) {
                var str = new Utf8(str_, Transfer.None);
                yield return str;
            }
        }

        IEnumerator<Utf8> IEnumerable<Utf8>.GetEnumerator() => GetIEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetIEnumerator();

        /// <summary>
        /// Implements type needed in <c>foreach</c> loops.
        /// </summary>
        public class Enumerator
        {
            private readonly Strv instance;
            private int offset;
            private IntPtr ptr;

            internal Enumerator(Strv instance)
            {
                this.instance = instance;
            }

            /// <summary>
            /// Implements property needed in <c>foreach</c> loops.
            /// </summary>
            public UnownedUtf8 Current {
                get {
                    return new UnownedUtf8(ptr, -1);
                }
            }

            /// <summary>
            /// Implements method needed in <c>foreach</c> loops.
            /// </summary>
            public bool MoveNext()
            {
                ptr = Marshal.ReadIntPtr(instance.UnsafeHandle, offset);
                offset += IntPtr.Size;
                return ptr != IntPtr.Zero;
            }
        }

        /// <summary>
        /// Function needed for use in <c>foreach</c> loops.
        /// </summary>
        public Enumerator GetEnumerator() => new(this);
    }
}
