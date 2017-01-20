// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

using GISharp.GIRepository.Dynamic;
using GISharp.Runtime;

namespace GISharp.GIRepository
{
    public sealed class ObjectInfo : RegisteredTypeInfo, IMethodContainer, IDynamicMetaObjectProvider
    {
        InfoDictionary<ConstantInfo> constants;

        public InfoDictionary<ConstantInfo> Constants {
            get {
                if (constants == null) {
                    constants = new InfoDictionary<ConstantInfo> (NConstants, GetConstant);
                }
                return constants;
            }
        }

        InfoDictionary<FieldInfo> fields;

        public InfoDictionary<FieldInfo> Fields {
            get {
                if (fields == null) {
                    fields = new InfoDictionary<FieldInfo> (NFields, GetField);
                }
                return fields;
            }
        }

        InfoDictionary<InterfaceInfo> interfaces;

        public InfoDictionary<InterfaceInfo> Interfaces {
            get {
                if (interfaces == null) {
                    interfaces = new InfoDictionary<InterfaceInfo> (NInterfaces, GetInterface);
                }
                return interfaces;
            }
        }

        InfoDictionary<FunctionInfo> methods;

        public InfoDictionary<FunctionInfo> Methods {
            get {
                if (methods == null) {
                    methods = new InfoDictionary<FunctionInfo> (NMethods, GetMethod);
                }
                return methods;
            }
        }

        InfoDictionary<PropertyInfo> properties;

        public InfoDictionary<PropertyInfo> Properties {
            get {
                if (properties == null) {
                    properties = new InfoDictionary<PropertyInfo> (NProperties, GetProperty);
                }
                return properties;
            }
        }

        InfoDictionary<SignalInfo> signals;

        public InfoDictionary<SignalInfo> Signals {
            get {
                if (signals == null) {
                    signals = new InfoDictionary<SignalInfo> (NSignals, GetSignal);
                }
                return signals;
            }
        }

        InfoDictionary<VFuncInfo> vFuncs;

