using System;
using GISharp.GLib;

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
                throw new ArgumentException ("Not a valid signature.", nameof (signature));
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
}
