// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="VariantIter.xmldoc" path="declaration/member[@name='VariantIter']/*" />
    public sealed unsafe partial class VariantIter : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X0']/*" />
            internal readonly nuint X0;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X1']/*" />
            internal readonly nuint X1;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X2']/*" />
            internal readonly nuint X2;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X3']/*" />
            internal readonly nuint X3;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X4']/*" />
            internal readonly nuint X4;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X5']/*" />
            internal readonly nuint X5;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X6']/*" />
            internal readonly nuint X6;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X7']/*" />
            internal readonly nuint X7;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X8']/*" />
            internal readonly nuint X8;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X9']/*" />
            internal readonly nuint X9;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X10']/*" />
            internal readonly nuint X10;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X11']/*" />
            internal readonly nuint X11;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X12']/*" />
            internal readonly nuint X12;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X13']/*" />
            internal readonly nuint X13;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X14']/*" />
            internal readonly nuint X14;

            /// <include file="VariantIter.xmldoc" path="declaration/member[@name='UnmanagedStruct.X15']/*" />
            internal readonly nuint X15;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <include file="VariantIter.xmldoc" path="declaration/member[@name='VariantIter.Count']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public int Count { get => GetCount(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantIter(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_variant_iter_copy((UnmanagedStruct*)handle);
            }
        }

        /// <summary>
        /// Creates a heap-allocated #GVariantIter for iterating over the items
        /// in @value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// </para>
        /// <para>
        /// A reference is taken to @value and will be released only when
        /// g_variant_iter_free() is called.
        /// </para>
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantIter.UnmanagedStruct* g_variant_iter_new(
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        static partial void CheckNewArgs(GISharp.Lib.GLib.Variant value);

        [GISharp.Runtime.SinceAttribute("2.24")]
        static GISharp.Lib.GLib.VariantIter.UnmanagedStruct* New(GISharp.Lib.GLib.Variant value)
        {
            CheckNewArgs(value);
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
            var ret_ = g_variant_iter_new(value_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="VariantIter.xmldoc" path="declaration/member[@name='VariantIter.VariantIter(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.24")]
        public VariantIter(GISharp.Lib.GLib.Variant value) : this((System.IntPtr)New(value), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new heap-allocated #GVariantIter to iterate over the
        /// container that was being iterated over by @iter.  Iteration begins on
        /// the new iterator from the current position of the old iterator but
        /// the two copies are independent past that point.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use g_variant_iter_free() to free the return value when you no longer
        /// need it.
        /// </para>
        /// <para>
        /// A reference is taken to the container that @iter is iterating over
        /// and will be related only when g_variant_iter_free() is called.
        /// </para>
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a new heap-allocated #GVariantIter
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.VariantIter.UnmanagedStruct* g_variant_iter_copy(
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantIter.UnmanagedStruct* iter);

        /// <summary>
        /// Frees a heap-allocated #GVariantIter.  Only call this function on
        /// iterators that were returned by g_variant_iter_new() or
        /// g_variant_iter_copy().
        /// </summary>
        /// <param name="iter">
        /// a heap-allocated #GVariantIter
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_variant_iter_free(
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.VariantIter.UnmanagedStruct* iter);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_variant_iter_free((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialises (without allocating) a #GVariantIter.  @iter may be
        /// completely uninitialised prior to this call; its old value is
        /// ignored.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The iterator remains valid for as long as @value exists, and need not
        /// be freed in any way.
        /// </para>
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
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_variant_iter_init(
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantIter.UnmanagedStruct* iter,
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);

        /// <summary>
        /// Queries the number of child items in the container that we are
        /// iterating over.  This is the total number of items -- not the number
        /// of items remaining.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function might be useful for preallocation of arrays.
        /// </para>
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_variant_iter_n_children(
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantIter.UnmanagedStruct* iter);
        partial void CheckGetCountArgs();

        [GISharp.Runtime.SinceAttribute("2.24")]
        private int GetCount()
        {
            CheckGetCountArgs();
            var iter_ = (GISharp.Lib.GLib.VariantIter.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_iter_n_children(iter_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the next item in the container.  If no more items remain then
        /// %NULL is returned.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use g_variant_unref() to drop your reference on the return value when
        /// you no longer need it.
        /// </para>
        /// <para>
        /// Here is an example for iterating with g_variant_iter_next_value():
        /// |[&lt;!-- language="C" --&gt;
        ///   // recursively iterate a container
        ///   void
        ///   iterate_container_recursive (GVariant *container)
        ///   {
        ///     GVariantIter iter;
        ///     GVariant *child;
        /// </para>
        /// <para>
        ///     g_variant_iter_init (&amp;iter, container);
        ///     while ((child = g_variant_iter_next_value (&amp;iter)))
        ///       {
        ///         g_print ("type '%s'\n", g_variant_get_type_string (child));
        /// </para>
        /// <para>
        ///         if (g_variant_is_container (child))
        ///           iterate_container_recursive (child);
        /// </para>
        /// <para>
        ///         g_variant_unref (child);
        ///       }
        ///   }
        /// ]|
        /// </para>
        /// </remarks>
        /// <param name="iter">
        /// a #GVariantIter
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_variant_iter_next_value(
        /* <type name="VariantIter" type="GVariantIter*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.VariantIter.UnmanagedStruct* iter);
        partial void CheckNextValueArgs();

        [GISharp.Runtime.SinceAttribute("2.24")]
        private GISharp.Lib.GLib.Variant? NextValue()
        {
            CheckNextValueArgs();
            var iter_ = (GISharp.Lib.GLib.VariantIter.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_iter_next_value(iter_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}