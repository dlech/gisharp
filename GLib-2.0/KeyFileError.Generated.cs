namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Error codes returned by key file parsing.
    /// </summary>
    [GISharp.Runtime.GErrorDomainAttribute("g-key-file-error-quark")]
    public enum KeyFileError
    {
        /// <summary>
        /// the text being parsed was in
        ///     an unknown encoding
        /// </summary>
        UnknownEncoding = 0,
        /// <summary>
        /// document was ill-formed
        /// </summary>
        Parse = 1,
        /// <summary>
        /// the file was not found
        /// </summary>
        NotFound = 2,
        /// <summary>
        /// a requested key was not found
        /// </summary>
        KeyNotFound = 3,
        /// <summary>
        /// a requested group was not found
        /// </summary>
        GroupNotFound = 4,
        /// <summary>
        /// a value could not be parsed
        /// </summary>
        InvalidValue = 5
    }

    public partial class KeyFileErrorDomain
    {
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_key_file_error_quark();

        public static unsafe GISharp.Lib.GLib.Quark ErrorQuark()
        {
            var ret_ = g_key_file_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }
}