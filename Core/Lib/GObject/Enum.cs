using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    [AttributeUsage (AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Nick { get; private set; }

        public EnumValueAttribute (string name = null, string nick = null)
        {
            Name = name;
            Nick = nick;
        }
    }

    public static class EnumExtensions
    {
        public static string GetValueName (System.Enum @enum)
        {
            var gtype = @enum.GetType ();
            throw new NotImplementedException ();
        }
    }

    public static class Enum
    {
        /// <summary>
        /// This function is meant to be called from the `complete_type_info`
        /// function of a #GTypePlugin implementation, as in the following
        /// example:
        /// </summary>
        /// <remarks>
        /// |[&lt;!-- language="C" --&gt;
        /// static void
        /// my_enum_complete_type_info (GTypePlugin     *plugin,
        ///                             GType            g_type,
        ///                             GTypeInfo       *info,
        ///                             GTypeValueTable *value_table)
        /// {
        ///   static const GEnumValue values[] = {
        ///     { MY_ENUM_FOO, "MY_ENUM_FOO", "foo" },
        ///     { MY_ENUM_BAR, "MY_ENUM_BAR", "bar" },
        ///     { 0, NULL, NULL }
        ///   };
        /// 
        ///   g_enum_complete_type_info (type, info, values);
        /// }
        /// ]|
        /// </remarks>
        /// <param name="gEnumType">
        /// the type identifier of the type being completed
        /// </param>
        /// <param name="info">
        /// the #GTypeInfo struct to be filled in
        /// </param>
        /// <param name="constValues">
        /// An array of #GEnumValue structs for the possible
        ///  enumeration values. The array is terminated by a struct with all
        ///  members being 0.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_enum_complete_type_info (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gEnumType,
            /* <type name="TypeInfo" type="GTypeInfo*" managed-name="TypeInfo" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out TypeInfo info,
            /* <type name="EnumValue" type="const GEnumValue*" managed-name="EnumValue" /> */
            /* transfer-ownership:none */
            IntPtr constValues);

        /// <summary>
        /// This function is meant to be called from the `complete_type_info`
        /// function of a #GTypePlugin implementation, as in the following
        /// example:
        /// </summary>
        /// <remarks>
        /// |[&lt;!-- language="C" --&gt;
        /// static void
        /// my_enum_complete_type_info (GTypePlugin     *plugin,
        ///                             GType            g_type,
        ///                             GTypeInfo       *info,
        ///                             GTypeValueTable *value_table)
        /// {
        ///   static const GEnumValue values[] = {
        ///     { MY_ENUM_FOO, "MY_ENUM_FOO", "foo" },
        ///     { MY_ENUM_BAR, "MY_ENUM_BAR", "bar" },
        ///     { 0, NULL, NULL }
        ///   };
        /// 
        ///   g_enum_complete_type_info (type, info, values);
        /// }
        /// ]|
        /// </remarks>
        /// <param name="gEnumType">
        /// the type identifier of the type being completed
        /// </param>
        /// <param name="info">
        /// the #GTypeInfo struct to be filled in
        /// </param>
        /// <param name="constValues">
        /// An array of #GEnumValue structs for the possible
        ///  enumeration values. The array is terminated by a struct with all
        ///  members being 0.
        /// </param>
        static void CompleteTypeInfo(GType gEnumType, out TypeInfo info, IArray<EnumValue> constValues)
        {
            var constValues_ = constValues?.Data ?? throw new ArgumentNullException(nameof(constValues));
            g_enum_complete_type_info(gEnumType, out info, constValues_);
        }

        /// <summary>
        /// Returns the #GEnumValue for a value.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="value">
        /// the value to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue for @value, or %NULL
        ///          if @value is not a member of the enumeration
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_enum_get_value (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            IntPtr enumClass,
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int value);

        /// <summary>
        /// Returns the #GEnumValue for a value.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="value">
        /// the value to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue for @value, or %NULL
        ///          if @value is not a member of the enumeration
        /// </returns>
        public static EnumValue GetValue (EnumClass enumClass, int value)
        {
            if (enumClass == null) {
                throw new ArgumentNullException (nameof (enumClass));
            }

            var ret_ = g_enum_get_value (enumClass.Handle, value);
            var ret = Marshal.PtrToStructure<EnumValue> (ret_);

            return ret;
        }

        /// <summary>
        /// Looks up a #GEnumValue by name.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="name">
        /// the name to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue with name @name,
        ///          or %NULL if the enumeration doesn't have a member
        ///          with that name
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_enum_get_value_by_name (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            IntPtr enumClass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);

        /// <summary>
        /// Looks up a #GEnumValue by name.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="name">
        /// the name to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue with name @name,
        ///          or %NULL if the enumeration doesn't have a member
        ///          with that name
        /// </returns>
        public static EnumValue GetValueByName(EnumClass enumClass, UnownedUtf8 name)
        {
            var enumClass_ = enumClass?.Handle ?? throw new ArgumentNullException(nameof(enumClass));
            var name_ = name.IsNull ? throw new ArgumentNullException(nameof(name)) : name.Handle;
            var ret_ = g_enum_get_value_by_name(enumClass_, name_);
            var ret = Marshal.PtrToStructure<EnumValue>(ret_);

            return ret;
        }

        /// <summary>
        /// Looks up a #GEnumValue by nickname.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="nick">
        /// the nickname to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue with nickname @nick,
        ///          or %NULL if the enumeration doesn't have a member
        ///          with that nickname
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_enum_get_value_by_nick (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            IntPtr enumClass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr nick);

        /// <summary>
        /// Looks up a #GEnumValue by nickname.
        /// </summary>
        /// <param name="enumClass">
        /// a #GEnumClass
        /// </param>
        /// <param name="nick">
        /// the nickname to look up
        /// </param>
        /// <returns>
        /// the #GEnumValue with nickname @nick,
        ///          or %NULL if the enumeration doesn't have a member
        ///          with that nickname
        /// </returns>
        public static EnumValue GetValueByNick(EnumClass enumClass, UnownedUtf8 nick)
        {
            var enumClass_ = enumClass?.Handle ?? throw new ArgumentNullException(nameof(enumClass));
            var nick_ = nick.IsNull ? throw new ArgumentNullException(nameof(nick)) : nick.Handle;
            var ret_ = g_enum_get_value_by_nick(enumClass_, nick_);
            var ret = Marshal.PtrToStructure<EnumValue>(ret_);

            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_enum_register_static (IntPtr typeName, IntPtr values);

        public static GType RegisterStatic(Utf8 typeName, IArray<EnumValue> values)
        {
            GType.AssertGTypeName(typeName);
            var typeName_ = typeName?.Take() ?? throw new ArgumentNullException(nameof(typeName));
            var (values_, length) = values?.TakeData() ?? throw new ArgumentNullException(nameof(values));

            // verify that the array is null-terminated
            var offset = Marshal.SizeOf<EnumValue>() * length;
            var terminator = Marshal.PtrToStructure<EnumValue>(values_ + offset);
            if (!terminator.Equals(default(EnumValue))) {
                throw new ArgumentException("Must be null-terminated", nameof(values));
            }

            var ret = g_enum_register_static(typeName_, values_);
            // values are never freed for the lifetime of the program
            return ret;
        }
    }

    /// <summary>
    /// A structure which contains a single enum value, its name, and its
    /// nickname.
    /// </summary>
    public struct EnumValue
    {
        int value;
        IntPtr valueName;
        IntPtr valueNick;

        /// <summary>
        /// the enum value
        /// </summary>
        public int Value => value;

        /// <summary>
        /// the name of the value
        /// </summary>
        public UnownedUtf8 Name => new UnownedUtf8(valueName, -1);

        /// <summary>
        /// the nickname of the value
        /// </summary>
        public UnownedUtf8 Nick => new UnownedUtf8(valueNick, -1);

        public EnumValue(int value, Utf8 name, Utf8 nick)
        {
            this.value = value;
            valueName = name?.Take() ?? throw new ArgumentNullException(nameof(name));
            valueNick = nick?.Take() ?? throw new ArgumentNullException(nameof(nick));
        }
    }
}
