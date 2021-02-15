// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="ConstantInfo.xmldoc" path="declaration/member[@name='ConstantInfo']/*" />
    public sealed unsafe partial class ConstantInfo : GISharp.Lib.GIRepository.BaseInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="ConstantInfo.xmldoc" path="declaration/member[@name='ConstantInfo.Type']/*" />
        public GISharp.Lib.GIRepository.TypeInfo Type { get => GetType_(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ConstantInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the type of the constant as a #GITypeInfo.
        /// </summary>
        /// <param name="info">
        /// a #GIConstantInfo
        /// </param>
        /// <returns>
        /// the #GITypeInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" managed-name="TypeInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_constant_info_get_type(
        /* <type name="ConstantInfo" type="GIConstantInfo*" managed-name="ConstantInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.ConstantInfo.UnmanagedStruct* info);
        partial void CheckGetType_Args();

        private GISharp.Lib.GIRepository.TypeInfo GetType_()
        {
            CheckGetType_Args();
            var info_ = (GISharp.Lib.GIRepository.ConstantInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_constant_info_get_type(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}