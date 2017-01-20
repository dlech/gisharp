using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using GISharp.Runtime;
using GISharp.GObject;

namespace GISharp.GLib
{
    /// <summary>
    /// Contains the public fields of a GArray.
    /// </summary>
    public sealed class Array<T> : ReferenceCountedOpaque, IList<T> where T : struct
    {
        struct ArrayStruct
        {
            public IntPtr Data;
            public uint Len;
        }

        /// <summary>
        /// Gets the pointer to the unmanaged array data.
        /// </summary>
        public IntPtr Data {
            get {
                AssertNotDisposed ();
                return Marshal.ReadIntPtr (Handle);
            }
        }

        /// <summary>
        /// Gets the size of the elements in this array.
        /// </summary>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [Since("2.22")]
        public Int32 ElementSize {
            get {
                AssertNotDisposed ();
                return (int)ArrayInternal.g_array_get_element_size (Handle);
            }
        }

        Array (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new zero-terminated <see cref="Array{T}"/> with clear set to <c>true</c>.
        /// </summary>
        public Array () : this (true, true, 0)
        {
        }

        static IntPtr New (Boolean zeroTerminated, Boolean clear, UInt32 reservedSize)
        {
            var elementSize = Marshal.SizeOf<T> ();
            IntPtr retPtr;
            if (reservedSize == 0) {
                retPtr = ArrayInternal.g_array_new (zeroTerminated, clear, (uint)elementSize);
            } else {
                retPtr = ArrayInternal.g_array_sized_new (zeroTerminated, clear, (uint)elementSize, reservedSize);
            }
            return retPtr;
        }

        /// <summary>
        /// Creates a new <see cref="Array{T}"/> with <paramref name="reservedSize"/>
        /// elements preallocated. This avoids frequent reallocation, if you
        /// are going to add many elements to the array. Note however that the
        /// size of the array is still 0.
        /// </summary>
        /// <param name="zeroTerminated">
        /// <c>true</c> if the array should have an extra element at
        ///     the end with all bits cleared
        /// </param>
        /// <param name="clear">
        /// <c>true</c> if all bits in the array should be cleared to 0 on
        ///     allocation
        /// </param>
        /// <param name="reservedSize">
        /// number of elements preallocated
        /// </param>
        public Array (Boolean zeroTerminated, Boolean clear, UInt32 reservedSize)
            : this (New (zeroTerminated, clear, reservedSize), Transfer.All)
        {
        }

        /// <summary>
        /// Adds element onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the element to append to the end of the array
        /// </param>
        public void Add (T data)
        {
            AssertNotDisposed ();
            AddRange (data);
        }

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        public void AddRange (params T[] data)
        {
            AssertNotDisposed ();
            var dataPtr = Marshal.AllocHGlobal (ElementSize * data.Length);
            var itemPtr = dataPtr;
            foreach (var item in data) {
                Marshal.StructureToPtr (item, itemPtr, false);
                itemPtr += ElementSize;
            }
            Handle = ArrayInternal.g_array_append_vals (Handle, dataPtr, (uint)data.Length);
            Marshal.FreeHGlobal (dataPtr);
        }

        /// <summary>
        /// Frees the memory allocated for the <see cref="Array{T}"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="freeSegment"/> is
        /// <c>true</c> it frees the memory block holding the elements as well and
        /// also each element if this array has a @element_free_func set. Pass
        /// <c>false</c> if you want to free the <see cref="Array{T}"/> wrapper but preserve the
        /// underlying array for use elsewhere. If the reference count of this array
        /// is greater than one, the <see cref="Array{T}"/> wrapper is preserved but the size
        /// of this array will be set to zero.
        /// 
        /// If array elements contain dynamically-allocated memory, they should
        /// be freed separately.
        /// </remarks>
        /// <param name="freeSegment">
        /// if <c>true</c> the actual element data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @free_segment is <c>false</c>, otherwise
        ///     <c>null</c>. The element data should be freed using g_free().
        /// </returns>
        IntPtr Free (Boolean freeSegment)
        {
            AssertNotDisposed ();
            return ArrayInternal.g_array_free (Handle, freeSegment);
        }

        /// <summary>
        /// Inserts element into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the element at
        /// </param>
        /// <param name="data">
        /// the element to insert
        /// </param>
        public void Insert (Int32 index, T data)
        {
            AssertNotDisposed ();
            InsertRange (index, data);
        }

        /// <summary>
        /// Inserts elements into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the elements at
        /// </param>
        /// <param name="data">
        /// the elements to insert
        /// </param>
        public void InsertRange (Int32 index, params T[] data)
        {
            AssertNotDisposed ();
            AssertInsertIndexInRange (index);
            var dataPtr = Marshal.AllocHGlobal (ElementSize * data.Length);
            var itemPtr = dataPtr;
            foreach (var item in data) {
                Marshal.StructureToPtr (item, itemPtr, false);
                itemPtr += ElementSize;
            }
            Handle = ArrayInternal.g_array_insert_vals (Handle, (uint)index, dataPtr, (uint)data.Length);
            Marshal.FreeHGlobal (dataPtr);
        }

        /// <summary>
        /// Adds elements onto the start of the array.
        /// </summary>
        /// <remarks>
        /// This operation is slower than <see cref="Add"/> since the
        /// existing elements in the array have to be moved to make space for
        /// the new elements.
        /// </remarks>
        /// <param name="data">
        /// the elements to prepend to the start of the array
        /// </param>
        public void Prepend (params T[] data)
        {
            AssertNotDisposed ();
            var dataPtr = Marshal.AllocHGlobal (ElementSize * data.Length);
            var itemPtr = dataPtr;
            foreach (var item in data) {
                Marshal.StructureToPtr (item, itemPtr, false);
                itemPtr += ElementSize;
            }
            Handle = ArrayInternal.g_array_prepend_vals (Handle, dataPtr, (uint)data.Length);
            Marshal.FreeHGlobal (dataPtr);
        }

        /// <summary>
        /// Atomically increments the reference count of this array by one.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        /// <returns>
        /// The passed in <see cref="Array{T}"/>
        /// </returns>
        [Since("2.22")]
        public override void Ref ()
        {
            AssertNotDisposed ();
            ArrayInternal.g_array_ref (Handle);
        }

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>. The following
        /// elements are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        public void RemoveAt (Int32 index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            Handle = ArrayInternal.g_array_remove_index (Handle, (uint)index);
        }

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the <see cref="Array{T}"/>. But it is faster than
        /// g_array_remove_index().
        /// </summary>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        public void RemoveAtFast (Int32 index)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            Handle = ArrayInternal.g_array_remove_index_fast (Handle, (uint)index);
        }

