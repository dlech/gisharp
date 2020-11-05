using System;
using System.Reflection;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Indicates that an Enum contains error codes for a GError domain.
    /// </summary>
    [AttributeUsage (AttributeTargets.Enum)]
    public sealed class GErrorDomainAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the error domain.
        /// </summary>
        /// <value>The name of the error domain.</value>
        public string ErrorDomain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GErrorDomainAttribute"/> class.
        /// </summary>
        /// <param name="errorDomain">The name of the error domain.</param>
        /// <remarks>
        /// The name must match the error domain quark for this error domain.
        /// </remarks>
        public GErrorDomainAttribute (string errorDomain)
        {
            ErrorDomain = errorDomain;
        }
    }

    /// <summary>
    /// Extension methods related to <see cref="GErrorDomainAttribute"/>.
    /// </summary>
    public static class GErrorDomainAttributeExtensions
    {
        /// <summary>
        /// Gets the error domain of an Enum.
        /// </summary>
        /// <returns>The error domain.</returns>
        /// <param name="value">Value.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if type of <paramref name="value"/> is not decorated with
        /// <see cref="GErrorDomainAttribute"/>.
        /// </exception>
        public static Quark GetGErrorDomain (this Enum value)
        {
            var type = value.GetType();
            var attr = type.GetCustomAttribute<GErrorDomainAttribute> ();
            if (attr is null) {
                throw new ArgumentException ("Enum type must have ErrorDomainAttribute", nameof (value));
            }
            var quark = Quark.FromString (attr.ErrorDomain);
            return quark;
        }
    }
}
