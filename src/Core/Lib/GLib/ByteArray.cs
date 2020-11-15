using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.Lib.GObject;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Contains the public fields of a GByteArray.
    /// </summary>
    [GType("GByteArray", IsProxyForUnmanagedType = true)]
    public sealed class ByteArray : Boxed, IReadOnlyList<byte>, IList<byte>
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ByteArray"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// a pointer to the element data. The data may be moved as elements
            /// are added to the GByteArray
            /// </summary>
            internal byte* Data;

            /// <summary>
            /// the number of elements in the GByteArray
            /// </summary>
            internal uint Len;
#pragma warning restore CS0649
        }

        unsafe uint Len => ((UnmanagedStruct*)Handle)->Len;

        /// <summary>
        /// a <see cref="Span{T}"/> of the element data. The data may be moved as elements
        /// are added to the <see cref="ByteArray"/>.
        /// </summary>
        public unsafe Span<byte> Data => new Span<byte>(((UnmanagedStruct*)Handle)->Data, (int)Len);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ByteArray(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_ref(IntPtr array);

        /// <inheritdoc/>
        public override IntPtr Take() => g_byte_array_ref(Handle);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_byte_array_unref(IntPtr array);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_byte_array_get_type();

        static readonly GType _GType = g_byte_array_get_type();

        /// <summary>
        /// Creates a new <see cref="ByteArray"/>.
        /// </summary>
        public ByteArray() : this(New(), Transfer.Full)
        {
        }

        /// <summary>
        /// Create byte array containing the data.
        /// </summary>
        /// <param name="data">
        /// byte data for the array
        /// </param>
        [Since("2.32")]
        public ByteArray(params byte[] data) : this(NewTake(data), Transfer.Full)
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
        public ByteArray(int reservedSize) : this(SizedNew(reservedSize), Transfer.Full)
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

        static IntPtr New()
        {
            var ret = g_byte_array_new();
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
        static extern IntPtr g_byte_array_new_take(
            IntPtr data,
            UIntPtr len);

        static IntPtr NewTake(byte[] data)
        {
            var dataPtr = GMarshal.Alloc(data.Length);
            Marshal.Copy(data, 0, dataPtr, data.Length);
            var ret = g_byte_array_new_take(dataPtr, (UIntPtr)data.Length);
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
        static extern IntPtr g_byte_array_sized_new(
            uint reservedSize);

        static IntPtr SizedNew(int reservedSize)
        {
            if (reservedSize < 0) {
                throw new ArgumentOutOfRangeException(nameof(reservedSize));
            }
            var ret = g_byte_array_sized_new((uint)reservedSize);
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
        static extern IntPtr g_byte_array_append(
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
        public void Append(params byte[] data)
        {
            var this_ = Handle;
            var len = data.Length;
            g_byte_array_append(this_, data, (uint)len);
        }

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        void ICollection<byte>.Add(byte item)
        {
            Append(item);
        }

        /// <summary>
        /// Removes all items from the array.
        /// </summary>
        public void Clear()
        {
            SetSize(0);
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
        static extern IntPtr g_byte_array_free_to_bytes(
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
        static extern IntPtr g_byte_array_prepend(
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
        public void Prepend(params byte[] data)
        {
            var this_ = Handle;
            var len = data.Length;
            g_byte_array_prepend(this_, data, (uint)len);
        }

        /// <summary>
        /// Insert the specified item at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, byte item)
        {
            if (index == Len) {
                Append(item);
                return;
            }
            AssertIndexInRange(index);
            int i = (int)Len;
            for (SetSize((int)Len + 1); i > index; i--) {
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
        static extern IntPtr g_byte_array_remove_index(
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray.
        /// The following bytes are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        public void RemoveAt(int index)
        {
            var this_ = Handle;
            AssertIndexInRange(index);
            g_byte_array_remove_index(this_, (uint)index);
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
        static extern IntPtr g_byte_array_remove_index_fast(
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
        public void RemoveAtFast(int index)
        {
            var this_ = Handle;
            AssertIndexInRange(index);
            g_byte_array_remove_index_fast(this_, (uint)index);
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
        static extern IntPtr g_byte_array_remove_range(
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
        public void RemoveRange(int index, int length)
        {
            var this_ = Handle;
            AssertIndexInRange(index);
            if (length < 0 || index + length > Len) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            g_byte_array_remove_range(this_, (uint)index, (uint)length);
        }

        /// <summary>
        /// Remove the first instance of the specified item.
        /// </summary>
        /// <returns><c>true</c> if an item was removed.</returns>
        /// <param name="item">The item to remove.</param>
        public bool Remove(byte item)
        {
            for (int i = 0; i < Len; i++) {
                if (this[i] == item) {
                    RemoveAt(i);
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
        static extern IntPtr g_byte_array_set_size(
            IntPtr array,
            uint length);

        /// <summary>
        /// Sets the size of the #GByteArray, expanding it if necessary.
        /// </summary>
        /// <param name="length">
        /// the new size of the #GByteArray
        /// </param>
        public void SetSize(int length)
        {
            var this_ = Handle;
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            g_byte_array_set_size(this_, (uint)length);
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
        static extern void g_byte_array_sort(
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
        public void Sort(Comparison<byte> compareFunc)
        {
            var this_ = Handle;
            UnmanagedCompareFunc compareFunc_ = (a, b) => {
                var x = Marshal.ReadByte(a);
                var y = Marshal.ReadByte(b);
                return compareFunc(x, y);
            };
            g_byte_array_sort(this_, compareFunc_);
            GC.KeepAlive(compareFunc_);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_byte_array_free(
            IntPtr array,
            Runtime.Boolean freeSegment);

        /// <summary>
        /// Takes ownership of the unmanaged array.
        /// </summary>
        /// <returns>
        /// Pointer to the array and length of the array.
        /// </returns>
        /// <remarks>
        /// The managed wrapper will become disposed after calling this method.
        /// </remarks>
        public (IntPtr, int) TakeData()
        {
            var length = (int)Len;
            var data = g_byte_array_free(Handle, Runtime.Boolean.False);
            handle = IntPtr.Zero; // object becomes disposed
            GC.SuppressFinalize(this);
            return (data, length);
        }

        /// <summary>
        /// Gets the number of elements in the <see cref="ByteArray"/>.
        /// </summary>
        /// <value>The count.</value>
        public int Count => (int)Len;

        /// <summary>
        /// Gets a value indicating whether this <see cref="ByteArray"/> is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        bool ICollection<byte>.IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="ByteArray"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public byte this[int index] {
            get {
                try {
                    return Data[index];
                }
                catch (IndexOutOfRangeException) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set {
                try {
                    Data[index] = value;
                }
                catch (IndexOutOfRangeException) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        /// <summary>
        /// Checks if the array contains the specified item.
        /// </summary>
        /// <returns><c>true</c> if the array contains <paramref name="item"/>.</returns>
        /// <param name="item">The item to search for.</param>
        public bool Contains(byte item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Gets the index of the first occurrence of <paramref name="item"/>.
        /// </summary>
        /// <returns>The index or <c>-1</c> if <paramref name="item"/> was not found.</returns>
        /// <param name="item">The item to search for.</param>
        public int IndexOf(byte item) => Data.IndexOf(item);

        /// <summary>
        /// Copies elements of this array to <paramref name="array"/>, starting
        /// at a particular index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The starting index of <paramref name="array"/>.</param>
        public void CopyTo(byte[] array, int arrayIndex)
        {
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (arrayIndex + Len > array.Length) {
                throw new ArgumentException("Destination array is not long enough.");
            }
            for (int i = 0; i < Len; i++) {
                array[i + arrayIndex] = this[i];
            }
        }

        IEnumerator<byte> GetEnumerator()
        {
            // TODO: protect against modified array
            for (int i = 0; i < Len; i++) {
                yield return this[i];
            }
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        void AssertIndexInRange(int index)
        {
            if (index < 0 || index >= Len) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Converts a <see cref="ByteArray"/> to a <see cref="ReadOnlySpan{T}"/> of bytes.
        /// </summary>.
        public static implicit operator ReadOnlySpan<byte>(ByteArray array)
        {
            return array.Data;
        }
    }
}
