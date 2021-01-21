// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.Lib.GObject;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The <see cref="HashTable{K,V}"/> struct is an opaque data structure to represent a
    /// [Hash Table][glib-Hash-Tables]. It should only be accessed via the
    /// following functions.
    /// </summary>
    /// <seealso cref="HashTable{K,V}"/>
    [GType("GHashTable", IsProxyForUnmanagedType = true)]
    public abstract class HashTable : Boxed
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HashTable(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_hash_table_ref(IntPtr hashTable);

        /// <inheritdoc/>
        public override IntPtr Take() => g_hash_table_ref(UnsafeHandle);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_hash_table_destroy(IntPtr hashTable);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_hash_table_unref(IntPtr hashTable);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_hash_table_get_type();

        static readonly GType _GType = g_hash_table_get_type();

        /// <summary>
        /// Creates a new #GHashTable with a reference count of 1.
        /// </summary>
        /// <remarks>
        /// Hash values returned by @hash_func are used to determine where keys
        /// are stored within the #GHashTable data structure. The g_direct_hash(),
        /// g_int_hash(), g_int64_hash(), g_double_hash() and g_str_hash()
        /// functions are provided for some common types of keys.
        /// If @hash_func is %NULL, g_direct_hash() is used.
        ///
        /// @key_equal_func is used when looking up keys in the #GHashTable.
        /// The g_direct_equal(), g_int_equal(), g_int64_equal(), g_double_equal()
        /// and g_str_equal() functions are provided for the most common types
        /// of keys. If @key_equal_func is %NULL, keys are compared directly in
        /// a similar fashion to g_direct_equal(), but without the overhead of
        /// a function call.
        /// </remarks>
        /// <param name="hashFunc">
        /// a function to create a hash value from a key
        /// </param>
        /// <param name="keyEqualFunc">
        /// a function to check two keys for equality
        /// </param>
        /// <returns>
        /// a new #GHashTable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern IntPtr g_hash_table_new(
            UnmanagedHashFunc hashFunc,
            UnmanagedEqualFunc keyEqualFunc);

        /// <summary>
        /// Creates a new #GHashTable like g_hash_table_new() with a reference
        /// count of 1 and allows to specify functions to free the memory
        /// allocated for the key and value that get called when removing the
        /// entry from the #GHashTable.
        /// </summary>
        /// <param name="hashFunc">
        /// a function to create a hash value from a key
        /// </param>
        /// <param name="keyEqualFunc">
        /// a function to check two keys for equality
        /// </param>
        /// <param name="keyDestroyFunc">
        /// a function to free the memory allocated for the key
        ///     used when removing the entry from the #GHashTable, or %NULL
        ///     if you don't want to supply such a function.
        /// </param>
        /// <param name="valueDestroyFunc">
        /// a function to free the memory allocated for the
        ///     value used when removing the entry from the #GHashTable, or %NULL
        ///     if you don't want to supply such a function.
        /// </param>
        /// <returns>
        /// a new #GHashTable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern IntPtr g_hash_table_new_full(
            UnmanagedHashFunc hashFunc,
            UnmanagedEqualFunc keyEqualFunc,
            UnmanagedDestroyNotify keyDestroyFunc,
            UnmanagedDestroyNotify valueDestroyFunc);

        /// <summary>
        /// This is a convenience function for using a #GHashTable as a set.  It
        /// is equivalent to calling g_hash_table_replace() with @key as both the
        /// key and the value.
        /// </summary>
        /// <remarks>
        /// When a hash table only ever contains keys that have themselves as the
        /// corresponding value it is able to be stored more efficiently.  See
        /// the discussion in the section description.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <returns>
        /// %TRUE if the key did not exist yet
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        private protected static extern Runtime.Boolean g_hash_table_add(
            IntPtr hashTable,
            IntPtr key);

        /// <summary>
        /// Checks if @key is in @hashTable.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// a key to check
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        private protected static extern Runtime.Boolean g_hash_table_contains(
            IntPtr hashTable,
            IntPtr key);

        /// <summary>
        /// Calls the given function for key/value pairs in the #GHashTable
        /// until @predicate returns %TRUE. The function is passed the key
        /// and value of each pair, and the given @user_data parameter. The
        /// hash table may not be modified while iterating over it (you can't
        /// add/remove items).
        /// </summary>
        /// <remarks>
        /// Note, that hash tables are really only optimized for forward
        /// lookups, i.e. g_hash_table_lookup(). So code that frequently issues
        /// g_hash_table_find() or g_hash_table_foreach() (e.g. in the order of
        /// once per every entry in a hash table) should probably be reworked
        /// to use additional or different data structures for reverse lookups
        /// (keep in mind that an O(n) find/foreach operation issued for all n
        /// values in a hash table ends up needing O(n*n) operations).
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="predicate">
        /// function to test the key/value pairs for a certain property
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        /// <returns>
        /// The value of the first key/value pair is returned,
        ///     for which @predicate evaluates to %TRUE. If no pair with the
        ///     requested property is found, %NULL is returned.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        private protected static extern IntPtr g_hash_table_find(
            IntPtr hashTable,
            UnmanagedHRFunc predicate,
            IntPtr userData);

        /// <summary>
        /// Calls the given function for each of the key/value pairs in the
        /// #GHashTable.  The function is passed the key and value of each
        /// pair, and the given @user_data parameter.  The hash table may not
        /// be modified while iterating over it (you can't add/remove
        /// items). To remove all items matching a predicate, use
        /// g_hash_table_foreach_remove().
        /// </summary>
        /// <remarks>
        /// See g_hash_table_find() for performance caveats for linear
        /// order searches in contrast to g_hash_table_lookup().
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern void g_hash_table_foreach(
            IntPtr hashTable,
            UnmanagedHFunc func,
            IntPtr userData);

        /// <summary>
        /// Calls the given function for each key/value pair in the
        /// #GHashTable. If the function returns %TRUE, then the key/value
        /// pair is removed from the #GHashTable. If you supplied key or
        /// value destroy functions when creating the #GHashTable, they are
        /// used to free the memory allocated for the removed keys and values.
        /// </summary>
        /// <remarks>
        /// See #GHashTableIter for an alternative way to loop over the
        /// key/value pairs in the hash table.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        /// <returns>
        /// the number of key/value pairs removed
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_hash_table_foreach_remove(
            IntPtr hashTable,
            UnmanagedHRFunc func,
            IntPtr userData);

        /// <summary>
        /// Calls the given function for each key/value pair in the
        /// #GHashTable. If the function returns %TRUE, then the key/value
        /// pair is removed from the #GHashTable, but no key or value
        /// destroy functions are called.
        /// </summary>
        /// <remarks>
        /// See #GHashTableIter for an alternative way to loop over the
        /// key/value pairs in the hash table.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        /// <param name="userData">
        /// user data to pass to the function
        /// </param>
        /// <returns>
        /// the number of key/value pairs removed.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_hash_table_foreach_steal(
            IntPtr hashTable,
            UnmanagedHRFunc func,
            IntPtr userData);

        /// <summary>
        /// Retrieves every key inside @hashTable. The returned data is valid
        /// until changes to the hash release those keys.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <returns>
        /// a #GList containing all the keys inside the hash
        ///     table. The content of the list is owned by the hash table and
        ///     should not be modified or freed. Use g_list_free() when done
        ///     using the list.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.14")]
        private protected static extern IntPtr g_hash_table_get_keys(
            IntPtr hashTable);

        /// <summary>
        /// Retrieves every key inside @hashTable, as an array.
        /// </summary>
        /// <remarks>
        /// The returned array is %NULL-terminated but may contain %NULL as a
        /// key.  Use @length to determine the true length if it's possible that
        /// %NULL was used as the value for a key.
        ///
        /// Note: in the common case of a string-keyed #GHashTable, the return
        /// value of this function can be conveniently cast to (gchar **).
        ///
        /// You should always free the return result with g_free().  In the
        /// above-mentioned case of a string-keyed hash table, it may be
        /// appropriate to use g_strfreev() if you call g_hash_table_steal_all()
        /// first to transfer ownership of the keys.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="length">
        /// the length of the returned array
        /// </param>
        /// <returns>
        /// a
        ///   %NULL-terminated array containing each key from the table.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.40")]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        private protected static extern unsafe IntPtr[] g_hash_table_get_keys_as_array(
            IntPtr hashTable,
            uint* length);

        /// <summary>
        /// Retrieves every value inside @hashTable. The returned data
        /// is valid until @hashTable is modified.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <returns>
        /// a #GList containing all the values inside the hash
        ///     table. The content of the list is owned by the hash table and
        ///     should not be modified or freed. Use g_list_free() when done
        ///     using the list.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.14")]
        private protected static extern IntPtr g_hash_table_get_values(
            IntPtr hashTable);

        /// <summary>
        /// Inserts a new key and value into a #GHashTable.
        /// </summary>
        /// <remarks>
        /// If the key already exists in the #GHashTable its current
        /// value is replaced with the new value. If you supplied a
        /// @value_destroy_func when creating the #GHashTable, the old
        /// value is freed using that function. If you supplied a
        /// @key_destroy_func when creating the #GHashTable, the passed
        /// key is freed using that function.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <param name="value">
        /// the value to associate with the key
        /// </param>
        /// <returns>
        /// %TRUE if the key did not exist yet
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_hash_table_insert(
            IntPtr hashTable,
            IntPtr key,
            IntPtr value);

        /// <summary>
        /// Looks up a key in a #GHashTable. Note that this function cannot
        /// distinguish between a key that is not present and one which is present
        /// and has the value %NULL. If you need this distinction, use
        /// g_hash_table_lookup_extended().
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// the key to look up
        /// </param>
        /// <returns>
        /// the associated value, or %NULL if the key is not found
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern IntPtr g_hash_table_lookup(
            IntPtr hashTable,
            IntPtr key);

        /// <summary>
        /// Looks up a key in the #GHashTable, returning the original key and the
        /// associated value and a #gboolean which is %TRUE if the key was found. This
        /// is useful if you need to free the memory allocated for the original key,
        /// for example before calling g_hash_table_remove().
        /// </summary>
        /// <remarks>
        /// You can actually pass %NULL for @lookup_key to test
        /// whether the %NULL key exists, provided the hash and equal functions
        /// of @hashTable are %NULL-safe.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="lookupKey">
        /// the key to look up
        /// </param>
        /// <param name="origKey">
        /// return location for the original key, or %NULL
        /// </param>
        /// <param name="value">
        /// return location for the value associated with the key, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if the key was found in the #GHashTable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected unsafe static extern Runtime.Boolean g_hash_table_lookup_extended(
            IntPtr hashTable,
            IntPtr lookupKey,
            IntPtr* origKey,
            IntPtr* value);

        /// <summary>
        /// Removes a key and its associated value from a #GHashTable.
        /// </summary>
        /// <remarks>
        /// If the #GHashTable was created using g_hash_table_new_full(), the
        /// key and value are freed using the supplied destroy functions, otherwise
        /// you have to make sure that any dynamically allocated values are freed
        /// yourself.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed from the #GHashTable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_hash_table_remove(
            IntPtr hashTable,
            IntPtr key);

        /// <summary>
        /// Removes all keys and their associated values from a #GHashTable.
        /// </summary>
        /// <remarks>
        /// If the #GHashTable was created using g_hash_table_new_full(),
        /// the keys and values are freed using the supplied destroy functions,
        /// otherwise you have to make sure that any dynamically allocated
        /// values are freed yourself.
        /// </remarks>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.12")]
        private protected static extern void g_hash_table_remove_all(
            IntPtr hashTable);

        /// <summary>
        /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        [Since("2.12")]
        public void RemoveAll()
        {
            g_hash_table_remove_all(UnsafeHandle);
        }

        /// <summary>
        /// Inserts a new key and value into a #GHashTable similar to
        /// g_hash_table_insert(). The difference is that if the key
        /// already exists in the #GHashTable, it gets replaced by the
        /// new key. If you supplied a @value_destroy_func when creating
        /// the #GHashTable, the old value is freed using that function.
        /// If you supplied a @key_destroy_func when creating the
        /// #GHashTable, the old key is freed using that function.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <param name="value">
        /// the value to associate with the key
        /// </param>
        /// <returns>
        /// %TRUE of the key did not exist yet
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_hash_table_replace(
            IntPtr hashTable,
            IntPtr key,
            IntPtr value);

        /// <summary>
        /// Returns the number of elements contained in the #GHashTable.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <returns>
        /// the number of key/value pairs in the #GHashTable.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_hash_table_size(
            IntPtr hashTable);

        /// <summary>
        /// Returns the number of elements contained in the <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <returns>
        /// the number of key/value pairs in the <see cref="HashTable{K,V}"/>.
        /// </returns>
        public int Size {
            get {
                var ret = g_hash_table_size(UnsafeHandle);
                return (int)ret;
            }
        }

        /// <summary>
        /// Removes a key and its associated value from a #GHashTable without
        /// calling the key and value destroy functions.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed from the #GHashTable
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_hash_table_steal(
            IntPtr hashTable,
            IntPtr key);

        /// <summary>
        /// Removes all keys and their associated values from a #GHashTable
        /// without calling the key and value destroy functions.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.12")]
        static extern void g_hash_table_steal_all(
            IntPtr hashTable);

        // /// <summary>
        // /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>
        // /// without calling the key and value destroy functions.
        // /// </summary>
        // [Since("2.12")]
        // public void StealAll ()
        // {
        //    g_hash_table_steal_all(UnsafeHandle);
        // }

        /// <summary>
        /// Compares two #gpointer arguments and returns %TRUE if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using opaque pointers compared by pointer value as
        /// keys in a #GHashTable.
        /// </summary>
        /// <remarks>
        /// This equality function is also appropriate for keys that are integers
        /// stored in pointers, such as `GINT_TO_POINTER (n)`.
        /// </remarks>
        /// <param name="v1">
        /// a key
        /// </param>
        /// <param name="v2">
        /// a key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_direct_equal(
            IntPtr v1,
            IntPtr v2);

        /// <summary>
        /// Converts a gpointer to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using opaque pointers compared by pointer value as keys in a
        /// #GHashTable.
        /// </summary>
        /// <remarks>
        /// This hash function is also appropriate for keys that are integers
        /// stored in pointers, such as `GINT_TO_POINTER (n)`.
        /// </remarks>
        /// <param name="v">
        /// a #gpointer key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_direct_hash(
            IntPtr v);

        /// <summary>
        /// Compares the two #gdouble values being pointed to and returns
        /// %TRUE if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL pointers to doubles as keys in a
        /// #GHashTable.
        /// </summary>
        /// <param name="v1">
        /// a pointer to a #gdouble key
        /// </param>
        /// <param name="v2">
        /// a pointer to a #gdouble key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        private protected static extern Runtime.Boolean g_double_equal(
            IntPtr v1,
            IntPtr v2);

        /// <summary>
        /// Converts a pointer to a #gdouble to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-%NULL pointers to doubles as keys in a #GHashTable.
        /// </summary>
        /// <param name="v">
        /// a pointer to a #gdouble key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        private protected static extern uint g_double_hash(
            IntPtr v);

        /// <summary>
        /// Compares the two #gint values being pointed to and returns
        /// %TRUE if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL pointers to integers as keys in a
        /// #GHashTable.
        /// </summary>
        /// <remarks>
        /// Note that this function acts on pointers to #gint, not on #gint
        /// directly: if your hash table's keys are of the form
        /// `GINT_TO_POINTER (n)`, use g_direct_equal() instead.
        /// </remarks>
        /// <param name="v1">
        /// a pointer to a #gint key
        /// </param>
        /// <param name="v2">
        /// a pointer to a #gint key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_int_equal(
            IntPtr v1,
            IntPtr v2);

        /// <summary>
        /// Converts a pointer to a #gint to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-%NULL pointers to integer values as keys in a #GHashTable.
        /// </summary>
        /// <remarks>
        /// Note that this function acts on pointers to #gint, not on #gint
        /// directly: if your hash table's keys are of the form
        /// `GINT_TO_POINTER (n)`, use g_direct_hash() instead.
        /// </remarks>
        /// <param name="v">
        /// a pointer to a #gint key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_int_hash(
            IntPtr v);

        /// <summary>
        /// Compares the two #gint64 values being pointed to and returns
        /// %TRUE if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-%NULL pointers to 64-bit integers as keys in a
        /// #GHashTable.
        /// </summary>
        /// <param name="v1">
        /// a pointer to a #gint64 key
        /// </param>
        /// <param name="v2">
        /// a pointer to a #gint64 key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        private protected static extern Runtime.Boolean g_int64_equal(
            IntPtr v1,
            IntPtr v2);

        /// <summary>
        /// Converts a pointer to a #gint64 to a hash value.
        /// </summary>
        /// <remarks>
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-%NULL pointers to 64-bit integer values as keys in a
        /// #GHashTable.
        /// </remarks>
        /// <param name="v">
        /// a pointer to a #gint64 key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        private protected static extern uint g_int64_hash(
            IntPtr v);

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns %TRUE
        /// if they are equal. It can be passed to g_hash_table_new() as the
        /// @key_equal_func parameter, when using non-%NULL strings as keys in a
        /// #GHashTable.
        /// </summary>
        /// <remarks>
        /// Note that this function is primarily meant as a hash table comparison
        /// function. For a general-purpose, %NULL-safe string comparison function,
        /// see g_strcmp0().
        /// </remarks>
        /// <param name="v1">
        /// a key
        /// </param>
        /// <param name="v2">
        /// a key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// %TRUE if the two keys match
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern Runtime.Boolean g_str_equal(
            IntPtr v1,
            IntPtr v2);

        /// <summary>
        /// Converts a string to a hash value.
        /// </summary>
        /// <remarks>
        /// This function implements the widely used "djb" hash apparently
        /// posted by Daniel Bernstein to comp.lang.c some time ago.  The 32
        /// bit unsigned hash value starts at 5381 and for each byte 'c' in
        /// the string, is updated: `hash = hash * 33 + c`. This function
        /// uses the signed value of each byte.
        ///
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-%NULL strings as keys in a #GHashTable.
        /// </remarks>
        /// <param name="v">
        /// a string key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private protected static extern uint g_str_hash(
            IntPtr v);
    }

    /// <summary>
    /// The <see cref="HashTable{K,V}"/> struct is an opaque data structure to represent a
    /// [Hash Table][glib-Hash-Tables]. It should only be accessed via the
    /// following functions.
    /// </summary>
    public sealed class HashTable<TKey, TValue> : HashTable
        where TKey : Opaque?
        where TValue : Opaque?
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HashTable(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly UnmanagedHashFunc directHash = g_direct_hash;
        static readonly UnmanagedEqualFunc directEqual = g_direct_equal;

        static IntPtr New()
        {
            var ret = g_hash_table_new(directHash, directEqual);
            return ret;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTable{K,V}"/> class.
        /// This instance does not maintain a reference to keys or values!
        /// </summary>
        public HashTable() : this(New(), Transfer.Full)
        {
        }

        /// <summary>
        /// This is a convenience function for using a <see cref="HashTable{K,V}"/> as a set.  It
        /// is equivalent to calling <see cref="Replace"/> with <paramref name="key"/> as both the
        /// key and the value.
        /// </summary>
        /// <remarks>
        /// When a hash table only ever contains keys that have themselves as the
        /// corresponding value it is able to be stored more efficiently.  See
        /// the discussion in the section description.
        /// </remarks>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <returns>
        /// <c>true</c> if the key did not exist yet
        /// </returns>
        [Since("2.32")]
        public bool TryAdd(TKey key)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_add(this_, key_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// This is a convenience function for using a <see cref="HashTable{K,V}"/> as a set.  It
        /// is equivalent to calling <see cref="Replace"/> with <paramref name="key"/> as both the
        /// key and the value.
        /// </summary>
        /// <remarks>
        /// When a hash table only ever contains keys that have themselves as the
        /// corresponding value it is able to be stored more efficiently.  See
        /// the discussion in the section description.
        /// </remarks>
        /// <param name="key">
        /// a key to insert
        /// </param>
        public void Add(TKey key)
        {
            if (!TryAdd(key)) {
                throw new ArgumentException("key already exists");
            }
        }

        /// <summary>
        /// Checks if <paramref name="key"/> is in this HashTable.
        /// </summary>
        /// <param name="key">
        /// a key to check
        /// </param>
        [Since("2.32")]
        public bool Contains(TKey key)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_contains(this_, key_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Calls the given function for key/value pairs in the <see cref="HashTable{K,V}"/>
        /// until <paramref name="predicate"/> returns <c>true</c>. The function
        /// is passed the key and value of each pair. The
        /// hash table may not be modified while iterating over it (you can't
        /// add/remove items).
        /// </summary>
        /// <remarks>
        /// Note, that hash tables are really only optimized for forward
        /// lookups, i.e. <see cref="Lookup(TKey)"/>. So code that frequently issues
        /// <see cref="Find"/> or <see cref="Foreach"/> (e.g. in the order of
        /// once per every entry in a hash table) should probably be reworked
        /// to use additional or different data structures for reverse lookups
        /// (keep in mind that an O(n) find/foreach operation issued for all n
        /// values in a hash table ends up needing O(n*n) operations).
        /// </remarks>
        /// <param name="predicate">
        /// function to test the key/value pairs for a certain property
        /// </param>
        /// <returns>
        /// The value of the first key/value pair is returned,
        /// for which <paramref name="predicate"/> evaluates to <c>true</c>.
        /// If no pair with the
        /// requested property is found, <c>null</c> is returned.
        /// </returns>
        [Since("2.4")]
        public TValue Find(Predicate<KeyValuePair<TKey, TValue>> predicate)
        {
            var this_ = UnsafeHandle;
            UnmanagedHRFunc predicate_ = (predicateKeyPtr, predicateValuePtr, predicateUserData) => {
                var predicateKey = GetInstance<TKey>(predicateKeyPtr, Transfer.None);
                var predicateValue = GetInstance<TValue>(predicateValuePtr, Transfer.None);
                var predicateRet = predicate(new KeyValuePair<TKey, TValue>(predicateKey, predicateValue));
                return predicateRet.ToBoolean();
            };
            var ret_ = g_hash_table_find(this_, predicate_, IntPtr.Zero);
            GC.KeepAlive(predicate_);
            var ret = GetInstance<TValue>(ret_, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Calls the given function for each of the key/value pairs in the
        /// <see cref="HashTable{K,V}"/>.  The function is passed the key and
        /// value of each pair.  The hash table may not
        /// be modified while iterating over it (you can't add/remove
        /// items). To remove all items matching a predicate, use
        /// <see cref="ForeachRemove"/>.
        /// </summary>
        /// <remarks>
        /// See <see cref="Find"/> for performance caveats for linear
        /// order searches in contrast to <see cref="Lookup(TKey)"/>.
        /// </remarks>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        public void Foreach(Action<TKey, TValue> func)
        {
            var this_ = UnsafeHandle;
            UnmanagedHFunc func_ = (funcKeyPtr, funcValuePtr, funcUserData) => {
                var funcKey = GetInstance<TKey>(funcKeyPtr, Transfer.None);
                var funcValue = GetInstance<TValue>(funcValuePtr, Transfer.None);
                func(funcKey, funcValue);
            };
            g_hash_table_foreach(this_, func_, IntPtr.Zero);
            GC.KeepAlive(func_);
        }

        /// <summary>
        /// Calls the given function for each key/value pair in the
        /// <see cref="HashTable{K,V}"/>. If the function returns <c>true</c>, then the key/value
        /// pair is removed from the <see cref="HashTable{K,V}"/>. If you supplied key or
        /// value destroy functions when creating the <see cref="HashTable{K,V}"/>, they are
        /// used to free the memory allocated for the removed keys and values.
        /// </summary>
        /// <remarks>
        /// See <see cref="HashTable{K,V}"/>Iter for an alternative way to loop over the
        /// key/value pairs in the hash table.
        /// </remarks>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        /// <returns>
        /// the number of key/value pairs removed
        /// </returns>
        public int ForeachRemove(Predicate<KeyValuePair<TKey, TValue>> func)
        {
            var this_ = UnsafeHandle;
            UnmanagedHRFunc func_ = (funcKeyPtr, funcValuePtr, funcUserData) => {
                var funcKey = GetInstance<TKey>(funcKeyPtr, Transfer.None);
                var funcValue = GetInstance<TValue>(funcValuePtr, Transfer.None);
                var funcRet = func(new KeyValuePair<TKey, TValue>(funcKey, funcValue));
                return funcRet.ToBoolean();
            };
            var ret = g_hash_table_foreach_remove(this_, func_, IntPtr.Zero);
            GC.KeepAlive(func_);
            return (int)ret;
        }

        ///// <summary>
        ///// Calls the given function for each key/value pair in the
        ///// <see cref="HashTable{K,V}"/>. If the function returns <c>true</c>, then the key/value
        ///// pair is removed from the <see cref="HashTable{K,V}"/>, but no key or value
        ///// destroy functions are called.
        ///// </summary>
        ///// <remarks>
        ///// See <see cref="HashTable{K,V}"/>Iter for an alternative way to loop over the
        ///// key/value pairs in the hash table.
        ///// </remarks>
        ///// <param name="func">
        ///// the function to call for each key/value pair
        ///// </param>
        ///// <returns>
        ///// the number of key/value pairs removed.
        ///// </returns>
        //public uint ForeachSteal (HRFunc<TKey,TValue> func)
        //{
        //    var this_ = UnsafeHandle;
        //    UnmanagedHRFunc funcUnmanaged = (funcKeyPtr, funcValuePtr, funcUserData) => {
        //        var funcKey = GetInstance<TKey> (funcKeyPtr, Transfer.None);
        //        var funcValue = GetInstance<TValue> (funcValuePtr, Transfer.None);
        //        var funcRet = func.Invoke (funcKey, funcValue);
        //        return funcRet;
        //    };
        //    var ret = g_hash_table_foreach_steal(this_, funcUnmanaged, IntPtr.Zero);
        //    return ret;
        //}

        /// <summary>
        /// Retrieves every key inside this HashTable. The returned data is valid
        /// until changes to the hash release those keys.
        /// </summary>
        /// <returns>
        /// a <see cref="List{T}"/> containing all the keys inside the hash table.
        /// </returns>
        [Since("2.14")]
        public List<TKey> Keys {
            get {
                var ret_ = g_hash_table_get_keys(UnsafeHandle);
                var ret = GetInstance<List<TKey>>(ret_, Transfer.Container) ?? new List<TKey>();
                return ret;
            }
        }

        /// <summary>
        /// Retrieves every value inside this HashTable. The returned data
        /// is valid until this HashTable is modified.
        /// </summary>
        /// <returns>
        /// a <see cref="List{T}"/> containing all the values inside the hash
        ///     table. The content of the list is owned by the hash table and
        ///     should not be modified or freed. Use g_list_free() when done
        ///     using the list.
        /// </returns>
        [Since("2.14")]
        public List<TValue> Values {
            get {
                var ret_ = g_hash_table_get_values(UnsafeHandle);
                var ret = GetInstance<List<TValue>>(ret_, Transfer.Container) ?? new List<TValue>();
                return ret;
            }
        }

        /// <summary>
        /// Inserts a new key and value into a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// If the key already exists in the <see cref="HashTable{K,V}"/> its current
        /// value is replaced with the new value.
        /// </remarks>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <param name="value">
        /// the value to associate with the key
        /// </param>
        /// <returns>
        /// <c>true</c> if the key did not exist yet
        /// </returns>
        public bool Insert(TKey key, TValue value)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var value_ = value?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_insert(this_, key_, value_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Looks up a key in a <see cref="HashTable{K,V}"/>. Note that this function cannot
        /// distinguish between a key that is not present and one which is present
        /// and has the value <c>null</c>. If you need this distinction, use
        /// <see cref="Lookup(TKey,out TKey,out TValue)"/>.
        /// </summary>
        /// <param name="key">
        /// the key to look up
        /// </param>
        /// <returns>
        /// the associated value, or <c>null</c> if the key is not found
        /// </returns>
        public TValue Lookup(TKey key)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_lookup(this_, key_);
            var ret = GetInstance<TValue>(ret_, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Looks up a key in the <see cref="HashTable{K,V}"/>, returning the original key and the
        /// associated value and a <see cref="bool"/> which is <c>true</c> if the key was found. This
        /// is useful if you need to free the memory allocated for the original key,
        /// for example before calling <see cref="Remove"/>.
        /// </summary>
        /// <remarks>
        /// You can actually pass <c>null</c> for <paramref name="lookupKey"/> to test
        /// whether the <c>null</c> key exists, provided the hash and equal functions
        /// of this HashTable are <c>null</c>-safe.
        /// </remarks>
        /// <param name="lookupKey">
        /// the key to look up
        /// </param>
        /// <param name="origKey">
        /// return location for the original key
        /// </param>
        /// <param name="value">
        /// return location for the value associated with the key
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found in the <see cref="HashTable{K,V}"/>
        /// </returns>
        public unsafe bool Lookup(TKey lookupKey, out TKey origKey, out TValue value)
        {
            var this_ = UnsafeHandle;
            var lookupKey_ = lookupKey?.UnsafeHandle ?? IntPtr.Zero;
            var origKey_ = IntPtr.Zero;
            var value_ = IntPtr.Zero;
            var ret_ = g_hash_table_lookup_extended(this_, lookupKey_, &origKey_, &value_);
            origKey = GetInstance<TKey>(origKey_, Transfer.None);
            value = GetInstance<TValue>(value_, Transfer.None);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Removes a key and its associated value from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed from the <see cref="HashTable{K,V}"/>
        /// </returns>
        public bool Remove(TKey key)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_remove(this_, key_);
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Inserts a new key and value into a <see cref="HashTable{K,V}"/> similar to
        /// g_hash_table_insert(). The difference is that if the key
        /// already exists in the <see cref="HashTable{K,V}"/>, it gets replaced by the
        /// new key. If you supplied a @value_destroy_func when creating
        /// the <see cref="HashTable{K,V}"/>, the old value is freed using that function.
        /// If you supplied a @key_destroy_func when creating the
        /// <see cref="HashTable{K,V}"/>, the old key is freed using that function.
        /// </summary>
        /// <param name="key">
        /// a key to insert
        /// </param>
        /// <param name="value">
        /// the value to associate with the key
        /// </param>
        /// <returns>
        /// <c>true</c> of the key did not exist yet
        /// </returns>
        public bool Replace(TKey key, TValue value)
        {
            var this_ = UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var value_ = value?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_replace(this_, key_, value_);
            var ret = ret_.IsTrue();
            return ret;
        }

        // /// <summary>
        // /// Removes a key and its associated value from a <see cref="HashTable{K,V}"/>  without
        // /// calling the key and value destroy functions.
        // /// </summary>
        // /// <param name="key">
        // /// the key to remove
        // /// </param>
        // /// <returns>
        // /// <c>true</c> if the key was found and removed from the <see cref="HashTable{K,V}"/>
        // /// </returns>
        // public bool Steal (TKey key)
        // {
        //    var this_ = UnsafeHandle;
        //    var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
        //    var ret = g_hash_table_steal(this_, key_);
        //    return ret;
        // }
    }
}
