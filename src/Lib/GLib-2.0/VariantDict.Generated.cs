// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict']/*" />
    [GISharp.Runtime.SinceAttribute("2.40")]
    [GISharp.Runtime.GTypeAttribute("GVariantDict", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class VariantDict : GISharp.Lib.GObject.Boxed
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_variant_dict_get_type();

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
        public VariantDict(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_variant_dict_ref((UnmanagedStruct*)handle);
            }
        }

        static partial void CheckNewArgs(GISharp.Lib.GLib.Variant? fromAsv);

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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantDict.UnmanagedStruct* g_variant_dict_new(
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* fromAsv);

        [GISharp.Runtime.SinceAttribute("2.40")]
        static GISharp.Lib.GLib.VariantDict.UnmanagedStruct* New(GISharp.Lib.GLib.Variant? fromAsv)
        {
            CheckNewArgs(fromAsv);
            var fromAsv_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)(fromAsv?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_variant_dict_new(fromAsv_);
            return ret_;
        }

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.VariantDict(GISharp.Lib.GLib.Variant?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public VariantDict(GISharp.Lib.GLib.Variant? fromAsv) : this((System.IntPtr)New(fromAsv), GISharp.Runtime.Transfer.Full)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_variant_dict_get_type();

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to look up in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_variant_dict_contains(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* key);
        partial void CheckContainsArgs(GISharp.Lib.GLib.UnownedUtf8 key);

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.Contains(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public System.Boolean Contains(GISharp.Lib.GLib.UnownedUtf8 key)
        {
            CheckContainsArgs(key);
            var dict_ = (GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle;
            var key_ = (System.Byte*)key.UnsafeHandle;
            var ret_ = g_variant_dict_contains(dict_,key_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_variant_dict_end(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict);
        partial void CheckEndArgs();

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.End()']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public GISharp.Lib.GLib.Variant End()
        {
            CheckEndArgs();
            var dict_ = (GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_dict_end(dict_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
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
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_dict_insert_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* key,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        partial void CheckInsertArgs(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.Variant value);

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.Insert(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public void Insert(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.Variant value)
        {
            CheckInsertArgs(key, value);
            var dict_ = (GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle;
            var key_ = (System.Byte*)key.UnsafeHandle;
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
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
        /// the key to look up in the dictionary
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_variant_dict_lookup_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* key,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.VariantType.UnmanagedStruct* expectedType);
        partial void CheckLookupArgs(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.VariantType? expectedType = null);

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.Lookup(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.VariantType?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public GISharp.Lib.GLib.Variant Lookup(GISharp.Lib.GLib.UnownedUtf8 key, GISharp.Lib.GLib.VariantType? expectedType = null)
        {
            CheckLookupArgs(key, expectedType);
            var dict_ = (GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle;
            var key_ = (System.Byte*)key.UnsafeHandle;
            var expectedType_ = (GISharp.Lib.GLib.VariantType.UnmanagedStruct*)(expectedType?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_variant_dict_lookup_value(dict_,key_,expectedType_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantDict.UnmanagedStruct* g_variant_dict_ref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_variant_dict_ref((GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle);

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
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_variant_dict_remove(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* key);
        partial void CheckRemoveArgs(GISharp.Lib.GLib.UnownedUtf8 key);

        /// <include file="VariantDict.xmldoc" path="declaration/member[@name='VariantDict.Remove(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public System.Boolean Remove(GISharp.Lib.GLib.UnownedUtf8 key)
        {
            CheckRemoveArgs(key);
            var dict_ = (GISharp.Lib.GLib.VariantDict.UnmanagedStruct*)UnsafeHandle;
            var key_ = (System.Byte*)key.UnsafeHandle;
            var ret_ = g_variant_dict_remove(dict_,key_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_dict_unref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.VariantDict.UnmanagedStruct* dict);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_variant_dict_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }
    }
}