// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="PropertyInfo.xmldoc" path="declaration/member[@name='PropertyInfo']/*" />
    public unsafe partial class PropertyInfo : GISharp.Lib.GIRepository.BaseInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="PropertyInfo.xmldoc" path="declaration/member[@name='PropertyInfo.Flags']/*" />
        public GISharp.Lib.GObject.ParamFlags Flags { get => GetFlags(); }

        /// <include file="PropertyInfo.xmldoc" path="declaration/member[@name='PropertyInfo.OwnershipTransfer']/*" />
        public GISharp.Lib.GIRepository.Transfer OwnershipTransfer { get => GetOwnershipTransfer(); }

        /// <include file="PropertyInfo.xmldoc" path="declaration/member[@name='PropertyInfo.Type']/*" />
        public GISharp.Lib.GIRepository.TypeInfo Type { get => GetType_(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public PropertyInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the flags for this property info. See #GParamFlags for
        /// more information about possible flag values.
        /// </summary>
        /// <param name="info">
        /// a #GIPropertyInfo
        /// </param>
        /// <returns>
        /// the flags
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.ParamFlags" type="GParamFlags" managed-name="GISharp.Lib.GObject.ParamFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamFlags g_property_info_get_flags(
        /* <type name="PropertyInfo" type="GIPropertyInfo*" managed-name="PropertyInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct* info);
        partial void CheckGetFlagsArgs();

        private GISharp.Lib.GObject.ParamFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var info_ = (GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_property_info_get_flags(info_);
            var ret = (GISharp.Lib.GObject.ParamFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the ownership transfer for this property. See #GITransfer for more
        /// information about transfer values.
        /// </summary>
        /// <param name="info">
        /// a #GIPropertyInfo
        /// </param>
        /// <returns>
        /// the transfer
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Transfer" type="GITransfer" managed-name="Transfer" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.Transfer g_property_info_get_ownership_transfer(
        /* <type name="PropertyInfo" type="GIPropertyInfo*" managed-name="PropertyInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct* info);
        partial void CheckGetOwnershipTransferArgs();

        private GISharp.Lib.GIRepository.Transfer GetOwnershipTransfer()
        {
            CheckGetOwnershipTransferArgs();
            var info_ = (GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_property_info_get_ownership_transfer(info_);
            var ret = (GISharp.Lib.GIRepository.Transfer)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for the property @info.
        /// </summary>
        /// <param name="info">
        /// a #GIPropertyInfo
        /// </param>
        /// <returns>
        /// the #GITypeInfo, free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" managed-name="TypeInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_property_info_get_type(
        /* <type name="PropertyInfo" type="GIPropertyInfo*" managed-name="PropertyInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct* info);
        partial void CheckGetType_Args();

        private GISharp.Lib.GIRepository.TypeInfo GetType_()
        {
            CheckGetType_Args();
            var info_ = (GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_property_info_get_type(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}