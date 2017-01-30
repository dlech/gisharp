using System;
using System.Reflection;
using GISharp.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Indicates that this Enum contains error codes for an error domain.
    /// </summary>
    [AttributeUsage (AttributeTargets.Enum)]
    public sealed class ErrorDomainAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the error domain.
        /// </summary>
        /// <value>The name of the error domain.</value>
        public string ErrorDomain { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDomainAttribute"/> class.
        /// </summary>
        /// <param name="errorDomain">The name of the error domain.</param>
        /// <remarks>
        /// The name must match the error domain quark for this error domain.
        /// </remarks>
        public ErrorDomainAttribute (string errorDomain)
        {
            ErrorDomain = errorDomain;
        }
    }

    /// <summary>
    /// Extension methods related to <see cref="ErrorDomainAttribute"/>.
    /// </summary>
    public static class ErrorDomainAttributeExtensions
    {
        /// <summary>
        /// Gets the error domain of an Enum.
        /// </summary>
        /// <returns>The error domain.</returns>
        /// <param name="value">Value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if type of <paramref name="value"/> is not decorated with
        /// <see cref="ErrorDomainAttribute"/>.
        /// </exception>
        public static Quark GetErrorDomain (this Enum value)
        {
            var type = value.GetType ();
            var attr = type.GetTypeInfo ().GetCustomAttribute<ErrorDomainAttribute> ();
            if (attr == null) {
                throw new ArgumentException ("Enum type must have ErrorDomainAttribute", nameof (value));
            }
            var quark = Quark.FromString (attr.ErrorDomain);
            return quark;
        }
    }
}
