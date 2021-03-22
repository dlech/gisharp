// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;

namespace GISharp.Lib.GLib
{
    unsafe partial class Utf8Extensions
    {
        static partial void CheckSubstringArgs(this UnownedUtf8 str, clong startPos, clong endPos)
        {
            if (startPos < 0 || startPos > str.Length) {
                throw new ArgumentOutOfRangeException(nameof(startPos));
            }
            if (endPos < 0 || endPos > str.Length) {
                throw new ArgumentOutOfRangeException(nameof(endPos));
            }
            if (endPos < startPos) {
                throw new ArgumentException($"{nameof(startPos)} must be less than or equal to ${nameof(endPos)}");
            }
        }

        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public static Utf8 CaseFold(this UnownedUtf8 str)
        {
            var str_ = (byte*)str.UnsafeHandle;
            var len_ = (IntPtr)str.Length;
            var ret_ = g_utf8_casefold(str_, len_);
            GMarshal.PopUnhandledException();
            var ret = Opaque.GetInstance<Utf8>((IntPtr)ret_, Transfer.Full)!;
            return ret;
        }

        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public static Utf8 CaseFold(this Utf8 str) => str.AsUnownedUtf8().CaseFold();

        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public static Utf8 Substring(this Utf8 str, clong startPos, clong endPos) => str.AsUnownedUtf8().Substring(startPos, endPos);
    }
}
