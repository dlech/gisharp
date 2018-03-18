using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Reflection;

using GISharp.Lib.GLib;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;
using BindFlags = System.Reflection.BindingFlags;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A numerical value which represents the unique identifier of a registered
    /// type.
    /// </summary>
    [GType ("GType", IsProxyForUnmanagedType = true)]
    [DebuggerDisplay ("{Name}")]
    public struct GType
    {
        static readonly Quark managedTypeQuark = Quark.FromString("gisharp-gtype-managed-type-quark");
        static readonly Dictionary<Type, GType> typeMap;
        static object mapLock;

        #pragma warning disable 414
        // There is an unfortunate bug that g_type_add_interface_static() will
        // fail to install properties because class_init of GObject has not
        // been run yet to create the param spec pool.
        //
        // The error is "g_param_spec_pool_lookup: assertion 'pool != NULL' failed"
        //
        // creating an object here and keeping it around forever will ensure
        // that class_init is run before we try to add any interfaces.
        //
        // Since the GISharp.Lib.GObject.Object class depends on GType, we have to
        // use pinvoke directly.
        static readonly IntPtr eternalObject = GObject.Object.g_object_newv (Object, 0, IntPtr.Zero);
        #pragma warning restore 414

        static GType ()
        {
            typeMap = new Dictionary<Type, GType> ();
            mapLock = new object ();

            // add the built-in fundamental types
            lock (mapLock) {
                GType gtype;

                gtype = None;
                typeMap.Add(typeof(void), gtype);
                gtype[managedTypeQuark] = typeof(void);

                gtype = Interface;
                typeMap.Add(typeof(GInterface<>), gtype);
                gtype[managedTypeQuark] = typeof(GInterface<>);

                gtype = Char;
                typeMap.Add(typeof(sbyte), gtype);
                gtype[managedTypeQuark] = typeof(sbyte);

                gtype = UChar;
                typeMap.Add(typeof(byte), gtype);
                gtype[managedTypeQuark] = typeof(byte);

                gtype = Boolean;
                typeMap.Add(typeof(bool), gtype);
                gtype[managedTypeQuark] = typeof(bool);

                gtype = Int;
                typeMap.Add(typeof(int), gtype);
                gtype[managedTypeQuark] = typeof(int);

                gtype = UInt;
                typeMap.Add(typeof(uint), gtype);
                gtype[managedTypeQuark] = typeof(uint);

                gtype = Long;
                typeMap.Add(typeof(nlong), gtype);
                gtype[managedTypeQuark] = typeof(nlong);

                gtype = ULong;
                typeMap.Add(typeof(nulong), gtype);
                gtype[managedTypeQuark] = typeof(nulong);

                gtype = Int64;
                typeMap.Add(typeof(long), gtype);
                gtype[managedTypeQuark] = typeof(long);

                gtype = UInt64;
                typeMap.Add(typeof(ulong), gtype);
                gtype[managedTypeQuark] = typeof(ulong);

                gtype = Enum;
                typeMap.Add(typeof(System.Enum), gtype);
                gtype[managedTypeQuark] = typeof(System.Enum);

                gtype = Flags;
                // TODO: do we care about enum vs. flags?
                //typeMap.Add(typeof(System.Enum), gType);
                gtype[managedTypeQuark] = typeof(System.Enum);

                gtype = Float;
                typeMap.Add(typeof(float), gtype);
                gtype[managedTypeQuark] = typeof(float);

                gtype = Double;
                typeMap.Add(typeof(double), gtype);
                gtype[managedTypeQuark] = typeof(double);

                gtype = String;
                typeMap.Add(typeof(string), gtype);
                gtype[managedTypeQuark] = typeof(string);

                gtype = Pointer;
                typeMap.Add(typeof(IntPtr), gtype);
                gtype[managedTypeQuark] = typeof(IntPtr);

                gtype = Boxed;
                typeMap.Add(typeof (Boxed), gtype);
                gtype[managedTypeQuark] = typeof (Boxed);

                gtype = Param;
                typeMap.Add(typeof(ParamSpec), gtype);
                gtype[managedTypeQuark] = typeof(ParamSpec);

                gtype = Object;
                typeMap.Add(typeof(Object), gtype);
                gtype[managedTypeQuark] = typeof(Object);

                gtype = Type;
                typeMap.Add(typeof(GType), gtype);
                gtype[managedTypeQuark] = typeof(GType);

                gtype = Variant;
                typeMap.Add(typeof(Variant), gtype);
                gtype[managedTypeQuark] = typeof(Variant);
            }
        }

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
        readonly UIntPtr value;

        GType (uint value)
        {
            this.value = new UIntPtr (value);
        }

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
                return new GType (1 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type from which all interfaces are derived.
        /// </summary>
        public static GType Interface {
            get {
                return new GType (2 << FundamentalShift);
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
                return new GType (3 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guchar.
        /// </summary>
        public static GType UChar {
            get {
                return new GType (4 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gboolean.
        /// </summary>
        public static GType Boolean {
            get {
                return new GType (5 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gint.
        /// </summary>
        public static GType Int {
            get {
                return new GType (6 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guint.
        /// </summary>
        public static GType UInt {
            get {
                return new GType (7 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to glong.
        /// </summary>
        public static GType Long {
            get {
                return new GType (8 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gulong.
        /// </summary>
        public static GType ULong {
            get {
                return new GType (9 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gint64.
        /// </summary>
        public static GType Int64 {
            get {
                return new GType (10 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to guint64.
        /// </summary>
        public static GType UInt64 {
            get {
                return new GType (11 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type from which all enumeration types are derived.
        /// </summary>
        public static GType Enum {
            get {
                return new GType (12 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type from which all flags types are derived.
        /// </summary>
        public static GType Flags {
            get {
                return new GType (13 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gfloat.
        /// </summary>
        public static GType Float {
            get {
                return new GType (14 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gdouble.
        /// </summary>
        public static GType Double {
            get {
                return new GType (15 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to null-terminated C strings.
        /// </summary>
        public static GType String {
            get {
                return new GType (16 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type corresponding to gpointer.
        /// </summary>
        public static GType Pointer {
            get {
                return new GType (17 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type from which all boxed types are derived.
        /// </summary>
        public static GType Boxed {
            get {
                return new GType (18 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type from which all GParamSpec types are derived.
        /// </summary>
        public static GType Param {
            get {
                return new GType (19 << FundamentalShift);
            }
        }

        /// <summary>
        /// The fundamental type for GObject.
        /// </summary>
        public static GType Object {
            get {
                return new GType (20 << FundamentalShift);
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
                return new GType (21 << FundamentalShift);
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_gtype_get_type ();

        /// <summary>
        /// The type for GType.
        /// </summary>
        public static GType Type {
            get {
                return g_gtype_get_type ();
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
                return (int)value > FundamentalMax;
            }
        }

        /// <summary>
        /// Checks if this is a fundamental type.
        /// </summary>
        public bool IsFundamental {
            get {
                return (int)value <= FundamentalMax;
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        public override string ToString ()
        {
            return Name ?? "invalid";
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public Utf8 Name {
            get {
                var ret_ = g_type_name (this);
                var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public IArray<GType> Children {
            get {
                var ret_ = g_type_children(this, out var nChildren_);
                var ret = CArray.GetInstance<GType>(ret_, (int)nChildren_, Transfer.Full);
                return ret;
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_type_is_a (GType type, GType is_a_type);

        public bool IsA (GType type)
        {
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_from_name (
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
        public static GType FromName(Utf8 name)
        {
            AssertGTypeName(name);
            var ret = g_type_from_name(name.Handle);
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
                var message = string.Format ($"The name '{name}' is too short.", nameof (name));
                throw new InvalidGTypeNameException (message);
            }
            if (Regex.IsMatch (name[0].ToString (), "[^A-Za-z_]")) {
                var message = string.Format ($"The name '{name}' must start with letter or underscore.", nameof (name));
                throw new InvalidGTypeNameException (message);
            }
            if (Regex.IsMatch (name, "[^0-9A-Za-z_\\-\\+]")) {
                var message = string.Format ($"The name '{name}' contains an invalid character.", nameof (name));
                throw new InvalidGTypeNameException (message);
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_type_register_static (
            GType parentType,
            IntPtr typeName,
            IntPtr info,
            TypeFlags flags);

        /// <summary>
        /// Registers <paramref name="typeName"/> as the name of a new static
        /// type derived from <paramref name="parentType"/>.
        /// </summary>
        /// <returns>The new type identifier.</returns>
        /// <param name="parentType">Type from which this type will be derived.</param>
        /// <param name="typeName">The name of the new type.</param>
        /// <param name="info"><see cref="TypeInfo"/> structure for this type.</param>
        /// <param name="flags">Bitwise combination of <see cref="TypeFlags"/> values.</param>
        static GType RegisterStatic (GType parentType, string typeName, TypeInfo info, TypeFlags flags)
        {
            // this is static, so typeName_ is not freed
            var typeName_ = new Utf8(typeName).Take();
            // also, make a copy of info in unmanaged memory so that it always exists
            var info_ = GMarshal.Alloc (Marshal.SizeOf (info));
            Marshal.StructureToPtr (info, info_, false);
            var ret = g_type_register_static (parentType, typeName_, info_, flags);

            return ret;
        }

        static void MapPropertyInfo (GType gtype, Type type)
        {
            // type registration has not been completed here, so have to get the
            // object class the hard way by not using our nice wrapper class
            var objClassPtr = TypeClass.g_type_class_ref (gtype);
            try {
                foreach (var pspec in ObjectClass.ListProperties (objClassPtr)) {
                    var prop = type.GetProperties (BindFlags.Public | BindFlags.NonPublic | BindFlags.Instance)
                        .SingleOrDefault(p => p.TryGetGPropertyName() == pspec.Name);
                    if (prop == null) {
                        var message = $"Could not find matching property for \"{pspec.Name}\" in type {type.FullName}";
                        throw new ArgumentException (message, nameof(type));
                    }
                    pspec[ObjectClass.managedClassPropertyInfoQuark] = prop;
                }
            }
            finally {
                TypeClass.g_type_class_unref (objClassPtr);
            }
        }

        /// <summary>
        /// Register the specified type with the GObject type system.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <remarks>
        /// This is meant to be called from that static constructor of a type.
        /// </remarks>
        static GType Register (Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }

            lock (mapLock) {
                if (typeMap.ContainsKey (type)) {
                    throw new ArgumentException ("This type is already registered.", nameof (type));
                }

                var gtypeAttribute = type.GetCustomAttributes ()
                    .OfType<GTypeAttribute> ().SingleOrDefault ();
                if (gtypeAttribute == null) {
                    // if the type is not decorated with GTypeAttribute, then we
                    // register it as a boxed type.
                    var name = type.GetGTypeName ();
                    AssertGTypeName (name);
                    var gtype = GObject.Boxed.Register (name, GObject.Boxed.CopyManagedTypeDelegate, GObject.Boxed.FreeManagedTypeDelegate);

                    typeMap.Add (type, gtype);
                    gtype[managedTypeQuark] = type;

                    return gtype;
                }

                if (gtypeAttribute.IsProxyForUnmanagedType) {
                    // enums and interfaces can't have method implementations,
                    // so we need to find the associated static type for the
                    // actual implementation.
                    var implementationType = type;
                    if (type.IsEnum) {
                        implementationType = type.Assembly.GetType (type.FullName + "Extensions") ?? implementationType;
                    } else if (type.IsInterface) {
                        var nameWithoutIPrefix = type.FullName.Remove (type.FullName.LastIndexOf ('.') + 1, 1);
                        implementationType = type.Assembly.GetType (nameWithoutIPrefix) ?? implementationType;
                    } else if (type.IsGenericType) {
                        implementationType = type.BaseType;
                    }
                    var gtypeField = implementationType.GetField("_GType",
                                       System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                    if (gtypeField == null) {
                        var message = $"Could not find _GType field for {implementationType.FullName}.";
                        throw new ArgumentException (message, nameof (type));
                    }
                    var gtype = (GType)gtypeField.GetValue(null);
                    if (gtype == Invalid) {
                        throw new InvalidOperationException ("Something bad happend while registering wrapped type.");
                    }

                    if (gtype.Fundamental == GType.Object) {
                        MapPropertyInfo (gtype, type);
                    }

                    typeMap.Add (type, gtype);
                    gtype[managedTypeQuark] = type;

                    return gtype;
                }

                var gtypeName = type.GetGTypeName ();
                AssertGTypeName (gtypeName);
                if (type.IsClass) {
                    if (!type.IsSubclassOf (typeof(Object))) {
                        var message = string.Format ("Class does not inherit from {0}",
                                          typeof(Object).FullName);
                        throw new ArgumentException (message, nameof (type));
                    }
                    var parentGType = type.BaseType.GetGType ();
                    var parentTypeclass = TypeClass.Get (parentGType);
                    var parentTypeInfo = ObjectClass.GetTypeInfo(type);

                    TypeFlags flags = default(TypeFlags);
                    // TODO: do we need to set any flags?

                    var gtype = RegisterStatic (parentGType, gtypeName, parentTypeInfo, flags);
                    if (gtype == Invalid) {
                        throw new InvalidOperationException ("Something bad happend while registering object.");
                    }

                    // Install interfaces

                    // The order matters here. When we have multiple GType interfaces
                    // we need to make sure the prerequisites of an interface get
                    // installed before that interface itself gets installed.
                    // Sorting by number of inherited interfaces works because
                    // if interface B inherits interface A, B.GetInterfaces ().Length
                    // will be greater than A.GetInterfaces ().Length because it
                    // includes A in addition to all of A's interfaces.
                    var ifaces = type.GetInterfaces ().OrderBy (i => i.GetInterfaces ().Length);
                    foreach (var ifaceType in ifaces) {
                        var ifaceMap = type.GetInterfaceMap (ifaceType);
                        if (ifaceMap.TargetType != type) {
                            // only interested in interfaces that are actually
                            // implemented by this type and not inherited
                            continue;
                        }
                        var gtypeAttr = ifaceType.GetCustomAttribute<GTypeAttribute> ();
                        if (gtypeAttr == null) {
                            // only care about interfaces registered with the
                            // GObject type system
                            continue;
                        }
                        var ifaceGType = ifaceType.GetGType ();
                        var prereqs = TypeInterface.GetPrerequisites(ifaceGType);
                        foreach (var p in prereqs) {
                            if (!GType.TypeOf (p).IsAssignableFrom (type)) {
                                var message = $"Type {type.FullName} is missing prerequisite {ifaceType.FullName} ({p})";
                                throw new ArgumentException (message, nameof(type));
                            }
                        }

                        var interfaceInfo = TypeInterface.CreateInterfaceInfo(ifaceType, type);
                        AddInterfaceStatic(gtype, ifaceGType, interfaceInfo);
                    }

                    MapPropertyInfo (gtype, type);

                    typeMap.Add (type, gtype);
                    gtype[managedTypeQuark] = type;

                    return gtype;
                }
                if (type.IsEnum) {
                    var underlyingType = type.GetEnumUnderlyingType ();
                    if (underlyingType != typeof(int) && underlyingType != typeof(uint)) {
                        throw new ArgumentException ("GType enums must be int/uint", nameof (type));
                    }
                    var values = (int[])type.GetEnumValues ();
                    var names = type.GetEnumNames ();
                    var flagsAttribute = type.GetCustomAttributes ()
                        .OfType<FlagsAttribute> ().SingleOrDefault ();
                    if (flagsAttribute == null) {
                        var gtypeValues = new Array<EnumValue>(true, true, values.Length);
                        for (int i = 0; i < values.Length; i++) {
                            var enumValueField = type.GetField (names[i]);
                            var enumValueAttr = enumValueField.GetCustomAttributes ()
                                .OfType<EnumValueAttribute> ()
                                .SingleOrDefault ();
                            var valueName = enumValueAttr?.Name ?? names[i];
                            var valueNick = enumValueAttr?.Nick ?? names[i];
                            var enumValue = new EnumValue(values[i], valueName, valueNick);
                            gtypeValues.Add(enumValue);
                        }
                        var gtype = GObject.Enum.RegisterStatic (gtypeName, gtypeValues);
                        if (gtype == Invalid) {
                            throw new InvalidOperationException ("Something bad happend while registering enum.");
                        }

                        typeMap.Add (type, gtype);
                        gtype[managedTypeQuark] = type;

                        return gtype;
                    } else {
                        var gtypeValues = new Array<FlagsValue>(true, false, values.Length);
                        for (int i = 0; i < values.Length; i++) {
                            var enumValueField = type.GetField (names[i]);
                            var enumValueAttr = enumValueField
                                .GetCustomAttributes ()
                                .OfType<EnumValueAttribute> ()
                                .SingleOrDefault ();
                            var valueName = enumValueAttr?.Name ?? names[i];
                            var valueNick = enumValueAttr?.Nick ?? names[i];
                            var flagValue = new FlagsValue((uint)values[i], valueName, valueNick);
                            gtypeValues.Add(flagValue);
                        }
                        var gtype = GObject.Flags.RegisterStatic (gtypeName, gtypeValues);
                        if (gtype == Invalid) {
                            throw new InvalidOperationException ("Something bad happend while registering flags.");
                        }

                        typeMap.Add (type, gtype);
                        gtype[managedTypeQuark] = type;

                        return gtype;
                    }
                }
            }
            throw new NotImplementedException ();
        }

        public static GType TypeOf (Type type)
        {
            lock (mapLock) {
                if (typeMap.ContainsKey (type)) {
                    return typeMap[type];
                }

                var ret = Register (type);

                return ret;
            }
        }

        public static GType TypeOf<T> ()
        {
            return TypeOf (typeof(T));
        }

        public static explicit operator GType (Type type)
        {
            try {
                return TypeOf (type);
            } catch (Exception ex) {
                throw new InvalidCastException ("Could not get GType from type.", ex);
            }
        }

        public static Type TypeOf (GType type)
        {
            lock (mapLock) {
                if (g_type_get_qdata(type, managedTypeQuark) == IntPtr.Zero) {
                    Type matchingType = null;
                    foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
                        matchingType = (asm.IsDynamic ? asm.DefinedTypes : asm.ExportedTypes)
                            .FirstOrDefault (t => t.GetCustomAttributes ()
                                .OfType<GTypeAttribute> ()
                                .Any (a => a.Name == type.Name));
                        if (matchingType != null) {
                            break;
                        }
                    }
                    if (matchingType == null) {
                        // TODO: More specific exception type
                        var message = $"Could not find type for GType '{type.Name}' in loaded assemblies.";
                        throw new Exception (message);
                    }
                    Register (matchingType);
                }

                return (Type)type[managedTypeQuark];
            }
        }

        public static explicit operator Type (GType type)
        {
            try {
                return TypeOf (type);
            } catch (Exception ex) {
                throw new InvalidCastException ("Could not get type from GType.", ex);
            }
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_query (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="TypeQuery" type="GTypeQuery*" managed-name="TypeQuery" /> */
            /* direction:out caller-allocates:1 transfer-ownership:none */
            out TypeQuery query);

        /// <summary>
        /// Queries the type system for information about a specific type.
        /// </summary>
        public TypeQuery Query ()
        {
            TypeQuery query;
            g_type_query (this, out query);

            return query;
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_static (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="InterfaceInfo" type="const GInterfaceInfo*" managed-name="InterfaceInfo" /> */
            /* transfer-ownership:none */
            IntPtr info);

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
        static void AddInterfaceStatic (GType instanceType, GType interfaceType, InterfaceInfo info)
        {
            // making a copy of info in unmanged memory that will never be freed
            var infoPtr = GMarshal.Alloc (Marshal.SizeOf<InterfaceInfo> ());
            Marshal.StructureToPtr<InterfaceInfo> (info, infoPtr, false);

            // also make sure the delegates are never GCed.
            GCHandle.Alloc (info.InterfaceInit);
            GCHandle.Alloc (info.InterfaceFinalize);

            g_type_add_interface_static (instanceType, interfaceType, infoPtr);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_get_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_set_qdata(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
            /* transfer-ownership:none */
            Quark quark,
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr data);

        /// <summary>
        /// Gets or sets arbitrary data for a type.
        /// </summary>
        /// <param name="quark">
        /// a <see cref="Quark"/> id to identify the data
        /// </param>
        /// <value>
        /// the data
        /// </value>
        public object this[Quark quark]
        {
            get {
                var ret_ = g_type_get_qdata(this, quark);
                if (ret_ == IntPtr.Zero) {
                    return null;
                }
                return GCHandle.FromIntPtr(ret_).Target;
            }
            set {
                var oldData_ = g_type_get_qdata(this, quark);
                if (oldData_ != IntPtr.Zero) {
                    var oldData = (GCHandle)oldData_;
                    oldData.Free();
                }
                if (value == null) {
                    g_type_set_qdata(this, quark, IntPtr.Zero);
                }
                else {
                    var data = GCHandle.Alloc(value);
                    var data_ = (IntPtr)data;
                    g_type_set_qdata(this, quark, data_);
                }
            }
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeClassCacheFunc cacheFunc);

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
            var cacheFunc_ = UnmanagedTypeClassCacheFuncFactory.Create(cacheFunc, false);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_add_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeInterfaceCheckFunc checkFunc);

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
            var checkFunc_ = TypeInterfaceCheckFuncFactory.Create(checkFunc, false);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        /// Returns the length of the ancestry of the passed in type. This
        /// includes the type itself, so that e.g. a fundamental type has depth 1.
        /// </summary>
        /// <param name="type">
        /// a #GType
        /// </param>
        /// <returns>
        /// the depth of @type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
         *   <type name="GType" type="GType" managed-name="GType" />
         * </array> */
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
        /// Array of interface types
        /// </returns>
        public static IArray<GType> Interfaces(GType type)
        {
            var ret_ = g_type_interfaces(type, out var nInterfaces_);
            var ret = CArray.GetInstance<GType>(ret_, (int)nInterfaces_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// If @is_a_type is a derivable type, check whether @type is a
        /// descendant of @is_a_type. If @is_a_type is an interface, check
        /// whether @type conforms to it.
        /// </summary>
        /// <param name="type">
        /// type to check ancestry for
        /// </param>
        /// <param name="isAType">
        /// possible ancestor of @type or interface that @type
        ///     could conform to
        /// </param>
        /// <returns>
        /// %TRUE if @type is a @is_a_type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        /// type to check ancestry for
        /// </param>
        /// <param name="isAType">
        /// possible ancestor of @type or interface that @type
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

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_class(
            /* <type name="TypeClass" type="GTypeClass*" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr gClass);

        public static Utf8 NameFromClass(TypeClass gClass)
        {
            if (gClass == null)
            {
                throw new ArgumentNullException("gClass");
            }
            var gClass_ = gClass == null ? IntPtr.Zero : gClass.Handle;
            var ret_ = g_type_name_from_class(gClass_);
            var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name_from_instance(
            /* <type name="TypeInstance" type="GTypeInstance*" managed-name="TypeInstance" /> */
            /* transfer-ownership:none */
            IntPtr instance);

        public static Utf8 NameFromInstance(TypeInstance instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            var instance_ = instance == null ? IntPtr.Zero : instance.Handle;
            var ret_ = g_type_name_from_instance(instance_);
            var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.None);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GLib.Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_type_qname(
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
        public static Quark Qname(GType type)
        {
            var ret = g_type_qname(type);
            return ret;
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public static GType RegisterDynamic(GType parentType, Utf8 typeName, TypePlugin plugin, TypeFlags flags)
        {
            var typeName_ = typeName?.Handle ?? throw new ArgumentNullException(nameof(typeName));
            var plugin_ = plugin?.Handle ?? throw new ArgumentNullException(nameof(plugin));
            var ret = g_type_register_dynamic(parentType, typeName_, plugin_, flags);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public static GType RegisterFundamental(GType typeId, Utf8 typeName, TypeInfo info, TypeFundamentalInfo finfo, TypeFlags flags)
        {
            var typeName_ = typeName?.Handle ?? throw new ArgumentNullException(nameof(typeName));
            var ret = g_type_register_fundamental(typeId, typeName_, info, finfo, flags);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_class_cache_func(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr cacheData,
            /* <type name="TypeClassCacheFunc" type="GTypeClassCacheFunc" managed-name="TypeClassCacheFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeClassCacheFunc cacheFunc);

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
            var cacheFunc_ = UnmanagedTypeClassCacheFuncFactory.Create(cacheFunc, false);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_remove_interface_check(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr checkData,
            /* <type name="TypeInterfaceCheckFunc" type="GTypeInterfaceCheckFunc" managed-name="TypeInterfaceCheckFunc" /> */
            /* transfer-ownership:none */
            UnmanagedTypeInterfaceCheckFunc checkFunc);

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
            var checkFunc_ = TypeInterfaceCheckFuncFactory.Create(checkFunc, false);
            g_type_remove_interface_check(checkData, checkFunc_);
        }
#endif
    }

    public class InvalidGTypeNameException : Exception
    {
        public InvalidGTypeNameException (string message) : base (message)
        {
        }
    }

    public static class GTypeExtenstions
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
            var gtypeAttr = type.GetCustomAttributes ()
                .OfType<GTypeAttribute> ().SingleOrDefault ();

            var ret = gtypeAttr?.Name ?? type.ToString()
                .Replace('.', '-')
                .Replace("[]", "--Array--")
                .Replace("`", "--of--")
                .Replace("[", "")
                .Replace("]", "");

            return ret;
        }

        public static Type GetGTypeStruct (this Type type)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }

            Type gtypeStructType;
            var gtypeStructAttr = type.GetCustomAttribute<GTypeStructAttribute> (true);
            if (gtypeStructAttr == null) {
                if (type.IsEnum) {
                    // GTypeStructAttribute is not needed on Enums/Flags
                    var flagsAttr = type.GetCustomAttribute<FlagsAttribute> ();
                    if (flagsAttr == null) {
                        gtypeStructType = typeof(EnumClass);
                    } else {
                        gtypeStructType = typeof(FlagsClass);
                    }
                } else {
                    var message = $"Type '{type.FullName}' does not have have GTypeStructAttribute";
                    throw new ArgumentException (message, nameof (type));
                }
            } else {
                gtypeStructType = gtypeStructAttr.GTypeStruct;
            }

            if (gtypeStructType == null) {
                throw new ArgumentNullException ($"Type '{type.FullName}' does not specify GTypeStruct", nameof(type));
            }

            return gtypeStructType;
        }

        public static Type GetGTypeStruct (this GType type)
        {
            return GType.TypeOf (type).GetGTypeStruct ();
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
            return GType.TypeOf (type);
        }

        /// <summary>
        /// Gets the <see cref="GType"/> for the managed objcet.
        /// </summary>
        /// <returns>
        /// The <see cref="GType"/> or <see cref="GType.Invalid"/> if the type
        /// is not registered.
        /// </returns>
        /// <param name="obj">Type.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="obj"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the Type of <paramref name="obj"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static GType GetGType (this object obj)
        {
            if (obj == null) {
                throw new ArgumentNullException (nameof (obj));
            }
            return GType.TypeOf (obj.GetType ());
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_default_interface_peek (GType type);
    }
}
