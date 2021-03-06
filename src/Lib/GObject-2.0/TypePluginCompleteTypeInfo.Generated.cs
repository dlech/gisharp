// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The type of the @complete_type_info function of #GTypePluginClass.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedTypePluginCompleteTypeInfo(
    /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypePlugin.UnmanagedStruct* plugin,
    /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.GType gType,
    /* <type name="TypeInfo" type="GTypeInfo*" managed-name="TypeInfo" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeInfo* info,
    /* <type name="TypeValueTable" type="GTypeValueTable*" managed-name="TypeValueTable" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeValueTable* valueTable);

    /// <include file="TypePluginCompleteTypeInfo.xmldoc" path="declaration/member[@name='TypePluginCompleteTypeInfo']/*" />
    public delegate void TypePluginCompleteTypeInfo(GISharp.Lib.GObject.ITypePlugin plugin, GISharp.Lib.GObject.GType gType, GISharp.Lib.GObject.TypeInfo info, GISharp.Lib.GObject.TypeValueTable valueTable);

    /// <summary>
    /// Class for marshalling <see cref="TypePluginCompleteTypeInfo"/> methods.
    /// </summary>
    public static unsafe class TypePluginCompleteTypeInfoMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="TypePluginCompleteTypeInfo"/>.
        /// </summary>
        public static GISharp.Lib.GObject.TypePluginCompleteTypeInfo FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, GISharp.Lib.GObject.GType, GISharp.Lib.GObject.TypeInfo*, GISharp.Lib.GObject.TypeValueTable*, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.ITypePlugin plugin, GISharp.Lib.GObject.GType gType, GISharp.Lib.GObject.TypeInfo info, GISharp.Lib.GObject.TypeValueTable valueTable)
            {
                var plugin_ = (GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*)plugin.UnsafeHandle;
                var gType_ = (GISharp.Lib.GObject.GType)gType;
                var info_ = &info;
                var valueTable_ = &valueTable;
                callback_(plugin_, gType_, info_, valueTable_);
            }

            return managedCallback;
        }
    }
}