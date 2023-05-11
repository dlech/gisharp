// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using static System.Reflection.BindingFlags;

namespace GISharp.Lib.GLib
{
    unsafe partial class PtrArray
    {
        private protected void* Data_ => (void*)((UnmanagedStruct*)UnsafeHandle)->Pdata;

        /// <summary>
        /// number of pointers in the array
        /// </summary>
        private protected uint Len => ((UnmanagedStruct*)UnsafeHandle)->Len;

        static UnmanagedStruct* New()
        {
            var ret = g_ptr_array_new();
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="PtrArray"/>.
        /// </summary>
        private protected PtrArray()
            : this((IntPtr)New(), Transfer.Full) { }

        static UnmanagedStruct* SizedNew(int reservedSize)
        {
            if (reservedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(reservedSize));
            }
            var ret = g_ptr_array_sized_new((uint)reservedSize);
            GMarshal.PopUnhandledException();
            return ret;
        }

        private protected PtrArray(int reservedSize)
            : this((IntPtr)SizedNew(reservedSize), Transfer.Full) { }

        static UnmanagedStruct* NewFull(
            int reservedSize,
            delegate* unmanaged[Cdecl]<IntPtr, void> elementFreeFunc
        )
        {
            if (reservedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(reservedSize));
            }
            var ret = g_ptr_array_new_full((uint)reservedSize, elementFreeFunc);
            GMarshal.PopUnhandledException();
            return ret;
        }

        // IMPORTANT: elementFreeFunc cannot be allowed to be GCed
        private protected PtrArray(
            int reservedSize,
            delegate* unmanaged[Cdecl]<IntPtr, void> elementFreeFunc
        )
            : this((IntPtr)NewFull(reservedSize, elementFreeFunc), Transfer.Full) { }

