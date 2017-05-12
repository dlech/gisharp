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
    [GType ("GError", IsWrappedNativeType = true)]
    public sealed class Error : Opaque
    {
        public sealed class SafeHandle : SafeOpaqueHandle
        {
            public static SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            struct ErrorStruct
            {
#pragma warning disable CS0649
                public Quark Domain;
                public int Code;
                public IntPtr Message;
#pragma warning restore CS0649
            }

            public Quark Domain {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Domain));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public int Code {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Code));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public IntPtr Message {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Message));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr g_error_copy (IntPtr error);

            public SafeHandle (IntPtr handle, Transfer ownership)
            {
                if (ownership == Transfer.None) {
                    handle = g_error_copy (handle);
                }
                SetHandle (handle);
            }

            public SafeHandle ()
            {
            }

            [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
            static extern void g_error_free (IntPtr error);

            protected override bool ReleaseHandle ()
            {
                try {
                    g_error_free (handle);
                    return true;
                }
                catch {
                    return false;
                }
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        /// <summary>
        /// Gets the error domain (aka error quark).
        /// </summary>
        /// <value>The domain value.</value>
        public Quark Domain {
            get {
                return Handle.Domain;
            }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code {
            get {
                return Handle.Code;
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The message.</value>
        public string Message {
            get {
                AssertNotDisposed ();
                var retPtr = Handle.Message;
                var ret = GMarshal.Utf8PtrToString (retPtr);
                return ret;
            }
        }

        public Error (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern SafeHandle g_error_new_literal (
            Quark domain,
            int code,
            IntPtr message);

        static SafeHandle NewLiteral (Quark domain, int code, string message)
        {
            if (message == null) {
                throw new ArgumentNullException (nameof (message));
            }
            var messagePtr = GMarshal.StringToUtf8Ptr (message);
            var ret = g_error_new_literal (domain, code, messagePtr);
            GMarshal.Free (messagePtr);
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="Error"/> with the given <paramref name="domain"/>,
        /// <paramref name="code"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="domain">Error domain.</param>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public Error (Quark domain, int code, string message)
            : this (NewLiteral (domain, code, message))
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
            : this (NewLiteral (domain, (int)(object)code, message))
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
            : this (domain, (int)(object)code, string.Format (format, args))
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_error_matches (
            SafeHandle err,
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
            AssertNotDisposed ();
            var ret = g_error_matches (Handle, domain, code);
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
            AssertNotDisposed ();
            var ret = g_error_matches (Handle, domain, (int)(object)code);
            return ret;
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_error_get_type ();

        static GType getGType ()
        {
            return g_error_get_type ();
        }
    }
}
