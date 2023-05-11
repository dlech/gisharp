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
    unsafe partial class SList
    {
        /// <inheritdoc/>
        public override IntPtr UnsafeHandle => handle; // null handle is OK here

        private protected SList(IntPtr handle, Transfer ownership)
            : base(handle)
        {
            if (ownership == Transfer.None)
            {
                GC.SuppressFinalize(this);
                throw new ArgumentException("requires owned SList", nameof(ownership));
            }
        }

        /// <summary>
        /// Adds the second <see cref="SList"/> onto the end of the first <see cref="SList"/>.
        /// Note that the elements of the second <see cref="SList"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="SList"/> to add to the end of the first <see cref="SList"/>
        /// </param>
        private protected void Concat(SList list2)
        {
            var list1_ = (UnmanagedStruct*)handle;
            var list2_ = (UnmanagedStruct*)list2.handle;
            handle = (IntPtr)g_slist_concat(list1_, list2_);
            GMarshal.PopUnhandledException();
            list2.handle = IntPtr.Zero;
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// The return value is the new start of the list, which may
        /// have changed, so make sure you store the new value.
        ///
        /// Note that <see cref="Append"/> has to traverse the entire list
        /// to find the end, which is inefficient when adding multiple
        /// elements. A common idiom to avoid the inefficiency is to prepend
        /// the elements and reverse the list when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        private protected void Append(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_append(list_, data);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Copies a <see cref="SList{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data isn't. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// a copy of @list
        /// </returns>
        private protected WeakSList<T> Copy<T>()
            where T : IOpaque?
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret_ = g_slist_copy(list_);
            GMarshal.PopUnhandledException();
            var ret = new WeakSList<T>((IntPtr)ret_, Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="SList"/>.
        /// </summary>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        private protected void Foreach<T>(Func<T> func)
            where T : IOpaque?
        {
            var list_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)&FuncMarshal.Callback;

            var marshalFunc = new Func(
                (IntPtr data_) =>
                {
                    var data = GetInstance<T>(data_, Transfer.None);
                    func(data);
                }
            );

            var userDataHandle = GCHandle.Alloc((marshalFunc, CallbackScope.Call));
            var userData_ = (IntPtr)userDataHandle;
            g_slist_foreach(list_, func_, userData_);
            GMarshal.PopUnhandledException();
            userDataHandle.Free();
        }

        private protected void Free()
        {
            g_slist_free((UnmanagedStruct*)handle);
            GMarshal.PopUnhandledException();
        }

        private protected void FreeFull(delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc)
        {
            g_slist_free_full((UnmanagedStruct*)handle, freeFunc);
            GMarshal.PopUnhandledException();
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
        private protected int IndexOf(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret = g_slist_index(list_, data);
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
        /// the position to insert the element.
        /// If this is negative, or is larger than the number
        /// of elements in the list, the new element is added on
        /// to the end of the list.
        /// </param>
        private protected void Insert(IntPtr data, int position)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_insert(list_, data, position);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Inserts a node before <paramref name="sibling"/> containing <paramref name="data"/>.
        /// </summary>
        /// <param name="sibling">
        /// node to insert <paramref name="data"/> before
        /// </param>
        /// <param name="data">
        /// data to put in the newly-inserted node
        /// </param>
        private protected void InsertBefore(IntPtr sibling, IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            var sibling_ = (UnmanagedStruct*)sibling;
            handle = (IntPtr)g_slist_insert_before(list_, sibling_, data);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list.
        /// It should return a number &gt; 0 if the first parameter
        /// comes after the second parameter in the sort order.
        /// </param>
        private protected void InsertSorted(IntPtr data, UnmanagedCompareFunc func)
        {
            var list_ = (UnmanagedStruct*)handle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)
                Marshal.GetFunctionPointerForDelegate(func);
            handle = (IntPtr)g_slist_insert_sorted(list_, data, func_);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Gets the number of elements in a <see cref="SList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list to
        /// count its elements.
        /// </remarks>
        /// <returns>
        /// the number of elements in the <see cref="SList{T}"/>
        /// </returns>
        public int Length
        {
            get
            {
                var list_ = (UnmanagedStruct*)handle;
                var ret = g_slist_length(list_);
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
        ///     is off the end of the <see cref="SList{T}"/>
        /// </returns>
        private protected IntPtr NthData(int n)
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret = g_slist_nth_data(list_, (uint)n);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Adds a new element on to the start of the list.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        protected void Prepend(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_prepend(list_, data);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Removes an element from a <see cref="SList{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="SList{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        protected void Remove(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_remove(list_, data);
            GMarshal.PopUnhandledException();
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
        protected void RemoveAll(IntPtr data)
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_remove_all(list_, data);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Reverses a <see cref="SList{T}"/>.
        /// </summary>
        public void Reverse()
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_reverse(list_);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sorts a <see cref="SList{T}"/> using the given comparison function.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="SList{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="SList{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        protected void Sort(UnmanagedCompareFunc compareFunc)
        {
            var list_ = (UnmanagedStruct*)handle;
            var compareFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, int>)
                Marshal.GetFunctionPointerForDelegate(compareFunc);
            handle = (IntPtr)g_slist_sort(list_, compareFunc_);
            GMarshal.PopUnhandledException();
        }
    }

    /// <summary>
    /// Enumerator for <see cref="SList{T}"/>.
    /// </summary>
    public sealed unsafe class SListEnumerator<T> : Opaque, IEnumerator<T>
        where T : IOpaque?
    {
        readonly IntPtr start;
        IntPtr next;

        internal SListEnumerator(IntPtr start)
            : base(IntPtr.Zero)
        {
            this.start = start;
            Reset();
        }

        /// <inheritdoc/>
        public void Reset() => next = start;

        /// <inheritdoc/>
        public T Current =>
            GetInstance<T>(((SList.UnmanagedStruct*)UnsafeHandle)->Data, Transfer.None);

        object? IEnumerator.Current => Current;

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (next == IntPtr.Zero)
            {
                return false;
            }
            handle = next;
            next = (IntPtr)((SList.UnmanagedStruct*)UnsafeHandle)->Next;
            return true;
        }
    }

    /// <summary>
    /// A singally linked list. The list does not own the data, so caution must
    /// be used since the data or the list itself could be freed at any time.
    /// </summary>
    public sealed unsafe class UnownedSList<T> : IEnumerable<T>
        where T : IOpaque?
    {
        private readonly SList.UnmanagedStruct* handle;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnownedSList(SList.UnmanagedStruct* handle)
        {
            this.handle = handle;
        }

        IEnumerator IEnumerable.GetEnumerator() => new SListEnumerator<T>((IntPtr)handle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SListEnumerator<T>((IntPtr)handle);
    }

    /// <summary>
    /// A singally linked list. The list does not own the data, so caution must
    /// be used since the data could be freed at any time.
    /// </summary>
    public sealed unsafe class WeakSList<T> : SList, IEnumerable<T>
        where T : IOpaque?
    {
        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public WeakSList()
            : this(IntPtr.Zero, Transfer.Container) { }

        private static Transfer AssertWeak(Transfer ownership)
        {
            if (ownership != Transfer.Container)
            {
                throw new ArgumentException("requires Transfer.Container", nameof(ownership));
            }
            return ownership;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WeakSList(IntPtr handle, Transfer ownership)
            : base(handle, AssertWeak(ownership)) { }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            Free();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Adds the second <see cref="SList{T}"/> onto the end of the first <see cref="SList{T}"/>.
        /// Note that the elements of the second <see cref="SList{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="SList{T}"/> to add to the end of the first <see cref="SList{T}"/>
        /// </param>
        /// <remarks>
        /// <paramref name="list2"/> will be empty after calling this method.
        /// </remarks>
        public void Concat(WeakSList<T> list2) => base.Concat(list2);

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// The return value is the new start of the list, which may
        /// have changed, so make sure you store the new value.
        ///
        /// Note that <see cref="Append"/> has to traverse the entire list
        /// to find the end, which is inefficient when adding multiple
        /// elements. A common idiom to avoid the inefficiency is to prepend
        /// the elements and reverse the list when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Append(T data)
        {
            Append(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Copies a <see cref="SList{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data isn't. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// a copy of this list
        /// </returns>
        public WeakSList<T> Copy() => Copy<T>();

        /// <summary>
        /// Calls a function for each element of a <see cref="SList"/>.
        /// </summary>
        /// <remarks>
        /// Not recommended for use in managed code. Use built-in foreach statement instead.
        /// </remarks>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Foreach(Func<T> func) => Foreach<T>(func);

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
        public int IndexOf(T data) => IndexOf(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element.
        /// If this is negative, or is larger than the number
        /// of elements in the list, the new element is added on
        /// to the end of the list.
        /// </param>
        public void Insert(T data, int position)
        {
            Insert(data?.UnsafeHandle ?? IntPtr.Zero, position);
        }

        /// <summary>
        /// Inserts a node before <paramref name="sibling"/> containing <paramref name="data"/>.
        /// </summary>
        /// <param name="sibling">
        /// node to insert <paramref name="data"/> before
        /// </param>
        /// <param name="data">
        /// data to put in the newly-inserted node
        /// </param>
        public void InsertBefore(SListEnumerator<T>? sibling, T data)
        {
            InsertBefore(sibling?.UnsafeHandle ?? IntPtr.Zero, data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list.
        /// It should return a number &gt; 0 if the first parameter
        /// comes after the second parameter in the sort order.
        /// </param>
        public void InsertSorted(T data, Comparison<T> func)
        {
            int func_(IntPtr a_, IntPtr b_)
            {
                try
                {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex)
                {
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
        /// is off the end of the <see cref="WeakSList{T}"/>
        /// </returns>
        public T this[int n]
        {
            get
            {
                if (n < 0 || n >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(n));
                }
                var ret_ = NthData(n);
                var ret = GetInstance<T>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Adds a new element on to the start of the list.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Prepend(T data)
        {
            Prepend(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from a <see cref="SList{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="SList{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        public void Remove(T data) => Remove(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Removes all list nodes with data equal to <paramref name="data"/>.
        /// Returns the new head of the list. Contrast with
        /// <see cref="Remove"/> which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        public void RemoveAll(T data) => RemoveAll(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Sorts a <see cref="SList{T}"/> using the given comparison function.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="SList{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="SList{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        public void Sort(Comparison<T> compareFunc)
        {
            int compareFunc_(IntPtr a_, IntPtr b_)
            {
                try
                {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex)
                {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);
    }

    /// <summary>
    /// A singally linked list.
    /// </summary>
    public sealed unsafe class SList<T> : SList, IEnumerable<T>
        where T : IOpaque?
    {
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyFunc;
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc;

        static SList()
        {
            var methods = typeof(T).GetMethods(Static | NonPublic);

            // var copyMethodInfo = methods.Single(m => m.IsDefined(typeof(PtrArrayCopyFuncAttribute), false));
            // copyData = (Func<IntPtr, IntPtr>)copyMethodInfo.CreateDelegate(typeof(Func<IntPtr, IntPtr>));
            copyFunc = default!;

            var freeMethodInfo = methods.Single(
                m => m.IsDefined(typeof(PtrArrayFreeFuncAttribute), false)
            );
            freeFunc = (delegate* unmanaged[Cdecl]<IntPtr, void>)
                freeMethodInfo.MethodHandle.GetFunctionPointer();
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public SList()
            : this(IntPtr.Zero, Transfer.Container) { }

        private static Transfer AssertStrong(Transfer ownership)
        {
            if (ownership != Transfer.Full)
            {
                throw new ArgumentException("requires Transfer.Full", nameof(ownership));
            }
            return ownership;
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SList(IntPtr handle, Transfer ownership)
            : base(handle, AssertStrong(ownership)) { }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            FreeFull(freeFunc);
            base.Dispose(disposing);
        }

        /// <summary>
        /// Adds the second <see cref="SList{T}"/> onto the end of the first <see cref="SList{T}"/>.
        /// Note that the elements of the second <see cref="SList{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="SList{T}"/> to add to the end of the first <see cref="SList{T}"/>
        /// </param>
        /// <remarks>
        /// <paramref name="list2"/> will be empty after calling this method.
        /// </remarks>
        public void Concat(SList<T> list2) => base.Concat(list2);

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// The return value is the new start of the list, which may
        /// have changed, so make sure you store the new value.
        ///
        /// Note that <see cref="Append"/> has to traverse the entire list
        /// to find the end, which is inefficient when adding multiple
        /// elements. A common idiom to avoid the inefficiency is to prepend
        /// the elements and reverse the list when all elements have been added.
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Append(T data) => Append(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Copies a <see cref="SList{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data isn't. See <see cref="M:CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// a copy of this list
        /// </returns>
        public WeakSList<T> Copy => Copy<T>();

        /// <summary>
        /// Calls a function for each element of a <see cref="SList"/>.
        /// </summary>
        /// <remarks>
        /// Not recommended for use in managed code. Use built-in foreach statement instead.
        /// </remarks>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Foreach(Func<T> func) => Foreach<T>(func);

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
        public int IndexOf(T data) => IndexOf(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element.
        /// If this is negative, or is larger than the number
        /// of elements in the list, the new element is added on
        /// to the end of the list.
        /// </param>
        public void Insert(T data, int position) =>
            Insert(data?.UnsafeHandle ?? IntPtr.Zero, position);

        /// <summary>
        /// Inserts a node before <paramref name="sibling"/> containing <paramref name="data"/>.
        /// </summary>
        /// <param name="sibling">
        /// node to insert <paramref name="data"/> before
        /// </param>
        /// <param name="data">
        /// data to put in the newly-inserted node
        /// </param>
        public void InsertBefore(SListEnumerator<T>? sibling, T data)
        {
            InsertBefore(sibling?.UnsafeHandle ?? IntPtr.Zero, data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list.
        /// It should return a number &gt; 0 if the first parameter
        /// comes after the second parameter in the sort order.
        /// </param>
        public void InsertSorted(T data, Comparison<T> func)
        {
            int func_(IntPtr a_, IntPtr b_)
            {
                try
                {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex)
                {
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
        /// is off the end of the <see cref="SList{T}"/>
        /// </returns>
        public T this[int n]
        {
            get
            {
                if (n < 0 || n >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(n));
                }
                var ret_ = NthData(n);
                var ret = GetInstance<T>(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Adds a new element on to the start of the list.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        public void Prepend(T data)
        {
            Prepend(data?.UnsafeHandle ?? IntPtr.Zero);
        }

        /// <summary>
        /// Removes an element from a <see cref="SList{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="SList{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        public void Remove(T data) => Remove(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Removes all list nodes with data equal to <paramref name="data"/>.
        /// Returns the new head of the list. Contrast with
        /// <see cref="Remove"/> which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        public void RemoveAll(T data) => RemoveAll(data?.UnsafeHandle ?? IntPtr.Zero);

        /// <summary>
        /// Sorts a <see cref="SList{T}"/> using the given comparison function.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="SList{T}"/>.
        /// This function is passed the data from 2 elements of the <see cref="SList{T}"/>
        /// and should return 0 if they are equal, a negative value if the
        /// first element comes before the second, or a positive value if
        /// the first element comes after the second.
        /// </param>
        public void Sort(Comparison<T> compareFunc)
        {
            int compareFunc_(IntPtr a_, IntPtr b_)
            {
                try
                {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex)
                {
                    GMarshal.PushUnhandledException(ex);
                    return default;
                }
            }
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);
    }
}
