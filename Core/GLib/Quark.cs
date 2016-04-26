using System;
using System.Runtime.InteropServices;

namespace GISharp.GLib
{
    /// <summary>
    /// A Quark is a non-zero integer which uniquely identifies a
    /// particular string. A Quark value of zero is associated to <c>null</c>.
    /// </summary>
    public struct Quark
    {
        readonly uint value;

        public static Quark Null {
            get {
                return new Quark ();
            }
        }

        internal Quark (uint value)
        {
            this.value = value;
        }

        public static implicit operator Quark (uint value)
        {
            return new Quark (value);
        }

        public static implicit operator uint (Quark value)
        {
            return value.value;
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
        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_quark_from_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

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
        public static Quark FromString (string @string)
        {
            var @string_ = GISharp.Runtime.MarshalG.StringToUtf8Ptr (@string);
            var ret = g_quark_from_string (@string_);
            GISharp.Runtime.MarshalG.Free (@string_);
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
        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern Quark g_quark_try_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

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
        public static Quark TryString (string @string)
        {
            var @string_ = GISharp.Runtime.MarshalG.StringToUtf8Ptr (@string);
            var ret = g_quark_try_string (@string_);
            GISharp.Runtime.MarshalG.Free (@string_);
            return ret;
        }

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [GISharp.Runtime.SinceAttribute ("2.10")]
        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="const gchar*" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_intern_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

        /// <summary>
        /// Returns a canonical representation for @string. Interned strings
        /// can be compared for equality by comparing the pointers, instead of
        /// using strcmp().
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [GISharp.Runtime.SinceAttribute ("2.10")]
        public static IntPtr InternString (string @string)
        {
            var @string_ = GISharp.Runtime.MarshalG.StringToUtf8Ptr (@string);
            var ret = g_intern_string (@string_);
            GISharp.Runtime.MarshalG.Free (@string_);
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
        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_quark_to_string (
            /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
            /* transfer-ownership:none */
            Quark quark);

        /// <summary>
        /// Gets the string associated with the given #GQuark.
        /// </summary>
        /// <returns>
        /// the string associated with the #GQuark
        /// </returns>
        public override string ToString ()
        {
            var ret_ = g_quark_to_string (value);
            var ret = GISharp.Runtime.MarshalG.Utf8PtrToString (ret_);

            return ret;
        }
    }
}
