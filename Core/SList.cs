using System;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace GISharp.Core
{

    /// <summary>
    /// The #GSList struct is used for each element in the singly-linked
    /// list.
    /// </summary>
    public sealed class SList<T> : OwnedOpaque<GISharp.Core.SList<T>> where T : class, IWrappedNative
    {
        // Analysis disable once StaticFieldInGenericType
        static readonly ICustomMarshaler typeParameterCustomMarshaler;

        static SList ()
        {
            typeParameterCustomMarshaler = typeof(T).GetCustomMarshaler ();
        }

        public SList () : this (IntPtr.Zero)
        {
            Owned = true;
        }

        public SList (IntPtr handle)
        {
            Handle = handle;
        }

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
        public static SList<T> Concat (SList<T> list1, SList<T> list2)
        {
            if (list1 != null) {
                list1.AssertIsHeadOfList ();
            }
            if (list2 != null) {
                list2.AssertIsHeadOfList ();
            }
            var list1Ptr = list1 == null ? IntPtr.Zero : list1.Handle;
            var list2Ptr = list2 == null ? IntPtr.Zero : list2.Handle;
            var retPtr = SListInternal.g_slist_concat (list1Ptr, list2Ptr);
            if (list1 != null) {
                list1.Owned = false;
            }
            if (list2 != null) {
                list2.Owned = false;
            }
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_append (Handle, dataPtr);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        public override SList<T> Copy ()
        {
            AssertIsHeadOfList ();
            var retPtr = SListInternal.g_slist_copy (Handle);
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        /// <param name="func">
        /// a copy function used to copy every element in the list
        /// </param>
        /// <returns>
        /// a full copy of @list, use #g_slist_free_full to free it
        /// </returns>
        [Since("2.34")]
        public SList<T> CopyDeep (CopyFuncCallback<T> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            CopyFunc funcNative = (funcSrcPtr, funcDataPtr) => {
                var funcSrc = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (funcSrcPtr);
                var funcRet = func.Invoke (funcSrc);
                if (funcRet == null) {
                    return IntPtr.Zero;
                }
                return funcRet.Handle;
            };
            var retPtr = SListInternal.g_slist_copy_deep (Handle, funcNative, IntPtr.Zero);
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        public SList<T> DeleteLink (SList<T> link)
        {
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var retPtr = SListInternal.g_slist_remove_link (Handle, linkPtr);
            Owned = false;
            link.Owned = false;
            link.Disposed = true;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
        }

        /// <summary>
        /// Finds the element in a #GSList which
        /// contains the given data.
        /// </summary>
        /// <param name="data">
        /// the element data to find
        /// </param>
        /// <returns>
        /// the found #GSList element,
        ///     or %NULL if it is not found
        /// </returns>
        public SList<T> Find (T data)
        {
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_find (Handle, dataPtr);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new SList<T> (retPtr);
            return ret;
        }

        /// <summary>
        /// Finds an element in a #GSList, using a supplied function to
        /// find the desired element. It iterates over the list, calling
        /// the given function which should return 0 when the desired
        /// element is found. The function takes two #gconstpointer arguments,
        /// the #GSList element's data as the first argument and the
        /// given user data.
        /// </summary>
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
        public SList<T> FindCustom (T data, CompareFuncCallback<T> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            CompareFunc funcNative = (funcAPtr, funcBPtr) => {
                var funcA = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (funcAPtr);
                var funcB = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (funcBPtr);
                var funcRet = func.Invoke (funcA, funcB);
                return funcRet;
            };
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_find_custom (Handle, dataPtr, funcNative);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new SList<T> (retPtr);
            return ret;
        }

        /// <summary>
        /// Calls a function for each element of a #GSList.
        /// </summary>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        public void Foreach (FuncCallback<T> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            Func funcNative = (funcDataPtr, funcUserDataPtr) => {
                var funcData = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (funcDataPtr);
                func.Invoke (funcData);
            };
            SListInternal.g_slist_foreach (Handle, funcNative, IntPtr.Zero);
        }

        /// <summary>
        /// Frees all of the memory used by a #GSList.
        /// The freed elements are returned to the slice allocator.
        /// </summary>
        /// <remarks>
        /// If list elements contain dynamically-allocated memory,
        /// you should either use g_slist_free_full() or free them manually
        /// first.
        /// </remarks>
        protected override void Free ()
        {
            SListInternal.g_slist_free (Handle);
            Owned = false;
        }

        /// <summary>
        /// Frees one #GSList element.
        /// It is usually used after g_slist_remove_link().
        /// </summary>
        public void Free1 ()
        {
            AssertNotDisposed ();
            SListInternal.g_slist_free_1 (Handle);
            Owned = false;
            Disposed = true;
        }

        /// <summary>
        /// Convenience method, which frees all the memory used by a #GSList, and
        /// calls the specified destroy function on every element's data.
        /// </summary>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [Since("2.28")]
        public void FreeFull (DestroyNotifyCallback<T> freeFunc)
        {
            if (freeFunc == null) {
                throw new ArgumentNullException ("freeFunc");
            }
            AssertNotDisposed ();
            DestroyNotify freeFuncNative = (freeFuncDataPtr) => {
                var freeFuncData = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (freeFuncDataPtr);
                freeFunc.Invoke (freeFuncData);
            };
            SListInternal.g_slist_free_full (Handle, freeFuncNative);
            Owned = false;
            Disposed = true;
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
        public Int32 IndexOf (T data)
        {
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var ret = SListInternal.g_slist_index (Handle, dataPtr);
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
        public SList<T> Insert (T data, Int32 position)
        {
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_insert (Handle, dataPtr, position);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
        }

        /// <summary>
        /// Inserts a node before @sibling containing @data.
        /// </summary>
        /// <param name="sibling">
        /// node to insert @data before
        /// </param>
        /// <param name="data">
        /// data to put in the newly-inserted node
        /// </param>
        /// <returns>
        /// the new head of the list.
        /// </returns>
        public SList<T> InsertBefore (SList<T> sibling, T data)
        {
            AssertIsHeadOfList ();
            if (sibling != null) {
                sibling.AssertNotDisposed ();
            }
            var siblingPtr = sibling == null ? IntPtr.Zero : sibling.Handle;
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_insert_before (Handle, siblingPtr, dataPtr);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        public SList<T> InsertSorted (T data, CompareFuncCallback<T> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            CompareFunc funcNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (compareFuncAPtr);
                var compareFuncB = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (compareFuncBPtr);
                var compareFuncRet = func.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var retPtr = SListInternal.g_slist_insert_sorted (Handle, dataPtr, funcNative);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
        }

        /// <summary>
        /// Gets the last element in a #GSList.
        /// </summary>
        /// <remarks>
        /// This function iterates over the whole list.
        /// </remarks>
        /// <returns>
        /// the last element in the #GSList,
        ///     or %NULL if the #GSList has no elements
        /// </returns>
        public SList<T> Last {
            get {
                AssertNotDisposed ();
                var retPtr = SListInternal.g_slist_last (Handle);
                if (retPtr == IntPtr.Zero) {
                    return null;
                }
                var ret = new SList<T> (retPtr);
                return ret;
            }
        }

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
        public System.Int32 Length {
            get {
                AssertNotDisposed ();
                return (int)SListInternal.g_slist_length (Handle);
            }
        }

        /// <summary>
        /// Gets the element at the given position in a #GSList.
        /// </summary>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or %NULL if the position is off
        ///     the end of the #GSList
        /// </returns>
        public SList<T> Nth (UInt32 n)
        {
            AssertIsHeadOfList ();
            var retPtr = SListInternal.g_slist_nth (Handle, n);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new SList<T> (retPtr);
            return ret;
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
        public T this[UInt32 n]
        {
            get {
                AssertIsHeadOfList ();
                var retPtr = SListInternal.g_slist_nth_data (Handle, n);
                var ret = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (retPtr);
                return ret;
            }
        }

        /// <summary>
        /// Gets the position of the given element
        /// in the #GSList (starting from 0).
        /// </summary>
        /// <param name="link">
        /// an element in the #GSList
        /// </param>
        /// <returns>
        /// the position of the element in the #GSList,
        ///     or -1 if the element is not found
        /// </returns>
        public Int32 Position (SList<T> link)
        {
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var ret = SListInternal.g_slist_position (Handle, linkPtr);
            return ret;
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
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_prepend (Handle, dataPtr);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_remove (Handle, dataPtr);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = SListInternal.g_slist_remove_all (Handle, dataPtr);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        /// <param name="link">
        /// an element in the #GSList
        /// </param>
        /// <returns>
        /// the new start of the #GSList, without the element
        /// </returns>
        public SList<T> RemoveLink (SList<T> link)
        {
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var retPtr = SListInternal.g_slist_remove_link (Handle, linkPtr);
            Owned = false;
            link.Owned = true;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
        }

        /// <summary>
        /// Reverses a #GSList.
        /// </summary>
        /// <returns>
        /// the start of the reversed #GSList
        /// </returns>
        public SList<T> Reverse ()
        {
            AssertIsHeadOfList ();
            var retPtr = SListInternal.g_slist_reverse (Handle);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
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
        public SList<T> Sort(CompareFuncCallback<T> compareFunc)
        {
            if (compareFunc == null) {
                throw new ArgumentNullException ("compareFunc");
            }
            AssertIsHeadOfList ();
            CompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (compareFuncAPtr);
                var compareFuncB = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (compareFuncBPtr);
                var compareFuncRet = compareFunc.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var retPtr = SListInternal.g_slist_sort (Handle, compareFuncNative);
            Owned = false;
            var ret = new SList<T> (retPtr);
            ret.Owned = true;
            return ret;
        }

        public T Data {
            get {
                AssertNotDisposed ();
                if (Handle == IntPtr.Zero) {
                    return null;
                }
                var retPtr = Marshal.ReadIntPtr (Handle, IntPtr.Size * 0);
                var ret = (T)typeParameterCustomMarshaler.MarshalNativeToManaged (retPtr);
                return ret;
            }
        }

        public List<T> Next {
            get {
                AssertNotDisposed ();
                if (Handle == IntPtr.Zero) {
                    return null;
                }
                var retPtr = Marshal.ReadIntPtr (Handle, IntPtr.Size * 1);
                if (retPtr == IntPtr.Zero) {
                    return null;
                }
                var ret = new List<T> (retPtr);
                return ret;
            }
        }

        void AssertIsHeadOfList ()
        {
            AssertNotDisposed ();
            if (!Owned) {
                throw new InvalidOperationException ("This operation requires an owned list.");
            }
        }
    }

    // Needed because compiler won't allow pinvoke methods in generic class
    static class SListInternal
    {
        /// <summary>
        /// Allocates space for one #GSList element. It is called by the
        /// g_slist_append(), g_slist_prepend(), g_slist_insert() and
        /// g_slist_insert_sorted() functions and so is rarely used on its own.
        /// </summary>
        /// <returns>
        /// a pointer to the newly-allocated #GSList element.
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_alloc();

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_concat(
            [In] IntPtr list1,
            [In] IntPtr list2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_append(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_copy(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.34")]
        internal static extern IntPtr g_slist_copy_deep(
            [In] IntPtr list,
            [In] CopyFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_delete_link(
            [In] IntPtr list,
            [In] IntPtr link);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_find(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_find_custom(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] CompareFunc func);

        /// <summary>
        /// Calls a function for each element of a #GSList.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        /// <param name="user_data">
        /// user data to pass to the function
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_slist_foreach(
            [In] IntPtr list,
            [In] Func func,
            [In] IntPtr userData);

        /// <summary>
        /// Frees all of the memory used by a #GSList.
        /// The freed elements are returned to the slice allocator.
        /// </summary>
        /// <remarks>
        /// If list elements contain dynamically-allocated memory,
        /// you should either use g_slist_free_full() or free them manually
        /// first.
        /// </remarks>
        /// <param name="list">
        /// a #GSList
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_slist_free(
            [In] IntPtr list);

        /// <summary>
        /// Frees one #GSList element.
        /// It is usually used after g_slist_remove_link().
        /// </summary>
        /// <param name="list">
        /// a #GSList element
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_slist_free_1(
            [In] IntPtr list);

        /// <summary>
        /// Convenience method, which frees all the memory used by a #GSList, and
        /// calls the specified destroy function on every element's data.
        /// </summary>
        /// <param name="list">
        /// a pointer to a #GSList
        /// </param>
        /// <param name="free_func">
        /// the function to be called to free each element's data
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.28")]
        internal static extern void g_slist_free_full(
            [In] IntPtr list,
            [In] DestroyNotify freeFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 g_slist_index(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_insert(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] Int32 position);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_insert_before(
            [In] IntPtr list,
            [In] IntPtr sibling,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_insert_sorted(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] CompareFunc func);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.10")]
        internal static extern IntPtr g_slist_insert_sorted_with_data(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] CompareDataFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_last(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern System.UInt32 g_slist_length(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_nth(
            [In] IntPtr list,
            [In] System.UInt32 n);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_nth_data(
            [In] IntPtr list,
            [In] System.UInt32 n);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 g_slist_position(
            [In] IntPtr list,
            [In] IntPtr llink);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_prepend(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_remove(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_remove_all(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_remove_link(
            [In] IntPtr list,
            [In] IntPtr link);

        /// <summary>
        /// Reverses a #GSList.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <returns>
        /// the start of the reversed #GSList
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_reverse(
            [In] IntPtr list);

        /// <summary>
        /// Sorts a #GSList using the given comparison function.
        /// </summary>
        /// <param name="list">
        /// a #GSList
        /// </param>
        /// <param name=compareFunc>
        /// the comparison function used to sort the #GSList.
        ///     This function is passed the data from 2 elements of the #GSList
        ///     and should return 0 if they are equal, a negative value if the
        ///     first element comes before the second, or a positive value if
        ///     the first element comes after the second.
        /// </param>
        /// <returns>
        /// the start of the sorted #GSList
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_sort(
            [In] IntPtr list,
            [In] CompareFunc compareFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_slist_sort_with_data(
            [In] IntPtr list,
            [In] CompareDataFunc compareFunc,
            [In] IntPtr userData);
    }
}
