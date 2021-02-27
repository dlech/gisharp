// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The type of the @complete_interface_info function of #GTypePluginClass.
    /// </summary>
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
}