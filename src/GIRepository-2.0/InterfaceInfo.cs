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
    public sealed class InterfaceInfo : RegisteredTypeInfo, IMethodContainer
    {

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_find_method (IntPtr raw, IntPtr name);

        public FunctionInfo? FindMethod(UnownedUtf8 name)
        {
            var ret_ = g_interface_info_find_method(Handle, name.Handle);
            var ret = GetInstanceOrNull<FunctionInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_find_signal (IntPtr raw, IntPtr name);

        public SignalInfo? FindSignal(UnownedUtf8 name)
        {
            var ret_ = g_interface_info_find_signal(Handle, name.Handle);
            var ret = GetInstanceOrNull<SignalInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_find_vfunc (IntPtr raw, IntPtr name);

        public VFuncInfo? FindVFunc(UnownedUtf8 name)
        {
            var ret_ = g_interface_info_find_vfunc(Handle, name.Handle);
            var ret = GetInstanceOrNull<VFuncInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_constant (IntPtr raw, int index);

        ConstantInfo GetConstant (int index)
        {
            IntPtr raw_ret = g_interface_info_get_constant (Handle, index);
            return GetInstance<ConstantInfo>(raw_ret);
        }

        public InfoDictionary<ConstantInfo> Constants {
            get {
                return new InfoDictionary<ConstantInfo> (NConstants, GetConstant);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_iface_struct (IntPtr raw);

        public StructInfo IfaceStruct {
            get {
                IntPtr raw_ret = g_interface_info_get_iface_struct (Handle);
                return GetInstance<StructInfo>(raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_method (IntPtr raw, int index);

        FunctionInfo GetMethod (int index)
        {
            IntPtr raw_ret = g_interface_info_get_method (Handle, index);
            return GetInstance<FunctionInfo>(raw_ret);
        }

        public InfoDictionary<FunctionInfo> Methods {
            get {
                return new InfoDictionary<FunctionInfo> (NMethods, GetMethod);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_constants (IntPtr raw);

        int NConstants {
            get {
                return g_interface_info_get_n_constants (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_methods (IntPtr raw);

        int NMethods {
            get {
                return g_interface_info_get_n_methods (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_prerequisites (IntPtr raw);

        int NPrerequisites {
            get {
                return g_interface_info_get_n_prerequisites (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_properties (IntPtr raw);

        int NProperties {
            get {
                return g_interface_info_get_n_properties (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_signals (IntPtr raw);

        int NSignals {
            get {
                return g_interface_info_get_n_signals (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_interface_info_get_n_vfuncs (IntPtr raw);

        int NVFuncs {
            get {
                return g_interface_info_get_n_vfuncs (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_prerequisite (IntPtr raw, int index);

        BaseInfo GetPrerequisite (int index)
        {
            IntPtr raw_ret = g_interface_info_get_prerequisite (Handle, index);
            return GetInstance<BaseInfo>(raw_ret);
        }

        public InfoDictionary<BaseInfo> Prerequisites {
            get {
                return new InfoDictionary<BaseInfo> (NPrerequisites, GetPrerequisite);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_property (IntPtr raw, int index);

        PropertyInfo GetProperty (int index)
        {
            IntPtr raw_ret = g_interface_info_get_property (Handle, index);
            return GetInstance<PropertyInfo>(raw_ret);
        }

        public InfoDictionary<PropertyInfo> Properties {
            get {
                return new InfoDictionary<PropertyInfo> (NProperties, GetProperty);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_signal (IntPtr raw, int index);

        SignalInfo GetSignal (int index)
        {
            IntPtr raw_ret = g_interface_info_get_signal (Handle, index);
            return GetInstance<SignalInfo>(raw_ret);
        }

        public InfoDictionary<SignalInfo> Signals {
            get {
                return new InfoDictionary<SignalInfo> (NSignals, GetSignal);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_interface_info_get_vfunc (IntPtr raw, int index);

        VFuncInfo GetVFunc (int index)
        {
            IntPtr raw_ret = g_interface_info_get_vfunc (Handle, index);
            return GetInstance<VFuncInfo>(raw_ret);
        }

        public InfoDictionary<VFuncInfo> VFuncs {
            get {
                return new InfoDictionary<VFuncInfo> (NVFuncs, GetVFunc);
            }
        }

        public InterfaceInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
