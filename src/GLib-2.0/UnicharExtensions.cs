// SPDX-License-Identifier: MIT
// Copyright (c) 2020-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    unsafe partial class UnicharExtensions
    {
        /// <summary>
        /// Converts a single character to UTF-8.
        /// </summary>
        /// <param name="ch">
        /// a Unicode character.
        /// </param>
        public static Utf8 ToUtf8(this Unichar ch)
        {
            var outbuf_ = (byte*)GMarshal.Alloc0(6);
            // TODO: pass length to Utf8 constructor
            g_unichar_to_utf8(ch, outbuf_);
            var outbuf = new Utf8((IntPtr)outbuf_, Transfer.Full);
            return outbuf;
        }

        /// <include file="UnicharExtensions.xmldoc" path="declaration/member[@name='UnicharExtensions.FullyDecompose(GISharp.Lib.GLib.Unichar,System.Boolean)']/*" />
        [Since("2.30")]
        public static Memory<Unichar> FullyDecompose(this Unichar ch, bool compat = false)
        {
            Memory<Unichar> result = new Unichar[maxDecompositionLength];
            var compat_ = compat.ToBoolean();
            using var resultHandle = result.Pin();
            try {
                var result_ = (Unichar*)resultHandle.Pointer;
                var resultLen_ = (UIntPtr)result.Length;
                var ret = g_unichar_fully_decompose(ch, compat_, result_, resultLen_);
                return result.Slice(0, (int)ret);
            }
            finally {
                resultHandle.Dispose();
            }
        }
    }
}
