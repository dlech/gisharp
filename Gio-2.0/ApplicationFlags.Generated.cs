namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Flags used to define the behaviour of a #GApplication.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [GISharp.Runtime.GTypeAttribute("GApplicationFlags", IsProxyForUnmanagedType = true)]
    [System.FlagsAttribute]
    public enum ApplicationFlags
    {
        /// <summary>
        /// Default
        /// </summary>
        FlagsNone = 0,
        /// <summary>
        /// Run as a service. In this mode, registration
        ///      fails if the service is already running, and the application
        ///      will initially wait up to 10 seconds for an initial activation
        ///      message to arrive.
        /// </summary>
        IsService = 1,
        /// <summary>
        /// Don't try to become the primary instance.
        /// </summary>
        IsLauncher = 2,
        /// <summary>
        /// This application handles opening files (in
        ///     the primary instance). Note that this flag only affects the default
        ///     implementation of local_command_line(), and has no effect if
        ///     <see cref="ApplicationFlags.HandlesCommandLine"/> is given.
        ///     See g_application_run() for details.
        /// </summary>
        HandlesOpen = 4,
        /// <summary>
        /// This application handles command line
        ///     arguments (in the primary instance). Note that this flag only affect
        ///     the default implementation of local_command_line().
        ///     See g_application_run() for details.
        /// </summary>
        HandlesCommandLine = 8,
        /// <summary>
        /// Send the environment of the
        ///     launching process to the primary instance. Set this flag if your
        ///     application is expected to behave differently depending on certain
        ///     environment variables. For instance, an editor might be expected
        ///     to use the `GIT_COMMITTER_NAME` environment variable
        ///     when editing a git commit message. The environment is available
        ///     to the #GApplication::command-line signal handler, via
        ///     g_application_command_line_getenv().
        /// </summary>
        SendEnvironment = 16,
        /// <summary>
        /// Make no attempts to do any of the typical
        ///     single-instance application negotiation, even if the application
        ///     ID is given.  The application neither attempts to become the
        ///     owner of the application ID nor does it check if an existing
        ///     owner already exists.  Everything occurs in the local process.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.30")]
        NonUnique = 32,
        /// <summary>
        /// Allow users to override the
        ///     application ID from the command line with `--gapplication-app-id`.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.48")]
        CanOverrideAppId = 64
    }

    public partial class ApplicationFlagsExtensions
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_application_flags_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_application_flags_get_type();
    }
}