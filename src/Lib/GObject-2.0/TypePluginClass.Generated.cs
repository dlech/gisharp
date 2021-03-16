// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass']/*" />
    public unsafe partial struct TypePluginClass
    {
#pragma warning disable CS0169, CS0649
        /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass.BaseIface']/*" />
        public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct BaseIface;

        /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass.UsePlugin']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, void> UsePlugin;

        /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass.UnusePlugin']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, void> UnusePlugin;

        /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass.CompleteTypeInfo']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, GISharp.Runtime.GType, GISharp.Lib.GObject.TypeInfo*, GISharp.Lib.GObject.TypeValueTable*, void> CompleteTypeInfo;

        /// <include file="TypePluginClass.xmldoc" path="declaration/member[@name='TypePluginClass.CompleteInterfaceInfo']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, GISharp.Runtime.GType, GISharp.Runtime.GType, GISharp.Lib.GObject.InterfaceInfo*, void> CompleteInterfaceInfo;
#pragma warning restore CS0169, CS0649
    }
}