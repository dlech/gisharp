using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    /// <summary>
    /// Structure for getting unmanged errors.
    /// </summary>
    /// <remarks>
    /// This is only indened for use in bindings. You probably want
    /// <see cref="GErrorException"/> instead.
    /// </remarks>
    [StructLayout (LayoutKind.Sequential)]
    public struct GError
    {
        public uint Domain;
        public int Code;
        IntPtr message;
        public string Message {
            get {
                return MarshalG.Utf8PtrToString (message);
            }
        }
    }
}
