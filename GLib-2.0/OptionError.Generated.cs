namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Error codes returned by option parsing.
    /// </summary>
    [GISharp.Runtime.GErrorDomainAttribute("g-option-context-error-quark")]
    public enum OptionError
    {
        /// <summary>
        /// An option was not known to the parser.
        ///  This error will only be reported, if the parser hasn't been instructed
        ///  to ignore unknown options, see <see cref="OptionContext.SetIgnoreUnknownOptions"/>.
        /// </summary>
        UnknownOption = 0,
        /// <summary>
        /// A value couldn't be parsed.
        /// </summary>
        BadValue = 1,
        /// <summary>
        /// A <see cref="OptionArgFunc"/> callback failed.
        /// </summary>
        Failed = 2
    }

    public partial class OptionErrorDomain
    {
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_option_error_quark();

        public static unsafe GISharp.Lib.GLib.Quark OptionErrorQuark()
        {
            var ret_ = g_option_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}