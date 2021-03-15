// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="FunctionInfo.xmldoc" path="declaration/member[@name='FunctionInfo']/*" />
    public sealed unsafe partial class FunctionInfo : GISharp.Lib.GIRepository.CallableInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="FunctionInfo.xmldoc" path="declaration/member[@name='FunctionInfo.Flags']/*" />
        public GISharp.Lib.GIRepository.FunctionInfoFlags Flags { get => GetFlags(); }

        /// <include file="FunctionInfo.xmldoc" path="declaration/member[@name='FunctionInfo.Property']/*" />
        public GISharp.Lib.GIRepository.PropertyInfo Property { get => GetProperty(); }

        /// <include file="FunctionInfo.xmldoc" path="declaration/member[@name='FunctionInfo.Symbol']/*" />
        public GISharp.Lib.GLib.UnownedUtf8 Symbol { get => GetSymbol(); }

        /// <include file="FunctionInfo.xmldoc" path="declaration/member[@name='FunctionInfo.VFunc']/*" />
        public GISharp.Lib.GIRepository.VFuncInfo VFunc { get => GetVFunc(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FunctionInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the #GIFunctionInfoFlags for the @info.
        /// </summary>
        /// <param name="info">
        /// a #GIFunctionInfo
        /// </param>
        /// <returns>
        /// the flags
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfoFlags" type="GIFunctionInfoFlags" managed-name="FunctionInfoFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfoFlags g_function_info_get_flags(
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* info);
        partial void CheckGetFlagsArgs();

        private GISharp.Lib.GIRepository.FunctionInfoFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var info_ = (GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_function_info_get_flags(info_);
            var ret = (GISharp.Lib.GIRepository.FunctionInfoFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the property associated with this #GIFunctionInfo.
        /// Only #GIFunctionInfo with the flag %GI_FUNCTION_IS_GETTER or
        /// %GI_FUNCTION_IS_SETTER have a property set. For other cases,
        /// %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GIFunctionInfo
        /// </param>
        /// <returns>
        /// the property or %NULL if not set. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="PropertyInfo" type="GIPropertyInfo*" managed-name="PropertyInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct* g_function_info_get_property(
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* info);
        partial void CheckGetPropertyArgs();

        private GISharp.Lib.GIRepository.PropertyInfo GetProperty()
        {
            CheckGetPropertyArgs();
            var info_ = (GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_function_info_get_property(info_);
            var ret = GISharp.Lib.GIRepository.PropertyInfo.GetInstance<GISharp.Lib.GIRepository.PropertyInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the symbol of the function. The symbol is the name of the
        /// exported function, suitable to be used as an argument to
        /// g_module_symbol().
        /// </summary>
        /// <param name="info">
        /// a #GIFunctionInfo
        /// </param>
        /// <returns>
        /// the symbol
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_function_info_get_symbol(
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* info);
        partial void CheckGetSymbolArgs();

        private GISharp.Lib.GLib.UnownedUtf8 GetSymbol()
        {
            CheckGetSymbolArgs();
            var info_ = (GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_function_info_get_symbol(info_);
            var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain the virtual function associated with this #GIFunctionInfo.
        /// Only #GIFunctionInfo with the flag %GI_FUNCTION_WRAPS_VFUNC has
        /// a virtual function set. For other cases, %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GIFunctionInfo
        /// </param>
        /// <returns>
        /// the virtual function or %NULL if not set.
        /// Free it by calling g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VFuncInfo" type="GIVFuncInfo*" managed-name="VFuncInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* g_function_info_get_vfunc(
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* info);
        partial void CheckGetVFuncArgs();

        private GISharp.Lib.GIRepository.VFuncInfo GetVFunc()
        {
            CheckGetVFuncArgs();
            var info_ = (GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_function_info_get_vfunc(info_);
            var ret = GISharp.Lib.GIRepository.VFuncInfo.GetInstance<GISharp.Lib.GIRepository.VFuncInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}