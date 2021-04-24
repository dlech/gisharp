// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Error
    {
        /// <summary>
        /// Gets the error domain (aka error quark).
        /// </summary>
        /// <value>The domain value.</value>
        public Quark Domain => ((UnmanagedStruct*)UnsafeHandle)->Domain;

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code => ((UnmanagedStruct*)UnsafeHandle)->Code;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The message.</value>
        public UnownedUtf8 Message {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->Message;
                var ret = new UnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given
        /// <paramref name="code"/> and <paramref name="message"/>.
        /// </summary>
        /// <remarks>
        /// The error domain is determined by the type of <paramref name="code"/>.
        /// </remarks>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public Error(Enum code, UnownedUtf8 message)
            : this((IntPtr)NewLiteral(code.GetGErrorDomain(), (int)(object)code, message), Transfer.Full)
        {
        }

        /// <summary>
        /// Returns <c>true</c> if error matches
        /// <paramref name="code"/>, <c>false</c> otherwise.
        /// </summary>
        /// <returns>The matches.</returns>
        /// <param name="code">An error code.</param>
        /// <remarks>
        /// If domain contains a <c>Failed</c> (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should instead
        /// treat any not-explicitly-recognized error code as being equivalent to
        /// the <c>Failed</c> code. This way, if the domain is extended in the
        /// future to provide a more specific error code for a certain case, your
        /// code will still work.
        /// </remarks>
        public bool Matches(Enum code) => Matches(code.GetGErrorDomain(), Convert.ToInt32(code));

        /// <summary>
        /// If dest is NULL, free src; otherwise, moves src into *dest. The error
        /// variable dest points to must be NULL.
        /// </summary>
        /// <param name="dest">Destination.</param>
        /// <param name="src">Source.</param>
        /// <remarks>
        /// Note that src is no longer valid after this call.
        /// </remarks>
        public static void Propagate(UnmanagedStruct** dest, Error src)
        {
            var src_ = (UnmanagedStruct*)src.Take();
            g_propagate_error(dest, src_);
            GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Exception that wraps an unmanaged GError.
        /// </summary>
        public sealed class Exception : System.Exception
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
            public Exception(Error error) : base(error.Message)
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
            public Exception(Enum code, string message)
                : this(new Error(code.GetGErrorDomain(), Convert.ToInt32(code), message))
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
}
