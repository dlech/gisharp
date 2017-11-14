using System;
using GISharp.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Exception that wraps an unmanaged GError.
    /// </summary>
    public sealed class GErrorException : Exception
    {
        public Error Error { get; private set; }

        public override string Message {
            get {
                return Error.Message;
            }
        }

        public GErrorException (Error error)
        {
            Error = error;
        }

        public GErrorException (IntPtr handle)
            : this (new Error (handle, Transfer.Full))
        {
        }

        public bool Matches (Enum value)
        {
            return Error.Matches (value.GetErrorDomain (), Convert.ToInt32 (value));
        }
    }
}
