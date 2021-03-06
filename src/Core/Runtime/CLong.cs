// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

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
        public static readonly CLong MinValue = new(minValue);

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        public static readonly CLong MaxValue = new(maxValue);

        /// <summary>
        /// Add
        /// </summary>
        public static CLong operator +(CLong a, CLong b) => new(a.value + b.value);

        /// <summary>
        /// Subtract
        /// </summary>
        public static CLong operator -(CLong a, CLong b) => new(a.value - b.value);

        /// <summary>
        /// Multiply
        /// </summary>
        public static CLong operator *(CLong a, CLong b) => new(a.value * b.value);

        /// <summary>
        /// Divide
        /// </summary>
        public static CLong operator /(CLong a, CLong b) => new(a.value / b.value);

        /// <summary>
        /// Modulo
        /// </summary>
        public static CLong operator %(CLong a, CLong b) => new(a.value % b.value);

        /// <summary>
        /// Bitwise shift left
        /// </summary>
        public static CLong operator <<(CLong a, int b) => new(a.value << b);

        /// <summary>
        /// Bitwise shift right
        /// </summary>
        public static CLong operator >>(CLong a, int b) => new(a.value >> b);

        /// <summary>
        /// Tests if equal
        /// </summary>
        public static bool operator ==(CLong a, CLong b) => a.value == b.value;

        /// <summary>
        /// Tests if not equal
        /// </summary>
        public static bool operator !=(CLong a, CLong b) => a.value != b.value;

        /// <summary>
        /// Test if less than
        /// </summary>
        public static bool operator <(CLong a, CLong b) => a.value < b.value;

        /// <summary>
        /// Test if greater than
        /// </summary>
        public static bool operator >(CLong a, CLong b) => a.value > b.value;

        /// <summary>
        /// Test if less than or equal to
        /// </summary>
        public static bool operator <=(CLong a, CLong b) => a.value <= b.value;

        /// <summary>
        /// Test if greater than or equal to
        /// </summary>
        public static bool operator >=(CLong a, CLong b) => a.value >= b.value;

        /// <summary>
        /// Convert from int
        /// </summary>
        public static implicit operator CLong(int n) => new(n);

        /// <summary>
        /// Convert to long
        /// </summary>
        public static implicit operator long(CLong n) => n.value;

        /// <inheritdoc />
        public bool Equals(CLong other) => value.Equals(other.value);

        /// <inheritdoc />
        public bool Equals(int other) => value.Equals(other);

        /// <inheritdoc />
        public bool Equals(long other) => value.Equals(other);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is CLong clong) {
                return value == clong.value;
            }
            return value.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => value.ToString();
    }
}
