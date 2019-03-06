// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    public abstract class RegisteredTypeInfo : BaseInfo
    {
        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_registered_type_info_get_type_init (IntPtr raw);

        public UnownedUtf8 TypeInit {
            get {
                 var ret_ = g_registered_type_info_get_type_init(Handle);
                 var ret = new UnownedUtf8(ret_, -1);
                 return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_registered_type_info_get_type_name (IntPtr raw);

        public UnownedUtf8 TypeName {
            get {
                 var ret_ = g_registered_type_info_get_type_name(Handle);
                 var ret = new UnownedUtf8(ret_, -1);
                 return ret;
            }
        }
        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_registered_type_info_get_g_type (IntPtr info);

        public GType GType {
            get {
                 var ret = g_registered_type_info_get_g_type(Handle);
                 return ret;
            }
        }

        protected RegisteredTypeInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
