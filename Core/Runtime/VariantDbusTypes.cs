using System;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
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
                throw new ArgumentException ("Not a valid object path.", nameof (path));
            }
            value = path;
        }

        public bool Equals(DBusObjectPath other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is DBusObjectPath path) {
                return Equals(path);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }

        public static bool operator ==(DBusObjectPath? one, DBusObjectPath? two)
        {
            return object.Equals(one, two);
        }

        public static bool operator !=(DBusObjectPath? one, DBusObjectPath? two)
        {
            return !object.Equals(one, two);
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
                throw new ArgumentException ("Not a valid signature.", nameof (signature));
            }
            value = signature;
        }
        public bool Equals (DBusSignature other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is DBusSignature signature) {
                Equals(signature);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode ()
        {
            return value.GetHashCode ();
        }

        public static bool operator ==(DBusSignature? one, DBusSignature? two)
        {
            return object.Equals(one, two);
        }

        public static bool operator !=(DBusSignature? one, DBusSignature? two)
        {
            return !object.Equals(one, two);
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
}
