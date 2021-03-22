// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError']/*" />
    [GISharp.Runtime.GErrorDomainAttribute("g_convert_error")]
    public enum ConvertError
    {
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.NoConversion']/*" />
        NoConversion = 0,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.IllegalSequence']/*" />
        IllegalSequence = 1,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.Failed']/*" />
        Failed = 2,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.PartialInput']/*" />
        PartialInput = 3,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.BadUri']/*" />
        BadUri = 4,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.NotAbsolutePath']/*" />
        NotAbsolutePath = 5,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.NoMemory']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        NoMemory = 6,
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertError.EmbeddedNul']/*" />
        [GISharp.Runtime.SinceAttribute("2.56")]
        EmbeddedNul = 7
    }

    /// <summary>
    /// Extension methods for <see cref="ConvertError"/>.
    /// </summary>
    public static unsafe partial class ConvertErrorDomain
    {
        /// <include file="ConvertError.xmldoc" path="declaration/member[@name='ConvertErrorDomain.Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.Quark g_convert_error_quark();
        static partial void CheckGetQuarkArgs();

        private static GISharp.Lib.GLib.Quark GetQuark()
        {
            CheckGetQuarkArgs();
            var ret_ = g_convert_error_quark();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}