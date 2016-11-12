// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GIRepository
{
    public abstract class RegisteredTypeInfo : BaseInfo
    {
        readonly Lazy<string> _TypeInit;
        public string TypeInit { get { return _TypeInit.Value; } }

        readonly Lazy<string> _TypeName;
        public string TypeName { get { return _TypeName.Value; } }

        readonly Lazy<GType> _GType;
        public GType GType { get { return _GType.Value; } }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_registered_type_info_get_type_init (IntPtr raw);

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_registered_type_info_get_type_name (IntPtr raw);

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_registered_type_info_get_g_type (IntPtr info);

        protected RegisteredTypeInfo (IntPtr raw) : base (raw)
        {
            _TypeInit = new Lazy<string> (() => {
                IntPtr raw_ret = g_registered_type_info_get_type_init (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            });
            _TypeName = new Lazy<string> (() => {
                IntPtr raw_ret = g_registered_type_info_get_type_name (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            });
            _GType = new Lazy<GType> (() =>
                g_registered_type_info_get_g_type (Handle));
        }
    }
}
