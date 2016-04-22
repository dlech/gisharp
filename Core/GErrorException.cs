using System;
using System.Runtime.InteropServices;
using GISharp.GLib;

namespace GISharp.Core
{
    /// <summary>
    /// Exception that wraps an unmanaged GError.
    /// </summary>
    public class GErrorException : Exception
    {
        GError error;

        /// <summary>
        /// Gets the error domain (aka error quark).
        /// </summary>
        /// <value>The domain value.</value>
        public uint Domain {
            get { return error.Domain; }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The code.</value>
        public int Code {
            get { return error.Code; }
        }

        string message;
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The message.</value>
        public override string Message {
            get {
                if (message == null) {
                    message = error.Message;
                }
                return message;
            }
        }

        IntPtr handle;
        /// <summary>
        /// Gets the pointer to the unmanaged GError structure.
        /// </summary>
        /// <value>The pointer.</value>
        public IntPtr Handle { get { return handle; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="GErrorException"/> class.
        /// </summary>
        /// <param name="ptr">Pointer to an unmanged GError*.</param>
        public GErrorException (IntPtr ptr)
        {
            // have to hang on the the pointer so we can free it later (which frees the message too).
            handle = ptr;
            error = (GError)Marshal.PtrToStructure<GError> (ptr);
        }

        [DllImport ("glib-2.0.dll")]
        extern static void g_clear_error (ref IntPtr err);

        ~GErrorException ()
        {
            g_clear_error (ref handle);
        }
    }
}
