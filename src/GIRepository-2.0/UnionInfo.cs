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
                if (fields == null) {
                    fields = new InfoDictionary<FieldInfo> (NFields, GetField);
                }
                return fields;
            }
        }

        InfoDictionary<FunctionInfo>? methods;

        public InfoDictionary<FunctionInfo> Methods {
            get {
                if (methods == null) {
                    methods = new InfoDictionary<FunctionInfo> (NMethods, GetMethod);
                }
                return methods;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_find_method (IntPtr raw, IntPtr name);

        public FunctionInfo? FindMethod(UnownedUtf8 name)
        {
            var ret_ = g_union_info_find_method(Handle, name.Handle);
            var ret = GetInstanceOrNull<FunctionInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_union_info_get_alignment (IntPtr raw);

        public ulong Alignment {
            get {
                return (ulong)g_union_info_get_alignment (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_discriminator (IntPtr raw, int index);

        ConstantInfo GetDiscriminator (int index)
        {
            IntPtr raw_ret = g_union_info_get_discriminator (Handle, index);
            return GetInstance<ConstantInfo>(raw_ret);
        }

        public InfoDictionary<ConstantInfo> Discriminators {
            get {
                return new InfoDictionary<ConstantInfo> (IsDiscriminated ? NFields : 0, GetDiscriminator);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_discriminator_offset (IntPtr raw);

        public int DiscriminatorOffset {
            get {
                return g_union_info_get_discriminator_offset (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_discriminator_type (IntPtr raw);

        public TypeInfo DiscriminatorType {
            get {
                IntPtr raw_ret = g_union_info_get_discriminator_type (Handle);
                return GetInstance<TypeInfo>(raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_field (IntPtr raw, int index);

        FieldInfo GetField(int index)
        {
            IntPtr raw_ret = g_union_info_get_field (Handle, index);
            return GetInstance<FieldInfo>(raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_union_info_get_method (IntPtr raw, int index);

        FunctionInfo GetMethod(int index)
        {
            IntPtr raw_ret = g_union_info_get_method (Handle, index);
            return GetInstance<FunctionInfo>(raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_n_fields (IntPtr raw);

        int NFields {
            get {
                int raw_ret = g_union_info_get_n_fields (Handle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_union_info_get_n_methods (IntPtr raw);

        int NMethods {
            get {
                int raw_ret = g_union_info_get_n_methods (Handle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern UIntPtr g_union_info_get_size (IntPtr raw);

        public ulong Size {
            get {
                UIntPtr raw_ret = g_union_info_get_size (Handle);
                var ret = (ulong)raw_ret;
                return ret;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_union_info_is_discriminated(IntPtr raw);

        public bool IsDiscriminated {
            get {
                bool raw_ret = g_union_info_is_discriminated (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        public UnionInfo (IntPtr raw) : base (raw)
        {
        }
    }
}