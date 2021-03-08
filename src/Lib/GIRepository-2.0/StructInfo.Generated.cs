// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo']/*" />
    public sealed unsafe partial class StructInfo : GISharp.Lib.GIRepository.RegisteredTypeInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.Alignment']/*" />
        public int Alignment { get => GetAlignment(); }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.NFields']/*" />
        private int NFields { get => GetNFields(); }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.NMethods']/*" />
        private int NMethods { get => GetNMethods(); }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.Size']/*" />
        public int Size { get => GetSize(); }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.IsForeign']/*" />
        public bool IsForeign { get => GetIsForeign(); }

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.IsGtypeStruct']/*" />
        public bool IsGtypeStruct { get => GetIsGtypeStruct(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public StructInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain the type information for field named @name.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <param name="name">
        /// a field name
        /// </param>
        /// <returns>
        /// the #GIFieldInfo or %NULL if not found,
        /// free it with g_base_info_unref() when done.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.46")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FieldInfo" type="GIFieldInfo*" managed-name="FieldInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FieldInfo.UnmanagedStruct* g_struct_info_find_field(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name);
        partial void CheckFindFieldArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.FindField(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("1.46")]
        public GISharp.Lib.GIRepository.FieldInfo FindField(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckFindFieldArgs(name);
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (byte*)name.UnsafeHandle;
            var ret_ = g_struct_info_find_field(info_,name_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FieldInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for method named @name.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <param name="name">
        /// a method name
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_struct_info_find_method(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* name);
        partial void CheckFindMethodArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="StructInfo.xmldoc" path="declaration/member[@name='StructInfo.FindMethod(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public GISharp.Lib.GIRepository.FunctionInfo FindMethod(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckFindMethodArgs(name);
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (byte*)name.UnsafeHandle;
            var ret_ = g_struct_info_find_method(info_,name_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the required alignment of the structure.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <returns>
        /// required alignment in bytes
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_struct_info_get_alignment(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetAlignmentArgs();

        private int GetAlignment()
        {
            CheckGetAlignmentArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_get_alignment(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for field with specified index.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <param name="n">
        /// a field index
        /// </param>
        /// <returns>
        /// the #GIFieldInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FieldInfo" type="GIFieldInfo*" managed-name="FieldInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FieldInfo.UnmanagedStruct* g_struct_info_get_field(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetFieldArgs(int n);

        private GISharp.Lib.GIRepository.FieldInfo GetField(int n)
        {
            CheckGetFieldArgs(n);
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_struct_info_get_field(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FieldInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the type information for method with specified index.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <param name="n">
        /// a method index
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo, free it with g_base_info_unref()
        /// when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_struct_info_get_method(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int n);
        partial void CheckGetMethodArgs(int n);

        private GISharp.Lib.GIRepository.FunctionInfo GetMethod(int n)
        {
            CheckGetMethodArgs(n);
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (int)n;
            var ret_ = g_struct_info_get_method(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the number of fields this structure has.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <returns>
        /// number of fields
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_struct_info_get_n_fields(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetNFieldsArgs();

        private int GetNFields()
        {
            CheckGetNFieldsArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_get_n_fields(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of methods this structure has.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <returns>
        /// number of methods
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern int g_struct_info_get_n_methods(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetNMethodsArgs();

        private int GetNMethods()
        {
            CheckGetNMethodsArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_get_n_methods(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the total size of the structure.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <returns>
        /// size of the structure in bytes
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern nuint g_struct_info_get_size(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetSizeArgs();

        private int GetSize()
        {
            CheckGetSizeArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_get_size(info_);
            var ret = (int)ret_;
            return ret;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="info">
        /// TODO
        /// </param>
        /// <returns>
        /// TODO
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_struct_info_is_foreign(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetIsForeignArgs();

        private bool GetIsForeign()
        {
            CheckGetIsForeignArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_is_foreign(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Return true if this structure represents the "class structure" for some
        /// #GObject or #GInterface.  This function is mainly useful to hide this kind of structure
        /// from generated public APIs.
        /// </summary>
        /// <param name="info">
        /// a #GIStructInfo
        /// </param>
        /// <returns>
        /// %TRUE if this is a class struct, %FALSE otherwise
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_struct_info_is_gtype_struct(
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* info);
        partial void CheckGetIsGtypeStructArgs();

        private bool GetIsGtypeStruct()
        {
            CheckGetIsGtypeStructArgs();
            var info_ = (GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_struct_info_is_gtype_struct(info_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}