        ///// <summary>
        ///// Creates a new <see cref="PtrArray{T}"/> with <paramref name="reservedSize"/> pointers preallocated
        ///// and a reference count of 1. This avoids frequent reallocation, if
        ///// you are going to add many pointers to the array. Note however that
        ///// the size of the array is still 0. It also set @elementFreeFunc
        ///// for freeing each element when the array is destroyed either via
        ///// g_ptr_array_unref(), when g_ptr_array_free() is called with
        ///// @freeSegment set to <c>true</c> or when removing elements.
        ///// </summary>
        ///// <param name="reservedSize">
        ///// number of pointers preallocated
        ///// </param>
        ///// <param name="elementFreeFunc">
        ///// A function to free elements with
        /////     destroy this array or <c>null</c>
        ///// </param>
        //[Since("2.30")]
        //public PtrArray (uint reservedSize, DestroyNotify<T> elementFreeFunc)
        //    : this (NewFull (reservedSize, elementFreeFunc), Transfer.All)
        //{
        //}

        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        private protected void Add(IntPtr data)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            g_ptr_array_add(array_, data);
            GMarshal.PopUnhandledException();
        }

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
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            var length = (int)array_->Len;
            var data = g_ptr_array_free(array_, Runtime.Boolean.False);
            GMarshal.PopUnhandledException();
            handle = IntPtr.Zero; // object becomes disposed
            GC.SuppressFinalize(this);
            return (data, length);
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
        private protected void Insert(int index, IntPtr data)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            g_ptr_array_insert(array_, index, data);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The following elements are moved down one place. If this array
        /// has a non-<c>null</c> <c>GDestroyNotify</c>  function it is called for the
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
        private protected bool Remove(IntPtr data)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_ptr_array_remove(array_, data);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The last element in the array is used to fill in the space,
        /// so this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove(). If this array has a non-<c>null</c>
        /// <c>GDestroyNotify</c> function it is called for the removed element.
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
        private protected bool RemoveFast(IntPtr data)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_ptr_array_remove_fast(array_, data);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The following elements are moved down one place. If this array has
        /// a non-<c>null</c> <c>GDestroyNotify</c> function it is called for the removed
        /// element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        /// <returns>
        /// the pointer which was removed
        /// </returns>
        private protected IntPtr RemoveAt(int index)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index >= array_->Len)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var ret = g_ptr_array_remove_index(array_, (uint)index);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The last element in the array is used to fill in the space, so
        /// this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove_index(). If this array has a non-<c>null</c>
        /// <c>GDestroyNotify</c> function it is called for the removed element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        /// <returns>
        /// the pointer which was removed
        /// </returns>
        private protected IntPtr RemoveAtFast(int index)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index >= array_->Len)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var ret = g_ptr_array_remove_index_fast(array_, (uint)index);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Removes the given number of pointers starting at the given index
        /// from a <see cref="PtrArray{T}"/>. The following elements are moved to close the
        /// gap. If this array has a non-<c>null</c> <c>GDestroyNotify</c> function it is
        /// called for the removed elements.
        /// </summary>
        /// <param name="index">
        /// the index of the first pointer to remove
        /// </param>
        /// <param name="length">
        /// the number of pointers to remove
        /// </param>
        [Since("2.4")]
        public void RemoveRange(int index, int length)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (index + length > array_->Len)
            {
                throw new ArgumentException("index + length exceeds Count.");
            }
            g_ptr_array_remove_range(array_, (uint)index, (uint)length);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets a function for freeing each element when this array is destroyed
        /// or when removing elements.
        /// </summary>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy this array or <c>null</c>
        /// </param>
        [Since("2.22")]
        private protected void SetFreeFunc(delegate* unmanaged[Cdecl]<IntPtr, void> elementFreeFunc)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            g_ptr_array_set_free_func(array_, elementFreeFunc);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the size of the array. When making the array larger,
        /// newly-added elements will be set to <c>null</c>. When making it smaller,
        /// if this array has a non-<c>null</c> <c>GDestroyNotify</c> function then it will be
        /// called for the removed elements.
        /// </summary>
        /// <param name="length">
        /// the new length of the pointer array
        /// </param>
        public void SetSize(int length)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            g_ptr_array_set_size(array_, length);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sorts the array, using <paramref name="compareFunc"/> which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        private protected void Sort(Comparison<IntPtr> compareFunc)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;

            var unmanagedCompareFunc = new UnmanagedCompareFunc(
                (a_, b_) =>
                {
                    try
                    {
                        var a = Marshal.ReadIntPtr(a_);
                        var b = Marshal.ReadIntPtr(b_);
                        var ret = compareFunc(a, b);
                        return ret;
                    }
                    catch (Exception ex)
                    {
                        GMarshal.PushUnhandledException(ex);
                        return default;
                    }
                }
            );

            var compareFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)
                Marshal.GetFunctionPointerForDelegate(unmanagedCompareFunc);
            g_ptr_array_sort(array_, compareFunc_);
            GMarshal.PopUnhandledException();
            GC.KeepAlive(unmanagedCompareFunc);
        }

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
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_sort_with_data(
            UnmanagedStruct* array,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, void> compareFunc,
            IntPtr userData
        );

        /// <summary>
        /// Checks whether @needle exists in @haystack. If the element is found, %TRUE is
        /// returned and the element’s index is returned in @index_ (if non-%NULL).
        /// Otherwise, %FALSE is returned and @index_ is undefined. If @needle exists
        /// multiple times in @haystack, the index of the first instance is returned.
        /// </summary>
        /// <remarks>
        /// This does pointer comparisons only. If you want to use more complex equality
        /// checks, such as string comparisons, use g_ptr_array_find_with_equal_func().
        /// </remarks>
        /// <param name="needle">
        /// pointer to look for
        /// </param>
        /// <param name="index">
        /// return location for the index of the element, if found
        /// </param>
        /// <returns>
        /// %TRUE if @needle is one of the elements of @haystack
        /// </returns>
        [Since("2.54")]
        private protected bool Find(IntPtr needle, out int index)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            uint index_;
            var ret_ = g_ptr_array_find(array_, needle, &index_);
            GMarshal.PopUnhandledException();
            index = (int)index_;
            var ret = ret_.IsTrue();
            return ret;
        }
    }

    /// <summary>
    /// Contains the public fields of a pointer array.
    /// </summary>
    public sealed unsafe class PtrArray<T> : PtrArray, IReadOnlyList<T>, IList<T>
        where T : Opaque
    {
        static readonly Func<IntPtr, IntPtr> elementCopyFunc;
        static readonly delegate* unmanaged[Cdecl]<IntPtr, void> elementFreeFunc;

        static PtrArray()
        {
            var methods = typeof(T).GetMethods(Static | NonPublic);

            var copyMethodInfo = methods.Single(
                m => m.IsDefined(typeof(PtrArrayCopyFuncAttribute), false)
            );
            elementCopyFunc =
                (Func<IntPtr, IntPtr>)copyMethodInfo.CreateDelegate(typeof(Func<IntPtr, IntPtr>));

            var freeMethodInfo = methods.Single(
                m => m.IsDefined(typeof(PtrArrayFreeFuncAttribute), false)
            );
            elementFreeFunc = (delegate* unmanaged[Cdecl]<IntPtr, void>)
                freeMethodInfo.MethodHandle.GetFunctionPointer();
        }

        private ReadOnlySpan<IntPtr> Data => new(Data_, (int)Len);

        /// <summary>
        /// Indicates if this <see cref="PtrArray{T}"/> owns the elements in the
        /// GLib sense.
        /// </summary>
        public bool OwnsElements { get; private set; }

        /// <summary>
        /// Creates a new <see cref="PtrArray{T}"/> instance.
        /// </summary>
        /// <remarks>
        /// The array "owns" the elements in the GLib sense.
        /// </remarks>
        public PtrArray()
            : this(0) { }

        /// <summary>
        /// Creates a new <see cref="PtrArray{T}"/> instance.
        /// </summary>
        /// <param name="reservedSize">
        /// number of pointers preallocated
        /// </param>
        /// <remarks>
        /// The array "owns" the elements in the GLib sense.
        /// </remarks>
        public PtrArray(int reservedSize)
            : base(reservedSize, elementFreeFunc)
        {
            OwnsElements = true;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PtrArray(IntPtr handle, Transfer ownership)
            : base(handle, ownership)
        {
            if (ownership == Transfer.Full)
            {
                OwnsElements = true;
            }
        }

        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        public void Add(T data)
        {
            var data_ = data.UnsafeHandle;
            if (OwnsElements)
            {
                data_ = elementCopyFunc(data_);
            }
            Add(data_);
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="index"/> is &lt; 0 or &gt; <see cref="PtrArray.Len"/>
        /// </exception>
        [Since("2.40")]
        public void Insert(int index, T data)
        {
            if (index < 0 || index > Len)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var data_ = data.UnsafeHandle;
            if (OwnsElements)
            {
                data_ = elementCopyFunc(data_);
            }
            Insert(index, data_);
        }

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The following elements are moved down one place. If this array
        /// has a non-<c>null</c> <c>GDestroyNotify</c>  function it is called for the
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
        public bool Remove(T data)
        {
            var data_ = data.UnsafeHandle;
            return Remove(data_);
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The following elements are moved down one place. If this array has
        /// a non-<c>null</c> <c>GDestroyNotify</c> function it is called for the removed
        /// element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        public new void RemoveAt(int index) => base.RemoveAt(index);

        /// <summary>
        /// Removes the first occurrence of the given pointer from the pointer
        /// array. The last element in the array is used to fill in the space,
        /// so this function does not preserve the order of the array. But it
        /// is faster than g_ptr_array_remove(). If this array has a non-<c>null</c>
        /// <c>GDestroyNotify</c> function it is called for the removed element.
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
        public bool RemoveFast(T data)
        {
            var data_ = data.UnsafeHandle;
            return RemoveFast(data_);
        }

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The last element in the array is used to fill in the space, so
        /// this function does not preserve the order of the array. But it
        /// is faster than <see cref="RemoveAt"/>. If this array has a non-<c>null</c>
        /// <c>GDestroyNotify</c> function it is called for the removed element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        public new void RemoveAtFast(int index) => base.RemoveAtFast(index);

        /// <summary>
        /// Sorts the array, using <paramref name="compareFunc"/> which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        public void Sort(Comparison<T> compareFunc)
        {
            int compareFunc_(IntPtr a_, IntPtr b_)
            {
                var a = GetInstance<T>(a_, Transfer.None);
                var b = GetInstance<T>(b_, Transfer.None);
                var ret = compareFunc(a, b);
                return ret;
            }
            Sort(compareFunc_);
        }

        /// <summary>
        /// Gets or sets the element of the array at <paramref name="index"/>.
        /// </summary>
        public T this[int index]
        {
            get
            {
                try
                {
                    var ret_ = Data[index];
                    var ret = GetInstance<T>(ret_, Transfer.None);
                    return ret;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                // Doing some tricks to make this faster...
                // Add the new value to the end
                Add(value);
                // Then this will replace the value at index with the value
                // we just added to the end
                RemoveAtFast(index);
            }
        }

        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// Returns the first index of <paramref name="data"/> in this array.
        /// </summary>
        /// <returns>The index or -1 if <paramref name="data"/> was not found.</returns>
        /// <param name="data">Data.</param>
        public int IndexOf(T data)
        {
            var data_ = data.UnsafeHandle;
            for (int i = 0; i < Len; i++)
            {
                var ptr = Data[i];
                if (ptr == data_)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes all pointers from the array.
        /// </summary>
        public void Clear() => SetSize(0);

        /// <summary>
        /// Checks if the array contains <paramref name="data"/>.
        /// </summary>
        /// <returns><c>true</c> if <paramref name="data"/> was found, otherwise
        /// <c>false</c>.</returns>
        /// <param name="data">The item to search for.</param>
        public bool Contains(T data) => IndexOf(data) >= 0;

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (Len > array.Length - arrayIndex)
            {
                throw new ArgumentException("Destination array is not long enough.");
            }
            for (int i = 0; i < Len; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        public int Count => (int)Len;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Len; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Converts a <see cref="PtrArray{T}"/> to an unowned C array.
        /// </summary>
        public static implicit operator UnownedCPtrArray<T>(PtrArray<T>? array)
        {
            if (array is null)
            {
                return default;
            }
            return new UnownedCPtrArray<T>(array.Data);
        }
    }

    /// <summary>
    /// Extension methods for <see cref="PtrArray{T}"/>.
    /// </summary>
    public static class PtrArrayExtensions
    {
        /// <summary>
        /// Creates a new <see cref="PtrArray{T}"/> from an enumerable source.
        /// </summary>
        public static PtrArray<T> ToPtrArray<T>(this IEnumerable<T> source)
            where T : Opaque
        {
            var size = 0;

            // if we know the size ahead of time, use it
            if (source is ICollection<Variant> collection)
            {
                size = collection.Count;
            }
            else if (source is IReadOnlyCollection<Variant> readOnlyCollection)
            {
                size = readOnlyCollection.Count;
            }

            var array = new PtrArray<T>(size);
            foreach (var item in source)
            {
                array.Add(item);
            }
            return array;
        }
    }
}
