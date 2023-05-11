using System;
using System.Reflection;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Error domain helper methods.
    /// </summary>
    public static class ErrorDomain
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
        public static Quark GetGErrorDomain(this Enum value)
        {
            var type = value.GetType();
            var attr = type.GetCustomAttribute<GErrorDomainAttribute>();
            if (attr is null)
            {
                throw new ArgumentException(
                    "Enum type must have ErrorDomainAttribute",
                    nameof(value)
                );
            }
            var quark = Quark.FromString(attr.ErrorDomain);
            return quark;
        }
    }
}
