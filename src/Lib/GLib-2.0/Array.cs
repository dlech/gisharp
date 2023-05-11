// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Array
    {
        /// <summary>
        /// Gets the number of elements in the array including the possible
        /// terminating zero element.
        /// </summary>
        public int Length => (int)((UnmanagedStruct*)UnsafeHandle)->Len;

        /// <summary>
        /// Creates a new <see cref="Array"/> with a reference count of 1.
        /// </summary>
        /// <param name="zeroTerminated">
        /// <c>true</c> if the array should have an extra element at
        /// the end which is set to 0
        /// </param>
        /// <param name="clear">
        /// <c>true</c> if <see cref="Array"/> elements should be automatically
        /// cleared to 0 when they are allocated
        /// </param>
        /// <param name="elementSize">
        /// the size of each element in bytes
        /// </param>
        /// <returns>
        /// the new <see cref="Array"/>
        /// </returns>
        private protected static UnmanagedStruct* New(
            bool zeroTerminated,
            bool clear,
            int elementSize
        )
        {
            if (elementSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(elementSize));
            }
            var zeroTerminated_ = zeroTerminated.ToBoolean();
            var clear_ = clear.ToBoolean();
            var ret_ = g_array_new(zeroTerminated_, clear_, (uint)elementSize);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        private protected static UnmanagedStruct* SizedNew(
            bool zeroTerminated,
            bool clear,
            int elementSize,
            int reservedSize
        )
        {
            if (elementSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(elementSize));
            }
            if (reservedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(reservedSize));
            }
            var zeroTerminated_ = zeroTerminated.ToBoolean();
            var clear_ = clear.ToBoolean();
            var ret_ = g_array_sized_new(
                zeroTerminated_,
                clear_,
                (uint)elementSize,
                (uint)reservedSize
            );
            GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        private protected void AppendVals<T>(ReadOnlySpan<T> data)
            where T : unmanaged
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            fixed (void* data_ = data)
            {
                var len_ = (uint)data.Length;
                g_array_append_vals(array_, (IntPtr)data_, len_);
                GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Gets the size of the elements in this array.
        /// </summary>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [Since("2.22")]
        public int ElementSize
        {
            get
            {
                var array_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_array_get_element_size(array_);
                GMarshal.PopUnhandledException();
                return (int)ret;
            }
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
        private protected void InsertVals<T>(int index, ReadOnlySpan<T> data)
            where T : unmanaged
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var index_ = (uint)index;
            fixed (void* data_ = data)
            {
                var len_ = (uint)data.Length;
                g_array_insert_vals(array_, index_, (IntPtr)data_, len_);
                GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Adds elements onto the start of the array.
        /// </summary>
        /// <remarks>
        /// This operation is slower than <see cref="AppendVals"/> since the
        /// existing elements in the array have to be moved to make space for
        /// the new elements.
        /// </remarks>
        /// <param name="data">
        /// the elements to prepend to the start of the array
        /// </param>
        private protected void PrependVals<T>(ReadOnlySpan<T> data)
            where T : unmanaged
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            fixed (void* data_ = data)
            {
                var len_ = (uint)data.Length;
                g_array_prepend_vals(array_, (IntPtr)data_, len_);
                GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>.
        /// The following elements are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        public void RemoveAt(int index)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            g_array_remove_index(array_, (uint)index);
            GMarshal.PopUnhandledException();
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
        public void RemoveAtFast(int index)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            g_array_remove_index_fast(array_, (uint)index);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Removes the given number of elements starting at the given index
        /// from a <see cref="Array{T}"/>. The following elements are moved to
        /// close the gap.
        /// </summary>
        /// <param name="index">
        /// the index of the first element to remove
        /// </param>
        /// <param name="length">
        /// the number of elements to remove
        /// </param>
        [Since("2.4")]
        public void RemoveRange(int index, int length)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (length < 0 || index + length > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            g_array_remove_range(array_, (uint)index, (uint)length);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with <c>>clear</c> set to <c>true</c>, the
        /// new elements are set to 0.
        /// </summary>
        /// <param name="length">
        /// the new size of the <see cref="Array{T}"/>
        /// </param>
        public void SetSize(int length)
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            g_array_set_size(array_, (uint)length);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Specifies the type of a comparison function used to compare two
        /// values. The function should return a negative integer if the first
        /// value comes before the second, 0 if they are equal, or a positive
        /// integer if the first value comes after the second.
        /// </summary>
        /// <param name="a">
        /// a value
        /// </param>
        /// <param name="b">
        /// a value to compare with
        /// </param>
        /// <returns>
        /// negative value if <paramref name="a"/> &lt; <paramref name="b"/>;
        /// zero if <paramref name="a"/> = <paramref name="b"/>; positive
        /// value if  <paramref name="a"/> &gt; <paramref name="b"/>
        /// </returns>
        public delegate int CompareFunc<T>(in T a, in T b)
            where T : unmanaged;

        /// <summary>
        /// Sorts a <see cref="Array{T}"/> using <paramref name="compareFunc"/>
        /// which should be a qsort()-style
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
        private protected void Sort<T>(CompareFunc<T> compareFunc)
            where T : unmanaged
        {
            var array_ = (UnmanagedStruct*)UnsafeHandle;
            var unmanagedCompareFunc = new UnmanagedCompareFunc(
                (a_, b_) =>
                {
                    try
                    {
                        ref var a = ref Unsafe.AsRef<T>((void*)a_);
                        ref var b = ref Unsafe.AsRef<T>((void*)b_);
                        return compareFunc(a, b);
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
            g_array_sort(array_, compareFunc_);
            GMarshal.PopUnhandledException();
            GC.KeepAlive(unmanagedCompareFunc);
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
            handle = IntPtr.Zero; // object becomes disposed
            GC.SuppressFinalize(this);

            var length = (int)array_->Len;
            var data = (IntPtr)g_array_free(array_, Runtime.Boolean.False);
            return (data, length);
        }

        /// <summary>
        /// Removes all items from the <see cref="Array"/>.
        /// </summary>
        public void Clear()
        {
            SetSize(0);
        }
    }

    /// <summary>
    /// Contains the public fields of a GArray.
    /// </summary>
    [GType("GArray", IsProxyForUnmanagedType = true)]
    public sealed unsafe class Array<T> : Array, IReadOnlyList<T>, IList<T>
        where T : unmanaged
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Array(IntPtr handle, Transfer ownership)
            : base(handle, ownership) { }

        /// <summary>
        /// a <see cref="Span{T}"/> to the element data. The data may be moved as elements
        /// are added to the <see cref="Array"/>.
        /// </summary>
        public Span<T> Data
        {
            get
            {
                var array_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = new Span<T>(array_->Data, (int)array_->Len);
                return ret;
            }
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
        public Array(bool zeroTerminated, bool clear = false, int reservedSize = 10)
            : this((IntPtr)SizedNew(zeroTerminated, clear, sizeof(T), reservedSize), Transfer.Full)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Array{T}"/> class.
        /// </summary>
        public Array()
            : this((IntPtr)New(false, false, sizeof(T)), Transfer.Full) { }

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        public void Append(ReadOnlySpan<T> data) => AppendVals(data);

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        public void Append(params T[] data) => AppendVals<T>(data);

        /// <summary>
        /// Adds an element onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the element to append to the end of the array
        /// </param>
        public void Add(T data) => Append(data);

        /// <summary>
        /// Inserts elements into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the elements at
        /// </param>
        /// <param name="data">
        /// the elements to insert
        /// </param>
        public void Insert(int index, ReadOnlySpan<T> data) => InsertVals(index, data);

        /// <summary>
        /// Inserts elements into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the elements at
        /// </param>
        /// <param name="data">
        /// the elements to insert
        /// </param>
        public void Insert(int index, params T[] data) => InsertVals<T>(index, data);

        /// <summary>
        /// Inserts element into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the element at
        /// </param>
        /// <param name="data">
        /// the element to insert
        /// </param>
        void IList<T>.Insert(int index, T data) => Insert(index, data);

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
        public void Prepend(ReadOnlySpan<T> data) => PrependVals(data);

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
        public void Prepend(params T[] data) => PrependVals<T>(data);

        /// <summary>
        /// Sorts a <see cref="Array{T}"/> using <paramref name="compareFunc"/>
        /// which should be a qsort()-style
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
        public void Sort(CompareFunc<T> compareFunc) => Sort<T>(compareFunc);

        bool ICollection<T>.IsReadOnly => false;

        /// <inheritdoc/>
        public T this[int index]
        {
            get
            {
                try
                {
                    return Data[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
            set
            {
                try
                {
                    Data[index] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        /// <inheritdoc/>
        public bool Contains(T other)
        {
            for (int i = 0; i < Length; i++)
            {
                if (this[i].Equals(other))
                {
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (arrayIndex + Length > array.Length)
            {
                throw new ArgumentException("Destination array is not long enough.");
            }
            for (int i = 0; i < Length; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        /// <inheritdoc/>
        public int IndexOf(T data)
        {
            for (int i = 0; i < Length; i++)
            {
                if (this[i].Equals(data))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <inheritdoc/>
        public bool Remove(T data)
        {
            for (int i = 0; i < Length; i++)
            {
                if (this[i].Equals(data))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        int IReadOnlyCollection<T>.Count => Length;
        int ICollection<T>.Count => Length;

        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Converts an <see cref="Array{T}"/> to a <see cref="Span{T}"/>.
        /// </summary>
        public static implicit operator Span<T>(Array<T>? array)
        {
            if (array is null)
            {
                return default;
            }

            return array.Data;
        }
    }
}
