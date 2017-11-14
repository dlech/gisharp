using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The #GSList struct is used for each element in the singly-linked
    /// list.
    /// </summary>
    public abstract class SList : Opaque
    {
        static readonly IntPtr dataOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Data));
        static readonly IntPtr nextOffset = Marshal.OffsetOf<Struct> (nameof(Struct.Next));

        struct Struct
        {
            #pragma warning disable CS0649
            public IntPtr Data;
            public IntPtr Next;
            #pragma warning restore CS0649
        }

        IntPtr Data {
            get {
                if (Handle == IntPtr.Zero) {
                    throw new InvalidOperationException ();
                }
                var ret = Marshal.ReadIntPtr (Handle, (int)dataOffset);
                return ret;
            }
        }

        IntPtr Next {
            get {
                if (Handle == IntPtr.Zero) {
                    throw new InvalidOperationException ();
                }
                var ret = Marshal.ReadIntPtr (Handle, (int)nextOffset);
                return ret;
            }
        }

        public SList (IntPtr handle, Transfer ownership) : base (handle)
        {
            if (ownership == Transfer.None) {
                Handle = g_slist_copy (handle);
            }
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_slist_free (IntPtr list);

        protected override void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                g_slist_free (Handle);
            }
            base.Dispose (disposing);
        }

        protected SList () : this (IntPtr.Zero, Transfer.Full)
        {
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
        internal static extern IntPtr g_slist_alloc ();

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
        internal static extern IntPtr g_slist_concat (
            IntPtr list1,
            IntPtr list2);

        /// <summary>
        /// Adds the second #GSList onto the end of the first #GSList.
        /// Note that the elements of the second #GSList are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the #GSList to add to the end of the first #GSList
        /// </param>
        /// <returns>
        /// the start of the new #GSList
        /// </returns>
        protected SList Concat (SList list2)
        {
            if (list2 == null) {
                throw new ArgumentNullException (nameof (list2));
            }
            Handle = g_slist_concat (Handle, list2.Handle);
            list2.Handle = IntPtr.Zero;
            return this;
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
        internal static extern IntPtr g_slist_append (
            IntPtr list,
            IntPtr data);

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
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        protected SList Append (IntPtr data)
        {
            Handle = g_slist_append (Handle, data);
            return this;
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
        internal static extern IntPtr g_slist_copy (
            IntPtr list);

        /// <summary>
        /// Copies a #GSList.
        /// </summary>
        /// <remarks>
        /// Note that this is a "shallow" copy. If the list elements
        /// consist of pointers to data, the pointers are copied but
        /// the actual data isn't. See g_slist_copy_deep() if you need
        /// to copy the data as well.
        /// </remarks>
        /// <returns>
        /// a copy of @list
        /// </returns>
        protected SList Copy ()
        {
            var ret = g_slist_copy (Handle);
            var copy = Activator.CreateInstance (GetType (), ret);
            return (SList)copy;
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
        internal static extern IntPtr g_slist_copy_deep (
            IntPtr list,
            NativeCopyFunc func,
            IntPtr userData);

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
        /// <param name="func">
        /// a copy function used to copy every element in the list
        /// </param>
        /// <returns>
        /// a full copy of @list, use #g_slist_free_full to free it
        /// </returns>
        [Since("2.34")]
        protected SList CopyDeep (Func<IntPtr, IntPtr> func)
        {
            if (func == null) {
                throw new ArgumentNullException (nameof (func));
            }
            NativeCopyFunc funcNative = (funcSrcPtr, funcDataPtr) => {
                var funcRet = func (funcSrcPtr);
                return funcRet;
            };
            var ret = g_slist_copy_deep (Handle, funcNative, IntPtr.Zero);
            GC.KeepAlive (funcNative);
            var copy = Activator.CreateInstance (GetType (), ret);
            return (SList)copy;
        }

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
        internal static extern IntPtr g_slist_delete_link (
            IntPtr list,
            IntPtr link);

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
        internal static extern IntPtr g_slist_find (
            IntPtr list,
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
        internal static extern IntPtr g_slist_find_custom (
            IntPtr list,
            IntPtr data,
            NativeCompareFunc func);

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
        internal static extern void g_slist_foreach (
            IntPtr list,
            NativeFunc func,
            IntPtr userData);

        /// <summary>
        /// Frees one #GSList element.
        /// It is usually used after g_slist_remove_link().
        /// </summary>
        /// <param name="list">
        /// a #GSList element
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_slist_free_1 (
            IntPtr list);

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
        internal static extern void g_slist_free_full (
            IntPtr list,
            NativeDestroyNotify freeFunc);

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
        internal static extern int g_slist_index (
            IntPtr list,
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
            var ret = g_slist_index (Handle, data);
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
        internal static extern IntPtr g_slist_insert (
            IntPtr list,
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
        ///     If this is negative, or is larger than the number
        ///     of elements in the list, the new element is added on
        ///     to the end of the list.
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        protected SList Insert (IntPtr data, int position)
        {
            Handle = g_slist_insert (Handle, data, position);
            return this;
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
        internal static extern IntPtr g_slist_insert_before (
            IntPtr list,
            IntPtr sibling,
            IntPtr data);

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
        internal static extern IntPtr g_slist_insert_sorted (
            IntPtr list,
            IntPtr data,
            NativeCompareFunc func);

        /// <summary>
        /// Inserts a new element into the list, using the given
        /// comparison function to determine its position.
        /// </summary>
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
        protected SList InsertSorted (IntPtr data, Comparison<IntPtr> func)
        {
            if (func == null) {
                throw new ArgumentNullException (nameof (func));
            }
            NativeCompareFunc funcNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncRet = func (compareFuncAPtr, compareFuncBPtr);
                return compareFuncRet;
            };
            Handle = g_slist_insert_sorted (Handle, data, funcNative);
            GC.KeepAlive (funcNative);
            return this;
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
        internal static extern IntPtr g_slist_insert_sorted_with_data (
            IntPtr list,
            IntPtr data,
            NativeCompareDataFunc func,
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
        internal static extern IntPtr g_slist_last (
            IntPtr list);

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
        internal static extern uint g_slist_length (
            IntPtr list);

        /// <summary>
        /// Gets the number of elements in a #GSList.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list to
        /// count its elements.
        /// </remarks>
        /// <returns>
        /// the number of elements in the #GSList
        /// </returns>
        public int Length {
            get {
                var ret = g_slist_length (Handle);
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
        internal static extern IntPtr g_slist_nth (
            IntPtr list,
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
        internal static extern IntPtr g_slist_nth_data (
            IntPtr list,
            uint n);

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if the position
        ///     is off the end of the #GSList
        /// </returns>
        protected IntPtr NthData (int n)
        {
            if (n < 0) {
                throw new ArgumentOutOfRangeException (nameof (n));
            }
            var ret = g_slist_nth_data (Handle, (uint)n);
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
        internal static extern int g_slist_position (
            IntPtr list,
            IntPtr llink);

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
        internal static extern IntPtr g_slist_prepend (
            IntPtr list,
            IntPtr data);

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
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        protected SList Prepend (IntPtr data)
        {
            Handle = g_slist_prepend (Handle, data);
            return this;
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
        internal static extern IntPtr g_slist_remove (
            IntPtr list,
            IntPtr data);

        /// <summary>
        /// Removes an element from a #GSList.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the #GSList is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        protected SList Remove (IntPtr data)
        {
            Handle = g_slist_remove (Handle, data);
            return this;
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
        internal static extern IntPtr g_slist_remove_all (
            IntPtr list,
            IntPtr data);

        /// <summary>
        /// Removes all list nodes with data equal to @data.
        /// Returns the new head of the list. Contrast with
        /// g_slist_remove() which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        /// <returns>
        /// new head of @list
        /// </returns>
        protected SList RemoveAll (IntPtr data)
        {
            Handle = g_slist_remove_all (Handle, data);
            return this;
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
        internal static extern IntPtr g_slist_remove_link (
            IntPtr list,
            IntPtr link);

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
        internal static extern IntPtr g_slist_reverse (
            IntPtr list);

        /// <summary>
        /// Reverses a #GSList.
        /// </summary>
        /// <returns>
        /// the start of the reversed #GSList
        /// </returns>
        protected SList Reverse ()
        {
            Handle = g_slist_reverse (Handle);
            return this;
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
        internal static extern IntPtr g_slist_sort (
            IntPtr list,
            NativeCompareFunc compareFunc);

        /// <summary>
        /// Sorts a #GSList using the given comparison function.
        /// </summary>
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
        protected SList Sort (Comparison<IntPtr> compareFunc)
        {
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            NativeCompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncRet = compareFunc (compareFuncAPtr, compareFuncBPtr);
                return compareFuncRet;
            };
            Handle = g_slist_sort (Handle, compareFuncNative);
            GC.KeepAlive (compareFuncNative);
            return this;
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
        internal static extern IntPtr g_slist_sort_with_data (
            IntPtr list,
            NativeCompareDataFunc compareFunc,
            IntPtr userData);
    }

    public sealed class SList<T> : SList where T : Opaque
    {
        public SList (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        /// <summary>
        /// Adds the second #GSList onto the end of the first #GSList.
        /// Note that the elements of the second #GSList are not copied.
        /// They are used directly.
        /// </summary>
        /// <param name="list2">
        /// the #GSList to add to the end of the first #GSList
        /// </param>
        /// <returns>
        /// the start of the new #GSList
        /// </returns>
        public SList<T> Concat (SList<T> list2)
        {
            var ret = base.Concat (list2);
            return (SList<T>)ret;
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
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        public SList<T> Append (T data)
        {
            var ret = Append (data?.Handle ?? IntPtr.Zero);
            return (SList<T>)ret;
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
        /// <returns>
        /// a copy of @list
        /// </returns>
        public new SList<T> Copy ()
        {
            var ret = base.Copy ();
            return (SList<T>)ret;
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
            var ret = IndexOf (data?.Handle ?? IntPtr.Zero);
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
        ///     If this is negative, or is larger than the number
        ///     of elements in the list, the new element is added on
        ///     to the end of the list.
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        public SList<T> Insert (T data, int position)
        {
            var ret = Insert (data?.Handle ?? IntPtr.Zero, position);
            return (SList<T>)ret;
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
        ///     It should return a number &gt; 0 if the first parameter
        ///     comes after the second parameter in the sort order.
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        public SList<T> InsertSorted (T data, Comparison<T> func)
        {
            if (func == null) {
                throw new ArgumentNullException (nameof (func));
            }
            Comparison<IntPtr> compareFunc = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = func (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var ret = InsertSorted (data?.Handle ?? IntPtr.Zero, compareFunc);
            return (SList<T>)ret;
        }

        /// <summary>
        /// Gets the data of the element at the given position.
        /// </summary>
        /// <param name="n">
        /// the position of the element
        /// </param>
        /// <returns>
        /// the element's data, or %NULL if the position
        ///     is off the end of the #GSList
        /// </returns>
        public T this [int n]
        {
            get {
                if (n < 0) {
                    throw new ArgumentOutOfRangeException (nameof (n));
                }
                var ret_ = NthData (n);
                var ret = GetInstance<T> (ret_, Transfer.None);
                return ret;
            }
        }

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
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        public SList<T> Prepend (T data)
        {
            var ret = Prepend (data?.Handle ?? IntPtr.Zero);
            return (SList<T>)ret;
        }

        /// <summary>
        /// Removes an element from a #GSList.
        /// If two elements contain the same data, only the first is removed.
        /// If none of the elements contain the data, the #GSList is unchanged.
        /// </summary>
        /// <param name="data">
        /// the data of the element to remove
        /// </param>
        /// <returns>
        /// the new start of the #GSList
        /// </returns>
        public SList<T> Remove (T data)
        {
            var ret = Remove (data?.Handle ?? IntPtr.Zero);
            return (SList<T>)ret;
        }

        /// <summary>
        /// Removes all list nodes with data equal to @data.
        /// Returns the new head of the list. Contrast with
        /// g_slist_remove() which removes only the first node
        /// matching the given data.
        /// </summary>
        /// <param name="data">
        /// data to remove
        /// </param>
        /// <returns>
        /// new head of @list
        /// </returns>
        public SList<T> RemoveAll (T data)
        {
            var ret = RemoveAll (data?.Handle ?? IntPtr.Zero);
            return (SList<T>)ret;
        }

        /// <summary>
        /// Reverses a #GSList.
        /// </summary>
        /// <returns>
        /// the start of the reversed #GSList
        /// </returns>
        public new SList<T> Reverse ()
        {
            var ret = base.Reverse ();
            return (SList<T>)ret;
        }

        /// <summary>
        /// Sorts a #GSList using the given comparison function.
        /// </summary>
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
        public SList<T> Sort (Comparison<T> compareFunc)
        {
            if (compareFunc == null) {
                throw new ArgumentNullException (nameof (compareFunc));
            }
            Comparison<IntPtr> func = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = compareFunc (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var ret = Sort (func);
            return (SList<T>)ret;
        }
    }
}