        /// <summary>
        /// Removes the given number of elements starting at the given index
        /// from a <see cref="Array{T}"/>.  The following elements are moved to close the gap.
        /// </summary>
        /// <param name="index">
        /// the index of the first element to remove
        /// </param>
        /// <param name="length">
        /// the number of elements to remove
        /// </param>
        [Since("2.4")]
        public void RemoveAtRange (Int32 index, Int32 length)
        {
            AssertNotDisposed ();
            AssertIndexInRange (index);
            if (length < 0 || index + length > Count) {
                throw new ArgumentOutOfRangeException ("length");
            }
            Handle = ArrayInternal.g_array_remove_range (Handle, (uint)index, (uint)length);
        }

        /// <summary>
        /// Sets a function to clear an element of this array.
        /// </summary>
        /// <remarks>
        /// The @clear_func will be called when an element in the array
        /// data segment is removed and when the array is freed and data
        /// segment is deallocated as well.
        /// 
        /// Note that in contrast with other uses of #GDestroyNotify
        /// functions, @clear_func is expected to clear the contents of
        /// the array element it is given, but not free the element itself.
        /// </remarks>
        /// <param name="clearFunc">
        /// a function to clear an element of this array
        /// </param>
//        [Since("2.32")]
//        public void SetClearFunc(
//            GISharp.GLib.DestroyNotify clearFunc)
//        {
//        }

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with @clear_ set to <c>true</c>, the new elements are set to 0.
        /// </summary>
        /// <param name="length">
        /// the new size of the <see cref="Array{T}"/>
        /// </param>
        public void SetSize (Int32 length)
        {
            AssertNotDisposed ();
            if (length < 0) {
                throw new ArgumentOutOfRangeException ("length");
            }
            Handle = ArrayInternal.g_array_set_size (Handle, (uint)length);
        }

