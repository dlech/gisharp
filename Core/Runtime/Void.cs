using System;
using System.Diagnostics.CodeAnalysis;

namespace GISharp.Runtime
{
    /// <summary>
    /// The <see cref="Void" /> type is a substitute for <see cref="System.Void" />
    /// for use with generics since <see cref="System.Void" /> cannot be used.
    /// </summary>
    public struct Void : IEquatable<Void>
    {
        /// <summary>
        /// Gets the single value for this type.
        /// </summary>
        public static Void Default { get; } = default;

        // hack to hide the constructor
        [ExcludeFromCodeCoverage]
        private Void(int _) => throw new NotSupportedException();

        /// <inheritdoc />
        public bool Equals(Void other) => true;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is Void) {
                return true;
            }
            return base.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => 0;

        public static bool operator ==(Void a, Void b) => true;

        public static bool operator !=(Void a, Void b) => false;
    }
}