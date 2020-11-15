using System;
using GISharp.Lib.GLib;

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
        /// Create a new instance from a <see cref="Error"/>.
        /// </summary>
        /// <param name="error">
        /// The <see cref="Error"/>.
        /// </param>
        public GErrorException(Error error) : base(error.Message)
        {
            Error = error;
        }


        /// <summary>
        /// Create a new instance from a an error domain enum member.
        /// </summary>
        /// <param name="code">
        /// A member of an enum that is decorated with <see cref="GErrorDomainAttribute"/>.
        /// </param>
        /// <param name="message">
        /// A helpful error message.
        /// </param>
        public GErrorException(Enum code, string message) : this(new Error(code, message))
        {
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
        public bool Matches(Enum value)
        {
            return Error.Matches(value.GetGErrorDomain(), Convert.ToInt32(value));
        }
    }
}
