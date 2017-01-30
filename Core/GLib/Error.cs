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
    /// This is only indened for use in bindings. You probably want
    /// <see cref="GErrorException"/> instead.
    /// </remarks>
    [GType ("GError", IsWrappedNativeType = true)]
    public class Error : OwnedOpaque
    {
        struct ErrorStruct
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
        public Quark Domain {
            get {
                AssertNotDisposed ();
                var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Domain));
                return (uint)Marshal.ReadInt32 (Handle, (int)offset);
            }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code {
            get {
                AssertNotDisposed ();
                var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Code));
                return Marshal.ReadInt32 (Handle, (int)offset);
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The message.</value>
        public string Message {
            get {
                AssertNotDisposed ();
                var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Message));
                var messagePtr = Marshal.ReadIntPtr (Handle, (int)offset);
                return GMarshal.Utf8PtrToString (messagePtr);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given <paramref name="domain"/>,
        /// <paramref name="code"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="domain">Error domain.</param>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public Error (Quark domain, int code, string message)
            : this (New (domain, code, message), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given <paramref name="domain"/>,
        /// <paramref name="code"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="domain">Error domain.</param>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public Error (Quark domain, System.Enum code, string message)
            : this (New (domain, (int)(object)code, message), Transfer.Full)
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
            : this (domain, code, string.Format (format, args))
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
        public Error (Quark domain, System.Enum code, string format, params object[] args)
            : this (New (domain, (int)(object)code, string.Format (format, args)), Transfer.Full)
        {
        }

        public Error (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_error_new_literal (Quark domain, int code, IntPtr message);

        static IntPtr New (Quark domain, int code, string message)
        {
            if (message == null) {
                throw new ArgumentNullException (nameof (message));
            }
            var messagePtr = GMarshal.StringToUtf8Ptr (message);
            var ret = g_error_new_literal (domain, code, messagePtr);
            GMarshal.Free (messagePtr);
            return ret;
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_error_free (IntPtr error);

        protected override void Free ()
        {
            g_error_free (Handle);
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_error_copy (IntPtr err);

        /// <summary>
        /// Makes a copy of this <see cref="Error"/>.
        /// </summary>
        /// <returns>A new <see cref="Error"/>.</returns>
        public Error Copy ()
        {
            AssertNotDisposed ();
            var ret_ = g_error_copy (Handle);
            var ret = new Error (ret_, Transfer.Full);
            return ret;
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_error_matches (IntPtr err, Quark domain, int code);

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
            AssertNotDisposed ();
            var ret = g_error_matches (Handle, domain, code);
            return ret;
        }

        /// <summary>
        /// Invalidate this instance. Used by <see cref="GMarshal.PropogateError"/>.
        /// </summary>
        internal void Invalidate ()
        {
            Owned = false;
            IsDisposed = true;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_error_get_type ();

        static GType getGType ()
        {
            return g_error_get_type ();
        }
    }
}
