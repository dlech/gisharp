// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

// This file was generated by the Gtk# code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Struct representing a union.
    /// </summary>
    public sealed class UnionInfo : RegisteredTypeInfo, IMethodContainer
    {
        InfoDictionary<FieldInfo>? fields;

        public InfoDictionary<FieldInfo> Fields {
            get {
                if (fields is null) {
                    fields = new(NFields, GetField);
                }
                return fields;
            }
        }

        InfoDictionary<FunctionInfo>? methods;

        public InfoDictionary<FunctionInfo> Methods {
            get {
                if (methods is null) {
                    methods = new(NMethods, GetMethod);
                }
                return methods;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_find_method(IntPtr raw, IntPtr name);

        public FunctionInfo? FindMethod(UnownedUtf8 name)
        {
            var ret_ = g_union_info_find_method(UnsafeHandle, name.UnsafeHandle);
            var ret = GetInstanceOrNull<FunctionInfo>(ret_);
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_union_info_get_alignment(IntPtr raw);

        public ulong Alignment {
            get {
                return (ulong)g_union_info_get_alignment(UnsafeHandle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_discriminator(IntPtr raw, int index);

        ConstantInfo GetDiscriminator(int index)
        {
            IntPtr raw_ret = g_union_info_get_discriminator(UnsafeHandle, index);
            return GetInstance<ConstantInfo>(raw_ret);
        }

        public InfoDictionary<ConstantInfo> Discriminators {
            get {
                return new InfoDictionary<ConstantInfo>(IsDiscriminated ? NFields : 0, GetDiscriminator);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_discriminator_offset(IntPtr raw);

        public int DiscriminatorOffset {
            get {
                return g_union_info_get_discriminator_offset(UnsafeHandle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_discriminator_type(IntPtr raw);

        public TypeInfo DiscriminatorType {
            get {
                IntPtr raw_ret = g_union_info_get_discriminator_type(UnsafeHandle);
                return GetInstance<TypeInfo>(raw_ret);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_field(IntPtr raw, int index);

        FieldInfo GetField(int index)
        {
            IntPtr raw_ret = g_union_info_get_field(UnsafeHandle, index);
            return GetInstance<FieldInfo>(raw_ret);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_method(IntPtr raw, int index);

        FunctionInfo GetMethod(int index)
        {
            IntPtr raw_ret = g_union_info_get_method(UnsafeHandle, index);
            return GetInstance<FunctionInfo>(raw_ret);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_n_fields(IntPtr raw);

        int NFields {
            get {
                int raw_ret = g_union_info_get_n_fields(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_n_methods(IntPtr raw);

        int NMethods {
            get {
                int raw_ret = g_union_info_get_n_methods(UnsafeHandle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_union_info_get_size(IntPtr raw);

        public ulong Size {
            get {
                UIntPtr raw_ret = g_union_info_get_size(UnsafeHandle);
                var ret = (ulong)raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_union_info_is_discriminated(IntPtr raw);

        public bool IsDiscriminated {
            get {
                var ret_ = g_union_info_is_discriminated(UnsafeHandle);
                var ret = ret_.IsTrue();
                return ret;
            }
        }

        public UnionInfo(IntPtr raw) : base(raw)
        {
        }
    }
}
