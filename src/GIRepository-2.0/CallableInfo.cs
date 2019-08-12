// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    public abstract class CallableInfo : BaseInfo
    {
        InfoDictionary<ArgInfo>? args;

        public InfoDictionary<ArgInfo> Args {
            get {
                if (args == null) {
                    args = new InfoDictionary<ArgInfo> (NArgs, GetArg);
                }
                return args;
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_can_throw_gerror(IntPtr raw);

        public bool CanThrowGError {
            get {
                return g_callable_info_can_throw_gerror (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_callable_info_get_arg (IntPtr raw, int index);

        protected ArgInfo GetArg (int index)
        {
            IntPtr raw_ret = g_callable_info_get_arg (Handle, index);
            return GetInstance<ArgInfo>(raw_ret);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Transfer g_callable_info_get_caller_owns (IntPtr raw);

        public Transfer CallerOwns {
            get {
                return g_callable_info_get_caller_owns (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Transfer g_callable_info_get_instance_ownership_transfer (IntPtr raw);

        public Transfer InstanceOwnershipTransfer {
            get {
                return g_callable_info_get_instance_ownership_transfer (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_callable_info_get_n_args (IntPtr raw);

        protected int NArgs {
            get {
                return g_callable_info_get_n_args (Handle);
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_callable_info_get_return_attribute (IntPtr raw, IntPtr name);

        public NullableUnownedUtf8 GetReturnAttribute(UnownedUtf8 name)
        {
            var ret_ = g_callable_info_get_return_attribute(Handle, name.Handle);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_callable_info_get_return_type (IntPtr raw);

        public TypeInfo ReturnTypeInfo {
            get {
                IntPtr raw_ret = g_callable_info_get_return_type (Handle);
                return GetInstance<TypeInfo>(raw_ret);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_invoke(
            IntPtr raw,
            IntPtr function,
            Argument[] inArgs,
            int nInArgs,
            Argument[] outArgs,
            int nOutArgs,
            out Argument returnValue,
            Runtime.Boolean isMethod,
            Runtime.Boolean throws,
            out IntPtr error);

        bool Invoke(IntPtr function, Argument[] inArgs, Argument[] outArgs, out Argument returnValue, bool isMethod, bool throws)
        {
            IntPtr error_;
            bool ret = g_callable_info_invoke (Handle, function, inArgs, (inArgs == null ? 0 : inArgs.Length), outArgs, (outArgs == null ? 0 : outArgs.Length), out returnValue, isMethod, throws, out error_);
            if (error_ != IntPtr.Zero) {
                var error = new Error (error_, Runtime.Transfer.Full);
                throw new GErrorException (error);
            }
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_is_method(IntPtr raw);

        public bool IsMethod {
            get {
                return g_callable_info_is_method (Handle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_iterate_return_attributes(IntPtr raw, ref AttributeIter iterator, out IntPtr name, out IntPtr value);

        bool IterateReturnAttributes(ref AttributeIter iterator, out UnownedUtf8 name, out UnownedUtf8 value)
        {
            var ret = g_callable_info_iterate_return_attributes(Handle, ref iterator, out var name_, out var value_);
            name = ret ? new UnownedUtf8(name_, -1) : default!;
            value = ret ? new UnownedUtf8(value_, -1) : default!;
            return ret;
        }

        public IEnumerable<KeyValuePair<string, string>> ReturnAttributes {
            get {
                var iter = AttributeIter.Zero;
                while (IterateReturnAttributes(ref iter, out var name, out var value)) {
                    yield return new KeyValuePair<string, string> (name, value);
                }
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_callable_info_load_arg (IntPtr raw, int n, IntPtr arg);

        void LoadArg (int n, ArgInfo arg)
        {
            g_callable_info_load_arg (Handle, n, arg == null ? IntPtr.Zero : arg.Handle);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_callable_info_load_return_type (IntPtr raw, IntPtr type);

        void LoadReturnType (TypeInfo type)
        {
            g_callable_info_load_return_type (Handle, type == null ? IntPtr.Zero : type.Handle);
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_may_return_null(IntPtr raw);

        public bool MayReturnNull {
            get {
                return g_callable_info_may_return_null (Handle);
            }
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_callable_info_skip_return(IntPtr raw);

        public bool SkipReturn {
            get {
                return g_callable_info_skip_return (Handle);
            }
        }

        readonly Lazy<InfoDictionary<ArgInfo>> _InArgs;
        public InfoDictionary<ArgInfo> InArgs {
            get { return _InArgs.Value; }
        }

        readonly Lazy<InfoDictionary<ArgInfo>> _OutArgs;
        public InfoDictionary<ArgInfo> OutArgs {
            get { return _OutArgs.Value; }
        }

        protected CallableInfo (IntPtr raw) : base (raw)
        {
            _InArgs = new Lazy<InfoDictionary<ArgInfo>> (() => {
                var inArgs = Args.Where (a => a.Direction != Direction.Out).ToList ();
                return new InfoDictionary<ArgInfo> (inArgs.Count, i => inArgs[i]);
            });
            _OutArgs = new Lazy<InfoDictionary<ArgInfo>> (() => {
                var outArgs = Args.Where (a => a.Direction != Direction.In).ToList ();
                return new InfoDictionary<ArgInfo> (outArgs.Count, i => outArgs[i]);
            });
        }
    }
}