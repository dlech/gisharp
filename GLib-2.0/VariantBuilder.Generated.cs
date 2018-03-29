namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A utility type for constructing container-type #GVariant instances.
    /// </summary>
    /// <remarks>
    /// This is an opaque structure and may only be accessed using the
    /// following functions.
    /// 
    /// <see cref="VariantBuilder"/> is not threadsafe in any way.  Do not attempt to
    /// access it from more than one thread.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GVariantBuilder", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantBuilder : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_variant_builder_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantBuilder(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_builder_new(
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr type);

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantBuilder"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="VariantBuilder.Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a <see cref="VariantBuilder"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a <see cref="VariantBuilder"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.VariantType type)
        {
            AssertNewArgs(type);
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            var ret_ = g_variant_builder_new(type_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantBuilder"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="VariantBuilder.Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a <see cref="VariantBuilder"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public VariantBuilder(GISharp.Lib.GLib.VariantType type) : this(New(type), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_variant_builder_get_type();

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_add_value(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Adds <paramref name="value"/> to <paramref name="builder"/>.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If <paramref name="value"/> is a floating reference (see g_variant_ref_sink()),
        /// the <paramref name="builder"/> instance takes ownership of <paramref name="value"/>.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Add(GISharp.Lib.GLib.Variant value)
        {
            var builder_ = Handle;
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_variant_builder_add_value(builder_, value_);
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_close(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);

        /// <summary>
        /// Closes the subcontainer inside the given <paramref name="builder"/> that was opened by
        /// the most recent call to <see cref="VariantBuilder.Open"/>.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Close()
        {
            var builder_ = Handle;
            g_variant_builder_close(builder_);
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// g_variant_builder_end().
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_variant_builder_end(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use <paramref name="builder"/> in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated <see cref="VariantBuilder"/>) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// <see cref="VariantBuilder.End"/>.
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe GISharp.Lib.GLib.Variant End()
        {
            var builder_ = Handle;
            var ret_ = g_variant_builder_end(builder_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called. @type
        /// is the type of the container: so to build a tuple of several values, @type
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_open(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr type);

        /// <summary>
        /// Opens a subcontainer inside the given <paramref name="builder"/>.  When done adding
        /// items to the subcontainer, <see cref="VariantBuilder.Close"/> must be called. <paramref name="type"/>
        /// is the type of the container: so to build a tuple of several values, <paramref name="type"/>
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Open(GISharp.Lib.GLib.VariantType type)
        {
            var builder_ = Handle;
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            g_variant_builder_open(builder_, type_);
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_builder_ref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);
        public override System.IntPtr Take() => g_variant_builder_ref(Handle);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_unref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr builder);
    }
}