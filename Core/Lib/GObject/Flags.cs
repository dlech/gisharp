using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    public static class Flags
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
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
        public static void CompleteTypeInfo(GType gFlagsType, out TypeInfo info, IArray<FlagsValue> constValues)
        {
            var constValues_ = constValues?.Data ?? throw new ArgumentNullException(nameof(constValues));
            g_flags_complete_type_info(gFlagsType, out info, constValues_);
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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_flags_get_first_value (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            IntPtr flagsClass,
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
        public static FlagsValue GetFirstValue (FlagsClass flagsClass, uint value)
        {
            if (flagsClass == null) {
                throw new ArgumentNullException (nameof (flagsClass));
            }

            var ret_ = g_flags_get_first_value (flagsClass.Handle, value);
            var ret = Marshal.PtrToStructure<FlagsValue> (ret_);

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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_flags_get_value_by_name (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            IntPtr flagsClass,
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
        public static FlagsValue GetValueByName(FlagsClass flagsClass, UnownedUtf8 name)
        {
            var flagsClass_ = flagsClass?.Handle ?? throw new ArgumentNullException(nameof(flagsClass));
            var name_ = name.IsNull ? throw new ArgumentNullException(nameof(name)) : name.Handle;
            var ret_ = g_flags_get_value_by_name(flagsClass_, name_);
            var ret = Marshal.PtrToStructure<FlagsValue>(ret_);

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
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="FlagsValue" type="GFlagsValue*" managed-name="FlagsValue" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_flags_get_value_by_nick (
            /* <type name="FlagsClass" type="GFlagsClass*" managed-name="FlagsClass" /> */
            /* transfer-ownership:none */
            IntPtr flagsClass,
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
        public static FlagsValue GetValueByNick(FlagsClass flagsClass, UnownedUtf8 nick)
        {
            var flagsClass_ = flagsClass?.Handle ?? throw new ArgumentNullException(nameof(flagsClass));
            var nick_ = nick.IsNull ? throw new ArgumentNullException(nameof(nick)) : nick.Handle;
            var ret_ = g_flags_get_value_by_nick(flagsClass_, nick_);
            var ret = Marshal.PtrToStructure<FlagsValue>(ret_);

            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_flags_register_static (IntPtr typeName, IntPtr values);

        public static GType RegisterStatic(Utf8 typeName, IArray<FlagsValue> values)
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

            var ret = g_flags_register_static(typeName_, values_);
            // values are never freed for the lifetime of the program
            return ret;
        }
    }

    /// <summary>
    /// A structure which contains a single flags value, its name, and its
    /// nickname.
    /// </summary>
    public struct FlagsValue
    {
        uint value;
        IntPtr valueName;
        IntPtr valueNick;

        /// <summary>
        /// the flags value
        /// </summary>
        public uint Value => value;

        /// <summary>
        /// the name of the value
        /// </summary>
        public UnownedUtf8 Name => new UnownedUtf8(valueName, -1);

        /// <summary>
        /// the nickname of the value
        /// </summary>
        public UnownedUtf8 Nick => new UnownedUtf8(valueNick, -1);

        public FlagsValue(uint value, Utf8 name, Utf8 nick)
        {
            this.value = value;
            valueName = name?.Take() ?? throw new ArgumentNullException(nameof(name));
            valueNick = nick?.Take() ?? throw new ArgumentNullException(nameof(nick));
        }
    }
}
