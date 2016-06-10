// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;

namespace GISharp.GIRepository
{
    public sealed class ConstantInfo : BaseInfo
    {
        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_constant_info_free_value (IntPtr raw, ref Argument value);

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_constant_info_get_type (IntPtr raw);

        public TypeInfo TypeInfo {
            get {
                IntPtr raw_ret = g_constant_info_get_type (Handle);
                return MarshalPtr<TypeInfo> (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_constant_info_get_value (IntPtr raw, out Argument value);

        public object Value {
            get {
                Argument value;
                g_constant_info_get_value (Handle, out value);
                object result;
                switch (TypeInfo.Tag) {
                case TypeTag.Boolean:
                    result = value.Boolean;
                    break;
                case TypeTag.Double:
                    result = value.Double;
                    break;
                case TypeTag.Float:
                    result = value.Float;
                    break;
                case TypeTag.Int8:
                    result = value.Int8;
                    break;
                case TypeTag.Int16:
                    result = value.Int16;
                    break;
                case TypeTag.Int32:
                    result = value.Int32;
                    break;
                case TypeTag.Int64:
                    result = value.Int64;
                    break;
                case TypeTag.UInt8:
                    result = value.UInt8;
                    break;
                case TypeTag.UInt16:
                    result = value.UInt16;
                    break;
                case TypeTag.UInt32:
                    result = value.UInt32;
                    break;
                case TypeTag.UInt64:
                    result = value.UInt64;
                    break;
                case TypeTag.UTF8:
                    result = value.String;
                    break;
                default:
                    throw new Exception ($"Unexpected value type '{TypeInfo.Tag}'");
                }
                g_constant_info_free_value (Handle, ref value);

                return result;
            }
        }

        public ConstantInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
