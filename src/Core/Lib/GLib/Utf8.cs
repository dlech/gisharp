using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Lib.GObject;
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
        /// If this points to <c>null</c>, e.g. <c>default(UnownedUtf8).Handle</c>.
        /// </exception>
        public IntPtr Handle => handle is null ? throw new NullReferenceException() : (IntPtr)handle;

        [DllImport("c")]
        static extern UIntPtr strlen(IntPtr s);

        /// <summary>
        /// Gets the length of the string in bytes.
        /// </summary>
        public int Length {
            get {
                if (length < 0) {
                    length = (int)strlen(Handle);
                }
                return length;
            }
        }

        /// <summary>
        /// Creates a new <see cref="UnownedUtf8"/>.
        /// </summary>
        /// <parma name="handle">
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
            if (handle == IntPtr.Zero) {
                throw new ArgumentNullException(nameof(handle));
            }
            this.handle = (byte*)handle;
            this.length = length;
        }

        /// <summary>
        /// Creates a <see cref="NullableUnownedUtf8"/> from this instance.
        /// </summary>
        public NullableUnownedUtf8 AsNullableUnownedUtf8()
        {
            return new NullableUnownedUtf8(this);
        }

        /// <summary>
        /// Creates a <see cref="ReadOnlySpan<byte>"/> of the unmanaged memory.
        /// </summary>
        public ReadOnlySpan<byte> AsReadOnlySpan()
        {
            return new ReadOnlySpan<byte>((byte*)Handle, Length);
        }

        /// <summary>
        /// Creates a <see cref="Utf8Span"/> of the unmanaged memory.
        /// </summary>
        public Utf8Span AsUtf8Span()
        {
            return Utf8Span.UnsafeCreateWithoutValidation(AsReadOnlySpan());
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_str_equal(IntPtr v1, IntPtr v2);

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// <summary>
        public bool Equals(UnownedUtf8 other)
        {
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// <summary>
        public bool Equals(NullableUnownedUtf8 other)
        {
            if (!other.HasValue) {
                return false;
            }
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// <summary>
        public bool Equals(Utf8? other)
        {
            if (other is null) {
                return false;
            }
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// <summary>
        public bool Equals(string? other)
        {
            if (other is null) {
                return false;
            }
            return ToString() == other;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// <summary>
        public unsafe bool Equals(Utf8String? other)
        {
            if (other is null) {
                return false;
            }
            fixed (byte* p = other) {
                var ret = g_str_equal(Handle, (IntPtr)p);
                return ret;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Utf8 utf8) {
                return Equals(utf8);
            }
            if (obj is string str) {
                return ToString() == str;
            }
            if (obj is Utf8String utf8String) {
                return Equals(utf8String);
            }
            return false;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(IntPtr v);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var ret = g_str_hash(Handle);
            return (int)ret;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_strdup(IntPtr str);

        /// <summary>
        /// Creates a copy of the string.
        /// </summary>
        public Utf8 ToUtf8()
        {
            var ret_ = g_strdup(Handle);
            var ret = new Utf8(ret_, Transfer.Full);
            return ret;
        }

        /// <inheritdoc/>
        public override string ToString() => Encoding.UTF8.GetString(AsReadOnlySpan());

        /// <summary>
        /// Converts this instance to a <see cref="Utf8String"/>.
        /// </summary>
        public Utf8String ToUtf8String() => new Utf8String(AsReadOnlySpan());

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
        /// Converts <see cref="UnownedUtf8"/> to <see cref="ToUtf8String"/>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="ToUtf8String"/>.
        /// </remarks>
        public static explicit operator Utf8String(UnownedUtf8 value)
        {
            return value.ToUtf8String();
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
        /// Converts <see cref="UnownedUtf8"/> to <see cref="Utf8Span"/>.
        /// </summary>
        /// <remarks>
        /// This is the equivalent of <see cref="AsUtf8Span"/>.
        /// </remarks>
        public static implicit operator Utf8Span(UnownedUtf8 value)
        {
            return Utf8Span.UnsafeCreateWithoutValidation(value.AsReadOnlySpan());
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

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(UnownedUtf8 a, Utf8String? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(UnownedUtf8 a, Utf8String? b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(Utf8String? a, UnownedUtf8 b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Compares two strings for inequality.
        /// </summary>
        public static bool operator !=(Utf8String? a, UnownedUtf8 b)
        {
            return !b.Equals(a);
        }
    }

    /// <summary>
    /// Represents an <see cref="UnownedUtf8"/> that can possibly be null.
    /// </summary>
    /// <remarks>
    /// This works essentially the same as <c>Nullable<UnownedUtf8></c> would.
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
        public IntPtr Handle => HasValue ? value.Handle : IntPtr.Zero;

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

        public NullableUnownedUtf8(UnownedUtf8 value)
        {
            // protect against NullableUnownedUtf8(default(UnownedUtf8))
            var _ = value.Handle;

            this.value = value;
            HasValue = true;
        }

        public UnownedUtf8 GetValueOrDefault(UnownedUtf8 defaultValue)
        {
            if (HasValue) {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Compares str1 and str2 like strcmp(). Handles NULL gracefully by
        /// sorting it before non-NULL strings. Comparing two NULL pointers
        /// returns 0.
        /// </summary>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_strcmp0(IntPtr str1, IntPtr str2);

        public bool Equals(NullableUnownedUtf8 other)
        {
            return g_strcmp0(Handle, other.Handle) == 0;
        }

        public bool Equals(UnownedUtf8 other)
        {
            return g_strcmp0(Handle, other.Handle) == 0;
        }

        public bool Equals(Utf8? other)
        {
            var otherHandle = other is null ? IntPtr.Zero : other.Handle;
            return g_strcmp0(Handle, otherHandle) == 0;
        }

        public unsafe bool Equals(string? other)
        {
            if (other is null) {
                return !HasValue;
            }
            if (!HasValue) {
                return false;
            }
            return Value.Equals(other);
        }

        public unsafe bool Equals(Utf8String? other)
        {
            fixed (byte* other_ = other) {
                return g_strcmp0(Handle, (IntPtr)other_) == 0;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object other)
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
            // if (other is Utf8String utf8String) {
            //     return Value.Equals(utf8String);
            // }
            return false;
        }

        /// <summary>
        /// Retrieves the hash code of the object returned by the
        /// <see cref="Value"/> property.
        /// <summary>
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
        /// Converts this instance to a <see cref="Utf8String"/>.
        /// </summary>
        public Utf8String ToUtf8String()
        {
            if (HasValue) {
                return value.ToUtf8String();
            }
            return Utf8String.Empty;
        }

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

        public static explicit operator Utf8String?(NullableUnownedUtf8 value)
        {
            if (value.HasValue) {
                return value.ToUtf8String();
            }
            return null;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Utf8String)"/>
        /// </remarks>
        public static bool operator ==(NullableUnownedUtf8 a, Utf8String? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(Utf8String)"/>
        /// </remarks>
        public static bool operator !=(NullableUnownedUtf8 a, Utf8String? b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Utf8String)"/>
        /// </remarks>
        public static bool operator ==(Utf8String? a, NullableUnownedUtf8 b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of to <see cref="Equals(Utf8String)"/>
        /// </remarks>
        public static bool operator !=(Utf8String? a, NullableUnownedUtf8 b)
        {
            return !b.Equals(a);
        }
    }

    /// <summary>
    /// Managed wrapper around an owned, null-terminated UTF-8 string in unmanged memory.
    /// </summary>
    /// <seealso cref="UnownedUtf8"/>
    /// <seealso cref="NullableUnownedUtf8"/>
    [GType(IsProxyForUnmanagedType = true)]
    [DebuggerDisplay("{Value}")]
    public sealed class Utf8 : Opaque, IComparable, IComparable<Utf8>, IComparable<string>, IConvertible, IEquatable<Utf8>, IEquatable<string>
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
                for (var i = 0; (b = Marshal.ReadByte(utf8.Handle, i)) != 0; i++) {
                    yield return b;
                }
            }
        }

        /// <summary>
        /// Enumerator for iterating the unicode characters of a <see cref="Utf8"/> string.
        /// </summary>
        public readonly struct UnicharEnumerable : IEnumerable<Unichar>, IEnumerable
        {
            private readonly Utf8 utf8;

            internal UnicharEnumerable(Utf8 utf8) => this.utf8 = utf8;

            /// <inheritdoc/>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc/>
            public IEnumerator<Unichar> GetEnumerator()
            {
                for (var ptr = utf8.Handle; ptr != IntPtr.Zero; ptr = g_utf8_find_next_char(ptr, IntPtr.Zero)) {
                    var ret = g_utf8_get_char(ptr);
                    if (ret == 0) {
                        // don't return the null terminator
                        yield break;
                    }
                    yield return ret;
                }
            }
        }

        static readonly GType _GType = GType.String;

        private int length = -1;

        /// <summary>
        /// Convenience property for <c>default(NullableUnownedUtf8)</c> or
        /// <c>new NullableUnownedUtf8(null)</c>
        /// </summary>
        public static NullableUnownedUtf8 Null => default;

        static readonly IntPtr EmptyUtf8 = Marshal.AllocHGlobal(1);

        /// <summary>
        /// Convenience property for getting an empty string.
        /// </summary>
        public static UnownedUtf8 Empty => new UnownedUtf8(EmptyUtf8, 0);

        /// <summary>
        /// Gets an enumerator for iterating the bytes of this string.
        /// </summary>
        public ByteEnumerable Bytes => new ByteEnumerable(this);

        /// <summary>
        /// Gets an enumerator for iterating the unicode characters of this string.
        /// </summary>
        public UnicharEnumerable Unichars => new UnicharEnumerable(this);

        [PtrArrayCopyFunc]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_strdup(IntPtr str);

        [PtrArrayFreeFunc]
        static unsafe void Free(IntPtr src) => GMarshal.Free(src);


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
        public Utf8(UnownedUtf8 value) : this(value.Handle, Transfer.None)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_utf16_to_utf8(
            [MarshalAs(UnmanagedType.LPWStr)] string str,
            clong len,
            IntPtr itemsRead,
            IntPtr itemsWritten,
            out IntPtr error);

        static IntPtr New(string value)
        {
            var ret = g_utf16_to_utf8(value, value.Length, IntPtr.Zero, IntPtr.Zero, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            return ret;
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
        public Utf8(string value) : this(New(value), Transfer.Full)
        {
        }

        private unsafe static IntPtr New(Utf8String value)
        {
            if (value is null) {
                throw new ArgumentNullException(nameof(value));
            }

            fixed (byte* p = value) {
                return g_strdup((IntPtr)p);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Utf8"/> from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// An managed UTF-8 string.
        /// </param>
        /// <exception name="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <paramref name="value"/> is copied from managed memory to unmanaged memory.
        /// </remarks>
        public Utf8(Utf8String value) : this(New(value), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new <see cref="Utf8"/> string.
        /// </summary>
        /// <param name="handle">
        /// Pointer to the UTF-8 string in unmanaged memory.
        /// </param>
        /// <param name="ownership">
        /// Indicates if we own <paramref name="handle"/> or not.
        /// </param>
        /// <remarks>
        /// If <paramref name="handle"/> is unowned, a copy of the string is
        /// made.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Utf8(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                this.handle = g_strdup(handle);
            }
            _Value = new Lazy<string>(GetValue);
        }

        /// <inheritdoc/>
        public override IntPtr Take()
        {
            var this_ = Handle;
            handle = IntPtr.Zero;
            GC.SuppressFinalize(this);
            return this_;
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_free(IntPtr ptr);

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_free(handle);
            }
            base.Dispose(disposing);
        }

        public UnownedUtf8 AsUnownedUtf8() => new UnownedUtf8(Handle, length);

        public string Value => _Value.Value;
        readonly Lazy<string> _Value;

        /// </inheritdoc>
        public override string ToString()
        {
            return Value;
        }

        public unsafe Utf8String ToUtf8String()
        {
            return new Utf8String((byte*)Handle);
        }

        string GetValue()
        {
            // TODO: replace this with Marshal.PtrToStringUTF8() when it
            // becomes part of netstandard
            var ret_ = g_utf8_to_utf16(Handle, -1, IntPtr.Zero, IntPtr.Zero, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = GetInstance<Error>(error_, Transfer.Full);
                throw new GErrorException(error);
            }
            var ret = Marshal.PtrToStringUni(ret_);
            g_free(ret_);
            return ret;
        }

        /// <summary>
        /// Converts a string into a form that is independent of case. The
        /// result will not correspond to any particular case, but can be
        /// compared for equality or ordered with the results of calling
        /// g_utf8_casefold() on other strings.
        /// </summary>
        /// <remarks>
        /// Note that calling g_utf8_casefold() followed by g_utf8_collate() is
        /// only an approximation to the correct linguistic case insensitive
        /// ordering, though it is a fairly good one. Getting this exactly
        /// right would require a more sophisticated collation function that
        /// takes case sensitivity into account. GLib does not currently
        /// provide such a function.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is a
        ///   case independent form of @str.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_casefold(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a form that is independent of case. The
        /// result will not correspond to any particular case, but can be
        /// compared for equality or ordered with the results of calling
        /// <see cref="CaseFold"/> on other strings.
        /// </summary>
        /// <remarks>
        /// Note that calling <see cref="CaseFold"/> followed by <see cref="Collate"/> is
        /// only an approximation to the correct linguistic case insensitive
        /// ordering, though it is a fairly good one. Getting this exactly
        /// right would require a more sophisticated collation function that
        /// takes case sensitivity into account. GLib does not currently
        /// provide such a function.
        /// </remarks>
        /// <returns>
        /// a newly allocated string, that is a
        /// case independent form of this string.
        /// </returns>
        public Utf8 CaseFold()
        {
            var ret_ = g_utf8_casefold(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Compares two strings for ordering using the linguistically
        /// correct rules for the [current locale][setlocale].
        /// When sorting a large number of strings, it will be significantly
        /// faster to obtain collation keys with g_utf8_collate_key() and
        /// compare the keys with strcmp() when sorting instead of sorting
        /// the original strings.
        /// </summary>
        /// <param name="str1">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="str2">
        /// a UTF-8 encoded string
        /// </param>
        /// <returns>
        /// &lt; 0 if @str1 compares before @str2,
        ///   0 if they compare equal, &gt; 0 if @str1 compares after @str2.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_utf8_collate(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str1,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str2);

        /// <summary>
        /// Compares two strings for ordering using the linguistically
        /// correct rules for the [current locale][setlocale].
        /// When sorting a large number of strings, it will be significantly
        /// faster to obtain collation keys with <see cref="CollateKey"/> and
        /// compare the keys with <see cref="Compare"/> when sorting instead of sorting
        /// the original strings.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <returns>
        /// &lt; 0 if this string compares before <paramref name="str"/>,
        /// 0 if they compare equal, &gt; 0 if this string compares after
        /// <paramref name="str"/>.
        /// </returns>
        public int Collate(Utf8 str)
        {
            var this_ = Handle;
            var str_ = str.Handle;
            var ret = g_utf8_collate(this_, str_);
            return ret;
        }

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// strcmp().
        /// </summary>
        /// <remarks>
        /// The results of comparing the collation keys of two strings
        /// with strcmp() will always be the same as comparing the two
        /// original keys with g_utf8_collate().
        ///
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string. This string should
        ///   be freed with g_free() when you are done with it.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_collate_key(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// <see cref="Compare"/>
        /// </summary>
        /// <remarks>
        /// The results of comparing the collation keys of two strings
        /// with <see cref="Compare"/> will always be the same as comparing the two
        /// original keys with <see cref="Collate"/>.
        ///
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <returns>
        /// a newly allocated string.
        /// </returns>
        public Utf8 CollateKey()
        {
            var ret_ = g_utf8_collate_key(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using strcmp().
        /// </summary>
        /// <remarks>
        /// In order to sort filenames correctly, this function treats the dot '.'
        /// as a special case. Most dictionary orderings seem to consider it
        /// insignificant, thus producing the ordering "event.c" "eventgenerator.c"
        /// "event.h" instead of "event.c" "event.h" "eventgenerator.c". Also, we
        /// would like to treat numbers intelligently so that "file1" "file10" "file5"
        /// is sorted as "file1" "file5" "file10".
        ///
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string. This string should
        ///   be freed with g_free() when you are done with it.
        /// </returns>
        [Since("2.8")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_collate_key_for_filename(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts a string into a collation key that can be compared
        /// with other collation keys produced by the same function using
        /// <see cref="Compare"/>.
        /// </summary>
        /// <remarks>
        /// In order to sort filenames correctly, this function treats the dot '.'
        /// as a special case. Most dictionary orderings seem to consider it
        /// insignificant, thus producing the ordering "event.c" "eventgenerator.c"
        /// "event.h" instead of "event.c" "event.h" "eventgenerator.c". Also, we
        /// would like to treat numbers intelligently so that "file1" "file10" "file5"
        /// is sorted as "file1" "file5" "file10".
        ///
        /// Note that this function depends on the [current locale][setlocale].
        /// </remarks>
        /// <returns>
        /// a newly allocated string.
        /// </returns>
        [Since("2.8")]
        public Utf8 CollateKeyForFilename()
        {
            var ret_ = g_utf8_collate_key_for_filename(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
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
        static extern IntPtr g_utf8_find_next_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr end);

        /// <summary>
        /// Given a position @p with a UTF-8 encoded string @str, find the start
        /// of the previous UTF-8 character starting before @p. Returns %NULL if no
        /// UTF-8 characters are present in @str before @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte.
        /// </remarks>
        /// <param name="str">
        /// pointer to the beginning of a UTF-8 encoded string
        /// </param>
        /// <param name="p">
        /// pointer to some position within @str
        /// </param>
        /// <returns>
        /// a pointer to the found character or %NULL.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_find_prev_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

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
        static extern Unichar g_utf8_get_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

        /// <summary>
        /// Convert a sequence of bytes encoded as UTF-8 to a Unicode character.
        /// This function checks for incomplete characters, for invalid characters
        /// such as characters that are out of the range of Unicode, and for
        /// overlong encodings of valid characters.
        /// </summary>
        /// <param name="p">
        /// a pointer to Unicode character encoded as UTF-8
        /// </param>
        /// <param name="maxLen">
        /// the maximum number of bytes to read, or -1, for no maximum or
        ///     if @p is nul-terminated
        /// </param>
        /// <returns>
        /// the resulting character. If @p points to a partial
        ///     sequence at the end of a string that could begin a valid
        ///     character (or if @max_len is zero), returns (gunichar)-2;
        ///     otherwise, if @p does not point to a valid UTF-8 encoded
        ///     Unicode character, returns (gunichar)-1.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern Unichar g_utf8_get_char_validated(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr maxLen);

        /// <summary>
        /// Converts a string into canonical form, standardizing
        /// such issues as whether a character with an accent
        /// is represented as a base character and combining
        /// accent or as a single precomposed character. The
        /// string has to be valid UTF-8, otherwise %NULL is
        /// returned. You should generally call g_utf8_normalize()
        /// before comparing two Unicode strings.
        /// </summary>
        /// <remarks>
        /// The normalization mode %G_NORMALIZE_DEFAULT only
        /// standardizes differences that do not affect the
        /// text content, such as the above-mentioned accent
        /// representation. %G_NORMALIZE_ALL also standardizes
        /// the "compatibility" characters in Unicode, such
        /// as SUPERSCRIPT THREE to the standard forms
        /// (in this case DIGIT THREE). Formatting information
        /// may be lost but for most text operations such
        /// characters should be considered the same.
        ///
        /// %G_NORMALIZE_DEFAULT_COMPOSE and %G_NORMALIZE_ALL_COMPOSE
        /// are like %G_NORMALIZE_DEFAULT and %G_NORMALIZE_ALL,
        /// but returned a result with composed forms rather
        /// than a maximally decomposed form. This is often
        /// useful if you intend to convert the string to
        /// a legacy encoding or pass it to a system with
        /// less capable Unicode handling.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string.
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <param name="mode">
        /// the type of normalization to perform.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is the
        ///   normalized form of @str, or %NULL if @str is not
        ///   valid UTF-8.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_normalize(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="NormalizeMode" type="GNormalizeMode" managed-name="NormalizeMode" /> */
            /* transfer-ownership:none */
            NormalizeMode mode);

        /// <summary>
        /// Converts a string into canonical form, standardizing
        /// such issues as whether a character with an accent
        /// is represented as a base character and combining
        /// accent or as a single precomposed character. The
        /// string has to be valid UTF-8, otherwise <c>null</c> is
        /// returned. You should generally call <see cref="Normalize"/>
        /// before comparing two Unicode strings.
        /// </summary>
        /// <remarks>
        /// The normalization mode <see cref="NormalizeMode.Default"/> only
        /// standardizes differences that do not affect the
        /// text content, such as the above-mentioned accent
        /// representation. <see cref="NormalizeMode.All"/> also standardizes
        /// the "compatibility" characters in Unicode, such
        /// as SUPERSCRIPT THREE to the standard forms
        /// (in this case DIGIT THREE). Formatting information
        /// may be lost but for most text operations such
        /// characters should be considered the same.
        ///
        /// <see cref="NormalizeMode.DefaultCompose"/> and <see cref="NormalizeMode.AllCompose"/>
        /// are like <see cref="NormalizeMode.Default"/> and <see cref="NormalizeMode.All"/>,
        /// but returned a result with composed forms rather
        /// than a maximally decomposed form. This is often
        /// useful if you intend to convert the string to
        /// a legacy encoding or pass it to a system with
        /// less capable Unicode handling.
        /// </remarks>
        /// <param name="mode">
        /// the type of normalization to perform.
        /// </param>
        /// <returns>
        /// a newly allocated string, that is the
        /// normalized form of this string, or <c>null</c> if this string is not
        /// valid UTF-8.
        /// </returns>
        public Utf8 Normalize(NormalizeMode mode = NormalizeMode.Default)
        {
            var ret_ = g_utf8_normalize(Handle, IntPtr.Zero, mode);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts from an integer character offset to a pointer to a position
        /// within the string.
        /// </summary>
        /// <remarks>
        /// Since 2.10, this function allows to pass a negative @offset to
        /// step backwards. It is usually worth stepping backwards from the end
        /// instead of forwards if @offset is in the last fourth of the string,
        /// since moving forward is about 3 times faster than moving backward.
        ///
        /// Note that this function doesn't abort when reaching the end of @str.
        /// Therefore you should be sure that @offset is within string boundaries
        /// before calling that function. Call g_utf8_strlen() when unsure.
        /// This limitation exists as this function is called frequently during
        /// text rendering and therefore has to be as fast as possible.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="offset">
        /// a character offset within @str
        /// </param>
        /// <returns>
        /// the resulting pointer
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_offset_to_pointer(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong offset);

        // /// <summary>
        // /// Converts from an integer character offset to a pointer to a position
        // /// within the string.
        // /// </summary>
        // /// <remarks>
        // /// Since 2.10, this function allows to pass a negative @offset to
        // /// step backwards. It is usually worth stepping backwards from the end
        // /// instead of forwards if @offset is in the last fourth of the string,
        // /// since moving forward is about 3 times faster than moving backward.
        // ///
        // /// Note that this function doesn't abort when reaching the end of @str.
        // /// Therefore you should be sure that @offset is within string boundaries
        // /// before calling that function. Call g_utf8_strlen() when unsure.
        // /// This limitation exists as this function is called frequently during
        // /// text rendering and therefore has to be as fast as possible.
        // /// </remarks>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <param name="offset">
        // /// a character offset within @str
        // /// </param>
        // /// <returns>
        // /// the resulting pointer
        // /// </returns>
        // public static Utf8 Utf8OffsetToPointer(Utf8 str, clong offset)
        // {
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var ret_ = g_utf8_offset_to_pointer(str_, offset);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Converts from a pointer to position within a string to a integer
        /// character offset.
        /// </summary>
        /// <remarks>
        /// Since 2.10, this function allows @pos to be before @str, and returns
        /// a negative offset in this case.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="pos">
        /// a pointer to a position within @str
        /// </param>
        /// <returns>
        /// the resulting character offset
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern clong g_utf8_pointer_to_offset(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr pos);

        // /// <summary>
        // /// Converts from a pointer to position within a string to a integer
        // /// character offset.
        // /// </summary>
        // /// <remarks>
        // /// Since 2.10, this function allows @pos to be before @str, and returns
        // /// a negative offset in this case.
        // /// </remarks>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <param name="pos">
        // /// a pointer to a position within @str
        // /// </param>
        // /// <returns>
        // /// the resulting character offset
        // /// </returns>
        // public static clong Utf8PointerToOffset(Utf8 str, Utf8 pos)
        // {
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var pos_ = GMarshal.StringToUtf8Ptr(pos);
        //     var ret = g_utf8_pointer_to_offset(str_, pos_);
        //     try
        //     {
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //         GMarshal.Free(pos_);
        //     }
        // }

        /// <summary>
        /// Finds the previous UTF-8 character in the string before @p.
        /// </summary>
        /// <remarks>
        /// @p does not have to be at the beginning of a UTF-8 character. No check
        /// is made to see if the character found is actually valid other than
        /// it starts with an appropriate byte. If @p might be the first
        /// character of the string, you must use g_utf8_find_prev_char() instead.
        /// </remarks>
        /// <param name="p">
        /// a pointer to a position within a UTF-8 encoded string
        /// </param>
        /// <returns>
        /// a pointer to the found character
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_prev_char(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p);

        // /// <summary>
        // /// Finds the previous UTF-8 character in the string before @p.
        // /// </summary>
        // /// <remarks>
        // /// @p does not have to be at the beginning of a UTF-8 character. No check
        // /// is made to see if the character found is actually valid other than
        // /// it starts with an appropriate byte. If @p might be the first
        // /// character of the string, you must use g_utf8_find_prev_char() instead.
        // /// </remarks>
        // /// <param name="p">
        // /// a pointer to a position within a UTF-8 encoded string
        // /// </param>
        // /// <returns>
        // /// a pointer to the found character
        // /// </returns>
        // public static Utf8 Utf8PrevChar(Utf8 p)
        // {
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_prev_char(p_);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Finds the leftmost occurrence of the given Unicode character
        /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        /// If @len is -1, allow unbounded search.
        /// </summary>
        /// <param name="p">
        /// a nul-terminated UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @p
        /// </param>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %NULL if the string does not contain the character,
        ///     otherwise, a pointer to the start of the leftmost occurrence
        ///     of the character in the string.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strchr(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        // /// <summary>
        // /// Finds the leftmost occurrence of the given Unicode character
        // /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        // /// If @len is -1, allow unbounded search.
        // /// </summary>
        // /// <param name="p">
        // /// a nul-terminated UTF-8 encoded string
        // /// </param>
        // /// <param name="len">
        // /// the maximum length of @p
        // /// </param>
        // /// <param name="c">
        // /// a Unicode character
        // /// </param>
        // /// <returns>
        // /// %NULL if the string does not contain the character,
        // ///     otherwise, a pointer to the start of the leftmost occurrence
        // ///     of the character in the string.
        // /// </returns>
        // public static Utf8 Utf8Strchr(Utf8 p, IntPtr len, int c)
        // {
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_strchr(p_, len, c);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to lowercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string changing.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, with all characters
        ///    converted to lowercase.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strdown(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to lowercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string changing.
        /// </summary>
        /// <returns>
        /// a newly allocated string, with all characters
        /// converted to lowercase.
        /// </returns>
        public Utf8 ToLower()
        {
            var ret_ = g_utf8_strdown(handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

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
        /* <type name="glong" type="glong" managed-name="Glong" /> */
        /* transfer-ownership:none */
        static extern clong g_utf8_strlen(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr max);

        [DllImport("c")]
        static extern UIntPtr strlen(IntPtr s);

        /// <summary>
        /// Gets the length of the string in bytes.
        /// </summary>
        public int Length {
            get {
                if (length == -1) {
                    length = (int)strlen(Handle);
                }
                return length;
            }
        }

        /// <summary>
        /// Like the standard C strncpy() function, but copies a given number
        /// of characters instead of a given number of bytes. The @src string
        /// must be valid UTF-8 encoded text. (Use g_utf8_validate() on all
        /// text before trying to use UTF-8 utility functions with it.)
        /// </summary>
        /// <param name="dest">
        /// buffer to fill with characters from @src
        /// </param>
        /// <param name="src">
        /// UTF-8 encoded string
        /// </param>
        /// <param name="n">
        /// character count
        /// </param>
        /// <returns>
        /// @dest
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strncpy(
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr dest,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr src,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr n);

        // /// <summary>
        // /// Like the standard C strncpy() function, but copies a given number
        // /// of characters instead of a given number of bytes. The @src string
        // /// must be valid UTF-8 encoded text. (Use g_utf8_validate() on all
        // /// text before trying to use UTF-8 utility functions with it.)
        // /// </summary>
        // /// <param name="dest">
        // /// buffer to fill with characters from @src
        // /// </param>
        // /// <param name="src">
        // /// UTF-8 encoded string
        // /// </param>
        // /// <param name="n">
        // /// character count
        // /// </param>
        // /// <returns>
        // /// @dest
        // /// </returns>
        // public static Utf8 Utf8Strncpy(Utf8 dest, Utf8 src, UIntPtr n)
        // {
        //     var dest_ = GMarshal.StringToUtf8Ptr(dest);
        //     var src_ = GMarshal.StringToUtf8Ptr(src);
        //     var ret_ = g_utf8_strncpy(dest_, src_, n);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(dest_);
        //         GMarshal.Free(src_);
        //     }
        // }

        /// <summary>
        /// Find the rightmost occurrence of the given Unicode character
        /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        /// If @len is -1, allow unbounded search.
        /// </summary>
        /// <param name="p">
        /// a nul-terminated UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @p
        /// </param>
        /// <param name="c">
        /// a Unicode character
        /// </param>
        /// <returns>
        /// %NULL if the string does not contain the character,
        ///     otherwise, a pointer to the start of the rightmost occurrence
        ///     of the character in the string.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strrchr(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len,
            /* <type name="gunichar" type="gunichar" managed-name="Gunichar" /> */
            /* transfer-ownership:none */
            Unichar c);

        // /// <summary>
        // /// Find the rightmost occurrence of the given Unicode character
        // /// in a UTF-8 encoded string, while limiting the search to @len bytes.
        // /// If @len is -1, allow unbounded search.
        // /// </summary>
        // /// <param name="p">
        // /// a nul-terminated UTF-8 encoded string
        // /// </param>
        // /// <param name="len">
        // /// the maximum length of @p
        // /// </param>
        // /// <param name="c">
        // /// a Unicode character
        // /// </param>
        // /// <returns>
        // /// %NULL if the string does not contain the character,
        // ///     otherwise, a pointer to the start of the rightmost occurrence
        // ///     of the character in the string.
        // /// </returns>
        // public static Utf8 Utf8Strrchr(Utf8 p, IntPtr len, int c)
        // {
        //     var p_ = GMarshal.StringToUtf8Ptr(p);
        //     var ret_ = g_utf8_strrchr(p_, len, c);
        //     try
        //     {
        //         var ret = GetInstance<Utf8>(ret_, Transfer.Full);
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(p_);
        //     }
        // }

        /// <summary>
        /// Reverses a UTF-8 string. @str must be valid UTF-8 encoded text.
        /// (Use g_utf8_validate() on all text before trying to use UTF-8
        /// utility functions with it.)
        /// </summary>
        /// <remarks>
        /// This function is intended for programmatic uses of reversed strings.
        /// It pays no attention to decomposed characters, combining marks, byte
        /// order marks, directional indicators (LRM, LRO, etc) and similar
        /// characters which might need special handling when reversing a string
        /// for display purposes.
        ///
        /// Note that unlike g_strreverse(), this function returns
        /// newly-allocated memory, which should be freed with g_free() when
        /// no longer needed.
        /// </remarks>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly-allocated string which is the reverse of @str
        /// </returns>
        [Since("2.2")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strreverse(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Reverses a UTF-8 string.
        /// </summary>
        /// <remarks>
        /// This function is intended for programmatic uses of reversed strings.
        /// It pays no attention to decomposed characters, combining marks, byte
        /// order marks, directional indicators (LRM, LRO, etc) and similar
        /// characters which might need special handling when reversing a string
        /// for display purposes.
        /// </remarks>
        /// <returns>
        /// a newly-allocated string which is the reverse of this string
        /// </returns>
        [Since("2.2")]
        public Utf8 Reverse()
        {
            var ret_ = g_utf8_strreverse(Handle, IntPtr.Zero);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to uppercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string increasing. (For instance, the
        /// German ess-zet will be changed to SS.)
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// length of @str, in bytes, or -1 if @str is nul-terminated.
        /// </param>
        /// <returns>
        /// a newly allocated string, with all characters
        ///    converted to uppercase.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_strup(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr len);

        /// <summary>
        /// Converts all Unicode characters in the string that have a case
        /// to uppercase. The exact manner that this is done depends
        /// on the current locale, and may result in the number of
        /// characters in the string increasing. (For instance, the
        /// German ess-zet will be changed to SS.)
        /// </summary>
        /// <returns>
        /// a newly allocated string, with all characters
        /// converted to uppercase.
        /// </returns>
        public Utf8 ToUpper()
        {
            var ret_ = g_utf8_strup(Handle, new IntPtr(-1));
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Copies a substring out of a UTF-8 encoded string.
        /// The substring will contain @end_pos - @start_pos characters.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="startPos">
        /// a character offset within @str
        /// </param>
        /// <param name="endPos">
        /// another character offset within @str
        /// </param>
        /// <returns>
        /// a newly allocated copy of the requested
        ///     substring. Free with g_free() when no longer needed.
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_utf8_substring(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong startPos,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong endPos);

        /// <summary>
        /// Copies a substring out of a UTF-8 encoded string.
        /// The substring will contain <paramref name="endPos"/> -
        /// <paramref name="startPos"/> characters.
        /// </summary>
        /// <param name="startPos">
        /// a character offset within this string
        /// </param>
        /// <param name="endPos">
        /// another character offset within this string
        /// </param>
        /// <returns>
        /// a newly allocated copy of the requested substring.
        /// </returns>
        [Since("2.30")]
        public Utf8 Substring(int startPos, int endPos)
        {
            var ret_ = g_utf8_substring(Handle, startPos, endPos);
            var ret = GetInstance<Utf8>(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Convert a string from UTF-8 to a 32-bit fixed width
        /// representation as UCS-4. A trailing 0 character will be added to the
        /// string after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <param name="itemsRead">
        /// location to store number of bytes read, or %NULL.
        ///     If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        ///     returned in case @str contains a trailing partial
        ///     character. If an error occurs then the index of the
        ///     invalid input is stored here.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store number of characters
        ///     written or %NULL. The value here stored does not include the
        ///     trailing 0 character.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UCS-4 string.
        ///     This value must be freed with g_free(). If an error occurs,
        ///     %NULL will be returned and @error set.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_ucs4(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            clong itemsRead,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            clong itemsWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        // /// <summary>
        // /// Convert a string from UTF-8 to a 32-bit fixed width
        // /// representation as UCS-4. A trailing 0 character will be added to the
        // /// string after the converted text.
        // /// </summary>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <param name="len">
        // /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        // ///     then the string is nul-terminated.
        // /// </param>
        // /// <param name="itemsRead">
        // /// location to store number of bytes read, or %NULL.
        // ///     If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        // ///     returned in case @str contains a trailing partial
        // ///     character. If an error occurs then the index of the
        // ///     invalid input is stored here.
        // /// </param>
        // /// <param name="itemsWritten">
        // /// location to store number of characters
        // ///     written or %NULL. The value here stored does not include the
        // ///     trailing 0 character.
        // /// </param>
        // /// <returns>
        // /// a pointer to a newly allocated UCS-4 string.
        // ///     This value must be freed with g_free(). If an error occurs,
        // ///     %NULL will be returned and @error set.
        // /// </returns>
        // /// <exception name="GErrorException">
        // /// On error
        // /// </exception>
        // public static int Utf8ToUcs4(Utf8 str, clong len, clong itemsRead, clong itemsWritten)
        // {
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     IntPtr error_;
        //     var ret = g_utf8_to_ucs4(handle, IntPtr.Zero, itemsRead, itemsWritten,out error_);
        //     try
        //     {
        //         if (error_ != IntPtr.Zero)
        //         {
        //             var error = GISharp.Runtime.Opaque.GetInstance<Error>(error_, GISharp.Runtime.Transfer.Full);
        //             throw new GErrorException(error);
        //         }

        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Convert a string from UTF-8 to a 32-bit fixed width
        /// representation as UCS-4, assuming valid UTF-8 input.
        /// This function is roughly twice as fast as g_utf8_to_ucs4()
        /// but does no error checking on the input. A trailing 0 character
        /// will be added to the string after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        ///     then the string is nul-terminated.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store the number of
        ///     characters in the result, or %NULL.
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UCS-4 string.
        ///     This value must be freed with g_free().
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gunichar" type="gunichar*" managed-name="Gunichar" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_ucs4_fast(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            clong itemsWritten);

        // /// <summary>
        // /// Convert a string from UTF-8 to a 32-bit fixed width
        // /// representation as UCS-4, assuming valid UTF-8 input.
        // /// This function is roughly twice as fast as g_utf8_to_ucs4()
        // /// but does no error checking on the input. A trailing 0 character
        // /// will be added to the string after the converted text.
        // /// </summary>
        // /// <param name="str">
        // /// a UTF-8 encoded string
        // /// </param>
        // /// <param name="len">
        // /// the maximum length of @str to use, in bytes. If @len &lt; 0,
        // ///     then the string is nul-terminated.
        // /// </param>
        // /// <param name="itemsWritten">
        // /// location to store the number of
        // ///     characters in the result, or %NULL.
        // /// </param>
        // /// <returns>
        // /// a pointer to a newly allocated UCS-4 string.
        // ///     This value must be freed with g_free().
        // /// </returns>
        // public static int Utf8ToUcs4Fast(Utf8 str, clong len, clong itemsWritten)
        // {
        //     var str_ = GMarshal.StringToUtf8Ptr(str);
        //     var ret = g_utf8_to_ucs4_fast(handle, IntPtr.Zero, itemsWritten);
        //     try
        //     {
        //         return ret;
        //     }
        //     finally
        //     {
        //         GMarshal.Free(str_);
        //     }
        // }

        /// <summary>
        /// Convert a string from UTF-8 to UTF-16. A 0 character will be
        /// added to the result after the converted text.
        /// </summary>
        /// <param name="str">
        /// a UTF-8 encoded string
        /// </param>
        /// <param name="len">
        /// the maximum length (number of bytes) of @str to use.
        ///     If @len &lt; 0, then the string is nul-terminated.
        /// </param>
        /// <param name="itemsRead">
        /// location to store number of bytes read,
        ///     or %NULL. If %NULL, then %G_CONVERT_ERROR_PARTIAL_INPUT will be
        ///     returned in case @str contains a trailing partial character. If
        ///     an error occurs then the index of the invalid input is stored here.
        /// </param>
        /// <param name="itemsWritten">
        /// location to store number of #gunichar2
        ///     written, or %NULL. The value stored here does not include the
        ///     trailing 0.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a pointer to a newly allocated UTF-16 string.
        ///     This value must be freed with g_free(). If an error occurs,
        ///     %NULL will be returned and @error set.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint16" type="gunichar2*" managed-name="Guint16" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_utf8_to_utf16(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="glong" type="glong" managed-name="Glong" /> */
            /* transfer-ownership:none */
            clong len,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr itemsRead,
            /* <type name="glong" type="glong*" managed-name="Glong" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr itemsWritten,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            out IntPtr error);

        /// <summary>
        /// Validates UTF-8 encoded text. @str is the text to validate;
        /// if @str is nul-terminated, then @max_len can be -1, otherwise
        /// @max_len should be the number of bytes to validate.
        /// If @end is non-%NULL, then the end of the valid range
        /// will be stored there (i.e. the start of the first invalid
        /// character if some bytes were invalid, or the end of the text
        /// being validated otherwise).
        /// </summary>
        /// <remarks>
        /// Note that g_utf8_validate() returns %FALSE if @max_len is
        /// positive and any of the @max_len bytes are nul.
        ///
        /// Returns %TRUE if all of @str was valid. Many GLib and GTK+
        /// routines require valid UTF-8 as input; so data read from a file
        /// or the network should be checked with g_utf8_validate() before
        /// doing anything else with it.
        /// </remarks>
        /// <param name="str">
        /// a pointer to character data
        /// </param>
        /// <param name="maxLen">
        /// max bytes to validate, or -1 to go until NUL
        /// </param>
        /// <param name="end">
        /// return location for end of valid data
        /// </param>
        /// <returns>
        /// %TRUE if the text was valid UTF-8
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern unsafe Runtime.Boolean g_utf8_validate(
            /* <array length="1" zero-terminated="0" type="gchar*">
             *   <type name="guint8" managed-name="Guint8" />
             * </array> */
            /* transfer-ownership:none */
            IntPtr str,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            IntPtr maxLen,
            /* <type name="utf8" type="const gchar**" managed-name="Utf8" /> */
            /* direction:out caller-allocates:0 transfer-ownership:none optional:1 allow-none:1 */
            IntPtr* end);

        /// <summary>
        /// Validates UTF-8 encoded text.
        /// </summary>
        /// <remarks>
        /// Note that <see cref="Validate"/> returns <c>false</c> if <paramref name="maxLen"/> is
        /// positive and any of the <paramref name="maxLen"/> bytes are nul.
        ///
        /// Returns <c>true</c> if all of this string was valid. Many GLib and GTK+
        /// routines require valid UTF-8 as input; so data read from a file
        /// or the network should be checked with <see cref="Validate"/> before
        /// doing anything else with it.
        /// </remarks>
        /// <param name="maxLen">
        /// max bytes to validate, or -1 to validate the entire string
        /// </param>
        /// <returns>
        /// <c>true</c> if the text was valid UTF-8
        /// </returns>
        public unsafe bool Validate(int maxLen = -1)
        {
            var ret = g_utf8_validate(Handle, new IntPtr(maxLen), null);
            return ret;
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Utf8 other) {
                return ((IComparable<Utf8>)this).CompareTo(other);
            }
            return Value.CompareTo(obj);
        }

        int IComparable<Utf8>.CompareTo(Utf8 other) => Collate(other);

        int IComparable<string>.CompareTo(string other) => Value.CompareTo(other);

        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_str_equal(IntPtr v1, IntPtr v2);

        public bool Equals(Utf8 other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            var this_ = Handle;
            var other_ = other.Handle;
            var ret = g_str_equal(this_, other_);
            return ret;
        }

        public bool Equals(string other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            return Value.Equals(other);
        }

        public unsafe bool Equals(Utf8String other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            var this_ = Handle;
            fixed (byte* other_ = other) {
                var ret = g_str_equal(this_, (IntPtr)other_);
                return ret;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Utf8 utf8) {
                return Equals(utf8);
            }
            if (obj is string str) {
                return Equals(str);
            }
            if (obj is Utf8String utf8String) {
                return Equals(utf8String);
            }
            return base.Equals(obj);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(IntPtr v);

        public override int GetHashCode()
        {
            var ret = g_str_hash(Handle);
            return (int)ret;
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

        public static bool operator ==(Utf8? a, Utf8? b)
        {
            return EqualsUtf8(a, b);
        }

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

        public static implicit operator Utf8?(NullableUnownedUtf8 value)
        {
            if (value.HasValue) {
                return value.Value;
            }
            return null;
        }

        public static implicit operator string(Utf8 utf8)
        {
            return utf8.ToString();
        }

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

        public static bool operator ==(Utf8? a, string? b)
        {
            return EqualsString(a, b);
        }

        public static bool operator !=(Utf8? a, string? b)
        {
            return !EqualsString(a, b);
        }

        public static bool operator ==(string? a, Utf8? b)
        {
            return EqualsString(b, a);
        }

        public static bool operator !=(string? a, Utf8? b)
        {
            return !EqualsString(b, a);
        }

        public unsafe static explicit operator Utf8String(Utf8 utf8)
        {
            return new Utf8String((byte*)utf8.Handle);
        }

        static bool EqualsUtf8String(Utf8? a, Utf8String? b)
        {
            if (a is null && b is null) {
                return true;
            }
            if (a is null || b is null) {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator ==(Utf8? a, Utf8String? b)
        {
            return EqualsUtf8String(a, b);
        }

        public static bool operator !=(Utf8? a, Utf8String? b)
        {
            return !EqualsUtf8String(a, b);
        }

        public static bool operator ==(Utf8String? a, Utf8? b)
        {
            return EqualsUtf8String(b, a);
        }

        public static bool operator !=(Utf8String? a, Utf8? b)
        {
            return !EqualsUtf8String(b, a);
        }
    }

    public static class Utf8Extensions
    {
        public static Utf8 ToUtf8(this string str)
        {
            return new Utf8(str);
        }
    }
}
