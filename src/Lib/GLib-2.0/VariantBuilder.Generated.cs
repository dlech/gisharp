// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder']/*" />
    [GISharp.Runtime.GTypeAttribute("GVariantBuilder", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class VariantBuilder : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Runtime.GType _GType = g_variant_builder_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantBuilder(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_variant_builder_ref((UnmanagedStruct*)handle);
            }
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// </para>
        /// <para>
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </para>
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* g_variant_builder_new(
        /* <type name="VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantType.UnmanagedStruct* type);
        static partial void CheckNewArgs(GISharp.Lib.GLib.VariantType type);

        [GISharp.Runtime.SinceAttribute("2.24")]
        static GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* New(GISharp.Lib.GLib.VariantType type)
        {
            CheckNewArgs(type);
            var type_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)type.UnsafeHandle;
            var ret_ = g_variant_builder_new(type_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder.VariantBuilder(GISharp.Lib.GLib.VariantType)']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public VariantBuilder(GISharp.Lib.GLib.VariantType type) : this((System.IntPtr)New(type), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_variant_builder_get_type();

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// </para>
        /// <para>
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_builder_add_value(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder,
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        partial void CheckAddArgs(GISharp.Lib.GLib.Variant value);

        /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder.Add(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Add(GISharp.Lib.GLib.Variant value)
        {
            CheckAddArgs(value);
            var builder_ = (GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct*)UnsafeHandle;
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
            g_variant_builder_add_value(builder_, value_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_builder_close(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder);
        partial void CheckCloseArgs();

        /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder.Close()']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Close()
        {
            CheckCloseArgs();
            var builder_ = (GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct*)UnsafeHandle;
            g_variant_builder_close(builder_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// g_variant_builder_end().
        /// </para>
        /// <para>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_variant_builder_end(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder);
        partial void CheckEndArgs();

        /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder.End()']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public GISharp.Lib.GLib.Variant End()
        {
            CheckEndArgs();
            var builder_ = (GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_builder_end(builder_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called. @type
        /// is the type of the container: so to build a tuple of several values, @type
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// </para>
        /// <para>
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// </para>
        /// <para>
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// </para>
        /// <para>
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// </para>
        /// <para>
        /// g_variant_builder_close (&amp;builder);
        /// </para>
        /// <para>
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_builder_open(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder,
        /* <type name="VariantType" type="const GVariantType*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantType.UnmanagedStruct* type);
        partial void CheckOpenArgs(GISharp.Lib.GLib.VariantType type);

        /// <include file="VariantBuilder.xmldoc" path="declaration/member[@name='VariantBuilder.Open(GISharp.Lib.GLib.VariantType)']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Open(GISharp.Lib.GLib.VariantType type)
        {
            CheckOpenArgs(type);
            var builder_ = (GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct*)UnsafeHandle;
            var type_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)type.UnsafeHandle;
            g_variant_builder_open(builder_, type_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* g_variant_builder_ref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_variant_builder_ref((GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// </para>
        /// <para>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </para>
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_builder_unref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.VariantBuilder.UnmanagedStruct* builder);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_variant_builder_unref((UnmanagedStruct*)handle);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            base.Dispose(disposing);
        }
    }
}