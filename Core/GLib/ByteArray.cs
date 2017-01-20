using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.GObject;

namespace GISharp.GLib
{
    /// <summary>
    /// Contains the public fields of a GByteArray.
    /// </summary>
    public sealed class ByteArray : ReferenceCountedOpaque
    {
        ByteArray (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GByteArray.
        /// </summary>
        public ByteArray () : base (New (), Transfer.All)
        {
        }

        /// <summary>
        /// Create byte array containing the data.
        /// </summary>
        /// <param name="data">
        /// byte data for the array
        /// </param>
        [Since("2.32")]
        public ByteArray (Byte[] data) : base (NewTake (data), Transfer.All)
        {
        }

        /// <summary>
        /// Creates a new #GByteArray with <paramref name="reservedSize"/> bytes preallocated.
        /// This avoids frequent reallocation, if you are going to add many
        /// bytes to the array. Note however that the size of the array is still
        /// 0.
        /// </summary>
        /// <param name="reservedSize">
        /// number of bytes preallocated
        /// </param>
        public ByteArray (UInt32 reservedSize) : base (SizedNew (reservedSize), Transfer.All)
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
            var retPtr = g_byte_array_new ();
            return retPtr;
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
            [In] IntPtr data,
            [In] UInt64 len);

        static IntPtr NewTake (Byte[] data)
        {
            if (data == null) {
                throw new ArgumentNullException ("data");
            }
            var dataPtr = GMarshal.Alloc (data.Length);
            Marshal.Copy (data, 0, dataPtr, data.Length);
            var retPtr = g_byte_array_new_take (dataPtr, (ulong)data.Length);
            return retPtr;
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
            [In] UInt32 reservedSize);

        static IntPtr SizedNew (UInt32 reservedSize)
        {
            var retPtr = g_byte_array_sized_new (reservedSize);
            return retPtr;
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
            [In] IntPtr array,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Byte[] data,
            [In] UInt32 len);

        /// <summary>
        /// Adds the given bytes to the end of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Append (Byte[] data)
        {
            AssertNotDisposed ();
            AssertNotDisposed ();
            if (data == null) {
                throw new ArgumentNullException ("data");
            }
            g_byte_array_append (Handle, data, (uint)data.Length);
        }

        /// <summary>
        /// Frees the memory allocated by the #GByteArray. If @freeSegment is
        /// %TRUE it frees the actual byte data. If the reference count of
        /// @array is greater than one, the #GByteArray wrapper is preserved but
        /// the size of @array will be set to zero.
        /// </summary>
        /// <param name="array">
        /// a #GByteArray
        /// </param>
        /// <param name="freeSegment">
        /// if %TRUE the actual byte data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @freeSegment is %FALSE, otherwise
        ///          %NULL.  The element data should be freed using g_free().
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Byte g_byte_array_free(
            [In] IntPtr array,
            [In] Boolean freeSegment);

        /// <summary>
        /// Frees the memory allocated by the #GByteArray. If @freeSegment is
        /// %TRUE it frees the actual byte data. If the reference count of
        /// @array is greater than one, the #GByteArray wrapper is preserved but
        /// the size of @array will be set to zero.
        /// </summary>
        /// <param name="freeSegment">
        /// if %TRUE the actual byte data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @freeSegment is %FALSE, otherwise
        ///          %NULL.  The element data should be freed using g_free().
        /// </returns>
        public Byte Free (Boolean freeSegment)
        {
            AssertNotDisposed ();
            throw new NotImplementedException ();
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
            [In] IntPtr array);

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
//        [Since("2.32")]
//        public GISharp.GLib.Bytes FreeToBytes()
//        {
//            return default(GISharp.GLib.Bytes);
//        }

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
            [In] IntPtr array,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Byte[] data,
            [In] UInt32 len);

        /// <summary>
        /// Adds the given data to the start of the #GByteArray.
        /// The array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the byte data to be added
        /// </param>
        public void Prepend (Byte[] data)
        {
            AssertNotDisposed ();
            if (data == null) {
                throw new ArgumentNullException ("data");
            }
            g_byte_array_prepend (Handle, data, (uint)data.Length);
        }

        /// <summary>
        /// Atomically increments the reference count of @array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// A #GByteArray
        /// </param>
        /// <returns>
        /// The passed in #GByteArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        static extern IntPtr g_byte_array_ref(
            [In] IntPtr array);

        /// <summary>
        /// Atomically increments the reference count of @array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        [Since("2.22")]
        public override void Ref ()
        {
            AssertNotDisposed ();
            g_byte_array_ref (Handle);
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
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray.
        /// The following bytes are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        public void RemoveIndex (Int32 index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            g_byte_array_remove_index (Handle, (uint)index);
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
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the byte at the given index from a #GByteArray. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the #GByteArray. But it is faster
        /// than g_byte_array_remove_index().
        /// </summary>
        /// <param name="index">
        /// the index of the byte to remove
        /// </param>
        public void RemoveIndexFast (Int32 index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            g_byte_array_remove_index_fast (Handle, (uint)index);
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
            [In] IntPtr array,
            [In] UInt32 index,
            [In] UInt32 length);

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
        public void RemoveRange (Int32 index, Int32 length)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            if (length < 0 || index + length > Length) {
                throw new ArgumentOutOfRangeException ("length");
            }
            g_byte_array_remove_range (Handle, (uint)index, (uint)length);
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
            [In] IntPtr array,
            [In] UInt32 length);

        /// <summary>
        /// Sets the size of the #GByteArray, expanding it if necessary.
        /// </summary>
        /// <param name="length">
        /// the new size of the #GByteArray
        /// </param>
        public void SetSize (Int32 length)
        {
            AssertNotDisposed ();
            if (length < 0) {
                throw new ArgumentOutOfRangeException ("length");
            }
            g_byte_array_set_size (Handle, (uint)length);
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
            [In] IntPtr array,
            [In] NativeCompareFunc compareFunc);

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
        public void Sort (CompareFunc<WrappedStruct<byte>> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException ("compareFunc");
            }
            NativeCompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = Opaque.GetInstance<WrappedStruct<byte>> (compareFuncAPtr, Transfer.None);
                var compareFuncB = Opaque.GetInstance<WrappedStruct<byte>> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = compareFunc.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            g_byte_array_sort (Handle, compareFuncNative);
        }

        /// <summary>
        /// Atomically decrements the reference count of @array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is thread-safe and may be called from any
        /// thread.
        /// </summary>
        /// <param name="array">
        /// A #GByteArray
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        static extern void g_byte_array_unref(
            [In] IntPtr array);

        /// <summary>
        /// Atomically decrements the reference count of @array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is thread-safe and may be called from any
        /// thread.
        /// </summary>
        [Since("2.22")]
        public override void Unref ()
        {
            AssertNotDisposed ();
            g_byte_array_unref (Handle);
        }

        public int Length {
            get {
                AssertNotDisposed ();
                return Marshal.ReadInt32 (Handle, IntPtr.Size);
            }
        }

        void AssertIndexInRange (int index)
        {
            if (index < 0 || index >= Length) {
                throw new IndexOutOfRangeException ();
            }
        }
    }
}
