// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="InitiallyUnownedClass.xmldoc" path="declaration/member[@name='InitiallyUnownedClass']/*" />
    public unsafe partial class InitiallyUnownedClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="InitiallyUnownedClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Parent']/*" />
            public readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct Parent;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static InitiallyUnownedClass()
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InitiallyUnownedClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}