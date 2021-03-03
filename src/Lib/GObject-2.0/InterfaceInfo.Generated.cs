// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo']/*" />
    public unsafe partial struct InterfaceInfo
    {
#pragma warning disable CS0169, CS0649
        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.InterfaceInit']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*, System.IntPtr, void> InterfaceInit;

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.InterfaceFinalize']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*, System.IntPtr, void> InterfaceFinalize;

        /// <include file="InterfaceInfo.xmldoc" path="declaration/member[@name='InterfaceInfo.InterfaceData']/*" />
        public readonly System.IntPtr InterfaceData;
#pragma warning restore CS0169, CS0649
    }
}