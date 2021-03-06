// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition']/*" />
    [GISharp.Runtime.GTypeAttribute("GIOCondition", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum IOCondition : uint
    {
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.In']/*" />
        In = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.Out']/*" />
        Out = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.Pri']/*" />
        Pri = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.Err']/*" />
        Err = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.Hup']/*" />
        Hup = 0b0000_0000_0000_0000_0000_0000_0001_0000,
        /// <include file="IOCondition.xmldoc" path="declaration/member[@name='IOCondition.Nval']/*" />
        Nval = 0b0000_0000_0000_0000_0000_0000_0010_0000
    }

    /// <summary>
    /// Extension methods for <see cref="IOCondition"/>.
    /// </summary>
    public static unsafe partial class IOConditionExtensions
    {
        private static readonly GISharp.Runtime.GType _GType = g_io_condition_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_io_condition_get_type();
    }
}