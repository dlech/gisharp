// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Managed wrapper around an unowned, null-terminated UTF-8 string in unmanged memory.
    /// </summary>
    /// <seealso cref="NullableUnownedUtf8"/>
    /// <seealso cref="Utf8"/>
    public unsafe ref struct UnownedUtf8
    {
        readonly byte* handle;
        int length;

        /// <summary>
        /// Pointer to to the unmanaged UTF-8 string.
        /// </summary>
        /// <exception name="NullReferenceException">
        /// If this points to <c>null</c>, e.g. <c>default(UnownedUtf8).UnsafeHandle</c>.
        /// </exception>
        public IntPtr UnsafeHandle => handle is null ? throw new NullReferenceException() : (IntPtr)handle;

        /// <summary>
        /// Gets the length of the string in bytes.
        /// </summary>
        public int Length {
            get {
                if (length < 0) {
                    length = new ReadOnlySpan<byte>((byte*)UnsafeHandle, int.MaxValue).IndexOf<byte>(0);
                }
                return length;
            }
        }

        /// <summary>
        /// Gets the length of the string in bytes or -1 if the length is not known.
        /// </summary>
        public int MaybeLength => length;

        /// <summary>
        /// Creates a new <see cref="UnownedUtf8"/>.
        /// </summary>
        /// <param name="handle">
        /// Pointer to the unmanaged UTF-8 string.
        /// </param>
        /// <param name="length">
        /// The length of the string or <c>-1</c> if the length is unknown.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// <paramref name="handle"/> is <see cref="IntPtr.Zero"/>.
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedUtf8(IntPtr handle, int length)
        {
            // REVISIT: this breaks out args of try functions
            // if (handle == IntPtr.Zero) {
            //     throw new ArgumentNullException(nameof(handle));
            // }
            this.handle = (byte*)handle;
            this.length = length;
        }

        /// <summary>
        /// Creates a new <see cref="UnownedUtf8"/>.
        /// </summary>
        /// <param name="handle">
        /// Pointer to the unmanaged UTF-8 string.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// <paramref name="handle"/> is <c>null</c>.
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe UnownedUtf8(byte* handle) : this((IntPtr)handle, -1)
        {
        }

        /// <summary>
        /// Creates a <see cref="NullableUnownedUtf8"/> from this instance.
        /// </summary>
        public NullableUnownedUtf8 AsNullableUnownedUtf8()
        {
            return new NullableUnownedUtf8(this);
        }

        /// <summary>
        /// Creates a <see cref="ReadOnlySpan{T}"/> of the unmanaged memory.
        /// </summary>
        public ReadOnlySpan<byte> AsReadOnlySpan()
        {
            return new ReadOnlySpan<byte>((byte*)UnsafeHandle, Length);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_str_equal(byte* v1, byte* v2);

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// </summary>
        public bool Equals(UnownedUtf8 other)
        {
            var v1_ = (byte*)UnsafeHandle;
            var v2_ = (byte*)other.UnsafeHandle;
            var ret = g_str_equal(v1_, v2_);
            return ret.IsTrue();
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// </summary>
        public bool Equals(NullableUnownedUtf8 other)
        {
            if (!other.HasValue) {
                return false;
            }
            return Equals(other.Value);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// </summary>
        public bool Equals(Utf8? other)
        {
            if (other is null) {
                return false;
            }
            var v1_ = (byte*)UnsafeHandle;
            var v2_ = (byte*)other.UnsafeHandle;
            var ret = g_str_equal(v1_, v2_);
            return ret.IsTrue();
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// </summary>
        public bool Equals(string? other)
        {
            if (other is null) {
                return false;
            }
            return ToString() == other;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Utf8 utf8) {
                return Equals(utf8);
            }
            if (obj is string str) {
                return ToString() == str;
            }
            return false;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(byte* v);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var v_ = (byte*)UnsafeHandle;
            var ret = g_str_hash(v_);
            return (int)ret;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte* g_strdup(byte* str);

        /// <summary>
        /// Creates a copy of the string.
        /// </summary>
        public Utf8 ToUtf8()
        {
            var str_ = (byte*)UnsafeHandle;
            var ret_ = g_strdup(str_);
            var ret = new Utf8((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <inheritdoc/>
        public override string ToString() => Encoding.UTF8.GetString(AsReadOnlySpan());

        /// <summary>
        /// Converts <see cref="UnownedUtf8"/> to <see cref="Utf8"/>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="AsNullableUnownedUtf8"/>.
        /// </remarks>
        public static implicit operator NullableUnownedUtf8(UnownedUtf8 value)
        {
            return value.AsNullableUnownedUtf8();
        }

        /// <summary>
        /// Converts <see cref="UnownedUtf8"/> to <c>string</c>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="ToString()"/>.
        /// </remarks>
        public static implicit operator string(UnownedUtf8 value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(UnownedUtf8)"/>
        /// </remarks>
        public static bool operator ==(UnownedUtf8 a, UnownedUtf8 b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(UnownedUtf8)"/>
        /// </remarks>
        public static bool operator !=(UnownedUtf8 a, UnownedUtf8 b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(UnownedUtf8 a, NullableUnownedUtf8 b)
        {
            if (b.HasValue) {
                return a.Equals(b.Value);
            }
            // a can't be null, so must be false
            return false;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(UnownedUtf8 a, NullableUnownedUtf8 b)
        {
            if (b.HasValue) {
                return !a.Equals(b.Value);
            }
            // a can't be null, so must be true
            return true;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(UnownedUtf8 a, Utf8? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(UnownedUtf8 a, Utf8? b)
        {
            return !a.Equals(b);
        }

        // Needed to keep Utf8 objects alive for string implicit cast;
        static readonly ConditionalWeakTable<string, Utf8> stringMap = new();

        /// <summary>
        /// Converts a managed string to an unowned unmanaged string.
        /// </summary>
        /// <remarks>
        /// The lifetime of the unmanaged string is tied to the managed string.
        /// </remarks>
        public static implicit operator UnownedUtf8(string value)
        {
            return stringMap.GetValue(value, v => new Utf8(v)).AsUnownedUtf8();
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(UnownedUtf8 a, string? b)
        {
            return a.ToString() == b;
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(UnownedUtf8 a, string? b)
        {
            return a.ToString() != b;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(string? a, UnownedUtf8 b)
        {
            return a == b.ToString();
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(string? a, UnownedUtf8 b)
        {
            return a != b.ToString();
        }
    }

    /// <summary>
    /// Represents an <see cref="UnownedUtf8"/> that can possibly be null.
    /// </summary>
    /// <remarks>
    /// This works essentially the same as <c>Nullable&lt;UnownedUtf8&gt;</c> would.
    /// <see cref="Nullable{T}"/> can't be use with <see cref="UnownedUtf8"/>
    /// since it is a <c>ref struct</c>.
    /// </remarks>
    /// <seealso cref="UnownedUtf8"/>
    /// <seealso cref="Utf8"/>
    public unsafe ref struct NullableUnownedUtf8
    {
        readonly UnownedUtf8 value;

        /// <summary>
        /// Pointer to to the unmanaged UTF-8 string if <see cref="HasValue"/>
        /// is <c>true</c>, otherwise <see cref="IntPtr.Zero"/>.
        /// </summary>
        public IntPtr UnsafeHandle => HasValue ? value.UnsafeHandle : IntPtr.Zero;

        /// <summary>
        /// Gets a value indicating whether this instance has a valid value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the value of this instance if it has been assigned a valid
        /// underlying value.
        /// </summary>
        /// <exception name="InvalidOperationException">
        /// The <see cref="HasValue"/> property is <c>false</c>.
        /// </exception>
        public UnownedUtf8 Value {
            get {
                if (!HasValue) {
                    throw new InvalidOperationException();
                }
                return value;
            }
        }

        /// <summary>
        /// Creates a new <see cref="NullableUnownedUtf8"/>.
        /// </summary>
        /// <param name="handle">
        /// Pointer to the unowned unmanaged UTF-8 string or <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="length">
        /// The length of the string or <c>-1</c> if the length is unknown.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NullableUnownedUtf8(IntPtr handle, int length)
        {
            if (handle == IntPtr.Zero) {
                value = default;
                HasValue = false;
            }
            else {
                value = new UnownedUtf8(handle, length);
                HasValue = true;
            }
        }

        /// <summary>
        /// Creates a new <see cref="NullableUnownedUtf8"/>.
        /// </summary>
        /// <param name="handle">
        /// Pointer to the unowned unmanaged UTF-8 string or <c>null</c>.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe NullableUnownedUtf8(byte* handle) : this((IntPtr)handle, -1)
        {
        }

        /// <summary>
        /// Converts an unowned string to a nullable unowned unmanaged string.
        /// </summary>
        public NullableUnownedUtf8(UnownedUtf8 value)
        {
            // protect against NullableUnownedUtf8(default(UnownedUtf8))
            var _ = value.UnsafeHandle;

            this.value = value;
            HasValue = true;
        }

        /// <summary>
        /// Compares str1 and str2 like strcmp(). Handles NULL gracefully by
        /// sorting it before non-NULL strings. Comparing two NULL pointers
        /// returns 0.
        /// </summary>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_strcmp0(byte* str1, byte* str2);

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(NullableUnownedUtf8 other)
        {
            var str1_ = (byte*)UnsafeHandle;
            var str2_ = (byte*)other.UnsafeHandle;
            return g_strcmp0(str1_, str2_) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(UnownedUtf8 other)
        {
            var str1_ = (byte*)UnsafeHandle;
            var str2_ = (byte*)other.UnsafeHandle;
            return g_strcmp0(str1_, str2_) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(Utf8? other)
        {
            var str1_ = (byte*)UnsafeHandle;
            var str2_ = (byte*)(other?.UnsafeHandle ?? IntPtr.Zero);
            return g_strcmp0(str1_, str2_) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(string? other)
        {
            if (other is null) {
                return !HasValue;
            }
            if (!HasValue) {
                return false;
            }
            return Value.Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(object? other)
        {
            if (!HasValue) {
                return other is null;
            }
            if (other is Utf8 utf8) {
                return Value.Equals(utf8);
            }
            if (other is string str) {
                return Value.Equals(str);
            }
            return false;
        }

        /// <summary>
        /// Retrieves the hash code of the object returned by the
        /// <see cref="Value"/> property.
        /// </summary>
        public override int GetHashCode()
        {
            if (HasValue) {
                return value.GetHashCode();
            }
            return 0;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (HasValue) {
                return value.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts a nullable unowned unmanged string to an unowned managed string string.
        /// </summary>
        public static explicit operator UnownedUtf8(NullableUnownedUtf8 value)
        {
            return value.Value;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(NullableUnownedUtf8)"/>
        /// </remarks>
        public static bool operator ==(NullableUnownedUtf8 a, NullableUnownedUtf8 b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(NullableUnownedUtf8)"/>
        /// </remarks>
        public static bool operator !=(NullableUnownedUtf8 a, NullableUnownedUtf8 b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(NullableUnownedUtf8 a, UnownedUtf8 b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(NullableUnownedUtf8 a, UnownedUtf8 b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Utf8)"/>
        /// </remarks>
        public static bool operator ==(NullableUnownedUtf8 a, Utf8? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(Utf8)"/>
        /// </remarks>
        public static bool operator !=(NullableUnownedUtf8 a, Utf8? b)
        {
            return !a.Equals(b);
        }

        // Needed to keep Utf8 objects alive for string implicit cast;
        static readonly ConditionalWeakTable<string, Utf8> stringMap = new();

        /// <summary>
        /// Converts a managed string to an unowned unmanaged string.
        /// </summary>
        /// <remarks>
        /// The lifetime of the unmanaged string is tied to the managed string.
        /// </remarks>
        public static implicit operator NullableUnownedUtf8(string? value)
        {
            if (value is null) {
                return default;
            }
            return stringMap.GetValue(value, v => new Utf8(v)).AsNullableUnownedUtf8();
        }

        /// <summary>
        /// Converts an unowned unmanaged string to a managed string.
        /// </summary>
        public static implicit operator string?(NullableUnownedUtf8 value)
        {
            if (!value.HasValue) {
                return null;
            }
            return value.ToString();
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(string)"/>
        /// </remarks>
        public static bool operator ==(NullableUnownedUtf8 a, string? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(string)"/>
        /// </remarks>
        public static bool operator !=(NullableUnownedUtf8 a, string? b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(string)"/>
        /// </remarks>
        public static bool operator ==(string? a, NullableUnownedUtf8 b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(string)"/>
        /// </remarks>
        public static bool operator !=(string? a, NullableUnownedUtf8 b)
        {
            return !b.Equals(a);
        }
    }

    /// <summary>
    /// Managed wrapper around an owned, null-terminated UTF-8 string in unmanged memory.
    /// </summary>
    /// <seealso cref="UnownedUtf8"/>
    /// <seealso cref="NullableUnownedUtf8"/>
    [GType("gchararray", IsProxyForUnmanagedType = true)]
    [DebuggerDisplay("{Value}")]
    public unsafe class Utf8 : ByteString, IComparable, IComparable<Utf8>, IComparable<string>, IConvertible, IEquatable<string>
    {
        /// <summary>
        /// Enumerator for iterating the bytes of a <see cref="Utf8"/> string.
        /// </summary>
        public readonly struct ByteEnumerable : IEnumerable<byte>, IEnumerable
        {
            private readonly Utf8 utf8;

            internal ByteEnumerable(Utf8 utf8) => this.utf8 = utf8;

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc/>
            public IEnumerator<byte> GetEnumerator()
            {
                byte b;
                for (var i = 0; (b = Marshal.ReadByte(utf8.UnsafeHandle, i)) != 0; i++) {
                    yield return b;
                }
            }
        }

        /// <summary>
        /// Enumerator for iterating the unicode characters of a <see cref="Utf8"/> string.
        /// </summary>
        public readonly struct RuneEnumerable : IEnumerable<Rune>, IEnumerable
        {
            private readonly Utf8 utf8;

            internal RuneEnumerable(Utf8 utf8) => this.utf8 = utf8;

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc/>
            public IEnumerator<Rune> GetEnumerator() => new RuneEnumerator(utf8);

            private struct RuneEnumerator : IEnumerator<Rune>
            {
                private readonly Utf8 utf8;
                private byte* current;

                public RuneEnumerator(Utf8 utf8)
                {
                    this.utf8 = utf8;
                    current = null;
                }

                public Rune Current {
                    get {
                        if (utf8.handle == IntPtr.Zero) {
                            throw new ObjectDisposedException(null);
                        }
                        if (current is null) {
                            throw new InvalidOperationException();
                        }
                        var ret_ = g_utf8_get_char(current);
                        GMarshal.PopUnhandledException();
                        var ret = (Rune)ret_;
                        return ret;
                    }
                }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    // first call
                    if (current is null) {
                        current = (byte*)utf8.UnsafeHandle;
                        return true;
                    }

                    // subsequent calls
                    if (utf8.handle == IntPtr.Zero) {
                        throw new ObjectDisposedException(null);
                    }
                    current = g_utf8_find_next_char(current, null);
                    GMarshal.PopUnhandledException();
                    return *current != default;
                }

                public void Reset()
                {
                    current = null;
                }
            }
        }

        /// <summary>
        /// Convenience property for <c>default(NullableUnownedUtf8)</c> or
        /// <c>new NullableUnownedUtf8(null)</c>
        /// </summary>
        public static NullableUnownedUtf8 Null => default;

        static readonly IntPtr EmptyUtf8 = Marshal.AllocHGlobal(1);

        /// <summary>
        /// Convenience property for getting an empty string.
        /// </summary>
        public static UnownedUtf8 Empty => new(EmptyUtf8, 0);

        /// <summary>
        /// Gets an enumerator for iterating the bytes of this string.
        /// </summary>
        public ByteEnumerable Bytes => new(this);

        /// <summary>
        /// Gets an enumerator for iterating the unicode characters of this string.
        /// </summary>
        public RuneEnumerable Characters => new(this);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte* g_strdup(byte* str);

        [PtrArrayCopyFunc]
        static IntPtr Copy(IntPtr str) => (IntPtr)g_strdup((byte*)str);

        /// <summary>
        /// Creates a new <see cref="Utf8"/> from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// A managed UTF-16 string.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <paramref name="value"/> is converted from UTF-16 to UTF-8 and stored
        /// in unmanaged memory.
        /// </remarks>
        public Utf8(UnownedUtf8 value) : this(value.UnsafeHandle, value.MaybeLength, Transfer.None)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte* g_utf16_to_utf8(
            char* str,
            clong len,
            clong* itemsRead,
            clong* itemsWritten,
            void** error);

        static byte* NewFromManaged(string value)
        {
            fixed (char* value_ = value) {
                var len_ = (clong)value.Length;
                var ret = g_utf16_to_utf8(value_, len_, null, null, null);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Utf8"/> from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// A managed UTF-16 string.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <paramref name="value"/> is converted from UTF-16 to UTF-8 and stored
        /// in unmanaged memory.
        /// </remarks>
        public Utf8(string value) : this((IntPtr)NewFromManaged(value), -1, Transfer.Full)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Utf8(IntPtr handle, Transfer ownership) : this(handle, -1, ownership)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Utf8(IntPtr handle, int length, Transfer ownership) : base(handle, ownership)
        {
            // TODO: save length
            _Value = new(() => Marshal.PtrToStringUTF8(UnsafeHandle)!);
        }

        /// <inheritdoc/>
        public override IntPtr Take()
        {
            var this_ = UnsafeHandle;
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
            return this_;
        }

        [PtrArrayFreeFunc]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_free(void* ptr);

        /// <summary>
        /// Gets an unowned reference to this string.
        /// </summary>
        public UnownedUtf8 AsUnownedUtf8() => new(UnsafeHandle, length);

        /// <summary>
        /// Gets a nullable unowned reference to this string.
        /// </summary>
        public NullableUnownedUtf8 AsNullableUnownedUtf8() => new(UnsafeHandle, length);

        /// <summary>
        /// Gets the managed UTF-16 value of this string.
        /// </summary>
        public string Value => _Value.Value;
        readonly Lazy<string> _Value;

        /// <inheritdoc/>
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Finds the start of the next UTF-8 character in the string after @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte.
        /// </remarks>
        /// <param name="p">
        /// a pointer to a position within a UTF-8 encoded string
        /// </param>
        /// <param name="end">
        /// a pointer to the byte following the end of the string,
        ///     or %NULL to indicate that the string is nul-terminated
        /// </param>
        /// <returns>
        /// a pointer to the found character or %NULL
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern byte* g_utf8_find_next_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* p,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* end);

        /// <summary>
        /// Converts a sequence of bytes encoded as UTF-8 to a Unicode character.
        /// </summary>
        /// <remarks>
        /// If @p does not point to a valid UTF-8 encoded character, results
        /// are undefined. If you are not sure that the bytes are complete
        /// valid Unicode characters, you should use g_utf8_get_char_validated()
        /// instead.
        /// </remarks>
        /// <param name="p">
        /// a pointer to Unicode character encoded as UTF-8
        /// </param>
        /// <returns>
        /// the resulting character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern uint g_utf8_get_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* p);

        /// <summary>
        /// Computes the length of the string in characters, not including
        /// the terminating nul character. If the @max'th byte falls in the
        /// middle of a character, the last (partial) character is not counted.
        /// </summary>
        /// <param name="p">
        /// pointer to the start of a UTF-8 encoded string
        /// </param>
        /// <param name="max">
        /// the maximum number of bytes to examine. If @max
        ///       is less than 0, then the string is assumed to be
        ///       nul-terminated. If @max is 0, @p will not be examined and
        ///       may be %NULL. If @max is greater than 0, up to @max
        ///       bytes are examined
        /// </param>
        /// <returns>
        /// the length of the string in characters
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="GISharp.Runtime.CLong" /> */
        /* transfer-ownership:none direction:out */
        private static extern clong g_utf8_strlen(
            /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
            /* transfer-ownership:none direction:in */
            byte* p,
            /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
            /* transfer-ownership:none direction:in */
            nint max);

        private int lengthInCharacters = -1;

        /// <summary>
        /// Gets the length of the string in Unicode characters.
        /// </summary>
        /// <seealso cref="ByteString.Length"/>
        public int LengthInCharacters {
            get {
                if (lengthInCharacters == -1) {
                    lengthInCharacters = (int)g_utf8_strlen((byte*)UnsafeHandle, -1);
                    GMarshal.PopUnhandledException();
                }
                return lengthInCharacters;
            }
        }

        int IComparable.CompareTo(object? obj)
        {
            if (obj is Utf8 other) {
                return ((IComparable<Utf8>)this).CompareTo(other);
            }
            return Value.CompareTo(obj);
        }

        /// <summary>
        /// Compares str1 and str2 like strcmp(). Handles NULL gracefully by
        /// sorting it before non-NULL strings. Comparing two NULL pointers
        /// returns 0.
        /// </summary>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_strcmp0(byte* str1, byte* str2);

        int IComparable<Utf8>.CompareTo(Utf8? other)
        {
            var str1_ = (byte*)UnsafeHandle;
            var str2_ = (byte*)(other?.UnsafeHandle ?? IntPtr.Zero);
            var ret = g_strcmp0(str1_, str2_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        int IComparable<string>.CompareTo(string? other) => Value.CompareTo(other);

        TypeCode IConvertible.GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider? provider)
        {
            return Value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider? provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_str_equal(byte* v1, byte* v2);

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public bool Equals(Utf8? other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            var this_ = (byte*)UnsafeHandle;
            var other_ = (byte*)other.UnsafeHandle;
            var ret_ = g_str_equal(this_, other_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(string? other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            return Value.Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Utf8 utf8) {
                return Equals(utf8);
            }
            if (obj is string str) {
                return Equals(str);
            }
            return base.Equals(obj);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(byte* v);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var v_ = (byte*)UnsafeHandle;
            var ret = g_str_hash(v_);
            GMarshal.PopUnhandledException();
            return unchecked((int)ret);
        }

        static bool EqualsUtf8(Utf8? a, Utf8? b)
        {
            if (a is null && b is null) {
                return true;
            }
            if (a is null || b is null) {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(Utf8? a, Utf8? b)
        {
            return EqualsUtf8(a, b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(Utf8? a, Utf8? b)
        {
            return !EqualsUtf8(a, b);
        }

        /// <summary>
        /// Converts <see cref="UnownedUtf8"/> to <see cref="Utf8"/>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="Utf8(UnownedUtf8)"/>.
        /// </remarks>
        public static implicit operator Utf8(UnownedUtf8 value)
        {
            return new Utf8(value);
        }

        /// <summary>
        /// Converts <see cref="Utf8"/> to <see cref="UnownedUtf8"/>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="AsUnownedUtf8"/>.
        /// </remarks>
        public static implicit operator UnownedUtf8(Utf8 value)
        {
            return value.AsUnownedUtf8();
        }

        /// <summary>
        /// Converts <see cref="Utf8"/> to <see cref="NullableUnownedUtf8"/>.
        /// </summary>
        public static implicit operator NullableUnownedUtf8(Utf8? value)
        {
            return value is null ? default : new NullableUnownedUtf8(value.AsUnownedUtf8());
        }

        /// <summary>
        /// Converts a unowned unmanaged string to an owned unmanaged string.
        /// </summary>
        public static implicit operator Utf8?(NullableUnownedUtf8 value)
        {
            if (value.HasValue) {
                return value.Value;
            }
            return null;
        }

        /// <summary>
        /// Converts an unmanaged UTF-8 string to a managed UTF-16 string.
        /// </summary>
        public static implicit operator string(Utf8 utf8)
        {
            return utf8.ToString();
        }

        /// <summary>
        /// Converts a managed UTF-16 string to an unmanaged UTF-8 string.
        /// </summary>
        public static implicit operator Utf8(string str)
        {
            return new Utf8(str);
        }

        static bool EqualsString(Utf8? a, string? b)
        {
            if (a is null && b is null) {
                return true;
            }
            if (a is null || b is null) {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(Utf8? a, string? b)
        {
            return EqualsString(a, b);
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(Utf8? a, string? b)
        {
            return !EqualsString(a, b);
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(string? a, Utf8? b)
        {
            return EqualsString(b, a);
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(string? a, Utf8? b)
        {
            return !EqualsString(b, a);
        }
    }

    /// <summary>
    /// Extension methods for <see cref="Utf8"/>.
    /// </summary>
    public static class Utf8Extensions
    {
        /// <summary>
        /// Converts a managed UTF-16 string to an unmanaged UTF-8 string.
        /// </summary>
        public static Utf8 ToUtf8(this string str)
        {
            return new Utf8(str);
        }
    }
}
