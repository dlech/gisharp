using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    [AttributeUsage (AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public string? Name { get; }
        public string? Nick { get; }

        public EnumValueAttribute (string? name = null, string? nick = null)
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
        static unsafe extern void g_enum_complete_type_info(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gEnumType,
            /* <type name="TypeInfo" type="GTypeInfo*" managed-name="TypeInfo" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out TypeInfo info,
            /* <type name="EnumValue" type="const GEnumValue*" managed-name="EnumValue" /> */
            /* transfer-ownership:none */
            EnumValue* constValues);

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
        static unsafe void CompleteTypeInfo(GType gEnumType, out TypeInfo info, ReadOnlySpan<EnumValue> constValues)
        {
            fixed (EnumValue* constValues_ = constValues) {
                g_enum_complete_type_info(gEnumType, out info, constValues_);
            }
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
            var enumClass_ = enumClass.Handle;
            var name_ = name.Handle;
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
            var enumClass_ = enumClass.Handle;
            var nick_ = nick.Handle;
            var ret_ = g_enum_get_value_by_nick(enumClass_, nick_);
            var ret = Marshal.PtrToStructure<EnumValue>(ret_);

            return ret;
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe GType g_enum_register_static(IntPtr typeName, EnumValue* values);

        public static unsafe GType RegisterStatic(string typeName, ReadOnlyMemory<EnumValue> values)
        {
            GType.AssertGTypeName(typeName);
            using var typeNameUtf8 = typeName.ToUtf8();
            var typeName_ = typeNameUtf8.Handle;
            var handle = values.Pin();
            try {
                var values_ = (EnumValue*)handle.Pointer;
                var length_ = values.Length;

                // verify that the array is null-terminated
                if (!values_[length_ - 1].Equals(default(EnumValue))) {
                    throw new ArgumentException("Array must be zero-terminated", nameof(values));
                }

                var ret = g_enum_register_static(typeName_, values_);
                // pinned memory of values is never freed for the lifetime of the program
                return ret;
            } catch {
                handle.Dispose();
                throw;
            }
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
            valueName = name.Take();
            valueNick = nick.Take();
        }
    }
}
