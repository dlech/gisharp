// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Reflection;

namespace GISharp.Runtime
{
    /// <summary>
    /// A numerical value which represents the unique identifier of a registered
    /// type.
    /// </summary>
    [GType("GType", IsProxyForUnmanagedType = true)]
    [DebuggerDisplay("{Name}")]
    public unsafe struct GType
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

        // typedef gsize GType;
        readonly nuint value;

        GType(nuint value)
        {
            this.value = value;
        }

        /// <summary>
        /// An invalid GType used as error return value in some functions which
        /// return a GType.
        /// </summary>
        public static GType Invalid => default;

        /// <summary>
        /// A fundamental type which is used as a replacement for the C void
        /// return type.
        /// </summary>
        public static GType None => new(1 << FundamentalShift);

        /// <summary>
        /// The fundamental type from which all interfaces are derived.
        /// </summary>
        public static GType Interface => new(2 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gchar.
        /// </summary>
        /// <remarks>
        /// The type designated by G_TYPE_CHAR is unconditionally an 8-bit
        /// signed integer. This may or may not be the same type a the C type
        /// "gchar".
        /// </remarks>
        public static GType Char => new(3 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to guchar.
        /// </summary>
        public static GType UChar => new(4 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gboolean.
        /// </summary>
        public static GType Boolean => new(5 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gint.
        /// </summary>
        public static GType Int => new(6 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to guint.
        /// </summary>
        public static GType UInt => new(7 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to glong.
        /// </summary>
        public static GType Long => new(8 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gulong.
        /// </summary>
        public static GType ULong => new(9 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gint64.
        /// </summary>
        public static GType Int64 => new(10 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to guint64.
        /// </summary>
        public static GType UInt64 => new(11 << FundamentalShift);

        /// <summary>
        /// The fundamental type from which all enumeration types are derived.
        /// </summary>
        public static GType Enum => new(12 << FundamentalShift);

        /// <summary>
        /// The fundamental type from which all flags types are derived.
        /// </summary>
        public static GType Flags => new(13 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gfloat.
        /// </summary>
        public static GType Float => new(14 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gdouble.
        /// </summary>
        public static GType Double => new(15 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to null-terminated C strings.
        /// </summary>
        public static GType String => new(16 << FundamentalShift);

        /// <summary>
        /// The fundamental type corresponding to gpointer.
        /// </summary>
        public static GType Pointer => new(17 << FundamentalShift);

        /// <summary>
        /// The fundamental type from which all boxed types are derived.
        /// </summary>
        public static GType Boxed => new(18 << FundamentalShift);

        /// <summary>
        /// The fundamental type from which all GParamSpec types are derived.
        /// </summary>
        public static GType Param => new(19 << FundamentalShift);

        /// <summary>
        /// The fundamental type for GObject.
        /// </summary>
        public static GType Object => new(20 << FundamentalShift);

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
        public static GType Variant => new(21 << FundamentalShift);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_gtype_get_type();

        /// <summary>
        /// The type for GType.
        /// </summary>
        public static GType Type {
            get {
                var ret = g_gtype_get_type();
                GMarshal.PopUnhandledException();
                return ret;
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_fundamental(
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
                var ret = g_type_fundamental(this);
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Bit masks used to check or determine characteristics of a type.
        /// </summary>
        [Flags]
        enum TypeFlags : uint
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

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Boolean g_type_test_flags(
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
                var ret_ = g_type_test_flags(this, TypeFlags.Abstract);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Checks if this is derived (or in object-oriented terminology: inherited)
        /// from another type (this holds true for all non-fundamental types).
        /// </summary>
        public bool IsDerived => (int)value > FundamentalMax;

        /// <summary>
        /// Checks if this is a fundamental type.
        /// </summary>
        public bool IsFundamental => (int)value <= FundamentalMax;

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern Boolean g_type_check_is_value_type(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Checks if this is a value type and can be used with g_value_init().
        /// </summary>
        public bool IsValueType {
            get {
                var ret_ = g_type_check_is_value_type(this);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        /// <summary>
        /// Checks if type is a classed type.
        /// </summary>
        public bool IsClassed {
            get {
                var ret_ = g_type_test_flags(this, TypeFlags.Classed);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
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
                var ret_ = g_type_test_flags(this, TypeFlags.Instantiatable);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
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
                var ret_ = g_type_test_flags(this, TypeFlags.Derivable);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
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
                var ret_ = g_type_test_flags(this, TypeFlags.DeepDerivable);
                GMarshal.PopUnhandledException();
                var ret = ret_.IsTrue();
                return ret;
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
                var ret = g_type_fundamental(this) == Interface;
                GMarshal.PopUnhandledException();
                return ret;
            }
        }

        /// <summary>
        /// Compares two GTypes for equality.
        /// </summary>
        public static bool operator ==(GType a, GType b)
        {
            return a.value == b.value;
        }

        /// <summary>
        /// Compares two GTypes for inequality.
        /// </summary>
        public static bool operator !=(GType a, GType b)
        {
            return a.value != b.value;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is GType type) {
                return this == type;
            }
            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name ?? "<invalid>";
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_name(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type);

        /// <summary>
        /// Get the unique name that is assigned to a type ID.
        /// </summary>
        /// <returns>
        /// type name or <c>null</c>
        /// </returns>
        public string? Name {
            get {
                var ret_ = g_type_name(this);
                GMarshal.PopUnhandledException();
                var ret = Marshal.PtrToStringUTF8(ret_);
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GType" /> */
        /* transfer-ownership:none */
        static extern GType g_type_parent(
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
                var ret = g_type_parent(this);
                GMarshal.PopUnhandledException();
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
            <type name="GType" type="GType" managed-name="GType" />
            </array> */
        /* transfer-ownership:full */
        static extern IntPtr g_type_children(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType type,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            uint* nChildren);

        /// <summary>
        /// Return an array of type IDs, listing the child types of this type.
        /// </summary>
        /// <returns>
        /// array of child types
        /// </returns>
        public ZeroTerminatedCArray<GType>? Children {
            get {
                uint nChildren_;
                var ret_ = g_type_children(this, &nChildren_);
                GMarshal.PopUnhandledException();
                if (ret_ == IntPtr.Zero) {
                    return null;
                }
                var ret = new ZeroTerminatedCArray<GType>(ret_, (int)nChildren_, Transfer.Full);
                return ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Boolean g_type_is_a(GType type, GType is_a_type);

        /// <summary>
        /// If <paramref name="type"/> is a derivable type, check whether this
        /// type is a descendant of <paramref name="type"/>. If <paramref name="type"/>
        /// is an interface, check whether this type conforms to it.
        /// </summary>
        /// <param name="type">
        /// possible ancestor of this type or interface that this type could conform to
        /// </param>
        /// <returns>
        /// <c>true</c> if this type is a <paramref name="type"/>.
        /// </returns>
        public bool IsA(GType type)
        {
            var ret_ = g_type_is_a(this, type);
            GMarshal.PopUnhandledException();
            var ret = ret_.IsTrue();
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public static GType FromName(string name)
        {
            AssertGTypeName(name);
            var name_ = Marshal.StringToCoTaskMemUTF8(name);
            try {
                var ret = g_type_from_name(name_);
                GMarshal.PopUnhandledException();
                return ret;
            }
            finally {
                Marshal.FreeCoTaskMem(name_);
            }
        }

        /// <summary>
        /// Asserts that the name of the type is a valid GType name.
        /// </summary>
        /// <param name="name">The type name.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="name"/> is not valid (see remarks).
        /// </exception>
        /// <remarks>
        /// Type names must be at least three characters long. There is no upper
        /// length limit. The first character must be a letter (a–z or A–Z) or
        /// an underscore (‘_’). Subsequent characters can be letters, numbers
        /// or any of ‘-_+’.
        /// </remarks>
        public static void AssertGTypeName(string name)
        {
            if (name.Length < 3) {
                var message = $"The name '{name}' is too short.";
                throw new ArgumentException(message, nameof(name));
            }
            if (Regex.IsMatch(name[0].ToString(), "[^A-Za-z_]")) {
                var message = $"The name '{name}' must start with letter or underscore.";
                throw new ArgumentException(message, nameof(name));
            }
            if (Regex.IsMatch(name, "[^0-9A-Za-z_\\-\\+]")) {
                var message = $"The name '{name}' contains an invalid character.";
                throw new ArgumentException(message, nameof(name));
            }
        }
    }

    /// <summary>
    /// Extension methods for <see cref="GType"/>
    /// </summary>
    public static class GTypeExtensions
    {
        /// <summary>
        /// Gets the type name used by the GObject type system.
        /// </summary>
        /// <returns>The name.</returns>
        /// <param name="type">Type.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="type"/> is not decorated with <see cref="GTypeAttribute"/>
        /// </exception>
        public static string GetGTypeName(this Type type)
        {
            var gtypeAttr = type.GetCustomAttributes()
                .OfType<GTypeAttribute>().SingleOrDefault();

            var ret = gtypeAttr?.Name ?? type.ToString()
                .Replace('.', '-')
                .Replace("[]", "--Array--")
                .Replace("`", "--of--")
                .Replace("[", "")
                .Replace("]", "");

            GType.AssertGTypeName(ret);

            return ret;
        }
    }
}
