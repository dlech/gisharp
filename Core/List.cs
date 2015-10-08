using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;

namespace GISharp.Core
{

    /// <summary>
    /// The <see cref="List{T}"/> struct is used for each element in a doubly-linked list.
    /// </summary>
    [NullHandleIsInstance]
    public sealed class List<T> : OwnedOpaque where T : Opaque
    {
        List (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new empty list.
        /// </summary>
        public List () : this (IntPtr.Zero, Transfer.All)
        {
        }

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
        public static List<T> Concat (List<T> list1, List<T> list2)
        {
            if (list1 != null) {
                list1.AssertNotDisposed ();
                list1.AssertIsHeadOfList ();
            }
            if (list2 != null) {
                list2.AssertNotDisposed ();
                list2.AssertIsHeadOfList ();
            }
            var list1Ptr = list1 == null ? IntPtr.Zero : list1.Handle;
            var list2Ptr = list2 == null ? IntPtr.Zero : list2.Handle;
            var retPtr = ListInternal.g_list_concat (list1Ptr, list2Ptr);
            if (list1 != null) {
                list1.Owned = false;
            }
            if (list2 != null) {
                list2.Owned = false;
            }
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
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
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_append (Handle, dataPtr);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
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
        public List<T> Copy ()
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var retPtr = ListInternal.g_list_copy (Handle);
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Makes a full (deep) copy of a <see cref="List{T}"/>.
        /// </summary>
        /// <remarks>
        /// In contrast with <see cref="Copy"/>, this function uses <paramref name="func"/> to make
        /// a copy of each list element, in addition to copying the list
        /// container itself.
        /// 
        /// @func, as a #GCopyFunc, takes two arguments, the data to be copied
        /// and a @user_data pointer. It's safe to pass <c>null</c> as user_data,
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
        /// <param name="func">
        /// a copy function used to copy every element in the list
        /// </param>
        /// <returns>
        /// the start of the new list that holds a full copy of @list,
        ///     use g_list_free_full() to free it
        /// </returns>
        [GISharp.Core.Since("2.34")]
        public List<T> CopyDeep(CopyFunc<T> func)
        {
            AssertNotDisposed ();
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            NativeCopyFunc funcNative = (funcSrcPtr, funcDataPtr) => {
                var funcSrc = Opaque.GetInstance<T> (funcSrcPtr, Transfer.None);
                var funcRet = func.Invoke (funcSrc);
                if (funcRet == null) {
                    return IntPtr.Zero;
                }
                return funcRet.Handle;
            };
            var retPtr = ListInternal.g_list_copy_deep (Handle, funcNative, IntPtr.Zero);
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Removes the node <paramref name="link"/> from the list and frees it.
        /// Compare this to <see cref="RemoveLink"/> which removes the node
        /// without freeing it.
        /// </summary>
        /// <param name="link">
        /// node to delete from this list
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> DeleteLink (List<T> link)
        {
            AssertNotDisposed ();
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var retPtr = ListInternal.g_list_remove_link (Handle, linkPtr);
            Owned = false;
            link.Owned = false;
            link.IsDisposed = true;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Finds the element in a <see cref="List{T}"/> which contains the given data.
        /// </summary>
        /// <param name="data">
        /// the element data to find
        /// </param>
        /// <returns>
        /// the found <see cref="List{T}"/> element, or <c>null</c> if it is not found
        /// </returns>
        public List<T> Find(T data)
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_find (Handle, dataPtr);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new List<T> (retPtr, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Finds an element in a <see cref="List{T}"/>, using a supplied function to
        /// find the desired element. It iterates over the list, calling
        /// the given function which should return 0 when the desired
        /// element is found. The function takes two #gconstpointer arguments,
        /// the <see cref="List{T}"/> element's data as the first argument and the
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
        /// the found <see cref="List{T}"/> element, or <c>null</c> if it is not found
        /// </returns>
        public List<T> FindCustom (T data, CompareFunc<T> func)
        {
            AssertNotDisposed ();
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            NativeCompareFunc funcNative = (funcAPtr, funcBPtr) => {
                var funcA = Opaque.GetInstance<T> (funcAPtr, Transfer.None);
                var funcB = Opaque.GetInstance<T> (funcBPtr, Transfer.None);
                var funcRet = func.Invoke (funcA, funcB);
                return funcRet;
            };
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_find_custom (Handle, dataPtr, funcNative);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new List<T> (retPtr, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the first element in a <see cref="List{T}"/>.
        /// </summary>
        /// <returns>
        /// the first element in the <see cref="List{T}"/>,
        ///     or <c>null</c> if the <see cref="List{T}"/> has no elements
        /// </returns>
        public List<T> First {
            get {
                AssertNotDisposed ();
                var retPtr = ListInternal.g_list_first (Handle);
                if (retPtr == IntPtr.Zero) {
                    return null;
                }
                var ret = new List<T> (retPtr, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Calls a function for each element of a <see cref="List{T}"/>.
        /// </summary>
        /// <param name="func">
        /// the function to call with each element's data
        /// </param>
        public void Foreach (Func<T> func)
        {
            AssertNotDisposed ();
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            NativeFunc funcNative = (funcDataPtr, funcUserDataPtr) => {
                var funcData = Opaque.GetInstance<T>(funcDataPtr, Transfer.None);
                func.Invoke (funcData);
            };
            ListInternal.g_list_foreach (Handle, funcNative, IntPtr.Zero);
        }

        /// <summary>
        /// Frees all of the memory used by a <see cref="List{T}"/>.
        /// The freed elements are returned to the slice allocator.
        /// </summary>
        /// <remarks>
        /// If list elements contain dynamically-allocated memory, you should
        /// either use <see cref="FreeFull"/>  or free them manually first.
        /// </remarks>
        protected override void Free ()
        {
            ListInternal.g_list_free (Handle);
            Owned = false;
        }

        /// <summary>
        /// Frees one <see cref="List{T}"/> element.
        /// It is usually used after <see cref="RemoveLink"/>.
        /// </summary>
        public void Free1 ()
        {
            AssertNotDisposed ();
            ListInternal.g_list_free_1 (Handle);
            Owned = false;
            IsDisposed = true;
        }

        /// <summary>
        /// Convenience method, which frees all the memory used by a <see cref="List{T}"/>,
        /// and calls @free_func on every element's data.
        /// </summary>
        /// <param name="freeFunc">
        /// the function to be called to free each element's data
        /// </param>
        [GISharp.Core.Since("2.28")]
        public void FreeFull (DestroyNotify<T> freeFunc)
        {
            if (freeFunc == null) {
                throw new ArgumentNullException ("freeFunc");
            }
            AssertNotDisposed ();
            NativeDestroyNotify freeFuncNative = (freeFuncDataPtr) => {
                var freeFuncData = Opaque.GetInstance<T> (freeFuncDataPtr, Transfer.None);
                freeFunc.Invoke (freeFuncData);
            };
            ListInternal.g_list_free_full (Handle, freeFuncNative);
            Owned = false;
            IsDisposed = true;
        }

        /// <summary>
        /// Gets the position of the element containing
        /// the given data (starting from 0).
        /// </summary>
        /// <param name="list">
        /// a <see cref="List{T}"/>, this must point to the top of the list
        /// </param>
        /// <param name="data">
        /// the data to find
        /// </param>
        /// <returns>
        /// the index of the element containing the data,
        ///     or -1 if the data is not found
        /// </returns>
        public Int32 IndexOf (T data)
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var ret = ListInternal.g_list_index (Handle, dataPtr);
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
        public List<T> Insert (T data, Int32 position)
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_insert (Handle, dataPtr, position);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list before the given position.
        /// </summary>
        /// <param name="sibling">
        /// the list element before which the new element
        ///     is inserted or <c>null</c> to insert at the end of the list
        /// </param>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> InsertBefore (List<T> sibling, T data)
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            if (sibling != null) {
                sibling.AssertNotDisposed ();
            }
            var siblingPtr = sibling == null ? IntPtr.Zero : sibling.Handle;
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_insert_before (Handle, siblingPtr, dataPtr);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Inserts a new element into the list, using the given comparison
        /// function to determine its position.
        /// </summary>
        /// <remarks>
        /// If you are adding many new elements to a list, and the number of
        /// new elements is much larger than the length of the list, use
        /// <see cref="Prepend"/> to add the new items and sort the list afterwards
        /// with g_list_sort().
        /// </remarks>
        /// <param name="data">
        /// the data for the new element
        /// </param>
        /// <param name="func">
        /// the function to compare elements in the list. It should
        ///     return a number &gt; 0 if the first parameter comes after the
        ///     second parameter in the sort order.
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> InsertSorted (T data, CompareFunc<T> func)
        {
            AssertNotDisposed ();
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            NativeCompareFunc funcNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = Opaque.GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = Opaque.GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = func.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var retPtr = ListInternal.g_list_insert_sorted (Handle, dataPtr, funcNative);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Gets the last element in a <see cref="List{T}"/>.
        /// </summary>
        /// <param name="list">
        /// any <see cref="List{T}"/> element
        /// </param>
        /// <returns>
        /// the last element in the <see cref="List{T}"/>,
        ///     or <c>null</c> if the <see cref="List{T}"/> has no elements
        /// </returns>
        public List<T> Last {
            get {
                AssertNotDisposed ();
                var retPtr = ListInternal.g_list_last (Handle);
                if (retPtr == IntPtr.Zero) {
                    return null;
                }
                var ret = new List<T> (retPtr, Transfer.None);
                return ret;
            }
        }

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
        public Int32 Length {
            get {
                AssertNotDisposed ();
                return (int)ListInternal.g_list_length (Handle);
            }
        }

        /// <summary>
        /// Gets the element at the given position in a <see cref="List{T}"/>.
        /// </summary>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or <c>null</c> if the position is off
        ///     the end of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Nth (UInt32 n) {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var retPtr = ListInternal.g_list_nth (Handle, n);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new List<T> (retPtr, Transfer.None);
            return ret;
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
        public T this[UInt32 n] {
            get {
                AssertNotDisposed ();
                AssertIsHeadOfList ();
                var retPtr = ListInternal.g_list_nth_data (Handle, n);
                var ret = Opaque.GetInstance<T> (retPtr, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Gets the element @n places before @list.
        /// </summary>
        /// <param name="n">
        /// the position of the element, counting from 0
        /// </param>
        /// <returns>
        /// the element, or <c>null</c> if the position is
        ///     off the end of the <see cref="List{T}"/>
        /// </returns>
        public List<T> NthPrev(UInt32 n)
        {
            AssertNotDisposed ();
            var retPtr = ListInternal.g_list_nth_prev (Handle, n);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = new List<T> (retPtr, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the position of the given element
        /// in the <see cref="List{T}"/> (starting from 0).
        /// </summary>
        /// <param name="link">
        /// an element in the <see cref="List{T}"/>
        /// </param>
        /// <returns>
        /// the position of the element in the <see cref="List{T}"/>,
        ///     or -1 if the element is not found
        /// </returns>
        public Int32 Position(List<T> link)
        {
            AssertNotDisposed ();
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var ret = ListInternal.g_list_position (Handle, linkPtr);
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
        /// <returns>
        /// the newly prepended element, which is the new
        ///     start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> Prepend (T data)
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_prepend (Handle, dataPtr);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.None);
            ret.Owned = true;
            return ret;
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
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_remove (Handle, dataPtr);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
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
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var dataPtr = data == null ? IntPtr.Zero : data.Handle;
            var retPtr = ListInternal.g_list_remove_all (Handle, dataPtr);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Removes an element from a <see cref="List{T}"/>, without freeing the element.
        /// The removed element's prev and next links are set to <c>null</c>, so
        /// that it becomes a self-contained list with one element.
        /// </summary>
        /// <param name="link">
        /// an element in the <see cref="List{T}"/>
        /// </param>
        /// <returns>
        /// the (possibly changed) start of the <see cref="List{T}"/>
        /// </returns>
        public List<T> RemoveLink (List<T> link)
        {
            AssertNotDisposed ();
            if (link == null) {
                throw new ArgumentNullException ("link");
            }
            AssertIsHeadOfList ();
            link.AssertNotDisposed ();
            var linkPtr = link == null ? IntPtr.Zero : link.Handle;
            var retPtr = ListInternal.g_list_remove_link (Handle, linkPtr);
            Owned = false;
            link.Owned = true;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Reverses a <see cref="List{T}"/>.
        /// It simply switches the next and prev pointers of each element.
        /// </summary>
        /// <returns>
        /// the start of the reversed <see cref="List{T}"/>
        /// </returns>
        public List<T> Reverse ()
        {
            AssertNotDisposed ();
            AssertIsHeadOfList ();
            var retPtr = ListInternal.g_list_reverse (Handle);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
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
        public List<T> Sort (CompareFunc<T> compareFunc)
        {
            AssertNotDisposed ();
            if (compareFunc == null) {
                throw new ArgumentNullException ("compareFunc");
            }
            AssertIsHeadOfList ();
            NativeCompareFunc compareFuncNative = (compareFuncAPtr, compareFuncBPtr) => {
                var compareFuncA = Opaque.GetInstance<T> (compareFuncAPtr, Transfer.None);
                var compareFuncB = Opaque.GetInstance<T> (compareFuncBPtr, Transfer.None);
                var compareFuncRet = compareFunc.Invoke (compareFuncA, compareFuncB);
                return compareFuncRet;
            };
            var retPtr = ListInternal.g_list_sort (Handle, compareFuncNative);
            Owned = false;
            var ret = new List<T> (retPtr, Transfer.All);
            return ret;
        }

        public T Data {
            get {
                AssertNotDisposed ();
                if (Handle == IntPtr.Zero) {
                    return null;
                }
                var retPtr = Marshal.ReadIntPtr (Handle, IntPtr.Size * 0);
                var ret = Opaque.GetInstance<T> (retPtr, Transfer.None);
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
                var ret = new List<T> (retPtr, Transfer.None);
                return ret;
            }
        }

        public List<T> Previous {
            get {
                AssertNotDisposed ();
                if (Handle == IntPtr.Zero) {
                    return null;
                }
                var retPtr = Marshal.ReadIntPtr (Handle, IntPtr.Size * 2);
                if (retPtr == IntPtr.Zero) {
                    return null;
                }
                var ret = new List<T> (retPtr, Transfer.None);
                return ret;
            }
        }

        void AssertIsHeadOfList ()
        {
            if (!Owned) {
                throw new InvalidOperationException ("This operation requires an owned list.");
            }
        }
    }

    /// <summary>
    /// Contains all PInvoke methods since the compiler won't let them be in a
    /// generic class.
    /// </summary>
    static class ListInternal
    {
        /// <summary>
        /// Allocates space for one #GList element. It is called by
        /// g_list_append(), g_list_prepend(), g_list_insert() and
        /// g_list_insert_sorted() and so is rarely used on its own.
        /// </summary>
        /// <returns>
        /// a pointer to the newly-allocated #GList element
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_alloc();

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_concat(
            [In] IntPtr list1,
            [In] IntPtr list2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_append(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_copy(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [GISharp.Core.Since("2.34")]
        internal static extern IntPtr g_list_copy_deep(
            [In] IntPtr list,
            [In] NativeCopyFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_delete_link(
            [In] IntPtr list,
            [In] IntPtr link);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_find(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_find_custom(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] NativeCompareFunc func);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_first(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_list_foreach(
            [In] IntPtr list,
            [In] NativeFunc func,
            [In] IntPtr userData);

        /// <summary>
        /// Frees all of the memory used by a #GList.
        /// The freed elements are returned to the slice allocator.
        /// </summary>
        /// <remarks>
        /// If list elements contain dynamically-allocated memory, you should
        /// either use g_list_free_full() or free them manually first.
        /// </remarks>
        /// <param name="list">
        /// a #GList
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_list_free(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [GISharp.Core.Since("2.28")]
        internal static extern void g_list_free_full(
            [In] IntPtr list,
            [In] NativeDestroyNotify freeFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 g_list_index(
            [In] IntPtr list,
            [In] IntPtr data);

        /// <summary>
        /// Frees one #GList element.
        /// It is usually used after g_list_remove_link().
        /// </summary>
        /// <param name="list">
        /// a #GList element
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_list_free_1(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_insert(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] Int32 position);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_insert_before(
            [In] IntPtr list,
            [In] IntPtr sibling,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_insert_sorted(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] NativeCompareFunc func);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [GISharp.Core.Since("2.10")]
        internal static extern IntPtr g_list_insert_sorted_with_data(
            [In] IntPtr list,
            [In] IntPtr data,
            [In] NativeCompareDataFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_last(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_list_length(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_nth(
            [In] IntPtr list,
            [In] UInt32 n);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_nth_data(
            [In] IntPtr list,
            [In] UInt32 n);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_nth_prev(
            [In] IntPtr list,
            [In] UInt32 n);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 g_list_position(
            [In] IntPtr list,
            [In] IntPtr llink);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_prepend(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_remove(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_remove_all(
            [In] IntPtr list,
            [In] IntPtr data);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_remove_link(
            [In] IntPtr list,
            [In] IntPtr llink);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_reverse(
            [In] IntPtr list);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_sort(
            [In] IntPtr list,
            [In] NativeCompareFunc compareFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_list_sort_with_data(
            [In] IntPtr list,
            [In] NativeCompareDataFunc compareFunc,
            [In] IntPtr userData);
    }
}
