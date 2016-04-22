using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using GISharp.Core;
using GISharp.GObject;

namespace GISharp.GLib
{

    /// <summary>
    /// Contains the public fields of a pointer array.
    /// </summary>
    public sealed class PtrArray<T> : ReferenceCountedOpaque, IList<T> where T : Opaque
    {
        NativeDestroyNotify elementFreeFuncNative;

        public PtrArray (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static IntPtr New ()
        {
            var retPtr = PtrArrayInternal.g_ptr_array_new ();
            return retPtr;
        }

        /// <summary>
        /// Creates a new <see cref="PtrArray{T}"/>.
        /// </summary>
        public PtrArray () : this (New (), Transfer.All)
        {
        }

        static IntPtr NewFull (UInt32 reservedSize, DestroyNotify<T> elementFreeFunc)
        {
            if (elementFreeFunc == null) {
                throw new ArgumentNullException ("elementFreeFunc");
            }
            // TODO: this callback will be garbage collected before we are done with it
            NativeDestroyNotify elementFreeFuncNative = (elementFreeFuncDataPtr) => {
                var elementFreeFuncData = Opaque.GetInstance<T> (elementFreeFuncDataPtr, Transfer.None);
                elementFreeFunc (elementFreeFuncData);
            };
            var retPtr = PtrArrayInternal.g_ptr_array_new_full (reservedSize, elementFreeFuncNative);
            return retPtr;
        }

        /// <summary>
        /// Creates a new <see cref="PtrArray{T}"/> with <paramref name="reservedSize"/> pointers preallocated
        /// and a reference count of 1. This avoids frequent reallocation, if
        /// you are going to add many pointers to the array. Note however that
        /// the size of the array is still 0. It also set @elementFreeFunc
        /// for freeing each element when the array is destroyed either via
        /// g_ptr_array_unref(), when g_ptr_array_free() is called with
        /// @freeSegment set to <c>true</c> or when removing elements.
        /// </summary>
        /// <param name="reservedSize">
        /// number of pointers preallocated
        /// </param>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy this array or <c>null</c>
        /// </param>
        [Since("2.30")]
        public PtrArray (UInt32 reservedSize, DestroyNotify<T> elementFreeFunc)
            : this (NewFull (reservedSize, elementFreeFunc), Transfer.All)
        {
        }

        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        public void Add (T data)
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_add (Handle, data.Handle);
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="PtrArray{T}"/>.
        /// </summary>
        /// <param name="func">
        /// the function to call for each array element
        /// </param>
        [Since("2.4")]
        public void Foreach (Func<T> func)
        {
            AssertNotDisposed ();
            NativeFunc funcNative = (funcDataPtr, funcUserDataPtr) => {
                var funcData = Opaque.GetInstance<T> (funcDataPtr, Transfer.None);
                func.Invoke (funcData);
            };
            PtrArrayInternal.g_ptr_array_foreach (Handle, funcNative, IntPtr.Zero);
        }

        /// <summary>
        /// Frees the memory allocated for the <see cref="PtrArray{T}"/>.
        /// If <paramref name="freeSeg"/> is <c>true</c>
        /// it frees the memory block holding the elements as well. Pass <c>false</c>
        /// if you want to free the <see cref="PtrArray{T}"/> wrapper but preserve the
        /// underlying array for use elsewhere. If the reference count of this array
        /// is greater than one, the <see cref="PtrArray{T}"/> wrapper is preserved but the
        /// size of this array will be set to zero.
        /// </summary>
        /// <remarks>
        /// If array contents point to dynamically-allocated memory, they should
        /// be freed separately if <paramref name="freeSeg"/> is <c>true</c> and
        /// no <see cref="DestroyNotify{T}"/>
        /// function has been set for <c>false</c>.
        /// </remarks>
        /// <param name="freeSeg">
        /// if <c>true</c> the actual pointer array is freed as well
        /// </param>
        /// <returns>
        /// the pointer array if <paramref name="freeSeg"/> is <c>false</c>, otherwise <c>IntPtr.Zero</c>.
        ///     The pointer array should be freed using g_free().
        /// </returns>
        public IntPtr Free (Boolean freeSeg)
        {
            AssertNotDisposed ();
            var ret = PtrArrayInternal.g_ptr_array_free (Handle, freeSeg);
            return ret;
        }

        /// <summary>
        /// Inserts an element into the pointer array at the given index. The
        /// array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="index">
        /// the index to place the new element at, or -1 to append
        /// </param>
        /// <param name="data">
        /// the pointer to add.
        /// </param>
        [Since("2.40")]
        public void Insert (Int32 index, T data)
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_insert (Handle, index, data.Handle);
        }