        /// <summary>
        /// Sorts a <see cref="Array{T}"/> using @compare_func which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
//        public void Sort(
//            GISharp.GLib.CompareFunc compareFunc)
//        {
//        }

        /// <summary>
        /// Like g_array_sort(), but the comparison function receives an extra
        /// user data argument.
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// 
        /// There used to be a comment here about making the sort stable by
        /// using the addresses of the elements in the comparison function.
        /// This did not actually work, so any such code should be removed.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
//        public void SortWithData(
//            GISharp.GLib.CompareDataFunc compareFunc)
//        {
//        }

        /// <summary>
        /// Atomically decrements the reference count of this array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is MT-safe and may be called from any
        /// thread.
        [Since("2.22")]
        public override void Unref ()
        {
            AssertNotDisposed ();
            ArrayInternal.g_array_unref (Handle);
        }

        public T this[int index] {
            get {
                AssertNotDisposed ();
                AssertIndexInRange (index);
                var dataPtr = Marshal.ReadIntPtr (Handle);
                dataPtr += Marshal.SizeOf<T> () * index;
                var item = Marshal.PtrToStructure <T> (dataPtr);
                return item;
            }
            set {
                AssertNotDisposed ();
                RemoveAt (index);
                InsertRange (index, value);
            }
        }

        public int Count {
            get {
                AssertNotDisposed ();
                return Marshal.ReadInt32 (Handle, IntPtr.Size);
            }
        }

        /// <summary>
        /// Asserts that the index in range for accessing an existing element.
        /// </summary>
        /// <param name="index">Index.</param>
        void AssertIndexInRange (int index)
        {
            if (index < 0 || index >= Count) {
                throw new IndexOutOfRangeException ();
            }
        }

        /// <summary>
        /// Asserts the set index in range for inserting an element.
        /// </summary>
        /// <param name="index">Index.</param>
        void AssertInsertIndexInRange (int index)
        {
            if (index < 0 || index > Count) {
                throw new IndexOutOfRangeException ();
            }
        }

        public void Clear () {
            AssertNotDisposed ();
            var oldSize = Count;
            SetSize (0);
            SetSize (oldSize);
        }

