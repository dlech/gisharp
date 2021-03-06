// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="BindingFlags.xmldoc" path="declaration/member[@name='BindingFlags']/*" />
    [GISharp.Runtime.SinceAttribute("2.26")]
    [GISharp.Runtime.GTypeAttribute("GBindingFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum BindingFlags : uint
    {
        /// <include file="BindingFlags.xmldoc" path="declaration/member[@name='BindingFlags.Default']/*" />
        Default = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="BindingFlags.xmldoc" path="declaration/member[@name='BindingFlags.Bidirectional']/*" />
        Bidirectional = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="BindingFlags.xmldoc" path="declaration/member[@name='BindingFlags.SyncCreate']/*" />
        SyncCreate = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="BindingFlags.xmldoc" path="declaration/member[@name='BindingFlags.InvertBoolean']/*" />
        InvertBoolean = 0b0000_0000_0000_0000_0000_0000_0000_0100
    }

    /// <summary>
    /// Extension methods for <see cref="BindingFlags"/>.
    /// </summary>
    public static unsafe partial class BindingFlagsExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = g_binding_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_binding_flags_get_type();
    }
}