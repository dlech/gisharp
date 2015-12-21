using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace GISharp.Core
{
    /// <summary>
    /// A numerical value which represents the unique identifier of a registered
    /// type.
    /// </summary>
    public struct GType
    {
        /// <summary>
        /// An integer constant that represents the number of identifiers reserved
        /// for types that are assigned at compile-time.
        /// </summary>
        const int FundamentalMax = 255;

        /// <summary>
        /// Shift value used in converting numbers to type IDs.
        /// </summary>
        const int FundamentalShift = 2;

        /// <summary>
        /// First fundamental type number to create a new fundamental type id with
        /// G_TYPE_MAKE_FUNDAMENTAL() reserved for BSE.
        /// </summary>
        const int ReservedBseFirst = 32;

        /// <summary>
        /// Last fundamental type number reserved for BSE.
        /// </summary>
        const int ReservedBseLast = 48;

        /// <summary>
        /// First fundamental type number to create a new fundamental type id with
        /// G_TYPE_MAKE_FUNDAMENTAL() reserved for GLib.
        /// </summary>
        const int ReservedGlibFirst = 22;

        /// <summary>
        /// Last fundamental type number reserved for GLib.
        /// </summary>
        const int ReservedGlibLast = 31;

        /// <summary>
        /// First available fundamental type number to create new fundamental
        /// type id with G_TYPE_MAKE_FUNDAMENTAL().
        /// </summary>
        const int ReservedUserFirst = 49;

        // typedef gsize GType;
        UIntPtr value;

        /// <summary>
        /// An invalid GType used as error return value in some functions which
        /// return a GType.
        /// </summary>
        public static GType Invalid {
            get {
                return new GType ();
            }
        }

        /// <summary>
        /// A fundamental type which is used as a replacement for the C void
        /// return type.
        /// </summary>
        public static GType None {
            get {
                return new GType { value = (UIntPtr)(1 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type from which all interfaces are derived.
        /// </summary>
        public static GType Interface {
            get {
                return new GType { value = (UIntPtr)(2 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gchar.
        /// </summary>
        /// <remarks>
        /// The type designated by G_TYPE_CHAR is unconditionally an 8-bit
        /// signed integer. This may or may not be the same type a the C type
        /// "gchar".
        /// </remarks>
        public static GType Char {
            get {
                return new GType { value = (UIntPtr)(3 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guchar.
        /// </summary>
        public static GType UChar {
            get {
                return new GType { value = (UIntPtr)(4 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gboolean.
        /// </summary>
        public static GType Boolean {
            get {
                return new GType { value = (UIntPtr)(5 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gint.
        /// </summary>
        public static GType Int {
            get {
                return new GType { value = (UIntPtr)(6 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guint.
        /// </summary>
        public static GType UInt {
            get {
                return new GType { value = (UIntPtr)(7 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to glong.
        /// </summary>
        public static GType Long {
            get {
                return new GType { value = (UIntPtr)(8 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gulong.
        /// </summary>
        public static GType ULong {
            get {
                return new GType { value = (UIntPtr)(9 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gint64.
        /// </summary>
        public static GType Int64 {
            get {
                return new GType { value = (UIntPtr)(10 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guint64.
        /// </summary>
        public static GType UInt64 {
            get {
                return new GType { value = (UIntPtr)(11 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type from which all enumeration types are derived.
        /// </summary>
        public static GType Enum {
            get {
                return new GType { value = (UIntPtr)(12 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type from which all flags types are derived.
        /// </summary>
        public static GType Flags {
            get {
                return new GType { value = (UIntPtr)(13 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gfloat.
        /// </summary>
        public static GType Float {
            get {
                return new GType { value = (UIntPtr)(14 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gdouble.
        /// </summary>
        public static GType Double {
            get {
                return new GType { value = (UIntPtr)(15 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to null-terminated C strings.
        /// </summary>
        public static GType String {
            get {
                return new GType { value = (UIntPtr)(16 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gpointer.
        /// </summary>
        public static GType Pointer {
            get {
                return new GType { value = (UIntPtr)(17 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type from which all boxed types are derived.
        /// </summary>
        public static GType Boxed {
            get {
                return new GType { value = (UIntPtr)(18 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type from which all GParamSpec types are derived.
        /// </summary>
        public static GType Param {
            get {
                return new GType { value = (UIntPtr)(19 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type for GObject.
        /// </summary>
        public static GType Object {
            get {
                return new GType { value = (UIntPtr)(20 << FundamentalShift) };
            }
        }

        /// <summary>
        /// The fundamental type corresponding to GVariant.
        /// </summary>
        /// <remarks>
        /// All floating GVariant instances passed through the GType system are
        /// consumed.
        ///
        /// Note that callbacks in closures, and signal handlers for signals of
        /// return type G_TYPE_VARIANT, must never return floating variants.
        /// </remarks>
        public static GType Variant {
            get {
                return new GType { value = (UIntPtr)21 };
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_get_type ();

        /// <summary>
        /// The type for GType.
        /// </summary>
        public static GType xGType {
            // FIXME: member name cannot be the same as the type name
            get {
                return g_type_get_type ();
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_checksum_get_type ();

        /// <summary>
        /// The GType for a boxed type holding a GChecksum.
        /// </summary>
        public static GType Checksum {
            get {
                return g_checksum_get_type ();
            }
        }

        /// <summary>
        /// Internal function, used to extract the fundamental type ID portion.
        /// Use G_TYPE_FUNDAMENTAL() instead.
        /// </summary>
        /// <param name="typeId">
        /// valid type ID
        /// </param>
        /// <returns>
        /// fundamental type ID
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_fundamental (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType typeId);

        /// <summary>
        /// The fundamental type which is the ancestor of type.
        /// </summary>
        /// <remarks>
        /// Fundamental types are types that serve as ultimate bases for the
        /// derived types, thus they are the roots of distinct inheritance
        /// hierarchies.
        /// </remarks>
        public GType Fundamental {
            get {
                return g_type_fundamental (this);
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_test_flags (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            TypeFlags flags);

        /// <summary>
        /// Checks if type is an abstract type.
        /// </summary>
        /// <remarks>>
        /// An abstract type cannot be instantiated and is normally used as an
        /// abstract base class for derived classes.
        /// </remarks>
        public bool IsAbstract {
            get {
                return g_type_test_flags (this, TypeFlags.Abstract);
            }
        }

        /// <summary>
        /// Checks if this is derived (or in object-oriented terminology: inherited)
        /// from another type (this holds true for all non-fundamental types).
        /// </summary>
        public bool IsDerived {
            get {
                return value.ToUInt32 () > FundamentalMax;
            }
        }

        /// <summary>
        /// Checks if this is a fundamental type.
        /// </summary>
        public bool IsFundamental {
            get {
                return value.ToUInt32 () <= FundamentalMax;
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_is_value_type (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Checks if this is a value type and can be used with g_value_init().
        /// </summary>
        public bool IsValueType {
            get {
                return g_type_check_is_value_type (this);
            }
        }

        /// <summary>
        /// Checks if type is a classed type.
        /// </summary>
        public bool IsClassed {
            get {
                return g_type_test_flags (this, TypeFlags.Classed);
            }
        }

        /// <summary>
        /// Checks if type can be instantiated.
        /// </summary>
        /// <remarks>
        /// Instantiation is the process of creating an instance (object) of
        /// this type.
        /// </remarks>
        public bool IsInstantiatable {
            get {
                return g_type_test_flags (this, TypeFlags.Instantiatable);
            }
        }

        /// <summary>
        /// Checks if type is a derivable type.
        /// </summary>
        /// <remarks>
        /// A derivable type can be used as the base class of a flat
        /// (single-level) class hierarchy.
        /// </remarks>
        public bool IsDerivable {
            get {
                return g_type_test_flags (this, TypeFlags.Derivable);
            }
        }

        /// <summary>
        /// Checks if type is a deep derivable type.
        /// </summary>
        /// <remarks>
        /// A deep derivable type can be used as the base class of a deep
        /// (multi-level) class hierarchy.
        /// </remarks>
        public bool IsDeepDerivable {
            get {
                return g_type_test_flags (this, TypeFlags.DeepDerivable);
            }
        }

        /// <summary>
        /// Checks if type is an interface type.
        /// </summary>
        /// <remarks>
        /// An interface type provides a pure API, the implementation of which
        /// is provided by another type (which is then said to conform to the
        /// interface). GLib interfaces are somewhat analogous to Java interfaces
        /// and C++ classes containing only pure virtual functions, with the
        /// difference that GType interfaces are not derivable (but see
        /// g_type_interface_add_prerequisite() for an alternative).
        /// </remarks>
        public bool IsInterface {
            get {
                return g_type_fundamental (this) == Interface;
            }
        }

        public static bool operator == (GType a, GType b)
        {
            return a.value == b.value;
        }

        public static bool operator != (GType a, GType b)
        {
            return a.value != b.value;
        }

        public override bool Equals (object obj)
        {
            if (obj is GType) {
                return this == (GType)obj;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }


        /// <summary>
        /// Get the unique name that is assigned to a type ID.  Note that this
        /// function (like all other GType API) cannot cope with invalid type
        /// IDs. %G_TYPE_INVALID may be passed to this function, as may be any
        /// other validly registered type ID, but randomized type IDs should
        /// not be passed in and will most likely lead to a crash.
        /// </summary>
        /// <param name="type">
        /// type to return name for
        /// </param>
        /// <returns>
        /// static type name or %NULL
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Get the unique name that is assigned to a type ID.
        /// </summary>
        /// <returns>
        /// type name or <c>null</c>
        /// </returns>
        public string Name {
            get {
                if (this == Invalid) {
                    throw new InvalidOperationException ("Invalid GType.");
                }
                var ret_ = g_type_name (this);
                var ret = MarshalG.Utf8PtrToString (ret_, false);
                return ret;
            }
        }

        /// <summary>
        /// Return the direct parent type of the passed in type. If the passed
        /// in type has no parent, i.e. is a fundamental type, 0 is returned.
        /// </summary>
        /// <param name="type">
        /// the derived type
        /// </param>
        /// <returns>
        /// the parent type
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_parent (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Return the direct parent type of the passed in type. If the passed
        /// in type has no parent, i.e. is a fundamental type,
        /// <see cref="Invalid"/> is returned.
        /// </summary>
        /// <returns>
        /// the parent type
        /// </returns>
        public GType Parent {
            get {
                if (this == Invalid) {
                    throw new InvalidOperationException ("Invalid GType.");
                }
                var ret = g_type_parent (this);
                return ret;
            }
        }


        /// <summary>
        /// Return a newly allocated and 0-terminated array of type IDs, listing
        /// the child types of @type.
        /// </summary>
        /// <param name="type">
        /// the parent type
        /// </param>
        /// <param name="nChildren">
        /// location to store the length of
        ///     the returned array, or %NULL
        /// </param>
        /// <returns>
        /// Newly allocated
        ///     and 0-terminated array of child types, free with g_free()
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
            <type name="GType" type="GType" managed-name="GType" />
            </array> */
        /* transfer-ownership:full */
        static extern IntPtr g_type_children (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            out uint nChildren);

        /// <summary>
        /// Return an array of type IDs, listing the child types of this type.
        /// </summary>
        /// <returns>
        /// array of child types
        /// </returns>
        public GType [] Children {
            get {
                if (this == Invalid) {
                    throw new InvalidOperationException ("Invalid GType.");
                }
                uint nChildren_;
                var ret_ = g_type_children (this, out nChildren_);
                var ret = MarshalG.PtrToCArray<GType> (ret_, (int)nChildren_, freePtr: true);
                return ret;
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_type_is_a (GType type, GType is_a_type);

        public bool IsA (GType type)
        {
            if (this == Invalid) {
                throw new InvalidOperationException ("Invalid GType.");
            }
            if (type == Invalid) {
                throw new ArgumentException ("Invalid GType.", nameof (type));
            }
            var ret = g_type_is_a (this, type);
            return ret;
        }

        /// <summary>
        /// Lookup the type ID from a given type name, returning 0 if no type
        /// has been registered under this name (this is the preferred method
        /// to find out by name whether a specific type has been registered
        /// yet).
        /// </summary>
        /// <param name="name">
        /// type name to lookup
        /// </param>
        /// <returns>
        /// corresponding type ID or 0
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_from_name(
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);

        /// <summary>
        /// Lookup the type ID from a given type name, returning
        /// <see cref="Invalid"/> if no type
        /// has been registered under this name.
        /// </summary>
        /// <param name="name">
        /// type name to lookup
        /// </param>
        /// <returns>
        /// corresponding type ID or 0
        /// </returns>
        /// <remarks>
        /// This is the preferred method to find out by name whether a specific
        /// type has been registered yet.
        /// </remarks>
        public static GType FromName (string name)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            AssertGTypeName (name);
            var name_ = MarshalG.StringToUtf8Ptr (name);
            var ret = g_type_from_name (name_);
            MarshalG.Free (name_);
            return ret;
        }

        /// <summary>
        /// Asserts that the name of the type is a valid GType name.
        /// </summary>
        /// <param name="name">The type name.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="name"/> is null.
        /// </exception>
        /// <exception cref="InvalidGTypeNameException">
        /// Thrown if <paramref name="name"/> is not valid (see remarks).
        /// </exception>
        /// <remarks>
        /// Type names must be at least three characters long. There is no upper
        /// length limit. The first character must be a letter (a–z or A–Z) or
        /// an underscore (‘_’). Subsequent characters can be letters, numbers
        /// or any of ‘-_+’.
        /// </remarks>
        public static void AssertGTypeName (string name)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            if (name.Length < 3) {
                var message = string.Format ($"The name '{name}' is too short.");
                throw new InvalidGTypeNameException (message);
            }
            if (Regex.IsMatch (name[0].ToString (), "[^A-Za-z_]")) {
                var message = string.Format ($"The name '{name}' must start with letter or underscore.");
                throw new InvalidGTypeNameException (message);
            }
            if (Regex.IsMatch (name, "[^0-9A-Za-z_\\-\\+]")) {
                var message = string.Format ($"The name '{name}' contains an invalid character.");
                throw new InvalidGTypeNameException (message);
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_register_static (
            GType parent_type,
            IntPtr type_name,
            IntPtr info,
            TypeFlags flags);

        public static GType Register (Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            var gtypeAttribute = (GTypeAttribute)type.GetCustomAttributes (
                typeof (GTypeAttribute), false).SingleOrDefault ();
            if (gtypeAttribute == null) {
                var message = string.Format ("Type must have {0} attribute.",
                                             typeof (GTypeAttribute).FullName);
                throw new InvalidOperationException (message);
            }
            if (!gtypeAttribute.Register) {
                throw new InvalidOperationException ("This type can't be registered.");
            }
            var gtypeName = type.GetGTypeName ();
            if (type.IsEnum) {
                if (Marshal.SizeOf (type.GetEnumUnderlyingType ()) != 4) {
                    throw new InvalidOperationException ("GType enums must be int/uint");
                }
                var values = (int[])type.GetEnumValues ();
                var names = type.GetEnumNames ();
                //var fields = type.GetFields ();
                var flagsAttribute = type.GetCustomAttributes (
                    typeof (FlagsAttribute), false).SingleOrDefault ();
                if (flagsAttribute == null) {
                    var gtypeValues = new EnumValue[values.Length];
                    for (int i = 0; i < values.Length; i++) {
                        gtypeValues[i].Value = values[i];
                        // TODO: Check fields for EnumValueAttribute and use those names/nicks instead
                        gtypeValues[i].ValueName = MarshalG.StringToUtf8Ptr (names[i]);
                        gtypeValues[i].ValueNick = MarshalG.StringToUtf8Ptr (names[i]);
                    }
                    var ret = Core.Enum.RegisterStatic (gtypeName, gtypeValues);
                    return ret;
                } else {
                    var gtypeValues = new FlagsValue[values.Length];
                    for (int i = 0; i < values.Length; i++) {
                        gtypeValues[i].Value = (uint)values[i];
                        // TODO: Check fields for EnumValueAttribute and use those names/nicks instead
                        gtypeValues[i].ValueName = MarshalG.StringToUtf8Ptr (names[i]);
                        gtypeValues[i].ValueNick = MarshalG.StringToUtf8Ptr (names[i]);
                    }
                    var ret = Core.Flags.RegisterStatic (gtypeName, gtypeValues);
                    return ret;
                }
            }
            throw new NotImplementedException ();
        }

#if THIS_CODE_IS_NOT_COMPILED
        /// <summary>
        /// Adds a #GTypeClassCacheFunc to be called before the reference count of a
        /// class goes from one to zero. This can be used to prevent premature class
        /// destruction. All installed #GTypeClassCacheFunc functions will be chained
        /// until one of them returns %TRUE. The functions have to check the class id
        /// passed in to figure whether they actually want to cache the class of this
        /// type, since all classes are routed through the same #GTypeClassCacheFunc
        /// chain.
        /// </summary>
        /// <param name="cacheData">
        /// data to be passed to @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            NativeTypeClassCacheFunc cacheFunc);

        /// <summary>
        /// Adds a #GTypeClassCacheFunc to be called before the reference count of a
        /// class goes from one to zero. This can be used to prevent premature class
        /// destruction. All installed #GTypeClassCacheFunc functions will be chained
        /// until one of them returns %TRUE. The functions have to check the class id
        /// passed in to figure whether they actually want to cache the class of this
        /// type, since all classes are routed through the same #GTypeClassCacheFunc
        /// chain.
        /// </summary>
        /// <param name="cacheData">
        /// data to be passed to @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        public static void AddClassCacheFunc(IntPtr cacheData, TypeClassCacheFunc cacheFunc)
        {
            if (cacheFunc == null)
            {
                throw new ArgumentNullException("cacheFunc");
            }
            var cacheFunc_ = NativeTypeClassCacheFuncFactory.Create(cacheFunc, false);
            g_type_add_class_cache_func(cacheData, cacheFunc_);
        }

        /// <summary>
        /// Registers a private class structure for a classed type;
        /// when the class is allocated, the private structures for
        /// the class and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        /// </summary>
        /// <remarks>
        /// This function should be called in the
        /// type's get_type() function after the type is registered.
        /// The private structure can be retrieved using the
        /// G_TYPE_CLASS_GET_PRIVATE() macro.
        /// </remarks>
        /// <param name="classType">
        /// GType of an classed type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [Since ("2.24")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_class_private(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType classType,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            ulong privateSize);

        /// <summary>
        /// Registers a private class structure for a classed type;
        /// when the class is allocated, the private structures for
        /// the class and all of its parent types are allocated
        /// sequentially in the same memory block as the public
        /// structures, and are zero-filled.
        /// </summary>
        /// <remarks>
        /// This function should be called in the
        /// type's get_type() function after the type is registered.
        /// The private structure can be retrieved using the
        /// G_TYPE_CLASS_GET_PRIVATE() macro.
        /// </remarks>
        /// <param name="classType">
        /// GType of an classed type
        /// </param>
        /// <param name="privateSize">
        /// size of private structure
        /// </param>
        [Since ("2.24")]
        public static void AddClassPrivate(GType classType, ulong privateSize)
        {
            g_type_add_class_private(classType, privateSize);
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_type_add_instance_private(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType classType,
            /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
            /* transfer-ownership:none */
            ulong privateSize);

        public static int AddInstancePrivate(GType classType, ulong privateSize)
        {
            var ret = g_type_add_instance_private(classType, privateSize);
            return ret;
        }

        /// <summary>
        /// Adds a function to be called after an interface vtable is
        /// initialized for any class (i.e. after the @interface_init
        /// member of #GInterfaceInfo has been called).
        /// </summary>
        /// <remarks>
        /// This function is useful when you want to check an invariant
        /// that depends on the interfaces of a class. For instance, the
        /// implementation of #GObject uses this facility to check that an
        /// object implements all of the properties that are defined on its
        /// interfaces.
        /// </remarks>
        /// <param name="checkData">
        /// data to pass to @check_func
        /// </param>
        /// <param name="checkFunc">
        /// function to be called after each interface
        ///     is initialized
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            NativeTypeInterfaceCheckFunc checkFunc);

        /// <summary>
        /// Adds a function to be called after an interface vtable is
        /// initialized for any class (i.e. after the @interface_init
        /// member of #GInterfaceInfo has been called).
        /// </summary>
        /// <remarks>
        /// This function is useful when you want to check an invariant
        /// that depends on the interfaces of a class. For instance, the
        /// implementation of #GObject uses this facility to check that an
        /// object implements all of the properties that are defined on its
        /// interfaces.
        /// </remarks>
        /// <param name="checkData">
        /// data to pass to @check_func
        /// </param>
        /// <param name="checkFunc">
        /// function to be called after each interface
        ///     is initialized
        /// </param>
        [Since ("2.4")]
        public static void AddInterfaceCheck(IntPtr checkData, TypeInterfaceCheckFunc checkFunc)
        {
            if (checkFunc == null)
            {
                throw new ArgumentNullException("checkFunc");
            }
            var checkFunc_ = NativeTypeInterfaceCheckFuncFactory.Create(checkFunc, false);
            g_type_add_interface_check(checkData, checkFunc_);
        }

        /// <summary>
        /// Adds the dynamic @interface_type to @instantiable_type. The information
        /// contained in the #GTypePlugin structure pointed to by @plugin
        /// is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GInterfaceInfo from
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_dynamic(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
            /* transfer-ownership:none */
            IntPtr plugin);

        /// <summary>
        /// Adds the dynamic @interface_type to @instantiable_type. The information
        /// contained in the #GTypePlugin structure pointed to by @plugin
        /// is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GInterfaceInfo from
        /// </param>
        public static void AddInterfaceDynamic(GType instanceType, GType interfaceType, TypePlugin plugin)
        {
            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }
            var plugin_ = default(IntPtr);
            throw new System.NotImplementedException();
            g_type_add_interface_dynamic(instanceType, interfaceType, plugin_);
        }

        /// <summary>
        /// Adds the static @interface_type to @instantiable_type.
        /// The information contained in the #GInterfaceInfo structure
        /// pointed to by @info is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="info">
        /// #GInterfaceInfo structure for this
        ///        (@instance_type, @interface_type) combination
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_static(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="InterfaceInfo" type="const GInterfaceInfo*" managed-name="InterfaceInfo" /> */
            /* transfer-ownership:none */
            InterfaceInfo info);

        /// <summary>
        /// Adds the static @interface_type to @instantiable_type.
        /// The information contained in the #GInterfaceInfo structure
        /// pointed to by @info is used to manage the relationship.
        /// </summary>
        /// <param name="instanceType">
        /// #GType value of an instantiable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="info">
        /// #GInterfaceInfo structure for this
        ///        (@instance_type, @interface_type) combination
        /// </param>
        public static void AddInterfaceStatic(GType instanceType, GType interfaceType, InterfaceInfo info)
        {
            g_type_add_interface_static(instanceType, interfaceType, info);
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
        /* */
        static extern IntPtr g_type_check_class_cast(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        public static TypeClass CheckClassCast(TypeClass gClass, GType isAType)
        {
            if (gClass == null)
            {
                throw new ArgumentNullException("gClass");
            }
            var gClass_ = gClass == null ? IntPtr.Zero : gClass.Handle;
            var ret_ = g_type_check_class_cast(gClass_, isAType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeClass>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_class_is_a(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        public static bool CheckClassIsA(TypeClass gClass, GType isAType)
        {
            if (gClass == null)
            {
                throw new ArgumentNullException("gClass");
            }
            var gClass_ = gClass == null ? IntPtr.Zero : gClass.Handle;
            var ret = g_type_check_class_is_a(gClass_, isAType);
            return ret;
        }

        /// <summary>
        /// Private helper function to aid implementation of the
        /// G_TYPE_CHECK_INSTANCE() macro.
        /// </summary>
        /// <param name="instance">
        /// a valid #GTypeInstance structure
        /// </param>
        /// <returns>
        /// %TRUE if @instance is valid, %FALSE otherwise
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        /// <summary>
        /// Private helper function to aid implementation of the
        /// G_TYPE_CHECK_INSTANCE() macro.
        /// </summary>
        /// <param name="instance">
        /// a valid #GTypeInstance structure
        /// </param>
        /// <returns>
        /// %TRUE if @instance is valid, %FALSE otherwise
        /// </returns>
        public static bool CheckInstance(TypeInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret = g_type_check_instance(instance_);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* */
        static extern IntPtr g_type_check_instance_cast(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType ifaceType);

        public static TypeInstance CheckInstanceCast(TypeInstance instance, GType ifaceType)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret_ = g_type_check_instance_cast(instance_, ifaceType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInstance>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_instance_is_a(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType ifaceType);

        public static bool CheckInstanceIsA(TypeInstance instance, GType ifaceType)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret = g_type_check_instance_is_a(instance_, ifaceType);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_instance_is_fundamentally_a(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType fundamentalType);

        public static bool CheckInstanceIsFundamentallyA(TypeInstance instance, GType fundamentalType)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret = g_type_check_instance_is_fundamentally_a(instance_, fundamentalType);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_value(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public static bool CheckValue(Value value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var value_ = value == null ? IntPtr.Zero : value.Handle;
            var ret = g_type_check_value(value_);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_check_value_holds(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        public static bool CheckValueHolds(Value value, GType type)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var value_ = value == null ? IntPtr.Zero : value.Handle;
            var ret = g_type_check_value_holds(value_, type);
            return ret;
        }

        /// <summary>
        /// Creates and initializes an instance of @type if @type is valid and
        /// can be instantiated. The type system only performs basic allocation
        /// and structure setups for instances: actual instance creation should
        /// happen through functions supplied by the type's fundamental type
        /// implementation.  So use of g_type_create_instance() is reserved for
        /// implementators of fundamental types only. E.g. instances of the
        /// #GObject hierarchy should be created via g_object_new() and never
        /// directly through g_type_create_instance() which doesn't handle things
        /// like singleton objects or object construction.
        /// </summary>
        /// <remarks>
        /// The extended members of the returned instance are guaranteed to be filled
        /// with zeros.
        /// 
        /// Note: Do not use this function, unless you're implementing a
        /// fundamental type. Also language bindings should not use this
        /// function, but g_object_new() instead.
        /// </remarks>
        /// <param name="type">
        /// an instantiatable type to create an instance for
        /// </param>
        /// <returns>
        /// an allocated and initialized instance, subject to further
        ///     treatment by the fundamental type implementation
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* */
        static extern IntPtr g_type_create_instance(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Creates and initializes an instance of @type if @type is valid and
        /// can be instantiated. The type system only performs basic allocation
        /// and structure setups for instances: actual instance creation should
        /// happen through functions supplied by the type's fundamental type
        /// implementation.  So use of g_type_create_instance() is reserved for
        /// implementators of fundamental types only. E.g. instances of the
        /// #GObject hierarchy should be created via g_object_new() and never
        /// directly through g_type_create_instance() which doesn't handle things
        /// like singleton objects or object construction.
        /// </summary>
        /// <remarks>
        /// The extended members of the returned instance are guaranteed to be filled
        /// with zeros.
        /// 
        /// Note: Do not use this function, unless you're implementing a
        /// fundamental type. Also language bindings should not use this
        /// function, but g_object_new() instead.
        /// </remarks>
        /// <param name="type">
        /// an instantiatable type to create an instance for
        /// </param>
        /// <returns>
        /// an allocated and initialized instance, subject to further
        ///     treatment by the fundamental type implementation
        /// </returns>
        public static TypeInstance CreateInstance(GType type)
        {
            var ret_ = g_type_create_instance(type);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInstance>(ret_, GISharp.Core.Transfer.All);
            return ret;
        }

        /// <summary>
        /// If the interface type @g_type is currently in use, returns its
        /// default interface vtable.
        /// </summary>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface, or %NULL if the type is not currently
        ///     in use
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_default_interface_peek(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gType);

        /// <summary>
        /// If the interface type @g_type is currently in use, returns its
        /// default interface vtable.
        /// </summary>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface, or %NULL if the type is not currently
        ///     in use
        /// </returns>
        [Since ("2.4")]
        public static TypeInterface DefaultInterfacePeek(GType gType)
        {
            var ret_ = g_type_default_interface_peek(gType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInterface>(ret_, GISharp.Core.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Increments the reference count for the interface type @g_type,
        /// and returns the default interface vtable for the type.
        /// </summary>
        /// <remarks>
        /// If the type is not currently in use, then the default vtable
        /// for the type will be created and initalized by calling
        /// the base interface init and default vtable init functions for
        /// the type (the @base_init and @class_init members of #GTypeInfo).
        /// Calling g_type_default_interface_ref() is useful when you
        /// want to make sure that signals and properties for an interface
        /// have been installed.
        /// </remarks>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface; call g_type_default_interface_unref()
        ///     when you are done using the interface.
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_default_interface_ref(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gType);

        /// <summary>
        /// Increments the reference count for the interface type @g_type,
        /// and returns the default interface vtable for the type.
        /// </summary>
        /// <remarks>
        /// If the type is not currently in use, then the default vtable
        /// for the type will be created and initalized by calling
        /// the base interface init and default vtable init functions for
        /// the type (the @base_init and @class_init members of #GTypeInfo).
        /// Calling g_type_default_interface_ref() is useful when you
        /// want to make sure that signals and properties for an interface
        /// have been installed.
        /// </remarks>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface; call g_type_default_interface_unref()
        ///     when you are done using the interface.
        /// </returns>
        [Since ("2.4")]
        public static TypeInterface DefaultInterfaceRef(GType gType)
        {
            var ret_ = g_type_default_interface_ref(gType);
            var ret = GISharp.Core.Opaque.GetInstance<TypeInterface>(ret_, GISharp.Core.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Decrements the reference count for the type corresponding to the
        /// interface default vtable @g_iface. If the type is dynamic, then
        /// when no one is using the interface and all references have
        /// been released, the finalize function for the interface's default
        /// vtable (the @class_finalize member of #GTypeInfo) will be called.
        /// </summary>
        /// <param name="gIface">
        /// the default vtable
        ///     structure for a interface, as returned by g_type_default_interface_ref()
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_default_interface_unref(
            /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
            /* transfer-ownership:none */
            IntPtr gIface);

        /// <summary>
        /// Decrements the reference count for the type corresponding to the
        /// interface default vtable @g_iface. If the type is dynamic, then
        /// when no one is using the interface and all references have
        /// been released, the finalize function for the interface's default
        /// vtable (the @class_finalize member of #GTypeInfo) will be called.
        /// </summary>
        /// <param name="gIface">
        /// the default vtable
        ///     structure for a interface, as returned by g_type_default_interface_ref()
        /// </param>
        [Since ("2.4")]
        public static void DefaultInterfaceUnref(TypeInterface gIface)
        {
            if (gIface == null)
            {
                throw new ArgumentNullException("gIface");
            }
            var gIface_ = gIface == null ? IntPtr.Zero : gIface.Handle;
            g_type_default_interface_unref(gIface_);
        }

        /// <summary>
        /// Returns the length of the ancestry of the passed in type. This
        /// includes the type itself, so that e.g. a fundamental type has depth 1.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the depth of @type
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_type_depth(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the length of the ancestry of the passed in type. This
        /// includes the type itself, so that e.g. a fundamental type has depth 1.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the depth of @type
        /// </returns>
        public static uint Depth(GType type)
        {
            var ret = g_type_depth(type);
            return ret;
        }

        /// <summary>
        /// Ensures that the indicated @type has been registered with the
        /// type system, and its _class_init() method has been run.
        /// </summary>
        /// <remarks>
        /// In theory, simply calling the type's _get_type() method (or using
        /// the corresponding macro) is supposed take care of this. However,
        /// _get_type() methods are often marked %G_GNUC_CONST for performance
        /// reasons, even though this is technically incorrect (since
        /// %G_GNUC_CONST requires that the function not have side effects,
        /// which _get_type() methods do on the first call). As a result, if
        /// you write a bare call to a _get_type() macro, it may get optimized
        /// out by the compiler. Using g_type_ensure() guarantees that the
        /// type's _get_type() method is called.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        [Since ("2.34")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_ensure(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Ensures that the indicated @type has been registered with the
        /// type system, and its _class_init() method has been run.
        /// </summary>
        /// <remarks>
        /// In theory, simply calling the type's _get_type() method (or using
        /// the corresponding macro) is supposed take care of this. However,
        /// _get_type() methods are often marked %G_GNUC_CONST for performance
        /// reasons, even though this is technically incorrect (since
        /// %G_GNUC_CONST requires that the function not have side effects,
        /// which _get_type() methods do on the first call). As a result, if
        /// you write a bare call to a _get_type() macro, it may get optimized
        /// out by the compiler. Using g_type_ensure() guarantees that the
        /// type's _get_type() method is called.
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        [Since ("2.34")]
        public static void Ensure(GType type)
        {
            g_type_ensure(type);
        }

        /// <summary>
        /// Frees an instance of a type, returning it to the instance pool for
        /// the type, if there is one.
        /// </summary>
        /// <remarks>
        /// Like g_type_create_instance(), this function is reserved for
        /// implementors of fundamental types.
        /// </remarks>
        /// <param name="instance">
        /// an instance of a type
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_free_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        /// <summary>
        /// Frees an instance of a type, returning it to the instance pool for
        /// the type, if there is one.
        /// </summary>
        /// <remarks>
        /// Like g_type_create_instance(), this function is reserved for
        /// implementors of fundamental types.
        /// </remarks>
        /// <param name="instance">
        /// an instance of a type
        /// </param>
        public static void FreeInstance(TypeInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            g_type_free_instance(instance_);
        }

        /// <summary>
        /// Returns the next free fundamental type id which can be used to
        /// register a new fundamental type with g_type_register_fundamental().
        /// The returned type ID represents the highest currently registered
        /// fundamental type identifier.
        /// </summary>
        /// <returns>
        /// the next available fundamental type ID to be registered,
        ///     or 0 if the type system ran out of fundamental type IDs
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_fundamental_next();

        /// <summary>
        /// Returns the next free fundamental type id which can be used to
        /// register a new fundamental type with g_type_register_fundamental().
        /// The returned type ID represents the highest currently registered
        /// fundamental type identifier.
        /// </summary>
        /// <returns>
        /// the next available fundamental type ID to be registered,
        ///     or 0 if the type system ran out of fundamental type IDs
        /// </returns>
        public static GType FundamentalNext()
        {
            var ret = g_type_fundamental_next();
            return ret;
        }

        /// <summary>
        /// Returns the number of instances allocated of the particular type;
        /// this is only available if GLib is built with debugging support and
        /// the instance_count debug flag is set (by setting the GOBJECT_DEBUG
        /// variable to include instance-count).
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the number of instances allocated of the given type;
        ///   if instance counts are not available, returns 0.
        /// </returns>
        [Since ("2.44")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gint" type="int" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern int g_type_get_instance_count(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the number of instances allocated of the particular type;
        /// this is only available if GLib is built with debugging support and
        /// the instance_count debug flag is set (by setting the GOBJECT_DEBUG
        /// variable to include instance-count).
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the number of instances allocated of the given type;
        ///   if instance counts are not available, returns 0.
        /// </returns>
        [Since ("2.44")]
        public static int GetInstanceCount(GType type)
        {
            var ret = g_type_get_instance_count(type);
            return ret;
        }

        /// <summary>
        /// Returns the #GTypePlugin structure for @type.
        /// </summary>
        /// <param name="type">
        /// #GType to retrieve the plugin for
        /// </param>
        /// <returns>
        /// the corresponding plugin
        ///     if @type is a dynamic type, %NULL otherwise
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_get_plugin(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Returns the #GTypePlugin structure for @type.
        /// </summary>
        /// <param name="type">
        /// #GType to retrieve the plugin for
        /// </param>
        /// <returns>
        /// the corresponding plugin
        ///     if @type is a dynamic type, %NULL otherwise
        /// </returns>
        public static TypePlugin GetPlugin(GType type)
        {
            var ret_ = g_type_get_plugin(type);
            var ret = default(TypePlugin);
            throw new System.NotImplementedException();
            return ret;
        }

        /// <summary>
        /// Obtains data which has previously been attached to @type
        /// with g_type_set_qdata().
        /// </summary>
        /// <remarks>
        /// Note that this does not take subtyping into account; data
        /// attached to one type with g_type_set_qdata() cannot
        /// be retrieved from a subtype using g_type_get_qdata().
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <returns>
        /// the data, or %NULL if no data was found
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_get_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            GISharp.GLib.Quark quark);

        /// <summary>
        /// Obtains data which has previously been attached to @type
        /// with g_type_set_qdata().
        /// </summary>
        /// <remarks>
        /// Note that this does not take subtyping into account; data
        /// attached to one type with g_type_set_qdata() cannot
        /// be retrieved from a subtype using g_type_get_qdata().
        /// </remarks>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <returns>
        /// the data, or %NULL if no data was found
        /// </returns>
        public static IntPtr GetQdata(GType type, GISharp.GLib.Quark quark)
        {
            var ret = g_type_get_qdata(type, quark);
            return ret;
        }

        /// <summary>
        /// Returns an opaque serial number that represents the state of the set
        /// of registered types. Any time a type is registered this serial changes,
        /// which means you can cache information based on type lookups (such as
        /// g_type_from_name()) and know if the cache is still valid at a later
        /// time by comparing the current serial with the one at the type lookup.
        /// </summary>
        /// <returns>
        /// An unsigned int, representing the state of type registrations
        /// </returns>
        [Since ("2.36")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        static extern uint g_type_get_type_registration_serial();

        /// <summary>
        /// Returns an opaque serial number that represents the state of the set
        /// of registered types. Any time a type is registered this serial changes,
        /// which means you can cache information based on type lookups (such as
        /// g_type_from_name()) and know if the cache is still valid at a later
        /// time by comparing the current serial with the one at the type lookup.
        /// </summary>
        /// <returns>
        /// An unsigned int, representing the state of type registrations
        /// </returns>
        [Since ("2.36")]
        public static uint TypeRegistrationSerial
        {
            get
            {
                var ret = g_type_get_type_registration_serial();
                return ret;
            }
        }

        /// <summary>
        /// This function used to initialise the type system.  Since GLib 2.36,
        /// the type system is initialised automatically and this function does
        /// nothing.
        /// </summary>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_init();

        /// <summary>
        /// This function used to initialise the type system.  Since GLib 2.36,
        /// the type system is initialised automatically and this function does
        /// nothing.
        /// </summary>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        public static void Init()
        {
            g_type_init();
        }

        /// <summary>
        /// This function used to initialise the type system with debugging
        /// flags.  Since GLib 2.36, the type system is initialised automatically
        /// and this function does nothing.
        /// </summary>
        /// <remarks>
        /// If you need to enable debugging features, use the GOBJECT_DEBUG
        /// environment variable.
        /// </remarks>
        /// <param name="debugFlags">
        /// bitwise combination of #GTypeDebugFlags values for
        ///     debugging purposes
        /// </param>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_init_with_debug_flags(
            /* <type name="TypeDebugFlags" type="GTypeDebugFlags" managed-name="TypeDebugFlags" /> */
            /* transfer-ownership:none */
            TypeDebugFlags debugFlags);

        /// <summary>
        /// This function used to initialise the type system with debugging
        /// flags.  Since GLib 2.36, the type system is initialised automatically
        /// and this function does nothing.
        /// </summary>
        /// <remarks>
        /// If you need to enable debugging features, use the GOBJECT_DEBUG
        /// environment variable.
        /// </remarks>
        /// <param name="debugFlags">
        /// bitwise combination of #GTypeDebugFlags values for
        ///     debugging purposes
        /// </param>
        [System.ObsoleteAttribute("the type system is now initialised automatically")]
        public static void InitWithDebugFlags(TypeDebugFlags debugFlags)
        {
            g_type_init_with_debug_flags(debugFlags);
        }

        /// <summary>
        /// Return a newly allocated and 0-terminated array of type IDs, listing
        /// the interface types that @type conforms to.
        /// </summary>
        /// <param name="type">
        /// the type to list interface types for
        /// </param>
        /// <param name="nInterfaces">
        /// location to store the length of
        ///     the returned array, or %NULL
        /// </param>
        /// <returns>
        /// Newly allocated
        ///     and 0-terminated array of interface types, free with g_free()
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
<type name="GType" type="GType" managed-name="GType" />
</array> */
        /* transfer-ownership:full */
        static extern IntPtr g_type_interfaces(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            out uint nInterfaces);

        /// <summary>
        /// Return a newly allocated and 0-terminated array of type IDs, listing
        /// the interface types that @type conforms to.
        /// </summary>
        /// <param name="type">
        /// the type to list interface types for
        /// </param>
        /// <returns>
        /// Newly allocated
        ///     and 0-terminated array of interface types, free with g_free()
        /// </returns>
        public static GType[] Interfaces(GType type)
        {
            uint nInterfaces_;
            var ret_ = g_type_interfaces(type,out nInterfaces_);
            var ret = MarshalG.PtrToCArray<GType>(ret_, (int)nInterfaces_, true);
            return ret;
        }

        /// <summary>
        /// If @is_a_type is a derivable type, check whether @type is a
        /// descendant of @is_a_type. If @is_a_type is an interface, check
        /// whether @type conforms to it.
        /// </summary>
        /// <param name="type">
        /// type to check anchestry for
        /// </param>
        /// <param name="isAType">
        /// possible anchestor of @type or interface that @type
        ///     could conform to
        /// </param>
        /// <returns>
        /// %TRUE if @type is a @is_a_type
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_type_is_a(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType isAType);

        /// <summary>
        /// If @is_a_type is a derivable type, check whether @type is a
        /// descendant of @is_a_type. If @is_a_type is an interface, check
        /// whether @type conforms to it.
        /// </summary>
        /// <param name="type">
        /// type to check anchestry for
        /// </param>
        /// <param name="isAType">
        /// possible anchestor of @type or interface that @type
        ///     could conform to
        /// </param>
        /// <returns>
        /// %TRUE if @type is a @is_a_type
        /// </returns>
        public static bool IsA(GType type, GType isAType)
        {
            var ret = g_type_is_a(type, isAType);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_class(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        public static string NameFromClass(TypeClass gClass)
        {
            if (gClass == null)
            {
                throw new ArgumentNullException("gClass");
            }
            var gClass_ = gClass == null ? IntPtr.Zero : gClass.Handle;
            var ret_ = g_type_name_from_class(gClass_);
            var ret = MarshalG.Utf8PtrToString(ret_, false);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        public static string NameFromInstance(TypeInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret_ = g_type_name_from_instance(instance_);
            var ret = MarshalG.Utf8PtrToString(ret_, false);
            return ret;
        }

        /// <summary>
        /// Given a @leaf_type and a @root_type which is contained in its
        /// anchestry, return the type that @root_type is the immediate parent
        /// of. In other words, this function determines the type that is
        /// derived directly from @root_type which is also a base class of
        /// @leaf_type.  Given a root type and a leaf type, this function can
        /// be used to determine the types and order in which the leaf type is
        /// descended from the root type.
        /// </summary>
        /// <param name="leafType">
        /// descendant of @root_type and the type to be returned
        /// </param>
        /// <param name="rootType">
        /// immediate parent of the returned type
        /// </param>
        /// <returns>
        /// immediate child of @root_type and anchestor of @leaf_type
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_next_base(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType leafType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType rootType);

        /// <summary>
        /// Given a @leaf_type and a @root_type which is contained in its
        /// anchestry, return the type that @root_type is the immediate parent
        /// of. In other words, this function determines the type that is
        /// derived directly from @root_type which is also a base class of
        /// @leaf_type.  Given a root type and a leaf type, this function can
        /// be used to determine the types and order in which the leaf type is
        /// descended from the root type.
        /// </summary>
        /// <param name="leafType">
        /// descendant of @root_type and the type to be returned
        /// </param>
        /// <param name="rootType">
        /// immediate parent of the returned type
        /// </param>
        /// <returns>
        /// immediate child of @root_type and anchestor of @leaf_type
        /// </returns>
        public static GType NextBase(GType leafType, GType rootType)
        {
            var ret = g_type_next_base(leafType, rootType);
            return ret;
        }

        /// <summary>
        /// Get the corresponding quark of the type IDs name.
        /// </summary>
        /// <param name="type">
        /// type to return quark of type name for
        /// </param>
        /// <returns>
        /// the type names quark or 0
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        /* transfer-ownership:none */
        static extern GISharp.GLib.Quark g_type_qname(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Get the corresponding quark of the type IDs name.
        /// </summary>
        /// <param name="type">
        /// type to return quark of type name for
        /// </param>
        /// <returns>
        /// the type names quark or 0
        /// </returns>
        public static GISharp.GLib.Quark Qname(GType type)
        {
            var ret = g_type_qname(type);
            return ret;
        }

        /// <summary>
        /// Queries the type system for information about a specific type.
        /// This function will fill in a user-provided structure to hold
        /// type-specific information. If an invalid #GType is passed in, the
        /// @type member of the #GTypeQuery is 0. All members filled into the
        /// #GTypeQuery structure should be considered constant and have to be
        /// left untouched.
        /// </summary>
        /// <param name="type">
        /// #GType of a static, classed type
        /// </param>
        /// <param name="query">
        /// a user provided structure that is
        ///     filled in with constant values upon success
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_query(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="TypeQuery" type="GTypeQuery*" managed-name="TypeQuery" /> */
            /* direction:out caller-allocates:1 transfer-ownership:none */
            ref TypeQuery query);

        /// <summary>
        /// Queries the type system for information about a specific type.
        /// This function will fill in a user-provided structure to hold
        /// type-specific information. If an invalid #GType is passed in, the
        /// @type member of the #GTypeQuery is 0. All members filled into the
        /// #GTypeQuery structure should be considered constant and have to be
        /// left untouched.
        /// </summary>
        /// <param name="type">
        /// #GType of a static, classed type
        /// </param>
        /// <param name="query">
        /// a user provided structure that is
        ///     filled in with constant values upon success
        /// </param>
        public static void Query(GType type, ref TypeQuery query)
        {
            g_type_query(type,ref query);
        }

        /// <summary>
        /// Registers @type_name as the name of a new dynamic type derived from
        /// @parent_type.  The type system uses the information contained in the
        /// #GTypePlugin structure pointed to by @plugin to manage the type and its
        /// instances (if not abstract).  The value of @flags determines the nature
        /// (e.g. abstract or not) of the type.
        /// </summary>
        /// <param name="parentType">
        /// type from which this type will be derived
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GTypeInfo from
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the new type identifier or #G_TYPE_INVALID if registration failed
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_register_dynamic(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType parentType,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeName,
            /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
            /* transfer-ownership:none */
            IntPtr plugin,
            /* <type name="TypeFlags" type="GTypeFlags" managed-name="TypeFlags" /> */
            /* transfer-ownership:none */
            TypeFlags flags);

        /// <summary>
        /// Registers @type_name as the name of a new dynamic type derived from
        /// @parent_type.  The type system uses the information contained in the
        /// #GTypePlugin structure pointed to by @plugin to manage the type and its
        /// instances (if not abstract).  The value of @flags determines the nature
        /// (e.g. abstract or not) of the type.
        /// </summary>
        /// <param name="parentType">
        /// type from which this type will be derived
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="plugin">
        /// #GTypePlugin structure to retrieve the #GTypeInfo from
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the new type identifier or #G_TYPE_INVALID if registration failed
        /// </returns>
        public static GType RegisterDynamic(GType parentType, string typeName, TypePlugin plugin, TypeFlags flags)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }
            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }
            var typeName_ = MarshalG.StringToUtf8Ptr(typeName);
            var plugin_ = default(IntPtr);
            throw new System.NotImplementedException();
            var ret = g_type_register_dynamic(parentType, typeName_, plugin_, flags);
            MarshalG.Free(typeName_);
            return ret;
        }

        /// <summary>
        /// Registers @type_id as the predefined identifier and @type_name as the
        /// name of a fundamental type. If @type_id is already registered, or a
        /// type named @type_name is already registered, the behaviour is undefined.
        /// The type system uses the information contained in the #GTypeInfo structure
        /// pointed to by @info and the #GTypeFundamentalInfo structure pointed to by
        /// @finfo to manage the type and its instances. The value of @flags determines
        /// additional characteristics of the fundamental type.
        /// </summary>
        /// <param name="typeId">
        /// a predefined type identifier
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="info">
        /// #GTypeInfo structure for this type
        /// </param>
        /// <param name="finfo">
        /// #GTypeFundamentalInfo structure for this type
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the predefined type identifier
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_register_fundamental(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType typeId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr typeName,
            /* <type name="TypeInfo" type="const GTypeInfo*" managed-name="TypeInfo" /> */
            /* transfer-ownership:none */
            TypeInfo info,
            /* <type name="TypeFundamentalInfo" type="const GTypeFundamentalInfo*" managed-name="TypeFundamentalInfo" /> */
            /* transfer-ownership:none */
            TypeFundamentalInfo finfo,
            /* <type name="TypeFlags" type="GTypeFlags" managed-name="TypeFlags" /> */
            /* transfer-ownership:none */
            TypeFlags flags);

        /// <summary>
        /// Registers @type_id as the predefined identifier and @type_name as the
        /// name of a fundamental type. If @type_id is already registered, or a
        /// type named @type_name is already registered, the behaviour is undefined.
        /// The type system uses the information contained in the #GTypeInfo structure
        /// pointed to by @info and the #GTypeFundamentalInfo structure pointed to by
        /// @finfo to manage the type and its instances. The value of @flags determines
        /// additional characteristics of the fundamental type.
        /// </summary>
        /// <param name="typeId">
        /// a predefined type identifier
        /// </param>
        /// <param name="typeName">
        /// 0-terminated string used as the name of the new type
        /// </param>
        /// <param name="info">
        /// #GTypeInfo structure for this type
        /// </param>
        /// <param name="finfo">
        /// #GTypeFundamentalInfo structure for this type
        /// </param>
        /// <param name="flags">
        /// bitwise combination of #GTypeFlags values
        /// </param>
        /// <returns>
        /// the predefined type identifier
        /// </returns>
        public static GType RegisterFundamental(GType typeId, string typeName, TypeInfo info, TypeFundamentalInfo finfo, TypeFlags flags)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }
            var typeName_ = MarshalG.StringToUtf8Ptr(typeName);
            var ret = g_type_register_fundamental(typeId, typeName_, info, finfo, flags);
            MarshalG.Free(typeName_);
            return ret;
        }

        /// <summary>
        /// Removes a previously installed #GTypeClassCacheFunc. The cache
        /// maintained by @cache_func has to be empty when calling
        /// g_type_remove_class_cache_func() to avoid leaks.
        /// </summary>
        /// <param name="cacheData">
        /// data that was given when adding @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            NativeTypeClassCacheFunc cacheFunc);

        /// <summary>
        /// Removes a previously installed #GTypeClassCacheFunc. The cache
        /// maintained by @cache_func has to be empty when calling
        /// g_type_remove_class_cache_func() to avoid leaks.
        /// </summary>
        /// <param name="cacheData">
        /// data that was given when adding @cache_func
        /// </param>
        /// <param name="cacheFunc">
        /// a #GTypeClassCacheFunc
        /// </param>
        public static void RemoveClassCacheFunc(IntPtr cacheData, TypeClassCacheFunc cacheFunc)
        {
            if (cacheFunc == null)
            {
                throw new ArgumentNullException("cacheFunc");
            }
            var cacheFunc_ = NativeTypeClassCacheFuncFactory.Create(cacheFunc, false);
            g_type_remove_class_cache_func(cacheData, cacheFunc_);
        }

        /// <summary>
        /// Removes an interface check function added with
        /// g_type_add_interface_check().
        /// </summary>
        /// <param name="checkData">
        /// callback data passed to g_type_add_interface_check()
        /// </param>
        /// <param name="checkFunc">
        /// callback function passed to g_type_add_interface_check()
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            NativeTypeInterfaceCheckFunc checkFunc);

        /// <summary>
        /// Removes an interface check function added with
        /// g_type_add_interface_check().
        /// </summary>
        /// <param name="checkData">
        /// callback data passed to g_type_add_interface_check()
        /// </param>
        /// <param name="checkFunc">
        /// callback function passed to g_type_add_interface_check()
        /// </param>
        [Since ("2.4")]
        public static void RemoveInterfaceCheck(IntPtr checkData, TypeInterfaceCheckFunc checkFunc)
        {
            if (checkFunc == null)
            {
                throw new ArgumentNullException("checkFunc");
            }
            var checkFunc_ = NativeTypeInterfaceCheckFuncFactory.Create(checkFunc, false);
            g_type_remove_interface_check(checkData, checkFunc_);
        }

        /// <summary>
        /// Attaches arbitrary data to a type.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <param name="data">
        /// the data
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_set_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            GISharp.GLib.Quark quark,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data);

        /// <summary>
        /// Attaches arbitrary data to a type.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <param name="quark">
        /// a #GQuark id to identify the data
        /// </param>
        /// <param name="data">
        /// the data
        /// </param>
        public static void SetQdata(GType type, GISharp.GLib.Quark quark, IntPtr data)
        {
            g_type_set_qdata(type, quark, data);
        }
#endif
    }

    public class InvalidGTypeNameException : Exception
    {
        public InvalidGTypeNameException (string message) : base (message)
        {
        }
    }

    /// <summary>
    /// Bit masks used to check or determine characteristics of a type.
    /// </summary>
    [Flags]
    enum TypeFlags
    {
        /// <summary>
        /// Indicates a classed type
        /// </summary>
        Classed = 1,

        /// <summary>
        /// Indicates an instantiable type (implies classed)
        /// </summary>
        Instantiatable = 2,

        /// <summary>
        /// Indicates a flat derivable type
        /// </summary>
        Derivable = 4,

        /// <summary>
        /// Indicates a deep derivable type (implies derivable)
        /// </summary>
        DeepDerivable = 8,

        /// <summary>
        /// Indicates an abstract type. No instances can be
        ///  created for an abstract type
        /// </summary>
        Abstract = 16,

        /// <summary>
        /// Indicates an abstract value type, i.e. a type
        ///  that introduces a value table, but can't be used for
        ///  g_value_init()
        /// </summary>
        ValueAbstract = 32,
    }

    /// <summary>
    /// A callback function used by the type system to do base initialization
    /// of the class structures of derived types. It is called as part of the
    /// initialization process of all derived classes and should reallocate
    /// or reset all dynamic class members copied over from the parent class.
    /// For example, class members (such as strings) that are not sufficiently
    /// handled by a plain memory copy of the parent class into the derived class
    /// have to be altered. See GClassInitFunc() for a discussion of the class
    /// intialization process.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeBaseInitFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to do base initialization
    /// of the class structures of derived types. It is called as part of the
    /// initialization process of all derived classes and should reallocate
    /// or reset all dynamic class members copied over from the parent class.
    /// For example, class members (such as strings) that are not sufficiently
    /// handled by a plain memory copy of the parent class into the derived class
    /// have to be altered. See GClassInitFunc() for a discussion of the class
    /// intialization process.
    /// </summary>
    delegate void BaseInitFunc(IntPtr gClass);

    /// <summary>
    /// Factory for creating <see cref="NativeBaseInitFunc"/> methods.
    /// </summary>
    public static class NativeBaseInitFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="BaseInitFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        static NativeBaseInitFunc Create(BaseInitFunc method, bool freeUserData)
        {
            NativeBaseInitFunc nativeCallback = (
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gClass_) =>
            {
                method.Invoke(gClass_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// A callback function used by the type system to finalize those portions
    /// of a derived types class structure that were setup from the corresponding
    /// GBaseInitFunc() function. Class finalization basically works the inverse
    /// way in which class intialization is performed.
    /// See GClassInitFunc() for a discussion of the class intialization process.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeBaseFinalizeFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to finalize those portions
    /// of a derived types class structure that were setup from the corresponding
    /// GBaseInitFunc() function. Class finalization basically works the inverse
    /// way in which class intialization is performed.
    /// See GClassInitFunc() for a discussion of the class intialization process.
    /// </summary>
    delegate void BaseFinalizeFunc(IntPtr gClass);

    /// <summary>
    /// Factory for creating <see cref="NativeBaseFinalizeFunc"/> methods.
    /// </summary>
    static class NativeBaseFinalizeFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="BaseFinalizeFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        public static NativeBaseFinalizeFunc Create (BaseFinalizeFunc method, bool freeUserData)
        {
            NativeBaseFinalizeFunc nativeCallback = (
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gClass_) =>
            {
                method.Invoke(gClass_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// A callback function used by the type system to initialize the class
    /// of a specific type. This function should initialize all static class
    /// members.
    /// </summary>
    /// <remarks>
    /// The initialization process of a class involves:
    /// 
    /// - Copying common members from the parent class over to the
    ///   derived class structure.
    /// - Zero initialization of the remaining members not copied
    ///   over from the parent class.
    /// - Invocation of the GBaseInitFunc() initializers of all parent
    ///   types and the class' type.
    /// - Invocation of the class' GClassInitFunc() initializer.
    /// 
    /// Since derived classes are partially initialized through a memory copy
    /// of the parent class, the general rule is that GBaseInitFunc() and
    /// GBaseFinalizeFunc() should take care of necessary reinitialization
    /// and release of those class members that were introduced by the type
    /// that specified these GBaseInitFunc()/GBaseFinalizeFunc().
    /// GClassInitFunc() should only care about initializing static
    /// class members, while dynamic class members (such as allocated strings
    /// or reference counted resources) are better handled by a GBaseInitFunc()
    /// for this type, so proper initialization of the dynamic class members
    /// is performed for class initialization of derived types as well.
    /// 
    /// An example may help to correspond the intend of the different class
    /// initializers:
    /// 
    /// |[&lt;!-- language="C" --&gt;
    /// typedef struct {
    ///   GObjectClass parent_class;
    ///   gint         static_integer;
    ///   gchar       *dynamic_string;
    /// } TypeAClass;
    /// static void
    /// type_a_base_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;dynamic_string = g_strdup ("some string");
    /// }
    /// static void
    /// type_a_base_class_finalize (TypeAClass *class)
    /// {
    ///   g_free (class-&gt;dynamic_string);
    /// }
    /// static void
    /// type_a_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;static_integer = 42;
    /// }
    /// 
    /// typedef struct {
    ///   TypeAClass   parent_class;
    ///   gfloat       static_float;
    ///   GString     *dynamic_gstring;
    /// } TypeBClass;
    /// static void
    /// type_b_base_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;dynamic_gstring = g_string_new ("some other string");
    /// }
    /// static void
    /// type_b_base_class_finalize (TypeBClass *class)
    /// {
    ///   g_string_free (class-&gt;dynamic_gstring);
    /// }
    /// static void
    /// type_b_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;static_float = 3.14159265358979323846;
    /// }
    /// ]|
    /// Initialization of TypeBClass will first cause initialization of
    /// TypeAClass (derived classes reference their parent classes, see
    /// g_type_class_ref() on this).
    /// 
    /// Initialization of TypeAClass roughly involves zero-initializing its fields,
    /// then calling its GBaseInitFunc() type_a_base_class_init() to allocate
    /// its dynamic members (dynamic_string), and finally calling its GClassInitFunc()
    /// type_a_class_init() to initialize its static members (static_integer).
    /// The first step in the initialization process of TypeBClass is then
    /// a plain memory copy of the contents of TypeAClass into TypeBClass and
    /// zero-initialization of the remaining fields in TypeBClass.
    /// The dynamic members of TypeAClass within TypeBClass now need
    /// reinitialization which is performed by calling type_a_base_class_init()
    /// with an argument of TypeBClass.
    /// 
    /// After that, the GBaseInitFunc() of TypeBClass, type_b_base_class_init()
    /// is called to allocate the dynamic members of TypeBClass (dynamic_gstring),
    /// and finally the GClassInitFunc() of TypeBClass, type_b_class_init(),
    /// is called to complete the initialization process with the static members
    /// (static_float).
    /// 
    /// Corresponding finalization counter parts to the GBaseInitFunc() functions
    /// have to be provided to release allocated resources at class finalization
    /// time.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClassInitFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr classData);

    /// <summary>
    /// A callback function used by the type system to initialize the class
    /// of a specific type. This function should initialize all static class
    /// members.
    /// </summary>
    /// <remarks>
    /// The initialization process of a class involves:
    /// 
    /// - Copying common members from the parent class over to the
    ///   derived class structure.
    /// - Zero initialization of the remaining members not copied
    ///   over from the parent class.
    /// - Invocation of the GBaseInitFunc() initializers of all parent
    ///   types and the class' type.
    /// - Invocation of the class' GClassInitFunc() initializer.
    /// 
    /// Since derived classes are partially initialized through a memory copy
    /// of the parent class, the general rule is that GBaseInitFunc() and
    /// GBaseFinalizeFunc() should take care of necessary reinitialization
    /// and release of those class members that were introduced by the type
    /// that specified these GBaseInitFunc()/GBaseFinalizeFunc().
    /// GClassInitFunc() should only care about initializing static
    /// class members, while dynamic class members (such as allocated strings
    /// or reference counted resources) are better handled by a GBaseInitFunc()
    /// for this type, so proper initialization of the dynamic class members
    /// is performed for class initialization of derived types as well.
    /// 
    /// An example may help to correspond the intend of the different class
    /// initializers:
    /// 
    /// |[&lt;!-- language="C" --&gt;
    /// typedef struct {
    ///   GObjectClass parent_class;
    ///   gint         static_integer;
    ///   gchar       *dynamic_string;
    /// } TypeAClass;
    /// static void
    /// type_a_base_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;dynamic_string = g_strdup ("some string");
    /// }
    /// static void
    /// type_a_base_class_finalize (TypeAClass *class)
    /// {
    ///   g_free (class-&gt;dynamic_string);
    /// }
    /// static void
    /// type_a_class_init (TypeAClass *class)
    /// {
    ///   class-&gt;static_integer = 42;
    /// }
    /// 
    /// typedef struct {
    ///   TypeAClass   parent_class;
    ///   gfloat       static_float;
    ///   GString     *dynamic_gstring;
    /// } TypeBClass;
    /// static void
    /// type_b_base_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;dynamic_gstring = g_string_new ("some other string");
    /// }
    /// static void
    /// type_b_base_class_finalize (TypeBClass *class)
    /// {
    ///   g_string_free (class-&gt;dynamic_gstring);
    /// }
    /// static void
    /// type_b_class_init (TypeBClass *class)
    /// {
    ///   class-&gt;static_float = 3.14159265358979323846;
    /// }
    /// ]|
    /// Initialization of TypeBClass will first cause initialization of
    /// TypeAClass (derived classes reference their parent classes, see
    /// g_type_class_ref() on this).
    /// 
    /// Initialization of TypeAClass roughly involves zero-initializing its fields,
    /// then calling its GBaseInitFunc() type_a_base_class_init() to allocate
    /// its dynamic members (dynamic_string), and finally calling its GClassInitFunc()
    /// type_a_class_init() to initialize its static members (static_integer).
    /// The first step in the initialization process of TypeBClass is then
    /// a plain memory copy of the contents of TypeAClass into TypeBClass and
    /// zero-initialization of the remaining fields in TypeBClass.
    /// The dynamic members of TypeAClass within TypeBClass now need
    /// reinitialization which is performed by calling type_a_base_class_init()
    /// with an argument of TypeBClass.
    /// 
    /// After that, the GBaseInitFunc() of TypeBClass, type_b_base_class_init()
    /// is called to allocate the dynamic members of TypeBClass (dynamic_gstring),
    /// and finally the GClassInitFunc() of TypeBClass, type_b_class_init(),
    /// is called to complete the initialization process with the static members
    /// (static_float).
    /// 
    /// Corresponding finalization counter parts to the GBaseInitFunc() functions
    /// have to be provided to release allocated resources at class finalization
    /// time.
    /// </remarks>
    delegate void ClassInitFunc(IntPtr gClass, IntPtr classData);

    /// <summary>
    /// Factory for creating <see cref="NativeClassInitFunc"/> methods.
    /// </summary>
    static class NativeClassInitFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="ClassInitFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        public static NativeClassInitFunc Create (ClassInitFunc method, bool freeUserData)
        {
            NativeClassInitFunc nativeCallback = (
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gClass_,
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr classData_) =>
            {
                method.Invoke(gClass_, classData_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// A callback function used by the type system to finalize a class.
    /// This function is rarely needed, as dynamically allocated class resources
    /// should be handled by GBaseInitFunc() and GBaseFinalizeFunc().
    /// Also, specification of a GClassFinalizeFunc() in the #GTypeInfo
    /// structure of a static type is invalid, because classes of static types
    /// will never be finalized (they are artificially kept alive when their
    /// reference count drops to zero).
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeClassFinalizeFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr classData);

    /// <summary>
    /// A callback function used by the type system to finalize a class.
    /// This function is rarely needed, as dynamically allocated class resources
    /// should be handled by GBaseInitFunc() and GBaseFinalizeFunc().
    /// Also, specification of a GClassFinalizeFunc() in the #GTypeInfo
    /// structure of a static type is invalid, because classes of static types
    /// will never be finalized (they are artificially kept alive when their
    /// reference count drops to zero).
    /// </summary>
    delegate void ClassFinalizeFunc(IntPtr gClass, IntPtr classData);

    /// <summary>
    /// Factory for creating <see cref="NativeClassFinalizeFunc"/> methods.
    /// </summary>
    static class NativeClassFinalizeFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="ClassFinalizeFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        static NativeClassFinalizeFunc Create (ClassFinalizeFunc method, bool freeUserData)
        {
            NativeClassFinalizeFunc nativeCallback = (
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gClass_,
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr classData_) =>
            {
                method.Invoke(gClass_, classData_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// A callback function used by the type system to initialize a new
    /// instance of a type. This function initializes all instance members and
    /// allocates any resources required by it.
    /// </summary>
    /// <remarks>
    /// Initialization of a derived instance involves calling all its parent
    /// types instance initializers, so the class member of the instance
    /// is altered during its initialization to always point to the class that
    /// belongs to the type the current initializer was introduced for.
    /// 
    /// The extended members of @instance are guaranteed to have been filled with
    /// zeros before this function is called.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void NativeInstanceInitFunc(
        /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
        /* transfer-ownership:none */
        IntPtr instance,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gClass);

    /// <summary>
    /// A callback function used by the type system to initialize a new
    /// instance of a type. This function initializes all instance members and
    /// allocates any resources required by it.
    /// </summary>
    /// <remarks>
    /// Initialization of a derived instance involves calling all its parent
    /// types instance initializers, so the class member of the instance
    /// is altered during its initialization to always point to the class that
    /// belongs to the type the current initializer was introduced for.
    /// 
    /// The extended members of @instance are guaranteed to have been filled with
    /// zeros before this function is called.
    /// </remarks>
    delegate void InstanceInitFunc(TypeInstance instance, IntPtr gClass);

    /// <summary>
    /// Factory for creating <see cref="NativeInstanceInitFunc"/> methods.
    /// </summary>
    static class NativeInstanceInitFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="InstanceInitFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        public static NativeInstanceInitFunc Create(InstanceInitFunc method, bool freeUserData)
        {
            NativeInstanceInitFunc nativeCallback = (
                /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
                /* transfer-ownership:none */
                IntPtr instance_,
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gClass_) =>
            {
                var instance = Opaque.GetInstance<TypeInstance>(instance_, Transfer.None);
                method.Invoke(instance, gClass_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// A callback function used by the type system to finalize an interface.
    /// This function should destroy any internal data and release any resources
    /// allocated by the corresponding GInterfaceInitFunc() function.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void NativeInterfaceFinalizeFunc(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr gIface,
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr ifaceData);

    /// <summary>
    /// A callback function used by the type system to finalize an interface.
    /// This function should destroy any internal data and release any resources
    /// allocated by the corresponding GInterfaceInitFunc() function.
    /// </summary>
    delegate void InterfaceFinalizeFunc(IntPtr gIface, IntPtr ifaceData);

    /// <summary>
    /// Factory for creating <see cref="NativeInterfaceFinalizeFunc"/> methods.
    /// </summary>
    public static class NativeInterfaceFinalizeFuncFactory
    {
        /// <summary>
        /// Wraps <see cref="InterfaceFinalizeFunc"/> in an anonymous method that can be passed
        /// to unmaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
        /// data closure parameters in the unmanged function</param>
        /// <returns>The callback method for passing to unmanged code.</returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged code. If this
        /// callback is only called once, <paramref name="freeUserData"/> should be
        /// set to <c>true</c>. If it can be called multiple times, it should be set to
        /// <c>false</c> and the user data must be freed elsewhere. If the callback does
        /// not have closure user data, then the <paramref name="freeUserData"/> 
        /// parameter has no effect.
        /// </remarks>
        static NativeInterfaceFinalizeFunc Create (InterfaceFinalizeFunc method, bool freeUserData)
        {
            NativeInterfaceFinalizeFunc nativeCallback = (
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr gIface_,
                /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
                /* transfer-ownership:none */
                IntPtr ifaceData_) =>
            {
                method.Invoke(gIface_, ifaceData_);
            };
            return nativeCallback;
        }
    }

    /// <summary>
    /// This structure is used to provide the type system with the information
    /// required to initialize and destruct (finalize) a type's class and
    /// its instances.
    /// </summary>
    /// <remarks>
    /// The initialized structure is passed to the g_type_register_static() function
    /// (or is copied into the provided #GTypeInfo structure in the
    /// g_type_plugin_complete_type_info()). The type system will perform a deep
    /// copy of this structure, so its memory does not need to be persistent
    /// across invocation of g_type_register_static().
    /// </remarks>
    struct TypeInfo
    {
        /// <summary>
        /// Size of the class structure (required for interface, classed and instantiatable types)
        /// </summary>
        public ushort ClassSize;

        /// <summary>
        /// Location of the base initialization function (optional)
        /// </summary>
        public NativeBaseInitFunc BaseInit;

        /// <summary>
        /// Location of the base finalization function (optional)
        /// </summary>
        public NativeBaseFinalizeFunc BaseFinalize;

        /// <summary>
        /// Location of the class initialization function for
        ///  classed and instantiatable types. Location of the default vtable
        ///  inititalization function for interface types. (optional) This function
        ///  is used both to fill in virtual functions in the class or default vtable,
        ///  and to do type-specific setup such as registering signals and object
        ///  properties.
        /// </summary>
        public NativeClassInitFunc ClassInit;

        /// <summary>
        /// Location of the class finalization function for
        ///  classed and instantiatable types. Location of the default vtable
        ///  finalization function for interface types. (optional)
        /// </summary>
        public NativeClassFinalizeFunc ClassFinalize;

        /// <summary>
        /// User-supplied data passed to the class init/finalize functions
        /// </summary>
        public IntPtr ClassData;

        /// <summary>
        /// Size of the instance (object) structure (required for instantiatable types only)
        /// </summary>
        public ushort InstanceSize;

        /// <summary>
        /// Prior to GLib 2.10, it specified the number of pre-allocated (cached) instances to reserve memory for (0 indicates no caching). Since GLib 2.10, it is ignored, since instances are allocated with the [slice allocator][glib-Memory-Slices] now.
        /// </summary>
        public ushort NPreallocs;

        /// <summary>
        /// Location of the instance initialization function (optional, for instantiatable types only)
        /// </summary>
        public NativeInstanceInitFunc InstanceInit;

        /// <summary>
        /// A #GTypeValueTable function table for generic handling of GValues
        ///  of this type (usually only useful for fundamental types)
        /// </summary>
        public TypeValueTable ValueTable;
    }

    /// <summary>
    /// The #GTypeValueTable provides the functions required by the #GValue
    /// implementation, to serve as a container for values of a type.
    /// </summary>
    struct TypeValueTable
    {
        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueInit(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate void ValueInit(Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValueInit"/> methods.
        /// </summary>
        public static class NativeValueInitFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueInit"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueInit Create(ValueInit method, bool freeUserData)
            {
                NativeValueInit nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    method.Invoke(value);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueInit ValueInitImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueFree(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate void ValueFree(Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValueFree"/> methods.
        /// </summary>
        public static class NativeValueFreeFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueFree"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueFree Create(ValueFree method, bool freeUserData)
            {
                NativeValueFree nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    method.Invoke(value);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueFree ValueFreeImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate void NativeValueCopy(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr srcValue,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr destValue);

        public delegate void ValueCopy(Value srcValue, Value destValue);

        /// <summary>
        /// Factory for creating <see cref="NativeValueCopy"/> methods.
        /// </summary>
        public static class NativeValueCopyFactory
        {
            /// <summary>
            /// Wraps <see cref="ValueCopy"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeValueCopy Create(ValueCopy method, bool freeUserData)
            {
                NativeValueCopy nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr srcValue_,
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr destValue_) =>
                {
                    var srcValue = Opaque.GetInstance<Value>(srcValue_, Transfer.None);
                    var destValue = Opaque.GetInstance<Value>(destValue_, Transfer.None);
                    method.Invoke(srcValue, destValue);
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValueCopy ValueCopyImpl;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeValuePeekPointer (
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value);

        public delegate IntPtr ValuePeekPointer (Value value);

        /// <summary>
        /// Factory for creating <see cref="NativeValuePeekPointer"/> methods.
        /// </summary>
        public static class NativeValuePeekPointerFactory
        {
            /// <summary>
            /// Wraps <see cref="ValuePeekPointer"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeValuePeekPointer Create(ValuePeekPointer method, bool freeUserData)
            {
                NativeValuePeekPointer nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var ret_ = method.Invoke(value);
                    return ret_;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeValuePeekPointer ValuePeekPointerImpl;

        /// <summary>
        /// A string format describing how to collect the contents of
        ///  this value bit-by-bit. Each character in the format represents
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
        /// </summary>
        public IntPtr CollectFormat;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate IntPtr NativeCollectValue(
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nCollectValues,
            /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
            /* transfer-ownership:none */
            IntPtr collectValues,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint collectFlags);

        public delegate string CollectValue (Value value, TypeCValue[] collectValues, uint collectFlags);

        /// <summary>
        /// Factory for creating <see cref="NativeCollectValue"/> methods.
        /// </summary>
        public static class NativeCollectValueFactory
        {
            /// <summary>
            /// Wraps <see cref="CollectValue"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeCollectValue Create(CollectValue method, bool freeUserData)
            {
                NativeCollectValue nativeCallback = (
                    /* <type name="Value" type="GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                    IntPtr collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint collectFlags_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var collectValues = MarshalG.PtrToCArray<TypeCValue> (collectValues_, (int)nCollectValues_);
                    var ret = method.Invoke(value, collectValues, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr(ret);
                    return ret_;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeCollectValue CollectValueImpl;

        /// <summary>
        /// Format description of the arguments to collect for @lcopy_value,
        ///  analogous to @collect_format. Usually, @lcopy_format string consists
        ///  only of 'p's to provide lcopy_value() with pointers to storage locations.
        /// </summary>
        public IntPtr LcopyFormat;

        [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
        public delegate string NativeLcopyValue(
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            IntPtr value,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nCollectValues,
            /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
            /* transfer-ownership:none */
            TypeCValue collectValues,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint collectFlags);

        public delegate string LcopyValue(Value value, uint nCollectValues, TypeCValue collectValues, uint collectFlags);

        /// <summary>
        /// Factory for creating <see cref="NativeLcopyValue"/> methods.
        /// </summary>
        public static class NativeLcopyValueFactory
        {
            /// <summary>
            /// Wraps <see cref="LcopyValue"/> in an anonymous method that can be passed
            /// to unmaged code.
            /// </summary>
            /// <param name="method">The managed method to wrap.</param>
            /// <param name="freeUserData">Frees the <see cref="GCHandle"/> for any user
            /// data closure parameters in the unmanged function</param>
            /// <returns>The callback method for passing to unmanged code.</returns>
            /// <remarks>
            /// This function is used to marshal managed callbacks to unmanged code. If this
            /// callback is only called once, <paramref name="freeUserData"/> should be
            /// set to <c>true</c>. If it can be called multiple times, it should be set to
            /// <c>false</c> and the user data must be freed elsewhere. If the callback does
            /// not have closure user data, then the <paramref name="freeUserData"/> 
            /// parameter has no effect.
            /// </remarks>
            public static NativeLcopyValue Create(LcopyValue method, bool freeUserData)
            {
                NativeLcopyValue nativeCallback = (
                    /* <type name="Value" type="const GValue*" managed-name="Value" /> */
                    /* transfer-ownership:none */
                    IntPtr value_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint nCollectValues_,
                    /* <type name="TypeCValue" type="GTypeCValue*" managed-name="TypeCValue" /> */
                    /* transfer-ownership:none */
                    TypeCValue collectValues_,
                    /* <type name="guint" type="guint" managed-name="Guint" /> */
                    /* transfer-ownership:none */
                    uint collectFlags_) =>
                {
                    var value = Opaque.GetInstance<Value>(value_, Transfer.None);
                    var ret = method.Invoke(value, nCollectValues_, collectValues_, collectFlags_);
                    var ret_ = MarshalG.StringToUtf8Ptr(ret);
                    return ret;
                };
                return nativeCallback;
            }
        }

        [MarshalAs (UnmanagedType.FunctionPtr)]
        public NativeLcopyValue LcopyValueImpl;

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
        [DllImport ("gobject-2.0.dll", CallingConvention =  CallingConvention.Cdecl)]
        /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" /> */
        /* */
        static extern TypeValueTable g_type_value_table_peek(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

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
        public static TypeValueTable Peek(GType type)
        {
            var ret = g_type_value_table_peek(type);
            return ret;
        }
    }

    /// <summary>
    /// A union holding one collected value.
    /// </summary>
    [StructLayout (LayoutKind.Explicit)]
    struct TypeCValue
    {
        /// <summary>
        /// the field for holding integer values
        /// </summary>
        [FieldOffset (0)]
        public int VInt;

        /// <summary>
        /// the field for holding long integer values
        /// </summary>
        [FieldOffset (0)]
        public long VLong;

        /// <summary>
        /// the field for holding 64 bit integer values
        /// </summary>
        [FieldOffset (0)]
        public long VInt64;

        /// <summary>
        /// the field for holding floating point values
        /// </summary>
        [FieldOffset (0)]
        public double VDouble;

        /// <summary>
        /// the field for holding pointers
        /// </summary>
        [FieldOffset (0)]
        public IntPtr VPointer;
    }

    public static class GTypeExtenstion
    {
        /// <summary>
        /// Gets the type name used by the GObject type system.
        /// </summary>
        /// <returns>The name.</returns>
        /// <param name="type">Type.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="type"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="type"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static string GetGTypeName (this Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            var gtypeAttr = (GTypeAttribute)type.GetCustomAttributes (
                typeof (GTypeAttribute), false).SingleOrDefault ();
            if (gtypeAttr == null) {
                var message = string.Format ("The type '{0}' does not have {1}",
                                             type.FullName, typeof (GTypeAttribute).FullName);
                throw new ArgumentException (message, nameof (type));
            }
            return gtypeAttr.Name ?? type.FullName.Replace ('.', '-');
        }

        /// <summary>
        /// Gets the <see cref="GType"/> for the managed type.
        /// </summary>
        /// <returns>
        /// The <see cref="GType"/> or <see cref="GType.Invalid"/> if the type
        /// is not registered.
        /// </returns>
        /// <param name="type">Type.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="type"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="type"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static GType GetGType (this Type type)
        {
            return GType.FromName (type.GetGTypeName ());
        }
    }

    /// <summary>
    /// An opaque structure used as the base of all type instances.
    /// </summary>
    class TypeInstance : StaticOpaque
    {
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* */
        static extern IntPtr g_type_instance_get_private (
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType privateType);

        public IntPtr GetPrivate (GType privateType)
        {
            AssertNotDisposed();
            var ret = g_type_instance_get_private(Handle, privateType);
            return ret;
        }

        TypeInstance(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }
    }
}
