// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections;

using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// #GVariant is a variant datatype; it stores a value along with
    /// information about the type of that value.  The range of possible
    /// values is determined by the type.  The type system used by #GVariant
    /// is #GVariantType.
    /// </summary>
    /// <remarks>
    /// #GVariant instances always have a type and a value (which are given
    /// at construction time).  The type and value of a #GVariant instance
    /// can never change other than by the #GVariant itself being
    /// destroyed.  A #GVariant cannot contain a pointer.
    ///
    /// #GVariant is reference counted using g_variant_ref() and
    /// g_variant_unref().  #GVariant also has floating reference counts --
    /// see g_variant_ref_sink().
    ///
    /// #GVariant is completely threadsafe.  A #GVariant instance can be
    /// concurrently accessed in any way from any number of threads without
    /// problems.
    ///
    /// #GVariant is heavily optimised for dealing with data in serialised
    /// form.  It works particularly well with data located in memory-mapped
    /// files.  It can perform nearly all deserialisation operations in a
    /// small constant time, usually touching only a single memory page.
    /// Serialised #GVariant data can also be sent over the network.
    ///
    /// #GVariant is largely compatible with D-Bus.  Almost all types of
    /// #GVariant instances can be sent over D-Bus.  See #GVariantType for
    /// exceptions.  (However, #GVariant's serialisation format is not the same
    /// as the serialisation format of a D-Bus message body: use #GDBusMessage,
    /// in the gio library, for those.)
    ///
    /// For space-efficiency, the #GVariant serialisation format does not
    /// automatically include the variant's length, type or endianness,
    /// which must either be implied from context (such as knowledge that a
    /// particular file format always contains a little-endian
    /// %G_VARIANT_TYPE_VARIANT which occupies the whole length of the file)
    /// or supplied out-of-band (for instance, a length, type and/or endianness
    /// indicator could be placed at the beginning of a file, network message
    /// or network stream).
    ///
    /// A #GVariant's size is limited mainly by any lower level operating
    /// system constraints, such as the number of bits in #gsize.  For
    /// example, it is reasonable to have a 2GB file mapped into memory
    /// with #GMappedFile, and call g_variant_new_from_data() on it.
    ///
    /// For convenience to C programmers, #GVariant features powerful
    /// varargs-based value construction and destruction.  This feature is
    /// designed to be embedded in other libraries.
    ///
    /// There is a Python-inspired text language for describing #GVariant
    /// values.  #GVariant includes a printer for this language and a parser
    /// with type inferencing.
    ///
    /// ## Memory Use
    ///
    /// #GVariant tries to be quite efficient with respect to memory use.
    /// This section gives a rough idea of how much memory is used by the
    /// current implementation.  The information here is subject to change
    /// in the future.
    ///
    /// The memory allocated by #GVariant can be grouped into 4 broad
    /// purposes: memory for serialised data, memory for the type
    /// information cache, buffer management memory and memory for the
    /// #GVariant structure itself.
    ///
    /// ## Serialised Data Memory
    ///
    /// This is the memory that is used for storing GVariant data in
    /// serialised form.  This is what would be sent over the network or
    /// what would end up on disk, not counting any indicator of the
    /// endianness, or of the length or type of the top-level variant.
    ///
    /// The amount of memory required to store a boolean is 1 byte. 16,
    /// 32 and 64 bit integers and double precision floating point numbers
    /// use their "natural" size.  Strings (including object path and
    /// signature strings) are stored with a nul terminator, and as such
    /// use the length of the string plus 1 byte.
    ///
    /// Maybe types use no space at all to represent the null value and
    /// use the same amount of space (sometimes plus one byte) as the
    /// equivalent non-maybe-typed value to represent the non-null case.
    ///
    /// Arrays use the amount of space required to store each of their
    /// members, concatenated.  Additionally, if the items stored in an
    /// array are not of a fixed-size (ie: strings, other arrays, etc)
    /// then an additional framing offset is stored for each item.  The
    /// size of this offset is either 1, 2 or 4 bytes depending on the
    /// overall size of the container.  Additionally, extra padding bytes
    /// are added as required for alignment of child values.
    ///
    /// Tuples (including dictionary entries) use the amount of space
    /// required to store each of their members, concatenated, plus one
    /// framing offset (as per arrays) for each non-fixed-sized item in
    /// the tuple, except for the last one.  Additionally, extra padding
    /// bytes are added as required for alignment of child values.
    ///
    /// Variants use the same amount of space as the item inside of the
    /// variant, plus 1 byte, plus the length of the type string for the
    /// item inside the variant.
    ///
    /// As an example, consider a dictionary mapping strings to variants.
    /// In the case that the dictionary is empty, 0 bytes are required for
    /// the serialisation.
    ///
    /// If we add an item "width" that maps to the int32 value of 500 then
    /// we will use 4 byte to store the int32 (so 6 for the variant
    /// containing it) and 6 bytes for the string.  The variant must be
    /// aligned to 8 after the 6 bytes of the string, so that's 2 extra
    /// bytes.  6 (string) + 2 (padding) + 6 (variant) is 14 bytes used
    /// for the dictionary entry.  An additional 1 byte is added to the
    /// array as a framing offset making a total of 15 bytes.
    ///
    /// If we add another entry, "title" that maps to a nullable string
    /// that happens to have a value of null, then we use 0 bytes for the
    /// null value (and 3 bytes for the variant to contain it along with
    /// its type string) plus 6 bytes for the string.  Again, we need 2
    /// padding bytes.  That makes a total of 6 + 2 + 3 = 11 bytes.
    ///
    /// We now require extra padding between the two items in the array.
    /// After the 14 bytes of the first item, that's 2 bytes required.
    /// We now require 2 framing offsets for an extra two
    /// bytes. 14 + 2 + 11 + 2 = 29 bytes to encode the entire two-item
    /// dictionary.
    ///
    /// ## Type Information Cache
    ///
    /// For each GVariant type that currently exists in the program a type
    /// information structure is kept in the type information cache.  The
    /// type information structure is required for rapid deserialisation.
    ///
    /// Continuing with the above example, if a #GVariant exists with the
    /// type "a{sv}" then a type information struct will exist for
    /// "a{sv}", "{sv}", "s", and "v".  Multiple uses of the same type
    /// will share the same type information.  Additionally, all
    /// single-digit types are stored in read-only static memory and do
    /// not contribute to the writable memory footprint of a program using
    /// #GVariant.
    ///
    /// Aside from the type information structures stored in read-only
    /// memory, there are two forms of type information.  One is used for
    /// container types where there is a single element type: arrays and
    /// maybe types.  The other is used for container types where there
    /// are multiple element types: tuples and dictionary entries.
    ///
    /// Array type info structures are 6 * sizeof (void *), plus the
    /// memory required to store the type string itself.  This means that
    /// on 32-bit systems, the cache entry for "a{sv}" would require 30
    /// bytes of memory (plus malloc overhead).
    ///
    /// Tuple type info structures are 6 * sizeof (void *), plus 4 *
    /// sizeof (void *) for each item in the tuple, plus the memory
    /// required to store the type string itself.  A 2-item tuple, for
    /// example, would have a type information structure that consumed
    /// writable memory in the size of 14 * sizeof (void *) (plus type
    /// string)  This means that on 32-bit systems, the cache entry for
    /// "{sv}" would require 61 bytes of memory (plus malloc overhead).
    ///
    /// This means that in total, for our "a{sv}" example, 91 bytes of
    /// type information would be allocated.
    ///
    /// The type information cache, additionally, uses a #GHashTable to
    /// store and lookup the cached items and stores a pointer to this
    /// hash table in static storage.  The hash table is freed when there
    /// are zero items in the type cache.
    ///
    /// Although these sizes may seem large it is important to remember
    /// that a program will probably only have a very small number of
    /// different types of values in it and that only one type information
    /// structure is required for many different values of the same type.
    ///
    /// ## Buffer Management Memory
    ///
    /// #GVariant uses an internal buffer management structure to deal
    /// with the various different possible sources of serialised data
    /// that it uses.  The buffer is responsible for ensuring that the
    /// correct call is made when the data is no longer in use by
    /// #GVariant.  This may involve a g_free() or a g_slice_free() or
    /// even g_mapped_file_unref().
    ///
    /// One buffer management structure is used for each chunk of
    /// serialised data.  The size of the buffer management structure
    /// is 4 * (void *).  On 32-bit systems, that's 16 bytes.
    ///
    /// ## GVariant structure
    ///
    /// The size of a #GVariant structure is 6 * (void *).  On 32-bit
    /// systems, that's 24 bytes.
    ///
    /// #GVariant structures only exist if they are explicitly created
    /// with API calls.  For example, if a #GVariant is constructed out of
    /// serialised data for the example given above (with the dictionary)
    /// then although there are 9 individual values that comprise the
    /// entire dictionary (two keys, two values, two variants containing
    /// the values, two dictionary entries, plus the dictionary itself),
    /// only 1 #GVariant instance exists -- the one referring to the
    /// dictionary.
    ///
    /// If calls are made to start accessing the other values then
    /// #GVariant instances will exist for those values only for as long
    /// as they are in use (ie: until you call g_variant_unref()).  The
    /// type information is shared.  The serialised data and the buffer
    /// management structure for that serialised data is shared by the
    /// child.
    ///
    /// ## Summary
    ///
    /// To put the entire example together, for our dictionary mapping
    /// strings to variants (with two entries, as given above), we are
    /// using 91 bytes of memory for type information, 29 byes of memory
    /// for the serialised data, 16 bytes for buffer management and 24
    /// bytes for the #GVariant instance, or a total of 160 bytes, plus
    /// malloc overhead.  If we were to use g_variant_get_child_value() to
    /// access the two dictionary entries, we would use an additional 48
    /// bytes.  If we were to have other dictionaries of the same type, we
    /// would use more memory for the serialised data and buffer
    /// management for those dictionaries, but the type information would
    /// be shared.
    /// </remarks>
    [Since("2.24")]
    [GType("GVariant", IsProxyForUnmanagedType = true)]
    public sealed unsafe class Variant
        : Opaque, IEquatable<Variant>, IComparable<Variant>, IEnumerable<Variant>
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="Variant"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct UnmanagedStruct { }

        IndexedCollection<Variant>? childValues;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Variant(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                g_variant_ref_sink((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            else {
                g_variant_take_ref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_variant_unref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            base.Dispose(disposing);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_variant_ref(UnmanagedStruct* value);

        [PtrArrayCopyFunc]
        static IntPtr Copy(IntPtr value) => (IntPtr)g_variant_ref((UnmanagedStruct*)value);

        /// <inheritdoc/>
        public override IntPtr Take() => (IntPtr)g_variant_ref((UnmanagedStruct*)UnsafeHandle);

        [PtrArrayFreeFunc]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_variant_unref(UnmanagedStruct* value);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_variant_ref_sink(UnmanagedStruct* value);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UnmanagedStruct* g_variant_take_ref(UnmanagedStruct* value);

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_variant_is_floating(UnmanagedStruct* value);

        bool IsFloating => g_variant_is_floating((UnmanagedStruct*)UnsafeHandle).IsTrue();

        /// <summary>
        /// Reads a child item out of a container <see cref="Variant"/> instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// <see cref="Variant"/>.
        /// </summary>
        public IndexedCollection<Variant> ChildValues {
            get {
                if (childValues is null) {
                    if (!Type.IsContainer) {
                        throw new InvalidOperationException("Variant must be a container type");
                    }
                    childValues = new(NChildren, GetChildValue);
                }
                return childValues;
            }
        }

        // explicit cast operators

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="bool"/>.
        /// </summary>
        public static explicit operator bool(Variant value)
        {
            if (value.Type != VariantType.Boolean) {
                throw new InvalidCastException();
            }
            return value.Boolean;
        }

        /// <summary>
        /// Coverts <see cref="bool"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(bool value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="byte"/>.
        /// </summary>
        public static explicit operator byte(Variant v)
        {
            if (v.Type != VariantType.Byte) {
                throw new InvalidCastException();
            }
            return v.Byte;
        }

        /// <summary>
        /// Coverts <see cref="byte"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(byte value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="byte"/> array.
        /// </summary>
        public static explicit operator byte[](Variant v)
        {
            if (v.Type != VariantType.ByteString) {
                throw new InvalidCastException();
            }
            return v.Bytestring;
        }

        /// <summary>
        /// Coverts <see cref="byte"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(byte[] value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/>.
        /// </summary>
        public static explicit operator WeakZeroTerminatedCPtrArray<ByteString>?(Variant v)
        {
            if (v.Type != VariantType.ByteStringArray) {
                throw new InvalidCastException();
            }
            return v.GetBytestringArray();
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="ByteStringArray"/>.
        /// </summary>
        public static explicit operator ByteStringArray?(Variant v)
        {
            if (v.Type != VariantType.ByteStringArray) {
                throw new InvalidCastException();
            }
            return v.DupBytestringArray();
        }

        /// <summary>
        /// Coverts <see cref="ByteStringArray"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ByteStringArray value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(WeakZeroTerminatedCPtrArray<ByteString> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="UnownedZeroTerminatedCPtrArray{T}"/> of <see cref="ByteString"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(UnownedZeroTerminatedCPtrArray<ByteString> value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="double"/>.
        /// </summary>
        public static explicit operator double(Variant v)
        {
            if (v.Type != VariantType.Double) {
                throw new InvalidCastException();
            }
            return v.Double;
        }

        /// <summary>
        /// Coverts <see cref="double"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(double value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusHandle"/>.
        /// </summary>

        public static explicit operator DBusHandle(Variant v)
        {
            if (v.Type != VariantType.DBusHandle) {
                throw new InvalidCastException();
            }
            return v.DBusHandle;
        }

        /// <summary>
        /// Coverts <see cref="DBusHandle"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusHandle value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="short"/>.
        /// </summary>
        public static explicit operator short(Variant v)
        {
            if (v.Type != VariantType.Int16) {
                throw new InvalidCastException();
            }
            return v.Int16;
        }

        /// <summary>
        /// Coverts <see cref="short"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(short value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="int"/>.
        /// </summary>
        public static explicit operator int(Variant v)
        {
            if (v.Type != VariantType.Int32) {
                throw new InvalidCastException();
            }
            return v.Int32;
        }

        /// <summary>
        /// Coverts <see cref="int"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(int value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="long"/>.
        /// </summary>
        public static explicit operator long(Variant v)
        {
            if (v.Type != VariantType.Int64) {
                throw new InvalidCastException();
            }
            return v.Int64;
        }

        /// <summary>
        /// Coverts <see cref="long"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(long value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusObjectPath"/>.
        /// </summary>
        public static explicit operator DBusObjectPath(Variant v)
        {
            if (v.Type != VariantType.DBusObjectPath) {
                throw new InvalidCastException();
            }
            return (string)v.GetString();
        }

        /// <summary>
        /// Coverts <see cref="DBusObjectPath"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusObjectPath value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusSignature"/>.
        /// </summary>
        public static explicit operator DBusSignature(Variant v)
        {
            if (v.Type != VariantType.DBusSignature) {
                throw new InvalidCastException();
            }
            return (string)v.GetString();
        }

        /// <summary>
        /// Coverts <see cref="DBusSignature"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusSignature value)
        {
            return new Variant(value);
        }

        // TODO cast Maybe to nullable types

        /// <summary>
        /// Coverts <see cref="ValueTuple"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator ValueTuple(Variant value)
        {
            if (!value.IsOfType(VariantType.Unit)) {
                throw new InvalidCastException();
            }
            return default;
        }

        /// <summary>
        /// Coverts <see cref="ValueTuple"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ValueTuple value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="DBusObjectPath"/> array.
        /// </summary>
        public static explicit operator DBusObjectPath[](Variant v)
        {
            if (v.Type != VariantType.DBusObjectPathArray) {
                throw new InvalidCastException();
            }
            return v.Objv;
        }

        /// <summary>
        /// Coverts <see cref="DBusObjectPath"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(DBusObjectPath[] value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="string"/>.
        /// </summary>
        public static explicit operator string(Variant v)
        {
            if (v.Type != VariantType.String) {
                throw new InvalidCastException();
            }
            return v.GetString();
        }

        /// <summary>
        /// Coverts <see cref="string"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(string value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="WeakZeroTerminatedCPtrArray{T}"/> of <see cref="Utf8"/>.
        /// </summary>
        public static explicit operator WeakZeroTerminatedCPtrArray<Utf8>?(Variant v)
        {
            if (v.Type != VariantType.StringArray) {
                throw new InvalidCastException();
            }
            return v.Strv;
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="Strv"/>.
        /// </summary>
        public static explicit operator Strv?(Variant v)
        {
            if (v.Type != VariantType.StringArray) {
                throw new InvalidCastException();
            }
            return v.DupStrv();
        }

        /// <summary>
        /// Coverts <see cref="string"/> array to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(Strv value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="ushort"/>.
        /// </summary>
        public static explicit operator ushort(Variant v)
        {
            if (v.Type != VariantType.UInt16) {
                throw new InvalidCastException();
            }
            return v.Uint16;
        }

        /// <summary>
        /// Coverts <see cref="ushort"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ushort value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="uint"/>.
        /// </summary>
        public static explicit operator uint(Variant v)
        {
            if (v.Type != VariantType.UInt32) {
                throw new InvalidCastException();
            }
            return v.Uint32;
        }

        /// <summary>
        /// Coverts <see cref="uint"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(uint value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="ulong"/>.
        /// </summary>
        public static explicit operator ulong(Variant v)
        {
            if (v.Type != VariantType.UInt64) {
                throw new InvalidCastException();
            }
            return v.Uint64;
        }

        /// <summary>
        /// Coverts <see cref="ulong"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(ulong value)
        {
            return new Variant(value);
        }

        /// <summary>
        /// Coverts <see cref="Variant"/> to <see cref="KeyValuePair{K,V}"/>.
        /// </summary>
        public static explicit operator KeyValuePair<Variant, Variant>(Variant v)
        {
            if (!v.Type.IsDictionaryEntry) {
                throw new InvalidCastException();
            }
            return new KeyValuePair<Variant, Variant>(v.ChildValues[0], v.ChildValues[1]);
        }

        /// <summary>
        /// Coverts <see cref="KeyValuePair{K,V}"/> to <see cref="Variant"/>.
        /// </summary>
        public static explicit operator Variant(KeyValuePair<Variant, Variant> value)
        {
            return new Variant(value.Key, value.Value);
        }

        static void CheckNewArrayArgs(VariantType? childType, UnownedCPtrArray<Variant> children)
        {
            if (childType is null && (children.Data.Length == 0)) {
                throw new ArgumentException("Must specify child type when no children", nameof(childType));
            }
            if (childType is null && children.Data.Length == 0) {
                throw new ArgumentException("childType and children cannot both be null");
            }
            if (children.Data.Length != 0) {
                var testChildType = childType ?? children[0].Type;
                foreach (var item in children) {
                    if (item is null) {
                        throw new ArgumentException("Array cannot have null elements", nameof(children));
                    }
                    if (item.Type != testChildType) {
                        throw new ArgumentException("All children must have the same variant type.", nameof(children));
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        ///
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        ///
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_array(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            VariantType.UnmanagedStruct* childType,
            /* <array length="2" zero-terminated="0" type="GVariant**">
                <type name="Variant" type="GVariant*" managed-name="Variant" />
                </array> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            UnmanagedStruct** children,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint nChildren);

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        ///
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        ///
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant array
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewArray(VariantType? childType, UnownedCPtrArray<Variant> children)
        {
            CheckNewArrayArgs(childType, children);
            var childType_ = (VariantType.UnmanagedStruct*)(childType?.UnsafeHandle ?? IntPtr.Zero);
            fixed (IntPtr* childrenData_ = children.Data) {
                var children_ = (UnmanagedStruct**)childrenData_;
                var nChildren_ = (nuint)children.Data.Length;
                var ret = g_variant_new_array(childType_, children_, nChildren_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        ///
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        ///
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        [Since("2.24")]
        public Variant(VariantType? childType, UnownedCPtrArray<Variant> children)
            : this((IntPtr)NewArray(childType, children), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new #GVariant array from @children.
        /// </summary>
        /// <remarks>
        /// @child_type must be non-%NULL if @n_children is zero.  Otherwise, the
        /// child type is determined by inspecting the first element of the
        /// @children array.  If @child_type is non-%NULL then it must be a
        /// definite type.
        ///
        /// The items of the array are taken from the @children array.  No entry
        /// in the @children array may be %NULL.
        ///
        /// All items in the array must have the same type, which must be the
        /// same as @child_type, if given.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="childType">
        /// the element type of the new array
        /// </param>
        /// <param name="children">
        /// an array of
        ///            #GVariant pointers, the children
        /// </param>
        [Since("2.24")]
        public static Variant CreateArray(VariantType? childType, params Variant[] children)
        {
            return new Variant(childType, children.ToUnownedCPtrArray());
        }

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_boolean(
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean value);

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        /// <returns>
        /// a floating reference to a new boolean #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewBoolean(bool value)
        {
            var value_ = value.ToBoolean();
            var ret = g_variant_new_boolean(value_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new boolean #GVariant instance -- either %TRUE or %FALSE.
        /// </summary>
        /// <param name="value">
        /// a #gboolean value
        /// </param>
        [Since("2.24")]
        public Variant(bool value) : this((IntPtr)NewBoolean(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_byte(
            /* <type name="guint8" type="guchar" managed-name="Guint8" /> */
            /* transfer-ownership:none */
            byte value);

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        /// <returns>
        /// a floating reference to a new byte #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewByte(byte value)
        {
            var ret = g_variant_new_byte(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new byte #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint8 value
        /// </param>
        [Since("2.24")]
        public Variant(byte value) : this((IntPtr)NewByte(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid UTF-8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_bytestring(
            /* <array type="gchar*" zero-terminated="1">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none */
            byte* @string);

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid UTF-8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        /// <returns>
        /// a floating reference to a new bytestring #GVariant instance
        /// </returns>
        [Since("2.26")]
        static UnmanagedStruct* NewBytestring(byte[] @string)
        {
            var @string_ = (byte*)GMarshal.CArrayToPtr(@string, true);
            try {
                var ret = g_variant_new_bytestring(@string_);
                GMarshal.PopUnhandledException();
                return ret;
            }
            finally {
                GMarshal.Free((IntPtr)@string_);
            }
        }

        /// <summary>
        /// Creates an array-of-bytes #GVariant with the contents of @string.
        /// This function is just like g_variant_new_string() except that the
        /// string need not be valid UTF-8.
        /// </summary>
        /// <remarks>
        /// The nul terminator character at the end of the string is stored in
        /// the array.
        /// </remarks>
        /// <param name="string">
        /// a normal
        ///          nul-terminated string in no particular encoding
        /// </param>
        [Since("2.26")]
        public Variant(byte[] @string) : this((IntPtr)NewBytestring(@string), Transfer.None)
        {
        }

        /// <summary>
        /// Constructs an array of bytestring #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_bytestring_array(
            /* <array length="1" zero-terminated="0" type="gchar**">
                <type name="utf8" type="gchar*" managed-name="Utf8" />
                </array> */
            /* transfer-ownership:none */
            byte** strv,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            nint length);

        static UnmanagedStruct* NewBytestringArray(UnownedZeroTerminatedCPtrArray<ByteString> value)
        {
            var strv_ = (byte**)value.UnsafeHandle;
            var length_ = (nint)value.Length;
            var ret_ = g_variant_new_bytestring_array(strv_, length_);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Constructs an array of bytestring <see cref="Variant"/> from the given array of
        /// strings.
        /// </summary>
        public Variant(UnownedZeroTerminatedCPtrArray<ByteString> value) : this((IntPtr)NewBytestringArray(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_dict_entry(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* key,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        /// <returns>
        /// a floating reference to a new dictionary entry #GVariant
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewDictEntry(Variant key, Variant value)
        {
            var key_ = (UnmanagedStruct*)key.UnsafeHandle;
            var value_ = (UnmanagedStruct*)value.UnsafeHandle;
            if (!key.Type.IsBasic) {
                throw new ArgumentException("Key must be a basic variant type.", nameof(key));
            }
            var ret = g_variant_new_dict_entry(key_, value_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new dictionary entry #GVariant. @key and @value must be
        /// non-%NULL. @key must be a value of a basic type (ie: not a container).
        /// </summary>
        /// <remarks>
        /// If the @key or @value are floating references (see g_variant_ref_sink()),
        /// the new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariant, the key
        /// </param>
        /// <param name="value">
        /// a #GVariant, the value
        /// </param>
        [Since("2.24")]
        public Variant(Variant key, Variant value)
            : this((IntPtr)NewDictEntry(key, value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new dictionary entry <see cref="Variant"/>. <c>TKey</c>
        /// and <c>TValue</c> must be non-null. key must be a value of a basic
        /// type (ie: not a container).
        /// </summary>
        [Since("2.24")]
        public Variant(KeyValuePair<Variant, Variant> value)
            : this(value.Key, value.Value)
        {
        }

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_double(
            /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
            /* transfer-ownership:none */
            double value);

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        /// <returns>
        /// a floating reference to a new double #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewDouble(double value)
        {
            var ret = g_variant_new_double(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new double #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gdouble floating point value
        /// </param>
        [Since("2.24")]
        public Variant(double value) : this((IntPtr)NewDouble(value), Transfer.None)
        {
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        ///
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        ///
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <param name="nElements">
        /// the number of elements
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [Since("2.32")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_fixed_array(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            VariantType.UnmanagedStruct* elementType,
            /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            void* elements,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint nElements,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint elementSize);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size as are tuples containing only other fixed-sized types.
        ///
        /// @element_size must be the size of a single element in the array.
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        ///
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="elementType">
        /// the #GVariantType of each element
        /// </param>
        /// <param name="elements">
        /// a pointer to the fixed array of contiguous elements
        /// </param>
        /// <returns>
        /// a floating reference to a new array #GVariant instance
        /// </returns>
        [Since("2.32")]
        static Variant NewFixedArray<T>(VariantType elementType, T[] elements) where T : unmanaged
        {
            var gch = GCHandle.Alloc(elements, GCHandleType.Pinned);
            try {
                var elementType_ = (VariantType.UnmanagedStruct*)elementType.UnsafeHandle;
                var elements_ = (void*)gch.AddrOfPinnedObject();
                var nElements = (nuint)elements.Length;
                var elementSize = (nuint)sizeof(T);
                var ret = g_variant_new_fixed_array(elementType_, elements_, nElements, elementSize);
                GMarshal.PopUnhandledException();
                return new Variant((IntPtr)ret, Transfer.None);
            }
            finally {
                gch.Free();
            }
        }

        /// <summary>
        /// Creates a new #GVariant instance from serialised data.
        /// </summary>
        /// <remarks>
        /// @type is the type of #GVariant instance that will be constructed.
        /// The interpretation of @data depends on knowing the type.
        ///
        /// @data is not modified by this function and must remain valid with an
        /// unchanging value until such a time as @notify is called with
        /// @user_data.  If the contents of @data change before that time then
        /// the result is undefined.
        ///
        /// If @data is trusted to be serialised data in normal form then
        /// @trusted should be %TRUE.  This applies to serialised data created
        /// within this process or read from a trusted location on the disk (such
        /// as a file installed in /usr/lib alongside your application).  You
        /// should set trusted to %FALSE if @data is read from the network, a
        /// file in the user's home directory, etc.
        ///
        /// If @data was not stored in this machine's native endianness, any multi-byte
        /// numeric values in the returned variant will also be in non-native
        /// endianness. g_variant_byteswap() can be used to recover the original values.
        ///
        /// @notify will be called with @user_data when @data is no longer
        /// needed.  The exact time of this call is unspecified and might even be
        /// before this function returns.
        /// </remarks>
        /// <param name="type">
        /// a definite #GVariantType
        /// </param>
        /// <param name="data">
        /// the serialised data
        /// </param>
        /// <param name="size">
        /// the size of @data
        /// </param>
        /// <param name="trusted">
        /// %TRUE if @data is definitely in normal form
        /// </param>
        /// <param name="notify">
        /// function to call when @data is no longer needed
        /// </param>
        /// <param name="userData">
        /// data for @notify
        /// </param>
        /// <returns>
        /// a new floating #GVariant of type @type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_from_data(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            VariantType.UnmanagedStruct* type,
            /* <array length="2" zero-terminated="0" type="gconstpointer">
                <type name="guint8" managed-name="Guint8" />
                </array> */
            /* transfer-ownership:none */
            byte* data,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint size,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean trusted,
            /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="DestroyNotify" /> */
            /* transfer-ownership:none scope:async */
            delegate* unmanaged[Cdecl]<IntPtr, void> notify,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr userData);

        /// <summary>
        /// Creates a new handle #GVariant instance.
        /// </summary>
        /// <remarks>
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new handle #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_handle(
            /* <type name="gint32" type="gint32" managed-name="Gint32" /> */
            /* transfer-ownership:none */
            int value);

        [Since("2.24")]
        static UnmanagedStruct* NewHandle(DBusHandle value) // new_handle
        {
            var ret = g_variant_new_handle(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new handle <see cref="Variant"/> instance.
        /// </summary>
        /// <remarks>
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message. If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        [Since("2.24")]
        public Variant(DBusHandle value) : this((IntPtr)NewHandle(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_int16(
            /* <type name="gint16" type="gint16" managed-name="Gint16" /> */
            /* transfer-ownership:none */
            short value);

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int16 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewInt16(short value)
        {
            var ret = g_variant_new_int16(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new int16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint16 value
        /// </param>
        [Since("2.24")]
        public Variant(short value) : this((IntPtr)NewInt16(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_int32(
            /* <type name="gint32" type="gint32" managed-name="Gint32" /> */
            /* transfer-ownership:none */
            int value);

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int32 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewInt32(int value)
        {
            var ret = g_variant_new_int32(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new int32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint32 value
        /// </param>
        [Since("2.24")]
        public Variant(int value) : this((IntPtr)NewInt32(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_int64(
            /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
            /* transfer-ownership:none */
            long value);

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new int64 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewInt64(long value)
        {
            var ret = g_variant_new_int64(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new int64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #gint64 value
        /// </param>
        [Since("2.24")]
        public Variant(long value) : this((IntPtr)NewInt64(value), Transfer.None)
        {
        }

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        ///
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_maybe(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            VariantType.UnmanagedStruct* childType,
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            UnmanagedStruct* child);

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        ///
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant maybe instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewMaybe(VariantType? childType, Variant? child)
        {
            // FIXME: check args for at least one non-null and consistent types
            var childType_ = (VariantType.UnmanagedStruct*)(childType?.UnsafeHandle ?? IntPtr.Zero);
            var child_ = (UnmanagedStruct*)(child?.handle ?? IntPtr.Zero);
            var ret = g_variant_new_maybe(childType_, child_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Depending on if @child is %NULL, either wraps @child inside of a
        /// maybe container or creates a Nothing instance for the given @type.
        /// </summary>
        /// <remarks>
        /// At least one of @child_type and @child must be non-%NULL.
        /// If @child_type is non-%NULL then it must be a definite type.
        /// If they are both non-%NULL then @child_type must be the type
        /// of @child.
        ///
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="childType">
        /// the #GVariantType of the child, or %NULL
        /// </param>
        /// <param name="child">
        /// the child value, or %NULL
        /// </param>
        [Since("2.24")]
        public Variant(VariantType? childType, Variant? child)
            : this((IntPtr)NewMaybe(childType, child), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a D-Bus object path #GVariant with the contents of @string.
        /// @string must be a valid D-Bus object path.  Use
        /// g_variant_is_object_path() if you're not sure.
        /// </summary>
        /// <param name="objectPath">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new object path #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_object_path(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* objectPath);

        [Since("2.24")]
        static UnmanagedStruct* NewObjectPath(DBusObjectPath objectPath)
        {
            var objectPath_ = (byte*)GMarshal.StringToUtf8Ptr(objectPath);
            try {
                var ret = g_variant_new_object_path(objectPath_);
                GMarshal.PopUnhandledException();
                return ret;
            }
            finally {
                GMarshal.Free((IntPtr)objectPath_);
            }
        }

        /// <summary>
        /// Creates a D-Bus object path <see cref="Variant"/> with the contents
        /// of <paramref name="objectPath"/>.
        /// </summary>
        [Since("2.24")]
        public Variant(DBusObjectPath objectPath) : this((IntPtr)NewObjectPath(objectPath), Transfer.None)
        {
        }

        /// <summary>
        /// Constructs an array of object paths #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// Each string must be a valid #GVariant object path; see
        /// g_variant_is_object_path().
        ///
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_objv(
            /* <array length="1" zero-terminated="0" type="gchar**">
                <type name="utf8" managed-name="Utf8" />
                </array> */
            /* transfer-ownership:none */
            byte** strv,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            nint length);

        [Since("2.30")]
        static UnmanagedStruct* NewObjv(DBusObjectPath[] paths)
        {
            var strv = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++) {
                strv[i] = paths[i];
            }
            var strv_ = (byte**)GMarshal.StringArrayToGStrvPtr(strv);
            try {
                var ret = g_variant_new_objv(strv_, -1);
                GMarshal.PopUnhandledException();
                return ret;
            }
            finally {
                GMarshal.FreeGStrv((IntPtr)strv_);
            }
        }

        /// <summary>
        /// Constructs an array of object paths <see cref="Variant"/> from the given array of paths.
        /// </summary>
        [Since("2.30")]
        public Variant(DBusObjectPath[] paths) : this((IntPtr)NewObjv(paths), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a D-Bus type signature #GVariant with the contents of
        /// @string.  @string must be a valid D-Bus type signature.  Use
        /// g_variant_is_signature() if you're not sure.
        /// </summary>
        /// <param name="signature">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new signature #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_signature(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* signature);

        [Since("2.24")]
        static UnmanagedStruct* NewSignature(DBusSignature signature)
        {
            var signature_ = (byte*)GMarshal.StringToUtf8Ptr(signature);
            try {
                var ret = g_variant_new_signature(signature_);
                GMarshal.PopUnhandledException();
                return ret;
            }
            finally {
                GMarshal.Free((IntPtr)signature_);
            }
        }

        /// <summary>
        /// Creates a D-Bus type signature <see cref="Variant"/> with the
        /// contents of <paramref name="signature"/>.
        /// </summary>
        [Since("2.24")]
        public Variant(DBusSignature signature) : this((IntPtr)NewSignature(signature), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid UTF-8, and must not be %NULL. To encode
        /// potentially-%NULL strings, use g_variant_new() with `ms` as the
        /// [format string][gvariant-format-strings-maybe-types].
        /// </remarks>
        /// <param name="string">
        /// a normal UTF-8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern UnmanagedStruct* g_variant_new_string(
            /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
            /* transfer-ownership:none direction:in */
            byte* @string);

        [Since("2.24")]
        static UnmanagedStruct* NewString(UnownedUtf8 @string)
        {
            var @string_ = (byte*)@string.UnsafeHandle;
            var ret_ = g_variant_new_string(@string_);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Creates a string <see cref="Variant"/> with the contents of <paramref name="string"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="string"/> must be valid UTF-8, and must not be <c>null</c>. To encode
        /// potentially-<c>null</c> strings, create a <see cref="Variant"/> with `ms` as the
        /// format string.
        /// </remarks>
        /// <param name="string">
        /// a normal UTF-8 nul-terminated string
        /// </param>
        [Since("2.24")]
        public Variant(UnownedUtf8 @string) : this((IntPtr)NewString(@string), Transfer.None)
        {
        }

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <param name="length">
        /// the length of @strv, or -1
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_strv(
            /* <array length="1" zero-terminated="0" type="gchar**">
                <type name="utf8" managed-name="Utf8" />
                </array> */
            /* transfer-ownership:none */
            byte** strv,
            /* <type name="gssize" type="gssize" managed-name="Gssize" /> */
            /* transfer-ownership:none */
            nint length);

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        /// <returns>
        /// a new floating #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewStrv(Strv strv)
        {
            var strv_ = (byte**)strv.UnsafeHandle;
            var ret = g_variant_new_strv(strv_, -1);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Constructs an array of strings #GVariant from the given array of
        /// strings.
        /// </summary>
        /// <remarks>
        /// If @length is -1 then @strv is %NULL-terminated.
        /// </remarks>
        /// <param name="strv">
        /// an array of strings
        /// </param>
        [Since("2.24")]
        public Variant(Strv strv) : this((IntPtr)NewStrv(strv), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid UTF-8, and must not be %NULL. To encode
        /// potentially-%NULL strings, use this with g_variant_new_maybe().
        ///
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        ///
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal UTF-8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [Since("2.38")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_take_string(
            /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:full */
            byte* @string);

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid UTF-8, and must not be %NULL. To encode
        /// potentially-%NULL strings, use this with g_variant_new_maybe().
        ///
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        ///
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal UTF-8 nul-terminated string
        /// </param>
        /// <returns>
        /// a floating reference to a new string
        ///   #GVariant instance
        /// </returns>
        [Since("2.38")]
        static UnmanagedStruct* NewTakeString(string @string)
        {
            var @string_ = (byte*)GMarshal.StringToUtf8Ptr(@string);
            var ret = g_variant_new_take_string(@string_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a string #GVariant with the contents of @string.
        /// </summary>
        /// <remarks>
        /// @string must be valid UTF-8, and must not be %NULL. To encode
        /// potentially-%NULL strings, use this with g_variant_new_maybe().
        ///
        /// This function consumes @string.  g_free() will be called on @string
        /// when it is no longer required.
        ///
        /// You must not modify or access @string in any other way after passing
        /// it to this function.  It is even possible that @string is immediately
        /// freed.
        /// </remarks>
        /// <param name="string">
        /// a normal UTF-8 nul-terminated string
        /// </param>
        [Since("2.38")]
        public Variant(string @string) : this((IntPtr)NewTakeString(@string), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        /// <param name="nChildren">
        /// the length of @children
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_tuple(
            /* <array length="1" zero-terminated="0" type="GVariant**">
                <type name="Variant" type="GVariant*" managed-name="Variant" />
                </array> */
            /* transfer-ownership:none */
            UnmanagedStruct** children,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint nChildren);

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        /// <returns>
        /// a floating reference to a new #GVariant tuple
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewTuple(ITuple children)
        {
            var children_ = stackalloc UnmanagedStruct*[children.Length];
            var nChildren_ = (nuint)children.Length;

            for (var i = 0; i < children.Length; i++) {
                var child = (Variant?)children[i];

                if (child is null) {
                    throw new ArgumentException("Tuple cannot have null elements", nameof(children));
                }

                children_[i] = (UnmanagedStruct*)child.UnsafeHandle;
            }

            var ret = g_variant_new_tuple(children_, nChildren_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new tuple #GVariant out of the items in @children.  The
        /// type is determined from the types of @children.  No entry in the
        /// @children array may be %NULL.
        /// </summary>
        /// <remarks>
        /// If @n_children is 0 then the unit tuple is constructed.
        ///
        /// If the @children are floating references (see g_variant_ref_sink()), the
        /// new instance takes ownership of them as if via g_variant_ref_sink().
        /// </remarks>
        /// <param name="children">
        /// the items to make the tuple out of
        /// </param>
        [Since("2.24")]
        public Variant(ITuple children) : this((IntPtr)NewTuple(children), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_uint16(
            /* <type name="guint16" type="guint16" managed-name="Guint16" /> */
            /* transfer-ownership:none */
            ushort value);

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint16 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewUint16(ushort value)
        {
            var ret = g_variant_new_uint16(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new uint16 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint16 value
        /// </param>
        [Since("2.24")]
        public Variant(ushort value) : this((IntPtr)NewUint16(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_uint32(
            /* <type name="guint32" type="guint32" managed-name="Guint32" /> */
            /* transfer-ownership:none */
            uint value);

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint32 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewUint32(uint value)
        {
            var ret = g_variant_new_uint32(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new uint32 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint32 value
        /// </param>
        [Since("2.24")]
        public Variant(uint value) : this((IntPtr)NewUint32(value), Transfer.None)
        {
        }

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_uint64(
            /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
            /* transfer-ownership:none */
            ulong value);

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        /// <returns>
        /// a floating reference to a new uint64 #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewUint64(ulong value)
        {
            var ret = g_variant_new_uint64(value);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Creates a new uint64 #GVariant instance.
        /// </summary>
        /// <param name="value">
        /// a #guint64 value
        /// </param>
        [Since("2.24")]
        public Variant(ulong value) : this((IntPtr)NewUint64(value), Transfer.None)
        {
        }

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:none */
        static extern UnmanagedStruct* g_variant_new_variant(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// a floating reference to a new variant #GVariant instance
        /// </returns>
        [Since("2.24")]
        static UnmanagedStruct* NewVariant(Variant value)
        {
            var value_ = (UnmanagedStruct*)value.UnsafeHandle;
            var ret = g_variant_new_variant(value_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Boxes @value.  The result is a #GVariant instance representing a
        /// variant containing the original value.
        /// </summary>
        /// <remarks>
        /// If @child is a floating reference (see g_variant_ref_sink()), the new
        /// instance takes ownership of @child.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        [Since("2.24")]
        public Variant(Variant value) : this((IntPtr)NewVariant(value), Transfer.None)
        {
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_is_object_path(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* @string);

        /// <summary>
        /// Determines if a given string is a valid D-Bus object path.  You
        /// should ensure that a string is a valid D-Bus object path before
        /// passing it to g_variant_new_object_path().
        /// </summary>
        /// <remarks>
        /// A valid object path starts with '/' followed by zero or more
        /// sequences of characters separated by '/' characters.  Each sequence
        /// must contain only the characters "[A-Z][a-z][0-9]_".  No sequence
        /// (including the one following the final '/' character) may be empty.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus object path
        /// </returns>
        [Since("2.24")]
        public static bool IsObjectPath(UnownedUtf8 @string)
        {
            var string_ = (byte*)@string.UnsafeHandle;
            var ret_ = g_variant_is_object_path(@string_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_is_signature(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* @string);

        /// <summary>
        /// Determines if a given string is a valid D-Bus type signature.  You
        /// should ensure that a string is a valid D-Bus type signature before
        /// passing it to g_variant_new_signature().
        /// </summary>
        /// <remarks>
        /// D-Bus type signatures consist of zero or more definite #GVariantType
        /// strings in sequence.
        /// </remarks>
        /// <param name="string">
        /// a normal C nul-terminated string
        /// </param>
        /// <returns>
        /// %TRUE if @string is a D-Bus type signature
        /// </returns>
        [Since("2.24")]
        public static bool IsSignature(UnownedUtf8 @string)
        {
            var string_ = (byte*)@string.UnsafeHandle;
            var ret_ = g_variant_is_signature(@string_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Parses a #GVariant from a text representation.
        /// </summary>
        /// <remarks>
        /// A single #GVariant is parsed from the content of @text.
        ///
        /// The format is described [here][gvariant-text].
        ///
        /// The memory at @limit will never be accessed and the parser behaves as
        /// if the character at @limit is the nul terminator.  This has the
        /// effect of bounding @text.
        ///
        /// If @endptr is non-%NULL then @text is permitted to contain data
        /// following the value that this function parses and @endptr will be
        /// updated to point to the first character past the end of the text
        /// parsed by this function.  If @endptr is %NULL and there is extra data
        /// then an error is returned.
        ///
        /// If @type is non-%NULL then the value will be parsed to have that
        /// type.  This may result in additional parse errors (in the case that
        /// the parsed value doesn't fit the type) but may also result in fewer
        /// errors (in the case that the type would have been ambiguous, such as
        /// with empty arrays).
        ///
        /// In the event that the parsing is successful, the resulting #GVariant
        /// is returned. It is never floating, and must be freed with
        /// g_variant_unref().
        ///
        /// In case of any error, %NULL will be returned.  If @error is non-%NULL
        /// then it will be set to reflect the error that occurred.
        ///
        /// Officially, the language understood by the parser is "any string
        /// produced by g_variant_print()".
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <param name="text">
        /// a string containing a GVariant in text form
        /// </param>
        /// <param name="limit">
        /// a pointer to the end of @text, or %NULL
        /// </param>
        /// <param name="endptr">
        /// a location to store the end pointer, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a non-floating reference to a #GVariant, or %NULL
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_variant_parse(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            VariantType.UnmanagedStruct* type,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* text,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            byte* limit,
            /* <type name="utf8" type="const gchar**" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            byte* endptr,
            /* <type name="GLib.Error" managed-name="GLib.Error" /> */
            /* direction:out */
            Error.UnmanagedStruct** error);

        /// <summary>
        /// Parses a #GVariant from a text representation.
        /// </summary>
        /// <remarks>
        /// A single #GVariant is parsed from the content of @text.
        ///
        /// The format is described [here][gvariant-text].
        ///
        /// The memory at @limit will never be accessed and the parser behaves as
        /// if the character at @limit is the nul terminator.  This has the
        /// effect of bounding @text.
        ///
        /// If @endptr is non-%NULL then @text is permitted to contain data
        /// following the value that this function parses and @endptr will be
        /// updated to point to the first character past the end of the text
        /// parsed by this function.  If @endptr is %NULL and there is extra data
        /// then an error is returned.
        ///
        /// If @type is non-%NULL then the value will be parsed to have that
        /// type.  This may result in additional parse errors (in the case that
        /// the parsed value doesn't fit the type) but may also result in fewer
        /// errors (in the case that the type would have been ambiguous, such as
        /// with empty arrays).
        ///
        /// In the event that the parsing is successful, the resulting #GVariant
        /// is returned. It is never floating, and must be freed with
        /// g_variant_unref().
        ///
        /// In case of any error, %NULL will be returned.  If @error is non-%NULL
        /// then it will be set to reflect the error that occurred.
        ///
        /// Officially, the language understood by the parser is "any string
        /// produced by g_variant_print()".
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <param name="text">
        /// a string containing a GVariant in text form
        /// </param>
        /// <returns>
        /// a non-floating reference to a #GVariant, or %NULL
        /// </returns>
        public static Variant Parse(VariantType? type, UnownedUtf8 text)
        {
            var type_ = (VariantType.UnmanagedStruct*)(type?.UnsafeHandle ?? IntPtr.Zero);
            var text_ = (byte*)text.UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret = g_variant_parse(type_, text_, null, null, &error_);
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new GErrorException(error);
            }
            return new Variant((IntPtr)ret, Transfer.Full);
        }

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        ///
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_variant_byteswap(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Performs a byteswapping operation on the contents of @value.  The
        /// result is that all multi-byte numeric data contained in @value is
        /// byteswapped.  That includes 16, 32, and 64bit signed and unsigned
        /// integers as well as file handles and double precision floating point
        /// values.
        /// </summary>
        /// <remarks>
        /// This function is an identity mapping on any value that does not
        /// contain multi-byte numeric data.  That include strings, booleans,
        /// bytes and containers containing only these things (recursively).
        ///
        /// The returned value is always in normal form and is marked as trusted.
        /// </remarks>
        /// <returns>
        /// the byteswapped form of @value
        /// </returns>
        [Since("2.24")]
        public Variant Byteswap()
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_byteswap(value_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<Variant>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        ///
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [Since("2.34")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_check_format_string(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* formatString,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean copyOnly);

        /// <summary>
        /// Checks if calling g_variant_get() with @format_string on @value would
        /// be valid from a type-compatibility standpoint.  @format_string is
        /// assumed to be a valid format string (from a syntactic standpoint).
        /// </summary>
        /// <remarks>
        /// If @copy_only is %TRUE then this function additionally checks that it
        /// would be safe to call g_variant_unref() on @value immediately after
        /// the call to g_variant_get() without invalidating the result.  This is
        /// only possible if deep copies are made (ie: there are no pointers to
        /// the data inside of the soon-to-be-freed #GVariant instance).  If this
        /// check fails then a g_critical() is printed and %FALSE is returned.
        ///
        /// This function is meant to be used by functions that wish to provide
        /// varargs accessors to #GVariant values of uncertain values (eg:
        /// g_variant_lookup() or g_menu_model_get_item_attribute()).
        /// </remarks>
        /// <param name="formatString">
        /// a valid #GVariant format string
        /// </param>
        /// <param name="copyOnly">
        /// %TRUE to ensure the format string makes deep copies
        /// </param>
        /// <returns>
        /// %TRUE if @format_string is safe to use
        /// </returns>
        [Since("2.34")]
        public bool CheckFormatString(UnownedUtf8 formatString, bool copyOnly)
        {
            var this_ = (UnmanagedStruct*)UnsafeHandle;
            var formatString_ = (byte*)formatString.UnsafeHandle;
            var copyOnly_ = copyOnly.ToBoolean();
            var ret_ = g_variant_check_format_string(this_, formatString_, copyOnly_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantClass" type="GVariantClass" managed-name="VariantClass" /> */
        /* transfer-ownership:none */
        static extern VariantClass g_variant_classify(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Classifies @value according to its top-level type.
        /// </summary>
        /// <returns>
        /// the #GVariantClass of @value
        /// </returns>
        [Since("2.24")]
        public VariantClass Classify()
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var ret = g_variant_classify(value_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Compares @one and @two.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        ///
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, %FALSE is less than %TRUE.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        ///
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        ///
        /// If you only require an equality comparison, g_variant_equal() is more
        /// general.
        /// </remarks>
        /// <param name="one">
        /// a basic-typed #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance of the same type
        /// </param>
        /// <returns>
        /// negative value if a &lt; b;
        ///          zero if a = b;
        ///          positive value if a &gt; b.
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_variant_compare(
            /* <type name="Variant" type="gconstpointer" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* one,
            /* <type name="Variant" type="gconstpointer" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* two);

        /// <summary>
        /// Compares <parmref name="one"/> and <parmref name="two"/>.
        /// </summary>
        /// <remarks>
        /// The types of <parmref name="one"/> and <parmref name="two"/> are #gconstpointer only to allow use of
        /// this function with #GTree, #GPtrArray, etc.  They must each be a
        /// #GVariant.
        ///
        /// Comparison is only defined for basic types (ie: booleans, numbers,
        /// strings).  For booleans, <c>false</c> is less than <c>true</c>.  Numbers are
        /// ordered in the usual way.  Strings are in ASCII lexographical order.
        ///
        /// It is a programmer error to attempt to compare container values or
        /// two values that have types that are not exactly equal.  For example,
        /// you cannot compare a 32-bit signed integer with a 32-bit unsigned
        /// integer.  Also note that this function is not particularly
        /// well-behaved when it comes to comparison of doubles; in particular,
        /// the handling of incomparable values (ie: NaN) is undefined.
        ///
        /// If you only require an equality comparison, <see cref="Equal"/> is more
        /// general.
        /// </remarks>
        /// <param name="one">
        /// a basic-typed <see cref="Variant"/> instance
        /// </param>
        /// <param name="two">
        /// a <see cref="Variant"/> instance of the same type
        /// </param>
        /// <returns>
        /// negative value if <parmref name="one"/> &lt; <parmref name="two"/>;
        ///          zero if <parmref name="one"/> = <parmref name="two"/>;
        ///          positive value if <parmref name="one"/> &gt; <parmref name="two"/>.
        /// </returns>
        [Since("2.26")]
        public static int Compare(Variant one, Variant two)
        {
            var one_ = (UnmanagedStruct*)one.UnsafeHandle;
            var two_ = (UnmanagedStruct*)two.UnsafeHandle;
            if (one.Type != two.Type) {
                var message = $"Variant types must match but have '{one.Type}' and '{two.Type}'";
                throw new InvalidOperationException(message);
            }
            var ret = g_variant_compare(one_, two_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <inheritdoc/>
        /// <seealso cref="Compare"/>
        public int CompareTo(Variant? other)
        {
            return Compare(this, other ?? throw new ArgumentNullException(nameof(other)));
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s.
        /// </summary>
        public static bool operator >=(Variant one, Variant two)
        {
            return Compare(one, two) >= 0;
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s.
        /// </summary>
        public static bool operator >(Variant one, Variant two)
        {
            return Compare(one, two) > 0;
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s.
        /// </summary>
        public static bool operator <(Variant one, Variant two)
        {
            return Compare(one, two) < 0;
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s.
        /// </summary>
        public static bool operator <=(Variant one, Variant two)
        {
            return Compare(one, two) <= 0;
        }

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="one">
        /// a #GVariant instance
        /// </param>
        /// <param name="two">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_equal(
            /* <type name="Variant" type="gconstpointer" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* one,
            /* <type name="Variant" type="gconstpointer" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* two);

        private static bool Equal(Variant? one, Variant? two)
        {
            if (one is null) {
                return two is null;
            }
            if (two is null) {
                return false;
            }
            var one_ = (UnmanagedStruct*)one.UnsafeHandle;
            var two_ = (UnmanagedStruct*)two.UnsafeHandle;
            var ret_ = g_variant_equal(one_, two_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Checks if @one and @two have the same type and value.
        /// </summary>
        /// <remarks>
        /// The types of @one and @two are #gconstpointer only to allow use of
        /// this function with #GHashTable.  They must each be a #GVariant.
        /// </remarks>
        /// <param name="other">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @one and @two are equal
        /// </returns>
        [Since("2.24")]
        public bool Equals(Variant? other)
        {
            return Equal(this, other);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Variant variant) {
                return Equals(variant);
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s for equality.
        /// </summary>
        public static bool operator ==(Variant? one, Variant? two)
        {
            return Equal(one, two);
        }

        /// <summary>
        /// Compares two <see cref="Variant"/>s for inequality.
        /// </summary>
        public static bool operator !=(Variant? one, Variant? two)
        {
            return !Equal(one, two);
        }

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <param name="value">
        /// a boolean #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_get_boolean(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the boolean value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BOOLEAN.
        /// </remarks>
        /// <returns>
        /// %TRUE or %FALSE
        /// </returns>
        [Since("2.24")]
        bool Boolean {
            get {
                if (!IsOfType(VariantType.Boolean)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_boolean(value_);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <param name="value">
        /// a byte #GVariant instance
        /// </param>
        /// <returns>
        /// a #guchar
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint8" type="guchar" managed-name="Guint8" /> */
        /* transfer-ownership:none */
        static extern byte g_variant_get_byte(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the byte value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_BYTE.
        /// </remarks>
        /// <returns>
        /// a #guchar
        /// </returns>
        [Since("2.24")]
        byte Byte {
            get {
                if (!IsOfType(VariantType.Byte)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_byte(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        ///
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        ///
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        ///
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// an array-of-bytes #GVariant instance
        /// </param>
        /// <returns>
        ///
        ///          the constant string
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array type="gchar*" zero-terminated="1">
            <type name="guint8" managed-name="Guint8" />
            </array> */
        /* transfer-ownership:none */
        static extern byte* g_variant_get_bytestring(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the string value of a #GVariant instance with an
        /// array-of-bytes type.  The string has no particular encoding.
        /// </summary>
        /// <remarks>
        /// If the array does not end with a nul terminator character, the empty
        /// string is returned.  For this reason, you can always trust that a
        /// non-%NULL nul-terminated string will be returned by this function.
        ///
        /// If the array contains a nul terminator character somewhere other than
        /// the last byte then the returned string is the string, up to the first
        /// such nul character.
        ///
        /// It is an error to call this function with a @value that is not an
        /// array of bytes.
        ///
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <returns>
        ///
        ///          the constant string
        /// </returns>
        [Since("2.26")]
        byte[] Bytestring {
            get {
                if (!IsOfType(VariantType.ByteString)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_bytestring(value_);
                GMarshal.PopUnhandledException();
                var ret = GMarshal.PtrToCArray<byte>((IntPtr)ret_, null)!;
                return ret;
            }
        }

        /// <summary>
        /// Gets the contents of an array of array of bytes #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result is
        /// stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        ///
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of array of bytes #GVariant ('aay')
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gchar**">
            <type name="utf8" managed-name="Utf8" />
            </array> */
        /* transfer-ownership:container */
        static extern byte** g_variant_get_bytestring_array(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            nuint* length);

        WeakZeroTerminatedCPtrArray<ByteString>? GetBytestringArray()
        {
            if (!IsOfType(VariantType.ByteStringArray)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_get_bytestring_array(value_, &length_);
            GMarshal.PopUnhandledException();
            if (ret_ == null) {
                return null;
            }
            return new WeakZeroTerminatedCPtrArray<ByteString>((IntPtr)ret_, (int)length_, Transfer.Container);
        }

        [Since("2.26")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte** g_variant_dup_bytestring_array(
            UnmanagedStruct* value,
            nuint* length);

        ByteStringArray? DupBytestringArray()
        {
            if (!IsOfType(VariantType.ByteStringArray)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_dup_bytestring_array(value_, &length_);
            GMarshal.PopUnhandledException();
            if (ret_ == null) {
                return null;
            }
            return new ByteStringArray((IntPtr)ret_, (int)length_, Transfer.Full);
        }

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        ///
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        ///
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_variant_get_child_value(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint index);

        /// <summary>
        /// Reads a child item out of a container #GVariant instance.  This
        /// includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// It is an error if @index_ is greater than the number of child items
        /// in the container.  See g_variant_n_children().
        ///
        /// The returned value is never floating.  You should free it with
        /// g_variant_unref() when you're done with it.
        ///
        /// This function is O(1).
        /// </remarks>
        /// <param name="index">
        /// the index of the child to fetch
        /// </param>
        /// <returns>
        /// the child at the specified index
        /// </returns>
        [Since("2.24")]
        Variant GetChildValue(int index)
        {
            if (!IsContainer) {
                throw new InvalidOperationException();
            }
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var index_ = (nuint)index;
            var ret_ = g_variant_get_child_value(value_, index_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<Variant>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        ///
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        ///
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gconstpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern void* g_variant_get_data(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns a pointer to the serialised form of a #GVariant instance.
        /// The returned data may not be in fully-normalised form if read from an
        /// untrusted source.  The returned data must not be freed; it remains
        /// valid for as long as @value exists.
        /// </summary>
        /// <remarks>
        /// If @value is a fixed-sized value that was deserialised from a
        /// corrupted serialised container then %NULL may be returned.  In this
        /// case, the proper thing to do is typically to use the appropriate
        /// number of nul bytes in place of @value.  If @value is not fixed-sized
        /// then %NULL is never returned.
        ///
        /// In the case that @value is already in serialised form, this function
        /// is O(1).  If the value is not already in serialised form,
        /// serialisation occurs implicitly and is approximately O(n) in the size
        /// of the result.
        ///
        /// To deserialise the data returned by this function, in addition to the
        /// serialised data, you must know the type of the #GVariant, and (if the
        /// machine might be different) the endianness of the machine that stored
        /// it. As a result, file formats or network messages that incorporate
        /// serialised #GVariants must include this information either
        /// implicitly (for instance "the file always contains a
        /// %G_VARIANT_TYPE_VARIANT and it is always in little-endian order") or
        /// explicitly (by storing the type and/or endianness in addition to the
        /// serialised data).
        /// </remarks>
        /// <returns>
        /// the serialised form of @value, or %NULL
        /// </returns>
        [Since("2.24")]
        public IntPtr Data {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_data(value_);
                GMarshal.PopUnhandledException();
                return (IntPtr)ret_;
            }
        }

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <param name="value">
        /// a double #GVariant instance
        /// </param>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
        /* transfer-ownership:none */
        static extern double g_variant_get_double(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the double precision floating point value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_DOUBLE.
        /// </remarks>
        /// <returns>
        /// a #gdouble
        /// </returns>
        [Since("2.24")]
        double Double {
            get {
                if (!IsOfType(VariantType.Double)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_double(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        ///
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        ///
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        ///
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        ///
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant array with fixed-sized elements
        /// </param>
        /// <param name="nElements">
        /// a pointer to the location to store the number of items
        /// </param>
        /// <param name="elementSize">
        /// the size of each element
        /// </param>
        /// <returns>
        /// a pointer to
        ///     the fixed array
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gconstpointer">
            <type name="gpointer" type="gconstpointer" managed-name="Gpointer" />
            </array> */
        /* transfer-ownership:none */
        static extern void* g_variant_get_fixed_array(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            nuint* nElements,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            nuint elementSize);

        /// <summary>
        /// Provides access to the serialised data for an array of fixed-sized
        /// items.
        /// </summary>
        /// <remarks>
        /// @value must be an array with fixed-sized elements.  Numeric types are
        /// fixed-size, as are tuples containing only other fixed-sized types.
        ///
        /// @element_size must be the size of a single element in the array,
        /// as given by the section on
        /// [serialized data memory][gvariant-serialised-data-memory].
        ///
        /// In particular, arrays of these fixed-sized types can be interpreted
        /// as an array of the given C type, with @element_size set to the size
        /// the appropriate type:
        /// - %G_VARIANT_TYPE_INT16 (etc.): #gint16 (etc.)
        /// - %G_VARIANT_TYPE_BOOLEAN: #guchar (not #gboolean!)
        /// - %G_VARIANT_TYPE_BYTE: #guchar
        /// - %G_VARIANT_TYPE_HANDLE: #guint32
        /// - %G_VARIANT_TYPE_DOUBLE: #gdouble
        ///
        /// For example, if calling this function for an array of 32-bit integers,
        /// you might say sizeof(gint32). This value isn't used except for the purpose
        /// of a double-check that the form of the serialised data matches the caller's
        /// expectation.
        ///
        /// @n_elements, which must be non-%NULL is set equal to the number of
        /// items in the array.
        /// </remarks>
        /// <returns>
        /// a pointer to the fixed array
        /// </returns>
        [Since("2.24")]
        ReadOnlySpan<T> GetFixedArray<T>() where T : unmanaged
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            if (!IsOfType(VariantType.Array)) {
                throw new InvalidOperationException();
            }
            nuint nElements_;
            var elementSize_ = (nuint)sizeof(T);
            var ret_ = g_variant_get_fixed_array(value_, &nElements_, elementSize_);
            GMarshal.PopUnhandledException();
            var ret = new ReadOnlySpan<T>(ret_, (int)nElements_);
            return ret;
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        ///
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <param name="value">
        /// a handle #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint32" type="gint32" managed-name="Gint32" /> */
        /* transfer-ownership:none */
        static extern int g_variant_get_handle(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type other
        /// than %G_VARIANT_TYPE_HANDLE.
        ///
        /// By convention, handles are indexes into an array of file descriptors
        /// that are sent alongside a D-Bus message.  If you're not interacting
        /// with D-Bus, you probably don't need them.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [Since("2.24")]
        int DBusHandle {
            get {
                if (!IsOfType(VariantType.DBusHandle)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_handle(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <param name="value">
        /// a int16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint16
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint16" type="gint16" managed-name="Gint16" /> */
        /* transfer-ownership:none */
        static extern short g_variant_get_int16(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 16-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT16.
        /// </remarks>
        /// <returns>
        /// a #gint16
        /// </returns>
        [Since("2.24")]
        short Int16 {
            get {
                if (!IsOfType(VariantType.Int16)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_int16(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <param name="value">
        /// a int32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint32
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint32" type="gint32" managed-name="Gint32" /> */
        /* transfer-ownership:none */
        static extern int g_variant_get_int32(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 32-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT32.
        /// </remarks>
        /// <returns>
        /// a #gint32
        /// </returns>
        [Since("2.24")]
        int Int32 {
            get {
                if (!IsOfType(VariantType.Int32)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_int32(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <param name="value">
        /// a int64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #gint64
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern long g_variant_get_int64(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 64-bit signed integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_INT64.
        /// </remarks>
        /// <returns>
        /// a #gint64
        /// </returns>
        [Since("2.24")]
        long Int64 {
            get {
                if (!IsOfType(VariantType.Int64)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_int64(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <param name="value">
        /// a maybe-typed value
        /// </param>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_get_maybe(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Given a maybe-typed #GVariant instance, extract its value.  If the
        /// value is Nothing, then this function returns %NULL.
        /// </summary>
        /// <returns>
        /// the contents of @value, or %NULL
        /// </returns>
        [Since("2.24")]
        Variant Maybe {
            get {
                if (!IsOfType(VariantType.Maybe)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_maybe(value_);
                GMarshal.PopUnhandledException();
                var ret = GetInstance<Variant>(ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        ///
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        ///
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        ///
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_variant_get_normal_form(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Gets a #GVariant instance that has the same value as @value and is
        /// trusted to be in normal form.
        /// </summary>
        /// <remarks>
        /// If @value is already trusted to be in normal form then a new
        /// reference to @value is returned.
        ///
        /// If @value is not already trusted, then it is scanned to check if it
        /// is in normal form.  If it is found to be in normal form then it is
        /// marked as trusted and a new reference to it is returned.
        ///
        /// If @value is found not to be in normal form then a new trusted
        /// #GVariant is created with the same value as @value.
        ///
        /// It makes sense to call this function if you've received #GVariant
        /// data from untrusted sources and you want to ensure your serialised
        /// output is definitely in normal form.
        /// </remarks>
        /// <returns>
        /// a trusted #GVariant
        /// </returns>
        [Since("2.24")]
        Variant NormalForm {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_normal_form(value_);
                GMarshal.PopUnhandledException();
                var ret = GetInstance<Variant>((IntPtr)ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Gets the contents of an array of object paths #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        ///
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of object paths #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="1" type="gchar**">
            <type name="utf8" managed-name="Utf8" />
            </array> */
        /* transfer-ownership:container */
        static extern byte** g_variant_get_objv(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            nuint* length);

        [Since("2.30")]
        DBusObjectPath[] Objv {
            get {
                if (!IsOfType(VariantType.DBusObjectPathArray)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                nuint length_;
                var ret_ = g_variant_get_objv(value_, &length_);
                GMarshal.PopUnhandledException();
                if (ret_ is null) {
                    return Array.Empty<DBusObjectPath>();
                }
                var strv = GMarshal.GStrvPtrToStringArray((IntPtr)ret_, freePtr: true, freeElements: false)!;
                var objv = new DBusObjectPath[strv.Length];
                for (int i = 0; i < strv.Length; i++) {
                    objv[i] = strv[i];
                }
                return objv;
            }
        }

        /// <summary>
        /// Determines the number of bytes that would be required to store @value
        /// with g_variant_store().
        /// </summary>
        /// <remarks>
        /// If @value has a fixed-sized type then this function always returned
        /// that fixed size.
        ///
        /// In the case that @value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// the serialised size of @value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern nuint g_variant_get_size(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Determines the number of bytes that would be required to store this value
        /// with <see cref="Store" />.
        /// </summary>
        /// <remarks>
        /// If this value has a fixed-sized type then this function always returned
        /// that fixed size.
        ///
        /// In the case that this value is already in serialised form or the size has
        /// already been calculated (ie: this function has been called before)
        /// then this function is O(1).  Otherwise, the size is calculated, an
        /// operation which is approximately O(n) in the number of values
        /// involved.
        /// </remarks>
        /// <returns>
        /// the serialised size of this value
        /// </returns>
        [Since("2.24")]
        public int Size {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_size(value_);
                GMarshal.PopUnhandledException();
                return (int)ret;
            }
        }

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <remarks>
        /// The string will always be UTF-8 encoded, and will never be %NULL.
        ///
        /// If @length is non-%NULL then the length of the string (in bytes) is
        /// returned there.  For trusted values, this information is already
        /// known.  For untrusted values, a strlen() will be performed.
        ///
        /// It is an error to call this function with a @value of any type
        /// other than those three.
        ///
        /// The return value remains valid as long as @value exists.
        /// </remarks>
        /// <param name="value">
        /// a string #GVariant instance
        /// </param>
        /// <param name="length">
        /// a pointer to a #gsize,
        ///          to store the length
        /// </param>
        /// <returns>
        /// the constant string, UTF-8 encoded
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern byte* g_variant_get_string(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            nuint* length);

        /// <summary>
        /// Returns the string value of a #GVariant instance with a string
        /// type.  This includes the types %G_VARIANT_TYPE_STRING,
        /// %G_VARIANT_TYPE_OBJECT_PATH and %G_VARIANT_TYPE_SIGNATURE.
        /// </summary>
        /// <returns>
        /// the string
        /// </returns>
        [Since("2.24")]
        UnownedUtf8 GetString()
        {
            if (!IsOfType(VariantType.String) && !IsOfType(VariantType.DBusObjectPath) && !IsOfType(VariantType.DBusSignature)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_get_string(value_, &length_);
            GMarshal.PopUnhandledException();
            var ret = new UnownedUtf8((IntPtr)ret_, (int)length_);
            return ret;
        }

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <remarks>
        /// If @length is non-%NULL then the number of elements in the result
        /// is stored there.  In any case, the resulting array will be
        /// %NULL-terminated.
        ///
        /// For an empty array, @length will be set to 0 and a pointer to a
        /// %NULL pointer will be returned.
        /// </remarks>
        /// <param name="value">
        /// an array of strings #GVariant
        /// </param>
        /// <param name="length">
        /// the length of the result, or %NULL
        /// </param>
        /// <returns>
        /// an array of constant strings
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="1" type="gchar**">
            <type name="utf8" managed-name="Utf8" />
            </array> */
        /* transfer-ownership:container */
        static extern byte** g_variant_get_strv(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gsize" type="gsize*" managed-name="Gsize" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            nuint* length);

        /// <summary>
        /// Gets the contents of an array of strings #GVariant.  This call
        /// makes a shallow copy; the return result should be released with
        /// g_free(), but the individual strings must not be modified.
        /// </summary>
        /// <returns>
        /// an array of constant strings or <c>null</c> for an empty array
        /// </returns>
        [Since("2.24")]
        WeakZeroTerminatedCPtrArray<Utf8>? Strv {
            get {
                if (!IsOfType(VariantType.StringArray)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                nuint length_;
                var ret_ = g_variant_get_strv(value_, &length_);
                GMarshal.PopUnhandledException();
                var ret = new WeakZeroTerminatedCPtrArray<Utf8>((IntPtr)ret_, (int)length_, Transfer.Container);
                return ret;
            }
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern byte** g_variant_dup_strv(
            UnmanagedStruct* value,
            nuint* length);

        Strv? DupStrv()
        {
            if (!IsOfType(VariantType.StringArray)) {
                throw new InvalidOperationException();
            }
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            nuint length_;
            var ret_ = g_variant_dup_strv(value_, &length_);
            GMarshal.PopUnhandledException();
            var ret = new Strv((IntPtr)ret_, (int)length_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Determines the type of @value.
        /// </summary>
        /// <remarks>
        /// The return value is valid for the lifetime of @value and must not
        /// be freed.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// a #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern VariantType.UnmanagedStruct* g_variant_get_type(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Determines the type of this value.
        /// </summary>
        [Since("2.24")]
        public VariantType Type {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_type(value_);
                GMarshal.PopUnhandledException();
                var ret = GetInstance<VariantType>((IntPtr)ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern byte* g_variant_get_type_string(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the type string of @value.  Unlike the result of calling
        /// g_variant_type_peek_string(), this string is nul-terminated.  This
        /// string belongs to #GVariant and must not be freed.
        /// </summary>
        /// <returns>
        /// the type string for the type of @value
        /// </returns>
        [Since("2.24")]
        public UnownedUtf8 TypeString {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_type_string(value_);
                GMarshal.PopUnhandledException();
                var ret = new UnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <param name="value">
        /// a uint16 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint16
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint16" type="guint16" managed-name="Guint16" /> */
        /* transfer-ownership:none */
        static extern ushort g_variant_get_uint16(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 16-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT16.
        /// </remarks>
        /// <returns>
        /// a #guint16
        /// </returns>
        [Since("2.24")]
        ushort Uint16 {
            get {
                if (!IsOfType(VariantType.UInt16)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_uint16(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <param name="value">
        /// a uint32 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint32
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint32" type="guint32" managed-name="Guint32" /> */
        /* transfer-ownership:none */
        static extern uint g_variant_get_uint32(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 32-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT32.
        /// </remarks>
        /// <returns>
        /// a #guint32
        /// </returns>
        [Since("2.24")]
        uint Uint32 {
            get {
                if (!IsOfType(VariantType.UInt32)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_uint32(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <param name="value">
        /// a uint64 #GVariant instance
        /// </param>
        /// <returns>
        /// a #guint64
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
        /* transfer-ownership:none */
        static extern ulong g_variant_get_uint64(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Returns the 64-bit unsigned integer value of @value.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function with a @value of any type
        /// other than %G_VARIANT_TYPE_UINT64.
        /// </remarks>
        /// <returns>
        /// a #guint64
        /// </returns>
        [Since("2.24")]
        ulong Uint64 {
            get {
                if (!IsOfType(VariantType.UInt64)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret = g_variant_get_uint64(value_);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <param name="value">
        /// a variant #GVariant instance
        /// </param>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_get_variant(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Unboxes @value.  The result is the #GVariant instance that was
        /// contained in @value.
        /// </summary>
        /// <returns>
        /// the item contained in the variant
        /// </returns>
        [Since("2.24")]
        Variant BoxedVariant {
            get {
                if (!IsOfType(VariantType.Variant)) {
                    throw new InvalidOperationException();
                }
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_get_variant(value_);
                GMarshal.PopUnhandledException();
                var ret = GetInstance<Variant>(ret_, Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        ///
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <param name="value">
        /// a basic #GVariant value as a #gconstpointer
        /// </param>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern int g_variant_hash(
            /* <type name="Variant" type="gconstpointer" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Generates a hash value for a #GVariant instance.
        /// </summary>
        /// <remarks>
        /// The output of this function is guaranteed to be the same for a given
        /// value only per-process.  It may change between different processor
        /// architectures or even different versions of GLib.  Do not use this
        /// function as a basis for building protocols or file formats.
        ///
        /// The type of @value is #gconstpointer only to allow use of this
        /// function with #GHashTable.  @value must be a #GVariant.
        /// </remarks>
        /// <returns>
        /// a hash value corresponding to @value
        /// </returns>
        [Since("2.24")]
        public override int GetHashCode()
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var ret = g_variant_hash(value_);
            GMarshal.PopUnhandledException();
            return ret;
        }

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_is_container(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Checks if @value is a container.
        /// </summary>
        /// <returns>
        /// %TRUE if @value is a container
        /// </returns>
        [Since("2.24")]
        public bool IsContainer {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_is_container(value_);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        ///
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_is_normal_form(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Checks if @value is in normal form.
        /// </summary>
        /// <remarks>
        /// The main reason to do this is to detect if a given chunk of
        /// serialised data is in normal form: load the data into a #GVariant
        /// using g_variant_new_from_data() and then use this function to
        /// check.
        ///
        /// If @value is found to be in normal form then it will be marked as
        /// being trusted.  If the value was already marked as being trusted then
        /// this function will immediately return %TRUE.
        /// </remarks>
        /// <returns>
        /// %TRUE if @value is in normal form
        /// </returns>
        [Since("2.24")]
        public bool IsNormalForm {
            get {
                var value_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_variant_is_normal_form(value_);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="value">
        /// a #GVariant instance
        /// </param>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_is_of_type(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            VariantType.UnmanagedStruct* type);

        /// <summary>
        /// Checks if a value has a type matching the provided type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if the type of @value matches @type
        /// </returns>
        [Since("2.24")]
        public bool IsOfType(VariantType type)
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var type_ = (VariantType.UnmanagedStruct*)type.UnsafeHandle;
            var ret_ = g_variant_is_of_type(value_, type_);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
            return ret;
        }

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        ///
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        ///
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        ///
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        ///
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="dictionary">
        /// a dictionary #GVariant
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
        [Since("2.28")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
        /* transfer-ownership:full */
        static extern UnmanagedStruct* g_variant_lookup_value(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* dictionary,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            byte* key,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            VariantType.UnmanagedStruct* expectedType);

        /// <summary>
        /// Looks up a value in a dictionary #GVariant.
        /// </summary>
        /// <remarks>
        /// This function works with dictionaries of the type a{s*} (and equally
        /// well with type a{o*}, but we only further discuss the string case
        /// for sake of clarity).
        ///
        /// In the event that @dictionary has the type a{sv}, the @expected_type
        /// string specifies what type of value is expected to be inside of the
        /// variant. If the value inside the variant has a different type then
        /// %NULL is returned. In the event that @dictionary has a value type other
        /// than v then @expected_type must directly match the key type and it is
        /// used to unpack the value directly or an error occurs.
        ///
        /// In either case, if @key is not found in @dictionary, %NULL is returned.
        ///
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        ///
        /// This function is currently implemented with a linear scan.  If you
        /// plan to do many lookups then #GVariantDict may be more efficient.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [Since("2.28")]
        public Variant LookupValue(UnownedUtf8 key, VariantType? expectedType)
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var key_ = (byte*)key.UnsafeHandle;
            var expectedType_ = (VariantType.UnmanagedStruct*)(expectedType?.UnsafeHandle ?? IntPtr.Zero);
            var ret_ = g_variant_lookup_value(value_, key_, expectedType_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<Variant>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        ///
        /// This function is O(1).
        /// </remarks>
        /// <param name="value">
        /// a container #GVariant
        /// </param>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern nuint g_variant_n_children(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value);

        /// <summary>
        /// Determines the number of children in a container #GVariant instance.
        /// This includes variants, maybes, arrays, tuples and dictionary
        /// entries.  It is an error to call this function on any other type of
        /// #GVariant.
        /// </summary>
        /// <remarks>
        /// For variants, the return value is always 1.  For values with maybe
        /// types, it is always zero or one.  For arrays, it is the length of the
        /// array.  For tuples it is the number of tuple items (which depends
        /// only on the type).  For dictionary entries, it is always 2
        ///
        /// This function is O(1).
        /// </remarks>
        /// <returns>
        /// the number of children in the container
        /// </returns>
        [Since("2.24")]
        int NChildren()
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_n_children(value_);
            GMarshal.PopUnhandledException();
            return (int)ret_;
        }

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        ///
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern byte* g_variant_print(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            Runtime.Boolean typeAnnotate);

        /// <summary>
        /// Pretty-prints @value in the format understood by g_variant_parse().
        /// </summary>
        /// <remarks>
        /// The format is described [here][gvariant-text].
        ///
        /// If @type_annotate is %TRUE, then type information is included in
        /// the output.
        /// </remarks>
        /// <param name="typeAnnotate">
        /// %TRUE if type information should be included in
        ///                 the output
        /// </param>
        /// <returns>
        /// a newly-allocated string holding the result.
        /// </returns>
        [Since("2.24")]
        public Utf8 Print(bool typeAnnotate)
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            var typeAnnotate_ = typeAnnotate.ToBoolean();
            var ret_ = g_variant_print(value_, typeAnnotate_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<Utf8>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Stores the serialised form of @value at @data.  @data should be
        /// large enough.  See g_variant_get_size().
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// g_variant_get_normal_form() for a solution.
        ///
        /// As with g_variant_get_data(), to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        ///
        /// This function is approximately O(n) in the size of @data.
        /// </remarks>
        /// <param name="value">
        /// the #GVariant to store
        /// </param>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_store(
            /* <type name="Variant" type="GVariant*" managed-name="Variant" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* value,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            void* data);

        /// <summary>
        /// Stores the serialised form of this value value in <paramref name="data" />.
        /// <paramref name="data" /> should be large enough. See <see cref="Size" />.
        /// </summary>
        /// <remarks>
        /// The stored data is in machine native byte order but may not be in
        /// fully-normalised form if read from an untrusted source.  See
        /// <see cref="NormalForm" /> for a solution.
        ///
        /// As with <see cref="Data" />, to be able to deserialise the
        /// serialised variant successfully, its type and (if the destination
        /// machine might be different) its endianness must also be available.
        ///
        /// This function is approximately O(n) in the size of <paramref name="data" />.
        /// </remarks>
        /// <param name="data">
        /// the location to store the serialised data at
        /// </param>
        [Since("2.24")]
        public void Store(Span<byte> data)
        {
            var value_ = (UnmanagedStruct*)UnsafeHandle;
            if (data.Length < (int)g_variant_get_size(value_)) {
                throw new ArgumentException("Not large enough", nameof(data));
            }
            fixed (void* data_ = data) {
                g_variant_store(value_, data_);
                GMarshal.PopUnhandledException();
            }
        }

        private IEnumerator<Variant> GetEnumerator() => new VariantIter(this);
        IEnumerator<Variant> IEnumerable<Variant>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6, out Variant v7)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
            v7 = ChildValues[6];
        }

        /// <summary>
        /// Deconstruct as tuple.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out Variant v1, out Variant v2, out Variant v3, out Variant v4, out Variant v5, out Variant v6, out Variant v7, out Variant v8)
        {
            v1 = ChildValues[0];
            v2 = ChildValues[1];
            v3 = ChildValues[2];
            v4 = ChildValues[3];
            v5 = ChildValues[4];
            v6 = ChildValues[5];
            v7 = ChildValues[6];
            v8 = ChildValues[7];
        }
    }
}
