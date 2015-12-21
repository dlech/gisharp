using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    [AttributeUsage (AttributeTargets.Field)]
    public class EnumValueAttribute : Attribute
    {
        public string Name { get; set; }
        public string Nick { get; set; }
    }

    public static class EnumExtensions
    {
        public static string GetValueName (System.Enum @enum)
        {
            var gtype = @enum.GetType ();
            throw new NotImplementedException ();
        }
    }

    static class Enum
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
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
        static void CompleteTypeInfo (GType gEnumType, out TypeInfo info, EnumValue[] constValues)
        {
            var constValues_ = MarshalG.CArrayToPtr<EnumValue> (constValues, nullTerminated: true);
            g_enum_complete_type_info (gEnumType, out info, constValues_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern EnumValue g_enum_get_value (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            ref EnumClass enumClass,
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
        public static EnumValue GetValue (ref EnumClass enumClass, int value)
        {
            var ret = g_enum_get_value (ref enumClass, value);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern EnumValue g_enum_get_value_by_name (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            ref EnumClass enumClass,
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
        public static EnumValue GetValueByName (ref EnumClass enumClass, string name)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            var name_ = MarshalG.StringToUtf8Ptr (name);
            var ret = g_enum_get_value_by_name (ref enumClass, name_);
            MarshalG.Free (name_);
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
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="EnumValue" type="GEnumValue*" managed-name="EnumValue" /> */
        /* transfer-ownership:none */
        static extern EnumValue g_enum_get_value_by_nick (
            /* <type name="EnumClass" type="GEnumClass*" managed-name="EnumClass" /> */
            /* transfer-ownership:none */
            ref EnumClass enumClass,
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
        public static EnumValue GetValueByNick (ref EnumClass enumClass, string nick)
        {
            if (nick == null) {
                throw new ArgumentNullException (nameof (nick));
            }
            var nick_ = MarshalG.StringToUtf8Ptr (nick);
            var ret = g_enum_get_value_by_nick (ref enumClass, nick_);
            MarshalG.Free (nick_);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_enum_register_static (IntPtr typeName, IntPtr values);

        public static GType RegisterStatic (string typeName, EnumValue[] values)
        {
            GType.AssertGTypeName (typeName);
            var typeName_ = MarshalG.StringToUtf8Ptr (typeName);
            var values_ = MarshalG.CArrayToPtr<EnumValue> (values, nullTerminated: true);
            var ret = g_enum_register_static (typeName_, values_);
            // values are never freed for the liftime of the program
            return ret;
        }
    }

    /// <summary>
    /// The class of an enumeration type holds information about its
    /// possible values.
    /// </summary>
    [StructLayout (LayoutKind.Sequential)]
    struct EnumClass
    {
        /// <summary>
        /// the parent class
        /// </summary>
        public IntPtr GTypeClass;

        /// <summary>
        /// the smallest possible value.
        /// </summary>
        public int Minimum;

        /// <summary>
        /// the largest possible value.
        /// </summary>
        public int Maximum;

        /// <summary>
        /// the number of possible values.
        /// </summary>
        public uint NValues;

        /// <summary>
        /// an array of #GEnumValue structs describing the
        ///  individual values.
        /// </summary>
        public IntPtr Values;
    }

    /// <summary>
    /// A structure which contains a single enum value, its name, and its
    /// nickname.
    /// </summary>
    [StructLayout (LayoutKind.Sequential)]
    struct EnumValue
    {
        /// <summary>
        /// the enum value
        /// </summary>
        public int Value;

        /// <summary>
        /// the name of the value
        /// </summary>
        public IntPtr ValueName;

        /// <summary>
        /// the nickname of the value
        /// </summary>
        public IntPtr ValueNick;
    }
}
