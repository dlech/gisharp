using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// The <see cref="Unit" /> type is a substitute for <see cref="System.Void" />
    /// for use with generics since <see cref="System.Void" /> cannot be used.
    /// </summary>
    public struct Unit : IEquatable<Unit>
    {
        /// <summary>
        /// Gets the single value for this type.
        /// </summary>
        public static Unit Default { get; } = default;

        // hack to hide the constructor
        private Unit(int unit)
        {
        }

        /// <inheritdoc />
        public bool Equals(Unit other) => true;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is Unit) {
                return true;
            }
            return base.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => 0;

        public static bool operator ==(Unit a, Unit b) => true;

        public static bool operator !=(Unit a, Unit b) => false;
    }
}