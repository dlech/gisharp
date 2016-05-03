using System;
using System.Runtime.InteropServices;
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
    public class Error : OwnedOpaque
    {
        struct ErrorStruct
        {
            public Quark Domain;
            public int Code;
            public IntPtr Message;
        }

        /// <summary>
        /// Gets the error domain (aka error quark).
        /// </summary>
        /// <value>The domain value.</value>
        public Quark Domain {
            get {
                var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Domain));
                return new Quark ((uint)Marshal.ReadInt32 (Handle, (int)offset));
            }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code {
            get {
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
                var offset = Marshal.OffsetOf<ErrorStruct> (nameof (ErrorStruct.Message));
                var messagePtr = Marshal.ReadIntPtr (Handle, (int)offset);
                return MarshalG.Utf8PtrToString (messagePtr);
            }
        }

        public Error (Quark domain, int code, string message)
            : this (New (domain, code, message), Transfer.All)
        {
        }

        protected Error (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_error_new_literal (Quark domain, int code, IntPtr message);

        static IntPtr New (Quark domain, int code, string message)
        {
            if (message == null) {
                throw new ArgumentNullException (nameof (message));
            }
            var messagePtr = MarshalG.StringToUtf8Ptr (message);
            var ret = g_error_new_literal (domain, code, messagePtr);
            return ret;
        }

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_error_free (IntPtr error);

        protected override void Free ()
        {
            g_error_free (Handle);
        }

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_set_error_literal (IntPtr err, Quark domain, int code, IntPtr message);

        public static void Set (IntPtr error, Quark domain, int code, string message)
        {
            if (message == null) {
                throw new ArgumentNullException (nameof (message));
            }
            var messagePtr = MarshalG.StringToUtf8Ptr (message);
            g_set_error_literal (error, domain, code, messagePtr);
        }

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_propagate_error (IntPtr dest, IntPtr src);

        public static void Propogate (IntPtr dest, Error src)
        {
            if (src == null) {
                throw new ArgumentNullException (nameof (src));
            }
            g_propagate_error (dest, src.Handle);
            src.Owned = false;
        }
    }
}
