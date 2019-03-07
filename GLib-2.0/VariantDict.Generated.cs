// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// <see cref="VariantDict"/> is a mutable interface to #GVariant dictionaries.
    /// </summary>
    /// <remarks>
    /// It can be used for doing a sequence of dictionary lookups in an
    /// efficient way on an existing #GVariant dictionary or it can be used
    /// to construct new dictionaries with a hashtable-like interface.  It
    /// can also be used for taking existing dictionaries and modifying them
    /// in order to create new ones.
    /// 
    /// <see cref="VariantDict"/> can only be used with %G_VARIANT_TYPE_VARDICT
    /// dictionaries.
    /// 
    /// It is possible to use <see cref="VariantDict"/> allocated on the stack or on the
    /// heap.  When using a stack-allocated <see cref="VariantDict"/>, you begin with a
    /// call to g_variant_dict_init() and free the resources with a call to
    /// g_variant_dict_clear().
    /// 
    /// Heap-allocated <see cref="VariantDict"/> follows normal refcounting rules: you
    /// allocate it with <see cref="VariantDict.New"/> and use <see cref="VariantDict.Ref"/>
    /// and <see cref="VariantDict.Unref"/>.
    /// 
    /// <see cref="VariantDict.End"/> is used to convert the <see cref="VariantDict"/> back into a
    /// dictionary-type #GVariant.  When used with stack-allocated instances,
    /// this also implicitly frees all associated memory, but for
    /// heap-allocated instances, you must still call <see cref="VariantDict.Unref"/>
    /// afterwards.
    /// 
    /// You will typically want to use a heap-allocated <see cref="VariantDict"/> when
    /// you expose it as part of an API.  For most other uses, the
    /// stack-allocated form will be more convenient.
    /// 
    /// Consider the following two examples that do the same thing in each
    /// style: take an existing dictionary and look up the "count" uint32
    /// key, adding 1 to it if it is found, or returning an error if the
    /// key is not found.  Each returns the new dictionary as a floating
    /// #GVariant.
    /// 
    /// ## Using a stack-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict dict;
    ///     guint32 count;
    /// 
    ///     g_variant_dict_init (&amp;dict, orig);
    ///     if (!g_variant_dict_lookup (&amp;dict, "count", "u", &amp;count))
    ///       {
    ///         g_set_error (...);
    ///         g_variant_dict_clear (&amp;dict);
    ///         return NULL;
    ///       }
    /// 
    ///     g_variant_dict_insert (&amp;dict, "count", "u", count + 1);
    /// 
    ///     return g_variant_dict_end (&amp;dict);
    ///   }
    /// ]|
    /// 
    /// ## Using heap-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict *dict;
    ///     GVariant *result;
    ///     guint32 count;
    /// 
    ///     dict = g_variant_dict_new (orig);
    /// 
    ///     if (g_variant_dict_lookup (dict, "count", "u", &amp;count))
    ///       {
    ///         g_variant_dict_insert (dict, "count", "u", count + 1);
    ///         result = g_variant_dict_end (dict);
    ///       }
    ///     else
    ///       {
    ///         g_set_error (...);
    ///         result = NULL;
    ///       }
    /// 
    ///     g_variant_dict_unref (dict);
    /// 
    ///     return result;
    ///   }
    /// ]|
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.40")]
    [GISharp.Runtime.GTypeAttribute("GVariantDict", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantDict : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_variant_dict_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantDict(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_new(
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr fromAsv);

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="VariantDict.Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a <see cref="VariantDict"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using <see cref="VariantDict"/> to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a <see cref="VariantDict"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.Variant? fromAsv)
        {
            AssertNewArgs(fromAsv);
            var fromAsv_ = fromAsv?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_new(fromAsv_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="VariantDict.Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a <see cref="VariantDict"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using <see cref="VariantDict"/> to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public VariantDict(GISharp.Lib.GLib.Variant? fromAsv) : this(New(fromAsv), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_variant_dict_get_type();

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_variant_dict_contains(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key);

        /// <summary>
        /// Checks if <paramref name="key"/> exists in <paramref name="dict"/>.
        /// </summary>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="key"/> is in <paramref name="dict"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe System.Boolean Contains(GISharp.Lib.GLib.UnownedUtf8 key)
        {
            var dict_ = Handle;
            var key_ = key.Handle;
            var ret_ = g_variant_dict_contains(dict_,key_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_variant_dict_end(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict);

        /// <summary>
        /// Returns the current value of <paramref name="dict"/> as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use <paramref name="dict"/> in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// <see cref="VariantDict"/>) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe GISharp.Lib.GLib.Variant End()
        {
            var dict_ = Handle;
            var ret_ = g_variant_dict_end(dict_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_dict_insert_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Inserts (or replaces) a key in a <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="value"/> is consumed if it is floating.
        /// </remarks>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe void Insert(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.Variant value)
        {
            var dict_ = Handle;
            var key_ = key.Handle;
            var value_ = value.Handle;
            g_variant_dict_insert_value(dict_, key_, value_);
        }

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_lookup_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr expectedType);

        /// <summary>
        /// Looks up a value in a <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> is not found in <paramref name="dictionary"/>, <c>null</c> is returned.
        /// 
        /// The <paramref name="expectedType"/> string specifies what type of value is expected.
        /// If the value associated with <paramref name="key"/> has a different type then <c>null</c> is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If <paramref name="expectedType"/> was specified then any non-<c>null</c> return
        /// value will have this type.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or <c>null</c>
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe GISharp.Lib.GLib.Variant Lookup(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.VariantType? expectedType = null)
        {
            var dict_ = Handle;
            var key_ = key.Handle;
            var expectedType_ = expectedType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_lookup_value(dict_,key_,expectedType_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_ref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict);
        public override System.IntPtr Take() => g_variant_dict_ref(Handle);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_variant_dict_remove(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key);

        /// <summary>
        /// Removes a key and its associated value from a <see cref="VariantDict"/>.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe System.Boolean Remove(GISharp.Lib.GLib.UnownedUtf8 key)
        {
            var dict_ = Handle;
            var key_ = key.Handle;
            var ret_ = g_variant_dict_remove(dict_,key_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_dict_unref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr dict);
    }
}