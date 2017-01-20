using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// #GVariantIter is an opaque data structure and can only be accessed
    /// using the following functions.
    /// </summary>
    public sealed class VariantIter : OwnedOpaque
    {
        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        ///
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_iter_copy (
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            IntPtr iter);

        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        ///
        /// A reference is taken to the container that @iter is iterating over
        /// and will be releated only when g_variant_iter_free() is called.
        /// </remarks>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [Since ("2.24")]
        public VariantIter Copy ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_iter_copy (Handle);
            var ret = Opaque.GetInstance<VariantIter> (ret_, Transfer.All);
            return ret;
        }

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        /// <param name="iter">
        /// a heap-allocated #GVariantIter
        /// </param>
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_iter_free (
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:full */
            IntPtr iter);

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        [Since ("2.24")]
        protected override void Free ()
        {
            AssertNotDisposed ();
            g_variant_iter_free (Handle);
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
            IntPtr iter,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            IntPtr value);

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
            var value_ = value == null ? IntPtr.Zero : value.Handle;
            var ret = g_variant_iter_init (Handle, value_);
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
            IntPtr iter);

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
        public ulong NChildren ()
        {
            AssertNotDisposed ();
            var ret = g_variant_iter_n_children (Handle);
            return ret;
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
            IntPtr iter);

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
        public Variant NextValue ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_iter_next_value (Handle);
            var ret = Opaque.GetInstance<Variant> (ret_, Transfer.All);
            return ret;
        }

        VariantIter (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
