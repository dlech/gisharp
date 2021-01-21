// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2021 David Lechner <david@lechnology.com>

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A simple refcounted data type representing an immutable sequence of zero or
    /// more bytes from an unspecified origin.
    /// </summary>
    /// <remarks>
    /// The purpose of a <see cref="Bytes"/> is to keep the memory region that it holds
    /// alive for as long as anyone holds a reference to the bytes.  When
    /// the last reference count is dropped, the memory is released. Multiple
    /// unrelated callers can use byte data in the <see cref="Bytes"/> without coordinating
    /// their activities, resting assured that the byte data will not change or
    /// move while they hold a reference.
    ///
    /// A <see cref="Bytes"/> can come from many different origins that may have
    /// different procedures for freeing the memory region.  Examples are
    /// memory from g_malloc(), from memory slices, from a #GMappedFile or
    /// memory from other allocators.
    ///
    /// #GBytes work well as keys in #GHashTable. Use g_bytes_equal() and
    /// g_bytes_hash() as parameters to g_hash_table_new() or g_hash_table_new_full().
    /// #GBytes can also be used as keys in a #GTree by passing the g_bytes_compare()
    /// function to g_tree_new().
    ///
    /// The data pointed to by this bytes must not be modified. For a mutable
    /// array of bytes see #GByteArray. Use g_bytes_unref_to_array() to create a
    /// mutable array for a #GBytes sequence. To create an immutable <see cref="Bytes"/> from
    /// a mutable <see cref="ByteArray"/>, use the <see cref="M:ByteArray.ToBytes"/> function.
    /// </remarks>
    [Since("2.32")]
    [GType("GBytes", IsProxyForUnmanagedType = true)]
    public sealed class Bytes : Boxed, IReadOnlyList<byte>, IEquatable<Bytes>, IComparable<Bytes>
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Bytes(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_bytes_ref(IntPtr array);

        /// <inheritdoc/>
        public override IntPtr Take() => g_bytes_ref(UnsafeHandle);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_bytes_unref(IntPtr array);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        static extern GType g_bytes_get_type();

        static readonly GType _GType = g_bytes_get_type();

        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// @data is copied. If @size is 0, @data may be %NULL.
        /// </remarks>
        /// <param name="data">
        ///
        ///        the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static unsafe extern IntPtr g_bytes_new(
            /* <array length="1" zero-terminated="0" type="gconstpointer">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            void* data,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint size);

        [Since("2.32")]
        static unsafe IntPtr New(ReadOnlySpan<byte> data)
        {
            fixed (byte* data_ = data) {
                var size_ = (nuint)data.Length;
                var ret_ = g_bytes_new(data_, size_);
                return ret_;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Bytes"/> from <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        /// A copy of the memory is created.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        [Since("2.32")]
        public Bytes(ReadOnlySpan<byte> data) : this(New(data), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// When the last reference is dropped, @free_func will be called with the
        /// @user_data argument.
        ///
        /// @data must not be modified after this call is made until @free_func has
        /// been called to indicate that the bytes is no longer in use.
        ///
        /// @data may be %NULL if @size is 0.
        /// </remarks>
        /// <param name="data">
        ///
        ///           the data to be used for the bytes
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="freeFunc">
        /// the function to call to release the data
        /// </param>
        /// <param name="userData">
        /// data to pass to @free_func
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static unsafe extern IntPtr g_bytes_new_with_free_func(
            /* <array length="1" zero-terminated="0" type="gconstpointer">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            byte* data,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint size,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

        static unsafe IntPtr New(ReadOnlyMemory<byte> data)
        {
            var memoryHandle = data.Pin();
            var data_ = (byte*)memoryHandle.Pointer;
            var size_ = (nuint)data.Length;
            var freeFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&FreeMemoryHandle;
            var userData_ = (IntPtr)GCHandle.Alloc(memoryHandle);
            var ret_ = g_bytes_new_with_free_func(data_, size_, freeFunc_, userData_);
            return ret_;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void FreeMemoryHandle(IntPtr userData_)
        {
            try {
                var gcHandle = GCHandle.FromIntPtr(userData_);
                var memoryHandle = (MemoryHandle)gcHandle.Target!;
                memoryHandle.Dispose();
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Creates a <see cref="Bytes"/> from <paramref name="data"/>.
        /// </summary>
        /// <remarks>
        /// The memory is used directly and must not be modified. For managed
        /// memory, it means that it will be pinned until all references to the
        /// <see cref="Bytes"/> instance have been released.
        /// </remarks>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        public Bytes(ReadOnlyMemory<byte> data) : this(New(data), Transfer.Full) { }

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if bytes2 is lesser, a positive value if bytes2 is
        ///          greater, and zero if bytes2 is equal to bytes1
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_bytes_compare(
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes1,
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes2);

        /// <summary>
        /// Compares the two <see cref="Bytes"/> values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexographical order.
        /// </remarks>
        /// <param name="bytes1">
        /// a <see cref="Bytes"/>
        /// </param>
        /// <param name="bytes2">
        /// a <see cref="Bytes"/> to compare with <paramref name="bytes1"/>
        /// </param>
        /// <returns>
        /// a negative value if <paramref name="bytes2"/> is lesser, a positive
        /// value if <paramref name="bytes2"/> is
        /// greater, and zero if <paramref name="bytes2"/> is equal to <paramref name="bytes1"/>
        /// </returns>
        [Since("2.32")]
        public static int Compare(Bytes bytes1, Bytes bytes2)
        {
            var bytes1_ = bytes1.UnsafeHandle;
            var bytes2_ = bytes2.UnsafeHandle;
            var ret = g_bytes_compare(bytes1_, bytes2_);
            return ret;
        }

        /// <inheritdoc/>
        /// <seealso cref="Compare"/>
        public int CompareTo(Bytes? other)
        {
            return Compare(this, other ?? throw new ArgumentNullException(nameof(other)));
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/>.
        /// </summary>
        public static bool operator >=(Bytes one, Bytes two)
        {
            return Compare(one, two) >= 0;
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/>.
        /// </summary>
        public static bool operator >(Bytes one, Bytes two)
        {
            return Compare(one, two) > 0;
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/>.
        /// </summary>
        public static bool operator <(Bytes one, Bytes two)
        {
            return Compare(one, two) < 0;
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/>.
        /// </summary>
        public static bool operator <=(Bytes one, Bytes two)
        {
            return Compare(one, two) <= 0;
        }

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_bytes_equal(
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes1,
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes2);

        private static bool Equal(Bytes? bytes1, Bytes? bytes2)
        {
            if (bytes1 is null) {
                return bytes2 is null;
            }
            if (bytes2 is null) {
                return false;
            }
            var bytes1_ = bytes1.UnsafeHandle;
            var bytes2_ = bytes2.UnsafeHandle;
            var ret_ = g_bytes_equal(bytes1_, bytes2_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="other">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        [Since("2.32")]
        public bool Equals(Bytes? other)
        {
            return Equal(this, other);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Bytes bytes) {
                return Equals(bytes);
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/> for equality.
        /// </summary>
        public static bool operator ==(Bytes? one, Bytes? two)
        {
            return Equal(one, two);
        }

        /// <summary>
        /// Compares two <see cref="Bytes"/> for inequality.
        /// </summary>
        public static bool operator !=(Bytes? one, Bytes? two)
        {
            return !Equal(one, two);
        }

        /// <summary>
        /// Get the byte data in the #GBytes. This data should not be modified.
        /// </summary>
        /// <remarks>
        /// This function will always return the same pointer for a given #GBytes.
        ///
        /// %NULL may be returned if @size is 0. This is not guaranteed, as the #GBytes
        /// may represent an empty string with @data non-%NULL and @size as 0. %NULL will
        /// not be returned if @size is non-zero.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to return size of byte data
        /// </param>
        /// <returns>
        ///
        ///          a pointer to the byte data, or %NULL
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gconstpointer">
            <type name="guint8" managed-name="Guint8" />
            </array> */
        /* transfer-ownership:none nullable:1 */
        static unsafe extern byte* g_bytes_get_data(
            /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            nuint* size);

        /// <summary>
        /// The array data as a <see cref="ReadOnlySpan{T}"/> of bytes.
        /// </summary>
        public unsafe ReadOnlySpan<byte> Data {
            get {
                var this_ = UnsafeHandle;
                nuint size_;
                var ret_ = g_bytes_get_data(this_, &size_);
                var ret = new ReadOnlySpan<byte>(ret_, (int)size_);
                return ret;
            }
        }

        /// <summary>
        /// Get the size of the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given #GBytes.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the size
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern nuint g_bytes_get_size(
            /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes);

        /// <summary>
        /// Get the size of the byte data in the <see cref="Bytes"/>.
        /// </summary>
        /// <remarks>
        /// This function will always return the same value for a given <see cref="Bytes"/>.
        /// </remarks>
        /// <returns>
        /// the size
        /// </returns>
        [Since("2.32")]
        public int Size {
            get {
                var this_ = UnsafeHandle;
                var ret = g_bytes_get_size(this_);
                return (int)ret;
            }
        }

        int IReadOnlyCollection<byte>.Count => Size;

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes">
        /// a pointer to a #GBytes key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_bytes_hash(
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes);

        /// <summary>
        /// Creates an integer hash code for the byte data in the #GBytes.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_hash_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [Since("2.32")]
        public override int GetHashCode()
        {
            var this_ = UnsafeHandle;
            var ret = g_bytes_hash(this_);
            return (int)ret;
        }

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_bytes_new_from_bytes(
            /* <type name="Bytes" type="IntPtr" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint offset,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint length);

        /// <summary>
        /// Creates a <see cref="Bytes"/> which is a subsection of another
        /// <see cref="Bytes"/>. The <paramref name="offset"/> +
        /// <paramref name="length"/> may not be longer than the size of this.
        /// </summary>
        /// <param name="offset">
        /// offset which subsection starts at
        /// </param>
        /// <param name="length">
        /// length of subsection
        /// </param>
        /// <returns>
        /// a new <see cref="Bytes"/>
        /// </returns>
        [Since("2.32")]
        public Bytes NewFromBytes(int offset, int length)
        {
            var this_ = UnsafeHandle;
            if (offset < 0) {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (offset + length > Size) {
                throw new ArgumentException("offset + length exceeds size");
            }
            var ret_ = g_bytes_new_from_bytes(this_, (nuint)offset, (nuint)length);
            var ret = new Bytes(ret_, Transfer.Full);
            return ret;
        }

        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static unsafe extern IntPtr g_bytes_unref_to_data(IntPtr bytes, UIntPtr* size);

        /// <summary>
        /// Takes ownership of the unmanaged array.
        /// </summary>
        /// <returns>
        /// Pointer to the array and length of the array.
        /// </returns>
        /// <remarks>
        /// The managed wrapper will become disposed after calling this method.
        /// </remarks>
        public unsafe (IntPtr, int) TakeData()
        {
            var this_ = UnsafeHandle;
            handle = IntPtr.Zero; // object becomes disposed
            GC.SuppressFinalize(this);
            UIntPtr size_;
            var data_ = g_bytes_unref_to_data(this_, &size_);
            return (data_, (int)size_);
        }

        /// <summary>
        /// Gets an element in the array.
        /// </summary>
        public byte this[int index] {
            get {
                try {
                    return Data[index];
                }
                catch (IndexOutOfRangeException) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < (int)Size; i++) {
                yield return this[i];
            }
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
