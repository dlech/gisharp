// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Unmanaged string in file system encoding.
    /// </summary>
    public sealed unsafe class Filename : ByteString
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Filename(IntPtr handle, Transfer ownership)
            : this(handle, -1, ownership) { }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Filename(IntPtr handle, int length, Transfer ownership)
            : base(handle, length, ownership) { }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* g_filename_from_utf8(
            IntPtr utf8string,
            nint len,
            nuint* bytesRead,
            nuint* bytesWritten,
            IntPtr* error
        );

        private static byte* NewFromManaged(string filename)
        {
            var utf8 = Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                var ret = g_filename_from_utf8(utf8, -1, null, null, null);
                GMarshal.PopUnhandledException();
                if (ret == null)
                {
                    throw new Exception(
                        "Unexpected error. Use GISharp.Lib.GLib.FilenameExtensions.FromUtf8() to get a more detailed error."
                    );
                }
                return ret;
            }
            finally
            {
                Marshal.FreeCoTaskMem(utf8);
            }
        }

        /// <summary>
        /// Creates a new file name from a managed UTF-16 string.
        /// </summary>
        public Filename(string filename)
            : this((IntPtr)NewFromManaged(filename), Transfer.Full) { }

        /// <summary>
        /// Converts a managed UTF-16 string to an unmanged string with OS
        /// filename encoding.
        /// </summary>
        public static implicit operator Filename(string str)
        {
            using var utf8 = new Utf8(str);
            return new(utf8);
        }

        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern byte* g_filename_display_name(byte* filename);

        /// <inheritdoc/>
        public override string ToString()
        {
            var filename_ = (byte*)UnsafeHandle;
            var ret_ = g_filename_display_name(filename_);
            GMarshal.PopUnhandledException();
            using var utf8 = new Utf8((IntPtr)ret_, Transfer.Full);
            return utf8;
        }
    }
}
