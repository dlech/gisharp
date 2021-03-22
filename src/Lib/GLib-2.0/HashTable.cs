// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class HashTable
    {
        private protected static UnmanagedStruct* New()
        {
            // TODO: hash and equal functions need to be retrieved from TKey and TValue
            var hashFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, uint>)CLibrary.GetSymbol("glib-2.0", "g_direct_hash");
            var keyEqualFunc_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, Runtime.Boolean>)CLibrary.GetSymbol("glib-2.0", "g_direct_equal");
            var ret = g_hash_table_new(hashFunc_, keyEqualFunc_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        private protected bool TryAdd<TKey>(TKey key) where TKey : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_add(hashTable_, key_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        private protected bool Contains<TKey>(TKey key) where TKey : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_contains(hashTable_, key_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        private protected TValue Find<TKey, TValue>(HRFunc<TKey, TValue> predicate) where TKey : Opaque? where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var predicate_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, Runtime.Boolean>)&FindPredicate;
            var userDataHandle = GCHandle.Alloc(new FindUserData(typeof(TKey), typeof(TValue), predicate));
            var userData_ = (IntPtr)userDataHandle;
            var ret_ = g_hash_table_find(hashTable_, predicate_, userData_);
            userDataHandle.Free();
            GMarshal.PopUnhandledException();
            var ret = GetInstance<TValue>(ret_, Transfer.None);
            return ret;
        }

        private record FindUserData(Type TKey, Type TValue, Delegate Predicate);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static Runtime.Boolean FindPredicate(IntPtr key_, IntPtr value_, IntPtr userData_)
        {
            try {
                var userData = (FindUserData)GCHandle.FromIntPtr(userData_).Target!;
                var key = GetInstance(userData.TKey, key_, Transfer.None);
                var value = GetInstance(userData.TValue, value_, Transfer.None);
                var ret = (bool)userData.Predicate.DynamicInvoke(key, value)!;
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
                return default;
            }
        }

        private protected void Foreach<TKey, TValue>(HFunc<TKey, TValue> func)
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, void>)&ForeachFunc;
            var userDataHandle = GCHandle.Alloc(new ForeachUserData(typeof(TKey), typeof(TValue), func));
            var userData_ = (IntPtr)userDataHandle;
            g_hash_table_foreach(hashTable_, func_, userData_);
            userDataHandle.Free();
            GMarshal.PopUnhandledException();
        }

        private record ForeachUserData(Type TKey, Type TValue, Delegate Func);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void ForeachFunc(IntPtr key_, IntPtr value_, IntPtr userData_)
        {
            try {
                var userData = (ForeachUserData)GCHandle.FromIntPtr(userData_).Target!;
                var key = GetInstance(userData.TKey, key_, Transfer.None);
                var value = GetInstance(userData.TValue, value_, Transfer.None);
                userData.Func.DynamicInvoke(key, value);
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        private protected int ForeachRemove<TKey, TValue>(HRFunc<TKey, TValue> func) where TKey : Opaque? where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var func_ = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, Runtime.Boolean>)&ForeachRemoveFunc;
            var userDataHandle = GCHandle.Alloc(new ForeachRemoveUserData(typeof(TKey), typeof(TValue), func));
            var userData_ = (IntPtr)userDataHandle;
            var ret_ = g_hash_table_foreach_remove(hashTable_, func_, userData_);
            userDataHandle.Free();
            GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        private record ForeachRemoveUserData(Type TKey, Type TValue, Delegate Func);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static Runtime.Boolean ForeachRemoveFunc(IntPtr key_, IntPtr value_, IntPtr userData_)
        {
            try {
                var userData = (ForeachRemoveUserData)GCHandle.FromIntPtr(userData_).Target!;
                var key = GetInstance(userData.TKey, key_, Transfer.None);
                var value = GetInstance(userData.TValue, value_, Transfer.None);
                var ret = (bool)userData.Func.DynamicInvoke(key, value)!;
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
                return default;
            }
        }

        /// <summary>
        /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        [Since("2.12")]
        public void RemoveAll()
        {
            g_hash_table_remove_all((UnmanagedStruct*)UnsafeHandle);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Returns the number of elements contained in the <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <returns>
        /// the number of key/value pairs in the <see cref="HashTable{K,V}"/>.
        /// </returns>
        public int Size {
            get {
                var ret = g_hash_table_size((UnmanagedStruct*)UnsafeHandle);
                GMarshal.PopUnhandledException();
                return (int)ret;
            }
        }

        private protected WeakList<TKey> GetKeys<TKey>() where TKey : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_hash_table_get_keys(hashTable_);
            GMarshal.PopUnhandledException();
            var ret = new WeakList<TKey>((IntPtr)ret_, Transfer.Container);
            return ret;
        }

        private protected WeakList<TValue> GetValues<TValue>() where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_hash_table_get_values(hashTable_);
            GMarshal.PopUnhandledException();
            var ret = new WeakList<TValue>((IntPtr)ret_, Transfer.Container);
            return ret;
        }

        private protected bool Insert<TKey, TValue>(TKey key, TValue value)
            where TKey : Opaque?
            where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var value_ = value?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_insert(hashTable_, key_, value_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        private protected TValue Lookup<TKey, TValue>(TKey key)
            where TKey : Opaque?
            where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_lookup(hashTable_, key_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<TValue>(ret_, Transfer.None);
            return ret;
        }

        private protected bool Lookup<TKey, TValue>(TKey lookupKey, out TKey origKey, out TValue value)
            where TKey : Opaque?
            where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var lookupKey_ = lookupKey?.UnsafeHandle ?? IntPtr.Zero;
            var origKey_ = IntPtr.Zero;
            var value_ = IntPtr.Zero;
            var ret_ = g_hash_table_lookup_extended(hashTable_, lookupKey_, &origKey_, &value_);
            GMarshal.PopUnhandledException();
            origKey = GetInstance<TKey>(origKey_, Transfer.None);
            value = GetInstance<TValue>(value_, Transfer.None);
            var ret = ret_.IsTrue();
            return ret;
        }

        private protected bool Remove<TKey>(TKey key) where TKey : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_remove(hashTable_, key_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        private protected bool Replace<TKey, TValue>(TKey key, TValue value)
            where TKey : Opaque?
            where TValue : Opaque?
        {
            var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
            var value_ = value?.UnsafeHandle ?? IntPtr.Zero;
            var ret_ = g_hash_table_replace(hashTable_, key_, value_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        // /// <summary>
        // /// Removes all keys and their associated values from a <see cref="HashTable{K,V}"/>
        // /// without calling the key and value destroy functions.
        // /// </summary>
        // [Since("2.12")]
        // public void StealAll ()
        // {
        //    g_hash_table_steal_all(UnsafeHandle);
        // }
    }

    /// <summary>
    /// The <see cref="HashTable{K,V}"/> struct is an opaque data structure to represent a
    /// [Hash Table][glib-Hash-Tables]. It should only be accessed via the
    /// following functions.
    /// </summary>
    public sealed unsafe class HashTable<TKey, TValue> : HashTable
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

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTable{K,V}"/> class.
        /// This instance does not maintain a reference to keys or values!
        /// </summary>
        public HashTable() : this((IntPtr)New(), Transfer.Full)
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
        public bool TryAdd(TKey key) => base.TryAdd(key);

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
        public bool Contains(TKey key) => base.Contains(key);

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
        public TValue Find(HRFunc<TKey, TValue> predicate) => Find<TKey, TValue>(predicate);

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
        public void Foreach(HFunc<TKey, TValue> func) => Foreach<TKey, TValue>(func);

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
        public int ForeachRemove(HRFunc<TKey, TValue> func) => ForeachRemove<TKey, TValue>(func);

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
        //    var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
        //    UnmanagedHRFunc funcUnmanaged = (funcKeyPtr, funcValuePtr, funcUserData) => {
        //        var funcKey = GetInstance<TKey> (funcKeyPtr, Transfer.None);
        //        var funcValue = GetInstance<TValue> (funcValuePtr, Transfer.None);
        //        var funcRet = func.Invoke (funcKey, funcValue);
        //        return funcRet;
        //    };
        //    var ret = g_hash_table_foreach_steal(hashTable_, funcUnmanaged, IntPtr.Zero);
        //    return ret;
        //}

        /// <summary>
        /// Retrieves every key inside this HashTable. The returned data is valid
        /// until changes to the hash release those keys.
        /// </summary>
        /// <returns>
        /// a <see cref="WeakList{T}"/> containing all the keys inside the hash table.
        /// </returns>
        [Since("2.14")]
        public WeakList<TKey> Keys => GetKeys<TKey>();

        /// <summary>
        /// Retrieves every value inside this HashTable. The returned data
        /// is valid until this HashTable is modified.
        /// </summary>
        /// <returns>
        /// a <see cref="WeakList{T}"/> containing all the values inside the hash table.
        /// </returns>
        [Since("2.14")]
        public WeakList<TValue> Values => GetValues<TValue>();

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
        public bool Insert(TKey key, TValue value) => base.Insert(key, value);

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
        public TValue Lookup(TKey key) => Lookup<TKey, TValue>(key);

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
        public bool Lookup(TKey lookupKey, out TKey origKey, out TValue value) =>
            base.Lookup(lookupKey, out origKey, out value);

        /// <summary>
        /// Removes a key and its associated value from a <see cref="HashTable{K,V}"/>.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed from the <see cref="HashTable{K,V}"/>
        /// </returns>
        public bool Remove(TKey key) => base.Remove(key);

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
        public bool Replace(TKey key, TValue value) => base.Replace(key, value);

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
        // public bool Steal(TKey key)
        // {
        //    var hashTable_ = (UnmanagedStruct*)UnsafeHandle;
        //    var key_ = key?.UnsafeHandle ?? IntPtr.Zero;
        //    var ret = g_hash_table_steal(hashTable_, key_);
        //    return ret;
        // }
    }
}
