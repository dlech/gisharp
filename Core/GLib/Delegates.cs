using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

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
    public delegate int UnmanagedCompareDataFunc ([In] IntPtr a, [In] IntPtr b, [In] IntPtr userData);

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
    public delegate int UnmanagedCompareFunc (IntPtr a, IntPtr b);

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
    public delegate int CompareFunc<T> (T a, T b);

    /// <summary>
    /// A function of this signature is used to copy data when doing a deep-copy.
    /// </summary>
    /// <param name="src">
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
    public delegate IntPtr UnmanagedCopyFunc ([In] IntPtr src, [In] IntPtr data);

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
    public delegate void UnmanagedDestroyNotify ([In] IntPtr data);

    /// <summary>
    /// Specifies the type of function which is called when a data element
    /// is destroyed. It is passed the pointer to the data element and
    /// should free any memory and resources allocated for it.
    /// </summary>
    /// <param name="data">
    /// the data element.
    /// </param>
    public delegate void DestroyNotify<T> (T data);

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
    public delegate bool UnmanagedEqualFunc ([In] IntPtr a, [In] IntPtr b);

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
    public delegate bool EqualFunc<T> (T a, T b) where T : Opaque;

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
    public delegate void UnmanagedFunc ([In] IntPtr data, [In] IntPtr userData);

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
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint UnmanagedHashFunc ([In] IntPtr key);

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
    public delegate uint HashFunc<T> (T key) where T : Opaque;


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
    public delegate void UnmanagedHFunc ([In] IntPtr key, [In] IntPtr value, [In] IntPtr userData);

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
    public delegate bool UnmanagedHRFunc ([In] IntPtr key, [In] IntPtr value, [In] IntPtr userData);

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
    public delegate bool HRFunc<K,V> (K key, V value);
    // Analysis restore InconsistentNaming

    /// <summary>
    /// Writer function for log entries. A log entry is a collection of one or more
    /// #GLogFields, using the standard [field names from journal
    /// specification](https://www.freedesktop.org/software/systemd/man/systemd.journal-fields.html).
    /// See g_log_structured() for more information.
    /// </summary>
    /// <remarks>
    /// Writer functions must ignore fields which they do not recognise, unless they
    /// can write arbitrary binary output, as field values may be arbitrary binary.
    /// 
    /// @log_level is guaranteed to be included in @fields as the `PRIORITY` field,
    /// but is provided separately for convenience of deciding whether or where to
    /// output the log entry.
    /// </remarks>
    [Since ("2.50")]
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate LogWriterOutput UnmanagedLogWriterFunc(
        /* <type name="LogLevelFlags" type="GLogLevelFlags" managed-name="LogLevelFlags" /> */
        /* transfer-ownership:none */
        LogLevelFlags logLevel,
        /* <array length="2" zero-terminated="0" type="GLogField*">
            <type name="LogField" type="GLogField" managed-name="LogField" />
            </array> */
        /* transfer-ownership:none */
        [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 2)] LogField[] fields,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        UIntPtr nFields,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 closure:3 */
        IntPtr userData);

    /// <summary>
    /// Writer function for log entries. A log entry is a collection of one or more
    /// #GLogFields, using the standard [field names from journal
    /// specification](https://www.freedesktop.org/software/systemd/man/systemd.journal-fields.html).
    /// See g_log_structured() for more information.
    /// </summary>
    /// <remarks>
    /// Writer functions must ignore fields which they do not recognise, unless they
    /// can write arbitrary binary output, as field values may be arbitrary binary.
    /// 
    /// @log_level is guaranteed to be included in @fields as the `PRIORITY` field,
    /// but is provided separately for convenience of deciding whether or where to
    /// output the log entry.
    /// </remarks>
    [Since ("2.50")]
    public delegate LogWriterOutput LogWriterFunc (LogLevelFlags logLevel, LogField[] fields);

    public static class UnmanagedLogWriterFuncFactory
    {
        class UnmanagedLogWriterFuncData
        {
            public bool IsAsync;
            public LogWriterFunc Func;
            public UnmanagedLogWriterFunc UnmanagedFunc;
            public UnmanagedDestroyNotify UnmanagedNotify;
        }

        public static (UnmanagedLogWriterFunc, IntPtr) CreateDelegate(LogWriterFunc func, bool isAsync = false) {
            var data = new UnmanagedLogWriterFuncData {
                IsAsync = isAsync,
                Func = func,
                UnmanagedFunc = UnmanagedFunc,
                UnmanagedNotify = null,
            };
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnmanagedFunc, (IntPtr)gcHandle);
        }

        public static (UnmanagedLogWriterFunc, UnmanagedDestroyNotify, IntPtr) CreateNotifyDelegate(LogWriterFunc func) {
            var data = new UnmanagedLogWriterFuncData {
                IsAsync = false,
                Func = func,
                UnmanagedFunc = UnmanagedFunc,
                UnmanagedNotify = UnmanagedNotify,
            };
            var gcHandle = GCHandle.Alloc(data);

            return (data.UnmanagedFunc, data.UnmanagedNotify, (IntPtr)gcHandle);
        }

        static LogWriterOutput UnmanagedFunc(LogLevelFlags logLevel_, LogField[] fields_, UIntPtr nFields_, IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                var userData = (UnmanagedLogWriterFuncData)gcHandle.Target;
                var ret = userData.Func(logLevel_, fields_);
                if (userData.IsAsync) {
                    gcHandle.Free();
                }
                return ret;
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default(LogWriterOutput);
            }
        }

        static void UnmanagedNotify(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }
    }

    static class LogWriterFuncMarshaler
    {
        public static LogWriterOutput Invoke (LogLevelFlags logLevel, LogField[] fields, UIntPtr nfields, IntPtr userData)
        {
            var logWriterFunc = (LogWriterFunc)GCHandle.FromIntPtr (userData).Target;
            return logWriterFunc (logLevel, fields);
        }
    }

    /// <summary>
    /// Specifies the type of function passed to <see cref="MainContext.PollFunc"/>.
    /// The semantics of the function should match those of the poll() system call.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate int UnmanagedPollFunc (
        /* <type name="PollFD" type="GPollFD*" managed-name="PollFD" /> */
        /* transfer-ownership:none */
        [MarshalAs (UnmanagedType.LPArray, SizeParamIndex = 1)] PollFD[] ufds,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        uint nfsd,
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        int timeout);
}
