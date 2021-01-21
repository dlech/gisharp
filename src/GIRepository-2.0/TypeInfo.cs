// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    [DebuggerDisplay("{Tag}")]
    public sealed class TypeInfo : BaseInfo
    {

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_type_info_get_array_fixed_size(IntPtr raw);

        public int ArrayFixedSize {
            get {
                int raw_ret = g_type_info_get_array_fixed_size(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_type_info_get_array_length(IntPtr raw);

        public int ArrayLengthIndex {
            get {
                int raw_ret = g_type_info_get_array_length(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern ArrayType g_type_info_get_array_type(IntPtr raw);

        public ArrayType ArrayType {
            get {
                if (Tag != TypeTag.Array) {
                    return ArrayType.None;
                }
                return g_type_info_get_array_type(UnsafeHandle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_info_get_interface(IntPtr raw);

        public BaseInfo? Interface {
            get {
                var ret_ = g_type_info_get_interface(UnsafeHandle);
                var ret = GetInstanceOrNull<BaseInfo>(ret_);
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_type_info_get_param_type(IntPtr raw, int index);

        public TypeInfo GetParamType(int index)
        {
            IntPtr raw_ret = g_type_info_get_param_type(UnsafeHandle, index);
            TypeInfo ret = GetInstance<TypeInfo>(raw_ret);
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern TypeTag g_type_info_get_tag(IntPtr raw);

        public TypeTag Tag {
            get {
                return g_type_info_get_tag(UnsafeHandle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_type_info_is_pointer(IntPtr raw);

        public bool IsPointer {
            get {
                var ret_ = g_type_info_is_pointer(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_type_info_is_zero_terminated(IntPtr raw);

        public bool IsZeroTerminated {
            get {
                var ret_ = g_type_info_is_zero_terminated(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        public TypeInfo(IntPtr raw) : base(raw)
        {
        }
    }
}
