using System;
using System.Collections.Generic;

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
        public Variant (KeyValuePair<Variant, Variant> value) : this (value.Key, value.Value) // new_dict_entry
        {
        }

        public Variant (DBusHandle value) : base (IntPtr.Zero) // new_handle
        {
            Handle = g_variant_new_handle (value);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusObjectPath value) : base (IntPtr.Zero) // new_handle
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = GISharp.Core.MarshalG.StringToUtf8Ptr (value);
            Handle = g_variant_new_object_path (valuePtr);
            GISharp.Core.MarshalG.Free (valuePtr);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusObjectPath[] value) : base (IntPtr.Zero) // new_handle
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = GISharp.Core.MarshalG.CArrayToPtr (value);
            Handle = g_variant_new_objv (valuePtr, value.LongLength);
            GISharp.Core.MarshalG.Free (valuePtr);
            g_variant_ref_sink (Handle);
        }

        public Variant (DBusSignature value) : base (IntPtr.Zero) // new_handle
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = GISharp.Core.MarshalG.StringToUtf8Ptr (value);
            Handle = g_variant_new_signature (valuePtr);
            GISharp.Core.MarshalG.Free (valuePtr);
            g_variant_ref_sink (Handle);
        }

        public static explicit operator bool (Variant value)
        {
            if (value.VariantType != VariantType.Boolean) {
                throw new InvalidCastException ();
            }
            return value.Boolean;
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
            return v.Byte;
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
            return v.Bytestring;
        }

        public static explicit operator Variant (byte[] value)
        {
            return new Variant (value);
        }

        // TODO: handle BytestringArray

        public static explicit operator double (Variant v)
        {
            if (v.VariantType != VariantType.Double) {
                throw new InvalidCastException ();
            }
            return v.Double;
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
            return v.DBusHandle;
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
            return v.Int16;
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
            return v.Int32;
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
            return v.Int64;
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

        public static explicit operator DBusObjectPath[] (Variant v)
        {
            if (v.VariantType != VariantType.ObjectPathArray) {
                throw new InvalidCastException ();
            }
            ulong length;
            var objv = v.GetObjv (out length);
            var array = new DBusObjectPath[length];
            for (ulong i = 0; i < length; i ++) {
                array [i] = new DBusObjectPath (objv [i]);
            }
            return array;
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
            return v.Uint16;
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
            return v.Uint32;
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
            return v.Uint64;
        }

        public static explicit operator Variant (ulong value)
        {
            return new Variant (value);
        }
    }
}
