
using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// A C-compiler-sized long value. On Windows, this is always 32-bits. On
    /// Other platforms, it is pointer-sized (32-bit or 64-bit).
    /// </summary>
    public readonly partial struct CLong : IEquatable<CLong>, IEquatable<int>, IEquatable<long>
    {
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public static readonly CLong MinValue = new CLong(minValue);

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public static readonly CLong MaxValue = new CLong(maxValue);

        public static CLong operator +(CLong a, CLong b) => new CLong(a.value + b.value);

        public static CLong operator -(CLong a, CLong b) => new CLong(a.value - b.value);

        public static CLong operator *(CLong a, CLong b) => new CLong(a.value * b.value);

        public static CLong operator /(CLong a, CLong b) => new CLong(a.value / b.value);

        public static CLong operator %(CLong a, CLong b) => new CLong(a.value % b.value);

        public static CLong operator <<(CLong a, int b) => new CLong(a.value << b);

        public static CLong operator >>(CLong a, int b) => new CLong(a.value >> b);

        public static bool operator <(CLong a, CLong b) => a.value < b.value;

        public static bool operator >(CLong a, CLong b) => a.value > b.value;

        public static bool operator <=(CLong a, CLong b) => a.value <= b.value;

        public static bool operator >=(CLong a, CLong b) => a.value >= b.value;

        public static implicit operator CLong(int n) => new CLong(n);

        public static implicit operator long(CLong n) => n.value;

        public bool Equals(CLong other) => value.Equals(other.value);

        public bool Equals(int other) => value.Equals(other);

        public bool Equals(long other) => value.Equals(other);

        public override bool Equals(object obj)
        {
            if (obj is CLong clong) {
                return value == clong.value;
            }
            return value.Equals(obj);
        }

        public override int GetHashCode() => value.GetHashCode();

        public override string ToString() => value.ToString();
    }
}
