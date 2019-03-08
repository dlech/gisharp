using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A Quark is a non-zero integer which uniquely identifies a
    /// particular string. A Quark value of zero is associated to <c>null</c>.
    /// </summary>
    public struct Quark
    {
        readonly uint value;

        /// <summary>
        /// A zero value <see cref="Quark"/>.
        /// </summary>
        public static Quark Zero {
            get {
                return default(Quark);
            }
        }

        Quark (uint value)
        {
            this.value = value;
        }

        /// <summary>
        /// Convert <see cref="uint"/> to <see cref="Quark"/>
        /// </summary>
        public static implicit operator Quark (uint value)
        {
            return new Quark (value);
        }

        /// <summary>
        /// Convert <see cref="Quark"/> to <see cref="uint"/>.
        /// </summary>
        public static implicit operator uint (Quark value)
        {
            return value.value;
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Quark"/>.
        /// </summary>
        public static explicit operator Quark(string value)
        {
            var ret = Quark.TryString(value);
            if (ret == 0) {
                var msg = $"Quark does not exist for \"{value}\"";
                throw new InvalidCastException(msg);
            }
            return ret;
        }

        /// <summary>
        /// Gets the #GQuark identifying the given string. If the string does
        /// not currently have an associated #GQuark, a new #GQuark is created,
        /// using a copy of the string.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark identifying the string, or 0 if @string is %NULL
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_quark_from_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

        /// <summary>
        /// Gets the <see cref="Quark"/> identifying the given string. If the string does
        /// not currently have an associated <see cref="Quark"/>, a new <see cref="Quark"/> is created.
        /// </summary>
        /// <param name="string">
        /// A string
        /// </param>
        /// <returns>
        /// The <see cref="Quark"/> identifying the string, or <see cref="Zero"/> if <paramref name="string"/> is <c>null</c>.
        /// </returns>
        public static Quark FromString(NullableUnownedUtf8 @string)
        {
            var string_ = @string.Handle;
            var ret = g_quark_from_string(string_);
            return ret;
        }

        /// <summary>
        /// Gets the #GQuark associated with the given string, or 0 if string is
        /// %NULL or it has no associated #GQuark.
        /// </summary>
        /// <remarks>
        /// If you want the GQuark to be created if it doesn't already exist,
        /// use g_quark_from_string() or g_quark_from_static_string().
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the #GQuark associated with the string, or 0 if @string is
        ///     %NULL or there is no #GQuark associated with it
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_quark_try_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

        /// <summary>
        /// Gets the <see cref="Quark"/> associated with the given string, or <see cref="Zero"/> if string is
        /// <c>null</c> or it has no associated <see cref="Quark"/>.
        /// </summary>
        /// <remarks>
        /// If you want the <see cref="Quark"/> to be created if it doesn't already exist,
        /// use <see cref="FromString"/>.
        /// </remarks>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// the <see cref="Quark"/> associated with the string, or <see cref="Zero"/> if <paramref name="string"/> is
        /// <c>null</c> or there is no <see cref="Quark"/> associated with it
        /// </returns>
        public static Quark TryString(NullableUnownedUtf8 @string)
        {
            var string_ = @string.Handle;
            var ret = g_quark_try_string(string_);
            return ret;
        }

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <param name="quark">
        /// a #GQuark.
        /// </param>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_quark_to_string(
            /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

        /// <summary>
        /// Gets the string associated with the given <see cref="Quark"/>.
        /// </summary>
        /// <returns>
        /// the string associated with the <see cref="Quark"/>
        /// </returns>
        public override string? ToString()
        {
            var ret_ = g_quark_to_string(value);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }
    }
}
