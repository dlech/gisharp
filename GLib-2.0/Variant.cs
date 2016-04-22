using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using GISharp.Runtime;

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
        static IntPtr NewBytestringArray (byte[][] value) // new_bytestring_array
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
            var retPtr = g_variant_new_bytestring_array (strv, -1);
            return retPtr;
        }

        public Variant (byte[][] value) : this (NewBytestringArray (value), Transfer.None)
        {
        }

        public Variant (KeyValuePair<Variant, Variant> value) : this (value.Key, value.Value) // new_dict_entry
        {
        }

        static IntPtr NewHandle (DBusHandle value) // new_handle
        {
            var retPtr =  g_variant_new_handle (value);
            return retPtr;
        }

        public Variant (DBusHandle value) : this (NewHandle (value), Transfer.None)
        {
        }

        static IntPtr NewObjectPath (DBusObjectPath value) // new_object_path
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = MarshalG.StringToUtf8Ptr (value);
            var retPtr = g_variant_new_object_path (valuePtr);
            MarshalG.Free (valuePtr);
            return retPtr;
        }


        public Variant (DBusObjectPath value) : this (NewObjectPath (value), Transfer.None)
        {
        }

        static IntPtr NewObjv (DBusObjectPath[] value) // new_objv
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var strv = new string[value.Length];
            for (int i = 0; i < value.Length; i++) {
                strv [i] = value [i];
            }
            var ptr = MarshalG.StringArrayToGStrvPtr (strv);
            var retPtr = g_variant_new_objv (ptr, -1);
            MarshalG.FreeGStrv (ptr);
            return retPtr;
        }

        public Variant (DBusObjectPath[] value) : this (NewObjv (value), Transfer.None)
        {
        }

        static IntPtr NewSignature (DBusSignature value) // new_signature
        {
            if (value == null) {
                throw new ArgumentNullException ("value");
            }
            var valuePtr = MarshalG.StringToUtf8Ptr (value);
            var retPtr = g_variant_new_signature (valuePtr);
            MarshalG.Free (valuePtr);
            return retPtr;
        }

        public Variant (DBusSignature value) : this (NewSignature (value), Transfer.None)
        {
        }

        byte[][] GetBytestringArray () {
            ulong length;
            var ptr = g_variant_get_bytestring_array (Handle, out length);
            if (ptr == IntPtr.Zero) {
                return null;
            }
            var array = new System.Collections.Generic.List<byte[]> ();
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

        IndexedCollection<Variant> childValues;
        public IndexedCollection<Variant> ChildValues {
            get {
                AssertNotDisposed ();
                if (childValues == null) {
                    childValues = new IndexedCollection<Variant> (NChildren, getChildValue);
                }
                return childValues;
            }
        }

        // explicit cast operators

        public static explicit operator bool (Variant value)
        {
            if (value.Type != VariantType.Boolean) {
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
            if (v.Type != VariantType.Byte) {
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
            if (v.Type != VariantType.ByteString) {
                throw new InvalidCastException ();
            }
            return v.Bytestring;
        }

        public static explicit operator Variant (byte[] value)
        {
            return new Variant (value);
        }

        public static explicit operator byte[][] (Variant v)
        {
            if (v.Type != VariantType.ByteStringArray) {
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
            if (v.Type != VariantType.Double) {
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
            if (v.Type != VariantType.DBusHandle) {
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
            if (v.Type != VariantType.Int16) {
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
            if (v.Type != VariantType.Int32) {
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
            if (v.Type != VariantType.Int64) {
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
            if (v.Type != VariantType.ObjectPath) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.getString (out length).Substring (0, (int)length);
        }

        public static explicit operator Variant (DBusObjectPath value)
        {
            return new Variant (value);
        }

        public static explicit operator DBusSignature (Variant v)
        {
            if (v.Type != VariantType.DBusSignature) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.getString (out length).Substring (0, (int)length);
        }

        public static explicit operator Variant (DBusSignature value)
        {
            return new Variant (value);
        }

        // TODO cast Maybe to nullable types

        public static explicit operator Variant[] (Variant v)
        {
            if (!v.Type.IsContainer) {
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
            if (v.Type != VariantType.ObjectPathArray) {
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
            if (v.Type != VariantType.String) {
                throw new InvalidCastException ();
            }
            ulong length;
            return v.getString (out length);
        }

        public static explicit operator Variant (string value)
        {
            return new Variant (value);
        }

        public static explicit operator string[] (Variant v)
        {
            if (v.Type != VariantType.StringArray) {
                throw new InvalidCastException ();
            }
            return v.Strv;
        }

        public static explicit operator Variant (string[] value)
        {
            return new Variant (value);
        }

        public static explicit operator ushort (Variant v)
        {
            if (v.Type != VariantType.UInt16) {
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
            if (v.Type != VariantType.UInt32) {
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
            if (v.Type != VariantType.UInt64) {
                throw new InvalidCastException ();
            }
            return v.Uint64;
        }

        public static explicit operator Variant (ulong value)
        {
            return new Variant (value);
        }

        public static explicit operator KeyValuePair<Variant, Variant> (Variant v)
        {
            if (!v.Type.IsDictEntry) {
                throw new InvalidCastException ();
            }
            return new KeyValuePair<Variant, Variant> (v.ChildValues[0], v.ChildValues[1]);
        }

        public static explicit operator Variant (KeyValuePair<Variant, Variant> value)
        {
            return new Variant (value.Key, value.Value);
        }

        static void AssertNewArrayArgs (VariantType childType, Variant[] children)
        {
            if (childType == null && (children == null || children.Length == 0)) {
                throw new ArgumentException ("Must specify child type when no children", nameof(childType));
            }
            if (childType == null && children == null) {
                throw new ArgumentException ("childType and children cannot both be null");
            }
            if (children != null) {
                var testChildType = childType ?? children[0].Type;
                foreach (var item in children) {
                    if (item == null) {
                        throw new ArgumentException ("Array cannot have null elements", nameof(children));
                    }
                    if (item.Type != testChildType) {
                        throw new ArgumentException ("All children must have the same variant type.", nameof(children));
                    }
                }
            }
        }

        static void AssertNewDictEntryArgs (Variant key, Variant value)
        {
            if (!key.Type.IsBasic) {
                throw new ArgumentException ("Key must be a basic variant type.", nameof(key));
            }
        }

        static void AssertNewTupleArgs (Variant[] children)
        {
            foreach (var item in children) {
                if (item == null) {
                    throw new ArgumentException ("Tuple cannot have null elements", nameof(children));
                }
            }
        }
    }
}
