// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes']/*" />
    [GISharp.Runtime.SinceAttribute("2.32")]
    [GISharp.Runtime.GTypeAttribute("GBytes", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class Bytes : GISharp.Runtime.Boxed, System.IComparable<Bytes>, System.IEquatable<Bytes>
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_bytes_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Data']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public System.ReadOnlySpan<byte> Data { get => GetData(); }

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Size']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public int Size { get => GetSize(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Bytes(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_bytes_ref((UnmanagedStruct*)handle);
            }
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_bytes_new(
        /* <array length="1" zero-terminated="0" type="gconstpointer" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* data,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint size);
        static partial void CheckNewArgs(System.ReadOnlySpan<byte> data);

        [GISharp.Runtime.SinceAttribute("2.32")]
        static GISharp.Lib.GLib.Bytes.UnmanagedStruct* New(System.ReadOnlySpan<byte> data)
        {
            fixed (byte* dataData_ = data)
            {
                CheckNewArgs(data);
                var data_ = (byte*)dataData_;
                var size_ = (nuint)data.Length;
                var ret_ = g_bytes_new(data_,size_);
                return ret_;
            }
        }

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Bytes(System.ReadOnlySpan&lt;byte&gt;)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public Bytes(System.ReadOnlySpan<byte> data) : this((System.IntPtr)New(data), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new #GBytes from @data.
        /// </summary>
        /// <remarks>
        /// After this call, @data belongs to the bytes and may no longer be
        /// modified by the caller.  g_free() will be called on @data when the
        /// bytes is no longer in use. Because of this @data must have been created by
        /// a call to g_malloc(), g_malloc0() or g_realloc() or by one of the many
        /// functions that wrap these calls (such as g_new(), g_strdup(), etc).
        /// 
        /// For creating #GBytes with memory from other allocators, see
        /// g_bytes_new_with_free_func().
        /// 
        /// @data may be %NULL if @size is 0.
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_bytes_new_take(
        /* <array length="1" zero-terminated="0" type="gpointer" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:full nullable:1 allow-none:1 direction:in */
        byte* data,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint size);
        static partial void CheckNewTakeArgs(GISharp.Runtime.CArray<byte>? data);

        [GISharp.Runtime.SinceAttribute("2.32")]
        static GISharp.Lib.GLib.Bytes.UnmanagedStruct* NewTake(GISharp.Runtime.CArray<byte>? data)
        {
            CheckNewTakeArgs(data);
            var (dataData_, dataLength_) = data?.TakeData() ?? (System.IntPtr.Zero, 0);
            var data_ = (byte*)dataData_;
            var size_ = (nuint)dataLength_;
            var ret_ = g_bytes_new_take(data_,size_);
            return ret_;
        }

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Bytes(GISharp.Runtime.CArray&lt;byte&gt;?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public Bytes(GISharp.Runtime.CArray<byte>? data) : this((System.IntPtr)NewTake(data), GISharp.Runtime.Transfer.Full)
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
        ///        the data to be used for the bytes
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_bytes_new_with_free_func(
        /* <array length="1" zero-terminated="0" type="gconstpointer" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* data,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint size,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
        /* transfer-ownership:none scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> freeFunc,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Compares the two #GBytes values.
        /// </summary>
        /// <remarks>
        /// This function can be used to sort GBytes instances in lexicographical order.
        /// 
        /// If @bytes1 and @bytes2 have different length but the shorter one is a
        /// prefix of the longer one then the shorter one is considered to be less than
        /// the longer one. Otherwise the first byte where both differ is used for
        /// comparison. If @bytes1 has a smaller value at that position it is
        /// considered less, otherwise greater than @bytes2.
        /// </remarks>
        /// <param name="bytes1">
        /// a pointer to a #GBytes
        /// </param>
        /// <param name="bytes2">
        /// a pointer to a #GBytes to compare with @bytes1
        /// </param>
        /// <returns>
        /// a negative value if @bytes1 is less than @bytes2, a positive value
        ///          if @bytes1 is greater than @bytes2, and zero if @bytes1 is equal to
        ///          @bytes2
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_bytes_compare(
        /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes1,
        /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes2);
        static partial void CheckCompareArgs(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2);

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Compare(GISharp.Lib.GLib.Bytes,GISharp.Lib.GLib.Bytes)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public static int Compare(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2)
        {
            CheckCompareArgs(bytes1, bytes2);
            var bytes1_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)bytes1.UnsafeHandle;
            var bytes2_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)bytes2.UnsafeHandle;
            var ret_ = g_bytes_compare(bytes1_,bytes2_);
            var ret = (int)ret_;
            return ret;
        }

        /// <inheritdoc/>
        /// <seealso cref="GISharp.Lib.GLib.Bytes.Compare"/>
        public System.Int32 CompareTo(GISharp.Lib.GLib.Bytes? other)
        {
            return Compare(this, other ?? throw new System.ArgumentNullException(nameof(other)));
        }

        /// <inheritdoc/>
        public static System.Boolean operator <(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2)
        {
            return Compare(bytes1, bytes2) < 0;
        }

        /// <inheritdoc/>
        public static System.Boolean operator >(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2)
        {
            return Compare(bytes1, bytes2) > 0;
        }

        /// <inheritdoc/>
        public static System.Boolean operator <=(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2)
        {
            return Compare(bytes1, bytes2) <= 0;
        }

        /// <inheritdoc/>
        public static System.Boolean operator >=(GISharp.Lib.GLib.Bytes bytes1, GISharp.Lib.GLib.Bytes bytes2)
        {
            return Compare(bytes1, bytes2) >= 0;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_bytes_get_type();

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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_bytes_equal(
        /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes1,
        /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes2);
        partial void CheckEqualsArgs(GISharp.Lib.GLib.Bytes bytes2);

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.Equals(GISharp.Lib.GLib.Bytes?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public bool Equals(GISharp.Lib.GLib.Bytes? bytes2)
        {
            if (bytes2 is null)
            {
                return false;
            }

            CheckEqualsArgs(bytes2);
            var bytes1_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle;
            var bytes2_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)bytes2.UnsafeHandle;
            var ret_ = g_bytes_equal(bytes1_,bytes2_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <inheritdoc/>
        public override bool Equals(object? other)
        {
            if (other is GISharp.Lib.GLib.Bytes bytes)
            {
                return Equals(bytes);
            }

            return base.Equals(other);
        }

        /// <inheritdoc/>
        public static bool operator ==(GISharp.Lib.GLib.Bytes a, GISharp.Lib.GLib.Bytes b)
        {
            return a.Equals(b);
        }

        /// <inheritdoc/>
        public static System.Boolean operator !=(GISharp.Lib.GLib.Bytes a, GISharp.Lib.GLib.Bytes b)
        {
            return !a.Equals(b);
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gconstpointer" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_bytes_get_data(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        nuint* size);
        partial void CheckGetDataArgs();

        [GISharp.Runtime.SinceAttribute("2.32")]
        private System.ReadOnlySpan<byte> GetData()
        {
            CheckGetDataArgs();
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle;
            nuint size_;
            var ret_ = g_bytes_get_data(bytes_,&size_);
            var ret = new System.ReadOnlySpan<byte>(ret_, (int)size_);
            return ret;
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_bytes_get_size(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes);
        partial void CheckGetSizeArgs();

        [GISharp.Runtime.SinceAttribute("2.32")]
        private int GetSize()
        {
            CheckGetSizeArgs();
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_bytes_get_size(bytes_);
            var ret = (int)ret_;
            return ret;
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint g_bytes_hash(
        /* <type name="Bytes" type="gconstpointer" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes);
        partial void CheckGetHashCodeArgs();

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.GetHashCode()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public override System.Int32 GetHashCode()
        {
            CheckGetHashCodeArgs();
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_bytes_hash(bytes_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a #GBytes which is a subsection of another #GBytes. The @offset +
        /// @length may not be longer than the size of @bytes.
        /// </summary>
        /// <remarks>
        /// A reference to @bytes will be held by the newly created #GBytes until
        /// the byte data is no longer needed.
        /// 
        /// Since 2.56, if @offset is 0 and @length matches the size of @bytes, then
        /// @bytes will be returned with the reference count incremented by 1. If @bytes
        /// is a slice of another #GBytes, then the resulting #GBytes will reference
        /// the same #GBytes instead of @bytes. This allows consumers to simplify the
        /// usage of #GBytes when asynchronously writing to streams.
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
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_bytes_new_from_bytes(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint offset,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        nuint length);
        partial void CheckNewFromBytesArgs(int offset, int length);

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.NewFromBytes(int,int)']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public GISharp.Lib.GLib.Bytes NewFromBytes(int offset, int length)
        {
            CheckNewFromBytesArgs(offset, length);
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle;
            var offset_ = (nuint)offset;
            var length_ = (nuint)length;
            var ret_ = g_bytes_new_from_bytes(bytes_,offset_,length_);
            var ret = GISharp.Lib.GLib.Bytes.GetInstance<GISharp.Lib.GLib.Bytes>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Increase the reference count on @bytes.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// the #GBytes
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Bytes.UnmanagedStruct* g_bytes_ref(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_bytes_ref((GISharp.Lib.GLib.Bytes.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Releases a reference on @bytes.  This may result in the bytes being
        /// freed. If @bytes is %NULL, it will return immediately.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_bytes_unref(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_bytes_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Unreferences the bytes, and returns a new mutable #GByteArray containing
        /// the same byte data.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is transferred to the array without copying
        /// if this was the last reference to bytes and bytes was created with
        /// g_bytes_new(), g_bytes_new_take() or g_byte_array_free_to_bytes(). In all
        /// other cases the data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <returns>
        /// a new mutable #GByteArray containing the same byte data
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.ByteArray" type="GByteArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.ByteArray" is-pointer="1">
*   <type name="guint8" type="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.ByteArray.UnmanagedStruct* g_bytes_unref_to_array(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes);
        partial void CheckUnrefToArrayArgs();

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.UnrefToArray()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public GISharp.Lib.GLib.ByteArray UnrefToArray()
        {
            CheckUnrefToArrayArgs();
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)Take();
            var ret_ = g_bytes_unref_to_array(bytes_);
            var ret = GISharp.Lib.GLib.ByteArray.GetInstance<GISharp.Lib.GLib.ByteArray>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Unreferences the bytes, and returns a pointer the same byte data
        /// contents.
        /// </summary>
        /// <remarks>
        /// As an optimization, the byte data is returned without copying if this was
        /// the last reference to bytes and bytes was created with g_bytes_new(),
        /// g_bytes_new_take() or g_byte_array_free_to_bytes(). In all other cases the
        /// data is copied.
        /// </remarks>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="size">
        /// location to place the length of the returned data
        /// </param>
        /// <returns>
        /// a pointer to the same byte data, which should be
        ///          freed with g_free()
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gpointer" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="guint8" managed-name="System.Byte" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_bytes_unref_to_data(
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.Bytes.UnmanagedStruct* bytes,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        nuint* size);
        partial void CheckUnrefToDataArgs();

        /// <include file="Bytes.xmldoc" path="declaration/member[@name='Bytes.UnrefToData()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public GISharp.Runtime.CArray<byte> UnrefToData()
        {
            CheckUnrefToDataArgs();
            var bytes_ = (GISharp.Lib.GLib.Bytes.UnmanagedStruct*)Take();
            nuint size_;
            var ret_ = g_bytes_unref_to_data(bytes_,&size_);
            var ret = new GISharp.Runtime.CArray<byte>((System.IntPtr)ret_, (int)size_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}