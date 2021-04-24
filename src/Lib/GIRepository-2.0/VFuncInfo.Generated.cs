// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo']/*" />
    public sealed unsafe partial class VFuncInfo : GISharp.Lib.GIRepository.CallableInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo.Flags']/*" />
        public GISharp.Lib.GIRepository.VFuncInfoFlags Flags { get => GetFlags(); }

        /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo.Invoker']/*" />
        public GISharp.Lib.GIRepository.FunctionInfo Invoker { get => GetInvoker(); }

        /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo.Offset']/*" />
        public int Offset { get => GetOffset(); }

        /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo.Signal']/*" />
        public GISharp.Lib.GIRepository.SignalInfo Signal { get => GetSignal(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VFuncInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// This method will look up where inside the type struct of @implementor_gtype
        /// is the implementation for @info.
        /// </summary>
        /// <param name="info">
        /// a #GIVFuncInfo
        /// </param>
        /// <param name="implementorGtype">
        /// #GType implementing this virtual function
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// address to a function or %NULL if an error happened
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern System.IntPtr g_vfunc_info_get_address(
        /* <type name="VFuncInfo" type="GIVFuncInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* info,
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.GType implementorGtype,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        partial void CheckGetAddressArgs(GISharp.Runtime.GType implementorGtype);

        /// <include file="VFuncInfo.xmldoc" path="declaration/member[@name='VFuncInfo.GetAddress(GISharp.Runtime.GType)']/*" />
        public System.IntPtr GetAddress(GISharp.Runtime.GType implementorGtype)
        {
            CheckGetAddressArgs(implementorGtype);
            var info_ = (GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct*)UnsafeHandle;
            var implementorGtype_ = (GISharp.Runtime.GType)implementorGtype;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_vfunc_info_get_address(info_,implementorGtype_,&error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            var ret = (System.IntPtr)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the flags for this virtual function info. See #GIVFuncInfoFlags for
        /// more information about possible flag values.
        /// </summary>
        /// <param name="info">
        /// a #GIVFuncInfo
        /// </param>
        /// <returns>
        /// the flags
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VFuncInfoFlags" type="GIVFuncInfoFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.VFuncInfoFlags g_vfunc_info_get_flags(
        /* <type name="VFuncInfo" type="GIVFuncInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* info);
        partial void CheckGetFlagsArgs();

        private GISharp.Lib.GIRepository.VFuncInfoFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var info_ = (GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_vfunc_info_get_flags(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.VFuncInfoFlags)ret_;
            return ret;
        }

        /// <summary>
        /// If this virtual function has an associated invoker method, this
        /// method will return it.  An invoker method is a C entry point.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Not all virtuals will have invokers.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GIVFuncInfo
        /// </param>
        /// <returns>
        /// the #GIVFuncInfo or %NULL. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_vfunc_info_get_invoker(
        /* <type name="VFuncInfo" type="GIVFuncInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* info);
        partial void CheckGetInvokerArgs();

        private GISharp.Lib.GIRepository.FunctionInfo GetInvoker()
        {
            CheckGetInvokerArgs();
            var info_ = (GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_vfunc_info_get_invoker(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.FunctionInfo.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the offset of the function pointer in the class struct. The value
        /// 0xFFFF indicates that the struct offset is unknown.
        /// </summary>
        /// <param name="info">
        /// a #GIVFuncInfo
        /// </param>
        /// <returns>
        /// the struct offset or 0xFFFF if it's unknown
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_vfunc_info_get_offset(
        /* <type name="VFuncInfo" type="GIVFuncInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* info);
        partial void CheckGetOffsetArgs();

        private int GetOffset()
        {
            CheckGetOffsetArgs();
            var info_ = (GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_vfunc_info_get_offset(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the signal for the virtual function if one is set.
        /// The signal comes from the object or interface to which
        /// this virtual function belongs.
        /// </summary>
        /// <param name="info">
        /// a #GIVFuncInfo
        /// </param>
        /// <returns>
        /// the signal or %NULL if none set
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SignalInfo" type="GISignalInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* g_vfunc_info_get_signal(
        /* <type name="VFuncInfo" type="GIVFuncInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* info);
        partial void CheckGetSignalArgs();

        private GISharp.Lib.GIRepository.SignalInfo GetSignal()
        {
            CheckGetSignalArgs();
            var info_ = (GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_vfunc_info_get_signal(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.SignalInfo.GetInstance<GISharp.Lib.GIRepository.SignalInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}