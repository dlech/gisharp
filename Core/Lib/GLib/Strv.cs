
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    [GType("GStrv", IsProxyForUnmanagedType = true)]
    public sealed class Strv : Boxed, IEnumerable<string>
    {
        public string[] Value => _Value.Value;
        readonly Lazy<string[]> _Value;

        static IntPtr New(string[] value)
        {
            return GMarshal.StringArrayToGStrvPtr(value);
        }

        public Strv(params string[] value) : this(New(value), Transfer.Full)
        {
        }

        public Strv(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
            _Value = new Lazy<string[]>(() => this.ToArray());
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_strv_get_type();

        static readonly GType _GType = g_strv_get_type();

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.6")]
        static extern uint g_strv_length(IntPtr strArray);

        /// <summary>
        /// Returns the length of this <see cref="Strv"/>.
        /// </summary>
        [Since("2.6")]
        public int Length {
            get {
                var ret = g_strv_length(Handle);
                return (int)ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.44")]
        static extern bool g_strv_contains(IntPtr strv, IntPtr str);

        [Since("2.44")]
        public bool Contains(Utf8 str)
        {
            var this_ = Handle;
            var str_ = str?.Handle ?? throw new ArgumentNullException(nameof(str));
            var ret = g_strv_contains(this_, str_);
            return ret;
        }

        public static implicit operator string[](Strv strv)
        {
            return strv?.Value;
        }

        IEnumerator<string> GetEnumerator()
        {
            IntPtr str_;
            var offset = 0;
            while ((str_ = Marshal.ReadIntPtr(Handle, offset)) != IntPtr.Zero) {
                yield return GMarshal.Utf8PtrToString(str_);
                offset += IntPtr.Size;
            }
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
