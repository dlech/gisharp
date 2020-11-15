using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
        public IntPtr Handle => handle == null ? throw new NullReferenceException() : (IntPtr)handle;

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
        /// Creates a <see cref="ReadOnlySpan{T}"/> of the unmanaged memory.
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
        /// </summary>
        public bool Equals(UnownedUtf8 other)
        {
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
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
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
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
            var ret = g_str_equal(Handle, other.Handle);
            return ret;
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

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns
        /// <c>true</c> if they are equal.
        /// </summary>
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
        public override bool Equals(object? obj)
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

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public static bool operator ==(UnownedUtf8 a, Utf8String? b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
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
        /// Compares two strings for byte-by-byte inequality.
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

        /// <summary>
        /// Converts an unowned string to a nullable unowned unmanaged string.
        /// </summary>
        public NullableUnownedUtf8(UnownedUtf8 value)
        {
            // protect against NullableUnownedUtf8(default(UnownedUtf8))
            var _ = value.Handle;

            this.value = value;
            HasValue = true;
        }

        /// <summary>
        /// Compares str1 and str2 like strcmp(). Handles NULL gracefully by
        /// sorting it before non-NULL strings. Comparing two NULL pointers
        /// returns 0.
        /// </summary>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_strcmp0(IntPtr str1, IntPtr str2);

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(NullableUnownedUtf8 other)
        {
            return g_strcmp0(Handle, other.Handle) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(UnownedUtf8 other)
        {
            return g_strcmp0(Handle, other.Handle) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public bool Equals(Utf8? other)
        {
            var otherHandle = other is null ? IntPtr.Zero : other.Handle;
            return g_strcmp0(Handle, otherHandle) == 0;
        }

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
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

        /// <summary>
        /// Compares two strings for equality.
        /// </summary>
        public unsafe bool Equals(Utf8String? other)
        {
            fixed (byte* other_ = other) {
                return g_strcmp0(Handle, (IntPtr)other_) == 0;
            }
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
            // if (other is Utf8String utf8String) {
            //     return Value.Equals(utf8String);
            // }
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
        /// Converts this instance to a <see cref="Utf8String"/>.
        /// </summary>
        public Utf8String ToUtf8String()
        {
            if (HasValue) {
                return value.ToUtf8String();
            }
            return Utf8String.Empty;
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

        /// <summary>
        /// Converts an unowned string to an owned string.
        /// </summary>
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
        public UnicharEnumerable Characters => new UnicharEnumerable(this);

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
        /// A managed UTF-8 string.
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
            _Value = new(GetValue);
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

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_free(handle);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets an unowned reference to this string.
        /// </summary>
        public UnownedUtf8 AsUnownedUtf8() => new UnownedUtf8(Handle, length);

        /// <summary>
        /// Gets a nullable unowned reference to this string.
        /// </summary>
        public NullableUnownedUtf8 AsNullableUnownedUtf8() => new NullableUnownedUtf8(Handle, length);

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
        /// Convers this string to a managed <see cref="Utf8String"/>.
        /// </summary>
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
            return ret!;
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

        [DllImport("c")]
        static extern UIntPtr strlen(IntPtr s);

        private int length = -1;

        /// <summary>
        /// Gets the length of the string in bytes.
        /// </summary>
        /// <seealso cref="LengthInCharacters"/>
        public int Length {
            get {
                if (length == -1) {
                    length = (int)strlen(Handle);
                }
                return length;
            }
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
        /* <type name="glong" type="glong" managed-name="GISharp.Runtime.CLong" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe clong g_utf8_strlen(
            /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
            /* transfer-ownership:none direction:in */
            IntPtr p,
            /* <type name="gssize" type="gssize" managed-name="System.Int32" /> */
            /* transfer-ownership:none direction:in */
            nint max);

        private int lengthInCharacters = -1;

        /// <summary>
        /// Gets the length of the string in Unicode characters.
        /// </summary>
        /// <seealso cref="Length"/>
        public int LengthInCharacters {
            get {
                if (lengthInCharacters == -1) {
                    lengthInCharacters = (int)g_utf8_strlen(Handle, -1);
                }
                return lengthInCharacters;
            }
        }

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
        static extern int g_strcmp0(IntPtr str1, IntPtr str2);

        int IComparable<Utf8>.CompareTo(Utf8? other) => g_strcmp0(Handle, other?.Handle ?? IntPtr.Zero);

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
        static extern Runtime.Boolean g_str_equal(IntPtr v1, IntPtr v2);

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public bool Equals(Utf8? other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            var this_ = Handle;
            var other_ = other.Handle;
            var ret_ = g_str_equal(this_, other_);
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

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public unsafe bool Equals(Utf8String? other)
        {
            if (other is null) {
                throw new ArgumentNullException(nameof(other));
            }

            var this_ = Handle;
            fixed (byte* other_ = other) {
                var ret_ = g_str_equal(this_, (IntPtr)other_);
                var ret = ret_.IsTrue();
                return ret;
            }
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
            if (obj is Utf8String utf8String) {
                return Equals(utf8String);
            }
            return base.Equals(obj);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_str_hash(IntPtr v);

        /// <inheritdoc/>
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

        /// <summary>
        /// Converts an unmanaged UTF-8 string to a managed UTF-8 string.
        /// </summary>
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

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(Utf8? a, Utf8String? b)
        {
            return EqualsUtf8String(a, b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(Utf8? a, Utf8String? b)
        {
            return !EqualsUtf8String(a, b);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality.
        /// </summary>
        public static bool operator ==(Utf8String? a, Utf8? b)
        {
            return EqualsUtf8String(b, a);
        }

        /// <summary>
        /// Compares two strings for byte-by-byte inequality.
        /// </summary>
        public static bool operator !=(Utf8String? a, Utf8? b)
        {
            return !EqualsUtf8String(b, a);
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
