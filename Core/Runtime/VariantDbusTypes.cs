using System;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Integer that represents a D-Bus handle.
    /// </summary>
    public struct DBusHandle
    {
        readonly int value;

        /// <summary>
        /// Creates a new D-Bus object path.
        /// </summary>
        public DBusHandle(int handle)
        {
            value = handle;
        }

        /// <summary>
        /// Converts a D-bus handle to an integer.
        /// </summary>
        public static implicit operator int(DBusHandle handle)
        {
            return handle.value;
        }

        /// <summary>
        /// Converts an integer to a D-bus handle.
        /// </summary>
        public static implicit operator DBusHandle(int handle)
        {
            return new DBusHandle(handle);
        }
    }

    /// <summary>
    /// String that represents a D-Bus object path.
    /// </summary>
    public class DBusObjectPath : IEquatable<DBusObjectPath>
    {
        readonly string value;

        /// <summary>
        /// Creates a new D-Bus object path.
        /// </summary>
        public DBusObjectPath(string path)
        {
            if (!Variant.IsObjectPath(path)) {
                throw new ArgumentException("Not a valid object path.", nameof(path));
            }
            value = path;
        }

        /// <inheritdoc />
        public bool Equals(DBusObjectPath other)
        {
            return value == other.value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is DBusObjectPath path) {
                return Equals(path);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Tests if two D-Bus object paths are equal.
        /// </summary>
        public static bool operator ==(DBusObjectPath? one, DBusObjectPath? two)
        {
            return Equals(one, two);
        }

        /// <summary>
        /// Tests if two D-Bus object paths are not equal.
        /// </summary>
        public static bool operator !=(DBusObjectPath? one, DBusObjectPath? two)
        {
            return !Equals(one, two);
        }

        /// <summary>
        /// Converts a D-bus object path to a string.
        /// </summary>
        public static implicit operator string(DBusObjectPath path)
        {
            return path.value;
        }

        /// <summary>
        /// Converts a string to a D-bus object path.
        /// </summary>
        public static implicit operator DBusObjectPath(string path)
        {
            return new DBusObjectPath(path);
        }
    }

    /// <summary>
    /// A string that represents a D-Bus signature.
    /// </summary>
    public class DBusSignature : IEquatable<DBusSignature>
    {
        readonly string value;

        /// <summary>
        /// Creates a new D-bus signature.
        /// </summary>
        public DBusSignature(string signature)
        {
            if (!Variant.IsSignature(signature)) {
                throw new ArgumentException("Not a valid signature.", nameof(signature));
            }
            value = signature;
        }

        /// <inheritdoc />
        public bool Equals(DBusSignature other)
        {
            return value == other.value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is DBusSignature signature) {
                Equals(signature);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Tests if two D-Bus signatures are equal.
        /// </summary>
        public static bool operator ==(DBusSignature? one, DBusSignature? two)
        {
            return Equals(one, two);
        }

        /// <summary>
        /// Tests if two D-Bus signatures are not equal.
        /// </summary>
        public static bool operator !=(DBusSignature? one, DBusSignature? two)
        {
            return !Equals(one, two);
        }

        /// <summary>
        /// Converts a D-bus signature to a string.
        /// </summary>
        public static implicit operator string(DBusSignature signature)
        {
            return signature.value;
        }

        /// <summary>
        /// Converts a string to a D-bus signature.
        /// </summary>
        public static implicit operator DBusSignature(string signature)
        {
            return new DBusSignature(signature);
        }
    }
}
