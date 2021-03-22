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
    unsafe partial class List
    {
        /// <inheritdoc/>
        public override IntPtr UnsafeHandle => handle; // null handle is OK here

        private protected List(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                GC.SuppressFinalize(this);
                throw new ArgumentException("Can't handle unowned list, use UnownedList<T> instead", nameof(ownership));
            }
        }

        /// <summary>
        /// Adds the second <see cref="List"/> onto the end of the first <see cref="List"/>.
        /// Note that the elements of the second <see cref="List"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="List"/> to add to the end of the first <see cref="List"/>,
        ///     this must point  to the top of the list
        /// </param>
        private protected void Concat(List list2)
        {
            var list1_ = (UnmanagedStruct*)handle;
            var list2_ = (UnmanagedStruct*)list2.handle;
            handle = (IntPtr)g_list_concat(list1_, list2_);
            list2.handle = IntPtr.Zero;
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// Note that the return value is the new start of the list,
        /// if @list was empty; make sure you store the new value.
        ///
        /// <see cref="Append"/> has to traverse the entire list to find the end,
        /// which is inefficient when adding multiple elements. A common idiom
        /// to avoid the inefficiency is to use <see cref="Prepend"/> and reverse
        /// the list with <see cref="Reverse"/> when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        private protected void Append(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_append(list_, data);
        }

        /// <summary>
        /// Copies a <see cref="List{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// the start of the new list that holds the same data as @list
        /// </returns>
        private protected List Copy()
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret_ = g_list_copy(list_);
            var ret = Activator.CreateInstance(GetType(), (IntPtr)ret_, Transfer.Container);
            return (List)ret!;
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="List"/>.
        /// </summary>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        private protected void Foreach<T>(Func<T> func) where T : Opaque?
        {
            var list_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)&FuncMarshal.Callback;

            var marshalFunc = new Func((IntPtr data_) => {
                var data = GetInstance<T>(data_, Transfer.None);
                func(data);
            });

            var userDataHandle = GCHandle.Alloc((marshalFunc, CallbackScope.Call));
            var userData_ = (IntPtr)userDataHandle;
            g_list_foreach(list_, func_, userData_);
            GMarshal.PopUnhandledException();
            userDataHandle.Free();
        }

        private protected void Free() => g_list_free((UnmanagedStruct*)handle);

        private protected void FreeFull(delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc) =>
            g_list_free_full((UnmanagedStruct*)handle, freeFunc);

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        private protected int IndexOf(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret = g_list_index(list_, data);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element. If this is
        /// negative, or is larger than the number of elements in the
        /// list, the new element is added on to the end of the list.
        /// </param>
        private protected void Insert(IntPtr data, int position)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_insert(list_, data, position);
        }

        /// <summary>
        /// Inserts a new element into the list before the given position.
        /// </summary>
        /// <param name="sibling">
        /// the list element before which the new element
        /// is inserted or <c>null</c> to insert at the end of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        private protected void InsertBefore(IntPtr sibling, IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            var sibling_ = (UnmanagedStruct*)sibling;
            handle = (IntPtr)g_list_insert_before(list_, sibling_, data);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given comparison
        /// function to determine its position.
        /// </summary>
        /// <remarks>
        /// If you are adding many new elements to a list, and the number of
        /// new elements is much larger than the length of the list, use
        /// g_list_prepend() to add the new items and sort the list afterwards
        /// with g_list_sort().
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        /// return a number &gt; 0 if the first parameter comes after the
        /// second parameter in the sort order.
        /// </param>
        private protected void InsertSorted(IntPtr data, UnmanagedCompareFunc func)
        {
            var list_ = (UnmanagedStruct*)handle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)Marshal.GetFunctionPointerForDelegate(func);
            handle = (IntPtr)g_list_insert_sorted(list_, data, func_);
        }

        /// <summary>
        /// Gets the number of elements in a <see cref="List"/>.
        /// </summary>
        /// <remarks>
        /// This iterates over the whole list to count its elements.
        /// Use a <see cref="T:GLib.Queue"/> instead of a List if you
        /// regularly need the number of items.
        /// </remarks>
        /// <returns>
        /// the number of elements in the <see cref="List"/>
        /// </returns>
        public int Length {
            get {
                var list_ = (UnmanagedStruct*)handle;
                var ret = g_list_length(list_);
                GMarshal.PopUnhandledException();
                return (int)ret;
            }
        }

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or <c>null</c> if the position
        ///     is off the end of the <see cref="List{T}"/>
        /// </returns>
        private protected IntPtr NthData(int n)
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret = g_list_nth_data(list_, (uint)n);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Prepends a new element on to the start of the list.
        /// </summary>
        /// <remarks>
        /// Do not use this function to prepend a new element to a different
        /// element than the start of the list. Use <see cref="InsertBefore"/> instead.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        private protected void Prepend(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_prepend(list_, data);
        }

        /// <summary>
        /// Removes an element from a <see cref="List{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="List{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        private protected void Remove(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_remove(list_, data);
        }

        /// <summary>
        /// Removes all list nodes with data equal to <paramref name="data"/>.
        /// Returns the new head of the list. Contrast with
        /// <see cref="Remove"/> which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        private protected void RemoveAll(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_remove_all(list_, data);
        }

        /// <summary>
        /// Reverses a <see cref="List{T}"/>.
        /// It simply switches the next and prev pointers of each element.
        /// </summary>
        public void Reverse()
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_list_reverse(list_);
        }

        /// <summary>
        /// Sorts a <see cref="List{T}"/> using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="List{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="List{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        private protected void Sort(UnmanagedCompareFunc compareFunc)
        {
            var list_ = (UnmanagedStruct*)handle;
            var compareFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)Marshal.GetFunctionPointerForDelegate(compareFunc);
            handle = (IntPtr)g_list_sort(list_, compareFunc_);
        }
    }

    /// <summary>
    /// Enumerates a <see cref="List{T}"/>.
    /// </summary>
    public sealed unsafe class ListEnumerator<T> : Opaque, IEnumerator<T> where T : IOpaque?
    {
        readonly IntPtr start;
        IntPtr next;

        internal ListEnumerator(IntPtr start) : base(IntPtr.Zero)
        {
            this.start = start;
            Reset();
        }

        /// <inheritdoc/>
        public void Reset() => next = start;

        /// <inheritdoc/>
        public T Current => GetInstance<T>(((List.UnmanagedStruct*)UnsafeHandle)->Data, Transfer.None);

        object? IEnumerator.Current => Current;

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (next == IntPtr.Zero) {
                return false;
            }
            handle = next;
            next = (IntPtr)((List.UnmanagedStruct*)UnsafeHandle)->Next;
            return true;
        }
    }

    /// <summary>
    /// A doubly linked list. The list does not own the data, so caution must
    /// be used since the data or the list itself could be freed at any time.
    /// </summary>
    public sealed unsafe class UnownedList<T> : IEnumerable<T> where T : IOpaque?
    {
        private readonly List.UnmanagedStruct* handle;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedList(List.UnmanagedStruct* handle)
        {
            this.handle = handle;
        }

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator<T>((IntPtr)handle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new ListEnumerator<T>((IntPtr)handle);
    }

    /// <summary>
    /// A doubly linked list. The list does not own the data, so caution must
    /// be used since the data could be freed at any time.
    /// </summary>
    public sealed unsafe class WeakList<T> : List, IEnumerable<T> where T : Opaque?
    {
        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public WeakList() : this(IntPtr.Zero, Transfer.Container)
        {
        }

        private static Transfer AssertWeak(Transfer ownership)
        {
            if (ownership != Transfer.Container) {
                throw new ArgumentException("requires Transfer.Container", nameof(ownership));
            }
            return ownership;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WeakList(IntPtr handle, Transfer ownership) : base(handle, AssertWeak(ownership))
        {
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            Free();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Adds the second <see cref="WeakList{T}"/> onto the end of the first <see cref="WeakList{T}"/>.
        /// Note that the elements of the second <see cref="WeakList{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="WeakList{T}"/> to add to the end of the first <see cref="WeakList{T}"/>,
        /// this must point to the top of the list
        /// </param>
        public void Concat(WeakList<T> list2)
        {
            base.Concat(list2);
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// <see cref="Append"/> has to traverse the entire list to find the end,
        /// which is inefficient when adding multiple elements. A common idiom
        /// to avoid the inefficiency is to use <see cref="Prepend"/> and reverse
        /// the list with <see cref="List.Reverse"/> when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Append(T data)
        {
            Append(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Copies a <see cref="WeakList{T}" />.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// the start of the new list that holds the same data as
        /// this list
        /// </returns>
        public new WeakList<T> Copy()
        {
            var ret = base.Copy();
            return (WeakList<T>)ret;
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="List"/>.
        /// </summary>
        /// <remarks>
        /// Not recommended for use in managed code. Use built-in foreach statement instead.
        /// </remarks>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Foreach(Func<T> func)
        {
            Foreach<T>(func);
        }

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        public int IndexOf(T data)
        {
            var ret = IndexOf(data?.UnsafeHandle ?? IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element. If this is
        /// negative, or is larger than the number of elements in the
        /// list, the new element is added on to the end of the list.
        /// </param>
        public void Insert(T data, int position)
        {
            Insert(data?.UnsafeHandle ?? IntPtr.Zero, position);
        }

        /// <summary>
        /// Inserts a new element into the list before the given position.
        /// </summary>
        /// <param name="sibling">
        /// the list element before which the new element
        /// is inserted or <c>null</c> to insert at the end of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void InsertBefore(ListEnumerator<T>? sibling, T data)
        {
            InsertBefore(sibling?.UnsafeHandle ?? IntPtr.Zero, data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given comparison
        /// function to determine its position.
        /// </summary>
        /// <remarks>
        /// If you are adding many new elements to a list, and the number of
        /// new elements is much larger than the length of the list, use
        /// <see cref="Prepend" /> to add the new items and sort the list
        /// afterwards with <see cref="Sort" />.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        /// return a number &gt; 0 if the first parameter comes after the
        /// second parameter in the sort order.
        /// </param>
        public void InsertSorted(T data, Comparison<T> func)
        {
            int func_(IntPtr a_, IntPtr b_)
            {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            InsertSorted(data?.UnsafeHandle ?? IntPtr.Zero, func_);
        }

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or <c>null</c> if the position
        /// is off the end of the <see cref="WeakList{T}"/>
        /// </returns>
        public T this[int n] {
            get {
                if (n < 0 || n >= Length) {
                    throw new ArgumentOutOfRangeException(nameof(n));
                }
                var ret_ = NthData(n);
                var ret = GetInstance<T>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Prepends a new element on to the start of the list.
        /// </summary>
        /// <remarks>
        /// Do not use this function to prepend a new element to a different
        /// element than the start of the list. Use <see cref="InsertBefore"/> instead.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Prepend(T data)
        {
            Prepend(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from a <see cref="WeakList{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="WeakList{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        public void Remove(T data)
        {
            Remove(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes all list nodes with data equal to <paramref name="data"/>.
        /// Returns the new head of the list. Contrast with
        /// <see cref="Remove"/> which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        public void RemoveAll(T data)
        {
            RemoveAll(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Sorts a <see cref="WeakList{T}"/> using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="WeakList{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="WeakList{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        public void Sort(Comparison<T> compareFunc)
        {
            int compareFunc_(IntPtr a_, IntPtr b_)
            {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new ListEnumerator<T>(UnsafeHandle);
    }

    /// <summary>
    /// A doubly linked list.
    /// </summary>
    public sealed unsafe class List<T> : List, IEnumerable<T> where T : Opaque?
    {
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyData;
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc;

        static List()
        {
            var methods = typeof(T).GetMethods(Static | NonPublic);

            // var copyMethodInfo = methods.Single(m => m.IsDefined(typeof(PtrArrayCopyFuncAttribute), false));
            // copyData = (Func<IntPtr, IntPtr>)copyMethodInfo.CreateDelegate(typeof(Func<IntPtr, IntPtr>));
            copyData = default!;

            var freeMethodInfo = methods.Single(m => m.IsDefined(typeof(PtrArrayFreeFuncAttribute), false));
            freeFunc = (delegate* unmanaged[Cdecl]<IntPtr, void>)freeMethodInfo.MethodHandle.GetFunctionPointer();
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public List() : this(IntPtr.Zero, Transfer.Container)
        {
        }

        private static Transfer AssertStrong(Transfer ownership)
        {
            if (ownership != Transfer.Full) {
                throw new ArgumentException("requires Transfer.Full", nameof(ownership));
            }
            return ownership;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List(IntPtr handle, Transfer ownership) : base(handle, AssertStrong(ownership))
        {
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            FreeFull(freeFunc);
            base.Dispose(disposing);
        }

        /// <summary>
        /// Adds the second <see cref="List{T}"/> onto the end of the first <see cref="List{T}"/>.
        /// Note that the elements of the second <see cref="List{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="List{T}"/> to add to the end of the first <see cref="List{T}"/>,
        /// this must point to the top of the list
        /// </param>
        public void Concat(List<T> list2)
        {
            base.Concat(list2);
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// <see cref="Append"/> has to traverse the entire list to find the end,
        /// which is inefficient when adding multiple elements. A common idiom
        /// to avoid the inefficiency is to use <see cref="Prepend"/> and reverse
        /// the list with <see cref="List.Reverse"/> when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Append(T data)
        {
            Append(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Copies a <see cref="List{T}" />.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// the start of the new list that holds the same data as
        /// this list
        /// </returns>
        public new WeakList<T> Copy()
        {
            var ret = base.Copy();
            return (WeakList<T>)ret;
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="List"/>.
        /// </summary>
        /// <remarks>
        /// Not recommended for use in managed code. Use built-in foreach statement instead.
        /// </remarks>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Foreach(Func<T> func)
        {
            Foreach<T>(func);
        }

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        public int IndexOf(T data)
        {
            var ret = IndexOf(data?.UnsafeHandle ?? IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element. If this is
        /// negative, or is larger than the number of elements in the
        /// list, the new element is added on to the end of the list.
        /// </param>
        public void Insert(T data, int position)
        {
            Insert(data?.UnsafeHandle ?? IntPtr.Zero, position);
        }

        /// <summary>
        /// Inserts a new element into the list before the given position.
        /// </summary>
        /// <param name="sibling">
        /// the list element before which the new element
        /// is inserted or <c>null</c> to insert at the end of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void InsertBefore(ListEnumerator<T>? sibling, T data)
        {
            InsertBefore(sibling?.UnsafeHandle ?? IntPtr.Zero, data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given comparison
        /// function to determine its position.
        /// </summary>
        /// <remarks>
        /// If you are adding many new elements to a list, and the number of
        /// new elements is much larger than the length of the list, use
        /// <see cref="Prepend" /> to add the new items and sort the list
        /// afterwards with <see cref="Sort" />.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        /// return a number &gt; 0 if the first parameter comes after the
        /// second parameter in the sort order.
        /// </param>
        public void InsertSorted(T data, Comparison<T> func)
        {
            int func_(IntPtr a_, IntPtr b_)
            {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            InsertSorted(data?.UnsafeHandle ?? IntPtr.Zero, func_);
        }

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or <c>null</c> if the position
        /// is off the end of the <see cref="List{T}"/>
        /// </returns>
        public T this[int n] {
            get {
                if (n < 0 || n >= Length) {
                    throw new ArgumentOutOfRangeException(nameof(n));
                }
                var ret_ = NthData(n);
                var ret = GetInstance<T>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Prepends a new element on to the start of the list.
        /// </summary>
        /// <remarks>
        /// Do not use this function to prepend a new element to a different
        /// element than the start of the list. Use <see cref="InsertBefore"/> instead.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Prepend(T data)
        {
            Prepend(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from a <see cref="List{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="List{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        public void Remove(T data)
        {
            Remove(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes all list nodes with data equal to <paramref name="data"/>.
        /// Returns the new head of the list. Contrast with
        /// <see cref="Remove"/> which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        public void RemoveAll(T data)
        {
            RemoveAll(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Sorts a <see cref="List{T}"/> using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="List{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="List{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        public void Sort(Comparison<T> compareFunc)
        {
            int compareFunc_(IntPtr a_, IntPtr b_)
            {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new ListEnumerator<T>(UnsafeHandle);
    }
}
