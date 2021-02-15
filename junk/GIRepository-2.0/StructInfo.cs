// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    public sealed class StructInfo : RegisteredTypeInfo, IMethodContainer
    {

        InfoDictionary<FieldInfo>? fields;

        public InfoDictionary<FieldInfo> Fields {
            get {
                if (fields is null) {
                    fields = new InfoDictionary<FieldInfo>(NFields, GetField);
                }
                return fields;
            }
        }

        InfoDictionary<FunctionInfo>? methods;

        public InfoDictionary<FunctionInfo> Methods {
            get {
                if (methods is null) {
                    methods = new InfoDictionary<FunctionInfo>(NMethods, GetMethod);
                }
                return methods;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_struct_info_find_method(IntPtr raw, IntPtr name);

        /// <summary>
        /// Finds the method.
        /// </summary>
        /// <returns>The method.</returns>
        /// <param name="name">Name.</param>
        /// <remarks>
        /// This seems to be unreliable. It causes a crash when struct is GObject.ObjectClass
        /// and cannot find methods in GObject.Closure
        /// </remarks>
        [Obsolete("Not really obsolete, but unreliable.")]
        public FunctionInfo? FindMethod(UnownedUtf8 name)
        {
            var ret_ = g_struct_info_find_method(UnsafeHandle, name.UnsafeHandle);
            var ret = GetInstanceOrNull<FunctionInfo>(ret_);
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_struct_info_get_alignment(IntPtr raw);

        public ulong Alignment {
            get {
                return (ulong)g_struct_info_get_alignment(UnsafeHandle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_struct_info_get_field(IntPtr raw, int index);

        FieldInfo GetField(int index)
        {
            IntPtr raw_ret = g_struct_info_get_field(UnsafeHandle, index);
            return GetInstance<FieldInfo>(raw_ret);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_struct_info_get_method(IntPtr raw, int index);

        FunctionInfo GetMethod(int index)
        {
            IntPtr raw_ret = g_struct_info_get_method(UnsafeHandle, index);
            return GetInstance<FunctionInfo>(raw_ret);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_struct_info_get_n_fields(IntPtr raw);

        int NFields {
            get {
                int raw_ret = g_struct_info_get_n_fields(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_struct_info_get_n_methods(IntPtr raw);

        int NMethods {
            get {
                int raw_ret = g_struct_info_get_n_methods(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_struct_info_get_size(IntPtr raw);

        public ulong Size {
            get {
                UIntPtr raw_ret = g_struct_info_get_size(UnsafeHandle);
                var ret = (ulong)raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_struct_info_is_foreign(IntPtr raw);

        public bool IsForeign {
            get {
                var ret_ = g_struct_info_is_foreign(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_struct_info_is_gtype_struct(IntPtr raw);

        public bool IsGTypeStruct {
            get {
                var ret_ = g_struct_info_is_gtype_struct(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        public StructInfo(IntPtr raw) : base(raw)
        {
        }
    }
}