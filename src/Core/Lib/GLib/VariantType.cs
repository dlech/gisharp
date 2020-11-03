using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// This section introduces the GVariant type system. It is based, in
    /// large part, on the D-Bus type system, with two major changes and
    /// some minor lifting of restrictions. The
    /// [D-Bus specification](http://dbus.freedesktop.org/doc/dbus-specification.html),
    /// therefore, provides a significant amount of
    /// information that is useful when working with GVariant.
    /// </summary>
    /// <remarks>
    /// The first major change with respect to the D-Bus type system is the
    /// introduction of maybe (or "nullable") types.  Any type in GVariant can be
    /// converted to a maybe type, in which case, "nothing" (or "null") becomes a
    /// valid value.  Maybe types have been added by introducing the
    /// character "m" to type strings.
    ///
    /// The second major change is that the GVariant type system supports the
    /// concept of "indefinite types" -- types that are less specific than
    /// the normal types found in D-Bus.  For example, it is possible to speak
    /// of "an array of any type" in GVariant, where the D-Bus type system
    /// would require you to speak of "an array of integers" or "an array of
    /// strings".  Indefinite types have been added by introducing the
    /// characters "*", "?" and "r" to type strings.
    ///
    /// Finally, all arbitrary restrictions relating to the complexity of
    /// types are lifted along with the restriction that dictionary entries
    /// may only appear nested inside of arrays.
    ///
    /// Just as in D-Bus, GVariant types are described with strings ("type
    /// strings").  Subject to the differences mentioned above, these strings
    /// are of the same form as those found in DBus.  Note, however: D-Bus
    /// always works in terms of messages and therefore individual type
    /// strings appear nowhere in its interface.  Instead, "signatures"
    /// are a concatenation of the strings of the type of each argument in a
    /// message.  GVariant deals with single values directly so GVariant type
    /// strings always describe the type of exactly one value.  This means
    /// that a D-Bus signature string is generally not a valid GVariant type
    /// string -- except in the case that it is the signature of a message
    /// containing exactly one argument.
    ///
    /// An indefinite type is similar in spirit to what may be called an
    /// abstract type in other type systems.  No value can exist that has an
    /// indefinite type as its type, but values can exist that have types
    /// that are subtypes of indefinite types.  That is to say,
    /// g_variant_get_type() will never return an indefinite type, but
    /// calling g_variant_is_of_type() with an indefinite type may return
    /// %TRUE.  For example, you cannot have a value that represents "an
    /// array of no particular type", but you can have an "array of integers"
    /// which certainly matches the type of "an array of no particular type",
    /// since "array of integers" is a subtype of "array of no particular
    /// type".
    ///
    /// This is similar to how instances of abstract classes may not
    /// directly exist in other type systems, but instances of their
    /// non-abstract subtypes may.  For example, in GTK, no object that has
    /// the type of #GtkBin can exist (since #GtkBin is an abstract class),
    /// but a #GtkWindow can certainly be instantiated, and you would say
    /// that the #GtkWindow is a #GtkBin (since #GtkWindow is a subclass of
    /// #GtkBin).
    ///
    /// ## GVariant Type Strings
    ///
    /// A GVariant type string can be any of the following:
    ///
    /// - any basic type string (listed below)
    ///
    /// - "v", "r" or "*"
    ///
    /// - one of the characters 'a' or 'm', followed by another type string
    ///
    /// - the character '(', followed by a concatenation of zero or more other
    ///   type strings, followed by the character ')'
    ///
    /// - the character '{', followed by a basic type string (see below),
    ///   followed by another type string, followed by the character '}'
    ///
    /// A basic type string describes a basic type (as per
    /// g_variant_type_is_basic()) and is always a single character in length.
    /// The valid basic type strings are "b", "y", "n", "q", "i", "u", "x", "t",
    /// "h", "d", "s", "o", "g" and "?".
    ///
    /// The above definition is recursive to arbitrary depth. "aaaaai" and
    /// "(ui(nq((y)))s)" are both valid type strings, as is
    /// "a(aa(ui)(qna{ya(yd)}))".
    ///
    /// The meaning of each of the characters is as follows:
    /// - `b`: the type string of %G_VARIANT_TYPE_BOOLEAN; a boolean value.
    /// - `y`: the type string of %G_VARIANT_TYPE_BYTE; a byte.
    /// - `n`: the type string of %G_VARIANT_TYPE_INT16; a signed 16 bit integer.
    /// - `q`: the type string of %G_VARIANT_TYPE_UINT16; an unsigned 16 bit integer.
    /// - `i`: the type string of %G_VARIANT_TYPE_INT32; a signed 32 bit integer.
    /// - `u`: the type string of %G_VARIANT_TYPE_UINT32; an unsigned 32 bit integer.
    /// - `x`: the type string of %G_VARIANT_TYPE_INT64; a signed 64 bit integer.
    /// - `t`: the type string of %G_VARIANT_TYPE_UINT64; an unsigned 64 bit integer.
    /// - `h`: the type string of %G_VARIANT_TYPE_HANDLE; a signed 32 bit value
    ///   that, by convention, is used as an index into an array of file
    ///   descriptors that are sent alongside a D-Bus message.
    /// - `d`: the type string of %G_VARIANT_TYPE_DOUBLE; a double precision
    ///   floating point value.
    /// - `s`: the type string of %G_VARIANT_TYPE_STRING; a string.
    /// - `o`: the type string of %G_VARIANT_TYPE_OBJECT_PATH; a string in the form
    ///   of a D-Bus object path.
    /// - `g`: the type string of %G_VARIANT_TYPE_STRING; a string in the form of
    ///   a D-Bus type signature.
    /// - `?`: the type string of %G_VARIANT_TYPE_BASIC; an indefinite type that
    ///   is a supertype of any of the basic types.
    /// - `v`: the type string of %G_VARIANT_TYPE_VARIANT; a container type that
    ///   contain any other type of value.
    /// - `a`: used as a prefix on another type string to mean an array of that
    ///   type; the type string "ai", for example, is the type of an array of
    ///   signed 32-bit integers.
    /// - `m`: used as a prefix on another type string to mean a "maybe", or
    ///   "nullable", version of that type; the type string "ms", for example,
    ///   is the type of a value that maybe contains a string, or maybe contains
    ///   nothing.
    /// - `()`: used to enclose zero or more other concatenated type strings to
    ///   create a tuple type; the type string "(is)", for example, is the type of
    ///   a pair of an integer and a string.
    /// - `r`: the type string of %G_VARIANT_TYPE_TUPLE; an indefinite type that is
    ///   a supertype of any tuple type, regardless of the number of items.
    /// - `{}`: used to enclose a basic type string concatenated with another type
    ///   string to create a dictionary entry type, which usually appears inside of
    ///   an array to form a dictionary; the type string "a{sd}", for example, is
    ///   the type of a dictionary that maps strings to double precision floating
    ///   point values.
    ///
    ///   The first type (the basic type) is the key type and the second type is
    ///   the value type. The reason that the first type is restricted to being a
    ///   basic type is so that it can easily be hashed.
    /// - `*`: the type string of %G_VARIANT_TYPE_ANY; the indefinite type that is
    ///   a supertype of all types.  Note that, as with all type strings, this
    ///   character represents exactly one type. It cannot be used inside of tuples
    ///   to mean "any number of items".
    ///
    /// Any type string of a container that contains an indefinite type is,
    /// itself, an indefinite type. For example, the type string "a*"
    /// (corresponding to %G_VARIANT_TYPE_ARRAY) is an indefinite type
    /// that is a supertype of every array type. "(*s)" is a supertype
    /// of all tuples that contain exactly two items where the second
    /// item is a string.
    ///
    /// "a{?*}" is an indefinite type that is a supertype of all arrays
    /// containing dictionary entries where the key is any basic type and
    /// the value is any type at all.  This is, by definition, a dictionary,
    /// so this type string corresponds to %G_VARIANT_TYPE_DICTIONARY. Note
    /// that, due to the restriction that the key of a dictionary entry must
    /// be a basic type, "{**}" is not a valid type string.
    /// </remarks>
    [GType("GVariantType", IsProxyForUnmanagedType = true)]
    public sealed class VariantType : Boxed, IEquatable<VariantType>
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_variant_type_copy(IntPtr type);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VariantType(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_variant_type_free(IntPtr type);

        // these static properties take the place of the G_VARIANT_TYPE_* macros

        /// <summary>
        /// The type of a value that can be either <c>true</c> or <c>false</c>.
        /// </summary>
        public static VariantType Boolean => new VariantType(boolean);
        readonly static Utf8 boolean = "b";

        /// <summary>
        /// The type of an integer value that can range from 0 to 255.
        /// </summary>
        public static VariantType Byte => new VariantType(@byte);
        readonly static Utf8 @byte = "y";

        /// <summary>
        /// The type of an integer value that can range from -32768 to 32767.
        /// </summary>
        public static VariantType Int16 => new VariantType(int16);
        readonly static Utf8 int16 = "n";

        /// <summary>
        /// The type of an integer value that can range from 0 to 65535.
        /// </summary>
        /// <remarks>
        /// There were about this many people living in Toronto in the 1870s.
        /// </remarks>
        public static VariantType UInt16 => new VariantType(uint16);
        readonly static Utf8 uint16 = "q";

        /// <summary>
        /// The type of an integer value that can range from -2147483648 to 2147483647.
        /// </summary>
        public static VariantType Int32 => new VariantType(int32);
        readonly static Utf8 int32 = "i";

        /// <summary>
        /// The type of an integer value that can range from 0 to 4294967295.
        /// </summary>
        /// <remarks>
        /// That's one number for everyone who was around in the late 1970s.
        /// </remarks>
        public static VariantType UInt32 => new VariantType(uint32);
        readonly static Utf8 uint32 = "u";

        /// <summary>
        /// The type of an integer value that can range from -9223372036854775808 to 9223372036854775807.
        /// </summary>
        public static VariantType Int64 => new VariantType(int64);
        readonly static Utf8 int64 = "x";

        /// <summary>
        /// The type of an integer value that can range from 0 to 18446744073709551615 (inclusive).
        /// </summary>
        /// <remarks>
        /// That's a really big number, but a Rubik's cube can have a bit more
        /// than twice as many possible positions.
        /// </remarks>
        public static VariantType UInt64 => new VariantType(uint64);
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
        public static VariantType DBusHandle => new VariantType(handle_);
        readonly static Utf8 handle_ = "h";

        /// <summary>
        /// The type of a double precision IEEE754 floating point number.
        /// </summary>
        /// <remarks>
        /// These guys go up to about 1.80e308 (plus and minus) but miss out on
        /// some numbers in between. In any case, that's far greater than the
        /// estimated number of fundamental particles in the observable universe.
        /// </remarks>
        public static VariantType Double => new VariantType(@double);
        readonly static Utf8 @double = "d";

        /// <summary>
        /// The type of a string.
        /// </summary>
        /// <remarks>
        /// <c>""</c> is a string. <c>null</c> is not a string.
        /// </remarks>
        public static VariantType String => new VariantType(@string);
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
        public static VariantType DBusObjectPath => new VariantType(objectPath);
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
        public static VariantType DBusSignature => new VariantType(signature);
        readonly static Utf8 signature = "g";

        /// <summary>
        /// The type of a box that contains any other value (including another variant).
        /// </summary>
        public static VariantType Variant => new VariantType(variant);
        readonly static Utf8 variant = "v";

        /// <summary>
        /// An indefinite type that is a supertype of every type (including itself).
        /// </summary>
        public static VariantType Any => new VariantType(any);
        readonly static Utf8 any = "*";

        /// <summary>
        /// An indefinite type that is a supertype of every basic (ie: non-container) type.
        /// </summary>
        public static VariantType Basic => new VariantType(basic);
        readonly static Utf8 basic = "?";

        /// <summary>
        /// An indefinite type that is a supertype of every maybe type.
        /// </summary>
        public static VariantType Maybe => new VariantType(maybe);
        readonly static Utf8 maybe = "m*";

        /// <summary>
        /// An indefinite type that is a supertype of every array type.
        /// </summary>
        public static VariantType Array => new VariantType(array);
        readonly static Utf8 array = "a*";

        /// <summary>
        /// An indefinite type that is a supertype of every tuple type, regardless of the number of items in the tuple.
        /// </summary>
        public static VariantType Tuple => new VariantType(tuple);
        readonly static Utf8 tuple = "r";

        /// <summary>
        /// The empty tuple type. Has only one instance. Known also as "triv" or "void".
        /// </summary>
        public static VariantType Unit => new VariantType(unit);
        readonly static Utf8 unit = "()";

        /// <summary>
        /// An indefinite type that is a supertype of every dictionary entry type.
        /// </summary>
        public static VariantType DictionaryEntry => new VariantType(dictEntry);
        readonly static Utf8 dictEntry = "{?*}";

        /// <summary>
        /// An indefinite type that is a supertype of every dictionary type.
        /// </summary>
        /// <remarks>
        /// That is, any array type that has an element type equal to any
        /// dictionary entry type.
        /// </remarks>
        public static VariantType Dictionary => new VariantType(dictionary);
        readonly static Utf8 dictionary = "a{?*}";

        /// <summary>
        /// The type of an array of strings.
        /// </summary>
        public static VariantType StringArray => new VariantType(stringArray);
        readonly static Utf8 stringArray = "as";

        /// <summary>
        /// The type of an array of object paths.
        /// </summary>
        public static VariantType DBusObjectPathArray => new VariantType(objectPathArray);
        readonly static Utf8 objectPathArray = "ao";

        /// <summary>
        /// The type of an array of bytes.
        /// </summary>
        /// <remarks>
        /// This type is commonly used to pass around strings that may not be
        /// valid utf8. In that case, the convention is that the null terminator
        /// character should be included as the last character in the array.
        /// </remarks>
        public static VariantType ByteString => new VariantType(bytestring);
        readonly static Utf8 bytestring = "ay";

        /// <summary>
        /// The type of an array of byte strings (an array of arrays of bytes).
        /// </summary>
        public static VariantType ByteStringArray => new VariantType(bytestringArray);
        readonly static Utf8 bytestringArray = "aay";

        /// <summary>
        /// The type of a dictionary mapping strings to variants (the ubiquitous "a{sv}" type).
        /// </summary>
        [Since("2.30")]
        public static VariantType VariantDictionary => new VariantType(vardict);
        readonly static Utf8 vardict = "a{sv}";

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_variant_type_get_gtype();

        static readonly GType _GType = g_variant_type_get_gtype();

        /// <summary>
        /// Creates a new #GVariantType corresponding to the type string given
        /// by @type_string.  It is appropriate to call g_variant_type_free() on
        /// the return value.
        /// </summary>
        /// <remarks>
        /// It is a programmer error to call this function with an invalid type
        /// string.  Use g_variant_type_string_is_valid() if you are unsure.
        /// </remarks>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeString);

        /// <summary>
        /// Creates a new <see cref="VariantType"/> corresponding to the type
        /// string given by <paramref name="typeString"/>.
        /// </summary>
        /// <param name="typeString">
        /// a valid GVariant type string
        /// </param>
        /// <returns>
        /// a new #GVariantType
        /// </returns>
        [Since("2.24")]
        static IntPtr New(UnownedUtf8 typeString)
        {
            if (!StringIsValid(typeString)) {
                throw new ArgumentException("Invalid type string", nameof(typeString));
            }
            var ret = g_variant_type_new(typeString.Handle);
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="VariantType"/> corresponding to the type
        /// string given by <paramref name="typeString"/>.
        /// </summary>
        /// <param name="typeString">
        /// a valid Variant type string
        /// </param>
        /// <exception cref="ArgumentException">
        /// if <paramref name="typeString"/> is not a valid type string
        /// </exception>
        [Since("2.24")]
        public VariantType(UnownedUtf8 typeString) : this(New(typeString), Transfer.Full)
        {
        }

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type @type.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new array #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_array(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr element);

        /// <summary>
        /// Constructs the type corresponding to an array of elements of the
        /// type <paramref name="element"/>
        /// </summary>
        /// <param name="element">
        /// a <see cref="VariantType"/>
        /// </param>
        /// <returns>
        /// a new array <see cref="VariantType"/>
        /// </returns>
        [Since("2.24")]
        public static VariantType CreateArray(VariantType element)
        {
            var ret_ = g_variant_type_new_array(element.Handle);
            var ret = new VariantType(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type @key and a value of type @value.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="key">
        /// a basic #GVariantType
        /// </param>
        /// <param name="value">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new dictionary entry #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_dict_entry(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr key,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr value);

        /// <summary>
        /// Constructs the type corresponding to a dictionary entry with a key
        /// of type <paramref name="key"/> and a value of type <paramref name="value"/>.
        /// </summary>
        /// <param name="key">
        /// a basic <see cref="VariantType"/>
        /// </param>
        /// <param name="value">
        /// a <see cref="VariantType"/>
        /// </param>
        /// <returns>
        /// a new dictionary entry <see cref="VariantType"/>
        /// </returns>
        [Since("2.24")]
        public static VariantType CreateDictEntry(VariantType key, VariantType value)
        {
            var ret_ = g_variant_type_new_dict_entry(key.Handle, value.Handle);
            var ret = new VariantType(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type @type or Nothing.
        /// </summary>
        /// <remarks>
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="element">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// a new maybe #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_maybe(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr element);

        /// <summary>
        /// Constructs the type corresponding to a maybe instance containing
        /// type <paramref name="element"/> or Nothing.
        /// </summary>
        /// <param name="element">
        /// a <see cref="VariantType"/>
        /// </param>
        /// <returns>
        /// a new maybe <see cref="VariantType"/>
        /// </returns>
        [Since("2.24")]
        public static VariantType CreateMaybe(VariantType element)
        {
            var ret_ = g_variant_type_new_maybe(element.Handle);
            var ret = new VariantType(ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Constructs a new tuple type, from @items.
        /// </summary>
        /// <remarks>
        /// @length is the number of items in @items, or -1 to indicate that
        /// @items is %NULL-terminated.
        ///
        /// It is appropriate to call g_variant_type_free() on the return value.
        /// </remarks>
        /// <param name="items">
        /// an array of #GVariantTypes, one for each item
        /// </param>
        /// <param name="length">
        /// the length of @items, or -1
        /// </param>
        /// <returns>
        /// a new tuple #GVariantType
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_tuple(
            /* <array length="1" zero-terminated="0" type="GVariantType**">
                <type name="VariantType" type="GVariantType*" managed-name="VariantType" />
                </array> */
            /* transfer-ownership:none */
            in IntPtr items,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int length);

        /// <summary>
        /// Constructs a new tuple type, from <paramref name="items"/>.
        /// </summary>
        /// <param name="items">
        /// an array of <see cref="VariantType"/>s, one for each item
        /// </param>
        /// <returns>
        /// a new tuple <see cref="VariantType"/>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// if any element of <paramref name="items"/> is <c>null</c>
        /// </exception>
        [Since("2.24")]
        private static VariantType NewTuple(ReadOnlySpan<IntPtr> items)
        {
            ref readonly var items_ = ref MemoryMarshal.GetReference(items);
            var length_ = items.Length;
            var ret_ = g_variant_type_new_tuple(items_, length_);
            var ret = new VariantType(ret_, Transfer.Full);
            return ret;
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
        /// <exception cref="ArgumentException">
        /// if any element of <paramref name="items"/> is <c>null</c>
        /// </exception>
        [Since("2.24")]
        public static VariantType CreateTuple(UnownedCPtrArray<VariantType> items)
        {
            return NewTuple(items.Data);
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
        /// <exception cref="ArgumentException">
        /// if any element of <paramref name="items"/> is <c>null</c>
        /// </exception>
        [Since("2.24")]
        public static VariantType CreateTuple(params VariantType[] items)
        {
            ReadOnlySpan<IntPtr> array = items.Select(x => x.Handle).ToArray();
            var ret = NewTuple(array);
            GC.KeepAlive(items);
            return ret;
        }

        /// <summary>
        /// Checks if @type_string is a valid GVariant type string.  This call is
        /// equivalent to calling g_variant_type_string_scan() and confirming
        /// that the following character is a nul terminator.
        /// </summary>
        /// <param name="typeString">
        /// a pointer to any string
        /// </param>
        /// <returns>
        /// %TRUE if @type_string is exactly one valid type string
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_string_is_valid(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeString);

        /// <summary>
        /// Checks if <paramref name="typeString"/> is a valid <see cref="GLib.Variant"/>
        /// type string.
        /// </summary>
        /// <param name="typeString">
        /// any string
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="typeString"/> is exactly one valid type string
        /// </returns>
        [Since("2.24")]
        public static bool StringIsValid(UnownedUtf8 typeString)
        {
            var typeString_ = typeString.Handle;
            var ret = g_variant_type_string_is_valid(typeString_);
            return ret;
        }

        /// <summary>
        /// Scan for a single complete and valid GVariant type string in @string.
        /// The memory pointed to by @limit (or bytes beyond it) is never
        /// accessed.
        /// </summary>
        /// <remarks>
        /// If a valid type string is found, @endptr is updated to point to the
        /// first character past the end of the string that was found and %TRUE
        /// is returned.
        ///
        /// If there is no valid type string starting at @string, or if the type
        /// string does not end before @limit then %FALSE is returned.
        ///
        /// For the simple case of checking if a string is a valid type string,
        /// see g_variant_type_string_is_valid().
        /// </remarks>
        /// <param name="string">
        /// a pointer to any string
        /// </param>
        /// <param name="limit">
        /// the end of @string, or %NULL
        /// </param>
        /// <param name="endptr">
        /// location to store the end pointer, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if a valid type string was found
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern unsafe Runtime.Boolean g_variant_type_string_scan(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr @string,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr limit,
            /* <type name="utf8" type="const gchar**" managed-name="Utf8" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            IntPtr* endptr);

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_dup_string(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Returns the type string corresponding to this type.
        /// </summary>
        /// <returns>
        /// the corresponding type string
        /// </returns>
        [Since("2.24")]
        public unsafe override string ToString()
        {
            var this_ = Handle;
            var ret_ = g_variant_type_peek_string(this_);
            var length_ = g_variant_type_get_string_length(this_);
            var ret = System.Text.Encoding.UTF8.GetString((byte*)ret_, (int)length_);
            return ret;
        }

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <param name="type">
        /// an array or maybe #GVariantType
        /// </param>
        /// <returns>
        /// the element type of @type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_element(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This property may only be used with array or maybe types.
        /// </remarks>
        /// <returns>
        /// the element type of @type
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// if this type is not an array or maybe type
        /// </exception>
        [Since("2.24")]
        public VariantType ElementType {
            get {
                var this_ = Handle;
                if (!g_variant_type_is_array(this_) && !g_variant_type_is_maybe(this_)) {
                    throw new InvalidOperationException();
                }
                var ret_ = g_variant_type_element(this_);
                var ret = new VariantType(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Compares @type1 and @type2 for equality.
        /// </summary>
        /// <remarks>
        /// Only returns %TRUE if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, %FALSE will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use g_variant_type_is_subtype_of().
        ///
        /// The argument types of @type1 and @type2 are only #gconstpointer to
        /// allow use with #GHashTable without function pointer casting.  For
        /// both arguments, a valid #GVariantType must be provided.
        /// </remarks>
        /// <param name="type1">
        /// a #GVariantType
        /// </param>
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_equal(
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type1,
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type2);

        /// <summary>
        /// Compares this type and <paramref name="other"/> for equality.
        /// </summary>
        /// <remarks>
        /// Only returns <c>true</c> if the types are exactly equal.  Even if one type
        /// is an indefinite type and the other is a subtype of it, <c>false</c> will
        /// be returned if they are not exactly equal.  If you want to check for
        /// subtypes, use <see cref="IsSubtypeOf"/>.
        /// </remarks>
        /// <param name="other">
        /// a <see cref="VariantType"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if this type and <paramref name="other"/> are exactly equal
        /// </returns>
        [Since("2.24")]
        public bool Equals(VariantType other)
        {
            var this_ = Handle;
            var other_ = other.Handle;
            var ret = g_variant_type_equal(this_, other_);
            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj is VariantType type2) {
                return Equals(type2);
            }
            return base.Equals(obj);
        }

        public static bool operator ==(VariantType? one, VariantType? two)
        {
            return object.Equals(one, two);
        }

        public static bool operator !=(VariantType? one, VariantType? two)
        {
            return !object.Equals(one, two);
        }

        /// <summary>
        /// Determines the first item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        ///
        /// In the case of a dictionary entry type, this returns the type of
        /// the key.
        ///
        /// %NULL is returned in case of @type being %G_VARIANT_TYPE_UNIT.
        ///
        /// This call, together with g_variant_type_next() provides an iterator
        /// interface over tuple and dictionary entry types.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the first item type of @type, or %NULL
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_first(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

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
        public IEnumerable<VariantType> Items {
            get {
                var this_ = Handle;
                if (!g_variant_type_is_tuple(this_) && !g_variant_type_is_dict_entry(this_)) {
                    throw new InvalidOperationException("only valid for tuple an dictionary entry types");
                }
                if (g_variant_type_equal(this_, Tuple.Handle)) {
                    throw new InvalidOperationException("only valid for non-generic tuple types");
                }
                for (var ret_ = g_variant_type_first(this_); ret_ != IntPtr.Zero; ret_ = g_variant_type_next(ret_)) {
                    var ret = new VariantType(ret_, Transfer.None);
                    yield return ret;
                }
            }
        }

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the length of the corresponding type string
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern UIntPtr g_variant_type_get_string_length(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the hash value
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_variant_type_hash(
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Hashes this variant type.
        /// </summary>
        /// <returns>
        /// the hash value
        /// </returns>
        [Since("2.24")]
        public override int GetHashCode()
        {
            var ret = g_variant_type_hash(Handle);
            return (int)ret;
        }

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is an array type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_array(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is an array type.  This is true if the
        /// type string for this type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns <c>true</c> for any indefinite type for which every
        /// definite subtype is an array type -- <see cref="Array"/>, for
        /// example.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this variant type is an array type
        /// </returns>
        [Since("2.24")]
        public bool IsArray {
            get {
                var ret = g_variant_type_is_array(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        ///
        /// Only a basic type may be used as the key of a dictionary entry.
        ///
        /// This function returns %FALSE for all indefinite types except
        /// %G_VARIANT_TYPE_BASIC.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a basic type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_basic(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is a basic type.
        /// </summary>
        /// <remarks>
        /// Basic types are booleans, bytes, integers, doubles, strings, object
        /// paths and signatures.
        ///
        /// Only a basic type may be used as the key of a dictionary entry.
        ///
        /// This function returns <c>false</c> for all indefinite types except
        /// <see cref="Basic"/>.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this variant type is a basic type
        /// </returns>
        [Since("2.24")]
        public bool IsBasic {
            get {
                var ret = g_variant_type_is_basic(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        ///
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a container -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a container type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_container(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is a container type.
        /// </summary>
        /// <remarks>
        /// Container types are any array, maybe, tuple, or dictionary
        /// entry types plus the variant type.
        ///
        /// This function returns <c>true</c> for any indefinite type for which every
        /// definite subtype is a container -- <see cref="Array"/>, for
        /// example.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this variant type is a container type
        /// </returns>
        [Since("2.24")]
        public bool IsContainer {
            get {
                var ret = g_variant_type_is_container(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is definite (ie: not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        ///
        /// A #GVariant instance may not have an indefinite type, so calling
        /// this function on the result of g_variant_get_type() will always
        /// result in %TRUE being returned.  Calling this function on an
        /// indefinite type like %G_VARIANT_TYPE_ARRAY, however, will result in
        /// %FALSE being returned.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is definite
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_definite(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is definite (i.e. not indefinite).
        /// </summary>
        /// <remarks>
        /// A type is definite if its type string does not contain any indefinite
        /// type characters ('*', '?', or 'r').
        ///
        /// A <see cref="Variant"/> instance may not have an indefinite type, so getting
        /// this property on the result of <see cref="Variant.Type"/> will always
        /// result in <c>true</c> being returned.  Getting this property on an
        /// indefinite type like <see cref="Array"/>, however, will result in
        /// <c>false</c> being returned.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this type is definite
        /// </returns>
        [Since("2.24")]
        public bool IsDefinite {
            get {
                var ret = g_variant_type_is_definite(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_dict_entry(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is a dictionary entry type.  This is
        /// true if the type string for this type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns <c>true</c> for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// <see cref="DictionaryEntry"/>, for example.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this type is a dictionary entry type
        /// </returns>
        [Since("2.24")]
        public bool IsDictionaryEntry {
            get {
                var ret = g_variant_type_is_dict_entry(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a maybe type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_maybe(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is a maybe type.  This is true if the
        /// type string for this type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns <c>true</c> for any indefinite type for which every
        /// definite subtype is a maybe type -- <see cref="Maybe"/>, for
        /// example.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this variant type is a maybe type
        /// </returns>
        [Since("2.24")]
        public bool IsMaybe {
            get {
                var ret = g_variant_type_is_maybe(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_subtype_of(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr supertype);

        /// <summary>
        /// Checks if this variant type is a subtype of <paramref name="supertype"/>.
        /// </summary>
        /// <remarks>
        /// This function returns <c>true</c> if this type is a subtype of <paramref name="supertype"/>.  All
        /// types are considered to be subtypes of themselves. Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="supertype">
        /// a <see cref="VariantType"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if this type is a subtype of <paramref name="supertype"/>
        /// </returns>
        [Since("2.24")]
        public bool IsSubtypeOf(VariantType supertype)
        {
            var this_ = Handle;
            var supertype_ = supertype.Handle;
            var ret = g_variant_type_is_subtype_of(this_, supertype_);
            return ret;
        }

        /// <summary>
        /// Determines if the given @type is a tuple type.  This is true if the
        /// type string for @type starts with a '(' or if @type is
        /// %G_VARIANT_TYPE_TUPLE.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a tuple type -- %G_VARIANT_TYPE_TUPLE, for
        /// example.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a tuple type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_tuple(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is a tuple type.  This is true if the
        /// type string for this type starts with a '(' or if this type is
        /// <see cref="Tuple"/>.
        /// </summary>
        /// <remarks>
        /// This property returns <c>true</c> for any indefinite type for which every
        /// definite subtype is a tuple type -- <see cref="Tuple"/>, for
        /// example.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if this variant type is a tuple type
        /// </returns>
        [Since("2.24")]
        public bool IsTuple {
            get {
                var ret = g_variant_type_is_tuple(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is the variant type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Runtime.Boolean g_variant_type_is_variant(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines if this variant type is the variant type.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this variant type is the variant type
        /// </returns>
        [Since("2.24")]
        public bool IsVariant {
            get {
                var ret = g_variant_type_is_variant(Handle);
                return ret;
            }
        }

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the key type of the dictionary entry
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_key(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Gets the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This property may only be used with a dictionary entry type.
        /// </remarks>
        /// <value>
        /// the key type of the dictionary entry
        /// </value>
        /// <exception cref="InvalidOperationException">
        /// if this type is not a dictionary entry type
        /// </exception>
        [Since("2.24")]
        public VariantType Key {
            get {
                var this_ = Handle;
                if (!g_variant_type_is_dict_entry(this_)) {
                    throw new InvalidOperationException("only valid for dictionary entry types");
                }
                var ret_ = g_variant_type_key(this_);
                var ret = new VariantType(ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// %G_VARIANT_TYPE_TUPLE.
        ///
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <param name="type">
        /// a tuple or dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the number of items in @type
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.SysUInt)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern UIntPtr g_variant_type_n_items(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines the number of items contained in a tuple or
        /// dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with tuple or dictionary entry types,
        /// but must not be used with the generic tuple type
        /// <see cref="Tuple"/>.
        ///
        /// In the case of a dictionary entry type, this function will always
        /// return 2.
        /// </remarks>
        /// <value>
        /// the number of items in this type
        /// </value>
        [Since("2.24")]
        public int Count {
            get {
                var this_ = Handle;
                if (!g_variant_type_is_tuple(this_) && !g_variant_type_is_dict_entry(this_)) {
                    throw new InvalidOperationException("only valid for tuple an dictionary entry types");
                }
                if (g_variant_type_equal(this_, Tuple.Handle)) {
                    throw new InvalidOperationException("only valid for non-generic tuple types");
                }
                var ret = g_variant_type_n_items(this_);
                return (int)ret;
            }
        }

        /// <summary>
        /// Determines the next item type of a tuple or dictionary entry
        /// type.
        /// </summary>
        /// <remarks>
        /// @type must be the result of a previous call to
        /// g_variant_type_first() or g_variant_type_next().
        ///
        /// If called on the key type of a dictionary entry then this call
        /// returns the value type.  If called on the value type of a dictionary
        /// entry then this call returns %NULL.
        ///
        /// For tuples, %NULL is returned when @type is the last item in a tuple.
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType from a previous call
        /// </param>
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_next(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <param name="type">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_peek_string(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <param name="type">
        /// a dictionary entry #GVariantType
        /// </param>
        /// <returns>
        /// the value type of the dictionary entry
        /// </returns>
        [Since("2.24")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_value(
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            IntPtr type);

        /// <summary>
        /// Gets the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This property may only be used with a dictionary entry type.
        /// </remarks>
        /// <value>
        /// the value type of the dictionary entry
        /// </value>
        [Since("2.24")]
        public VariantType Value {
            get {
                var this_ = Handle;
                if (!g_variant_type_is_dict_entry(this_)) {
                    throw new InvalidOperationException("only valid for dictionary entry types");
                }
                var ret_ = g_variant_type_value(this_);
                var ret = new VariantType(ret_, Transfer.None);
                return ret;
            }
        }
    }
}