        public InfoDictionary<VFuncInfo> VFuncs {
            get {
                if (vFuncs == null) {
                    vFuncs = new InfoDictionary<VFuncInfo> (NVfuncs, GetVFunc);
                }
                return vFuncs;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_find_method (IntPtr raw, IntPtr name);

        public FunctionInfo FindMethod (string name)
        {
            IntPtr native_name = GMarshal.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_object_info_find_method (Handle, native_name);
            var ret = MarshalPtr<FunctionInfo> (raw_ret);
            GMarshal.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_find_method_using_interfaces (IntPtr raw, IntPtr name, IntPtr implementor);

        public FunctionInfo FindMethodUsingInterfaces (string name, ObjectInfo implementor)
        {
            IntPtr native_name = GMarshal.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_object_info_find_method_using_interfaces (Handle, native_name, implementor == null ? IntPtr.Zero : implementor.Handle);
            var ret = MarshalPtr<FunctionInfo> (raw_ret);
            GMarshal.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_find_signal (IntPtr raw, IntPtr name);

        public SignalInfo FindSignal (string name)
        {
            IntPtr native_name = GMarshal.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_object_info_find_signal (Handle, native_name);
            var ret = MarshalPtr<SignalInfo> (raw_ret);
            GMarshal.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_find_vfunc (IntPtr raw, IntPtr name);

        public VFuncInfo FindVFunc (string name)
        {
            IntPtr native_name = GMarshal.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_object_info_find_vfunc (Handle, native_name);
            var ret = MarshalPtr<VFuncInfo> (raw_ret);
            GMarshal.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_find_vfunc_using_interfaces (IntPtr raw, IntPtr name, IntPtr implementor);

        public VFuncInfo FindVFuncUsingInterfaces (string name, ObjectInfo implementor)
        {
            IntPtr native_name = GMarshal.StringToUtf8Ptr (name);
            IntPtr raw_ret = g_object_info_find_vfunc_using_interfaces (Handle, native_name, implementor == null ? IntPtr.Zero : implementor.Handle);
            var ret = MarshalPtr<VFuncInfo> (raw_ret);
            GMarshal.Free (native_name);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_object_info_get_abstract (IntPtr raw);

        public bool Abstract {
            get {
                bool raw_ret = g_object_info_get_abstract (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_class_struct (IntPtr raw);

        public StructInfo ClassStruct {
            get {
                IntPtr raw_ret = g_object_info_get_class_struct (Handle);
                return MarshalPtr<StructInfo> (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_constant (IntPtr raw, int index);

        ConstantInfo GetConstant (int index)
        {
            IntPtr raw_ret = g_object_info_get_constant (Handle, index);
            return MarshalPtr<ConstantInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_field (IntPtr raw, int index);

        FieldInfo GetField (int index)
        {
            IntPtr raw_ret = g_object_info_get_field (Handle, index);
            return MarshalPtr<FieldInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern bool g_object_info_get_fundamental (IntPtr raw);

        public bool Fundamental {
            get {
                bool raw_ret = g_object_info_get_fundamental (Handle);
                bool ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_get_value_function (IntPtr raw);

        public string GetValueFunctionName {
            get {
                IntPtr raw_ret = g_object_info_get_get_value_function (Handle);
                string ret = GMarshal.Utf8PtrToString (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_interface (IntPtr raw, int index);

        InterfaceInfo GetInterface (int index)
        {
            IntPtr raw_ret = g_object_info_get_interface (Handle, index);
            return MarshalPtr<InterfaceInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_method (IntPtr raw, int index);

        FunctionInfo GetMethod (int index)
        {
            IntPtr raw_ret = g_object_info_get_method (Handle, index);
            return MarshalPtr<FunctionInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_constants (IntPtr raw);

        int NConstants {
            get {
                return g_object_info_get_n_constants (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_fields (IntPtr raw);

        int NFields {
            get {
                return g_object_info_get_n_fields (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_interfaces (IntPtr raw);

        int NInterfaces {
            get {
                return g_object_info_get_n_interfaces (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_methods (IntPtr raw);

        int NMethods {
            get {
                return g_object_info_get_n_methods (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_properties (IntPtr raw);

        int NProperties {
            get {
                return g_object_info_get_n_properties (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_signals (IntPtr raw);

        int NSignals {
            get {
                return g_object_info_get_n_signals (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_object_info_get_n_vfuncs (IntPtr raw);

        int NVfuncs {
            get {
                return g_object_info_get_n_vfuncs (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_parent (IntPtr raw);

        public ObjectInfo Parent {
            get {
                IntPtr raw_ret = g_object_info_get_parent (Handle);
                return MarshalPtr<ObjectInfo> (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_property (IntPtr raw, int index);

        PropertyInfo GetProperty (int index)
        {
            IntPtr raw_ret = g_object_info_get_property (Handle, index);
            return MarshalPtr<PropertyInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_ref_function (IntPtr raw);

        public string RefFunctionName {
            get {
                IntPtr raw_ret = g_object_info_get_ref_function (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_set_value_function (IntPtr raw);

        public string SetValueFunctionName {
            get {
                IntPtr raw_ret = g_object_info_get_set_value_function (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_signal (IntPtr raw, int index);

        SignalInfo GetSignal (int index)
        {
            IntPtr raw_ret = g_object_info_get_signal (Handle, index);
            return MarshalPtr<SignalInfo> (raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_type_init (IntPtr raw);

        public new string TypeInit {
            get {
                IntPtr raw_ret = g_object_info_get_type_init (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_type_name (IntPtr raw);

        public new string TypeName {
            get {
                IntPtr raw_ret = g_object_info_get_type_name (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_unref_function (IntPtr raw);

        public string UnrefFunctionName {
            get {
                IntPtr raw_ret = g_object_info_get_unref_function (Handle);
                return GMarshal.Utf8PtrToString (raw_ret);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_info_get_vfunc (IntPtr raw, int index);

        VFuncInfo GetVFunc (int index)
        {
            IntPtr raw_ret = g_object_info_get_vfunc (Handle, index);
            return MarshalPtr<VFuncInfo> (raw_ret);
        }

        public DynamicMetaObject GetMetaObject (Expression parameter)
        {
            return new ObjectInfoDynamicMetaObject (parameter, this);
        }

        public ObjectInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