        /// <summary>
        /// Atomically increments the reference count of this array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        /// <returns>
        /// The passed in <see cref="PtrArray{T}"/>
        /// </returns>
        [Since("2.22")]
        internal protected override void Ref()
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_ref (Handle);
        }

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The following elements are moved down one place. If this array
        /// has a non-<c>null</c> <see cref="DestroyNotify{T}"/>  function it is called for the
        /// removed element.
        /// </summary>
        /// <remarks>
        /// It returns <c>true</c> if the pointer was removed, or <c>false</c> if the
        /// pointer was not found.
        /// </remarks>
        /// <param name="data">
        /// the pointer to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the pointer is removed, <c>false</c> if the pointer
        ///     is not found in the array
        /// </returns>
        public Boolean Remove (T data)
        {
            AssertNotDisposed ();
            var ret = PtrArrayInternal.g_ptr_array_remove (Handle, data.Handle);
            return ret;
        }

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The last element in the array is used to fill in the space,
        /// so this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove(). If this array has a non-<c>null</c>
        /// <see cref="DestroyNotify{T}"/> function it is called for the removed element.
        /// </summary>
        /// <remarks>
        /// It returns <c>true</c> if the pointer was removed, or <c>false</c> if the
        /// pointer was not found.
        /// </remarks>
        /// <param name="data">
        /// the pointer to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the pointer was found in the array
        /// </returns>
        public Boolean RemoveFast (T data)
        {
            AssertNotDisposed ();
            var ret = PtrArrayInternal.g_ptr_array_remove_fast (Handle, data.Handle);
            return ret;
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The following elements are moved down one place. If this array has
        /// a non-<c>null</c> <see cref="DestroyNotify{T}"/> function it is called for the removed
        /// element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        public T RemoveIndex (Int32 index)
        {
            AssertNotDisposed ();
            var retPtr = PtrArrayInternal.g_ptr_array_remove_index (Handle, (uint)index);
            var ret = Opaque.GetInstance<T> (retPtr, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The last element in the array is used to fill in the space, so
        /// this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove_index(). If this array has a non-<c>null</c>
        /// <see cref="DestroyNotify{T}"/> function it is called for the removed element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        /// <returns>
        /// the pointer which was removed
        /// </returns>
        public T RemoveIndexFast (UInt32 index)
        {
            AssertNotDisposed ();
            var retPtr = PtrArrayInternal.g_ptr_array_remove_index_fast (Handle, index);
            var ret = Opaque.GetInstance<T> (retPtr, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Removes the given number of pointers starting at the given index
        /// from a <see cref="PtrArray{T}"/>. The following elements are moved to close the
        /// gap. If this array has a non-<c>null</c> <see cref="DestroyNotify{T}"/> function it is
        /// called for the removed elements.
        /// </summary>
        /// <param name="index">
        /// the index of the first pointer to remove
        /// </param>
        /// <param name="length">
        /// the number of pointers to remove
        /// </param>
        [Since("2.4")]
        public void RemoveRange (UInt32 index, UInt32 length)
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_remove_range (Handle, index, length);
        }

        /// <summary>
        /// Sets a function for freeing each element when this array is destroyed
        /// either via <see cref="Unref"/> , when <see cref="Free"/>  is called
        /// with @freeSegment set to <c>true</c> or when removing elements.
        /// </summary>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy this array or <c>null</c>
        /// </param>
        [Since("2.22")]
        public void SetFreeFunc (DestroyNotify<T> elementFreeFunc)
        {
            AssertNotDisposed ();
            if (elementFreeFunc == null) {
                elementFreeFuncNative = default(NativeDestroyNotify);
            } else {
                elementFreeFuncNative = (elementFreeFuncDataPtr) => {
                    var elementFreeFuncData = Opaque.GetInstance<T> (elementFreeFuncDataPtr, Transfer.None);
                    elementFreeFunc (elementFreeFuncData);
                };
            }
            PtrArrayInternal.g_ptr_array_set_free_func (Handle, elementFreeFuncNative);
        }

        /// <summary>
        /// Sets the size of the array. When making the array larger,
        /// newly-added elements will be set to <c>null</c>. When making it smaller,
        /// if this array has a non-<c>null</c> <see cref="DestroyNotify{T}"/> function then it will be
        /// called for the removed elements.
        /// </summary>
        /// <param name="length">
        /// the new length of the pointer array
        /// </param>
        public void SetSize (Int32 length)
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_set_size (Handle, length);
        }

        /// <summary>
        /// Sorts the array, using <paramref name="compareFunc"/> which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if irst arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// Note that the comparison function for <see cref="Sort"/> doesn't
        /// take the pointers from the array as arguments, it takes pointers to
        /// the pointers in the array.
        /// 
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        public void Sort (CompareFunc<T> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException ("compareFunc");
            }
            NativeCompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = Opaque.GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = Opaque.GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = compareFunc.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            PtrArrayInternal.g_ptr_array_sort (Handle, compareFuncNative);
        }

        /// <summary>
        /// Atomically decrements the reference count of this array by one. If the
        /// reference count drops to 0, the effect is the same as calling
        /// g_ptr_array_free() with @freeSegment set to <c>true</c>. This function
        /// is MT-safe and may be called from any thread.
        /// </summary>
        [Since("2.22")]
        internal protected override void Unref ()
        {
            AssertNotDisposed ();
            PtrArrayInternal.g_ptr_array_unref (Handle);
        }

        public T this[int index] {
            get {
                AssertNotDisposed ();
                var dataPtr = Marshal.ReadIntPtr (Handle, IntPtr.Size * 0);
                var retPtr = Marshal.ReadIntPtr (dataPtr, IntPtr.Size * index);
                var ret = Opaque.GetInstance<T> (retPtr, Transfer.None);
                return ret;
            }
            set {
                AssertNotDisposed ();
                RemoveIndex (index);
                Insert (index, value);
            }
        }

        public int Count {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadInt32 (Handle, IntPtr.Size * 1);
                return ret;
            }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public int IndexOf (T data)
        {
            AssertNotDisposed ();
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(data)) {
                    return i;
                }
            }
            return -1;
        }

