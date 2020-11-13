using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    partial class UnicharExtensions
    {
        /// <summary>
        /// Converts a single character to UTF-8.
        /// </summary>
        /// <param name="ch">
        /// a Unicode character.
        /// </param>
        public static Utf8 ToUtf8(this Unichar ch)
        {
            var outbuf_ = GMarshal.Alloc0(6);
            g_unichar_to_utf8(ch, outbuf_);
            var outbuf = new Utf8(outbuf_, Transfer.Full);
            return outbuf;
        }

        /// <include file="UnicharExtensions.xmldoc" path="declaration/member[@name='UnicharExtensions.FullyDecompose(GISharp.Lib.GLib.Unichar,System.Boolean)']/*" />
        [Since("2.30")]
        public static Memory<Unichar> FullyDecompose(this Unichar ch, bool compat = false)
        {
            Memory<Unichar> result = new Unichar[maxDecompositionLength];
            var compat_ = compat.ToBoolean();
            ref readonly var result_ = ref MemoryMarshal.GetReference(result.Span);
            var resultLen_ = (UIntPtr)maxDecompositionLength;
            var ret = g_unichar_fully_decompose(ch, compat_, result_, resultLen_);
            return result.Slice(0, (int)ret);
        }
    }
}
