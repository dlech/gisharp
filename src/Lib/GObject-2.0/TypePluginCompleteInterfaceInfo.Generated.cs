// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The type of the @complete_interface_info function of #GTypePluginClass.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedTypePluginCompleteInterfaceInfo(
    /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypePlugin.UnmanagedStruct* plugin,
    /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.GType instanceType,
    /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.GType interfaceType,
    /* <type name="InterfaceInfo" type="GInterfaceInfo*" managed-name="InterfaceInfo" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.InterfaceInfo* info);

    /// <include file="TypePluginCompleteInterfaceInfo.xmldoc" path="declaration/member[@name='TypePluginCompleteInterfaceInfo']/*" />
    public delegate void TypePluginCompleteInterfaceInfo(GISharp.Lib.GObject.ITypePlugin plugin, GISharp.Lib.GObject.GType instanceType, GISharp.Lib.GObject.GType interfaceType, GISharp.Lib.GObject.InterfaceInfo info);

    /// <summary>
    /// Class for marshalling <see cref="TypePluginCompleteInterfaceInfo"/> methods.
    /// </summary>
    public static unsafe class TypePluginCompleteInterfaceInfoMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="TypePluginCompleteInterfaceInfo"/>.
        /// </summary>
        public static GISharp.Lib.GObject.TypePluginCompleteInterfaceInfo FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, GISharp.Lib.GObject.GType, GISharp.Lib.GObject.GType, GISharp.Lib.GObject.InterfaceInfo*, void> callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.GObject.UnmanagedTypePluginCompleteInterfaceInfo>((System.IntPtr)callback_);
            void managedCallback(GISharp.Lib.GObject.ITypePlugin plugin, GISharp.Lib.GObject.GType instanceType, GISharp.Lib.GObject.GType interfaceType, GISharp.Lib.GObject.InterfaceInfo info) { var plugin_ = (GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*)plugin.UnsafeHandle; var instanceType_ = (GISharp.Lib.GObject.GType)instanceType; var interfaceType_ = (GISharp.Lib.GObject.GType)interfaceType; var info_ = &info; unmanagedCallback(plugin_, instanceType_, interfaceType_, info_); }

            return managedCallback;
        }
    }
}