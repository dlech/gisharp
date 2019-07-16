// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="OptionError.xmldoc" path="declaration/member[@name='OptionError']/*" />
    [GISharp.Runtime.GErrorDomainAttribute("g-option-context-error-quark")]
    public enum OptionError
    {
        /// <include file="OptionError.xmldoc" path="declaration/member[@name='UnknownOption']/*" />
        UnknownOption = 0,
        /// <include file="OptionError.xmldoc" path="declaration/member[@name='BadValue']/*" />
        BadValue = 1,
        /// <include file="OptionError.xmldoc" path="declaration/member[@name='Failed']/*" />
        Failed = 2
    }

    /// <summary>
    /// Extension methods for <see cref="OptionError"/>.
    /// </summary>
    public partial class OptionErrorDomain
    {
        /// <include file="OptionError.xmldoc" path="declaration/member[@name='Quark']/*" />
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_option_error_quark();

        /// <include file="OptionError.xmldoc" path="declaration/member[@name='GetQuark()']/*" />
        private static unsafe GISharp.Lib.GLib.Quark GetQuark()
        {
            var ret_ = g_option_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}