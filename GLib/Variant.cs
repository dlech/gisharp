using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace GISharp.GLib
{
    public struct DBusHandle
    {
        int value;

        public DBusHandle (int handle) {
            value = handle;
        }

        public static implicit operator int (DBusHandle handle)
        {
            return handle.value;
        }

        public static implicit operator DBusHandle (int handle)
        {
            return new DBusHandle (handle);
        }
    }

    public class DBusObjectPath : IEquatable<DBusObjectPath>
    {
        readonly string value;

        public DBusObjectPath (string path)
        {
            if (!Variant.IsObjectPath (path)) {
                throw new ArgumentException ("Not a valid object path.", "path");
            }
            value = path;
        }

        public bool Equals (DBusObjectPath other)
        {
            if ((object)other == null) {
                return false;
            }
            return value == other.value;
        }

        public override bool Equals (object obj)
        {
            if ((object)this == null) {
                return obj == null;
            }
            return Equals (obj as DBusObjectPath);
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }

        public static bool operator == (DBusObjectPath one, DBusObjectPath two)
        {
            if ((object)one == null) {
                return (object)two == null;
            }
            return one.Equals (two);
        }

        public static bool operator != (DBusObjectPath one, DBusObjectPath two)
        {
            return !(one == two);
        }

        public static implicit operator string (DBusObjectPath path)
        {
            return path.value;
        }

        public static implicit operator DBusObjectPath (string path)
        {
            return new DBusObjectPath (path);
        }
    }

    public class DBusSignature : IEquatable<DBusSignature>
    {
        readonly string value;

        public DBusSignature (string signature)
        {
            if (!Variant.IsSignature (signature)) {
                throw new ArgumentException ("Not a valid signature.", "signature");
            }
            value = signature;
        }
        public bool Equals (DBusSignature other)
        {
            if ((object)other == null) {
                return false;
            }
            return value == other.value;
        }

        public override bool Equals (object obj)
        {
            if ((object)this == null) {
                return obj == null;
            }
            return Equals (obj as DBusSignature);
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }

        public static bool operator == (DBusSignature one, DBusSignature two)
        {
            if ((object)one == null) {
                return (object)two == null;
            }
            return one.Equals (two);
        }

        public static bool operator != (DBusSignature one, DBusSignature two)
        {
            return !(one == two);
        }

        public static implicit operator string (DBusSignature signature)
        {
            return signature.value;
        }

        public static implicit operator DBusSignature (string signature)
        {
            return new DBusSignature (signature);
        }
    }

    public partial class Variant
    {
        public Variant (byte[][] value) : base (IntPtr.Zero) // new_bytestring_array
        {
            var strv = IntPtr.Zero;
            if (value != null) {
                strv = MarshalG.Alloc ((value.Length + 1) * IntPtr.Size);
                var offset = 0;
                foreach (var bytestring in value) {
                    Marshal.WriteIntPtr (strv, offset, MarshalG.ByteStringToPtr (bytestring));
                    offset += IntPtr.Size;
                }
                Marshal.WriteIntPtr (strv, offset, IntPtr.Zero);
            }
            Handle = g_variant_new_bytestring_array (strv, -1);
            g_variant_ref_sink (Handle);
        }

        public Variant (KeyValuePair<Variant, Variant> value) : this (value.Key, value.Value) // new_dict_entry
        {
        }

        public Variant (DBusHandle value) : base (IntPtr.Zero) // new_handle
        {
            Handle = g_variant_new_handle (value);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusObjectPath value) : base (IntPtr.Zero) // new_object_path
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = GISharp.Core.MarshalG.StringToUtf8Ptr (value);
            Handle = g_variant_new_object_path (valuePtr);
            GISharp.Core.MarshalG.Free (valuePtr);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusObjectPath[] value) : base (IntPtr.Zero) // new_objv
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var strv = new string[value.Length];
            for (int i = 0; i < value.Length; i++) {
                strv [i] = value [i];
            }
            var ptr = MarshalG.StringArrayToGStrvPtr (strv);
            Handle = g_variant_new_objv (ptr, -1);
            MarshalG.FreeGStrv (ptr);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusSignature value) : base (IntPtr.Zero) // new_signature
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = MarshalG.StringToUtf8Ptr (value);
            Handle = g_variant_new_signature (valuePtr);
            MarshalG.Free (valuePtr);
            g_variant_ref_sink (Handle);
        }

        byte[][] GetBytestringArray () {
            ulong length;
            var ptr = g_variant_get_bytestring_array (Handle, out length);
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var array = new List<byte[]> ();
            var offset = 0;
            for (ulong i = 0; i < length; i++) {
                var elementPtr = Marshal.ReadIntPtr (ptr, offset);
                array.Add (MarshalG.PtrToByteString (elementPtr));
                offset += IntPtr.Size;
            }
            return array.ToArray ();
        }

        DBusObjectPath[] Objv {
            get {
                ulong length;
                var ptr = g_variant_get_objv (Handle, out length);
                if (ptr == IntPtr.Zero) {
                    return null;
                }
                var strv = MarshalG.GStrvPtrToStringArray (ptr, freePtr: true, freeElements: false);
                var objv = new DBusObjectPath[strv.Length];
                for (int i = 0; i < strv.Length; i++) {
                    objv [i] = strv [i];
                }
                return objv;
            }
        }

        // explicit cast operators

        public static explicit operator bool (Variant value)
        {
            if (value.VariantType != VariantType.Boolean) {
                throw new InvalidCastException ();
            }
            return value.GetBoolean ();
        }

        public static explicit operator Variant (bool value)
        {
            return new Variant (value);
        }

        public static explicit operator byte (Variant v)
        {
            if (v.VariantType != VariantType.Byte) {
                throw new InvalidCastException ();
            }
            return v.GetByte ();
        }

        public static explicit operator Variant (byte value)
        {
            return new Variant (value);
        }

        public static explicit operator byte[] (Variant v)
        {
            if (v.VariantType != VariantType.ByteString) {
                throw new InvalidCastException ();
            }
            return v.GetBytestring ();
        }

        public static explicit operator Variant (byte[] value)
        {
            return new Variant (value);
        }

        public static explicit operator byte[][] (Variant v)
        {
            if (v.VariantType != VariantType.ByteStringArray) {
                throw new InvalidCastException ();
            }
            return v.GetBytestringArray ();
        }

        public static explicit operator Variant (byte[][] value)
        {
            return new Variant (value);
        }

        public static explicit operator double (Variant v)
        {
            if (v.VariantType != VariantType.Double) {
                throw new InvalidCastException ();
            }
            return v.GetDouble ();
        }

        public static explicit operator Variant (double value)
        {
            return new Variant (value);
        }

        public static explicit operator DBusHandle (Variant v)
        {
            if (v.VariantType != VariantType.DBusHandle) {
                throw new InvalidCastException ();
            }
            return v.GetDBusHandle ();
        }

        public static explicit operator Variant (DBusHandle value)
        {
            return new Variant (value);
        }

        public static explicit operator short (Variant v)
        {
            if (v.VariantType != VariantType.Int16) {
                throw new InvalidCastException ();
            }
            return v.GetInt16 ();
        }

        public static explicit operator Variant (short value)
        {
            return new Variant (value);
        }

        public static explicit operator int (Variant v)
        {
            if (v.VariantType != VariantType.Int32) {
                throw new InvalidCastException ();
            }
            return v.GetInt32 ();
        }

        public static explicit operator Variant (int value)
        {
            return new Variant (value);
        }

        public static explicit operator long (Variant v)
        {
            if (v.VariantType != VariantType.Int64) {
                throw new InvalidCastException ();
            }
            return v.GetInt64 ();
        }

        public static explicit operator Variant (long value)
        {
            return new Variant (value);
        }

        public static explicit operator DBusObjectPath (Variant v)
        {
            if (v.VariantType != VariantType.ObjectPath) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.GetString (out length).Substring (0, (int)length);
        }

        public static explicit operator Variant (DBusObjectPath value)
        {
            return new Variant (value);
        }

        public static explicit operator DBusSignature (Variant v)
        {
            if (v.VariantType != VariantType.DBusSignature) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.GetString (out length).Substring (0, (int)length);
        }

        public static explicit operator Variant (DBusSignature value)
        {
            return new Variant (value);
        }

        // TODO cast Maybe to nullable types

        public static explicit operator Variant[] (Variant v)
        {
            if (!v.VariantType.IsContainer) {
                throw new InvalidCastException ();
            }
            return v.ChildValues.ToArray ();
        }

        public static explicit operator Variant (Variant[] value)
        {
            return new Variant (value);
        }

        public static explicit operator DBusObjectPath[] (Variant v)
        {
            if (v.VariantType != VariantType.ObjectPathArray) {
                throw new InvalidCastException ();
            }
            return v.Objv;
        }

        public static explicit operator Variant (DBusObjectPath[] value)
        {
            return new Variant (value);
        }

        public static explicit operator string (Variant v)
        {
            if (v.VariantType != VariantType.String) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.GetString (out length).Substring (0, (int)length);
        }

        public static explicit operator Variant (string value)
        {
            return new Variant (value);
        }

        public static explicit operator string[] (Variant v)
        {
            if (v.VariantType != VariantType.StringArray) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.GetStrv (out length);
        }

        public static explicit operator Variant (string[] value)
        {
            return new Variant (value);
        }

        public static explicit operator ushort (Variant v)
        {
            if (v.VariantType != VariantType.UInt16) {
                throw new InvalidCastException ();
            }
            return v.GetUint16 ();
        }

        public static explicit operator Variant (ushort value)
        {
            return new Variant (value);
        }

        public static explicit operator uint (Variant v)
        {
            if (v.VariantType != VariantType.UInt32) {
                throw new InvalidCastException ();
            }
            return v.GetUint32 ();
        }

        public static explicit operator Variant (uint value)
        {
            return new Variant (value);
        }

        public static explicit operator ulong (Variant v)
        {
            if (v.VariantType != VariantType.UInt64) {
                throw new InvalidCastException ();
            }
            return v.GetUint64 ();
        }

        public static explicit operator Variant (ulong value)
        {
            return new Variant (value);
        }

        public static explicit operator KeyValuePair<Variant, Variant> (Variant v)
        {
            if (!v.VariantType.IsDictEntry) {
                throw new InvalidCastException ();
            }
            return new KeyValuePair<Variant, Variant> (v.ChildValues[0], v.childValues[1]);
        }

        public static explicit operator Variant (KeyValuePair<Variant, Variant> value)
        {
            return new Variant (value.Key, value.Value);
        }
    }
}
