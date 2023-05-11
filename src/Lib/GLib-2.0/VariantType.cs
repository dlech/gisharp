// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class VariantType
    {
        // these static properties take the place of the G_VARIANT_TYPE_* macros

        /// <summary>
        /// The type of a value that can be either <c>true</c> or <c>false</c>.
        /// </summary>
        public static VariantType Boolean => new(boolean);
        readonly static Utf8 boolean = "b";

        /// <summary>
        /// The type of an integer value that can range from 0 to 255.
        /// </summary>
        public static VariantType Byte => new(@byte);
        readonly static Utf8 @byte = "y";

        /// <summary>
        /// The type of an integer value that can range from -32768 to 32767.
        /// </summary>
        public static VariantType Int16 => new(int16);
        readonly static Utf8 int16 = "n";

        /// <summary>
        /// The type of an integer value that can range from 0 to 65535.
        /// </summary>
        /// <remarks>
        /// There were about this many people living in Toronto in the 1870s.
        /// </remarks>
        public static VariantType UInt16 => new(uint16);
        readonly static Utf8 uint16 = "q";

        /// <summary>
        /// The type of an integer value that can range from -2147483648 to 2147483647.
        /// </summary>
        public static VariantType Int32 => new(int32);
        readonly static Utf8 int32 = "i";

        /// <summary>
        /// The type of an integer value that can range from 0 to 4294967295.
        /// </summary>
        /// <remarks>
        /// That's one number for everyone who was around in the late 1970s.
        /// </remarks>
        public static VariantType UInt32 => new(uint32);
        readonly static Utf8 uint32 = "u";

        /// <summary>
        /// The type of an integer value that can range from -9223372036854775808 to 9223372036854775807.
        /// </summary>
        public static VariantType Int64 => new(int64);
        readonly static Utf8 int64 = "x";

        /// <summary>
        /// The type of an integer value that can range from 0 to 18446744073709551615 (inclusive).
        /// </summary>
        /// <remarks>
        /// That's a really big number, but a Rubik's cube can have a bit more
        /// than twice as many possible positions.
        /// </remarks>
        public static VariantType UInt64 => new(uint64);
        readonly static Utf8 uint64 = "t";

        /// <summary>
        /// The type of a 32-bit signed integer value, that by convention, is
        /// used as an index into an array of file descriptors that are sent
        /// alongside a D-Bus message.
        /// </summary>
        /// <remarks>
        /// If you are not interacting with D-Bus, then there is no reason to
        /// make use of this type.
        /// </remarks>
        public static VariantType DBusHandle => new(handle_);
        readonly static Utf8 handle_ = "h";

        /// <summary>
        /// The type of a double precision IEEE754 floating point number.
        /// </summary>
        /// <remarks>
        /// These guys go up to about 1.80e308 (plus and minus) but miss out on
        /// some numbers in between. In any case, that's far greater than the
        /// estimated number of fundamental particles in the observable universe.
        /// </remarks>
        public static VariantType Double => new(@double);
        readonly static Utf8 @double = "d";

        /// <summary>
        /// The type of a string.
        /// </summary>
        /// <remarks>
        /// <c>""</c> is a string. <c>null</c> is not a string.
        /// </remarks>
        public static VariantType String => new(@string);
        readonly static Utf8 @string = "s";

        /// <summary>
        /// The type of a D-Bus object reference.
        /// </summary>
        /// <remarks>
        /// These are strings of a specific format used to identify objects at
        /// a given destination on the bus.
        ///
        /// If you are not interacting with D-Bus, then there is no reason to
        /// make use of this type. If you are, then the D-Bus specification
        /// contains a precise description of valid object paths.
        /// </remarks>
        public static VariantType DBusObjectPath => new(objectPath);
        readonly static Utf8 objectPath = "o";

        /// <summary>
        /// The type of a D-Bus type signature.
        /// </summary>
        /// <remarks>
        /// These are strings of a specific format used as type signatures for
        /// D-Bus methods and messages.
        ///
        /// If you are not interacting with D-Bus, then there is no reason to
        /// make use of this type.If you are, then the D-Bus specification
        /// contains a precise description of valid signature strings.
        /// </remarks>
        public static VariantType DBusSignature => new(signature);
        readonly static Utf8 signature = "g";

        /// <summary>
        /// The type of a box that contains any other value (including another variant).
        /// </summary>
        public static VariantType Variant => new(variant);
        readonly static Utf8 variant = "v";

        /// <summary>
        /// An indefinite type that is a supertype of every type (including itself).
        /// </summary>
        public static VariantType Any => new(any);
        readonly static Utf8 any = "*";

        /// <summary>
        /// An indefinite type that is a supertype of every basic (ie: non-container) type.
        /// </summary>
        public static VariantType Basic => new(basic);
        readonly static Utf8 basic = "?";

        /// <summary>
        /// An indefinite type that is a supertype of every maybe type.
        /// </summary>
        public static VariantType Maybe => new(maybe);
        readonly static Utf8 maybe = "m*";

        /// <summary>
        /// An indefinite type that is a supertype of every array type.
        /// </summary>
        public static VariantType Array => new(array);
        readonly static Utf8 array = "a*";

        /// <summary>
        /// An indefinite type that is a supertype of every tuple type, regardless of the number of items in the tuple.
        /// </summary>
        public static VariantType Tuple => new(tuple);
        readonly static Utf8 tuple = "r";

        /// <summary>
        /// The empty tuple type. Has only one instance. Known also as "triv" or "void".
        /// </summary>
        public static VariantType Unit => new(unit);
        readonly static Utf8 unit = "()";

        /// <summary>
        /// An indefinite type that is a supertype of every dictionary entry type.
        /// </summary>
        public static VariantType DictionaryEntry => new(dictEntry);
        readonly static Utf8 dictEntry = "{?*}";

        /// <summary>
        /// An indefinite type that is a supertype of every dictionary type.
        /// </summary>
        /// <remarks>
        /// That is, any array type that has an element type equal to any
        /// dictionary entry type.
        /// </remarks>
        public static VariantType Dictionary => new(dictionary);
        readonly static Utf8 dictionary = "a{?*}";

        /// <summary>
        /// The type of an array of strings.
        /// </summary>
        public static VariantType StringArray => new(stringArray);
        readonly static Utf8 stringArray = "as";

        /// <summary>
        /// The type of an array of object paths.
        /// </summary>
        public static VariantType DBusObjectPathArray => new(objectPathArray);
        readonly static Utf8 objectPathArray = "ao";

        /// <summary>
        /// The type of an array of bytes.
        /// </summary>
        /// <remarks>
        /// This type is commonly used to pass around strings that may not be
        /// valid utf8. In that case, the convention is that the null terminator
        /// character should be included as the last character in the array.
        /// </remarks>
        public static VariantType ByteString => new(bytestring);
        readonly static Utf8 bytestring = "ay";

        /// <summary>
        /// The type of an array of byte strings (an array of arrays of bytes).
        /// </summary>
        public static VariantType ByteStringArray => new(bytestringArray);
        readonly static Utf8 bytestringArray = "aay";

        /// <summary>
        /// The type of a dictionary mapping strings to variants (the ubiquitous "a{sv}" type).
        /// </summary>
        [Since("2.30")]
        public static VariantType VariantDictionary => new(vardict);
        readonly static Utf8 vardict = "a{sv}";

        static partial void CheckNewArgs(UnownedUtf8 typeString)
        {
            if (!StringIsValid(typeString))
            {
                throw new ArgumentException("Invalid type string", nameof(typeString));
            }
        }

        /// <summary>
        /// Constructs a new tuple type, from <paramref name="items"/>.
        /// </summary>
        /// <param name="items">
        /// an array of <see cref="VariantType"/>s, one for each item
        /// </param>
        /// <returns>
        /// a new tuple <see cref="VariantType"/>
        /// </returns>
        public static VariantType NewTuple(params VariantType[] items)
        {
            using var itemsArray = items.ToWeakCPtrArray();
            return NewTuple(itemsArray);
        }

        /// <summary>
        /// Returns the type string corresponding to this type.
        /// </summary>
        /// <returns>
        /// the corresponding type string
        /// </returns>
        [Since("2.24")]
        public override string ToString()
        {
            var type_ = (UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_variant_type_peek_string(type_);
            var length_ = g_variant_type_get_string_length(type_);
            GMarshal.PopUnhandledException();
            var ret = Marshal.PtrToStringUTF8((IntPtr)ret_, (int)length_)!;
            return ret;
        }

        partial void CheckGetElementArgs()
        {
            if (!IsArray && !IsMaybe)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the items type of a tuple or dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// <see cref="Tuple"/>.
        ///
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        ///
        /// <c>null</c> is returned in case of this type being <see cref="Unit"/>.
        /// </remarks>
        /// <returns>
        /// the items type of this type type, or <c>null</c>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// if this type is not a tuple or a dictionary entry type
        /// </exception>
        [Since("2.24")]
        public IEnumerable<VariantType> Items => new ItemsEnumerable(this);

        private struct ItemsEnumerable : IEnumerable<VariantType>
        {
            private readonly VariantType type;

            public ItemsEnumerable(VariantType type)
            {
                var type_ = (UnmanagedStruct*)type.UnsafeHandle;
                if (
                    g_variant_type_is_tuple(type_).IsFalse()
                    && g_variant_type_is_dict_entry(type_).IsFalse()
                )
                {
                    throw new InvalidOperationException(
                        "only valid for tuple an dictionary entry types"
                    );
                }
                if (g_variant_type_equal(type_, (UnmanagedStruct*)Tuple.UnsafeHandle).IsTrue())
                {
                    throw new InvalidOperationException("only valid for non-generic tuple types");
                }
                this.type = type;
            }

            public IEnumerator<VariantType> GetEnumerator() => new ItemsEnumerator(type);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private struct ItemsEnumerator : IEnumerator<VariantType>
        {
            private readonly VariantType type;
            private UnmanagedStruct* current;

            public ItemsEnumerator(VariantType type)
            {
                this.type = type;
                current = null;
            }

            public VariantType Current
            {
                get
                {
                    if (type.handle == IntPtr.Zero)
                    {
                        throw new ObjectDisposedException(null);
                    }
                    if (current is null)
                    {
                        throw new InvalidOperationException();
                    }
                    return new VariantType((IntPtr)current, Transfer.None);
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (current is null)
                {
                    var type_ = (UnmanagedStruct*)type.UnsafeHandle;
                    current = g_variant_type_first(type_);
                }
                else
                {
                    if (type.handle == IntPtr.Zero)
                    {
                        throw new ObjectDisposedException(null);
                    }
                    current = g_variant_type_next(current);
                }

                return current is not null;
            }

            public void Reset()
            {
                current = null;
            }
        }

        partial void CheckGetKeyArgs()
        {
            if (!IsDictEntry)
            {
                throw new InvalidOperationException("only valid for dictionary entry types");
            }
        }

        partial void CheckGetItemCountArgs()
        {
            if (!IsTuple && !IsDictEntry)
            {
                throw new InvalidOperationException(
                    "only valid for tuple an dictionary entry types"
                );
            }
            if (this == Tuple)
            {
                throw new InvalidOperationException("only valid for non-generic tuple types");
            }
        }

        partial void CheckGetValueArgs()
        {
            if (!IsDictEntry)
            {
                throw new InvalidOperationException("only valid for dictionary entry types");
            }
        }
    }
}
