
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
{
    [GType("GStrv", IsProxyForUnmanagedType = true)]
    public sealed class Strv : Boxed, IEnumerable<string>
    {
        public string[] Value => _Value.Value;
        readonly Lazy<string[]> _Value;

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
                AssertNotDisposed();
                var ret = g_strv_length(handle);
                return (int)ret;
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        [Since("2.44")]
        static extern bool g_strv_contains(IntPtr strv, IntPtr str);

        [Since("2.44")]
        public bool Contains(string str)
        {
            AssertNotDisposed();
            var str_ = GMarshal.StringToUtf8Ptr(str);
            var ret = g_strv_contains(handle, str_);
            GMarshal.Free(str_);
            return ret;
        }

        IEnumerator<string> GetEnumerator()
        {
            AssertNotDisposed();
            IntPtr str_;
            var offset = 0;
            while ((str_ = Marshal.ReadIntPtr(handle, offset)) != IntPtr.Zero) {
                yield return GMarshal.Utf8PtrToString(str_);
                offset += IntPtr.Size;
            }
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
