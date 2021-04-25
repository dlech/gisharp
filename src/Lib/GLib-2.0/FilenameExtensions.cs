// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class FilenameExtensions
    {
        /// <summary>
        /// Converts an escaped ASCII-encoded URI to a local filename in the
        /// encoding used for filenames.
        /// </summary>
        /// <param name="uri">
        /// a uri describing a filename (escaped, encoded in ASCII).
        /// </param>
        /// <returns>
        /// the resulting filename
        /// </returns>
        /// <exception name="Error.Exception">
        /// On error
        /// </exception>
        public static Filename FromUri(UnownedUtf8 uri)
        {
            var uri_ = (byte*)uri.UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret_ = g_filename_from_uri(uri_, null, &error_);
            GMarshal.PopUnhandledException();
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new Error.Exception(error);
            }
            var ret = Opaque.GetInstance<Filename>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string from UTF-8 to the encoding GLib uses for
        /// filenames. Note that on Windows GLib uses UTF-8 for filenames;
        /// on other platforms, this function indirectly depends on the
        /// [current locale][setlocale].
        /// </summary>
        /// <param name="utf8string">
        /// a UTF-8 encoded string.
        /// </param>
        /// <returns>
        /// The converted string
        /// </returns>
        /// <exception name="Error.Exception">
        /// On error
        /// </exception>
        public static Filename FromUtf8(Utf8 utf8string)
        {
            var utf8string_ = (byte*)utf8string.UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret_ = g_filename_from_utf8(utf8string_, -1, null, null, &error_);
            GMarshal.PopUnhandledException();
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new Error.Exception(error);
            }
            var ret = Opaque.GetInstance<Filename>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Converts a string which is in the encoding used by GLib for
        /// filenames into a UTF-8 string. Note that on Windows GLib uses UTF-8
        /// for filenames; on other platforms, this function indirectly depends on
        /// the [current locale][setlocale].
        /// </summary>
        /// <returns>
        /// The converted string.
        /// </returns>
        /// <exception name="Error.Exception">
        /// On error
        /// </exception>
        public static Utf8 ToUtf8(this Filename filename)
        {
            var opsysstring_ = (byte*)filename.UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret_ = g_filename_to_utf8(opsysstring_, -1, null, null, &error_);
            GMarshal.PopUnhandledException();
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new Error.Exception(error);
            }

            var ret = Opaque.GetInstance<Utf8>((IntPtr)ret_, Transfer.Full);
            return ret;
        }
    }
}
