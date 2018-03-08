// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GISharp.Lib.GIRepository
{
    [DebuggerDisplay ("{Tag}")]
    public sealed class TypeInfo : BaseInfo
    {

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_type_info_get_array_fixed_size (IntPtr raw);

        public int ArrayFixedSize {
            get {
                int raw_ret = g_type_info_get_array_fixed_size (Handle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_type_info_get_array_length (IntPtr raw);

        public int ArrayLengthIndex {
            get {
                int raw_ret = g_type_info_get_array_length (Handle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern ArrayType g_type_info_get_array_type (IntPtr raw);

        public ArrayType ArrayType {
            get {
                if (Tag != TypeTag.Array) {
                    return ArrayType.None;
                }
                return g_type_info_get_array_type (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_info_get_interface (IntPtr raw);

        public BaseInfo Interface {
            get {
                IntPtr raw_ret = g_type_info_get_interface (Handle);
                BaseInfo ret = MarshalPtr<BaseInfo> (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_info_get_param_type (IntPtr raw, int index);

        public TypeInfo GetParamType (int index)
        {
            IntPtr raw_ret = g_type_info_get_param_type (Handle, index);
            TypeInfo ret = MarshalPtr<TypeInfo> (raw_ret);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern TypeTag g_type_info_get_tag (IntPtr raw);

        public TypeTag Tag {
            get {
                return g_type_info_get_tag (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_type_info_is_pointer (IntPtr raw);

        public bool IsPointer {
            get {
                bool raw_ret = g_type_info_is_pointer (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_type_info_is_zero_terminated (IntPtr raw);

        public bool IsZeroTerminated {
            get {
                bool raw_ret = g_type_info_is_zero_terminated (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        public TypeInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