        public void Clear ()
        {
            AssertNotDisposed ();
            SetSize (0);
        }

        public bool Contains (T data)
        {
            AssertNotDisposed ();
            return IndexOf (data) >= 0;
        }

        public void CopyTo (T[] array, int length)
        {
            AssertNotDisposed ();
            if (length < 0 || length > Count) {
                throw new ArgumentOutOfRangeException ("length");
            }
            for (int i = 0; i < length; i++)
            {
                array[i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator ()
        {
            AssertNotDisposed ();
            return new Enumerator (this);
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }

        public void RemoveAt (int index)
        {
            AssertNotDisposed ();
            RemoveIndex (index);
        }

        class Enumerator : IEnumerator<T>
        {
            PtrArray<T> array;
            int index;

            public Enumerator (PtrArray<T> array)
            {
                this.array = array;
                Reset ();
            }

            #region IEnumerator implementation

            public bool MoveNext ()
            {
                index++;
                return index < array.Count;
            }

            public void Reset ()
            {
                index = -1;
            }

            object IEnumerator.Current {
                get {
                    return array[index];
                }
            }

            #endregion

            #region IDisposable implementation

            public void Dispose ()
            {
                array = null;
            }

            #endregion

            #region IEnumerator implementation

            public T Current {
                get {
                    return array[index];
                }
            }

            #endregion
        }
    }

    // compiler doesn't allow pinvoke declarations in generic class
    static class PtrArrayInternal
    {
        /// <summary>
        /// Creates a new #GPtrArray with a reference count of 1.
        /// </summary>
        /// <returns>
        /// the new #GPtrArray
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_ptr_array_new();

        /// <summary>
        /// Creates a new #GPtrArray with @reservedSize pointers preallocated
        /// and a reference count of 1. This avoids frequent reallocation, if
        /// you are going to add many pointers to the array. Note however that
        /// the size of the array is still 0. It also set @elementFreeFunc
        /// for freeing each element when the array is destroyed either via
        /// g_ptr_array_unref(), when g_ptr_array_free() is called with
        /// @freeSegment set to %TRUE or when removing elements.
        /// </summary>
        /// <param name="reservedSize">
        /// number of pointers preallocated
        /// </param>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy @array or %NULL
        /// </param>
        /// <returns>
        /// A new #GPtrArray
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.30")]
        internal static extern IntPtr g_ptr_array_new_full(
            [In] UInt32 reservedSize,
            [In] NativeDestroyNotify elementFreeFunc);

        /// <summary>
        /// Creates a new #GPtrArray with a reference count of 1 and use
        /// @elementFreeFunc for freeing each element when the array is destroyed
        /// either via g_ptr_array_unref(), when g_ptr_array_free() is called with
        /// @freeSegment set to %TRUE or when removing elements.
        /// </summary>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy @array or %NULL
        /// </param>
        /// <returns>
        /// A new #GPtrArray
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern IntPtr g_ptr_array_new_with_free_func(
            [In] NativeDestroyNotify elementFreeFunc);

        /// <summary>
        /// Creates a new #GPtrArray with @reservedSize pointers preallocated
        /// and a reference count of 1. This avoids frequent reallocation, if
        /// you are going to add many pointers to the array. Note however that
        /// the size of the array is still 0.
        /// </summary>
        /// <param name="reservedSize">
        /// number of pointers preallocated
        /// </param>
        /// <returns>
        /// the new #GPtrArray
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_ptr_array_sized_new(
            [In] UInt32 reservedSize);

        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_ptr_array_add(
            [In] IntPtr array,
            [In] IntPtr data);

        /// <summary>
        /// Calls a function for each element of a #GPtrArray.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="func">
        /// the function to call for each array element
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        internal static extern void g_ptr_array_foreach(
            [In] IntPtr array,
            [In] NativeFunc func,
            [In] IntPtr userData);

        /// <summary>
        /// Frees the memory allocated for the #GPtrArray. If @freeSeg is %TRUE
        /// it frees the memory block holding the elements as well. Pass %FALSE
        /// if you want to free the #GPtrArray wrapper but preserve the
        /// underlying array for use elsewhere. If the reference count of @array
        /// is greater than one, the #GPtrArray wrapper is preserved but the
        /// size of @array will be set to zero.
        /// </summary>
        /// <remarks>
        /// If array contents point to dynamically-allocated memory, they should
        /// be freed separately if @freeSeg is %TRUE and no #GDestroyNotify
        /// function has been set for @array.
        /// </remarks>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="freeSeg">
        /// if %TRUE the actual pointer array is freed as well
        /// </param>
        /// <returns>
        /// the pointer array if @freeSeg is %FALSE, otherwise %NULL.
        ///     The pointer array should be freed using g_free().
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_ptr_array_free(
            [In] IntPtr array,
            [In] Boolean freeSeg);

        /// <summary>
        /// Inserts an element into the pointer array at the given index. The
        /// array will grow in size automatically if necessary.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="index">
        /// the index to place the new element at, or -1 to append
        /// </param>
        /// <param name="data">
        /// the pointer to add.
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.40")]
        internal static extern void g_ptr_array_insert(
            [In] IntPtr array,
            [In] Int32 index,
            [In] IntPtr data);

        /// <summary>
        /// Atomically increments the reference count of @array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <returns>
        /// The passed in #GPtrArray
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern IntPtr g_ptr_array_ref(
            [In] IntPtr array);

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The following elements are moved down one place. If @array
        /// has a non-%NULL #GDestroyNotify function it is called for the
        /// removed element.
        /// </summary>
        /// <remarks>
        /// It returns %TRUE if the pointer was removed, or %FALSE if the
        /// pointer was not found.
        /// </remarks>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="data">
        /// the pointer to remove
        /// </param>
        /// <returns>
        /// %TRUE if the pointer is removed, %FALSE if the pointer
        ///     is not found in the array
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_ptr_array_remove(
            [In] IntPtr array,
            [In] IntPtr data);

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The last element in the array is used to fill in the space,
        /// so this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove(). If @array has a non-%NULL
        /// #GDestroyNotify function it is called for the removed element.
        /// </summary>
        /// <remarks>
        /// It returns %TRUE if the pointer was removed, or %FALSE if the
        /// pointer was not found.
        /// </remarks>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="data">
        /// the pointer to remove
        /// </param>
        /// <returns>
        /// %TRUE if the pointer was found in the array
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_ptr_array_remove_fast(
            [In] IntPtr array,
            [In] IntPtr data);

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The following elements are moved down one place. If @array has
        /// a non-%NULL #GDestroyNotify function it is called for the removed
        /// element.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        /// <returns>
        /// the pointer which was removed
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_ptr_array_remove_index(
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The last element in the array is used to fill in the space, so
        /// this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove_index(). If @array has a non-%NULL
        /// #GDestroyNotify function it is called for the removed element.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        /// <returns>
        /// the pointer which was removed
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_ptr_array_remove_index_fast(
            [In] IntPtr array,
            [In] UInt32 index);

        /// <summary>
        /// Removes the given number of pointers starting at the given index
        /// from a #GPtrArray. The following elements are moved to close the
        /// gap. If @array has a non-%NULL #GDestroyNotify function it is
        /// called for the removed elements.
        /// </summary>
        /// <param name="array">
        /// a @GPtrArray
        /// </param>
        /// <param name="index">
        /// the index of the first pointer to remove
        /// </param>
        /// <param name="length">
        /// the number of pointers to remove
        /// </param>
        /// <returns>
        /// the @array
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        internal static extern IntPtr g_ptr_array_remove_range(
            [In] IntPtr array,
            [In] UInt32 index,
            [In] UInt32 length);

        /// <summary>
        /// Sets a function for freeing each element when @array is destroyed
        /// either via g_ptr_array_unref(), when g_ptr_array_free() is called
        /// with @freeSegment set to %TRUE or when removing elements.
        /// </summary>
        /// <param name="array">
        /// A #GPtrArray
        /// </param>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy @array or %NULL
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern void g_ptr_array_set_free_func(
            [In] IntPtr array,
            [In] NativeDestroyNotify elementFreeFunc);

        /// <summary>
        /// Sets the size of the array. When making the array larger,
        /// newly-added elements will be set to %NULL. When making it smaller,
        /// if @array has a non-%NULL #GDestroyNotify function then it will be
        /// called for the removed elements.
        /// </summary>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="length">
        /// the new length of the pointer array
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_ptr_array_set_size(
            [In] IntPtr array,
            [In] Int32 length);

        /// <summary>
        /// Sorts the array, using @compareFunc which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if irst arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// Note that the comparison function for g_ptr_array_sort() doesn't
        /// take the pointers from the array as arguments, it takes pointers to
        /// the pointers in the array.
        /// 
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_ptr_array_sort(
            [In] IntPtr array,
            [In] NativeCompareFunc compareFunc);

        /// <summary>
        /// Like g_ptr_array_sort(), but the comparison function has an extra
        /// user data argument.
        /// </summary>
        /// <remarks>
        /// Note that the comparison function for g_ptr_array_sort_with_data()
        /// doesn't take the pointers from the array as arguments, it takes
        /// pointers to the pointers in the array.
        /// 
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="array">
        /// a #GPtrArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        /// <param name="userData">
        /// data to pass to @compareFunc
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_ptr_array_sort_with_data(
            [In] IntPtr array,
            [In] NativeCompareDataFunc compareFunc,
            [In] IntPtr userData);

        /// <summary>
        /// Atomically decrements the reference count of @array by one. If the
        /// reference count drops to 0, the effect is the same as calling
        /// g_ptr_array_free() with @freeSegment set to %TRUE. This function
        /// is MT-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// A #GPtrArray
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern void g_ptr_array_unref(
            [In] IntPtr array);
    }
}
