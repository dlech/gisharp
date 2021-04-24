// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Filename : IEquatable<string>
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Filename(IntPtr handle, int length, Transfer ownership) : base(handle, length, ownership)
        {
        }

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
            var ret = GetInstance<Filename>((IntPtr)ret_, Transfer.Full);
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
            var ret = GetInstance<Filename>((IntPtr)ret_, Transfer.Full);
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
        public Utf8 ToUtf8()
        {
            var opsysstring_ = (byte*)UnsafeHandle;
            var error_ = default(Error.UnmanagedStruct*);
            var ret_ = g_filename_to_utf8(opsysstring_, -1, null, null, &error_);
            GMarshal.PopUnhandledException();
            if (error_ is not null) {
                var error = new Error((IntPtr)error_, Transfer.Full);
                throw new Error.Exception(error);
            }

            var ret = GetInstance<Utf8>((IntPtr)ret_, Transfer.Full);
            return ret;
        }

        /// <inheritdoc/>
        public bool Equals(string? other)
        {
            var str = ToString();
            return str.Equals(other);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            using var utf8 = ToUtf8();
            return utf8.ToString();
        }

        /// <summary>
        /// Converts an unmanged string with OS filename encoding to a managaged
        /// UTF-16 string.
        /// </summary>
        public static implicit operator string(Filename filename)
        {
            return filename.ToString();
        }

        /// <summary>
        /// Converts a managed UTF-16 string to an unmanged string with OS
        /// filename encoding.
        /// </summary>
        public static implicit operator Filename(string str)
        {
            using var utf8 = new Utf8(str);
            return FromUtf8(utf8);
        }
    }
}
