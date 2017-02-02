using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The <see cref="List"/> struct is used for each element in a doubly-linked list.
    /// </summary>
    public abstract class List : Opaque
    {
        public sealed class SafeListHandle : SafeHandleMinusOneIsInvalid
        {
            public SafeListHandle (IntPtr handle, Transfer ownership)
            {
                if (ownership != Transfer.Container) {
                    throw new NotSupportedException ("Must own container");
                }
                SetHandle (handle);
            }

            // lists get a new head pointer, so we need to expose SetHandle() internally
            internal void UpdateHead (IntPtr head)
            {
                SetHandle (head);
            }

            [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern void g_list_free (IntPtr array);

            protected override bool ReleaseHandle ()
            {
                try {
                    g_list_free (handle);
                    return true;
                } catch {
                    return false;
                }
            }
        }

        public new SafeListHandle Handle {
            get {
                return (SafeListHandle)base.Handle;
            }
        }

        public List (SafeListHandle handle) : base (handle)
        {
        }

        static SafeListHandle New ()
        {
            var ret = new SafeListHandle (IntPtr.Zero, Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public List () : this (New ())
        {
        }

        /// <summary>
        /// Allocates space for one #GList element. It is called by
        /// g_list_append(), g_list_prepend(), g_list_insert() and
        /// g_list_insert_sorted() and so is rarely used on its own.
        /// </summary>
        /// <returns>
        /// a pointer to the newly-allocated #GList element
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_alloc();

        /// <summary>
        /// Adds the second #GList onto the end of the first #GList.
        /// Note that the elements of the second #GList are not copied.
        /// They are used directly.
        /// </summary>
        /// <remarks>
        /// This function is for example used to move an element in the list.
        /// The following example moves an element to the top of the list:
        /// |[&lt;!-- language="C" --&gt;
        /// list = g_list_remove_link (list, llink);
        /// list = g_list_concat (llink, list);
        /// ]|
        /// </remarks>
        /// <param name="list1">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="list2">
        /// the #GList to add to the end of the first #GList,
        ///     this must point  to the top of the list
        /// </param>
        /// <returns>
        /// the start of the new #GList, which equals @list1 if not %NULL
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_concat (
            SafeListHandle list1,
            SafeListHandle list2);

        /// <summary>
        /// Adds the second <see cref="List{T}"/> onto the end of the first <see cref="List{T}"/>.
        /// Note that the elements of the second <see cref="List{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list1">
        /// a <see cref="List{T}"/>, this must point to the top of the list
        /// </param>
        /// <param name="list2">
        /// the <see cref="List{T}"/> to add to the end of the first <see cref="List{T}"/>,
        ///     this must point  to the top of the list
        /// </param>
        /// <returns>
        /// the new <see cref="List{T}"/>
        /// </returns>
        protected List Concat (List list2)
        {
            AssertNotDisposed ();
            if (list2 == null) {
                throw new ArgumentNullException (nameof (list2));
            }
            list2.AssertNotDisposed ();
            var ret_ = g_list_concat (Handle, list2.Handle);
            Handle.UpdateHead (ret_);
            list2.Handle.SetHandleAsInvalid ();
            return this;
        }

        /// <summary>
        /// Adds a new element on to the end of the list.
        /// </summary>
        /// <remarks>
        /// Note that the return value is the new start of the list,
        /// if @list was empty; make sure you store the new value.
        /// 
        /// g_list_append() has to traverse the entire list to find the end,
        /// which is inefficient when adding multiple elements. A common idiom
        /// to avoid the inefficiency is to use g_list_prepend() and reverse
        /// the list with g_list_reverse() when all elements have been added.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// // Notice that these are initialized to the empty list.
        /// GList *string_list = NULL, *number_list = NULL;
        /// 
        /// // This is a list of strings.
        /// string_list = g_list_append (string_list, "first");
        /// string_list = g_list_append (string_list, "second");
        /// 
        /// // This is a list of integers.
        /// number_list = g_list_append (number_list, GINT_TO_POINTER (27));
        /// number_list = g_list_append (number_list, GINT_TO_POINTER (14));
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a pointer to a #GList
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// either @list or the new start of the #GList if @list was %NULL
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_append (
            SafeListHandle list,
            IntPtr data);

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
        /// <returns>
        /// either this list or the new start of the <see cref="List"/> if this list was <c>null</c>
        /// </returns>
        protected List Append (IntPtr data)
        {
            AssertNotDisposed ();
            var ret_ = g_list_append (Handle, data);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Copies a #GList.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See g_list_copy_deep() if you need
        /// to copy the data as well.
        /// </remarks>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <returns>
        /// the start of the new list that holds the same data as @list
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_copy (
            SafeListHandle list);

        /// <summary>
        /// Copies a <see cref="List{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See <see cref="CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// the start of the new list that holds the same data as @list
        /// </returns>
        protected List Copy ()
        {
            AssertNotDisposed ();
            var ret_ = g_list_copy (Handle);
            var ret = new SafeListHandle (ret_, Transfer.Container);
            return (List)Activator.CreateInstance (GetType (), ret);
        }

        /// <summary>
        /// Makes a full (deep) copy of a #GList.
        /// </summary>
        /// <remarks>
        /// In contrast with g_list_copy(), this function uses @func to make
        /// a copy of each list element, in addition to copying the list
        /// container itself.
        /// 
        /// @func, as a #GCopyFunc, takes two arguments, the data to be copied
        /// and a @user_data pointer. It's safe to pass %NULL as user_data,
        /// if the copy function takes only one argument.
        /// 
        /// For instance, if @list holds a list of GObjects, you can do:
        /// |[&lt;!-- language="C" --&gt;
        /// another_list = g_list_copy_deep (list, (GCopyFunc) g_object_ref, NULL);
        /// ]|
        /// 
        /// And, to entirely free the new list, you could do:
        /// |[&lt;!-- language="C" --&gt;
        /// g_list_free_full (another_list, g_object_unref);
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="func">
        /// a copy function used to copy every element in the list
        /// </param>
        /// <param name="userData">
        /// user data passed to the copy function @func, or %NULL
        /// </param>
        /// <returns>
        /// the start of the new list that holds a full copy of @list,
        ///     use g_list_free_full() to free it
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.34")]
        static extern SafeListHandle g_list_copy_deep (
            SafeListHandle list,
            NativeCopyFunc func,
            IntPtr userData);

        /// <summary>
        /// Removes the node link_ from the list and frees it.
        /// Compare this to g_list_remove_link() which removes the node
        /// without freeing it.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="link">
        /// node to delete from @list
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_delete_link (
            SafeListHandle list,
            IntPtr link);

        /// <summary>
        /// Finds the element in a #GList which contains the given data.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the element data to find
        /// </param>
        /// <returns>
        /// the found #GList element, or %NULL if it is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_find (
            SafeListHandle list,
            IntPtr data);

        /// <summary>
        /// Finds an element in a #GList, using a supplied function to
        /// find the desired element. It iterates over the list, calling
        /// the given function which should return 0 when the desired
        /// element is found. The function takes two #gconstpointer arguments,
        /// the #GList element's data as the first argument and the
        /// given user data.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// user data passed to the function
        /// </param>
        /// <param name="func">
        /// the function to call for each element.
        ///     It should return 0 when the desired element is found
        /// </param>
        /// <returns>
        /// the found #GList element, or %NULL if it is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_find_custom (
            SafeListHandle list,
            IntPtr data,
            NativeCompareFunc func);

        /// <summary>
        /// Gets the first element in a #GList.
        /// </summary>
        /// <param name="list">
        /// any #GList element
        /// </param>
        /// <returns>
        /// the first element in the #GList,
        ///     or %NULL if the #GList has no elements
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_first (
            SafeListHandle list);

        /// <summary>
        /// Calls a function for each element of a #GList.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_list_foreach (
            SafeListHandle list,
            NativeFunc func,
            IntPtr userData);
        
        /// <summary>
        /// Convenience method, which frees all the memory used by a #GList,
        /// and calls @free_func on every element's data.
        /// </summary>
        /// <param name="list">
        /// a pointer to a #GList
        /// </param>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.28")]
        static extern void g_list_free_full (
            SafeListHandle list,
            NativeDestroyNotify freeFunc);

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_list_index (
            SafeListHandle list,
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
        protected int IndexOf (IntPtr data)
        {
            AssertNotDisposed ();
            var ret = g_list_index (Handle, data);
            return ret;
        }

        /// <summary>
        /// Frees one #GList element.
        /// It is usually used after g_list_remove_link().
        /// </summary>
        /// <param name="list">
        /// a #GList element
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_list_free_1 (
            SafeListHandle list);

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="list">
        /// a pointer to a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element. If this is
        ///     negative, or is larger than the number of elements in the
        ///     list, the new element is added on to the end of the list.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_insert (
            SafeListHandle list,
            IntPtr data,
            int position);

        /// <summary>
        /// Inserts a new element into the list at the given position.
        /// </summary>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="position">
        /// the position to insert the element. If this is
        ///     negative, or is larger than the number of elements in the
        ///     list, the new element is added on to the end of the list.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        protected List Insert (IntPtr data, int position)
        {
            AssertNotDisposed ();
            var ret_ = g_list_insert (Handle, data, position);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Inserts a new element into the list before the given position.
        /// </summary>
        /// <param name="list">
        /// a pointer to a #GList, this must point to the top of the list
        /// </param>
        /// <param name="sibling">
        /// the list element before which the new element
        ///     is inserted or %NULL to insert at the end of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_insert_before (
            SafeListHandle list,
            IntPtr sibling,
            IntPtr data);

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
        /// <param name="list">
        /// a pointer to a #GList, this must point to the top of the
        ///     already sorted list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        ///     return a number &gt; 0 if the first parameter comes after the
        ///     second parameter in the sort order.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_insert_sorted (
            SafeListHandle list,
            IntPtr data,
            NativeCompareFunc func);

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
        /// <param name="list">
        /// a pointer to a #GList, this must point to the top of the
        ///     already sorted list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        ///     return a number &gt; 0 if the first parameter  comes after the
        ///     second parameter in the sort order.
        /// </param>
        /// <param name="userData">
        /// user data to pass to comparison function
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.10")]
        static extern IntPtr g_list_insert_sorted_with_data (
            SafeListHandle list,
            IntPtr data,
            NativeCompareDataFunc func,
            IntPtr userData);

        /// <summary>
        /// Gets the last element in a #GList.
        /// </summary>
        /// <param name="list">
        /// any #GList element
        /// </param>
        /// <returns>
        /// the last element in the #GList,
        ///     or %NULL if the #GList has no elements
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_last ( 
            SafeListHandle list);

        /// <summary>
        /// Gets the number of elements in a #GList.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list to count its elements.
        /// Use a #GQueue instead of a GList if you regularly need the number
        /// of items.
        /// </remarks>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <returns>
        /// the number of elements in the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_list_length (
            SafeListHandle list);

        /// <summary>
        /// Gets the number of elements in a <see cref="List{T}"/>.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list to count its elements.
        /// Use a <see cref="GISharp.GLib.Queue"/> instead of a List if you regularly need the number
        /// of items.
        /// </remarks>
        /// <returns>
        /// the number of elements in the <see cref="List{T}"/>
        /// </returns>
        public int Length {
            get {
                AssertNotDisposed ();
                return (int)g_list_length (Handle);
            }
        }

        /// <summary>
        /// Gets the element at the given position in a #GList.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or %NULL if the position is off
        ///     the end of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_nth (
            SafeListHandle list,
            uint n);

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if the position
        ///     is off the end of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_nth_data (
            SafeListHandle list,
            uint n);

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
        protected IntPtr NthData (int n) {
            AssertNotDisposed ();
            if (n < 0) {
                throw new ArgumentOutOfRangeException (nameof (n));
            }
            var ret = g_list_nth_data (Handle, (uint)n);
            return ret;
        }

        /// <summary>
        /// Gets the element @n places before @list.
        /// </summary>
        /// <param name="list">
        /// a #GList
        /// </param>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or %NULL if the position is
        ///     off the end of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_nth_prev (
            SafeListHandle list,
            uint n);

        /// <summary>
        /// Gets the position of the given element
        /// in the #GList (starting from 0).
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="llink">
        /// an element in the #GList
        /// </param>
        /// <returns>
        /// the position of the element in the #GList,
        ///     or -1 if the element is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_list_position (
            SafeListHandle list,
            IntPtr llink);

        /// <summary>
        /// Prepends a new element on to the start of the list.
        /// </summary>
        /// <remarks>
        /// Note that the return value is the new start of the list,
        /// which will have changed, so make sure you store the new value.
        /// 
        /// |[&lt;!-- language="C" --&gt;
        /// // Notice that it is initialized to the empty list.
        /// GList *list = NULL;
        /// 
        /// list = g_list_prepend (list, "last");
        /// list = g_list_prepend (list, "first");
        /// ]|
        /// 
        /// Do not use this function to prepend a new element to a different
        /// element than the start of the list. Use g_list_insert_before() instead.
        /// </remarks>
        /// <param name="list">
        /// a pointer to a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// a pointer to the newly prepended element, which is the new
        ///     start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_prepend (
            SafeListHandle list,
            IntPtr data);

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
        /// <returns>
        /// the newly prepended element, which is the new
        ///     start of the <see cref="List{T}"/>
        /// </returns>
        protected List Prepend (IntPtr data)
        {
            AssertNotDisposed ();
            var ret_ = g_list_prepend (Handle, data);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Removes an element from a #GList.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the #GList is unchanged.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_remove (
            SafeListHandle list,
            IntPtr data);

        /// <summary>
        /// Removes an element from a <see cref="List{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="List{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        protected List Remove (IntPtr data)
        {
            AssertNotDisposed ();
            var ret_ = g_list_remove (Handle, data);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Removes all list nodes with data equal to @data.
        /// Returns the new head of the list. Contrast with
        /// g_list_remove() which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// data to remove
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_remove_all (
            SafeListHandle list,
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
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        protected List RemoveAll (IntPtr data)
        {
            AssertNotDisposed ();
            var ret_ = g_list_remove_all (Handle, data);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Removes an element from a #GList, without freeing the element.
        /// The removed element's prev and next links are set to %NULL, so
        /// that it becomes a self-contained list with one element.
        /// </summary>
        /// <remarks>
        /// This function is for example used to move an element in the list
        /// (see the example for g_list_concat()) or to remove an element in
        /// the list before freeing its data:
        /// |[&lt;!-- language="C" --&gt;
        /// list = g_list_remove_link (list, llink);
        /// free_some_data_that_may_access_the_list_again (llink-&gt;data);
        /// g_list_free (llink);
        /// ]|
        /// </remarks>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="llink">
        /// an element in the #GList
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_remove_link (
            SafeListHandle list,
            IntPtr llink);

        /// <summary>
        /// Reverses a #GList.
        /// It simply switches the next and prev pointers of each element.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <returns>
        /// the start of the reversed #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_reverse (
            SafeListHandle list);

        /// <summary>
        /// Reverses a <see cref="List{T}"/>.
        /// It simply switches the next and prev pointers of each element.
        /// </summary>
        /// <returns>
        /// the start of the reversed <see cref="List{T}"/>
        /// </returns>
        protected List Reverse ()
        {
            AssertNotDisposed ();
            var ret_ = g_list_reverse (Handle);
            Handle.UpdateHead (ret_);
            return this;
        }

        /// <summary>
        /// Sorts a #GList using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="compareFunc">
        /// the comparison function used to sort the #GList.
        ///     This function is passed the data from 2 elements of the #GList
        ///     and should return 0 if they are equal, a negative value if the
        ///     first element comes before the second, or a positive value if
        ///     the first element comes after the second.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_sort (
            SafeListHandle list,
            NativeCompareFunc compareFunc);

        /// <summary>
        /// Sorts a <see cref="List{T}"/> using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="List{T}"/>.
        ///     This function is passed the data from 2 elements of the <see cref="List{T}"/>
        ///     and should return 0 if they are equal, a negative value if the
        ///     first element comes before the second, or a positive value if
        ///     the first element comes after the second.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        protected List Sort (NativeCompareFunc compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            var ret_ = g_list_sort (Handle, compareFunc);
            GC.KeepAlive (compareFunc);
            Handle.UpdateHead (ret_);
            return this;
        }
        /// <summary>
        /// Like g_list_sort(), but the comparison function accepts
        /// a user data argument.
        /// </summary>
        /// <param name="list">
        /// a #GList, this must point to the top of the list
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        /// <param name="userData">
        /// user data to pass to comparison function
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the #GList
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_list_sort_with_data (
            SafeListHandle list,
            NativeCompareDataFunc compareFunc,
            IntPtr userData);
    }

    public sealed class List<T> : List where T : Opaque
    {
        /// <summary>
        /// Adds the second <see cref="List{T}"/> onto the end of the first <see cref="List{T}"/>.
        /// Note that the elements of the second <see cref="List{T}"/> are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the <see cref="List{T}"/> to add to the end of the first <see cref="List{T}"/>,
        ///     this must point  to the top of the list
        /// </param>
        /// <returns>
        /// the new <see cref="List{T}"/>
        /// </returns>
        public List<T> Concat (List<T> list2)
        {
            var ret = base.Concat (list2);
            return (List<T>)ret;
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
        /// <returns>
        /// either this list or the new start of the <see cref="List{T}"/> if this list was <c>null</c>
        /// </returns>
        public List<T> Append (T data)
        {
            var ret = Append (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero);
            return (List<T>)ret;
        }

        /// <summary>
        /// Copies a <see cref="List{T}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data is not. See <see cref="CopyDeep"/> if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// the start of the new list that holds the same data as @list
        /// </returns>
        public new List<T> Copy ()
        {
            var ret = base.Copy ();
            return (List<T>)ret;
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
        public int IndexOf (T data)
        {
            var ret = IndexOf (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero);
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
        ///     negative, or is larger than the number of elements in the
        ///     list, the new element is added on to the end of the list.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Insert (T data, int position)
        {
            var ret = Insert (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero, position);
            return (List<T>)ret;
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
        public T this[int n] {
            get {
                var ret_ = NthData (n);
                var ret = GetInstance<T> (ret_, Transfer.None);
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
        /// <returns>
        /// the newly prepended element, which is the new
        ///     start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Prepend (T data)
        {
            var ret = Prepend (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero);
            return (List<T>)ret;
        }

        /// <summary>
        /// Removes an element from a <see cref="List{T}"/>.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the <see cref="List{T}"/> is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Remove (T data)
        {
            var ret = Remove (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero);
            return (List<T>)ret;
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
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> RemoveAll (T data)
        {
            var ret = RemoveAll (data?.Handle.DangerousGetHandle () ?? IntPtr.Zero);
            return (List<T>)ret;
        }

        /// <summary>
        /// Reverses a <see cref="List{T}"/>.
        /// It simply switches the next and prev pointers of each element.
        /// </summary>
        /// <returns>
        /// the start of the reversed <see cref="List{T}"/>
        /// </returns>
        public new List<T> Reverse ()
        {
            var ret = base.Reverse ();
            return (List<T>)ret;
        }

        /// <summary>
        /// Sorts a <see cref="List{T}"/> using the given comparison function. The algorithm
        /// used is a stable sort.
        /// </summary>
        /// <param name="compareFunc">
        /// the comparison function used to sort the <see cref="List{T}"/>.
        ///     This function is passed the data from 2 elements of the <see cref="List{T}"/>
        ///     and should return 0 if they are equal, a negative value if the
        ///     first element comes before the second, or a positive value if
        ///     the first element comes after the second.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Sort (Comparison<T> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            NativeCompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = compareFunc.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var ret = Sort (compareFuncNative);
            return (List<T>)ret;
        }
    }
}
