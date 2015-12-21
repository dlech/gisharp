﻿using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    static class Flags
    {
        /// <summary>
        /// This function is meant to be called from the complete_type_info()
        /// function of a #GTypePlugin implementation, see the example for
        /// g_enum_complete_type_info() above.
        /// </summary>
        /// <param name="gFlagsType">
        /// the type identifier of the type being completed
        /// </param>
        /// <param name="info">
        /// the #GTypeInfo struct to be filled in
        /// </param>
        /// <param name="constValues">
        /// An array of #GFlagsValue structs for the possible
        ///  enumeration values. The array is terminated by a struct with all
        ///  members being 0.
        /// </param>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_flags_complete_type_info (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gFlagsType,
            /* <type name="TypeInfo" type="GTypeInfo*" managed-name="TypeInfo" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out TypeInfo info,
            /* <type name="FlagsValue" type="const GFlagsValue*" managed-name="FlagsValue" /> */
            /* transfer-ownership:none */
            IntPtr constValues);

        /// <summary>
        /// This function is meant to be called from the complete_type_info()
        /// function of a #GTypePlugin implementation, see the example for
        /// g_enum_complete_type_info() above.
        /// </summary>
        /// <param name="gFlagsType">
        /// the type identifier of the type being completed
        /// </param>
        /// <param name="info">
        /// the #GTypeInfo struct to be filled in
        /// </param>
        /// <param name="constValues">
        /// An array of #GFlagsValue structs for the possible
        ///  enumeration values.
        /// </param>
        public static void CompleteTypeInfo (GType gFlagsType, out TypeInfo info, FlagsValue[] constValues)
        {
            var constValues_ = MarshalG.CArrayToPtr<FlagsValue> (constValues, nullTerminated: true);
            g_flags_complete_type_info (gFlagsType, out info, constValues_);
        }

        /// <summary>
        /// Returns the first #GFlagsValue which is set in @value.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="value">
        /// the value
        /// </param>
        /// <returns>
        /// the first #GFlagsValue which is set in
        ///          @value, or %NULL if none is set
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern FlagsValue g_flags_get_first_value (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            ref FlagsClass flagsClass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint value);

        /// <summary>
        /// Returns the first #GFlagsValue which is set in @value.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="value">
        /// the value
        /// </param>
        /// <returns>
        /// the first #GFlagsValue which is set in
        ///          @value, or %NULL if none is set
        /// </returns>
        public static FlagsValue GetFirstValue (ref FlagsClass flagsClass, uint value)
        {
            var ret = g_flags_get_first_value (ref flagsClass, value);
            return ret;
        }

        /// <summary>
        /// Looks up a #GFlagsValue by name.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="name">
        /// the name to look up
        /// </param>
        /// <returns>
        /// the #GFlagsValue with name @name,
        ///          or %NULL if there is no flag with that name
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern FlagsValue g_flags_get_value_by_name (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            ref FlagsClass flagsClass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);

        /// <summary>
        /// Looks up a #GFlagsValue by name.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="name">
        /// the name to look up
        /// </param>
        /// <returns>
        /// the #GFlagsValue with name @name,
        ///          or %NULL if there is no flag with that name
        /// </returns>
        public static FlagsValue GetValueByName (ref FlagsClass flagsClass, string name)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            var name_ = MarshalG.StringToUtf8Ptr (name);
            var ret = g_flags_get_value_by_name (ref flagsClass, name_);
            MarshalG.Free (name_);
            return ret;
        }

        /// <summary>
        /// Looks up a #GFlagsValue by nickname.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="nick">
        /// the nickname to look up
        /// </param>
        /// <returns>
        /// the #GFlagsValue with nickname @nick,
        ///          or %NULL if there is no flag with that nickname
        /// </returns>
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern FlagsValue g_flags_get_value_by_nick (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            ref FlagsClass flagsClass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr nick);

        /// <summary>
        /// Looks up a #GFlagsValue by nickname.
        /// </summary>
        /// <param name="flagsClass">
        /// a #GFlagsClass
        /// </param>
        /// <param name="nick">
        /// the nickname to look up
        /// </param>
        /// <returns>
        /// the #GFlagsValue with nickname @nick,
        ///          or %NULL if there is no flag with that nickname
        /// </returns>
        public static FlagsValue GetValueByNick (ref FlagsClass flagsClass, string nick)
        {
            if (nick == null) {
                throw new ArgumentNullException (nameof (nick));
            }
            var nick_ = MarshalG.StringToUtf8Ptr (nick);
            var ret = g_flags_get_value_by_nick (ref flagsClass, nick_);
            MarshalG.Free (nick_);
            return ret;
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_flags_register_static (IntPtr typeName, IntPtr values);

        public static GType RegisterStatic (string typeName, FlagsValue[] values)
        {
            GType.AssertGTypeName (typeName);
            var typeName_ = MarshalG.StringToUtf8Ptr (typeName);
            var values_ = MarshalG.CArrayToPtr<FlagsValue> (values, nullTerminated: true);
            var ret = g_flags_register_static (typeName_, values_);
            // values are never freed for the liftime of the program
            return ret;
        }
    }

    /// <summary>
    /// The class of a flags type holds information about its
    /// possible values.
    /// </summary>
    [StructLayout (LayoutKind.Sequential)]
    struct FlagsClass
    {
        /// <summary>
        /// the parent class
        /// </summary>
        public IntPtr GTypeClass;

        /// <summary>
        /// a mask covering all possible values.
        /// </summary>
        public uint Mask;

        /// <summary>
        /// the number of possible values.
        /// </summary>
        public uint NValues;

        /// <summary>
        /// an array of #GFlagsValue structs describing the
        ///  individual values.
        /// </summary>
        public IntPtr Values;
    }

    /// <summary>
    /// A structure which contains a single flags value, its name, and its
    /// nickname.
    /// </summary>
    [StructLayout (LayoutKind.Sequential)]
    struct FlagsValue
    {
        /// <summary>
        /// the flags value
        /// </summary>
        public uint Value;

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
