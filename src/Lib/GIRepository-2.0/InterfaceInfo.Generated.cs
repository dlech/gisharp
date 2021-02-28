// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GIRepository
{
    /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo']/*" />
    public sealed unsafe partial class InterfaceInfo : GISharp.Lib.GIRepository.RegisteredTypeInfo
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.IfaceStruct']/*" />
        public GISharp.Lib.GIRepository.StructInfo IfaceStruct { get => GetIfaceStruct(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NConstants']/*" />
        private System.Int32 NConstants { get => GetNConstants(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NMethods']/*" />
        private System.Int32 NMethods { get => GetNMethods(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NPrerequisites']/*" />
        private System.Int32 NPrerequisites { get => GetNPrerequisites(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NProperties']/*" />
        private System.Int32 NProperties { get => GetNProperties(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NSignals']/*" />
        private System.Int32 NSignals { get => GetNSignals(); }

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.NVFuncs']/*" />
        private System.Int32 NVFuncs { get => GetNVFuncs(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InterfaceInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Obtain a method of the interface type given a @name. %NULL will be
        /// returned if there's no method available with that name.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="name">
        /// name of method to obtain
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo or %NULL if none found.
        /// Free the struct by calling g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_interface_info_find_method(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* name);
        partial void CheckFindMethodArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.FindMethod(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public GISharp.Lib.GIRepository.FunctionInfo FindMethod(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckFindMethodArgs(name);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (System.Byte*)name.UnsafeHandle;
            var ret_ = g_interface_info_find_method(info_,name_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="name">
        /// Name of signal
        /// </param>
        /// <returns>
        /// Info for the signal with name @name in @info, or
        /// %NULL on failure.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("1.34")]
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SignalInfo" type="GISignalInfo*" managed-name="SignalInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* g_interface_info_find_signal(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* name);
        partial void CheckFindSignalArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.FindSignal(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("1.34")]
        public GISharp.Lib.GIRepository.SignalInfo FindSignal(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckFindSignalArgs(name);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (System.Byte*)name.UnsafeHandle;
            var ret_ = g_interface_info_find_signal(info_,name_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.SignalInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Locate a virtual function slot with name @name. See the documentation
        /// for g_object_info_find_vfunc() for more information on virtuals.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="name">
        /// The name of a virtual function to find.
        /// </param>
        /// <returns>
        /// the #GIVFuncInfo, or %NULL. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VFuncInfo" type="GIVFuncInfo*" managed-name="VFuncInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* g_interface_info_find_vfunc(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* name);
        partial void CheckFindVFuncArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.FindVFunc(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public GISharp.Lib.GIRepository.VFuncInfo FindVFunc(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckFindVFuncArgs(name);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var name_ = (System.Byte*)name.UnsafeHandle;
            var ret_ = g_interface_info_find_vfunc(info_,name_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.VFuncInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type constant at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of constant to get
        /// </param>
        /// <returns>
        /// the #GIConstantInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ConstantInfo" type="GIConstantInfo*" managed-name="ConstantInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.ConstantInfo.UnmanagedStruct* g_interface_info_get_constant(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetConstantArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.ConstantInfo GetConstant(System.Int32 n)
        {
            CheckGetConstantArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_constant(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.ConstantInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Returns the layout C structure associated with this #GInterface.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// the #GIStructInfo or %NULL. Free it with
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="StructInfo" type="GIStructInfo*" managed-name="StructInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.StructInfo.UnmanagedStruct* g_interface_info_get_iface_struct(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetIfaceStructArgs();

        private GISharp.Lib.GIRepository.StructInfo GetIfaceStruct()
        {
            CheckGetIfaceStructArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_iface_struct(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.StructInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type method at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of method to get
        /// </param>
        /// <returns>
        /// the #GIFunctionInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FunctionInfo" type="GIFunctionInfo*" managed-name="FunctionInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.FunctionInfo.UnmanagedStruct* g_interface_info_get_method(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetMethodArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.FunctionInfo GetMethod(System.Int32 n)
        {
            CheckGetMethodArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_method(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.FunctionInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain the number of constants that this interface type has.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of constants
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_constants(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNConstantsArgs();

        private System.Int32 GetNConstants()
        {
            CheckGetNConstantsArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_constants(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of methods that this interface type has.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of methods
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_methods(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNMethodsArgs();

        private System.Int32 GetNMethods()
        {
            CheckGetNMethodsArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_methods(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of prerequisites for this interface type.
        /// A prerequisites is another interface that needs to be implemented for
        /// interface, similar to an base class for GObjects.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of prerequisites
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_prerequisites(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNPrerequisitesArgs();

        private System.Int32 GetNPrerequisites()
        {
            CheckGetNPrerequisitesArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_prerequisites(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of properties that this interface type has.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of properties
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_properties(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNPropertiesArgs();

        private System.Int32 GetNProperties()
        {
            CheckGetNPropertiesArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_properties(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of signals that this interface type has.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of signals
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_signals(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNSignalsArgs();

        private System.Int32 GetNSignals()
        {
            CheckGetNSignalsArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_signals(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain the number of virtual functions that this interface type has.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <returns>
        /// number of virtual functions
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern System.Int32 g_interface_info_get_n_vfuncs(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info);
        partial void CheckGetNVFuncsArgs();

        private System.Int32 GetNVFuncs()
        {
            CheckGetNVFuncsArgs();
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_interface_info_get_n_vfuncs(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type prerequisites index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of prerequisites to get
        /// </param>
        /// <returns>
        /// the prerequisites as a #GIBaseInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="BaseInfo" type="GIBaseInfo*" managed-name="BaseInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.BaseInfo.UnmanagedStruct* g_interface_info_get_prerequisite(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetPrerequisiteArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.BaseInfo GetPrerequisite(System.Int32 n)
        {
            CheckGetPrerequisiteArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_prerequisite(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.BaseInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type property at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of property to get
        /// </param>
        /// <returns>
        /// the #GIPropertyInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="PropertyInfo" type="GIPropertyInfo*" managed-name="PropertyInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.PropertyInfo.UnmanagedStruct* g_interface_info_get_property(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetPropertyArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.PropertyInfo GetProperty(System.Int32 n)
        {
            CheckGetPropertyArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_property(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.PropertyInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type signal at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of signal to get
        /// </param>
        /// <returns>
        /// the #GISignalInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="SignalInfo" type="GISignalInfo*" managed-name="SignalInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.SignalInfo.UnmanagedStruct* g_interface_info_get_signal(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetSignalArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.SignalInfo GetSignal(System.Int32 n)
        {
            CheckGetSignalArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_signal(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.SignalInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Obtain an interface type virtual function at index @n.
        /// </summary>
        /// <param name="info">
        /// a #GIInterfaceInfo
        /// </param>
        /// <param name="n">
        /// index of virtual function to get
        /// </param>
        /// <returns>
        /// the #GIVFuncInfo. Free the struct by calling
        /// g_base_info_unref() when done.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("girepository-1.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VFuncInfo" type="GIVFuncInfo*" managed-name="VFuncInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GIRepository.VFuncInfo.UnmanagedStruct* g_interface_info_get_vfunc(
        /* <type name="InterfaceInfo" type="GIInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct* info,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 n);
        partial void CheckGetVFuncArgs(System.Int32 n);

        private GISharp.Lib.GIRepository.VFuncInfo GetVFunc(System.Int32 n)
        {
            CheckGetVFuncArgs(n);
            var info_ = (GISharp.Lib.GIRepository.InterfaceInfo.UnmanagedStruct*)UnsafeHandle;
            var n_ = (System.Int32)n;
            var ret_ = g_interface_info_get_vfunc(info_,n_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GIRepository.VFuncInfo>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}