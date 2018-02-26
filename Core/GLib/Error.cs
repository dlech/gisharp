using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// Structure for getting unmanged errors.
    /// </summary>
    /// <remarks>
    /// This is only intended for use in bindings. You probably want
    /// <see cref="GErrorException"/> instead.
    /// </remarks>
    [GType ("GError", IsProxyForUnmanagedType = true)]
    public sealed class Error : Boxed
    {
        static readonly IntPtr domainOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Domain));
        static readonly IntPtr codeOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Code));
        static readonly IntPtr messageOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Message));

        struct Struct
        {
            #pragma warning disable CS0649
            public Quark Domain;
            public int Code;
            public IntPtr Message;
            #pragma warning restore CS0649
        }

        /// <summary>
        /// Gets the error domain (aka error quark).
        /// </summary>
        /// <value>The domain value.</value>
        public Quark Domain => (uint)Marshal.ReadInt32(Handle, (int)domainOffset);

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code => Marshal.ReadInt32(Handle, (int)codeOffset);

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The message.</value>
        public Utf8 Message {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)messageOffset);
                var ret = GetInstance<Utf8>(ret_, Transfer.None);
                return ret;
            }
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_error_copy (IntPtr error);

        public Error(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_error_free (IntPtr error);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_error_new_literal (
            Quark domain,
            int code,
            IntPtr message);

        static IntPtr NewLiteral(Quark domain, int code, Utf8 message)
        {
            if (message == null) {
                throw new ArgumentNullException (nameof (message));
            }
            var ret = g_error_new_literal(domain, code, message.Handle);
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given <paramref name="domain"/>,
        /// <paramref name="code"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="domain">Error domain.</param>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public Error(Quark domain, int code, Utf8 message)
            : this (NewLiteral (domain, code, message), Transfer.Full)
        {
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
        public Error(System.Enum code, Utf8 message)
            : this (NewLiteral (code.GetGErrorDomain(), (int)(object)code, message), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given <paramref name="domain"/>,
        /// <paramref name="code"/> and message.
        /// </summary>
        /// <param name="domain">Error domain.</param>
        /// <param name="code">Error code.</param>
        /// <param name="format">Message format string.</param>
        /// <param name="args">Objects to format.</param>
        public Error (Quark domain, int code, string format, params object[] args)
            : this(domain, code, (Utf8)string.Format(format, args))
        {
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given
        /// <paramref name="code"/> and message.
        /// </summary>
        /// <remarks>
        /// The error domain is determined by the type of <paramref name="code"/>.
        /// </remarks>
        /// <param name="code">Error code.</param>
        /// <param name="format">Message format string.</param>
        /// <param name="args">Objects to format.</param>
        public Error(System.Enum code, string format, params object[] args)
            : this(code.GetGErrorDomain(), (int)(object)code, (Utf8)string.Format(format, args))
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_error_matches (
            IntPtr err,
            Quark domain,
            int code);

        /// <summary>
        /// Returns <c>true</c> if error matches <paramref name="domain"/> and
        /// <paramref name="code"/>, <c>false</c> otherwise.
        /// </summary>
        /// <returns>The matches.</returns>
        /// <param name="domain">An error domain.</param>
        /// <param name="code">An error code.</param>
        /// <remarks>
        /// If domain contains a <c>Failed</c> (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should instead
        /// treat any not-explicitly-recognized error code as being equivalent to
        /// the <c>Failed</c> code. This way, if the domain is extended in the
        /// future to provide a more specific error code for a certain case, your
        /// code will still work.
        /// </remarks>
        public bool Matches (Quark domain, int code)
        {
            var ret = g_error_matches(Handle, domain, code);
            return ret;
        }

        /// <summary>
        /// Returns <c>true</c> if error matches <paramref name="domain"/> and
        /// <paramref name="code"/>, <c>false</c> otherwise.
        /// </summary>
        /// <returns>The matches.</returns>
        /// <param name="domain">An error domain.</param>
        /// <param name="code">An error code.</param>
        /// <remarks>
        /// If domain contains a <c>Failed</c> (or otherwise generic) error code,
        /// you should generally not check for it explicitly, but should instead
        /// treat any not-explicitly-recognized error code as being equivalent to
        /// the <c>Failed</c> code. This way, if the domain is extended in the
        /// future to provide a more specific error code for a certain case, your
        /// code will still work.
        /// </remarks>
        public bool Matches (Quark domain, System.Enum code)
        {
            var ret = g_error_matches(Handle, domain, (int)(object)code);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_error_get_type ();

        static readonly GType _GType = g_error_get_type();
    }
}
