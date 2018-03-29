namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Error codes returned by GIO functions.
    /// </summary>
    /// <remarks>
    /// Note that this domain may be extended in future GLib releases. In
    /// general, new error codes either only apply to new APIs, or else
    /// replace <see cref="IOErrorEnum.Failed"/> in cases that were not explicitly
    /// distinguished before. You should therefore avoid writing code like
    /// |[&lt;!-- language="C" --&gt;
    /// if (g_error_matches (error, G_IO_ERROR, G_IO_ERROR_FAILED))
    ///   {
    ///     // Assume that this is EPRINTERONFIRE
    ///     ...
    ///   }
    /// ]|
    /// but should instead treat all unrecognized error codes the same as
    /// #G_IO_ERROR_FAILED.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GIOErrorEnum", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GErrorDomainAttribute("g-io-error-quark")]
    public enum IOErrorEnum
    {
        /// <summary>
        /// Generic error condition for when an operation fails
        ///     and no more specific <see cref="IOErrorEnum"/> value is defined.
        /// </summary>
        Failed = 0,
        /// <summary>
        /// File not found.
        /// </summary>
        NotFound = 1,
        /// <summary>
        /// File already exists.
        /// </summary>
        Exists = 2,
        /// <summary>
        /// File is a directory.
        /// </summary>
        IsDirectory = 3,
        /// <summary>
        /// File is not a directory.
        /// </summary>
        NotDirectory = 4,
        /// <summary>
        /// File is a directory that isn't empty.
        /// </summary>
        NotEmpty = 5,
        /// <summary>
        /// File is not a regular file.
        /// </summary>
        NotRegularFile = 6,
        /// <summary>
        /// File is not a symbolic link.
        /// </summary>
        NotSymbolicLink = 7,
        /// <summary>
        /// File cannot be mounted.
        /// </summary>
        NotMountableFile = 8,
        /// <summary>
        /// Filename is too many characters.
        /// </summary>
        FilenameTooLong = 9,
        /// <summary>
        /// Filename is invalid or contains invalid characters.
        /// </summary>
        InvalidFilename = 10,
        /// <summary>
        /// File contains too many symbolic links.
        /// </summary>
        TooManyLinks = 11,
        /// <summary>
        /// No space left on drive.
        /// </summary>
        NoSpace = 12,
        /// <summary>
        /// Invalid argument.
        /// </summary>
        InvalidArgument = 13,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = 14,
        /// <summary>
        /// Operation (or one of its parameters) not supported
        /// </summary>
        NotSupported = 15,
        /// <summary>
        /// File isn't mounted.
        /// </summary>
        NotMounted = 16,
        /// <summary>
        /// File is already mounted.
        /// </summary>
        AlreadyMounted = 17,
        /// <summary>
        /// File was closed.
        /// </summary>
        Closed = 18,
        /// <summary>
        /// Operation was cancelled. See <see cref="Cancellable"/>.
        /// </summary>
        Cancelled = 19,
        /// <summary>
        /// Operations are still pending.
        /// </summary>
        Pending = 20,
        /// <summary>
        /// File is read only.
        /// </summary>
        ReadOnly = 21,
        /// <summary>
        /// Backup couldn't be created.
        /// </summary>
        CantCreateBackup = 22,
        /// <summary>
        /// File's Entity Tag was incorrect.
        /// </summary>
        WrongEtag = 23,
        /// <summary>
        /// Operation timed out.
        /// </summary>
        TimedOut = 24,
        /// <summary>
        /// Operation would be recursive.
        /// </summary>
        WouldRecurse = 25,
        /// <summary>
        /// File is busy.
        /// </summary>
        Busy = 26,
        /// <summary>
        /// Operation would block.
        /// </summary>
        WouldBlock = 27,
        /// <summary>
        /// Host couldn't be found (remote operations).
        /// </summary>
        HostNotFound = 28,
        /// <summary>
        /// Operation would merge files.
        /// </summary>
        WouldMerge = 29,
        /// <summary>
        /// Operation failed and a helper program has
        ///     already interacted with the user. Do not display any error dialog.
        /// </summary>
        FailedHandled = 30,
        /// <summary>
        /// The current process has too many files
        ///     open and can't open any more. Duplicate descriptors do count toward
        ///     this limit.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.20")]
        TooManyOpenFiles = 31,
        /// <summary>
        /// The object has not been initialized.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        NotInitialized = 32,
        /// <summary>
        /// The requested address is already in use.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        AddressInUse = 33,
        /// <summary>
        /// Need more input to finish operation.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        PartialInput = 34,
        /// <summary>
        /// The input data was invalid.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        InvalidData = 35,
        /// <summary>
        /// A remote object generated an error that
        ///     doesn't correspond to a locally registered #GError error
        ///     domain. Use g_dbus_error_get_remote_error() to extract the D-Bus
        ///     error name and g_dbus_error_strip_remote_error() to fix up the
        ///     message so it matches what was received on the wire.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        DbusError = 36,
        /// <summary>
        /// Host unreachable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        HostUnreachable = 37,
        /// <summary>
        /// Network unreachable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        NetworkUnreachable = 38,
        /// <summary>
        /// Connection refused.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ConnectionRefused = 39,
        /// <summary>
        /// Connection to proxy server failed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyFailed = 40,
        /// <summary>
        /// Proxy authentication failed.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyAuthFailed = 41,
        /// <summary>
        /// Proxy server needs authentication.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyNeedAuth = 42,
        /// <summary>
        /// Proxy connection is not allowed by ruleset.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        ProxyNotAllowed = 43,
        /// <summary>
        /// Broken pipe.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        BrokenPipe = 44,
        /// <summary>
        /// Connection closed by peer. Note that this
        ///     is the same code as <see cref="IOErrorEnum.BrokenPipe"/>; before 2.44 some
        ///     "connection closed" errors returned <see cref="IOErrorEnum.BrokenPipe"/>, but others
        ///     returned <see cref="IOErrorEnum.Failed"/>. Now they should all return the same
        ///     value, which has this more logical name.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        ConnectionClosed = 44,
        /// <summary>
        /// Transport endpoint is not connected.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.44")]
        NotConnected = 45,
        /// <summary>
        /// Message too large.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.48")]
        MessageTooLarge = 46
    }

    public partial class IOErrorEnumDomain
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_io_error_enum_get_type();

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        public static GISharp.Lib.GLib.Quark Quark { get => GetQuark(); }

        /// <summary>
        /// Converts errno.h error codes into GIO error codes. The fallback
        /// value %G_IO_ERROR_FAILED is returned for error codes not currently
        /// handled (but note that future GLib releases may return a more
        /// specific value instead).
        /// </summary>
        /// <remarks>
        /// As %errno is global and may be modified by intermediate function
        /// calls, you should save its value as soon as the call which sets it
        /// </remarks>
        /// <param name="errno">
        /// Error number as defined in errno.h.
        /// </param>
        /// <returns>
        /// #GIOErrorEnum value for the given errno.h error number.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="IOErrorEnum" type="GIOErrorEnum" managed-name="IOErrorEnum" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.Gio.IOErrorEnum g_io_error_from_errno(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 errno);

        /// <summary>
        /// Converts errno.h error codes into GIO error codes. The fallback
        /// value <see cref="IOErrorEnum.Failed"/> is returned for error codes not currently
        /// handled (but note that future GLib releases may return a more
        /// specific value instead).
        /// </summary>
        /// <remarks>
        /// As %errno is global and may be modified by intermediate function
        /// calls, you should save its value as soon as the call which sets it
        /// </remarks>
        /// <param name="errno">
        /// Error number as defined in errno.h.
        /// </param>
        /// <returns>
        /// <see cref="IOErrorEnum"/> value for the given errno.h error number.
        /// </returns>
        public static unsafe GISharp.Lib.Gio.IOErrorEnum FromErrno(System.Int32 errno)
        {
            var errno_ = (System.Int32)errno;
            var ret_ = g_io_error_from_errno(errno_);
            var ret = (GISharp.Lib.Gio.IOErrorEnum)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        /// <returns>
        /// a #GQuark.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Quark" type="GQuark" managed-name="GISharp.Lib.GLib.Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_io_error_quark();

        /// <summary>
        /// Gets the GIO Error Quark.
        /// </summary>
        /// <returns>
        /// a #GQuark.
        /// </returns>
        private static unsafe GISharp.Lib.GLib.Quark GetQuark()
        {
            var ret_ = g_io_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_io_error_enum_get_type();
    }
}