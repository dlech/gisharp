using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// #GVariantIter is an opaque data structure and can only be accessed
    /// using the following functions.
    /// </summary>
    public sealed class VariantIter : Opaque
    {
        public sealed class SafeVariantIterHandle : SafeOpaqueHandle
        {
            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr g_variant_iter_copy (IntPtr iter);

            public SafeVariantIterHandle (IntPtr handle, Transfer ownership)
            {
                if (ownership == Transfer.None) {
                    handle = g_variant_iter_copy (handle);
                }
                SetHandle (handle);
            }

            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern void g_variant_iter_free (IntPtr iter);

            protected override bool ReleaseHandle ()
            {
                try {
                    g_variant_iter_free (handle);
                    return true;
                } catch {
                    return false;
                }
            }
        }

        public new SafeVariantIterHandle Handle {
             get {
                 return (SafeVariantIterHandle)base.Handle;
             }
        }

        public VariantIter (SafeVariantIterHandle handle) : base (handle)
        {
        }

        /// <summary>
        /// Creates a new <see cref="VariantIter" /> to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// A reference is taken to the container that this is iterating over
        /// and will be released only when <see cref="Dispose" /> is called.
        /// </remarks>
        /// <returns>
        /// a new <see cref="VariantIter" />
        /// </returns>
        [Since ("2.24")]
        public VariantIter Copy ()
        {
            AssertNotDisposed ();
            var ret_ = new SafeVariantIterHandle (Handle.DangerousGetHandle (), Transfer.None);
            var ret = new VariantIter (ret_);
            return ret;
        }

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="iter">
        /// a pointer to a #GVariantIter
        /// </param>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern ulong g_variant_iter_init (
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            SafeVariantIterHandle iter,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            Variant.SafeVariantHandle value);

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of items in @value
        /// </returns>
        [Since ("2.24")]
        public ulong Init (Variant value)
        {
            AssertNotDisposed ();
            if (value == null) {
                throw new ArgumentNullException (nameof(value));
            }
            var ret = g_variant_iter_init (Handle, value.Handle);
            return ret;
        }

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern ulong g_variant_iter_n_children (
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            SafeVariantIterHandle iter);

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [Since ("2.24")]
        public ulong NChildren {
            get {
                AssertNotDisposed ();
                var ret = g_variant_iter_n_children (Handle);
                return ret;
            }
        }

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        ///
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        ///
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        ///
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        ///
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_iter_next_value (
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            SafeVariantIterHandle iter);

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        ///
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        ///
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        ///
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        ///
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </remarks>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [Since ("2.24")]
        public Variant NextValue {
            get {
                AssertNotDisposed ();
                var ret_ = g_variant_iter_next_value (Handle);
                var ret = GetInstance<Variant> (ret_, Transfer.Full);
                return ret;
            }
        }
    }
}
