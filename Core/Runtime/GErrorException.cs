using System;
using GISharp.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Exception that wraps an unmanaged GError.
    /// </summary>
    public sealed class GErrorException : Exception
    {
        /// <summary>
        /// The GError.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Create a new instance from a GError.
        /// </summary>
        public GErrorException (Error error) : base (error.Message)
        {
            Error = error;
        }

        /// <summary>
        /// Test if the exception matches a GError type
        /// </summary>
        /// <param name="value">
        /// An enum member of an enum type decorated with <see cref="GErrorDomainAttribute" />.
        /// </param>
        /// <returns>
        /// <c>true</c> if the exception matches the error domain and code
        /// of the <paramref name="value" />.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the type of <paramref name="value" /> does not have an
        /// <see cref="GErrorDomainAttribute" />.
        /// </exception>
        public bool Matches (Enum value)
        {
            return Error.Matches (value.GetGErrorDomain (), Convert.ToInt32 (value));
        }
    }
}
