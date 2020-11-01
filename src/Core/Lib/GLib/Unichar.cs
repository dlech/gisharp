
using System;
using System.Text;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A type which can hold any UTF-32 or UCS-4 character code, also known as a Unicode code point.
    /// </summary>
    public struct Unichar : IEquatable<Unichar>, IEquatable<uint>, IEquatable<int>, IEquatable<Rune>
    {
        readonly uint value;

        /// <summary>
        /// Creates a new <see cref="Unichar"/> from <paramref name="value"/>
        /// </summary>
        /// <param name="value">
        /// A Unicode code point.
        /// </param>
        public Unichar(uint value) => this.value = value;

        /// <summary>
        /// Creates a new <see cref="Unichar"/> from <paramref name="value"/>
        /// </summary>
        /// <param name="value">
        /// A Unicode code point.
        /// </param>
        public Unichar(int value) => this.value = (uint)value;

        /// <summary>
        /// Creates a new <see cref="Unichar"/> from <paramref name="value"/>
        /// </summary>
        /// <param name="value">
        /// A Unicode code point.
        /// </param>
        public Unichar(Rune value) => this.value = (uint)value.Value;

        /// <summary>
        /// Tests if this code point has the same value as <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// A Unicode code point.
        /// </param>
        public bool Equals(Unichar other) => value == other.value;

        /// <summary>
        /// Tests if this code point has the same value as <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// A Unicode code point.
        /// </param>
        public bool Equals(uint other) => value == other;

        /// <summary>
        /// Tests if this code point has the same value as <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// A Unicode code point.
        /// </param>
        public bool Equals(int other) => value == (uint)other;

        /// <summary>
        /// Tests if this code point has the same value as <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// A Unicode code point.
        /// </param>
        public bool Equals(Rune other) => value == (uint)other.Value;

        /// <inheritdoc/>
        public override bool Equals(object other)
        {
            if (other is Unichar unichar) {
                return Equals(unichar);
            }
            if (other is Rune rune) {
                return Equals(rune);
            }
            if (other is uint u) {
                return Equals(u);
            }
            if (other is int i) {
                return Equals(i);
            }
            return value.Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"U+{value:X4}";
        }

        /// <summary>
        /// Tests two <see cref="Unichar"/>s for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Unichar)"/>.
        /// </remarks>
        public static bool operator ==(Unichar a, Unichar b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Tests two <see cref="Unichar"/>s for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(Unichar)"/>.
        /// </remarks>
        public static bool operator !=(Unichar a, Unichar b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Converts <see cref="int"/> to <see cref="Unichar"/>.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Unichar(int)"/>.
        /// </remarks>
        public static explicit operator Unichar(int value)
        {
            return new Unichar(value);
        }

        /// <summary>
        /// Converts <see cref="Unicar"/> to <see cref="int"/>.
        /// </summary>
        public static explicit operator int(Unichar c)
        {
            return (int)c.value;
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="int"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(int)"/>.
        /// </remarks>
        public static bool operator ==(Unichar a, int b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="int"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(int)"/>.
        /// </remarks>
        public static bool operator !=(Unichar a, int b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="int"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(int)"/>.
        /// </remarks>
        public static bool operator ==(int a, Unichar b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="int"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(int)"/>.
        /// </remarks>
        public static bool operator !=(int a, Unichar b)
        {
            return !b.Equals(a);
        }

        /// <summary>
        /// Converts <see cref="uint"/> to <see cref="Unichar"/>.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Unichar(uint)"/>.
        /// </remarks>
        public static explicit operator Unichar(uint value)
        {
            return new Unichar(value);
        }

        /// <summary>
        /// Converts <see cref="Unicar"/> to <see cref="uint"/>.
        /// </summary>
        public static explicit operator uint(Unichar c)
        {
            return c.value;
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="uint"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(uint)"/>.
        /// </remarks>
        public static bool operator ==(Unichar a, uint b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="uint"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(uint)"/>.
        /// </remarks>
        public static bool operator !=(Unichar a, uint b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="uint"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(uint)"/>.
        /// </remarks>
        public static bool operator ==(uint a, Unichar b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="uint"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(uint)"/>.
        /// </remarks>
        public static bool operator !=(uint a, Unichar b)
        {
            return !b.Equals(a);
        }

        /// <summary>
        /// Converts an <see cref="Unichar"/> to a <see cref="Rune"/>.
        /// </summary>
        public static implicit operator Rune(Unichar unichar)
        {
            return new Rune(unichar.value);
        }

        /// <summary>
        /// Converts a <see cref="Rune"/> to <see cref="Unichar"/>.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Unichar(Rune)"/>.
        /// </remarks>
        public static implicit operator Unichar(Rune rune)
        {
            return new Unichar(rune);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="Rune"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Rune)"/>.
        /// </remarks>
        public static bool operator ==(Unichar a, Rune b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="Rune"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(Rune)"/>.
        /// </remarks>
        public static bool operator !=(Unichar a, Rune b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="Rune"/> for equality.
        /// </summary>
        /// <remarks>
        /// This is equivalent to <see cref="Equals(Rune)"/>.
        /// </remarks>
        public static bool operator ==(Rune a, Unichar b)
        {
            return b.Equals(a);
        }

        /// <summary>
        /// Tests an <see cref="Unichar"/> and a <see cref="Rune"/> for inequality.
        /// </summary>
        /// <remarks>
        /// This is the inverse of <see cref="Equals(Rune)"/>.
        /// </remarks>
        public static bool operator !=(Rune a, Unichar b)
        {
            return !b.Equals(a);
        }
    }
}
