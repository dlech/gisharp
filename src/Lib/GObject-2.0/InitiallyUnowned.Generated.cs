// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="InitiallyUnowned.xmldoc" path="declaration/member[@name='InitiallyUnowned']/*" />
    [GISharp.Runtime.GTypeAttribute("GInitiallyUnowned", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(InitiallyUnownedClass))]
    public unsafe partial class InitiallyUnowned : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Runtime.GType _GType = g_initially_unowned_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="InitiallyUnowned.xmldoc" path="declaration/member[@name='UnmanagedStruct.Parent']/*" />
            public readonly GISharp.Lib.GObject.Object.UnmanagedStruct Parent;
#pragma warning restore CS0169, CS0414, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public InitiallyUnowned(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_initially_unowned_get_type();
    }
}