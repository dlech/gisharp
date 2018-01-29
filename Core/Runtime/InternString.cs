using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    public class InternString : Opaque, IEnumerable<char>, IEnumerable, ICloneable, IComparable, IComparable<String>, IConvertible, IEquatable<String>
    {
        string stringValue;

        public InternString (IntPtr handle, Transfer ownership) : base (handle) {
            if (ownership != Transfer.None) {
                throw new InvalidOperationException ("Interned strings can never be owned");
            }
            stringValue = GMarshal.Utf8PtrToString (handle);
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
            return stringValue;
        }

        public override int GetHashCode ()
        {
            return handle.GetHashCode ();
        }

        public override bool Equals (object obj)
        {
            var str = obj as string;
            if (str != null) {
                return this?.stringValue == str;
            }
            var other = obj as InternString;
            return other?.handle == this?.handle;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return ((IEnumerable<char>)stringValue).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<char>)stringValue).GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return stringValue.Clone();
        }

        int IComparable.CompareTo(object obj)
        {
            return stringValue.CompareTo(obj);
        }

        int IComparable<string>.CompareTo(string other)
        {
            return stringValue.CompareTo(other);
        }

        TypeCode IConvertible.GetTypeCode()
        {
            return stringValue.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return stringValue.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)stringValue).ToUInt64(provider);
        }

        public bool Equals(string other)
        {
            return stringValue.Equals(other);
        }

        public static bool operator == (InternString a, InternString b)
        {
            return a?.handle == b?.handle;
        }

        public static bool operator != (InternString a, InternString b)
        {
            return a?.handle != b?.handle;
        }

        public static bool operator == (string a, InternString b)
        {
            return a == b?.stringValue;
        }

        public static bool operator != (string a, InternString b)
        {
            return a != b?.stringValue;
        }

        public static bool operator == (InternString a, string b)
        {
            return a?.stringValue == b;
        }

        public static bool operator != (InternString a, string b)
        {
            return a?.stringValue != b;
        }

        public static implicit operator string (InternString a)
        {
            return a?.stringValue;
        }
    }
}
