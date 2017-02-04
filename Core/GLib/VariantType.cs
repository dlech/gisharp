using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
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
    [GType ("GVariantType", IsWrappedNativeType = true)]
    [DebuggerDisplay ("{FormatString}")]
    public sealed class VariantType : Opaque, IEquatable<VariantType>
    {
        public sealed class SafeVariantTypeHandle : SafeOpaqueHandle
        {
            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr g_variant_type_copy (IntPtr type);

            public SafeVariantTypeHandle (IntPtr handle, Transfer ownership)
            {
                if (ownership == Transfer.None) {
                    handle = g_variant_type_copy (handle);
                }
                SetHandle (handle);
            }

            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern void g_variant_type_free (IntPtr type);

            protected override bool ReleaseHandle ()
            {
                try {
                    g_variant_type_free (handle);
                    return true;
                } catch {
                    return false;
                }
            }
        }

        public new SafeVariantTypeHandle Handle {
            get {
                return (SafeVariantTypeHandle)base.Handle;
            }
        }

        // these static properties take the place of the G_VARIANT_TYPE_* macros

        static Lazy<VariantType> lazyBoolean = new Lazy<VariantType> (() =>
            new VariantType ("b"));

        public static VariantType Boolean {
            get {
                return lazyBoolean.Value;
            }
        }

        static Lazy<VariantType> lazyByte = new Lazy<VariantType> (() =>
            new VariantType ("y"));

        public static VariantType Byte {
            get {
                return lazyByte.Value;
            }
        }

        static Lazy<VariantType> lazyInt16 = new Lazy<VariantType> (() =>
            new VariantType ("n"));

        public static VariantType Int16 {
            get {
                return lazyInt16.Value;
            }
        }

        static Lazy<VariantType> lazyUInt16 = new Lazy<VariantType> (() =>
            new VariantType ("q"));

        public static VariantType UInt16 {
            get {
                return lazyUInt16.Value;
            }
        }

        static Lazy<VariantType> lazyInt32 = new Lazy<VariantType> (() =>
            new VariantType ("i"));

        public static VariantType Int32 {
            get {
                return lazyInt32.Value;
            }
        }

        static Lazy<VariantType> lazyUInt32 = new Lazy<VariantType> (() =>
            new VariantType ("u"));

        public static VariantType UInt32 {
            get {
                return lazyUInt32.Value;
            }
        }

        static Lazy<VariantType> lazyInt64 = new Lazy<VariantType> (() =>
            new VariantType ("x"));

        public static VariantType Int64 {
            get {
                return lazyInt64.Value;
            }
        }

        static Lazy<VariantType> lazyUInt64 = new Lazy<VariantType> (() =>
            new VariantType ("t"));

        public static VariantType UInt64 {
            get {
                return lazyUInt64.Value;
            }
        }

        static Lazy<VariantType> lazyDBusHandle = new Lazy<VariantType> (() =>
            new VariantType ("h"));

        public static VariantType DBusHandle {
            get {
                return lazyDBusHandle.Value;
            }
        }

        static Lazy<VariantType> lazyDouble = new Lazy<VariantType> (() =>
            new VariantType ("d"));

        public static VariantType Double {
            get {
                return lazyDouble.Value;
            }
        }

        static Lazy<VariantType> lazyString = new Lazy<VariantType> (() =>
            new VariantType ("s"));

        public static VariantType String {
            get {
                return lazyString.Value;
            }
        }

        static Lazy<VariantType> lazyObjectPath = new Lazy<VariantType> (() =>
            new VariantType ("o"));

        public static VariantType ObjectPath {
            get {
                return lazyObjectPath.Value;
            }
        }

        static Lazy<VariantType> lazyDBusSignature = new Lazy<VariantType> (() =>
            new VariantType ("g"));

        public static VariantType DBusSignature {
            get {
                return lazyDBusSignature.Value;
            }
        }

        static Lazy<VariantType> lazyBoxedVariant = new Lazy<VariantType> (() =>
            new VariantType ("v"));

        public static VariantType BoxedVariant {
            get {
                return lazyBoxedVariant.Value;
            }
        }

        static Lazy<VariantType> lazyAny = new Lazy<VariantType> (() =>
            new VariantType ("*"));

        public static VariantType Any {
            get {
                return lazyAny.Value;
            }
        }

        static Lazy<VariantType> lazyBasic = new Lazy<VariantType> (() =>
            new VariantType ("?"));

        public static VariantType Basic {
            get {
                return lazyBasic.Value;
            }
        }

        static Lazy<VariantType> lazyMaybe = new Lazy<VariantType> (() =>
            new VariantType ("m*"));

        public static VariantType Maybe {
            get {
                return lazyMaybe.Value;
            }
        }

        static Lazy<VariantType> lazyArray = new Lazy<VariantType> (() =>
            new VariantType ("a*"));

        public static VariantType Array {
            get {
                return lazyArray.Value;
            }
        }

        static Lazy<VariantType> lazyTuple = new Lazy<VariantType> (() =>
            new VariantType ("r"));

        public static VariantType Tuple {
            get {
                return lazyTuple.Value;
            }
        }

        static Lazy<VariantType> lazyUnit = new Lazy<VariantType> (() =>
            new VariantType ("()"));

        public static VariantType Unit {
            get {
                return lazyUnit.Value;
            }
        }

        static Lazy<VariantType> lazyDictEntry = new Lazy<VariantType> (() =>
            new VariantType ("{?*}"));

        public static VariantType DictEntry {
            get {
                return lazyDictEntry.Value;
            }
        }

        static Lazy<VariantType> lazyDictionary = new Lazy<VariantType> (() =>
            new VariantType ("a{?*}"));

        public static VariantType Dictionary {
            get {
                return lazyDictionary.Value;
            }
        }

        static Lazy<VariantType> lazyStringArray = new Lazy<VariantType> (() =>
            new VariantType ("as"));

        public static VariantType StringArray {
            get {
                return lazyStringArray.Value;
            }
        }

        static Lazy<VariantType> lazyObjectPathArray = new Lazy<VariantType> (() =>
            new VariantType ("ao"));

        public static VariantType ObjectPathArray {
            get {
                return lazyObjectPathArray.Value;
            }
        }

        static Lazy<VariantType> lazyByteString = new Lazy<VariantType> (() => new
            VariantType ("ay"));

        public static VariantType ByteString {
            get {
                return lazyByteString.Value;
            }
        }

        static Lazy<VariantType> lazyByteStringArray = new Lazy<VariantType> (() =>
            new VariantType ("aay"));

        public static VariantType ByteStringArray {
            get {
                return lazyByteStringArray.Value;
            }
        }

        static Lazy<VariantType> lazyVarDict = new Lazy<VariantType> (() =>
            new VariantType ("a{sv}"));

        public static VariantType VarDict {
            get {
                return lazyVarDict.Value;
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_variant_type_get_gtype ();

        static GType getGType ()
        {
            var ret = g_variant_type_get_gtype ();
            return ret;
        }

        public VariantType (SafeVariantTypeHandle handle) : base (handle)
        {
        }

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
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeString);

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
        [Since ("2.24")]
        static SafeVariantTypeHandle New (string typeString)
        {
            if (typeString == null) {
                throw new ArgumentNullException (nameof (typeString));
            }
            var typeString_ = GMarshal.StringToUtf8Ptr (typeString);
            var ret_ = g_variant_type_new (typeString_);
            GMarshal.Free (typeString_);
            var ret = new SafeVariantTypeHandle (ret_, Transfer.Full);
            return ret;
        }

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
        [Since ("2.24")]
        public VariantType (string typeString) : this (New (typeString))
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_array (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle element);

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
        ///
        /// Since 2.24
        /// </returns>
        public static VariantType NewArray (VariantType element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof (element));
            }
            var ret_ = g_variant_type_new_array (element.Handle);
            var ret = new SafeVariantTypeHandle (ret_, Transfer.Full);
            return new VariantType (ret);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_dict_entry (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle key,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle value);

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
        ///
        /// Since 2.24
        /// </returns>
        public static VariantType NewDictEntry (VariantType key, VariantType value)
        {
            if (key == null) {
                throw new ArgumentNullException (nameof (key));
            }
            if (value == null) {
                throw new ArgumentNullException (nameof (value));
            }
            var ret_ = g_variant_type_new_dict_entry (key.Handle, value.Handle);
            var ret = new SafeVariantTypeHandle (ret_, Transfer.Full);
            return new VariantType (ret);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_maybe (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle element);

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
        ///
        /// Since 2.24
        /// </returns>
        public static VariantType NewMaybe (VariantType element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof (element));
            }
            var ret_ = g_variant_type_new_maybe (element.Handle);
            var ret = new SafeVariantTypeHandle (ret_, Transfer.Full);
            return new VariantType (ret);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_new_tuple (
            /* <array length="1" zero-terminated="0" type="GVariantType**">
                <type name="VariantType" type="GVariantType*" managed-name="VariantType" />
                </array> */
            /* transfer-ownership:none */
            IntPtr items,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int length);

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
        /// <returns>
        /// a new tuple #GVariantType
        ///
        /// Since 2.24
        /// </returns>
        public static VariantType NewTuple (VariantType[] items)
        {
            if (items == null) {
                throw new ArgumentNullException (nameof (items));
            }
            var items_ = GMarshal.OpaqueCArrayToPtr<VariantType> (items, false);
            var ret_ = g_variant_type_new_tuple (items_, items.Length);
            var ret = new SafeVariantTypeHandle (ret_, Transfer.Full);
            GMarshal.Free (items_);
            return new VariantType (ret);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_string_is_valid (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeString);

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
        ///
        /// Since 2.24
        /// </returns>
        public static bool StringIsValid (string typeString)
        {
            if (typeString == null) {
                throw new ArgumentNullException (nameof (typeString));
            }
            var typeString_ = GMarshal.StringToUtf8Ptr (typeString);
            var ret = g_variant_type_string_is_valid (typeString_);
            GMarshal.Free (typeString_);
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
        [Since ("2.24")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_string_scan (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr @string,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr limit,
            /* <type name="utf8" type="const gchar**" managed-name="Utf8" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            out IntPtr endptr);
        
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_variant_type_dup_string (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Returns a newly-allocated copy of the type string corresponding to
        /// @type.  The returned string is nul-terminated.  It is appropriate to
        /// call g_free() on the return value.
        /// </summary>
        /// <returns>
        /// the corresponding type string
        ///
        /// Since 2.24
        /// </returns>
        public override string ToString ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_dup_string (Handle);
            var ret = GMarshal.Utf8PtrToString (ret_, true);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_element (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines the element type of an array or maybe type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with array or maybe types.
        /// </remarks>
        /// <returns>
        /// the element type of @type
        ///
        /// Since 2.24
        /// </returns>
        public VariantType Element ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_element (Handle);
            var ret = GetInstance<VariantType> (ret_, Transfer.None);
            return ret;
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_equal (
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type1,
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type2);

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
        /// <param name="type2">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type1 and @type2 are exactly equal
        ///
        /// Since 2.24
        /// </returns>
        public bool Equals (VariantType type2)
        {
            AssertNotDisposed ();
            if (type2 == null) {
                throw new ArgumentNullException (nameof (type2));
            }
            var ret = g_variant_type_equal (Handle, type2.Handle);
            return ret;
        }

        public override bool Equals (object obj)
        {
            return Equals (obj as VariantType);
        }

        public static bool operator == (VariantType one, VariantType two)
        {
            if ((object)one == null) {
                return (object)two == null;
            }
            if ((object)two == null) {
                return false;
            }
            return one.Equals (two);
        }

        public static bool operator != (VariantType one, VariantType two)
        {
            return !(one == two);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_first (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// the first item type of @type, or %NULL
        ///
        /// Since 2.24
        /// </returns>
        public VariantType First ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_first (Handle);
            var ret = GetInstance<VariantType> (ret_, Transfer.None);
            return ret;
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern ulong g_variant_type_get_string_length (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Returns the length of the type string corresponding to the given
        /// @type.  This function must be used to determine the valid extent of
        /// the memory region returned by g_variant_type_peek_string().
        /// </summary>
        /// <returns>
        /// the length of the corresponding type string
        ///
        /// Since 2.24
        /// </returns>
        public ulong StringLength {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_get_string_length (Handle);
                return ret;
            }
        }

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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern int g_variant_type_hash (
            /* <type name="VariantType" type="gconstpointer" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Hashes @type.
        /// </summary>
        /// <remarks>
        /// The argument type of @type is only #gconstpointer to allow use with
        /// #GHashTable without function pointer casting.  A valid
        /// #GVariantType must be provided.
        /// </remarks>
        /// <returns>
        /// the hash value
        ///
        /// Since 2.24
        /// </returns>
        public override int GetHashCode ()
        {
            AssertNotDisposed ();
            var ret = g_variant_type_hash (Handle);
            return ret;
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_array (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines if the given @type is an array type.  This is true if the
        /// type string for @type starts with an 'a'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is an array type -- %G_VARIANT_TYPE_ARRAY, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is an array type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsArray {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_array (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_basic (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// %TRUE if @type is a basic type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsBasic {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_basic (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_container (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// %TRUE if @type is a container type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsContainer {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_container (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_definite (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// %TRUE if @type is definite
        ///
        /// Since 2.24
        /// </returns>
        public bool IsDefinite {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_definite (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_dict_entry (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines if the given @type is a dictionary entry type.  This is
        /// true if the type string for @type starts with a '{'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a dictionary entry type --
        /// %G_VARIANT_TYPE_DICT_ENTRY, for example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a dictionary entry type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsDictEntry {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_dict_entry (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_maybe (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines if the given @type is a maybe type.  This is true if the
        /// type string for @type starts with an 'm'.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE for any indefinite type for which every
        /// definite subtype is a maybe type -- %G_VARIANT_TYPE_MAYBE, for
        /// example.
        /// </remarks>
        /// <returns>
        /// %TRUE if @type is a maybe type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsMaybe {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_maybe (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_subtype_of (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type,
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle supertype);

        /// <summary>
        /// Checks if @type is a subtype of @supertype.
        /// </summary>
        /// <remarks>
        /// This function returns %TRUE if @type is a subtype of @supertype.  All
        /// types are considered to be subtypes of themselves.  Aside from that,
        /// only indefinite types can have subtypes.
        /// </remarks>
        /// <param name="supertype">
        /// a #GVariantType
        /// </param>
        /// <returns>
        /// %TRUE if @type is a subtype of @supertype
        ///
        /// Since 2.24
        /// </returns>
        public bool IsSubtypeOf (VariantType supertype)
        {
            AssertNotDisposed ();
            if (supertype == null) {
                throw new ArgumentNullException (nameof (supertype));
            }
            var ret = g_variant_type_is_subtype_of (Handle, supertype.Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_tuple (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// %TRUE if @type is a tuple type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsTuple {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_tuple (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_variant_type_is_variant (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines if the given @type is the variant type.
        /// </summary>
        /// <returns>
        /// %TRUE if @type is the variant type
        ///
        /// Since 2.24
        /// </returns>
        public bool IsVariant {
            get {
                AssertNotDisposed ();
                var ret = g_variant_type_is_variant (Handle);
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_key (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines the key type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.  Other
        /// than the additional restriction, this call is equivalent to
        /// g_variant_type_first().
        /// </remarks>
        /// <returns>
        /// the key type of the dictionary entry
        ///
        /// Since 2.24
        /// </returns>
        public VariantType Key ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_key (Handle);
            var ret = GetInstance<VariantType> (ret_, Transfer.None);
            return ret;
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        static extern ulong g_variant_type_n_items (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// the number of items in @type
        ///
        /// Since 2.24
        /// </returns>
        public ulong NItems ()
        {
            AssertNotDisposed ();
            var ret = g_variant_type_n_items (Handle);
            return ret;
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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_next (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

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
        /// <returns>
        /// the next #GVariantType after @type, or %NULL
        ///
        /// Since 2.24
        /// </returns>
        public VariantType Next ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_next (Handle);
            var ret = GetInstance<VariantType> (ret_, Transfer.None);
            return ret;
        }

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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_peek_string (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Returns the type string corresponding to the given @type.  The
        /// result is not nul-terminated; in order to determine its length you
        /// must call g_variant_type_get_string_length().
        /// </summary>
        /// <remarks>
        /// To get a nul-terminated string, see g_variant_type_dup_string().
        /// </remarks>
        /// <returns>
        /// the corresponding type string (not nul-terminated)
        ///
        /// Since 2.24
        /// </returns>
        public string PeekString ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_peek_string (Handle);
            var ret = GMarshal.Utf8PtrToString (ret_);
            return ret;
        }

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
        ///
        /// Since 2.24
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_variant_type_value (
            /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" /> */
            /* transfer-ownership:none */
            SafeVariantTypeHandle type);

        /// <summary>
        /// Determines the value type of a dictionary entry type.
        /// </summary>
        /// <remarks>
        /// This function may only be used with a dictionary entry type.
        /// </remarks>
        /// <returns>
        /// the value type of the dictionary entry
        ///
        /// Since 2.24
        /// </returns>
        public VariantType Value ()
        {
            AssertNotDisposed ();
            var ret_ = g_variant_type_value (Handle);
            var ret = GetInstance<VariantType> (ret_, Transfer.None);
            return ret;
        }
    }
}
