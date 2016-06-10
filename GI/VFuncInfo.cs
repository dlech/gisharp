// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Runtime.InteropServices;

namespace GISharp.GIRepository
{
    /// <summary>
    /// Represents a virtual function.
    /// </summary>
    public sealed class VFuncInfo : CallableInfo
    {
        /// <summary>
        /// Indicates that the struct offset is unknown.
        /// </summary>
        public int UnknownOffset = 0xFFFF;

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_vfunc_info_get_flags (IntPtr raw);

        /// <summary>
        /// Obtain the flags for this virtual function info.
        /// </summary>
        /// <value>The flags.</value>
        public VFuncInfoFlags Flags {
            get {
                int raw_ret = g_vfunc_info_get_flags (Handle);
                var ret = (VFuncInfoFlags)raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_vfunc_info_get_invoker (IntPtr raw);

        /// <summary>
        /// If this virtual function has an associated invoker method, this method will return it.
        /// </summary>
        /// <value>The invoker or <c>null</c>.</value>
        /// <remarks>
        /// Not all virtuals will have invokers.
        /// </remarks>
        public FunctionInfo Invoker {
            get {
                IntPtr raw_ret = g_vfunc_info_get_invoker (Handle);
                FunctionInfo ret = MarshalPtr<FunctionInfo> (raw_ret);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_vfunc_info_get_offset (IntPtr raw);

        /// <summary>
        /// Obtain the offset of the function pointer in the class struct.
        /// </summary>
        /// <value>The offset or <see cref="UnknownOffset"/>.</value>
        /// <remarks>
        /// The value 0xFFFF indicates that the struct offset is unknown.
        /// </remarks>
        public int Offset {
            get {
                int raw_ret = g_vfunc_info_get_offset (Handle);
                int ret = raw_ret;
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_vfunc_info_get_signal (IntPtr raw);

        /// <summary>
        /// Obtain the signal for the virtual function if one is set.
        /// </summary>
        /// <value>The signal or <c>null</c> if none set.</value>
        /// <remarks>
        /// The signal comes from the object or interface to which this virtual function belongs.
        /// </remarks>
        public SignalInfo Signal {
            get {
                IntPtr raw_ret = g_vfunc_info_get_signal (Handle);
                SignalInfo ret = MarshalPtr<SignalInfo> (raw_ret);
                return ret;
            }
        }

        public VFuncInfo (IntPtr raw) : base (raw)
        {
        }
    }
}
