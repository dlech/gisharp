// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo']/*" />
    public sealed unsafe partial class UnionInfo : GISharp.Lib.GIRepository.RegisteredTypeInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.Alignment']/*" />
        public int Alignment { get => GetAlignment(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.CopyFunction']/*" />
        [GISharp.Runtime.SinceAttribute("1.76")]
        public GISharp.Runtime.NullableUnownedUtf8 CopyFunction { get => GetCopyFunction(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.DiscriminatorOffset']/*" />
        public int DiscriminatorOffset { get => GetDiscriminatorOffset(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.DiscriminatorType']/*" />
        public GISharp.Lib.GIRepository.TypeInfo DiscriminatorType { get => GetDiscriminatorType(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.FreeFunction']/*" />
        [GISharp.Runtime.SinceAttribute("1.76")]
        public GISharp.Runtime.NullableUnownedUtf8 FreeFunction { get => GetFreeFunction(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.NFields']/*" />
        private int NFields { get => GetNFields(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.NMethods']/*" />
        private int NMethods { get => GetNMethods(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.Size']/*" />
        public int Size { get => GetSize(); }

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.IsDiscriminated']/*" />
        public bool IsDiscriminated { get => GetIsDiscriminated(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UnionInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the type information for method named @name.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <param name="name">
        /// a method name
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_union_info_find_method(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name);
        partial void CheckFindMethodArgs(GISharp.Runtime.UnownedUtf8 name);

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.FindMethod(GISharp.Runtime.UnownedUtf8)']/*" />
        public GISharp.Lib.GIRepository.FunctionInfo FindMethod(GISharp.Runtime.UnownedUtf8 name)
        {
            CheckFindMethodArgs(name);
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (byte*)name.UnsafeHandle;
            var ret_ = g_union_info_find_method(info_,name_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.FunctionInfo.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the required alignment of the union.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// required alignment in bytes
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_union_info_get_alignment(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetAlignmentArgs();

        private int GetAlignment()
        {
            CheckGetAlignmentArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_alignment(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the copy function for @info, if any is set.
        /// </summary>
        /// <param name="info">
        /// a union information blob
        /// </param>
        /// <returns>
        /// the name of the copy function
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.76")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_union_info_get_copy_function(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetCopyFunctionArgs();

        [GISharp.Runtime.SinceAttribute("1.76")]
        private GISharp.Runtime.NullableUnownedUtf8 GetCopyFunction()
        {
            CheckGetCopyFunctionArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_copy_function(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain discriminator value assigned for n-th union field, i.e. n-th
        /// union field is the active one if discriminator contains this
        /// constant.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <param name="n">
        /// a union field index
        /// </param>
        /// <returns>
        /// the #GIConstantInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ConstantInfo" type="GIConstantInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.ConstantInfo.UnmanagedStruct* g_union_info_get_discriminator(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetDiscriminatorArgs(int n);

        /// <include file="UnionInfo.xmldoc" path="declaration/member[@name='UnionInfo.GetDiscriminator(int)']/*" />
        public GISharp.Lib.GIRepository.ConstantInfo GetDiscriminator(int n)
        {
            CheckGetDiscriminatorArgs(n);
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_union_info_get_discriminator(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.ConstantInfo.GetInstance<GISharp.Lib.GIRepository.ConstantInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Returns offset of the discriminator field in the structure.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// offset in bytes of the discriminator
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_union_info_get_discriminator_offset(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetDiscriminatorOffsetArgs();

        private int GetDiscriminatorOffset()
        {
            CheckGetDiscriminatorOffsetArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_discriminator_offset(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the type information of the union discriminator.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// the #GITypeInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInfo" type="GITypeInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.TypeInfo.UnmanagedStruct* g_union_info_get_discriminator_type(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetDiscriminatorTypeArgs();

        private GISharp.Lib.GIRepository.TypeInfo GetDiscriminatorType()
        {
            CheckGetDiscriminatorTypeArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_discriminator_type(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.TypeInfo.GetInstance<GISharp.Lib.GIRepository.TypeInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for field with specified index.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <param name="n">
        /// a field index
        /// </param>
        /// <returns>
        /// the #GIFieldInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FieldInfo" type="GIFieldInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FieldInfo.UnmanagedStruct* g_union_info_get_field(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetFieldArgs(int n);

        private GISharp.Lib.GIRepository.FieldInfo GetField(int n)
        {
            CheckGetFieldArgs(n);
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_union_info_get_field(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.FieldInfo.GetInstance<GISharp.Lib.GIRepository.FieldInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the free function for @info, if any is set.
        /// </summary>
        /// <param name="info">
        /// a union information blob
        /// </param>
        /// <returns>
        /// the name of the free function
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.76")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_union_info_get_free_function(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetFreeFunctionArgs();

        [GISharp.Runtime.SinceAttribute("1.76")]
        private GISharp.Runtime.NullableUnownedUtf8 GetFreeFunction()
        {
            CheckGetFreeFunctionArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_free_function(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Obtain the type information for method with specified index.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <param name="n">
        /// a method index
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_union_info_get_method(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetMethodArgs(int n);

        private GISharp.Lib.GIRepository.FunctionInfo GetMethod(int n)
        {
            CheckGetMethodArgs(n);
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_union_info_get_method(info_,n_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GIRepository.FunctionInfo.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the number of fields this union has.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// number of fields
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_union_info_get_n_fields(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetNFieldsArgs();

        private int GetNFields()
        {
            CheckGetNFieldsArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_n_fields(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of methods this union has.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// number of methods
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_union_info_get_n_methods(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetNMethodsArgs();

        private int GetNMethods()
        {
            CheckGetNMethodsArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_n_methods(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the total size of the union.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// size of the union in bytes
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_union_info_get_size(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetSizeArgs();

        private int GetSize()
        {
            CheckGetSizeArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_get_size(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Return true if this union contains discriminator field.
        /// </summary>
        /// <param name="info">
        /// a #GIUnionInfo
        /// </param>
        /// <returns>
        /// %TRUE if this is a discriminated union, %FALSE otherwise
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_union_info_is_discriminated(
        /* <type name="UnionInfo" type="GIUnionInfo*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct* info);
        partial void CheckGetIsDiscriminatedArgs();

        private bool GetIsDiscriminated()
        {
            CheckGetIsDiscriminatedArgs();
            var info_ = (GISharp.Lib.GIRepository.UnionInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_union_info_is_discriminated(info_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}