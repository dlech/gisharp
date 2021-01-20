// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>


using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// A C-compiler-sized long value. On Windows, this is always 32-bits. On
    /// Other platforms, it is pointer-sized (32-bit or 64-bit).
    /// </summary>
    public readonly partial struct CULong : IEquatable<CULong>, IEquatable<uint>, IEquatable<ulong>
    {
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        public static readonly CULong MinValue = new(minValue);

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public static readonly CULong MaxValue = new(maxValue);

        /// <summary>
        /// Add
        /// </summary>
        public static CULong operator +(CULong a, CULong b) => new CULong(a.value + b.value);

        /// <summary>
        /// Subtract
        /// </summary>
        public static CULong operator -(CULong a, CULong b) => new CULong(a.value - b.value);

        /// <summary>
        /// Multiply
        /// </summary>
        public static CULong operator *(CULong a, CULong b) => new CULong(a.value * b.value);

        /// <summary>
        /// Divide
        /// </summary>
        public static CULong operator /(CULong a, CULong b) => new CULong(a.value / b.value);

        /// <summary>
        /// Modulo
        /// </summary>
        public static CULong operator %(CULong a, CULong b) => new CULong(a.value % b.value);

        /// <summary>
        /// Bitwise shift left
        /// </summary>
        public static CULong operator <<(CULong a, int b) => new CULong(a.value << b);

        /// <summary>
        /// Bitwise shift right
        /// </summary>
        public static CULong operator >>(CULong a, int b) => new CULong(a.value >> b);

        /// <summary>
        /// Tests if less than
        /// </summary>
        public static bool operator <(CULong a, CULong b) => a.value < b.value;

        /// <summary>
        /// Tests if greater than
        /// </summary>
        public static bool operator >(CULong a, CULong b) => a.value > b.value;

        /// <summary>
        /// Tests if less than or equal to
        /// </summary>
        public static bool operator <=(CULong a, CULong b) => a.value <= b.value;

        /// <summary>
        /// Tests if greater than or equal to
        /// </summary>
        public static bool operator >=(CULong a, CULong b) => a.value >= b.value;

        /// <summary>
        /// Converts from uint
        /// </summary>
        public static implicit operator CULong(uint n) => new CULong(n);

        /// <summary>
        /// Converts to ulong
        /// </summary>
        public static implicit operator ulong(CULong n) => n.value;

        /// <inheritdoc />
        public bool Equals(CULong other) => value.Equals(other.value);

        /// <inheritdoc />
        public bool Equals(uint other) => value.Equals(other);

        /// <inheritdoc />
        public bool Equals(ulong other) => value.Equals(other);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is CULong culong) {
                return value == culong.value;
            }
            return value.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => value.ToString();
    }
}
