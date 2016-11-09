using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.GObject;

namespace GISharp.GLib
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
    /// <param name="userData">
    /// user data
    /// </param>
    /// <returns>
    /// negative value if @a &lt; @b; zero if @a = @b; positive
    ///          value if @a &gt; @b
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Int32 NativeCompareDataFunc ([In] IntPtr a, [In] IntPtr b, [In] IntPtr userData);

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
    public delegate Int32 NativeCompareFunc ([In] IntPtr a, [In] IntPtr b);

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
    /// negative value if @a &lt; @b; zero if @a = @b; positive
    ///          value if @a &gt; @b
    /// </returns>
    public delegate Int32 CompareFunc<T> (T a, T b) where T : Opaque;

    /// <summary>
    /// A function of this signature is used to copy data when doing a deep-copy.
    /// </summary>
    // <param name="src">
    /// A pointer to the data which should be copied
    /// </param>
    /// <param name="data">
    /// Additional data
    /// </param>
    /// <returns>
    /// A pointer to the copy
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [Since("2.4")]
    public delegate IntPtr NativeCopyFunc ([In] IntPtr src, [In] IntPtr data);

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
    public delegate T CopyFunc<T> (T src) where T : Opaque;

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    /// <param name="data">
    /// the data element.
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void NativeDestroyNotify ([In] IntPtr data);

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    /// <param name="data">
    /// the data element.
    /// </param>
    public delegate void DestroyNotify<T> (T data);

    public static class NativeDestoryNotifyFactory
    {
        /// <summary>
        /// Creates a destroy notify function that can be passed to native methods
        /// that frees the GCHandle when called.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public static NativeDestroyNotify Create (GCHandle handle)
        {
            NativeDestroyNotify method = (userData) => {
                handle.Free ();
                GCHandle.FromIntPtr (userData).Free ();
            };
            return method;
        }

        public static NativeDestroyNotify Create<T> (DestroyNotify<T> method, bool freeData) where T : Opaque
        {
            NativeDestroyNotify native = (userData_) => {
                var userData = Opaque.GetInstance<T> (userData_, Transfer.None);
                method.Invoke (userData);
                if (freeData) {
                    GCHandle.FromIntPtr (userData_).Free ();
                }
            };
            return native;
        }
    }

    /// <summary>
    /// Provides a default unmanged callback for freeing a GCHandle.
    /// </summary>
    public static class ManagedDestroyNotify
    {
        public static void Invoke (IntPtr userData)
        {
            GCHandle.FromIntPtr (userData).Free ();
        }
    }

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
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Boolean NativeEqualFunc ([In] IntPtr a, [In] IntPtr b);

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
    public delegate Boolean EqualFunc<T> (T a, T b) where T : Opaque;

    /// <summary>
    /// Specifies the type of functions passed to g_list_foreach() and
    /// g_slist_foreach().
    /// </summary>
    /// <param name="data">
    /// the element's data
    /// </param>
    /// <param name="userData">
    /// user data passed to g_list_foreach() or g_slist_foreach()
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void NativeFunc ([In] IntPtr data, [In] IntPtr userData);

    /// <summary>
    /// Specifies the type of functions passed to g_list_foreach() and
    /// g_slist_foreach().
    /// </summary>
    /// <param name="data">
    /// the element's data
    /// </param>
    public delegate void Func<T> (T data);

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
    /// vulerable to
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
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UInt32 NativeHashFunc ([In] IntPtr key);

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
    /// vulerable to
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
    public delegate UInt32 HashFunc<T> (T key) where T : Opaque;


    /// <summary>
    /// Specifies the type of the function passed to <see cref="HashTable{K,V}.Foreach"/>.
    /// It is called with each key/value pair, together with the <paramref name="userData"/>
    /// parameter which is passed to <see cref="HashTable{K,V}.Foreach"/>.
    /// </summary>
    /// <param name="key">
    /// a key
    /// </param>
    /// <param name="value">
    /// the value corresponding to the key
    /// </param>
    /// <param name="userData">
    /// user data passed to <see cref="HashTable{K,V}.Foreach"/>
    /// </param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void NativeHFunc ([In] IntPtr key, [In] IntPtr value, [In] IntPtr userData);

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
    // Analysis disable InconsistentNaming
    public delegate void HFunc<K,V> (K key, V value);
    // Analysis restore InconsistentNaming

    /// <summary>
    /// Specifies the type of the function passed to
    /// <see cref="HashTable{K,V}.ForeachRemove"/> . It is called with each key/value
    /// pair, together with the <paramref name="userData"/> parameter passed to
    /// <see cref="HashTable{K,V}.ForeachRemove"/>. It should return <c>true</c> if the
    /// key/value pair should be removed from the <see cref="HashTable{K,V}"/>.
    /// </summary>
    /// <param name="key">
    /// a key
    /// </param>
    /// <param name="value">
    /// the value associated with the key
    /// </param>
    /// <param name="userData">
    /// user data passed to g_hash_table_remove()
    /// </param>
    /// <returns>
    /// <c>true</c> if the key/value pair should be removed from the
    ///     <see cref="HashTable{K,V}"/>
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Boolean NativeHRFunc ([In] IntPtr key, [In] IntPtr value, [In] IntPtr userData);

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
    // Analysis disable InconsistentNaming
    public delegate Boolean HRFunc<K,V> (K key, V value);
    // Analysis restore InconsistentNaming

    /// <summary>
    /// Specifies the type of function passed to <see cref="MainContext.PollFunc"/>.
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate int NativePollFunc (
        /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
        /* transfer-ownership:none */
        [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)] PollFD[] ufds,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nfsd,
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        int timeout);
    
    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate bool NativeSourceFunc (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:0 */
        IntPtr userData);

    /// <summary>
    /// Specifies the type of function passed to <see cref="Timeout.Add"/>,
    /// and <see cref="Idle.Add"/>.
    /// </summary>
    public delegate bool SourceFunc ();

    /// <summary>
    /// Provides default unmanaged callback for wrapping a managed <see cref="SourceFunc"/>.
    /// </summary>
    public static class ManagedSourceFunc
    {
        /// <summary>
        /// Invoke the managage callback
        /// </summary>
        /// <param name="userData">GCHandle for the managed callback.</param>
        /// <remarks>
        /// This version of the callback does not free the GCHandle.
        /// </remarks>
        public static bool Invoke (IntPtr userData)
        {
            var sourceFunc = (SourceFunc)GCHandle.FromIntPtr (userData).Target;
            return sourceFunc ();
        }

        /// <summary>
        /// Invoke the managage callback
        /// </summary>
        /// <param name="userData">GCHandle for the managed callback.</param>
        /// <remarks>
        /// This version of the callback does frees the GCHandle, so it can only
        /// be called once.
        /// </remarks>
        public static bool InvokeAndFree (IntPtr userData)
        {
            var gcHandle = GCHandle.FromIntPtr (userData);
            var sourceFunc = (SourceFunc)gcHandle.Target;
            try {
                return sourceFunc ();
            } finally {
                gcHandle.Free ();
            }
        }
    }
}
