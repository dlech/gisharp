using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
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
    /// a mutable <see cref="ByteArray"/>, use the <see cref="ByteArray.ToBytes"/> function.
    /// </remarks>
    [Since ("2.32")]
    [GType ("GBytes", IsProxyForUnmanagedType = true)]
    public sealed class Bytes
        : Opaque, IReadOnlyList<byte>, IEquatable<Bytes>, IComparable<Bytes>
    {
        public Bytes (IntPtr handle, Transfer ownership) : base (handle)
        {
            if (ownership == Transfer.None) {
                this.handle = g_bytes_ref (handle);
            }
        }

        protected override void Dispose (bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_bytes_unref (handle);
            }
            base.Dispose (disposing);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_bytes_ref (IntPtr array);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_bytes_unref (IntPtr array);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        static extern GType g_bytes_get_type ();

        static GType getGType ()
        {
            var ret = g_bytes_get_type ();
            return ret;
        }

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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_bytes_new (
            /* <array length="1" zero-terminated="0" type="gconstpointer">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr size);

        [Since ("2.32")]
        static IntPtr New (byte[] data)
        {
            var ret = g_bytes_new (data, (UIntPtr)(data?.Length ?? 0));
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="Bytes"/> from <paramref name="data"/>.
        /// </summary>
        /// <param name="data">
        /// the data to be used for the bytes
        /// </param>
        /// <returns>
        /// a new <see cref="Bytes"/>
        /// </returns>
        [Since ("2.32")]
        public Bytes (byte[] data) : this (New (data), Transfer.Full)
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
        /// <exception name="ArgumentNullException">
        /// If <paramref name="freeFunc"/> is <c>null</c>.
        ///</exception>
        /// <param name="userData">
        /// data to pass to @free_func
        /// </param>
        /// <returns>
        /// a new #GBytes
        /// </returns>
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_bytes_new_with_free_func (
            /* <array length="1" zero-terminated="0" type="gconstpointer">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr data,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr size,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            UnmanagedDestroyNotify freeFunc,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr userData);

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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_bytes_compare (
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
        /// <param name="bytes2">
        /// a <see cref="Bytes"/> to compare with this
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="bytes2"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a negative value if <paramref name="bytes2"/> is lesser, a positive
        /// value if <paramref name="bytes2"/> is
        /// greater, and zero if <paramref name="bytes2"/> is equal to this
        /// </returns>
        [Since ("2.32")]
        public int CompareTo (Bytes bytes2)
        {
            AssertNotDisposed ();
            if (bytes2 == null) {
                throw new ArgumentNullException (nameof (bytes2));
            }
            var bytes2_ = bytes2.handle;
            var ret = g_bytes_compare (handle, bytes2_);
            return ret;
        }

        public static bool operator >= (Bytes one, Bytes two)
        {
            return one.CompareTo (two) >= 0;
        }

        public static bool operator > (Bytes one, Bytes two)
        {
            return one.CompareTo (two) > 0;
        }

        public static bool operator < (Bytes one, Bytes two)
        {
            return one.CompareTo (two) < 0;
        }

        public static bool operator <= (Bytes one, Bytes two)
        {
            return one.CompareTo (two) <= 0;
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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_bytes_equal (
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes1,
            /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes2);

        /// <summary>
        /// Compares the two #GBytes values being pointed to and returns
        /// %TRUE if they are equal.
        /// </summary>
        /// <remarks>
        /// This function can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL #GBytes pointers as keys in a #GHashTable.
        /// </remarks>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <exception name="ArgumentNullException">
        /// If <paramref name="bytes2"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        [Since ("2.32")]
        public bool Equals (Bytes bytes2)
        {
            AssertNotDisposed ();
            if (bytes2 == null) {
                throw new ArgumentNullException (nameof (bytes2));
            }
            var bytes2_ = bytes2.handle;
            var ret = g_bytes_equal (handle, bytes2_);
            return ret;
        }

        public override bool Equals (object obj)
        {
            return Equals (obj as Bytes);
        }

        public static bool operator == (Bytes one, Bytes two)
        {
            if ((object)one == null) {
                return (object)two == null;
            }
            if ((object)two == null) {
                return false;
            }
            return one.Equals (two);
        }

        public static bool operator != (Bytes one, Bytes two)
        {
            return !(one == two);
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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gconstpointer">
            <type name="guint8" managed-name="Guint8" />
            </array> */
        /* transfer-ownership:none nullable:1 */
        static extern IntPtr g_bytes_get_data (
            /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            out UIntPtr size);

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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern UIntPtr g_bytes_get_size (
            /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
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
        [Since ("2.32")]
        public int Count {
            get {
                AssertNotDisposed ();
                var ret = g_bytes_get_size (handle);
                return (int)ret;
            }
        }

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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern int g_bytes_hash (
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
        [Since ("2.32")]
        public override int GetHashCode ()
        {
            AssertNotDisposed ();
            var ret = g_bytes_hash (handle);
            return ret;
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
        [Since ("2.32")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_bytes_new_from_bytes (
            /* <type name="Bytes" type="GBytes*" managed-name="Bytes" /> */
            /* transfer-ownership:none */
            IntPtr bytes,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr offset,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            UIntPtr length);

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
        [Since ("2.32")]
        public Bytes NewFromBytes (int offset, int length)
        {
            AssertNotDisposed ();
            if (offset < 0) {
                throw new ArgumentOutOfRangeException (nameof (offset));
            }
            if (length < 0) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            if (offset + length > Count) {
                throw new ArgumentException ("offset + length exceeds size");
            }
            var ret = g_bytes_new_from_bytes (handle, (UIntPtr)offset, (UIntPtr)length);
            return new Bytes (ret, Transfer.Full);
        }

        public byte this[int index] {
            get {
                AssertNotDisposed ();
                UIntPtr size;
                var dataPtr = g_bytes_get_data (handle, out size);
                if (index < 0 || index >= (int)size) {
                    throw new ArgumentOutOfRangeException (nameof (index));
                }
                var ret = Marshal.ReadByte (dataPtr, index);
                return ret;
            }
        }

        IEnumerable<byte> Enumerate ()
        {
            for (int i = 0; i < Count; i++) {
                yield return this[i];
            }
        }

        public IEnumerator<byte> GetEnumerator ()
        {
            AssertNotDisposed ();
            return Enumerate ().GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            AssertNotDisposed ();
            return Enumerate ().GetEnumerator ();
        }
    }
}
