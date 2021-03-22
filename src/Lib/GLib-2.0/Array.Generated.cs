// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Array.xmldoc" path="declaration/member[@name='Array']/*" />
    [GISharp.Runtime.GTypeAttribute("GArray", IsProxyForUnmanagedType = true)]
    public abstract unsafe partial class Array : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Runtime.GType _GType = g_array_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="Array.xmldoc" path="declaration/member[@name='UnmanagedStruct.Data']/*" />
            public readonly byte* Data;

            /// <include file="Array.xmldoc" path="declaration/member[@name='UnmanagedStruct.Len']/*" />
            public readonly uint Len;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Array(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_array_ref((UnmanagedStruct*)handle);
            }
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_append_vals(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr data,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint len);

        /// <summary>
        /// Checks whether @target exists in @array by performing a binary
        /// search based on the given comparison function @compare_func which
        /// get pointers to items as arguments. If the element is found, %TRUE
        /// is returned and the element’s index is returned in @out_match_index
        /// (if non-%NULL). Otherwise, %FALSE is returned and @out_match_index
        /// is undefined. If @target exists multiple times in @array, the index
        /// of the first instance is returned. This search is using a binary
        /// search, so the @array must absolutely be sorted to return a correct
        /// result (if not, the function may produce false-negative).
        /// </summary>
        /// <remarks>
        /// <para>
        /// This example defines a comparison function and search an element in a #GArray:
        /// |[&lt;!-- language="C" --&gt;
        /// static gint*
        /// cmpint (gconstpointer a, gconstpointer b)
        /// {
        ///   const gint *_a = a;
        ///   const gint *_b = b;
        /// </para>
        /// <para>
        ///   return *_a - *_b;
        /// }
        /// ...
        /// gint i = 424242;
        /// guint matched_index;
        /// gboolean result = g_array_binary_search (garray, &amp;i, cmpint, &amp;matched_index);
        /// ...
        /// ]|
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GArray.
        /// </param>
        /// <param name="target">
        /// a pointer to the item to look up.
        /// </param>
        /// <param name="compareFunc">
        /// A #GCompareFunc used to locate @target.
        /// </param>
        /// <param name="outMatchIndex">
        /// return location
        ///    for the index of the element, if found.
        /// </param>
        /// <returns>
        /// %TRUE if @target is one of the elements of @array, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.62")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_array_binary_search(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr target,
        /* <type name="CompareFunc" type="GCompareFunc" managed-name="CompareFunc" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, int> compareFunc,
        /* <type name="guint" type="guint*" managed-name="System.UInt32" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none optional:1 allow-none:1 */
        uint* outMatchIndex);

        /// <summary>
        /// Create a shallow copy of a #GArray. If the array elements consist of
        /// pointers to data, the pointers are copied but the actual data is not.
        /// </summary>
        /// <param name="array">
        /// A #GArray.
        /// </param>
        /// <returns>
        /// A copy of @array.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.62")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:container direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_copy(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array);

        /// <summary>
        /// Frees the memory allocated for the #GArray. If @free_segment is
        /// %TRUE it frees the memory block holding the elements as well. Pass
        /// %FALSE if you want to free the #GArray wrapper but preserve the
        /// underlying array for use elsewhere. If the reference count of
        /// @array is greater than one, the #GArray wrapper is preserved but
        /// the size of  @array will be set to zero.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If array contents point to dynamically-allocated memory, they should
        /// be freed separately if @free_seg is %TRUE and no @clear_func
        /// function has been set for @array.
        /// </para>
        /// <para>
        /// This function is not thread-safe. If using a #GArray from multiple
        /// threads, use only the atomic g_array_ref() and g_array_unref()
        /// functions.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="freeSegment">
        /// if %TRUE the actual element data is freed as well
        /// </param>
        /// <returns>
        /// the element data if @free_segment is %FALSE, otherwise
        ///     %NULL. The element data should be freed using g_free().
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_array_free(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean freeSegment);

        /// <summary>
        /// Gets the size of the elements in @array.
        /// </summary>
        /// <param name="array">
        /// A #GArray
        /// </param>
        /// <returns>
        /// Size of each element, in bytes
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint g_array_get_element_size(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array);

        /// <summary>
        /// Inserts @len elements into a #GArray at the given index.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If @index_ is greater than the array’s current length, the array is expanded.
        /// The elements between the old end of the array and the newly inserted elements
        /// will be initialised to zero if the array was configured to clear elements;
        /// otherwise their values will be undefined.
        /// </para>
        /// <para>
        /// If @index_ is less than the array’s current length, new entries will be
        /// inserted into the array, and the existing entries above @index_ will be moved
        /// upwards.
        /// </para>
        /// <para>
        /// @data may be %NULL if (and only if) @len is zero. If @len is zero, this
        /// function is a no-op.
        /// </para>
        /// </remarks>
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_insert_vals(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint index,
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint len);

        /// <summary>
        /// Creates a new #GArray with a reference count of 1.
        /// </summary>
        /// <param name="zeroTerminated">
        /// %TRUE if the array should have an extra element at
        ///     the end which is set to 0
        /// </param>
        /// <param name="clear">
        /// %TRUE if #GArray elements should be automatically cleared
        ///     to 0 when they are allocated
        /// </param>
        /// <param name="elementSize">
        /// the size of each element in bytes
        /// </param>
        /// <returns>
        /// the new #GArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_new(
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean zeroTerminated,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean clear,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint elementSize);

        /// <summary>
        /// Adds @len elements onto the start of the array.
        /// </summary>
        /// <remarks>
        /// <para>
        /// @data may be %NULL if (and only if) @len is zero. If @len is zero, this
        /// function is a no-op.
        /// </para>
        /// <para>
        /// This operation is slower than g_array_append_vals() since the
        /// existing elements in the array have to be moved to make space for
        /// the new elements.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="data">
        /// a pointer to the elements to prepend to the start of the array
        /// </param>
        /// <param name="len">
        /// the number of elements to prepend, which may be zero
        /// </param>
        /// <returns>
        /// the #GArray
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_prepend_vals(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint len);

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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_remove_index(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint index);

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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_remove_index_fast(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint index);

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
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_remove_range(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint index,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint length);

        /// <summary>
        /// Sets a function to clear an element of @array.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The @clear_func will be called when an element in the array
        /// data segment is removed and when the array is freed and data
        /// segment is deallocated as well. @clear_func will be passed a
        /// pointer to the element to clear, rather than the element itself.
        /// </para>
        /// <para>
        /// Note that in contrast with other uses of #GDestroyNotify
        /// functions, @clear_func is expected to clear the contents of
        /// the array element it is given, but not free the element itself.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// A #GArray
        /// </param>
        /// <param name="clearFunc">
        /// a function to clear an element of @array
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_array_set_clear_func(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
        /* transfer-ownership:none scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> clearFunc);

        /// <summary>
        /// Sets the size of the array, expanding it if necessary. If the array
        /// was created with @clear_ set to %TRUE, the new elements are set to 0.
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_set_size(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint length);

        /// <summary>
        /// Creates a new #GArray with @reserved_size elements preallocated and
        /// a reference count of 1. This avoids frequent reallocation, if you
        /// are going to add many elements to the array. Note however that the
        /// size of the array is still 0.
        /// </summary>
        /// <param name="zeroTerminated">
        /// %TRUE if the array should have an extra element at
        ///     the end with all bits cleared
        /// </param>
        /// <param name="clear">
        /// %TRUE if all bits in the array should be cleared to 0 on
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_sized_new(
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean zeroTerminated,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean clear,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint elementSize,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        uint reservedSize);

        /// <summary>
        /// Sorts a #GArray using @compare_func which should be a qsort()-style
        /// comparison function (returns less than zero for first arg is less
        /// than second arg, zero for equal, greater zero if first arg is
        /// greater than second arg).
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GArray
        /// </param>
        /// <param name="compareFunc">
        /// comparison function
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_array_sort(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="CompareFunc" type="GCompareFunc" managed-name="CompareFunc" /> */
        /* transfer-ownership:none direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, int> compareFunc);

        /// <summary>
        /// Like g_array_sort(), but the comparison function receives an extra
        /// user data argument.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is guaranteed to be a stable sort since version 2.32.
        /// </para>
        /// <para>
        /// There used to be a comment here about making the sort stable by
        /// using the addresses of the elements in the comparison function.
        /// This did not actually work, so any such code should be removed.
        /// </para>
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_array_sort_with_data(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="CompareDataFunc" type="GCompareDataFunc" managed-name="CompareDataFunc" /> */
        /* transfer-ownership:none closure:2 direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, System.IntPtr, int> compareFunc,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData);

        /// <summary>
        /// Frees the data in the array and resets the size to zero, while
        /// the underlying array is preserved for use elsewhere and returned
        /// to the caller.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the array was created with the @zero_terminate property
        /// set to %TRUE, the returned data is zero terminated too.
        /// </para>
        /// <para>
        /// If array elements contain dynamically-allocated memory,
        /// the array elements should also be freed by the caller.
        /// </para>
        /// <para>
        /// A short example of use:
        /// |[&lt;!-- language="C" --&gt;
        /// ...
        /// gpointer data;
        /// gsize data_len;
        /// data = g_array_steal (some_array, &amp;data_len);
        /// ...
        /// ]|
        /// </para>
        /// </remarks>
        /// <param name="array">
        /// a #GArray.
        /// </param>
        /// <param name="len">
        /// pointer to retrieve the number of
        ///    elements of the original array
        /// </param>
        /// <returns>
        /// the element data, which should be
        ///     freed using g_free().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.64")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern System.IntPtr g_array_steal(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none optional:1 allow-none:1 */
        nuint* len);
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Runtime.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_array_get_type();

        /// <summary>
        /// Atomically increments the reference count of @array by one.
        /// This function is thread-safe and may be called from any thread.
        /// </summary>
        /// <param name="array">
        /// A #GArray
        /// </param>
        /// <returns>
        /// The passed in #GArray
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Array.UnmanagedStruct* g_array_ref(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_array_ref((GISharp.Lib.GLib.Array.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Atomically decrements the reference count of @array by one. If the
        /// reference count drops to 0, all memory allocated by the array is
        /// released. This function is thread-safe and may be called from any
        /// thread.
        /// </summary>
        /// <param name="array">
        /// A #GArray
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_array_unref(
        /* <array name="GLib.Array" type="GArray*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Array" is-pointer="1">
*   <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Array.UnmanagedStruct* array);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_array_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }
    }
}