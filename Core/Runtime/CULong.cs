
using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// A C-compiler-sized long value. On Windows, this is always 32-bits. On
    /// Other platforms, it is pointer-sized (32-bit or 64-bit).
    /// </summary>
    public partial struct CULong : IEquatable<CULong>, IEquatable<uint>, IEquatable<ulong>
    {
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public static readonly CULong MinValue = new CULong(minValue);

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public static readonly CULong MaxValue = new CULong(maxValue);

        public static CULong operator +(CULong a, CULong b) => new CULong(a.value + b.value);

        public static CULong operator -(CULong a, CULong b) => new CULong(a.value - b.value);

        public static CULong operator *(CULong a, CULong b) => new CULong(a.value * b.value);

        public static CULong operator /(CULong a, CULong b) => new CULong(a.value / b.value);

        public static CULong operator %(CULong a, CULong b) => new CULong(a.value % b.value);

        public static CULong operator <<(CULong a, int b) => new CULong(a.value << b);

        public static CULong operator >>(CULong a, int b) => new CULong(a.value >> b);

        public static bool operator <(CULong a, CULong b) => a.value < b.value;

        public static bool operator >(CULong a, CULong b) => a.value > b.value;

        public static bool operator <=(CULong a, CULong b) => a.value <= b.value;

        public static bool operator >=(CULong a, CULong b) => a.value >= b.value;

        public static implicit operator CULong(uint n) => new CULong(n);

        public static implicit operator ulong(CULong n) => n.value;

        public bool Equals(CULong other) => value.Equals(other.value);

        public bool Equals(uint other) => value.Equals(other);

        public bool Equals(ulong other) => value.Equals(other);

        public override bool Equals(object obj)
        {
            if (obj is CULong culong) {
                return value == culong.value;
            }
            return value.Equals(obj);
        }

        public override int GetHashCode() => value.GetHashCode();

        public override string ToString() => value.ToString();
    }
}
