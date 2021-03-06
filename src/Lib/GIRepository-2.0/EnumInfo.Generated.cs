// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="EnumInfo.xmldoc" path="declaration/member[@name='EnumInfo']/*" />
    public sealed unsafe partial class EnumInfo : GISharp.Lib.GIRepository.RegisteredTypeInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="EnumInfo.xmldoc" path="declaration/member[@name='EnumInfo.ErrorDomain']/*" />
        [GISharp.Runtime.SinceAttribute("1.30")]
        public GISharp.Runtime.UnownedUtf8 ErrorDomain { get => GetErrorDomain(); }

        /// <include file="EnumInfo.xmldoc" path="declaration/member[@name='EnumInfo.NMethods']/*" />
        [GISharp.Runtime.SinceAttribute("1.30")]
        private int NMethods { get => GetNMethods(); }

        /// <include file="EnumInfo.xmldoc" path="declaration/member[@name='EnumInfo.NValues']/*" />
        private int NValues { get => GetNValues(); }

        /// <include file="EnumInfo.xmldoc" path="declaration/member[@name='EnumInfo.StorageType']/*" />
        public GISharp.Lib.GIRepository.TypeTag StorageType { get => GetStorageType(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public EnumInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the string form of the quark for the error domain associated with
        /// this enum, if any.
        /// </summary>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <returns>
        /// the string form of the error domain associated
        /// with this enum, or %NULL.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.30")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_enum_info_get_error_domain(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info);
        partial void CheckGetErrorDomainArgs();

        [GISharp.Runtime.SinceAttribute("1.30")]
        private GISharp.Runtime.UnownedUtf8 GetErrorDomain()
        {
            CheckGetErrorDomainArgs();
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_enum_info_get_error_domain(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain an enum type method at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <param name="n">
        /// index of method to get
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.30")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_enum_info_get_method(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetMethodArgs(int n);

        [GISharp.Runtime.SinceAttribute("1.30")]
        private GISharp.Lib.GIRepository.FunctionInfo GetMethod(int n)
        {
            CheckGetMethodArgs(n);
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_enum_info_get_method(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.FunctionInfo.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the number of methods that this enum type has.
        /// </summary>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <returns>
        /// number of methods
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.30")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_enum_info_get_n_methods(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info);
        partial void CheckGetNMethodsArgs();

        [GISharp.Runtime.SinceAttribute("1.30")]
        private int GetNMethods()
        {
            CheckGetNMethodsArgs();
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_enum_info_get_n_methods(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of values this enumeration contains.
        /// </summary>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <returns>
        /// the number of enumeration values
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_enum_info_get_n_values(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info);
        partial void CheckGetNValuesArgs();

        private int GetNValues()
        {
            CheckGetNValuesArgs();
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_enum_info_get_n_values(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the tag of the type used for the enum in the C ABI. This will
        /// will be a signed or unsigned integral type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that in the current implementation the width of the type is
        /// computed correctly, but the signed or unsigned nature of the type
        /// may not match the sign of the type used by the C compiler.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <returns>
        /// the storage type for the enumeration
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeTag" type="GITypeTag" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.TypeTag g_enum_info_get_storage_type(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info);
        partial void CheckGetStorageTypeArgs();

        private GISharp.Lib.GIRepository.TypeTag GetStorageType()
        {
            CheckGetStorageTypeArgs();
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_enum_info_get_storage_type(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.TypeTag)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain a value for this enumeration.
        /// </summary>
        /// <param name="info">
        /// a #GIEnumInfo
        /// </param>
        /// <param name="n">
        /// index of value to fetch
        /// </param>
        /// <returns>
        /// the enumeration value or %NULL if type tag is wrong,
        /// free the struct with g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ValueInfo" type="GIValueInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.ValueInfo.UnmanagedStruct* g_enum_info_get_value(
        /* <type name="EnumInfo" type="GIEnumInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetValueArgs(int n);

        private GISharp.Lib.GIRepository.ValueInfo GetValue(int n)
        {
            CheckGetValueArgs(n);
            var info_ = (GISharp.Lib.GIRepository.EnumInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_enum_info_get_value(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.ValueInfo.GetInstance<GISharp.Lib.GIRepository.ValueInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}