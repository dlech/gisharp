using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// #GVariantIter is an opaque data structure and can only be accessed
    /// using the following functions.
    /// </summary>
    public sealed class VariantIter : Opaque, IEnumerator<Variant>
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_variant_iter_copy(IntPtr iter);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public VariantIter(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (ownership == Transfer.None) {
                this.handle = g_variant_iter_copy(handle);
            }
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_variant_iter_free(IntPtr iter);

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_variant_iter_free(handle);
            }
            base.Dispose(disposing);
        }

        readonly Variant? value;
        Variant? current;

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_variant_iter_new(IntPtr value);

        static IntPtr New(Variant value)
        {
            if (!value.IsContainer) {
                throw new ArgumentException("must be a container", nameof(value));
            }
            var ret = g_variant_iter_new(value.Handle);
            return ret;
        }

        /// <summary>
        /// Creates a <see cref="T:VariantIter"/> for iterating over the items in <paramref name="value"/>.
        /// </summary>
        /// <param name="value">a container <see cref="T:Variant"/>.</param>
        /// <exception cref="ArgumentException">
        /// if <paramref name="value"/> is not a container type
        /// </exception>
        public VariantIter(Variant value) : this(New(value), Transfer.Full)
        {
            this.value = value;
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
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.SysUInt)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern UIntPtr g_variant_iter_init(
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            IntPtr iter,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            IntPtr value);

        [ExcludeFromCodeCoverage]
        void IEnumerator.Reset()
        {
            if (value == null) {
                throw new InvalidOperationException("Initial value is unknown.");
            }
            g_variant_iter_init(Handle, value.Handle);
            current = null;
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
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern UIntPtr g_variant_iter_n_children(
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            IntPtr iter);

        /// <summary>
        /// Gets the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// This function might be useful for preallocation of arrays.
        /// </remarks>
        /// <value>
        /// the number of children in the container
        /// </value>
        [Since("2.24")]
        public int Count {
            get {
                var ret = g_variant_iter_n_children(Handle);
                return (int)ret;
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
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_iter_next_value(
            /* <type name="VariantIter" type="GVariantIter*" managed-name="VariantIter" /> */
            /* transfer-ownership:none */
            IntPtr iter);

        public bool MoveNext()
        {
            var ret_ = g_variant_iter_next_value(Handle);
            if (ret_ == IntPtr.Zero) {
                current = null;
                return false;
            }
            current = GetInstance<Variant>(ret_, Transfer.Full);
            return true;
        }

        public Variant Current => current ?? throw new InvalidOperationException();

        object IEnumerator.Current => Current;
    }
}
