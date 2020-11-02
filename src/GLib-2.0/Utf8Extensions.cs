using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;

namespace GISharp.Lib.GLib
{
    partial class Utf8Extensions
    {
        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public unsafe static Utf8 CaseFold(this UnownedUtf8 str)
        {
            var str_ = str.Handle;
            var len_ = (System.IntPtr)str.Length;
            var ret_ = g_utf8_casefold(str_,len_);
            var ret = Opaque.GetInstance<Utf8>(ret_, Transfer.Full)!;
            return ret;
        }

        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public static Utf8 CaseFold(this Utf8 str) => str.AsUnownedUtf8().CaseFold();

        /// <include file="Utf8Extensions.xmldoc" path="declaration/member[@name='Utf8Extensions.CaseFold(GISharp.Lib.GLib.UnownedUtf8,System.Int32)']/*" />
        public static Utf8 Substring(this Utf8 str, clong startPos, clong endPos) => str.AsUnownedUtf8().Substring(startPos, endPos);
    }
}
