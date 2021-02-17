// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using GISharp.Runtime;

using static System.Reflection.BindingFlags;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The <see cref="SList"/> struct is used for each element in the singly-linked
    /// list.
    /// </summary>
    [GType("GSList", IsProxyForUnmanagedType = true)]
    public abstract unsafe class SList : Opaque
    {
        private readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyData;
        private readonly delegate* unmanaged[Cdecl]<IntPtr, void> freeData;
        private readonly bool weak;

        /// <summary>
        /// The unmanaged data structure for <see cref="SList"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct UnmanagedStruct
        {
#pragma warning disable CS0649
            internal IntPtr Data;
            internal IntPtr Next;
#pragma warning restore CS0649
        }

        /// <inheritdoc/>
        public override IntPtr UnsafeHandle {
            get {
                // null handle is OK here
                return handle;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private protected SList(IntPtr handle,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyData,
            delegate* unmanaged[Cdecl]<IntPtr, void> freeData,
            Transfer ownership) : base(handle)
        {
            this.copyData = copyData;
            this.freeData = freeData;

            if (ownership == Transfer.None) {
                GC.SuppressFinalize(this);
                throw new NotSupportedException("must start with owned SList");
            }
            if (ownership == Transfer.Container) {
                weak = true;
            }
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        private protected SList(
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyData,
            delegate* unmanaged[Cdecl]<IntPtr, void> freeData
        ) : this(IntPtr.Zero, copyData, freeData, Transfer.Container)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_slist_free(UnmanagedStruct* list);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            var list_ = (UnmanagedStruct*)handle;
            if (weak) {
                g_slist_free(list_);
            }
            else {
                g_slist_free_full(list_, freeData);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Allocates space for one #GSList element. It is called by the
        /// g_slist_append(), g_slist_prepend(), g_slist_insert() and
        /// g_slist_insert_sorted() functions and so is rarely used on its own.
        /// </summary>
        /// <returns>
        /// a pointer to the newly-allocated #GSList element.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_alloc();

        /// <summary>
        /// Adds the second #GSList onto the end of the first #GSList.
        /// Note that the elements of the second #GSList are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list1">
        /// a #GSList
        /// </param>
        /// <param name="list2">
        /// the #GSList to add to the end of the first #GSList
        /// </param>
        /// <returns>
        /// the start of the new #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_concat(
            UnmanagedStruct* list1,
            UnmanagedStruct* list2);

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
            list2.handle = IntPtr.Zero;
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// The return value is the new start of the list, which may
        /// have changed, so make sure you store the new value.
        ///
        /// Note that g_slist_append() has to traverse the entire list
        /// to find the end, which is inefficient when adding multiple
        /// elements. A common idiom to avoid the inefficiency is to prepend
        /// the elements and reverse the list when all elements have been added.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// // Notice that these are initialized to the empty list.
        /// GSList *list = NULL, *number_list = NULL;
        ///
        /// // This is a list of strings.
        /// list = g_slist_append (list, "first");
        /// list = g_slist_append (list, "second");
        ///
        /// // This is a list of integers.
        /// number_list = g_slist_append (number_list, GINT_TO_POINTER (27));
        /// number_list = g_slist_append (number_list, GINT_TO_POINTER (14));
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_append(
            UnmanagedStruct* list,
            IntPtr data);

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
        }

        /// <summary>
        /// Copies a #GSList.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data isn't. See g_slist_copy_deep() if you need
        /// to copy the data as well.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <returns>
        /// a copy of @list
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_copy(
            UnmanagedStruct* list);

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
        private protected SList Copy()
        {
            var list_ = (UnmanagedStruct*)handle;
            var ret_ = g_slist_copy(list_);
            var ret = Activator.CreateInstance(GetType(), (IntPtr)ret_, Transfer.Container);
            return (SList)ret!;
        }

        /// <summary>
        /// Makes a full (deep) copy of a #GSList.
        /// </summary>
        /// <remarks>
        /// In contrast with g_slist_copy(), this function uses @func to make a copy of
        /// each list element, in addition to copying the list container itself.
        ///
        /// @func, as a #GCopyFunc, takes two arguments, the data to be copied and a user
        /// pointer. It's safe to pass #NULL as user_data, if the copy function takes only
        /// one argument.
        ///
        /// For instance, if @list holds a list of GObjects, you can do:
        /// |[&lt;!-- language="C" --&gt;
        /// another_list = g_slist_copy_deep (list, (GCopyFunc) g_object_ref, NULL);
        /// ]|
        ///
        /// And, to entirely free the new list, you could do:
        /// |[&lt;!-- language="C" --&gt;
        /// g_slist_free_full (another_list, g_object_unref);
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="func">
        /// a copy function used to copy every element in the list
        /// </param>
        /// <param name="userData">
        /// user data passed to the copy function @func, or #NULL
        /// </param>
        /// <returns>
        /// a full copy of @list, use #g_slist_free_full to free it
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.34")]
        static extern UnmanagedStruct* g_slist_copy_deep(
            UnmanagedStruct* list,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr> func,
            IntPtr userData);

        /// <summary>
        /// Removes the node link_ from the list and frees it.
        /// Compare this to g_slist_remove_link() which removes the node
        /// without freeing it.
        /// </summary>
        /// <remarks>
        /// Removing arbitrary nodes from a singly-linked list requires time
        /// that is proportional to the length of the list (ie. O(n)). If you
        /// find yourself using g_slist_delete_link() frequently, you should
        /// consider a different data structure, such as the doubly-linked
        /// #GList.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="link">
        /// node to delete
        /// </param>
        /// <returns>
        /// the new head of @list
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_delete_link(
            UnmanagedStruct* list,
            UnmanagedStruct* link);

        /// <summary>
        /// Finds the element in a #GSList which
        /// contains the given data.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the element data to find
        /// </param>
        /// <returns>
        /// the found #GSList element,
        ///     or %NULL if it is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_find(
            UnmanagedStruct* list,
            IntPtr data);

        /// <summary>
        /// Finds an element in a #GSList, using a supplied function to
        /// find the desired element. It iterates over the list, calling
        /// the given function which should return 0 when the desired
        /// element is found. The function takes two #gconstpointer arguments,
        /// the #GSList element's data as the first argument and the
        /// given user data.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// user data passed to the function
        /// </param>
        /// <param name="func">
        /// the function to call for each element.
        ///     It should return 0 when the desired element is found
        /// </param>
        /// <returns>
        /// the found #GSList element, or %NULL if it is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_find_custom(
            UnmanagedStruct* list,
            IntPtr data,
            UnmanagedCompareFunc func);

        /// <summary>
        /// Calls a function for each element of a #GSList.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_slist_foreach(
            UnmanagedStruct* list,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> func,
            IntPtr userData);

        /// <summary>
        /// Calls a function for each element of a <see cref="SList"/>.
        /// </summary>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        private protected void Foreach<T>(Func<T> func) where T : IOpaque?
        {
            var list_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)&ForeachFunc;
            var userDataHandle = GCHandle.Alloc(new ForeachUserData(typeof(T), func));
            var userData_ = (IntPtr)userDataHandle;
            g_slist_foreach(list_, func_, userData_);
            userDataHandle.Free();
        }

        private record ForeachUserData(Type TypeArg, Delegate Func);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void ForeachFunc(IntPtr data_, IntPtr userData_)
        {
            try {
                var userData = (ForeachUserData)GCHandle.FromIntPtr(userData_).Target!;
                var data = GetInstance(userData.TypeArg, data_, Transfer.None);
                userData.Func.DynamicInvoke(data);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Frees one #GSList element.
        /// It is usually used after g_slist_remove_link().
        /// </summary>
        /// <param name="list">
        /// a #GSList element
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_slist_free_1(
            UnmanagedStruct* list);

        /// <summary>
        /// Convenience method, which frees all the memory used by a #GSList, and
        /// calls the specified destroy function on every element's data.
        /// </summary>
        /// <param name="list">
        /// a pointer to a #GSList
        /// </param>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.28")]
        static extern void g_slist_free_full(
            UnmanagedStruct* list,
            delegate* unmanaged[Cdecl]<IntPtr, void> freeFunc);

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_slist_index(
            UnmanagedStruct* list,
            IntPtr data);

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
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element.
        ///     If this is negative, or is larger than the number
        ///     of elements in the list, the new element is added on
        ///     to the end of the list.
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_insert(
            UnmanagedStruct* list,
            IntPtr data,
            int position);

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
        }

        /// <summary>
        /// Inserts a node before @sibling containing @data.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="sibling">
        /// node to insert @data before
        /// </param>
        /// <param name="data">
        /// data to put in the newly-inserted node
        /// </param>
        /// <returns>
        /// the new head of the list.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_insert_before(
            UnmanagedStruct* list,
            UnmanagedStruct* sibling,
            IntPtr data);

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
        }

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list.
        ///     It should return a number &gt; 0 if the first parameter
        ///     comes after the second parameter in the sort order.
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_insert_sorted(
            UnmanagedStruct* list,
            IntPtr data,
            UnmanagedCompareFunc func);

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
            handle = (IntPtr)g_slist_insert_sorted(list_, data, func);
        }

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list.
        ///     It should return a number &gt; 0 if the first parameter
        ///     comes after the second parameter in the sort order.
        /// </param>
        /// <param name="userData">
        /// data to pass to comparison function
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.10")]
        static extern UnmanagedStruct* g_slist_insert_sorted_with_data(
            UnmanagedStruct* list,
            IntPtr data,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, int> func,
            IntPtr userData);

        /// <summary>
        /// Gets the last element in a #GSList.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <returns>
        /// the last element in the #GSList,
        ///     or %NULL if the #GSList has no elements
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_last(
            UnmanagedStruct* list);

        /// <summary>
        /// Gets the number of elements in a #GSList.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list to
        /// count its elements.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <returns>
        /// the number of elements in the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_slist_length(
            UnmanagedStruct* list);

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
        public int Length {
            get {
                var list_ = (UnmanagedStruct*)handle;
                var ret = g_slist_length(list_);
                return (int)ret;
            }
        }

        /// <summary>
        /// Gets the element at the given position in a #GSList.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or %NULL if the position is off
        ///     the end of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_nth(
            UnmanagedStruct* list,
            uint n);

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if the position
        ///     is off the end of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_slist_nth_data(
            UnmanagedStruct* list,
            uint n);

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
            return ret;
        }

        /// <summary>
        /// Gets the position of the given element
        /// in the #GSList (starting from 0).
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="llink">
        /// an element in the #GSList
        /// </param>
        /// <returns>
        /// the position of the element in the #GSList,
        ///     or -1 if the element is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_slist_position(
            UnmanagedStruct* list,
            UnmanagedStruct* llink);

        /// <summary>
        /// Adds a new element on to the start of the list.
        /// </summary>
        /// <remarks>
        /// The return value is the new start of the list, which
        /// may have changed, so make sure you store the new value.
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// // Notice that it is initialized to the empty list.
        /// GSList *list = NULL;
        /// list = g_slist_prepend (list, "last");
        /// list = g_slist_prepend (list, "first");
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_prepend(
            UnmanagedStruct* list,
            IntPtr data);

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
        }

        /// <summary>
        /// Removes an element from a #GSList.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the #GSList is unchanged.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_remove(
            UnmanagedStruct* list,
            IntPtr data);

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
        }

        /// <summary>
        /// Removes all list nodes with data equal to @data.
        /// Returns the new head of the list. Contrast with
        /// g_slist_remove() which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="data">
        /// data to remove
        /// </param>
        /// <returns>
        /// new head of @list
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_remove_all(
            UnmanagedStruct* list,
            IntPtr data);

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
        }

        /// <summary>
        /// Removes an element from a #GSList, without
        /// freeing the element. The removed element's next
        /// link is set to %NULL, so that it becomes a
        /// self-contained list with one element.
        /// </summary>
        /// <remarks>
        /// Removing arbitrary nodes from a singly-linked list
        /// requires time that is proportional to the length of the list
        /// (ie. O(n)). If you find yourself using g_slist_remove_link()
        /// frequently, you should consider a different data structure,
        /// such as the doubly-linked #GList.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="link">
        /// an element in the #GSList
        /// </param>
        /// <returns>
        /// the new start of the #GSList, without the element
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_remove_link(
            UnmanagedStruct* list,
            UnmanagedStruct* link);

        /// <summary>
        /// Reverses a #GSList.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <returns>
        /// the start of the reversed #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_reverse(
            UnmanagedStruct* list);

        /// <summary>
        /// Reverses a <see cref="SList{T}"/>.
        /// </summary>
        public void Reverse()
        {
            var list_ = (UnmanagedStruct*)handle;
            handle = (IntPtr)g_slist_reverse(list_);
        }

        /// <summary>
        /// Sorts a #GSList using the given comparison function.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="compareFunc">
        /// the comparison function used to sort the #GSList.
        ///     This function is passed the data from 2 elements of the #GSList
        ///     and should return 0 if they are equal, a negative value if the
        ///     first element comes before the second, or a positive value if
        ///     the first element comes after the second.
        /// </param>
        /// <returns>
        /// the start of the sorted #GSList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_sort(
            UnmanagedStruct* list,
            UnmanagedCompareFunc compareFunc);

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
            handle = (IntPtr)g_slist_sort(list_, compareFunc);
        }

        /// <summary>
        /// Like g_slist_sort(), but the sort function accepts a user data argument.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        /// <param name="userData">
        /// data to pass to comparison function
        /// </param>
        /// <returns>
        /// new head of the list
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_slist_sort_with_data(
            UnmanagedStruct* list,
            delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, int> compareFunc,
            IntPtr userData);
    }

    /// <summary>
    /// Enumerator for <see cref="SList{T}"/>.
    /// </summary>
    public sealed unsafe class SListEnumerator<T> : Opaque, IEnumerator<T> where T : IOpaque?
    {
        readonly IntPtr start;
        IntPtr next;

        internal SListEnumerator(IntPtr start) : base(IntPtr.Zero)
        {
            this.start = start;
            Reset();
        }

        /// <inheritdoc/>
        public void Reset() => next = start;

        /// <inheritdoc/>
        public T Current => GetInstance<T>(((SList.UnmanagedStruct*)UnsafeHandle)->Data, Transfer.None);

        object? IEnumerator.Current => Current;

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (next == IntPtr.Zero) {
                return false;
            }
            handle = next;
            next = ((SList.UnmanagedStruct*)UnsafeHandle)->Next;
            return true;
        }
    }

    /// <summary>
    /// A singally linked list. The list does not own the data, so caution must
    /// be used since the data or the list itself could be freed at any time.
    /// </summary>
    public sealed unsafe class UnownedSList<T> : IEnumerable<T> where T : IOpaque?
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
    public sealed unsafe class WeakSList<T> : SList, IEnumerable<T> where T : IOpaque?
    {
        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public WeakSList() : this(IntPtr.Zero, Transfer.Container)
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
        public WeakSList(IntPtr handle, Transfer ownership) : base(handle, default, default, AssertWeak(ownership))
        {
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
        public void Concat(WeakSList<T> list2)
        {
            base.Concat(list2);
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
        public new WeakSList<T> Copy()
        {
            var ret = base.Copy();
            return (WeakSList<T>)ret;
        }

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
            UnmanagedCompareFunc func_ = (a_, b_) => {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            };
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
            UnmanagedCompareFunc compareFunc_ = (a_, b_) => {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            };
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);
    }

    /// <summary>
    /// A singally linked list.
    /// </summary>
    public sealed unsafe class SList<T> : SList, IEnumerable<T> where T : IOpaque?
    {
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, IntPtr> copyData;
        private static readonly delegate* unmanaged[Cdecl]<IntPtr, void> freeData;

        static SList()
        {
            var methods = typeof(T).GetMethods(Static | NonPublic);

            // var copyMethodInfo = methods.Single(m => m.IsDefined(typeof(PtrArrayCopyFuncAttribute), false));
            // copyData = (Func<IntPtr, IntPtr>)copyMethodInfo.CreateDelegate(typeof(Func<IntPtr, IntPtr>));
            copyData = default!;

            var freeMethodInfo = methods.Single(m => m.IsDefined(typeof(PtrArrayFreeFuncAttribute), false));
            freeData = (delegate* unmanaged[Cdecl]<IntPtr, void>)freeMethodInfo.MethodHandle.GetFunctionPointer();
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public SList() : this(IntPtr.Zero, Transfer.Container)
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
        public SList(IntPtr handle, Transfer ownership) : base(handle, copyData, freeData, AssertStrong(ownership))
        {
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
        public void Concat(SList<T> list2)
        {
            base.Concat(list2);
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
        public new WeakSList<T> Copy()
        {
            var ret = base.Copy();
            return (WeakSList<T>)ret;
        }

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
            UnmanagedCompareFunc func_ = (a_, b_) => {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = func(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            };
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
            UnmanagedCompareFunc compareFunc_ = (a_, b_) => {
                try {
                    var a = GetInstance<T>(a_, Transfer.None);
                    var b = GetInstance<T>(b_, Transfer.None);
                    var ret = compareFunc.Invoke(a, b);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            };
            Sort(compareFunc_);
        }

        IEnumerator IEnumerable.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new SListEnumerator<T>(UnsafeHandle);
    }
}
