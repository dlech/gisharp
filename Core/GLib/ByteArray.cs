using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.GObject;
using System.Collections.Generic;
using System.Collections;

namespace GISharp.GLib
{
    /// <summary>
    /// Contains the public fields of a GByteArray.
    /// </summary>
    [GType ("GByteArray", IsProxyForUnmanagedType = true)]
    public sealed class ByteArray : Boxed, IList<byte>
    {
        static readonly GType GType = g_byte_array_get_type();

        static readonly IntPtr dataOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Data));
        static readonly IntPtr lenOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Len));

        struct Struct
        {
            #pragma warning disable CS0649
            public IntPtr Data;
            public uint Len;
            #pragma warning restore CS0649
        }

        IntPtr Data {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadIntPtr (handle, (int)dataOffset);
                return ret;
            }
        }

        uint Len {
            get {
                AssertNotDisposed ();
                var ret = Marshal.PtrToStructure<uint> (handle + (int)lenOffset);
                return ret;
            }
        }

        public ByteArray(IntPtr handle, Transfer ownership) : base(GType, handle, ownership)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_ref (IntPtr array);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_free (IntPtr array, bool freeSegment);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_byte_array_unref (IntPtr array);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_byte_array_get_type ();

        static GType getGType ()
        {
            return g_byte_array_get_type ();
        }

        /// <summary>
        /// Creates a new <see cref="ByteArray"/>.
        /// </summary>
        public ByteArray () : this (New (), Transfer.Full)
        {
        }

        /// <summary>
        /// Create byte array containing the data.
        /// </summary>
        /// <param name="data">
        /// byte data for the array
        /// </param>
        [Since("2.32")]
        public ByteArray (params byte[] data) : this (NewTake (data), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ByteArray"/> with <paramref name="reservedSize"/> bytes preallocated.
        /// This avoids frequent reallocation, if you are going to add many
        /// bytes to the array. Note however that the size of the array is still 0.
        /// </summary>
        /// <param name="reservedSize">
        /// number of bytes preallocated
        /// </param>
        public ByteArray (int reservedSize) : this (SizedNew (reservedSize), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new #GByteArray with a reference count of 1.
        /// </summary>
        /// <returns>
        /// the new #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_new();

        static IntPtr New ()
        {
            var ret = g_byte_array_new ();
            return ret;
        }

        /// <summary>
        /// Create byte array containing the data. The data will be owned by the array
        /// and will be freed with g_free(), i.e. it could be allocated using g_strdup().
        /// </summary>
        /// <param name="data">
        /// byte data for the array
        /// </param>
        /// <param name="len">
        /// length of @data
        /// </param>
        /// <returns>
        /// a new #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        static extern IntPtr g_byte_array_new_take (
            IntPtr data,
            ulong len);

        static IntPtr NewTake (byte[] data)
        {
            if (data == null) {
                throw new ArgumentNullException (nameof (data));
            }
            var dataPtr = GMarshal.Alloc (data.Length);
            Marshal.Copy (data, 0, dataPtr, data.Length);
            var ret = g_byte_array_new_take (dataPtr, (ulong)data.Length);
            return ret;
        }

        /// <summary>
        /// Creates a new #GByteArray with @reservedSize bytes preallocated.
        /// This avoids frequent reallocation, if you are going to add many
        /// bytes to the array. Note however that the size of the array is still
        /// 0.
        /// </summary>
        /// <param name="reservedSize">
        /// number of bytes preallocated
        /// </param>
        /// <returns>
        /// a new #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_sized_new (
            uint reservedSize);

        static IntPtr SizedNew (int reservedSize)
        {
            if (reservedSize < 0) {
                throw new ArgumentOutOfRangeException (nameof (reservedSize));
            }
            var ret = g_byte_array_sized_new ((uint)reservedSize);
            return ret;
        }

        /// <summary>
        /// Adds the given bytes to the end of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        /// <param name="len">
        /// the number of bytes to add
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_append (
            IntPtr array,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] data,
            uint len);

        /// <summary>
        /// Adds the given bytes to the end of the <see cref="ByteArray"/>.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Append (params byte[] data)
        {
            AssertNotDisposed ();
            if (data == null) {
                throw new ArgumentNullException (nameof (data));
            }
            g_byte_array_append (handle, data, (uint)data.Length);
        }

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        void ICollection<byte>.Add (byte item)
        {
            Append (item);
        }

        /// <summary>
        /// Removes all items from the array.
        /// </summary>
        public void Clear ()
        {
            SetSize (0);
        }

        /// <summary>
        /// Transfers the data from the #GByteArray into a new immutable #GBytes.
        /// </summary>
        /// <remarks>
        /// The #GByteArray is freed unless the reference count of @array is greater
        /// than one, the #GByteArray wrapper is preserved but the size of @array
        /// will be set to zero.
        ///
        /// This is identical to using g_bytes_new_take() and g_byte_array_free()
        /// together.
        /// </remarks>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <returns>
        /// a new immutable #GBytes representing same
        ///     byte data that was in the array
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        static extern IntPtr g_byte_array_free_to_bytes (
            IntPtr array);

        /// <summary>
        /// Adds the given data to the start of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        /// <param name="len">
        /// the number of bytes to add
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_prepend (
            IntPtr array,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] data,
            uint len);

        /// <summary>
        /// Adds the given data to the start of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Prepend (params byte[] data)
        {
            AssertNotDisposed ();
            if (data == null) {
                throw new ArgumentNullException (nameof (data));
            }
            g_byte_array_prepend (handle, data, (uint)data.Length);
        }

        /// <summary>
        /// Insert the specified item at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert (int index, byte item)
        {
            AssertNotDisposed ();
            if (index == Count) {
                Append (item);
                return;
            }
            AssertIndexInRange (index);
            int i = Count;
            for (SetSize (Count + 1); i > index; i--) {
                this[i] = this[i - 1];
            }
            this[i] = item;
        }

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray.
        /// The following bytes are moved down one place.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_remove_index (
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray.
        /// The following bytes are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        public void RemoveAt (int index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            g_byte_array_remove_index (handle, (uint)index);
        }

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the #GByteArray. But it is faster
        /// than g_byte_array_remove_index().
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_remove_index_fast (
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the #GByteArray. But it is faster
        /// than g_byte_array_remove_index().
        /// </summary>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        public void RemoveAtFast (int index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            g_byte_array_remove_index_fast (handle, (uint)index);
        }

        /// <summary>
        /// Removes the given number of bytes starting at the given index from a
        /// #GByteArray.  The following elements are moved to close the gap.
        /// </summary>
        /// <param name="array">
        /// a @GByteArray
        /// </param>
        /// <param name="index">
        /// the index of the first byte to remove
        /// </param>
        /// <param name="length">
        /// the number of bytes to remove
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        static extern IntPtr g_byte_array_remove_range (
            IntPtr array,
            uint index,
            uint length);

        /// <summary>
        /// Removes the given number of bytes starting at the given index from a
        /// #GByteArray.  The following elements are moved to close the gap.
        /// </summary>
        /// <param name="index">
        /// the index of the first byte to remove
        /// </param>
        /// <param name="length">
        /// the number of bytes to remove
        /// </param>
        [Since("2.4")]
        public void RemoveRange (int index, int length)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            if (length < 0 || index + length > Count) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            g_byte_array_remove_range (handle, (uint)index, (uint)length);
        }

        /// <summary>
        /// Remove the first instance of the specified item.
        /// </summary>
        /// <returns><c>true</c> if an item was removed.</returns>
        /// <param name="item">The item to remove.</param>
        public bool Remove (byte item)
        {
            for (int i = 0; i < Count; i++) {
                if (this[i] == item) {
                    RemoveAt (i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the size of the #GByteArray, expanding it if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="length">
        /// the new size of the #GByteArray
        /// </param>
        /// <returns>
        /// the #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_set_size (
            IntPtr array,
            uint length);

        /// <summary>
        /// Sets the size of the #GByteArray, expanding it if necessary.
        /// </summary>
        /// <param name="length">
        /// the new size of the #GByteArray
        /// </param>
        public void SetSize (int length)
        {
            AssertNotDisposed ();
            if (length < 0) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            g_byte_array_set_size (handle, (uint)length);
        }

        /// <summary>
        /// Sorts a byte array, using @compareFunc which should be a
        /// qsort()-style comparison function (returns less than zero for first
        /// arg is less than second arg, zero for equal, greater than zero if
        /// first arg is greater than second arg).
        /// </summary>
        /// <remarks>
        /// If two array elements compare equal, their order in the sorted array
        /// is undefined. If you want equal elements to keep their order (i.e.
        /// you want a stable sort) you can write a comparison function that,
        /// if two elements would otherwise compare equal, compares them by
        /// their addresses.
        /// </remarks>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_byte_array_sort (
            IntPtr array,
            UnmanagedCompareFunc compareFunc);

        /// <summary>
        /// Sorts a byte array, using @compareFunc which should be a
        /// qsort()-style comparison function (returns less than zero for first
        /// arg is less than second arg, zero for equal, greater than zero if
        /// first arg is greater than second arg).
        /// </summary>
        /// <remarks>
        /// If two array elements compare equal, their order in the sorted array
        /// is undefined. If you want equal elements to keep their order (i.e.
        /// you want a stable sort) you can write a comparison function that,
        /// if two elements would otherwise compare equal, compares them by
        /// their addresses.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        public void Sort (Comparison<byte> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }

            UnmanagedCompareFunc compareFunc_ = (a, b) => {
                var x = Marshal.ReadByte (a);
                var y = Marshal.ReadByte (b);
                return compareFunc (x, y);
            };
            g_byte_array_sort (handle, compareFunc_);
            GC.KeepAlive (compareFunc_);
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="ByteArray"/>.
        /// </summary>
        /// <value>The count.</value>
        public int Count {
            get {
                return (int)Len;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ByteArray"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        bool ICollection<byte>.IsReadOnly {
            get {
                AssertNotDisposed ();
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ByteArray"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public byte this[int index] {
            get {
                AssertNotDisposed ();
                AssertIndexInRange (index);
                return Marshal.ReadByte (Data, index);
            }
            set {
                AssertNotDisposed ();
                AssertIndexInRange (index);
                Marshal.WriteByte (Data, index, value);
            }
        }

        /// <summary>
        /// Checks if the array contains the specified item.
        /// </summary>
        /// <returns><c>true</c> if the array contains <paramref name="item"/>.</returns>
        /// <param name="item">The item to search for.</param>
        public bool Contains (byte item)
        {
            return IndexOf (item) >= 0;
        }

        /// <summary>
        /// Indexs the of the first occurance of <paramref name="item"/>.
        /// </summary>
        /// <returns>The index or <c>-1</c> if <paramref name="item"/> was not found.</returns>
        /// <param name="item">The item to search for.</param>
        public int IndexOf (byte item)
        {
            AssertNotDisposed ();
            for (int i = 0; i < Count; i++) {
                if (this[i] == item) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Copies elements of this array to <paramref name="array"/>, starting
        /// at a particular index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The starting index of <paramref name="array"/>.</param>
        public void CopyTo (byte[] array, int arrayIndex)
        {
            AssertNotDisposed ();
            if (array == null) {
                throw new ArgumentNullException (nameof (array));
            }
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException (nameof (arrayIndex));
            }
            if (arrayIndex + Count > array.Length) {
                throw new ArgumentException ("Destination array is not long enough.");
            }
            for (int i = 0; i < Count; i++) {
                array[i + arrayIndex] = this[i];
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

        void AssertIndexInRange (int index)
        {
            if (index < 0 || index >= Count) {
                throw new ArgumentOutOfRangeException ();
            }
        }
    }
}
