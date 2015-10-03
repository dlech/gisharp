using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GISharp.Core
{
    /// <summary>
    /// The <see cref="HashTable{K,V}"/> struct is an opaque data structure to represent a
    /// [Hash Table][glib-Hash-Tables]. It should only be accessed via the
    /// following functions.
    /// </summary>
    // Analysis disable InconsistentNaming
    public sealed class HashTable<K,V> : ReferenceCountedOpaque<HashTable<K,V>>
        where K : Opaque where V : Opaque
    // Analysis restore InconsistentNaming
    {
        // Analysis disable StaticFieldInGenericType
        static readonly ICustomMarshaler keyTypeParameterCustomMarshaler;
        static readonly ICustomMarshaler valueTypeParameterCustomMarshaler;
        // Analysis restore StaticFieldInGenericType

        static HashTable () {
            keyTypeParameterCustomMarshaler = typeof(K).GetCustomMarshaler ();
            valueTypeParameterCustomMarshaler = typeof(V).GetCustomMarshaler ();
        }

        // have to keep functions (closures) around for lifetime of object.

        HashFunc hashFuncNative;
        EqualFunc keyEqualFuncNative;
        DestroyNotify keyDestroyFuncNative;
        DestroyNotify valueDestroyFuncNative;

        /// <summary>
        /// Retrieves every key inside this HashTable. The returned data is valid
        /// until changes to the hash release those keys.
        /// </summary>
        /// <returns>
        /// a <see cref="List{T}"/> containing all the keys inside the hash
        ///     table. The content of the list is owned by the hash table and
        ///     should not be modified or freed. Use g_list_free() when done
        ///     using the list.
        /// </returns>
        [Since("2.14")]
        public List<K> Keys
        {
            get
            {
                var retPtr = HashTableInternal.g_hash_table_get_keys (Handle);
                var ret = new List<K> (retPtr);
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
        public List<V> Values
        {
            get
            {
                var retPtr = HashTableInternal.g_hash_table_get_keys (Handle);
                var ret = new List<V> (retPtr);
                return ret;
            }
        }

        public HashTable (IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Creates a new <see cref="HashTable{K,V}"/> with a reference count of 1.
        /// </summary>
        /// <remarks>
        /// Hash values returned by @hash_func are used to determine where keys
        /// are stored within the <see cref="HashTable{K,V}"/> data structure. The g_direct_hash(),
        /// g_int_hash(), g_int64_hash(), g_double_hash() and g_str_hash()
        /// functions are provided for some common types of keys.
        /// If @hash_func is <c>null</c>, g_direct_hash() is used.
        /// 
        /// @key_equal_func is used when looking up keys in the <see cref="HashTable{K,V}"/>.
        /// The g_direct_equal(), g_int_equal(), g_int64_equal(), g_double_equal()
        /// and g_str_equal() functions are provided for the most common types
        /// of keys. If @key_equal_func is <c>null</c>, keys are compared directly in
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
        /// a new <see cref="HashTable{K,V}"/>
        /// </returns>
//        public HashTable (HashFunc<K> hashFunc = null, EqualFunc<K> keyEqualFunc = null) : base (IntPtr.Zero)
//        {
//            HashFuncNative hashFuncNative = hashFunc == null
//                ? default(HashFuncNative)
//                : (hashFuncKeyPtr) =>
//            {
//                var hashFuncKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (hashFuncKeyPtr);
//                var hashFuncRet = hashFunc.Invoke (hashFuncKey);
//                return hashFuncRet;
//            };
//            EqualFuncNative keyEqualFuncNative = keyEqualFunc == null
//                ? default(EqualFuncNative)
//                : (keyEqualFuncAPtr, keyEqualFuncBPtr) =>
//            {
//                var keyEqualFuncA = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (keyEqualFuncAPtr);
//                var keyEqualFuncB = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (keyEqualFuncBPtr);
//                var keyEqualFuncRet = keyEqualFunc.Invoke (keyEqualFuncA, keyEqualFuncB);
//                return keyEqualFuncRet;
//            };
//            Handle = HashTableInternal.g_hash_table_new (hashFuncNative, keyEqualFuncNative);
//        }

        /// <summary>
        /// Creates a new <see cref="HashTable{K,V}"/> like g_hash_table_new() with a reference
        /// count of 1 and allows to specify functions to free the memory
        /// allocated for the key and value that get called when removing the
        /// entry from the <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="hashFunc">
        /// a function to create a hash value from a key
        /// </param>
        /// <param name="keyEqualFunc">
        /// a function to check two keys for equality
        /// </param>
        /// <param name="keyDestroyFunc">
        /// a function to free the memory allocated for the key
        ///     used when removing the entry from the <see cref="HashTable{K,V}"/>, or <c>null</c>
        ///     if you don't want to supply such a function.
        /// </param>
        /// <param name="valueDestroyFunc">
        /// a function to free the memory allocated for the
        ///     value used when removing the entry from the <see cref="HashTable{K,V}"/>, or <c>null</c>
        ///     if you don't want to supply such a function.
        /// </param>
        /// <returns>
        /// a new <see cref="HashTable{K,V}"/>
        /// </returns>
        public HashTable(HashFuncCallback<K> hashFunc = null, EqualFuncCallback<K> keyEqualFunc = null,
            DestroyNotifyCallback<K> keyDestroyFunc = null, DestroyNotifyCallback<V> valueDestroyFunc = null)
        {
            if (hashFunc != null) {
                hashFuncNative = (hashFuncKeyPtr) => {
                    var hashFuncKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (hashFuncKeyPtr);
                    var hashFuncRet = hashFunc.Invoke (hashFuncKey);
                    return hashFuncRet;
                };
            }
            if (keyEqualFunc != null) {
                keyEqualFuncNative = (keyEqualFuncAPtr, keyEqualFuncBPtr) => {
                    var keyEqualFuncA = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (keyEqualFuncAPtr);
                    var keyEqualFuncB = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (keyEqualFuncBPtr);
                    var keyEqualFuncRet = keyEqualFunc.Invoke (keyEqualFuncA, keyEqualFuncB);
                    return keyEqualFuncRet;
                };
            }
            if (keyDestroyFunc != null) {
                keyDestroyFuncNative = (keyDestroyFuncDataPtr) => {
                    var keyDestroyFuncData = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (keyDestroyFuncDataPtr);
                    keyDestroyFunc.Invoke (keyDestroyFuncData);
                };
            }
            if (valueDestroyFunc != null) {
                valueDestroyFuncNative = (valueDestroyFuncDataPtr) => {
                    var valueDestroyFuncData = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (valueDestroyFuncDataPtr);
                    valueDestroyFunc.Invoke (valueDestroyFuncData);
                };
            }
            Handle = HashTableInternal.g_hash_table_new_full (hashFuncNative, keyEqualFuncNative, keyDestroyFuncNative, valueDestroyFuncNative);
        }

        /// <summary>
        /// Compares two <see cref="Opaque"/> arguments and returns <c>true</c> if they are equal.
        /// It can be passed to <see cref="HashTable{K,V}()"/>  as the <c>keyEqualFunc</c>
        /// parameter, when using opaque pointers compared by pointer value as
        /// keys in a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="v1">
        /// a key
        /// </param>
        /// <param name="v2">
        /// a key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        public static Boolean DirectEqual (K v1, K v2)
        {
            var v1Ptr = v1 == null ? IntPtr.Zero : v1.Handle;
            var v2Ptr = v2 == null ? IntPtr.Zero : v2.Handle;
            var ret = HashTableInternal.g_direct_equal (v1Ptr, v2Ptr);
            return ret;
        }

        /// <summary>
        /// Converts a gpointer to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using opaque pointers compared by pointer value as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// This hash function is also appropriate for keys that are integers
        /// stored in pointers, such as `GINT_TO_POINTER (n)`.
        /// </remarks>
        /// <param name="v">
        /// a <see cref="System.IntPtr"/> key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        public static UInt32 DirectHash (K v)
        {
            var vPtr = v == null ? IntPtr.Zero : v.Handle;
            var ret = HashTableInternal.g_direct_hash (vPtr);
            return ret;
        }

        /// <summary>
        /// Compares the two <see cref="System.Double"/> values being pointed to and returns
        /// <c>true</c> if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-<c>null</c> pointers to doubles as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="v1">
        /// a pointer to a <see cref="System.Double"/> key
        /// </param>
        /// <param name="v2">
        /// a pointer to a <see cref="System.Double"/> key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        [Since("2.22")]
        public static Boolean DoubleEqual (WrappedStruct<Double> v1, WrappedStruct<Double> v2)
        {
            var v1Ptr = v1 == null ? IntPtr.Zero : v1.Handle;
            var v2Ptr = v2 == null ? IntPtr.Zero : v2.Handle;
            var ret = HashTableInternal.g_double_equal (v1Ptr, v2Ptr);
            return ret;
        }

        /// <summary>
        /// Converts a pointer to a <see cref="System.Double"/> to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-<c>null</c> pointers to doubles as keys in a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="v">
        /// a pointer to a <see cref="System.Double"/> key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [Since("2.22")]
        public static UInt32 DoubleHash (WrappedStruct<Double> v)
        {
            var vPtr = v == null ? IntPtr.Zero : v.Handle;
            var ret = HashTableInternal.g_double_hash (vPtr);
            return ret;
        }

        /// <summary>
        /// Compares the two <see cref="System.Int32"/> values being pointed to and returns
        /// <c>true</c> if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-<c>null</c> pointers to integers as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this function acts on pointers to <see cref="System.Int32"/>, not on <see cref="System.Int32"/>
        /// directly: if your hash table's keys are of the form
        /// `GINT_TO_POINTER (n)`, use g_direct_equal() instead.
        /// </remarks>
        /// <param name="v1">
        /// a pointer to a <see cref="System.Int32"/> key
        /// </param>
        /// <param name="v2">
        /// a pointer to a <see cref="System.Int32"/> key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        public static Boolean IntEqual (WrappedStruct<Int32> v1, WrappedStruct<Int32> v2)
        {
            var v1Ptr = v1 == null ? IntPtr.Zero : v1.Handle;
            var v2Ptr = v2 == null ? IntPtr.Zero : v2.Handle;
            var ret = HashTableInternal.g_int_equal (v1Ptr, v2Ptr);
            return ret;
        }

        /// <summary>
        /// Converts a pointer to a <see cref="System.Int32"/> to a hash value.
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-<c>null</c> pointers to integer values as keys in a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this function acts on pointers to <see cref="System.Int32"/>, not on <see cref="System.Int32"/>
        /// directly: if your hash table's keys are of the form
        /// `GINT_TO_POINTER (n)`, use g_direct_hash() instead.
        /// </remarks>
        /// <param name="v">
        /// a pointer to a <see cref="System.Int32"/> key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        public static UInt32 IntHash (WrappedStruct<Int32> v)
        {
            var vPtr = v == null ? IntPtr.Zero : v.Handle;
            var ret = HashTableInternal.g_int_hash (vPtr);
            return ret;
        }

        /// <summary>
        /// Compares the two <see cref="System.Int32"/>64 values being pointed to and returns
        /// <c>true</c> if they are equal.
        /// It can be passed to g_hash_table_new() as the @key_equal_func
        /// parameter, when using non-<c>null</c> pointers to 64-bit integers as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="v1">
        /// a pointer to a <see cref="System.Int32"/>64 key
        /// </param>
        /// <param name="v2">
        /// a pointer to a <see cref="System.Int32"/>64 key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match.
        /// </returns>
        [Since("2.22")]
        public static Boolean Int64Equal (WrappedStruct<Int64> v1, WrappedStruct<Int64> v2)
        {
            var v1Ptr = v1 == null ? IntPtr.Zero : v1.Handle;
            var v2Ptr = v2 == null ? IntPtr.Zero : v2.Handle;
            var ret = HashTableInternal.g_int64_equal (v1Ptr, v2Ptr);
            return ret;
        }

        /// <summary>
        /// Converts a pointer to a <see cref="System.Int32"/>64 to a hash value.
        /// </summary>
        /// <remarks>
        /// It can be passed to g_hash_table_new() as the @hash_func parameter,
        /// when using non-<c>null</c> pointers to 64-bit integer values as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </remarks>
        /// <param name="v">
        /// a pointer to a <see cref="System.Int32"/>64 key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key.
        /// </returns>
        [Since("2.22")]
        public static UInt32 Int64Hash (WrappedStruct<Int64> v)
        {
            var vPtr = v == null ? IntPtr.Zero : v.Handle;
            var ret = HashTableInternal.g_int64_hash (vPtr);
            return ret;
        }

        /// <summary>
        /// Compares two strings for byte-by-byte equality and returns <c>true</c>
        /// if they are equal. It can be passed to g_hash_table_new() as the
        /// @key_equal_func parameter, when using non-<c>null</c> strings as keys in a
        /// <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// Note that this function is primarily meant as a hash table comparison
        /// function. For a general-purpose, <c>null</c>-safe string comparison function,
        /// see g_strcmp0().
        /// </remarks>
        /// <param name="v1">
        /// a key
        /// </param>
        /// <param name="v2">
        /// a key to compare with <paramref name="v1"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the two keys match
        /// </returns>
        public static Boolean StrEqual(WrappedStruct<IntPtr> v1, WrappedStruct<IntPtr> v2)
        {
            var v1Ptr = v1 == null ? IntPtr.Zero : v1.Handle;
            var v2Ptr = v2 == null ? IntPtr.Zero : v2.Handle;
            var ret = HashTableInternal.g_str_equal (v1Ptr, v2Ptr);
            return ret;
        }

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
        /// when using non-<c>null</c> strings as keys in a <see cref="HashTable{K,V}"/>.
        /// </remarks>
        /// <param name="v">
        /// a string key
        /// </param>
        /// <returns>
        /// a hash value corresponding to the key
        /// </returns>
        public static UInt32 StrHash (WrappedStruct<IntPtr> v)
        {
            var vPtr = v == null ? IntPtr.Zero : v.Handle;
            var ret = HashTableInternal.g_str_hash (vPtr);
            return ret;
        }

        /// <summary>
        /// This is a convenience function for using a <see cref="HashTable{K,V}"/> as a set.  It
        /// is equivalent to calling g_hash_table_replace() with <paramref name="key"/> as both the
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
        public Boolean Add (K key)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var ret = HashTableInternal.g_hash_table_add (Handle, keyPtr);
            return ret;
        }

        /// <summary>
        /// Checks if <paramref name="key"/> is in this HashTable.
        /// </summary>
        /// <param name="key">
        /// a key to check
        /// </param>
        [Since("2.32")]
        public Boolean Contains (K key)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var ret = HashTableInternal.g_hash_table_contains (Handle, keyPtr);
            return ret;
        }

        /// <summary>
        /// Destroys all keys and values in the <see cref="HashTable{K,V}"/> and decrements its
        /// reference count by 1. If keys and/or values are dynamically allocated,
        /// you should either free them first or create the <see cref="HashTable{K,V}"/> with destroy
        /// notifiers using g_hash_table_new_full(). In the latter case the destroy
        /// functions you supplied will be called on all keys and values during the
        /// destruction phase.
        /// </summary>
        public void Destroy ()
        {
            HashTableInternal.g_hash_table_destroy (Handle);
        }

        /// <summary>
        /// Calls the given function for key/value pairs in the <see cref="HashTable{K,V}"/>
        /// until @predicate returns <c>true</c>. The function is passed the key
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
        /// <param name="predicate">
        /// function to test the key/value pairs for a certain property
        /// </param>
        /// <returns>
        /// The value of the first key/value pair is returned,
        ///     for which @predicate evaluates to <c>true</c>. If no pair with the
        ///     requested property is found, <c>null</c> is returned.
        /// </returns>
        [Since("2.4")]
        public V Find (HRFuncCallback<K,V> predicate)
        {
            if (predicate == null) {
                throw new ArgumentNullException ("predicate");
            }
            HRFunc predicateNative = (predicateKeyPtr, predicateValuePtr, predicateUserData) => {
                var predicateKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (predicateKeyPtr);
                var predicateValue = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (predicateValuePtr);
                var predicateRet = predicate.Invoke (predicateKey, predicateValue);
                return predicateRet;
            };
            var retPtr = HashTableInternal.g_hash_table_find (Handle, predicateNative, IntPtr.Zero);
            if (retPtr == IntPtr.Zero) {
                return null;
            }
            var ret = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (retPtr);
            return ret;
        }

        /// <summary>
        /// Calls the given function for each of the key/value pairs in the
        /// <see cref="HashTable{K,V}"/>.  The function is passed the key and value of each
        /// pair, and the given @user_data parameter.  The hash table may not
        /// be modified while iterating over it (you can't add/remove
        /// items). To remove all items matching a predicate, use
        /// g_hash_table_foreach_remove().
        /// </summary>
        /// <remarks>
        /// See g_hash_table_find() for performance caveats for linear
        /// order searches in contrast to g_hash_table_lookup().
        /// </remarks>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        public void Foreach (HFuncCallback<K,V> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            HFunc funcNative = (funcKeyPtr, funcValuePtr, funcUserData) => {
                var funcKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (funcKeyPtr);
                var funcValue = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (funcValuePtr);
                func.Invoke (funcKey, funcValue);
            };
            HashTableInternal.g_hash_table_foreach (Handle, funcNative, IntPtr.Zero);
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
        public UInt32 ForeachRemove (HRFuncCallback<K,V> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            HRFunc funcNative = (funcKeyPtr, funcValuePtr, funcUserData) => {
                var funcKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (funcKeyPtr);
                var funcValue = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (funcValuePtr);
                var funcRet = func.Invoke (funcKey, funcValue);
                return funcRet;
            };
            var ret = HashTableInternal.g_hash_table_foreach_remove (Handle, funcNative, IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// Calls the given function for each key/value pair in the
        /// <see cref="HashTable{K,V}"/>. If the function returns <c>true</c>, then the key/value
        /// pair is removed from the <see cref="HashTable{K,V}"/>, but no key or value
        /// destroy functions are called.
        /// </summary>
        /// <remarks>
        /// See <see cref="HashTable{K,V}"/>Iter for an alternative way to loop over the
        /// key/value pairs in the hash table.
        /// </remarks>
        /// <param name="func">
        /// the function to call for each key/value pair
        /// </param>
        /// <returns>
        /// the number of key/value pairs removed.
        /// </returns>
        public UInt32 ForeachSteal (HRFuncCallback<K,V> func)
        {
            if (func == null) {
                throw new ArgumentNullException ("func");
            }
            HRFunc funcNative = (funcKeyPtr, funcValuePtr, funcUserData) => {
                var funcKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (funcKeyPtr);
                var funcValue = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (funcValuePtr);
                var funcRet = func.Invoke (funcKey, funcValue);
                return funcRet;
            };
            var ret = HashTableInternal.g_hash_table_foreach_steal (Handle, funcNative, IntPtr.Zero);
            return ret;
        }

        /// <summary>
        /// Inserts a new key and value into a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// If the key already exists in the <see cref="HashTable{K,V}"/> its current
        /// value is replaced with the new value. If you supplied a
        /// @value_destroy_func when creating the <see cref="HashTable{K,V}"/>, the old
        /// value is freed using that function. If you supplied a
        /// @key_destroy_func when creating the <see cref="HashTable{K,V}"/>, the passed
        /// key is freed using that function.
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
        public Boolean Insert (K key, V value)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var valuePtr = value == null ? IntPtr.Zero : value.Handle;
            var ret = HashTableInternal.g_hash_table_insert (Handle, keyPtr, valuePtr);
            return ret;
        }

        /// <summary>
        /// Looks up a key in a <see cref="HashTable{K,V}"/>. Note that this function cannot
        /// distinguish between a key that is not present and one which is present
        /// and has the value <c>null</c>. If you need this distinction, use
        /// g_hash_table_lookup_extended().
        /// </summary>
        /// <param name="key">
        /// the key to look up
        /// </param>
        /// <returns>
        /// the associated value, or <c>null</c> if the key is not found
        /// </returns>
        public V Lookup (K key)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var retPtr = HashTableInternal.g_hash_table_lookup (Handle, keyPtr);
            var ret = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (retPtr);
            return ret;
        }

        /// <summary>
        /// Looks up a key in the <see cref="HashTable{K,V}"/>, returning the original key and the
        /// associated value and a <see cref="Boolean"/> which is <c>true</c> if the key was found. This
        /// is useful if you need to free the memory allocated for the original key,
        /// for example before calling g_hash_table_remove().
        /// </summary>
        /// <remarks>
        /// You can actually pass <c>null</c> for @lookup_key to test
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
        public Boolean LookupExtended (K lookupKey, out K origKey, out V value)
        {
            var lookupKeyPtr = lookupKey == null ? IntPtr.Zero : lookupKey.Handle;
            IntPtr origKeyPtr, valuePtr;
            var ret = HashTableInternal.g_hash_table_lookup_extended (Handle, lookupKeyPtr, out origKeyPtr, out valuePtr);
            if (origKeyPtr == IntPtr.Zero) {
                origKey = null;
            } else {
                origKey = (K)keyTypeParameterCustomMarshaler.MarshalNativeToManaged (origKeyPtr);
            }
            if (valuePtr == IntPtr.Zero) {
                value = null;
            } else {
                value = (V)valueTypeParameterCustomMarshaler.MarshalNativeToManaged (valuePtr);
            }
            return ret;
        }

        /// <summary>
        /// Atomically increments the reference count of this HashTable by one.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        /// <returns>
        /// the passed in <see cref="HashTable{K,V}"/>
        /// </returns>
        [Since("2.10")]
        internal protected override void Ref ()
        {
            HashTableInternal.g_hash_table_ref (Handle);
        }

        /// <summary>
        /// Removes a key and its associated value from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// If the <see cref="HashTable{K,V}"/> was created using g_hash_table_new_full(), the
        /// key and value are freed using the supplied destroy functions, otherwise
        /// you have to make sure that any dynamically allocated values are freed
        /// yourself.
        /// </remarks>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed from the <see cref="HashTable{K,V}"/>
        /// </returns>
        public Boolean Remove (K key)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var ret = HashTableInternal.g_hash_table_remove (Handle, keyPtr);
            return ret;
        }

        /// <summary>
        /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <remarks>
        /// If the <see cref="HashTable{K,V}"/> was created using g_hash_table_new_full(),
        /// the keys and values are freed using the supplied destroy functions,
        /// otherwise you have to make sure that any dynamically allocated
        /// values are freed yourself.
        /// </remarks>
        [Since("2.12")]
        public void RemoveAll ()
        {
            HashTableInternal.g_hash_table_remove_all (Handle);
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
        public Boolean Replace (K key, V value)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var valuePtr = value == null ? IntPtr.Zero : value.Handle;
            var ret = HashTableInternal.g_hash_table_replace (Handle, keyPtr, valuePtr);
            return ret;
        }

        /// <summary>
        /// Returns the number of elements contained in the <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <returns>
        /// the number of key/value pairs in the <see cref="HashTable{K,V}"/>.
        /// </returns>
        public UInt32 Size {
            get {
                var ret = HashTableInternal.g_hash_table_size (Handle);
                return ret;
            }
        }

        /// <summary>
        /// Removes a key and its associated value from a <see cref="HashTable{K,V}"/>  without
        /// calling the key and value destroy functions.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed from the <see cref="HashTable{K,V}"/>
        /// </returns>
        public Boolean Steal (K key)
        {
            var keyPtr = key == null ? IntPtr.Zero : key.Handle;
            var ret = HashTableInternal.g_hash_table_steal (Handle, keyPtr);
            return ret;
        }

        /// <summary>
        /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>
        /// without calling the key and value destroy functions.
        /// </summary>
        [Since("2.12")]
        public void StealAll ()
        {
            HashTableInternal.g_hash_table_steal_all (Handle);
        }

        /// <summary>
        /// Atomically decrements the reference count of this HashTable by one.
        /// If the reference count drops to 0, all keys and values will be
        /// destroyed, and all memory allocated by the hash table is released.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        [Since("2.10")]
        internal protected override void Unref ()
        {
            HashTableInternal.g_hash_table_unref (Handle);
        }
    }

    /// <summary>
    /// PInvoke declarations can't be in a generic class
    /// </summary>
    static class HashTableInternal
    {
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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_hash_table_new(
            [In] HashFunc hashFunc,
            [In] EqualFunc keyEqualFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_hash_table_new_full(
            [In] HashFunc hashFunc,
            [In] EqualFunc keyEqualFunc,
            [In] DestroyNotify keyDestroyFunc,
            [In] DestroyNotify valueDestroyFunc);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_direct_equal(
            [In] IntPtr v1,
            [In] IntPtr v2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_direct_hash(
            [In] IntPtr v);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern Boolean g_double_equal(
            [In] IntPtr v1,
            [In] IntPtr v2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern UInt32 g_double_hash(
            [In] IntPtr v);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_int_equal(
            [In] IntPtr v1,
            [In] IntPtr v2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_int_hash(
            [In] IntPtr v);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern Boolean g_int64_equal(
            [In] IntPtr v1,
            [In] IntPtr v2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.22")]
        internal static extern UInt32 g_int64_hash(
            [In] IntPtr v);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_str_equal(
            [In] IntPtr v1,
            [In] IntPtr v2);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_str_hash(
            [In] IntPtr v);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        internal static extern Boolean g_hash_table_add(
            [In] IntPtr hashTable,
            [In] IntPtr key);

        /// <summary>
        /// Checks if @key is in @hashTable.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <param name="key">
        /// a key to check
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.32")]
        internal static extern Boolean g_hash_table_contains(
            [In] IntPtr hashTable,
            [In] IntPtr key);

        /// <summary>
        /// Destroys all keys and values in the #GHashTable and decrements its
        /// reference count by 1. If keys and/or values are dynamically allocated,
        /// you should either free them first or create the #GHashTable with destroy
        /// notifiers using g_hash_table_new_full(). In the latter case the destroy
        /// functions you supplied will be called on all keys and values during the
        /// destruction phase.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_hash_table_destroy(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.4")]
        internal static extern IntPtr g_hash_table_find(
            [In] IntPtr hashTable,
            [In] HRFunc predicate,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void g_hash_table_foreach(
            [In] IntPtr hashTable,
            [In] HFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_hash_table_foreach_remove(
            [In] IntPtr hashTable,
            [In] HRFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_hash_table_foreach_steal(
            [In] IntPtr hashTable,
            [In] HRFunc func,
            [In] IntPtr userData);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.14")]
        internal static extern IntPtr g_hash_table_get_keys(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.40")]
        [return: MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        internal static extern IntPtr[] g_hash_table_get_keys_as_array(
            [In] IntPtr hashTable,
            [Out()] out UInt32 length);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.14")]
        internal static extern IntPtr g_hash_table_get_values(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_hash_table_insert(
            [In] IntPtr hashTable,
            [In] IntPtr key,
            [In] IntPtr value);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr g_hash_table_lookup(
            [In] IntPtr hashTable,
            [In] IntPtr key);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_hash_table_lookup_extended(
            [In] IntPtr hashTable,
            [In] IntPtr lookupKey,
            [Out] out IntPtr origKey,
            [Out] out IntPtr value);

        /// <summary>
        /// Atomically increments the reference count of @hashTable by one.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        /// <param name="hashTable">
        /// a valid #GHashTable
        /// </param>
        /// <returns>
        /// the passed in #GHashTable
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.10")]
        internal static extern IntPtr g_hash_table_ref(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_hash_table_remove(
            [In] IntPtr hashTable,
            [In] IntPtr key);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.12")]
        internal static extern void g_hash_table_remove_all(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_hash_table_replace(
            [In] IntPtr hashTable,
            [In] IntPtr key,
            [In] IntPtr value);

        /// <summary>
        /// Returns the number of elements contained in the #GHashTable.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        /// <returns>
        /// the number of key/value pairs in the #GHashTable.
        /// </returns>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 g_hash_table_size(
            [In] IntPtr hashTable);

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
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Boolean g_hash_table_steal(
            [In] IntPtr hashTable,
            [In] IntPtr key);

        /// <summary>
        /// Removes all keys and their associated values from a #GHashTable
        /// without calling the key and value destroy functions.
        /// </summary>
        /// <param name="hashTable">
        /// a #GHashTable
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.12")]
        internal static extern void g_hash_table_steal_all(
            [In] IntPtr hashTable);

        /// <summary>
        /// Atomically decrements the reference count of @hashTable by one.
        /// If the reference count drops to 0, all keys and values will be
        /// destroyed, and all memory allocated by the hash table is released.
        /// This function is MT-safe and may be called from any thread.
        /// </summary>
        /// <param name="hashTable">
        /// a valid #GHashTable
        /// </param>
        [DllImport("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.10")]
        internal static extern void g_hash_table_unref(
            [In] IntPtr hashTable);
    }
}
