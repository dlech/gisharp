// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags']/*" />
    [GISharp.Runtime.SinceAttribute("2.28")]
    [GISharp.Runtime.GTypeAttribute("GApplicationFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum ApplicationFlags : uint
    {
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.FlagsNone']/*" />
        FlagsNone = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.IsService']/*" />
        IsService = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.IsLauncher']/*" />
        IsLauncher = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.HandlesOpen']/*" />
        HandlesOpen = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.HandlesCommandLine']/*" />
        HandlesCommandLine = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.SendEnvironment']/*" />
        SendEnvironment = 0b0000_0000_0000_0000_0000_0000_0001_0000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.NonUnique']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        NonUnique = 0b0000_0000_0000_0000_0000_0000_0010_0000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.CanOverrideAppId']/*" />
        [GISharp.Runtime.SinceAttribute("2.48")]
        CanOverrideAppId = 0b0000_0000_0000_0000_0000_0000_0100_0000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.AllowReplacement']/*" />
        [GISharp.Runtime.SinceAttribute("2.60")]
        AllowReplacement = 0b0000_0000_0000_0000_0000_0000_1000_0000,
        /// <include file="ApplicationFlags.xmldoc" path="declaration/member[@name='ApplicationFlags.Replace']/*" />
        [GISharp.Runtime.SinceAttribute("2.60")]
        Replace = 0b0000_0000_0000_0000_0000_0001_0000_0000
    }

    /// <summary>
    /// Extension methods for <see cref="ApplicationFlags"/>.
    /// </summary>
    public static unsafe partial class ApplicationFlagsExtensions
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_application_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_application_flags_get_type();
    }
}