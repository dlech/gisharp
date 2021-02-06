// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Wrapper around unmanaged null-terminated array of null-terminated UTF-8 strings.
    /// </summary>
    [GType("GStrv", IsProxyForUnmanagedType = true)]
    public sealed unsafe class Strv : Boxed, IReadOnlyList<Utf8>
    {
        /// <summary>
        /// Gets the managed UTF-16 value of this string.
        /// </summary>
        public string[] Value => _Value.Value;
        readonly Lazy<string[]> _Value;

        static IntPtr New(string[] value)
        {
            return GMarshal.StringArrayToGStrvPtr(value);
        }

        /// <summary>
        /// Creates a new unmanaged string array.
        /// </summary>
        public Strv(params string[] value) : this(New(value), Transfer.Full)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strv(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
            _Value = new Lazy<string[]>(() => this.Select(x => (string)x).ToArray());
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strv(IntPtr handle, int length, Transfer ownership) : this(handle, ownership)
        {
            // TODO: cache the length
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_strv_get_type();

        static readonly GType _GType = g_strv_get_type();

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.6")]
        static extern uint g_strv_length(byte** strArray);

        /// <summary>
        /// Returns the length of this <see cref="Strv"/>.
        /// </summary>
        [Since("2.6")]
        public int Length {
            get {
                var this_ = (byte**)UnsafeHandle;
                var ret = g_strv_length(this_);
                return (int)ret;
            }
        }

        int IReadOnlyCollection<Utf8>.Count => Length;

        Utf8 IReadOnlyList<Utf8>.this[int index] => throw new NotImplementedException();

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.44")]
        static extern Runtime.Boolean g_strv_contains(byte** strv, byte* str);

        /// <summary>
        /// Checks if this instance contains <paramref name="str"/>.
        /// </summary>
        /// <param name="str">
        /// a string
        /// </param>
        [Since("2.44")]
        public bool Contains(UnownedUtf8 str)
        {
            var this_ = (byte**)UnsafeHandle;
            var str_ = (byte*)str.UnsafeHandle;
            var ret_ = g_strv_contains(this_, str_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Converts and unmanaged UTF-8 string array to a manged UTF-16 string array.
        /// </summary>
        public static explicit operator string[](Strv strv)
        {
            return strv.Value;
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
        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// Returns a reference to unmanaged string array.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ref readonly IntPtr GetPinnableReference()
        {
            return ref Unsafe.AsRef<IntPtr>((void*)UnsafeHandle);
        }
    }
}
