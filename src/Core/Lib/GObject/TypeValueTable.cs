// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The <see cref="TypeValueTable"/> provides the functions required by the <see cref="Value"/>
    /// implementation, to serve as a container for values of a type.
    /// </summary>
    public sealed class TypeValueTable : Opaque
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeValueTable(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// The unmanaged data structure for <see cref="TypeValueTable"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe struct UnmanagedStruct
        {
            #pragma warning disable CS0649

            /// <summary>
            /// Default initialize @values contents by poking values directly
            /// into the <c>value-&gt;data</c> array.
            /// </summary>
            /// <remarks>
            /// The data array of the #GValue passed into this function was
            /// zero-filled with memset(), so no care has to be taken to free
            /// any old contents. E.g. for the implementation of a string value
            /// that may never be NULL, the implementation might look like:
            ///
            ///     value->data[0].v_pointer = g_strdup ("");
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, void> ValueInit;

            /// <summary>
            /// Free any old contents that might be left in the data array of
            /// the passed in @value.
            /// </summary>
            /// <remarks>
            /// No resources may remain allocated through the #GValue contents
            /// after this function returns. E.g. for our above string type:
            ///
            ///     // only free strings without a specific flag for static storage
            ///     if (!(value->data[1].v_uint &amp; G_VALUE_NOCOPY_CONTENTS))
            ///         g_free (value->data[0].v_pointer);
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, void> ValueFree;

            /// <summary>
            /// @dest_value is a #GValue with zero-filled data section and
            /// @src_value is a properly setup #GValue of same or derived type.
            /// </summary>
            /// <remarks>
            /// The purpose of this function is to copy the contents of @src_value
            /// into @dest_value in a way, that even after @src_value has been
            /// freed, the contents of @dest_value remain valid. String type example:
            ///
            ///     dest_value->data[0].v_pointer = g_strdup (src_value->data[0].v_pointer);
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, Value*, void> ValueCopy;

            /* varargs functionality (optional) */

            /// <summary>
            /// If the value contents fit into a pointer, such as objects or
            /// strings, return this pointer, so the caller can peek at the
            /// current contents.
            /// </summary>
            /// <remarks>
            /// To extend on our above string example:
            ///
            ///     return value->data[0].v_pointer;
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, IntPtr> ValuePeekPointer;

            /// <summary>
            /// A string format describing how to collect the contents of
            /// this value bit-by-bit.
            /// </summary>
            /// <remarks>
            /// Each character in the format represents
            ///  an argument to be collected, and the characters themselves indicate
            ///  the type of the argument. Currently supported arguments are:
            ///  - 'i' - Integers. passed as collect_values[].v_int.
            ///  - 'l' - Longs. passed as collect_values[].v_long.
            ///  - 'd' - Doubles. passed as collect_values[].v_double.
            ///  - 'p' - Pointers. passed as collect_values[].v_pointer.
            ///  It should be noted that for variable argument list construction,
            ///  ANSI C promotes every type smaller than an integer to an int, and
            ///  floats to doubles. So for collection of short int or char, 'i'
            ///  needs to be used, and for collection of floats 'd'.
            /// </remarks>
            public IntPtr CollectFormat;

            /// <summary>
            /// The collect_value() function is responsible for converting the
            /// values collected from a variable argument list into contents
            /// suitable for storage in a #GValue.
            /// </summary>
            /// <remarks>
            /// This function should setup value similar to value_init(); e.g.
            /// for a string value that does not allow NULL pointers, it needs
            /// to either spew an error, or do an implicit conversion by storing
            /// an empty string. The value passed in to this function has a
            /// zero-filled data array, so just like for value_init() it is
            /// guaranteed to not contain any old contents that might need
            /// freeing. n_collect_values is exactly the string length of
            /// collect_format , and collect_values is an array of unions
            /// GTypeCValue with length n_collect_values , containing the
            /// collected values according to collect_format . collect_flags
            /// is an argument provided as a hint by the caller. It may contain
            /// the flag G_VALUE_NOCOPY_CONTENTS indicating, that the collected
            /// value contents may be considered "static" for the duration of
            /// the value lifetime. Thus an extra copy of the contents stored
            /// in collect_values is not required for assignment to value . For
            /// our above string example, we continue with:
            ///
            ///     if (!collect_values[0].v_pointer)
            ///         value->data[0].v_pointer = g_strdup ("");
            ///     else if (collect_flags &amp; G_VALUE_NOCOPY_CONTENTS)
            ///     {
            ///         value->data[0].v_pointer = collect_values[0].v_pointer;
            ///         // keep a flag for the value_free() implementation to not free this string
            ///         value->data[1].v_uint = G_VALUE_NOCOPY_CONTENTS;
            ///     }
            ///     else
            ///         value->data[0].v_pointer = g_strdup (collect_values[0].v_pointer);
            ///     return NULL;
            ///
            /// It should be noted, that it is generally a bad idea to follow
            /// the G_VALUE_NOCOPY_CONTENTS hint for reference counted types.
            /// Due to reentrancy requirements and reference count assertions
            /// performed by the signal emission code, reference counts should
            /// always be incremented for reference counted contents stored in
            /// the value->data array. To deviate from our string example for a
            /// moment, and taking a look at an exemplary implementation for
            /// collect_value() of GObject:
            ///
            ///     GObject *object = G_OBJECT (collect_values[0].v_pointer);
            ///     g_return_val_if_fail (object != NULL,
            ///     g_strdup_printf ("Object passed as invalid NULL pointer"));
            ///     // never honour G_VALUE_NOCOPY_CONTENTS for ref-counted types
            ///     value->data[0].v_pointer = g_object_ref (object);
            ///     return NULL;
            ///
            /// The reference count for valid objects is always incremented,
            /// regardless of collect_flags . For invalid objects, the example
            /// returns a newly allocated string without altering value . Upon
            /// success, collect_value() needs to return NULL. If, however, an
            /// error condition occurred, collect_value() may spew an error by
            /// returning a newly allocated non-NULL string, giving a suitable
            /// description of the error condition. The calling code makes no
            /// assumptions about the value contents being valid upon error
            /// returns, value is simply thrown away without further freeing.
            /// As such, it is a good idea to not allocate GValue contents,
            /// prior to returning an error, however, collect_values() is not
            /// obliged to return a correctly setup value for error returns,
            /// simply because any non-NULL return is considered a fatal
            /// condition so further program behavior is undefined.
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, uint, IntPtr, uint, IntPtr> CollectValue;

            /// <summary>
            /// Format description of the arguments to collect for @lcopy_value,
            /// analogous to @collect_format. Usually, @lcopy_format string consists
            /// only of 'p's to provide lcopy_value() with pointers to storage locations.
            /// </summary>
            public IntPtr LcopyFormat;

            /// <summary>
            /// This function is responsible for storing the value contents
            /// into arguments passed through a variable argument list which
            /// got collected into collect_values according to lcopy_format.
            /// </summary>
            /// <remarks>
            /// n_collect_values equals the string length of lcopy_format, and
            /// collect_flags may contain G_VALUE_NOCOPY_CONTENTS. In contrast
            /// to collect_value(), lcopy_value() is obliged to always properly
            /// support G_VALUE_NOCOPY_CONTENTS. Similar to collect_value() the
            /// function may prematurely abort by returning a newly allocated
            /// string describing an error condition. To complete the string
            /// example:
            ///
            ///     gchar **string_p = collect_values[0].v_pointer;
            ///     g_return_val_if_fail (string_p != NULL,
            ///     g_strdup_printf ("string location passed as NULL"));
            ///     if (collect_flags &amp; G_VALUE_NOCOPY_CONTENTS)
            ///         *string_p = value->data[0].v_pointer;
            ///     else
            ///         *string_p = g_strdup (value->data[0].v_pointer);
            ///
            /// And an illustrative version of lcopy_value() for reference-counted types:
            ///
            ///     GObject **object_p = collect_values[0].v_pointer;
            ///     g_return_val_if_fail (object_p != NULL,
            ///     g_strdup_printf ("object location passed as NULL"));
            ///     if (!value->data[0].v_pointer)
            ///         *object_p = NULL;
            ///     else if (collect_flags &amp; G_VALUE_NOCOPY_CONTENTS) // always honour
            ///         *object_p = value->data[0].v_pointer;
            ///     else
            ///         *object_p = g_object_ref (value->data[0].v_pointer);
            ///     return NULL;
            /// </remarks>
            public delegate* unmanaged[Cdecl] <Value*, uint, IntPtr, uint, IntPtr> LcopyValue;

            #pragma warning restore CS0649
        }

        /// <summary>
        /// Returns the location of the #GTypeValueTable associated with @type.
        /// </summary>
        /// <remarks>
        /// Note that this function should only be used from source code
        /// that implements or has internal knowledge of the implementation of
        /// @type.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// location of the #GTypeValueTable associated with @type or
        ///     %NULL if there is no #GTypeValueTable associated with @type
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" /> */
        /* */
        static extern IntPtr g_type_value_table_peek(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the <see cref="TypeValueTable"/> associated with <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// Note that this function should only be used from source code
        /// that implements or has internal knowledge of the implementation of
        /// <paramref name="type"/>.
        /// </remarks>
        /// <param name="type">
        /// a <see cref="GType"/>
        /// </param>
        /// <returns>
        /// the <see cref="TypeValueTable"/> associated with <paramref name="type"/> or
        /// <c>null</c> if there is no <see cref="TypeValueTable"/> associated with <paramref name="type"/>
        /// </returns>
        public static TypeValueTable Peek(GType type)
        {
            var ret_ = g_type_value_table_peek(type);
            var ret = GetInstance<TypeValueTable>(ret_, Transfer.None);
            return ret;
        }
    }
}
