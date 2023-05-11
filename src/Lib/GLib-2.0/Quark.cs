// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GLib
{
    unsafe partial struct Quark : IEquatable<Quark>
    {
        /// <summary>
        /// A zero value <see cref="Quark"/>.
        /// </summary>
        public static Quark Zero => default;

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="Quark"/>.
        /// </summary>
        public static explicit operator Quark(string? value)
        {
            if (value is null)
            {
                return Zero;
            }
            var ret = TryString(value);
            if (ret == Zero)
            {
                var msg = $"Quark does not exist for \"{value}\"";
                throw new InvalidCastException(msg);
            }
            return ret;
        }

        /// <inheritdoc/>
        public bool Equals(Quark other) => value == other.value;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is Quark quark && Equals(quark);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => value.GetHashCode();

        /// <summary>
        /// Compares two quarks for equality.
        /// </summary>
        public static bool operator ==(Quark left, Quark right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two quarks for inequality.
        /// </summary>
        public static bool operator !=(Quark left, Quark right)
        {
            return !left.Equals(right);
        }
    }
}
