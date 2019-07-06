using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Collections;
using GISharp.Runtime;
using GISharp.Lib.GObject;
using System.ComponentModel;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Contains the public fields of a GArray.
    /// </summary>
    [GType ("GArray", IsProxyForUnmanagedType = true)]
    public abstract class Array : Boxed
    {
        static readonly IntPtr dataOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Data));
        static readonly IntPtr lenOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Len));

        private protected struct Struct
        {
            #pragma warning disable CS0649
            public IntPtr Data;
            public uint Len;
            #pragma warning restore CS0649
        }

        private protected IntPtr Data => Marshal.ReadIntPtr(Handle, (int)dataOffset);

        private protected uint Len => (uint)Marshal.ReadInt32(Handle, (int)lenOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Array(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_ref (IntPtr array);

        public override IntPtr Take() => g_array_ref(Handle);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_array_unref (IntPtr array);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_array_get_type ();

        static readonly GType _GType = g_array_get_type();

        /// <summary>
        /// Creates a new #GArray with a reference count of 1.
        /// </summary>
        /// <param name="zeroTerminated">
        /// <c>true</c> if the array should have an extra element at
        ///     the end which is set to 0
        /// </param>
        /// <param name="clear">
        /// <c>true</c> if #GArray elements should be automatically cleared
        ///     to 0 when they are allocated
        /// </param>
        /// <param name="elementSize">
        /// the size of each element in bytes
        /// </param>
        /// <returns>
        /// the new #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_new (
            bool zeroTerminated,
            bool clear,
            uint elementSize);

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
        private protected static IntPtr New(bool zeroTerminated, bool clear, int elementSize)
        {
            if (elementSize < 0) {
                throw new ArgumentOutOfRangeException (nameof (elementSize));
            }
            var ret = g_array_new (zeroTerminated, clear, (uint)elementSize);
            return ret;
        }

        /// <summary>
        /// Creates a new #GArray with @reserved_size elements preallocated and
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
        /// the new #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_sized_new (
            bool zeroTerminated,
            bool clear,
            uint elementSize,
            uint reservedSize);

        private protected static IntPtr SizedNew(bool zeroTerminated, bool clear, int elementSize, int reservedSize)
        {
            if (elementSize < 0) {
                throw new ArgumentOutOfRangeException (nameof (elementSize));
            }
            if (reservedSize < 0) {
                throw new ArgumentOutOfRangeException (nameof (reservedSize));
            }
            var ret = g_array_sized_new (zeroTerminated, clear, (uint)elementSize, (uint)reservedSize);
            return ret;
        }

        /// <summary>
        /// Adds @len elements onto the end of the array.
        /// </summary>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to append to the end of the array
        /// </param>
        /// <param name="len">
        /// the number of elements to append
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_append_vals(
            IntPtr array,
            in Unit data,
            uint len);

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        private protected void AppendVals<T>(ReadOnlySpan<T> data) where T : unmanaged
        {
            var this_ = Handle;
            ref readonly var data_ = ref MemoryMarshal.GetReference(MemoryMarshal.Cast<T, Unit>(data));
            var len_ = (uint)data.Length;
            g_array_append_vals(this_, data_, len_);
        }

        /// <summary>
        /// Gets the size of the elements in this array.
        /// </summary>
        /// <param name="array">
        /// A <see cref="Array{T}"/>
        /// </param>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.22")]
        static extern uint g_array_get_element_size (
            IntPtr array);

        /// <summary>
        /// Gets the size of the elements in this array.
        /// </summary>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [Since ("2.22")]
        public int ElementSize {
            get {
                var ret = g_array_get_element_size(Handle);
                return (int)ret;
            }
        }

        /// <summary>
        /// Inserts @len elements into a #GArray at the given index.
        /// </summary>
        /// <param name="array">
        /// a #GArray
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
        /// the #GArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_insert_vals(
            IntPtr array,
            uint index,
            in Unit data,
            uint len);

        /// <summary>
        /// Inserts elements into a <see cref="Array{T}"/> at the given index.
        /// </summary>
        /// <param name="index">
        /// the index to place the elements at
        /// </param>
        /// <param name="data">
        /// the elements to insert
        /// </param>
        private protected void InsertVals<T>(int index, ReadOnlySpan<T> data) where T : unmanaged
        {
            if (index < 0 || index > Len) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            var this_ = Handle;
            var index_ = (uint)index;
            ref readonly var data_ = ref MemoryMarshal.GetReference(MemoryMarshal.Cast<T, Unit>(data));
            var len_ = (uint)data.Length;
            g_array_insert_vals(this_, index_, data_, len_);
        }

        /// <summary>
        /// Adds @len elements onto the start of the array.
        /// </summary>
        /// <remarks>
        /// This operation is slower than g_array_append_vals() since the
        /// existing elements in the array have to be moved to make space for
        /// the new elements.
        /// </remarks>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to prepend to the start of the array
        /// </param>
        /// <param name="len">
        /// the number of elements to prepend
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_prepend_vals(
            IntPtr array,
            in Unit data,
            uint len);

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
        private protected void PrependVals<T>(ReadOnlySpan<T> data) where T : unmanaged
        {
            var this_ = Handle;
            ref readonly var data_ = ref MemoryMarshal.GetReference(MemoryMarshal.Cast<T, Unit>(data));
            var len_ = (uint)data.Length;
            g_array_prepend_vals(this_, data_, len_);
        }

        /// <summary>
        /// Removes the element at the given index from a #GArray. The following
        /// elements are moved down one place.
        /// </summary>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_remove_index (
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>.
        /// The following elements are moved down one place.
        /// </summary>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        public void RemoveAt (int index)
        {
            var this_ = Handle;
            if (index < 0 || index >= Len) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            g_array_remove_index(this_, (uint)index);
        }

        /// <summary>
        /// Removes the element at the given index from a #GArray. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the #GArray. But it is faster than
        /// g_array_remove_index().
        /// </summary>
        /// <param name="array">
        /// a @GArray
        /// </param>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_remove_index_fast (
            IntPtr array,
            uint index);

        /// <summary>
        /// Removes the element at the given index from a <see cref="Array{T}"/>. The last
        /// element in the array is used to fill in the space, so this function
        /// does not preserve the order of the <see cref="Array{T}"/>. But it is faster than
        /// g_array_remove_index().
        /// </summary>
        /// <param name="index">
        /// the index of the element to remove
        /// </param>
        public void RemoveAtFast (int index)
        {
            var this_ = Handle;
            if (index < 0 || index >= Len) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            g_array_remove_index_fast(this_, (uint)index);
        }

        /// <summary>
        /// Removes the given number of elements starting at the given index
        /// from a #GArray.  The following elements are moved to close the gap.
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
        /// the #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.4")]
        static extern IntPtr g_array_remove_range (
            IntPtr array,
            uint index,
            uint length);

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
        [Since ("2.4")]
        public void RemoveRange (int index, int length)
        {
            var this_ = Handle;
            if (index < 0 || index >= Len) {
                throw new ArgumentOutOfRangeException (nameof (index));
            }
            if (length < 0 || index + length > Len) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            g_array_remove_range(this_, (uint)index, (uint)length);
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
        /// <param name="array">
        /// A #GArray
        /// </param>
        /// <param name="clearFunc">
        /// a function to clear an element of this array
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("2.32")]
        static extern void g_array_set_clear_func (
            IntPtr array,
            UnmanagedDestroyNotify clearFunc);

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with @clear_ set to <c>true</c>, the new elements are set to 0.
        /// </summary>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="length">
        /// the new size of the #GArray
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_set_size (
            IntPtr array,
            uint length);

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with <paramref name="clear"/> set to <c>true</c>, the
        /// new elements are set to 0.
        /// </summary>
        /// <param name="length">
        /// the new size of the <see cref="Array{T}"/>
        /// </param>
        public void SetSize (int length)
        {
            var this_ = Handle;
            if (length < 0) {
                throw new ArgumentOutOfRangeException (nameof (length));
            }
            g_array_set_size(this_, (uint)length);
        }

        /// <summary>
        /// Sorts a #GArray using @compare_func which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </remarks>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_array_sort (
            IntPtr array,
            UnmanagedCompareFunc compareFunc);

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
        private protected void Sort<T>(Comparison<T> compareFunc) where T : unmanaged
        {
            var this_ = Handle;
            UnmanagedCompareFunc compareFunc_ = (a, b) => {
                try {
                    var x = Marshal.PtrToStructure<T>(a);
                    var y = Marshal.PtrToStructure<T>(b);
                    return compareFunc(x, y);
                } catch (Exception ex) {
                    ex.LogUnhandledException();
                    return 0;
                }
            };
            g_array_sort(this_, compareFunc_);
            GC.KeepAlive (compareFunc_);
        }

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
        /// a #GArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        /// <param name="userData">
        /// data to pass to @compare_func
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_array_sort_with_data (
            IntPtr array,
            UnmanagedCompareDataFunc compareFunc,
            IntPtr userData);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_array_free(IntPtr array, bool freeSegment);

        public (IntPtr, int) TakeData()
        {
            var length = (int)Len;
            var data = g_array_free(Handle, false);
            handle = IntPtr.Zero; // object becomes disposed
            return (data, length);
        }

        /// <summary>
        /// Removes all items from the <see cref="Array"/>.
        /// </summary>
        public void Clear ()
        {
            SetSize (0);
        }
    }

    [GType ("GArray", IsProxyForUnmanagedType = true)]
    public sealed class Array<T> : Array, IReadOnlyList<T>, IList<T> where T : unmanaged
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Array (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public new unsafe Span<T> Data => new Span<T>(base.Data.ToPointer(), (int)Len);

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
        public Array (bool zeroTerminated, bool clear = false, int reservedSize = 10)
            : this (SizedNew (zeroTerminated, clear, Marshal.SizeOf<T> (), reservedSize), Transfer.Full)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Array{T}"/> class.
        /// </summary>
        public Array ()
            : this (New (false, false, Marshal.SizeOf<T> ()), Transfer.Full)
        {
        }

        /// <summary>
        /// Adds elements onto the end of the array.
        /// </summary>
        /// <param name="data">
        /// the elements to append to the end of the array
        /// </param>
        public void Append(ReadOnlySpan<T> data) => AppendVals<T>(data);

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
        public void Add(T data)
        {
            Append (data);
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
        public void Insert(int index, ReadOnlySpan<T> data) => InsertVals<T>(index, data);

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
        void IList<T>.Insert (int index, T data)
        {
            Insert (index, data);
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
        public void Prepend(ReadOnlySpan<T> data) => PrependVals<T>(data);

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
        public void Sort (Comparison<T> compareFunc)
        {
            Sort<T> (compareFunc);
        }

        bool ICollection<T>.IsReadOnly => false;

        public T this[int index] {
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

        public bool Contains (T other)
        {
            for (int i = 0; i < Len; i++) {
                if (this[i].Equals (other)) {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo (T[] array, int arrayIndex)
        {
            if (arrayIndex < 0) {
                throw new ArgumentOutOfRangeException (nameof (arrayIndex));
            }
            if (arrayIndex + Len > array.Length) {
                throw new ArgumentException ("Destination array is not long enough.");
            }
            for (int i = 0; i < Len; i++) {
                array[i + arrayIndex] = this[i];
            }
        }

        public int IndexOf (T data)
        {
            for (int i = 0; i < Len; i++) {
                if (this[i].Equals (data)) {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove (T data)
        {
            for (int i = 0; i < Len; i++) {
                if (this[i].Equals (data)) {
                    RemoveAt (i);
                    return true;
                }
            }
            return false;
        }

        public int Count => (int)Len;
        IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Len; i++) {
                yield return this[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static unsafe implicit operator Span<T>(Array<T>? array)
        {
            if (array == null) {
                return default(Span<T>);
            }

            return array.Data;
        }
    }
}
