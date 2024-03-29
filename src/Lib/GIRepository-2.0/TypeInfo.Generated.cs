// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo']/*" />
    public sealed unsafe partial class TypeInfo : GISharp.Lib.GIRepository.BaseInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ArrayFixedSize']/*" />
        public int ArrayFixedSize { get => GetArrayFixedSize(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ArrayLength']/*" />
        public int ArrayLength { get => GetArrayLength(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ArrayType']/*" />
        public GISharp.Lib.GIRepository.ArrayType ArrayType { get => GetArrayType(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.Interface']/*" />
        public GISharp.Lib.GIRepository.BaseInfo Interface { get => GetInterface(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.StorageType']/*" />
        [GISharp.Runtime.SinceAttribute("1.66")]
        public GISharp.Lib.GIRepository.TypeTag StorageType { get => GetStorageType(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.Tag']/*" />
        public GISharp.Lib.GIRepository.TypeTag Tag { get => GetTag(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.IsPointer']/*" />
        public bool IsPointer { get => GetIsPointer(); }

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.IsZeroTerminated']/*" />
        public bool IsZeroTerminated { get => GetIsZeroTerminated(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public TypeInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// GLib data structures, such as #GList, #GSList, and #GHashTable, all store
        /// data pointers.
        /// In the case where the list or hash table is storing single types rather than
        /// structs, these data pointers may have values stuffed into them via macros
        /// such as %GPOINTER_TO_INT.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use this function to ensure that all values are correctly extracted from
        /// stuffed pointers, regardless of the machine's architecture or endianness.
        /// </para>
        /// <para>
        /// This function fills in the appropriate field of @arg with the value extracted
        /// from @hash_pointer, depending on the storage type of @info.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <param name="hashPointer">
        /// A pointer, such as a #GHashTable data pointer
        /// </param>
        /// <param name="arg">
        /// A #GIArgument to fill in
        /// </param>
        [GISharp.Runtime.SinceAttribute("1.66")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_type_info_argument_from_hash_pointer(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr hashPointer,
        /* <type name="Argument" type="GIArgument*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.Argument* arg);
        partial void CheckArgumentFromHashPointerArgs(System.IntPtr hashPointer, ref GISharp.Lib.GIRepository.Argument arg);

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ArgumentFromHashPointer(System.IntPtr,GISharp.Lib.GIRepository.Argument)']/*" />
        [GISharp.Runtime.SinceAttribute("1.66")]
        public void ArgumentFromHashPointer(System.IntPtr hashPointer, ref GISharp.Lib.GIRepository.Argument arg)
        {
            fixed (GISharp.Lib.GIRepository.Argument* arg_ = &arg)
            {
                CheckArgumentFromHashPointerArgs(hashPointer, ref arg);
                var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
                var hashPointer_ = (System.IntPtr)hashPointer;
                g_type_info_argument_from_hash_pointer(info_, hashPointer_, arg_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Obtain the fixed array size of the type. The type tag must be a
        /// #GI_TYPE_TAG_ARRAY or -1 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the size or -1 if it's not an array
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_type_info_get_array_fixed_size(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetArrayFixedSizeArgs();

        private int GetArrayFixedSize()
        {
            CheckGetArrayFixedSizeArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_array_fixed_size(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the position of the argument which gives the array length of the type.
        /// The type tag must be a #GI_TYPE_TAG_ARRAY or -1 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the array length, or -1 if the type is not an array
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_type_info_get_array_length(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetArrayLengthArgs();

        private int GetArrayLength()
        {
            CheckGetArrayLengthArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_array_length(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the array type for this type. See #GIArrayType for a list of
        /// possible values. If the type tag of this type is not array, -1 will be
        /// returned.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the array type or -1
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ArrayType" type="GIArrayType" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.ArrayType g_type_info_get_array_type(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetArrayTypeArgs();

        private GISharp.Lib.GIRepository.ArrayType GetArrayType()
        {
            CheckGetArrayTypeArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_array_type(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.ArrayType)ret_;
            return ret;
        }

        /// <summary>
        /// For types which have #GI_TYPE_TAG_INTERFACE such as GObjects and boxed values,
        /// this function returns full information about the referenced type.  You can then
        /// inspect the type of the returned #GIBaseInfo to further query whether it is
        /// a concrete GObject, a GInterface, a structure, etc. using g_base_info_get_type().
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the #GIBaseInfo, or %NULL. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="BaseInfo" type="GIBaseInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.BaseInfo.UnmanagedStruct* g_type_info_get_interface(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetInterfaceArgs();

        private GISharp.Lib.GIRepository.BaseInfo GetInterface()
        {
            CheckGetInterfaceArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_interface(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.BaseInfo.GetInstance<GISharp.Lib.GIRepository.BaseInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the parameter type @n.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <param name="n">
        /// index of the parameter
        /// </param>
        /// <returns>
        /// the param type info
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_type_info_get_param_type(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetParamTypeArgs(int n);

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.GetParamType(int)']/*" />
        public GISharp.Lib.GIRepository.TypeInfo GetParamType(int n)
        {
            CheckGetParamTypeArgs(n);
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_type_info_get_param_type(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.TypeInfo.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the type tag corresponding to the underlying storage type in C for
        /// the type.
        /// See #GITypeTag for a list of type tags.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the type tag
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.66")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeTag" type="GITypeTag" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.TypeTag g_type_info_get_storage_type(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetStorageTypeArgs();

        [GISharp.Runtime.SinceAttribute("1.66")]
        private GISharp.Lib.GIRepository.TypeTag GetStorageType()
        {
            CheckGetStorageTypeArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_storage_type(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.TypeTag)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the type tag for the type. See #GITypeTag for a list
        /// of type tags.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// the type tag
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeTag" type="GITypeTag" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GIRepository.TypeTag g_type_info_get_tag(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetTagArgs();

        private GISharp.Lib.GIRepository.TypeTag GetTag()
        {
            CheckGetTagArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_get_tag(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GIRepository.TypeTag)ret_;
            return ret;
        }

        /// <summary>
        /// GLib data structures, such as #GList, #GSList, and #GHashTable, all store
        /// data pointers.
        /// In the case where the list or hash table is storing single types rather than
        /// structs, these data pointers may have values stuffed into them via macros
        /// such as %GPOINTER_TO_INT.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use this function to ensure that all values are correctly stuffed into
        /// pointers, regardless of the machine's architecture or endianness.
        /// </para>
        /// <para>
        /// This function returns a pointer stuffed with the appropriate field of @arg,
        /// depending on the storage type of @info.
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <param name="arg">
        /// A #GIArgument with the value to stuff into a pointer
        /// </param>
        /// <returns>
        /// A stuffed pointer, that can be stored in a #GHashTable, for example
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.66")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern System.IntPtr g_type_info_hash_pointer_from_argument(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info,
        /* <type name="Argument" type="GIArgument*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.Argument* arg);
        partial void CheckHashPointerFromArgumentArgs(ref GISharp.Lib.GIRepository.Argument arg);

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.HashPointerFromArgument(GISharp.Lib.GIRepository.Argument)']/*" />
        [GISharp.Runtime.SinceAttribute("1.66")]
        public System.IntPtr HashPointerFromArgument(ref GISharp.Lib.GIRepository.Argument arg)
        {
            fixed (GISharp.Lib.GIRepository.Argument* arg_ = &arg)
            {
                CheckHashPointerFromArgumentArgs(ref arg);
                var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_type_info_hash_pointer_from_argument(info_,arg_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                var ret = (System.IntPtr)ret_;
                return ret;
            }
        }

        /// <summary>
        /// Obtain if the type is passed as a reference.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that the types of %GI_DIRECTION_OUT and %GI_DIRECTION_INOUT parameters
        /// will only be pointers if the underlying type being transferred is a pointer
        /// (i.e. only if the type of the C function’s formal parameter is a pointer to a
        /// pointer).
        /// </para>
        /// </remarks>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// %TRUE if it is a pointer
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_type_info_is_pointer(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetIsPointerArgs();

        private bool GetIsPointer()
        {
            CheckGetIsPointerArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_is_pointer(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain if the last element of the array is %NULL. The type tag must be a
        /// #GI_TYPE_TAG_ARRAY or %FALSE will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GITypeInfo
        /// </param>
        /// <returns>
        /// %TRUE if zero terminated
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_type_info_is_zero_terminated(
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* info);
        partial void CheckGetIsZeroTerminatedArgs();

        private bool GetIsZeroTerminated()
        {
            CheckGetIsZeroTerminatedArgs();
            var info_ = (GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_info_is_zero_terminated(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}