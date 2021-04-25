// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Indicates that an Enum contains error codes for a GError domain.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
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
        public GErrorDomainAttribute(string errorDomain)
        {
            ErrorDomain = errorDomain;
        }
    }
}
