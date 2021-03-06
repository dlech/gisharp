// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values.  The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if <paramref name="a"/> &lt; <paramref name="b"/>;
    /// zero if <paramref name="a"/> = <paramref name="b"/>; positive
    /// value if <paramref name="a"/> &gt; <paramref name="b"/>
    /// </returns>
    public delegate int CompareDataFunc<T>(T a, T b) where T : IOpaque;

    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values.  The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if @a &lt; @b; zero if @a = @b; positive
    ///          value if @a &gt; @b
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int UnmanagedCompareFunc(IntPtr a, IntPtr b);

    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values. The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if <paramref name="a"/> &lt; <paramref name="b"/>;
    /// zero if <paramref name="a"/> = <paramref name="b"/>; positive
    /// value if  <paramref name="a"/> &gt; <paramref name="b"/>
    /// </returns>
    public delegate int CompareFunc<T>(T a, T b) where T : IOpaque;

    /// <summary>
    /// A function of this signature is used to copy data when doing a deep-copy.
    /// </summary>
    /// <param name="src">
    /// the data which should be copied
    /// </param>
    /// <returns>
    /// the copy
    /// </returns>
    [Since("2.4")]
    public delegate T CopyFunc<T>(T src) where T : Opaque;

    /// <summary>
    /// Specifies the type of a function used to test two values for
    /// equality. The function should return <c>true</c> if both values are equal
    /// and <c>false</c> otherwise.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// <c>true</c> if <paramref name="a"/> = <paramref name="b"/>; <c>false</c> otherwise
    /// </returns>
    public delegate bool EqualFunc<T>(T a, T b) where T : Opaque;

    /// <summary>
    /// Specifies the type of functions passed to <see cref="List.Foreach"/> and
    /// <see cref="SList.Foreach"/>.
    /// </summary>
    /// <param name="data">
    /// the element's data
    /// </param>
    public delegate void Func<in T>(T data) where T : IOpaque?;

    /// <summary>
    /// Specifies the type of the hash function which is passed to
    /// g_hash_table_new() when a <see cref="HashTable{K,V}"/> is created.
    /// </summary>
    /// <remarks>
    /// The function is passed a key and should return a #guint hash value.
    /// The functions g_direct_hash(), g_int_hash() and g_str_hash() provide
    /// hash functions which can be used when the key is a #gpointer, #gint*,
    /// and #gchar* respectively.
    ///
    /// g_direct_hash() is also the appropriate hash function for keys
    /// of the form `GINT_TO_POINTER (n)` (or similar macros).
    ///
    /// &lt;!-- FIXME: Need more here. --&gt; A good hash functions should produce
    /// hash values that are evenly distributed over a fairly large range.
    /// The modulus is taken with the hash table size (a prime number) to
    /// find the 'bucket' to place each key into. The function should also
    /// be very fast, since it is called for each key lookup.
    ///
    /// Note that the hash functions provided by GLib have these qualities,
    /// but are not particularly robust against manufactured keys that
    /// cause hash collisions. Therefore, you should consider choosing
    /// a more secure hash function when using a GHashTable with keys
    /// that originate in untrusted data (such as HTTP requests).
    /// Using g_str_hash() in that situation might make your application
    /// vulnerable to
    /// [Algorithmic Complexity Attacks](https://lwn.net/Articles/474912/).
    ///
    /// The key to choosing a good hash is unpredictability.  Even
    /// cryptographic hashes are very easy to find collisions for when the
    /// remainder is taken modulo a somewhat predictable prime number.  There
    /// must be an element of randomness that an attacker is unable to guess.
    /// </remarks>
    /// <param name="key">
    /// a key
    /// </param>
    /// <returns>
    /// the hash value corresponding to the key
    /// </returns>
    public delegate uint HashFunc<T>(T key) where T : Opaque;

    /// <summary>
    /// Specifies the type of the function passed to <see cref="HashTable{K,V}.Foreach"/>.
    /// It is called with each key/value pair.
    /// </summary>
    /// <param name="key">
    /// a key
    /// </param>
    /// <param name="value">
    /// the value corresponding to the key
    /// </param>
    public delegate void HFunc<TKey, TValue>(TKey key, TValue value);

    /// <summary>
    /// Specifies the type of the function passed to
    /// <see cref="HashTable{K,V}.ForeachRemove"/>. It is called with each key/value
    /// pair. It should return <c>true</c> if the
    /// key/value pair should be removed from the <see cref="HashTable{K,V}"/>.
    /// </summary>
    /// <param name="key">
    /// a key
    /// </param>
    /// <param name="value">
    /// the value associated with the key
    /// </param>
    /// <returns>
    /// <c>true</c> if the key/value pair should be removed from the
    ///     <see cref="HashTable{K,V}"/>
    /// </returns>
    public delegate bool HRFunc<TKey, TValue>(TKey key, TValue value);

    /// <summary>
    /// Specifies the type of function passed to <see cref="MainContext.PollFunc"/>.
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int UnmanagedPollFunc(
        /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
        /* transfer-ownership:none */
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PollFD[] ufds,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nfsd,
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        int timeout);
}
