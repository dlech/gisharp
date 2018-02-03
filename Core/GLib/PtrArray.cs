using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using GISharp.Runtime;
using GISharp.GObject;

namespace GISharp.GLib
{
    /// <summary>
    /// Contains the public fields of a pointer array.
    /// </summary>
    [GType ("GPtrArray", IsProxyForUnmanagedType = true)]
    public abstract class PtrArray : Boxed
    {
        static readonly IntPtr dataOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Data));
        static readonly IntPtr lenOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Len));

        struct Struct
        {
            #pragma warning disable CS0649
            public IntPtr Data;
            public uint Len;
            #pragma warning restore CS0649
        }

        protected IntPtr Data {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadIntPtr (handle, (int)dataOffset);
                return ret;
            }
        }

        public uint Len {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadInt32 (handle, (int)lenOffset);
                return (uint)ret;
            }
        }

        public PtrArray(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_ref (IntPtr array);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_unref (IntPtr array);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_ptr_array_get_type ();

        static readonly GType _GType = g_ptr_array_get_type();

        /// <summary>
        /// Creates a new #GPtrArray with a reference count of 1.
        /// </summary>
        /// <returns>
        /// the new #GPtrArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_new ();

        static IntPtr New ()
        {
            var ret = g_ptr_array_new ();
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="PtrArray"/>.
        /// </summary>
        protected PtrArray () : this (New (), Transfer.Full)
        {
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_sized_new (
            uint reservedSize);

        static IntPtr SizedNew (uint reservedSize)
        {
            var ret = g_ptr_array_sized_new (reservedSize);
            return ret;
        }

        protected PtrArray (uint reservedSize) : this (SizedNew (reservedSize), Transfer.Full)
        {
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.30")]
        static extern IntPtr g_ptr_array_new_full (
            uint reservedSize,
            UnmanagedDestroyNotify elementFreeFunc);

        // static IntPtr NewFull (uint reservedSize, DestroyNotify<IntPtr> elementFreeFunc)
        // {
        //     if (elementFreeFunc == null) {
        //         throw new ArgumentNullException (nameof (elementFreeFunc));
        //     }
        //     // TODO: this callback will be garbage collected before we are done with it
        //     UnmanagedDestroyNotify elementFreeFuncUnmanaged = (data) => {
        //         elementFreeFunc (data);
        //     };
        //     var handle = g_ptr_array_new_full (reservedSize, elementFreeFuncNative);
        //     return handle;
        // }

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
        //[Since("2.30")]
        //public PtrArray (uint reservedSize, DestroyNotify<T> elementFreeFunc)
        //    : this (NewFull (reservedSize, elementFreeFunc), Transfer.All)
        //{
        //}

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.22")]
        static extern IntPtr g_ptr_array_new_with_free_func (
            UnmanagedDestroyNotify elementFreeFunc);

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_add (
            IntPtr array,
            IntPtr data);

        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        protected void Add (IntPtr data)
        {
            AssertNotDisposed ();
            g_ptr_array_add (handle, data);
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.4")]
        static extern void g_ptr_array_foreach (
            IntPtr array,
            UnmanagedFunc func,
            IntPtr userData);

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_free (
            IntPtr array,
            bool freeSeg);

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.40")]
        static extern void g_ptr_array_insert (
            IntPtr array,
            int index,
            IntPtr data);

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
        [Since ("2.40")]
        protected void Insert (int index, IntPtr data)
        {
            AssertNotDisposed ();
            if (index < 0 || index > Count) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            g_ptr_array_insert (handle, index, data);
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_ptr_array_remove (
            IntPtr array,
            IntPtr data);

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
        protected bool Remove (IntPtr data)
        {
            AssertNotDisposed ();
            var ret = g_ptr_array_remove (handle, data);
            return ret;
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_ptr_array_remove_fast (
            IntPtr array,
            IntPtr data);

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
        protected bool RemoveFast (IntPtr data)
        {
            AssertNotDisposed ();
            var ret = g_ptr_array_remove_fast (handle, data);
            return ret;
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_remove_index (
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the pointer at the given index from the pointer array.
        /// The following elements are moved down one place. If this array has
        /// a non-<c>null</c> <see cref="DestroyNotify{T}"/> function it is called for the removed
        /// element.
        /// </summary>
        /// <param name="index">
        /// the index of the pointer to remove
        /// </param>
        public void RemoveAt (int index)
        {
            AssertNotDisposed ();
            if (index < 0 || index >= Count) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            g_ptr_array_remove_index (handle, (uint)index);
            // Note: the pointer returned by g_ptr_array_remove_index may not be
            // valid because the free func is called on it so we always ignore it
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_ptr_array_remove_index_fast (
            IntPtr array,
            uint index);

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
        public void RemoveAtFast (int index)
        {
            AssertNotDisposed ();
            if (index < 0 || index >= Count) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            g_ptr_array_remove_index_fast (handle, (uint)index);
            // Note: the pointer returned by g_ptr_array_remove_index may not be
            // valid because the free func is called on it so we always ignore it
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.4")]
        static extern IntPtr g_ptr_array_remove_range (
            IntPtr array,
            uint index,
            uint length);

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
        [Since ("2.4")]
        public void RemoveRange (int index, int length)
        {
            AssertNotDisposed ();
            if (index < 0) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            if (length < 0) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            if (index + length > Count) {
                throw new ArgumentException ("index + length exceeds Count.");
            }
            g_ptr_array_remove_range (handle, (uint)index, (uint)length);
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.22")]
        static extern void g_ptr_array_set_free_func (
            IntPtr array,
            UnmanagedDestroyNotify elementFreeFunc);

        /// <summary>
        /// Sets a function for freeing each element when this array is destroyed
        /// either via <see cref="Unref"/> , when <see cref="Free"/>  is called
        /// with @freeSegment set to <c>true</c> or when removing elements.
        /// </summary>
        /// <param name="elementFreeFunc">
        /// A function to free elements with
        ///     destroy this array or <c>null</c>
        /// </param>
        //[Since("2.22")]
        //public void SetFreeFunc (DestroyNotify<T> elementFreeFunc)
        //{
        //    AssertNotDisposed ();
        //    if (elementFreeFunc == null) {
        //        elementFreeFuncUnmanaged = default(UnmanagedDestroyNotify);
        //    } else {
        //        elementFreeFuncUnmanaged = (elementFreeFuncDataPtr) => {
        //            var elementFreeFuncData = Opaque.GetInstance<T> (elementFreeFuncDataPtr, Transfer.None);
        //            elementFreeFunc (elementFreeFuncData);
        //        };
        //    }
        //    g_ptr_array_set_free_func (handle, elementFreeFuncNative);
        //}

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_set_size (
            IntPtr array,
            int length);

        /// <summary>
        /// Sets the size of the array. When making the array larger,
        /// newly-added elements will be set to <c>null</c>. When making it smaller,
        /// if this array has a non-<c>null</c> <see cref="DestroyNotify{T}"/> function then it will be
        /// called for the removed elements.
        /// </summary>
        /// <param name="length">
        /// the new length of the pointer array
        /// </param>
        public void SetSize (int length)
        {
            AssertNotDisposed ();
            if (length < 0) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            g_ptr_array_set_size (handle, length);
        }

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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_sort (
            IntPtr array,
            UnmanagedCompareFunc compareFunc);

        /// <summary>
        /// Sorts the array, using <paramref name="compareFunc"/> which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if irst arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks> 
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        protected void Sort (Comparison<IntPtr> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            UnmanagedCompareFunc compareFunc_ = (a, b) => {
                var x = Marshal.ReadIntPtr (a);
                var y = Marshal.ReadIntPtr (b);
                var compareFuncRet = compareFunc (x, y);
                return compareFuncRet;
            };
            g_ptr_array_sort (handle, compareFunc_);
            GC.KeepAlive (compareFunc_);
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
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_ptr_array_sort_with_data (
            IntPtr array,
            UnmanagedCompareDataFunc compareFunc,
            IntPtr userData);

        /// <summary>
        /// number of pointers in the array
        /// </summary>
        public int Count {
            get {
                return (int)Len;
            }
        }
    }

    public sealed class PtrArray<T> : PtrArray, IList<T>
        where T : Opaque
    {
        /// <summary>
        /// Adds a pointer to the end of the pointer array. The array will grow
        /// in size automatically if necessary.
        /// </summary>
        /// <param name="data">
        /// the pointer to add
        /// </param>
        public void Add (T data)
        {
            Add (data?.Handle ?? IntPtr.Zero);
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
        [Since ("2.40")]
        public void Insert (int index, T data)
        {
            Insert (index, data?.Handle ?? IntPtr.Zero);
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
        public bool Remove (T data)
        {
            return Remove (data?.Handle ?? IntPtr.Zero);
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
        public bool RemoveFast (T data)
        {
            return RemoveFast (data?.Handle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Sorts the array, using <paramref name="compareFunc"/> which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater than zero if irst arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks> 
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        public void Sort (Comparison<T> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            Comparison<IntPtr> compareFunc_ = (a, b) => {
                var x = GetInstance<T> (a, Transfer.None);
                var y = GetInstance<T> (b, Transfer.None);
                var compareFuncRet = compareFunc (x, y);
                return compareFuncRet;
            };
            Sort (compareFunc_);
        }

        public T this[int index] {
            get {
                AssertNotDisposed ();
                if (index < 0 || index >= Count) {
                    throw new ArgumentOutOfRangeException (nameof (index));
                }
                var retPtr = Marshal.ReadIntPtr (Data, IntPtr.Size * index);
                var ret = GetInstance<T> (retPtr, Transfer.None);
                return ret;
            }
            set {
                AssertNotDisposed ();
                // Doing some tricks to make this faster...
                // this will move the last item to index
                RemoveAtFast (index);
                // and then add the new value to the end
                Add (value);
                // now we have swap the pointers so that the last item is last
                // again and the new item is at index.
                var dataPtr = Data;
                var oldLast = Marshal.ReadIntPtr (dataPtr, IntPtr.Size * index);
                var newItem = Marshal.ReadIntPtr (dataPtr, IntPtr.Size * (Count - 1));
                Marshal.WriteIntPtr (dataPtr, IntPtr.Size * index, newItem);
                Marshal.WriteIntPtr (dataPtr, IntPtr.Size * Count, oldLast);
            }
        }

        bool ICollection<T>.IsReadOnly {
            get {
                AssertNotDisposed ();
                return false;
            }
        }

        /// <summary>
        /// Returns the first index of <paramref name="data"/> in this array.
        /// </summary>
        /// <returns>The index or -1 if <paramref name="data"/> was not found.</returns>
        /// <param name="data">Data.</param>
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

        /// <summary>
        /// Removes all pointers from the array.
        /// </summary>
        public void Clear ()
        {
            SetSize (0);
        }

        /// <summary>
        /// Checks if the array contains <paramref name="data"/>.
        /// </summary>
        /// <returns><c>true</c> if <paramref name="data"/> was found, otherwise
        /// <c>false</c>.</returns>
        /// <param name="data">The item to search for.</param>
        public bool Contains (T data)
        {
            AssertNotDisposed ();
            return IndexOf (data) >= 0;
        }

        public void CopyTo (T[] array, int arrayIndex)
        {
            AssertNotDisposed ();
            if (array == null) {
                throw new ArgumentNullException (nameof (array));
            }
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException (nameof (arrayIndex));
            }
            if (Count > array.Length - arrayIndex) {
                throw new ArgumentException ("Destination array is not long enough.");
            }
            for (int i = 0; i < Count; i++) {
                array[i + arrayIndex] = this[i];
            }
        }

        public IEnumerable<T> Enumerate ()
        {
            for (int i = 0; i < Count; i++) {
                yield return this[i];
            }
        }

        public IEnumerator<T> GetEnumerator ()
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