        public bool Contains (T other)
        {
            AssertNotDisposed ();
            for (int i = 0; i < Count; i++) {
                if (this[i].Equals (other)) {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo (T[] array, Int32 length)
        {
            AssertNotDisposed ();
            if (length < 0 || length > Count) {
                throw new ArgumentOutOfRangeException ("length");
            }
            for (int i = 1; i < length; i++) {
                array[i] = this[i];
            }
        }

        public int IndexOf (T data)
        {
            AssertNotDisposed ();
            for (int i = 0; i < Count; i++) {
                if (this[i].Equals (data)) {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove (T data)
        {
            AssertNotDisposed ();
            for (int i = 0; i < Count; i++) {
                if (this[i].Equals (data)) {
                    RemoveAt (i);
                    return true;
                }
            }
            return false;
        }

        public bool IsReadOnly {
            get {
                AssertNotDisposed ();
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator ()
        {
            AssertNotDisposed ();
            return new ArrayEnumerator (this);
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }

        class ArrayEnumerator : IEnumerator<T>
        {
            readonly Array<T> array;
            int index;

            public T Current {
                get {
                    return array[index];
                }
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            public ArrayEnumerator (Array<T> array)
            {
                this.array = array;
                Reset ();
            }

            public bool MoveNext ()
            {
                index++;
                return index < array.Count;
            }

            public void Reset ()
            {
                index = -1;
            }

            public void Dispose ()
            {
            }
        }
    }

    // Have to have pinvoke methods in separate class because compiler doesn't
    // like them in a generic class.
    static class ArrayInternal
    {
        /// <summary>
        /// Creates a new <see cref="Array{T}"/> with a reference count of 1.
        /// </summary>
        /// <param name="zeroTerminated">
        /// <c>true</c> if the array should have an extra element at
        ///     the end which is set to 0
        /// </param>
        /// <param name="clear">
        /// <c>true</c> if <see cref="Array{T}"/> elements should be automatically cleared
        ///     to 0 when they are allocated
        /// </param>
        /// <param name="elementSize">
        /// the size of each element in bytes
        /// </param>
        /// <returns>
        /// the new <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_new(
            [In] Boolean zeroTerminated,
            [In] Boolean clear,
            [In] UInt32 elementSize);

        /// <summary>
        /// Creates a new <see cref="Array{T}"/> with @reserved_size elements preallocated and
        /// a reference count of 1. This avoids frequent reallocation, if you
        /// are going to add many elements to the array. Note however that the
        /// size of the array is still 0.
        /// </summary>
        /// <param name="zeroTerminated">
        /// <c>true</c> if the array should have an extra element at
        ///     the end with all bits cleared
        /// </param>
        /// <param name="clear">
        /// <c>true</c> if all bits in the array should be cleared to 0 on
        ///     allocation
        /// </param>
        /// <param name="elementSize">
        /// size of each element in the array
        /// </param>
        /// <param name="reservedSize">
        /// number of elements preallocated
        /// </param>
        /// <returns>
        /// the new <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_sized_new(
            [In] Boolean zeroTerminated,
            [In] Boolean clear,
            [In] UInt32 elementSize,
            [In] UInt32 reservedSize);

        /// <summary>
        /// Adds @len elements onto the end of the array.
        /// </summary>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to append to the end of the array
        /// </param>
        /// <param name="len">
        /// the number of elements to append
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_append_vals(
            [In] IntPtr array,
            [In] IntPtr data,
            [In] UInt32 len);

        /// <summary>
        /// Frees the memory allocated for the <see cref="Array{T}"/>. If @free_segment is
        /// <c>true</c> it frees the memory block holding the elements as well and
        /// also each element if this array has a @element_free_func set. Pass
        /// <c>false</c> if you want to free the <see cref="Array{T}"/> wrapper but preserve the
        /// underlying array for use elsewhere. If the reference count of this array
        /// is greater than one, the <see cref="Array{T}"/> wrapper is preserved but the size
        /// of this array will be set to zero.
        /// </summary>
        /// <remarks>
        /// If array elements contain dynamically-allocated memory, they should
        /// be freed separately.
        /// </remarks>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="freeSegment">
        /// if <c>true</c> the actual element data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @free_segment is <c>false</c>, otherwise
        ///     <c>null</c>. The element data should be freed using g_free().
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_free(
            [In] IntPtr array,
            [In] Boolean freeSegment);

        /// <summary>
        /// Gets the size of the elements in this array.
        /// </summary>
        /// <param name="array">
        /// A <see cref="Array{T}"/>
        /// </param>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern UInt32 g_array_get_element_size(
            [In] IntPtr array);

        /// <summary>
        /// Inserts @len elements into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="index">
        /// the index to place the elements at
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to insert
        /// </param>
        /// <param name="len">
        /// the number of elements to insert
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_insert_vals(
            [In] IntPtr array,
            [In] UInt32 index,
            [In] IntPtr data,
            [In] UInt32 len);

        /// <summary>
        /// Adds @len elements onto the start of the array.
        /// </summary>
        /// <remarks>
        /// This operation is slower than g_array_append_vals() since the
        /// existing elements in the array have to be moved to make space for
        /// the new elements.
        /// </remarks>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to prepend to the start of the array
        /// </param>
        /// <param name="len">
        /// the number of elements to prepend
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_prepend_vals(
            [In] IntPtr array,
            [In] IntPtr data,
            [In] UInt32 len);

        /// <summary>
        /// Atomically increments the reference count of this array by one.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// A <see cref="Array{T}"/>
        /// </param>
        /// <returns>
        /// The passed in <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern IntPtr g_array_ref(
            [In] IntPtr array);

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>. The following
        /// elements are moved down one place.
        /// </summary>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_remove_index(
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the <see cref="Array{T}"/>. But it is faster than
        /// g_array_remove_index().
        /// </summary>
        /// <param name="array">
        /// a @GArray
        /// </param>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_remove_index_fast(
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the given number of elements starting at the given index
        /// from a <see cref="Array{T}"/>.  The following elements are moved to close the gap.
        /// </summary>
        /// <param name="array">
        /// a @GArray
        /// </param>
        /// <param name="index">
        /// the index of the first element to remove
        /// </param>
        /// <param name="length">
        /// the number of elements to remove
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        internal static extern IntPtr g_array_remove_range(
            [In] IntPtr array,
            [In] UInt32 index,
            [In] UInt32 length);

        /// <summary>
        /// Sets a function to clear an element of this array.
        /// </summary>
        /// <remarks>
        /// The @clear_func will be called when an element in the array
        /// data segment is removed and when the array is freed and data
        /// segment is deallocated as well.
        /// 
        /// Note that in contrast with other uses of #GDestroyNotify
        /// functions, @clear_func is expected to clear the contents of
        /// the array element it is given, but not free the element itself.
        /// </remarks>
        /// <param name="array">
        /// A <see cref="Array{T}"/>
        /// </param>
        /// <param name="clearFunc">
        /// a function to clear an element of this array
        /// </param>
        //        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        //        [Since("2.32")]
        //        internal static extern void g_array_set_clear_func(
        //            [In] IntPtr array,
        //            [In] GISharp.GLib.DestroyNotify clearFunc);

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with @clear_ set to <c>true</c>, the new elements are set to 0.
        /// </summary>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="length">
        /// the new size of the <see cref="Array{T}"/>
        /// </param>
        /// <returns>
        /// the <see cref="Array{T}"/>
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_array_set_size(
            [In] IntPtr array,
            [In] UInt32 length);
        
        /// <summary>
        /// Sorts a <see cref="Array{T}"/> using @compare_func which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        //        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        //        internal static extern void g_array_sort(
        //            [In] IntPtr array,
        //            [In] GISharp.GLib.CompareFuncNative compareFunc);

        /// <summary>
        /// Like g_array_sort(), but the comparison function receives an extra
        /// user data argument.
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// 
        /// There used to be a comment here about making the sort stable by
        /// using the addresses of the elements in the comparison function.
        /// This did not actually work, so any such code should be removed.
        /// </remarks>
        /// <param name="array">
        /// a <see cref="Array{T}"/>
        /// </param>
        /// <param name="compare_func">
        /// comparison function
        /// </param>
        /// <param name="user_data">
        /// data to pass to @compare_func
        /// </param>
        //        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        //        internal static extern void g_array_sort_with_data(
        //            [In] IntPtr array,
        //            [In] GISharp.GLib.CompareDataFuncNative compareFunc,
        //            [In] IntPtr userData);

        /// <summary>
        /// Atomically decrements the reference count of this array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is MT-safe and may be called from any
        /// thread.
        /// </summary>
        /// <param name="array">
        /// A <see cref="Array{T}"/>
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern void g_array_unref(
            [In] IntPtr array);
    }
}
