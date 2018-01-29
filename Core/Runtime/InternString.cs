using System;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public class InternString : Opaque, IEquatable<string>, IComparable<string>
    {
        public InternString (IntPtr handle, Transfer ownership) : base (handle) {
            if (ownership != Transfer.None) {
                throw new InvalidOperationException ("Interned strings can never be owned");
            }
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
        [Since ("2.10")]
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gpointer" type="const gchar*" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_intern_string (
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr @string);

        /// <summary>
        /// Returns a canonical representation for <paramref name="string"/>.
        /// Interned strings can be compared for equality by comparing the
        /// pointers, instead of using <see cref="string.=="/>.
        /// </summary>
        /// <param name="string">
        /// a string
        /// </param>
        /// <returns>
        /// a canonical representation for the string
        /// </returns>
        [Since ("2.10")]
        public static InternString Get (string @string)
        {
            var string_ = GMarshal.StringToUtf8Ptr (@string);
            var ret_ = g_intern_string (string_);
            GMarshal.Free (string_);
            var ret =  new InternString (ret_, Transfer.None);
            return ret;
        }

        public override string ToString ()
        {
            return GMarshal.Utf8PtrToString (handle);
        }

        public override int GetHashCode ()
        {
            return handle.GetHashCode ();
        }

        public override bool Equals (object obj)
        {
            var str = obj as string;
            if (str != null) {
                return this?.ToString () == str;
            }
            var other = obj as InternString;
            return other?.handle == this?.handle;
        }

        public static bool operator == (InternString a, InternString b)
        {
            return a?.handle == b?.handle;
        }

        public static bool operator != (InternString a, InternString b)
        {
            return a?.handle != b?.handle;
        }

        bool IEquatable<string>.Equals(string other)
        {
            return this == other;
        }

        int IComparable<string>.CompareTo(string other)
        {
            return this.ToString ().CompareTo (other);
        }

        public static bool operator == (string a, InternString b)
        {
            return a == b?.ToString ();
        }

        public static bool operator != (string a, InternString b)
        {
            return a != b?.ToString ();
        }

        public static bool operator == (InternString a, string b)
        {
            return a?.ToString () == b;
        }

        public static bool operator != (InternString a, string b)
        {
            return a?.ToString () != b;
        }

        public static implicit operator string (InternString a)
        {
            return a?.ToString ();
        }
    }
}
