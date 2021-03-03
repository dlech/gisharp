// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo']/*" />
    public unsafe partial struct TypeInfo
    {
#pragma warning disable CS0169, CS0649
        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ClassSize']/*" />
        public readonly ushort ClassSize;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.BaseInit']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass*, void> BaseInit;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.BaseFinalize']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass*, void> BaseFinalize;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ClassInit']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass*, System.IntPtr, void> ClassInit;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ClassFinalize']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass*, System.IntPtr, void> ClassFinalize;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ClassData']/*" />
        public readonly System.IntPtr ClassData;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.InstanceSize']/*" />
        public readonly ushort InstanceSize;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.NPreallocs']/*" />
        public readonly ushort NPreallocs;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.InstanceInit']/*" />
        public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeInstance*, GISharp.Lib.GObject.TypeClass*, void> InstanceInit;

        /// <include file="TypeInfo.xmldoc" path="declaration/member[@name='TypeInfo.ValueTable']/*" />
        public readonly GISharp.Lib.GObject.TypeValueTable* ValueTable;
#pragma warning restore CS0169, CS0649
    }
}