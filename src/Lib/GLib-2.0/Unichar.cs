// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using System;
using System.Text;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class Unichar
    {
        /// <summary>
        /// Converts a single character to UTF-8.
        /// </summary>
        /// <param name="ch">
        /// a Unicode character.
        /// </param>
        public static Utf8 ToUtf8(this Rune ch)
        {
            var ch_ = (uint)ch.Value;
            var outbuf_ = (byte*)GMarshal.Alloc0(6);
            // TODO: pass length to Utf8 constructor
            g_unichar_to_utf8(ch_, outbuf_);
            GMarshal.PopUnhandledException();
            var outbuf = new Utf8((IntPtr)outbuf_, Transfer.Full);
            return outbuf;
        }

        /// <include file="Unichar.xmldoc" path="declaration/member[@name='Unichar.FullyDecompose(System.Text.Rune,System.Boolean)']/*" />
        [Since("2.30")]
        public static Memory<Rune> FullyDecompose(this Rune ch, bool compat = false)
        {
            Memory<Rune> result = new Rune[maxDecompositionLength];
            var compat_ = compat.ToBoolean();
            using var resultHandle = result.Pin();
            var ch_ = (uint)ch.Value;
            var result_ = (uint*)resultHandle.Pointer;
            var resultLen_ = (nuint)result.Length;
            var ret = g_unichar_fully_decompose(ch_, compat_, result_, resultLen_);
            GMarshal.PopUnhandledException();
            return result.Slice(0, (int)ret);
        }
    }
}
