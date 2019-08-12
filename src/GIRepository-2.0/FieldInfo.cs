// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;

namespace GISharp.Lib.GIRepository
{
    public sealed class FieldInfo : BaseInfo
    {

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_field_info_get_field(IntPtr raw, IntPtr mem, out Argument value);

        public bool GetField (IntPtr mem, out Argument value)
        {
            return g_field_info_get_field (Handle, mem, out value);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern FieldInfoFlags g_field_info_get_flags (IntPtr raw);

        public FieldInfoFlags Flags {
            get {
                return g_field_info_get_flags (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_field_info_get_offset (IntPtr raw);

        public int Offset {
            get {
                return g_field_info_get_offset (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_field_info_get_size (IntPtr raw);

        public int Size {
            get {
                return g_field_info_get_size (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_field_info_get_type (IntPtr raw);

        public TypeInfo TypeInfo {
            get {
                IntPtr raw_ret = g_field_info_get_type (Handle);
                return GetInstance<TypeInfo>(raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_field_info_set_field(IntPtr raw, IntPtr mem, ref Argument value);

        public bool SetField (IntPtr mem, Argument value)
        {
            return g_field_info_set_field (Handle, mem, ref value);
        }

        public FieldInfo (IntPtr raw) : base (raw)
        {
        }
    }
}