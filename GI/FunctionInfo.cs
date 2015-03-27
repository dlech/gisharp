// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

namespace GI
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

#region Autogenerated code
    public partial class FunctionInfo : GI.CallableInfo
    {

        public bool IsConstructor {
            get {
                return Flags.HasFlag (FunctionInfoFlags.IsConstructor);
            }
        }

        public bool IsGetter {
            get {
                return Flags.HasFlag (FunctionInfoFlags.IsGetter);
            }
        }

        public bool IsSetter {
            get {
                return Flags.HasFlag (FunctionInfoFlags.IsSetter);
            }
        }

        public bool Throws {
            get {
                return Flags.HasFlag (FunctionInfoFlags.Throws);
            }
        }

        public bool WrapsVfunc {
            get {
                return Flags.HasFlag (FunctionInfoFlags.WrapsVfunc);
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_function_info_get_flags (IntPtr raw);

        public GI.FunctionInfoFlags Flags {
            get {
                int raw_ret = g_function_info_get_flags (Handle);
                GI.FunctionInfoFlags ret = (GI.FunctionInfoFlags)raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_function_info_get_property (IntPtr raw);

        public GI.PropertyInfo Property {
            get {
                IntPtr raw_ret = g_function_info_get_property (Handle);
                GI.PropertyInfo ret = MarshalPtr<PropertyInfo> (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_function_info_get_symbol (IntPtr raw);

        public string Symbol {
            get {
                IntPtr raw_ret = g_function_info_get_symbol (Handle);
                string ret = MarshalG.Utf8PtrToString (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_function_info_get_vfunc (IntPtr raw);

        public GI.VFuncInfo VFunc {
            get {
                IntPtr raw_ret = g_function_info_get_vfunc (Handle);
                GI.VFuncInfo ret = MarshalPtr<VFuncInfo> (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern unsafe bool g_function_info_invoke (IntPtr raw, GI.Argument[] in_args, int n_in_args, GI.Argument[] out_args, int n_out_args, IntPtr return_value, out IntPtr error);

        public unsafe bool Invoke (GI.Argument[] in_args, GI.Argument[] out_args, out GI.Argument return_value)
        {
            IntPtr native_return_value = Marshal.AllocHGlobal (Marshal.SizeOf (typeof(GI.Argument)));
            IntPtr error = IntPtr.Zero;
            bool raw_ret = g_function_info_invoke (Handle, in_args, (in_args == null ? 0 : in_args.Length), out_args, (out_args == null ? 0 : out_args.Length), native_return_value, out error);
            bool ret = raw_ret;
            return_value = GI.Argument.New (native_return_value);
            Marshal.FreeHGlobal (native_return_value);
            if (error != IntPtr.Zero)
                throw new GErrorException (error);
            return ret;
        }

        public FunctionInfo (IntPtr raw) : base (raw)
        {
        }

#endregion
    }
}
