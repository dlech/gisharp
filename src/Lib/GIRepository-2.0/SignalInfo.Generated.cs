// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="SignalInfo.xmldoc" path="declaration/member[@name='SignalInfo']/*" />
    public sealed unsafe partial class SignalInfo : GISharp.Lib.GIRepository.CallableInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="SignalInfo.xmldoc" path="declaration/member[@name='SignalInfo.ClassClosure']/*" />
        public GISharp.Lib.GIRepository.VFuncInfo ClassClosure { get => GetClassClosure(); }

        /// <include file="SignalInfo.xmldoc" path="declaration/member[@name='SignalInfo.Flags']/*" />
        public GISharp.Lib.GObject.SignalFlags Flags { get => GetFlags(); }

        /// <include file="SignalInfo.xmldoc" path="declaration/member[@name='SignalInfo.TrueStopsEmit']/*" />
        public bool TrueStopsEmit { get => GetTrueStopsEmit(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SignalInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the class closure for this signal if one is set. The class
        /// closure is a virtual function on the type that the signal belongs to.
        /// If the signal lacks a closure %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GISignalInfo
        /// </param>
        /// <returns>
        /// the class closure or %NULL
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VFuncInfo" type="GIVFuncInfo*" managed-name="VFuncInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* g_signal_info_get_class_closure(
        /* <type name="SignalInfo" type="GISignalInfo*" managed-name="SignalInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* info);
        partial void CheckGetClassClosureArgs();

        private GISharp.Lib.GIRepository.VFuncInfo GetClassClosure()
        {
            CheckGetClassClosureArgs();
            var info_ = (GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_signal_info_get_class_closure(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.VFuncInfo.GetInstance<GISharp.Lib.GIRepository.VFuncInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the flags for this signal info. See #GSignalFlags for
        /// more information about possible flag values.
        /// </summary>
        /// <param name="info">
        /// a #GISignalInfo
        /// </param>
        /// <returns>
        /// the flags
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.SignalFlags" type="GSignalFlags" managed-name="GISharp.Lib.GObject.SignalFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.SignalFlags g_signal_info_get_flags(
        /* <type name="SignalInfo" type="GISignalInfo*" managed-name="SignalInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* info);
        partial void CheckGetFlagsArgs();

        private GISharp.Lib.GObject.SignalFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var info_ = (GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_signal_info_get_flags(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GObject.SignalFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain if the returning true in the signal handler will
        /// stop the emission of the signal.
        /// </summary>
        /// <param name="info">
        /// a #GISignalInfo
        /// </param>
        /// <returns>
        /// %TRUE if returning true stops the signal emission
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_signal_info_true_stops_emit(
        /* <type name="SignalInfo" type="GISignalInfo*" managed-name="SignalInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* info);
        partial void CheckGetTrueStopsEmitArgs();

        private bool GetTrueStopsEmit()
        {
            CheckGetTrueStopsEmitArgs();
            var info_ = (GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_signal_info_true_stops_emit(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}