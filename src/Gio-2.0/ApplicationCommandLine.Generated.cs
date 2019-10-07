// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine']/*" />
    [GISharp.Runtime.GTypeAttribute("GApplicationCommandLine", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ApplicationCommandLineClass))]
    public partial class ApplicationCommandLine : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_application_command_line_get_type();

        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe protected new struct Struct
        {
#pragma warning disable CS0649
            /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='Struct.ParentInstance']/*" />
            public GISharp.Lib.GObject.Object.Struct ParentInstance;

            /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='Struct.Priv']/*" />
            public System.IntPtr Priv;
#pragma warning restore CS0649
        }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Arguments_']/*" />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("arguments", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Variant? Arguments_ { set => SetProperty("arguments", value); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.IsRemote_']/*" />
        [GISharp.Runtime.GPropertyAttribute("is-remote")]
        public System.Boolean IsRemote_ { get => (System.Boolean)GetProperty("is-remote")!; }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Options_']/*" />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("options", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Variant? Options_ { set => SetProperty("options", value); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.PlatformData_']/*" />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("platform-data", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Variant? PlatformData_ { set => SetProperty("platform-data", value); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Arguments']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.Runtime.CPtrArray<GISharp.Lib.GLib.Filename> Arguments { get => GetArguments(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Cwd']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.Lib.GLib.Filename? Cwd { get => GetCwd(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Environment']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.Runtime.FilenameArray Environment { get => GetEnvironment(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.ExitStatus']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public System.Int32 ExitStatus { get => GetExitStatus(); set => SetExitStatus(value); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.IsRemote']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public System.Boolean IsRemote { get => GetIsRemote(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Options']/*" />
        [GISharp.Runtime.SinceAttribute("2.40")]
        public GISharp.Lib.GLib.VariantDict Options { get => GetOptions(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.PlatformData']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public GISharp.Lib.GLib.Variant? PlatformData { get => GetPlatformData(); }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.Stdin']/*" />
        [GISharp.Runtime.SinceAttribute("2.34")]
        public GISharp.Lib.Gio.InputStream Stdin { get => GetStdin(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ApplicationCommandLine(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_application_command_line_get_type();

        /// <summary>
        /// Creates a #GFile corresponding to a filename that was given as part
        /// of the invocation of @cmdline.
        /// </summary>
        /// <remarks>
        /// This differs from g_file_new_for_commandline_arg() in that it
        /// resolves relative pathnames using the current working directory of
        /// the invoking process rather than the local process.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <param name="arg">
        /// an argument from @cmdline
        /// </param>
        /// <returns>
        /// a new #GFile
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="File" type="GFile*" managed-name="File" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_application_command_line_create_file_for_arg(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline,
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr arg);

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.CreateFileForArg(GISharp.Lib.GLib.Filename)']/*" />
        [GISharp.Runtime.SinceAttribute("2.36")]
        public unsafe GISharp.Lib.Gio.IFile CreateFileForArg(GISharp.Lib.GLib.Filename arg)
        {
            var cmdline_ = Handle;
            var arg_ = arg.Handle;
            var ret_ = g_application_command_line_create_file_for_arg(cmdline_,arg_);
            var ret = (GISharp.Lib.Gio.IFile)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Gets the list of arguments that was passed on the command line.
        /// </summary>
        /// <remarks>
        /// The strings in the array may contain non-UTF-8 data on UNIX (such as
        /// filenames or arguments given in the system locale) but are always in
        /// UTF-8 on Windows.
        /// 
        /// If you wish to use the return value with #GOptionContext, you must
        /// use g_option_context_parse_strv().
        /// 
        /// The return value is %NULL-terminated and should be freed using
        /// g_strfreev().
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <param name="argc">
        /// the length of the arguments array, or %NULL
        /// </param>
        /// <returns>
        /// 
        ///      the string array containing the arguments (the argv)
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="gchar**" null-terminated="1" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="filename" managed-name="GISharp.Lib.GLib.Filename" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr* g_application_command_line_get_arguments(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline,
        /* <type name="gint" type="int*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.Int32 argc);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe GISharp.Runtime.CPtrArray<GISharp.Lib.GLib.Filename> GetArguments()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_arguments(cmdline_,out var argc_);
            var ret = new GISharp.Runtime.CPtrArray<GISharp.Lib.GLib.Filename>((System.IntPtr)ret_, (int)argc_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the working directory of the command line invocation.
        /// The string may contain non-utf8 data.
        /// </summary>
        /// <remarks>
        /// It is possible that the remote application did not send a working
        /// directory, so this may be %NULL.
        /// 
        /// The return value should not be modified or freed and is valid for as
        /// long as @cmdline exists.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// the current directory, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:out */
        static extern unsafe System.IntPtr g_application_command_line_get_cwd(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe GISharp.Lib.GLib.Filename? GetCwd()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_cwd(cmdline_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Filename>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the contents of the 'environ' variable of the command line
        /// invocation, as would be returned by g_get_environ(), ie as a
        /// %NULL-terminated list of strings in the form 'NAME=VALUE'.
        /// The strings may contain non-utf8 data.
        /// </summary>
        /// <remarks>
        /// The remote application usually does not send an environment.  Use
        /// %G_APPLICATION_SEND_ENVIRONMENT to affect that.  Even with this flag
        /// set it is possible that the environment is still not available (due
        /// to invocation messages from other applications).
        /// 
        /// The return value should not be modified or freed and is valid for as
        /// long as @cmdline exists.
        /// 
        /// See g_application_command_line_getenv() if you are only interested
        /// in the value of a single environment variable.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// 
        ///     the environment strings, or %NULL if they were not sent
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="const gchar* const*" zero-terminated="1" managed-name="GISharp.Runtime.FilenameArray" is-pointer="1">
*   <type name="filename" managed-name="GISharp.Lib.GLib.Filename" />
* </array> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr* g_application_command_line_get_environ(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe GISharp.Runtime.FilenameArray GetEnvironment()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_environ(cmdline_);
            var ret = new GISharp.Runtime.FilenameArray((System.IntPtr)ret_, -1, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the exit status of @cmdline.  See
        /// g_application_command_line_set_exit_status() for more information.
        /// </summary>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// the exit status
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_application_command_line_get_exit_status(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe System.Int32 GetExitStatus()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_exit_status(cmdline_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Determines if @cmdline represents a remote invocation.
        /// </summary>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// %TRUE if the invocation was remote
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Runtime.Boolean g_application_command_line_get_is_remote(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe System.Boolean GetIsRemote()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_is_remote(cmdline_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the options there were passed to g_application_command_line().
        /// </summary>
        /// <remarks>
        /// If you did not override local_command_line() then these are the same
        /// options that were parsed according to the #GOptionEntrys added to the
        /// application with g_application_add_main_option_entries() and possibly
        /// modified from your GApplication::handle-local-options handler.
        /// 
        /// If no options were sent then an empty dictionary is returned so that
        /// you don't need to check for %NULL.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// a #GVariantDict with the options
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.VariantDict" type="GVariantDict*" managed-name="GISharp.Lib.GLib.VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_application_command_line_get_options_dict(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.40")]
        private unsafe GISharp.Lib.GLib.VariantDict GetOptions()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_options_dict(cmdline_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.VariantDict>(ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Gets the platform data associated with the invocation of @cmdline.
        /// </summary>
        /// <remarks>
        /// This is a #GVariant dictionary containing information about the
        /// context in which the invocation occurred.  It typically contains
        /// information like the current working directory and the startup
        /// notification ID.
        /// 
        /// For local invocation, it will be %NULL.
        /// </remarks>
        /// <param name="cmdline">
        /// #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// the platform data, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_application_command_line_get_platform_data(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe GISharp.Lib.GLib.Variant? GetPlatformData()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_platform_data(cmdline_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the stdin of the invoking process.
        /// </summary>
        /// <remarks>
        /// The #GInputStream can be used to read data passed to the standard
        /// input of the invoking process.
        /// This doesn't work on all platforms.  Presently, it is only available
        /// on UNIX when using a DBus daemon capable of passing file descriptors.
        /// If stdin is not available then %NULL will be returned.  In the
        /// future, support may be expanded to other platforms.
        /// 
        /// You must only call this function once per commandline invocation.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <returns>
        /// a #GInputStream for stdin
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="InputStream" type="GInputStream*" managed-name="InputStream" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_application_command_line_get_stdin(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline);

        [GISharp.Runtime.SinceAttribute("2.34")]
        private unsafe GISharp.Lib.Gio.InputStream GetStdin()
        {
            var cmdline_ = Handle;
            var ret_ = g_application_command_line_get_stdin(cmdline_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Gets the value of a particular environment variable of the command
        /// line invocation, as would be returned by g_getenv().  The strings may
        /// contain non-utf8 data.
        /// </summary>
        /// <remarks>
        /// The remote application usually does not send an environment.  Use
        /// %G_APPLICATION_SEND_ENVIRONMENT to affect that.  Even with this flag
        /// set it is possible that the environment is still not available (due
        /// to invocation messages from other applications).
        /// 
        /// The return value should not be modified or freed and is valid for as
        /// long as @cmdline exists.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <param name="name">
        /// the environment variable to get
        /// </param>
        /// <returns>
        /// the value of the variable, or %NULL if unset or unsent
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_application_command_line_getenv(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline,
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name);

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.GetEnvironmentVariable(GISharp.Lib.GLib.Filename)']/*" />
        [GISharp.Runtime.SinceAttribute("2.28")]
        public unsafe GISharp.Lib.GLib.UnownedUtf8 GetEnvironmentVariable(GISharp.Lib.GLib.Filename name)
        {
            var cmdline_ = Handle;
            var name_ = name.Handle;
            var ret_ = g_application_command_line_getenv(cmdline_,name_);
            var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_, -1);
            return ret;
        }

        /// <summary>
        /// Sets the exit status that will be used when the invoking process
        /// exits.
        /// </summary>
        /// <remarks>
        /// The return value of the #GApplication::command-line signal is
        /// passed to this function when the handler returns.  This is the usual
        /// way of setting the exit status.
        /// 
        /// In the event that you want the remote invocation to continue running
        /// and want to decide on the exit status in the future, you can use this
        /// call.  For the case of a remote invocation, the remote process will
        /// typically exit when the last reference is dropped on @cmdline.  The
        /// exit status of the remote process will be equal to the last value
        /// that was set with this function.
        /// 
        /// In the case that the commandline invocation is local, the situation
        /// is slightly more complicated.  If the commandline invocation results
        /// in the mainloop running (ie: because the use-count of the application
        /// increased to a non-zero value) then the application is considered to
        /// have been 'successful' in a certain sense, and the exit status is
        /// always zero.  If the application use count is zero, though, the exit
        /// status of the local #GApplicationCommandLine is used.
        /// </remarks>
        /// <param name="cmdline">
        /// a #GApplicationCommandLine
        /// </param>
        /// <param name="exitStatus">
        /// the exit status
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.28")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_application_command_line_set_exit_status(
        /* <type name="ApplicationCommandLine" type="GApplicationCommandLine*" managed-name="ApplicationCommandLine" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr cmdline,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 exitStatus);

        [GISharp.Runtime.SinceAttribute("2.28")]
        private unsafe void SetExitStatus(System.Int32 exitStatus)
        {
            var cmdline_ = Handle;
            var exitStatus_ = (System.Int32)exitStatus;
            g_application_command_line_set_exit_status(cmdline_, exitStatus_);
        }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.DoGetStdin()']/*" />
        [GISharp.Runtime.SinceAttribute("2.34")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ApplicationCommandLineClass.UnmanagedGetStdin))]
        protected virtual unsafe GISharp.Lib.Gio.InputStream DoGetStdin()
        {
            var cmdline_ = Handle;
            var ret_ = GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ApplicationCommandLineClass.UnmanagedGetStdin>(_GType)!(cmdline_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.InputStream>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.DoPrintLiteral(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ApplicationCommandLineClass.UnmanagedPrintLiteral))]
        protected virtual unsafe void DoPrintLiteral(GISharp.Lib.GLib.UnownedUtf8 message)
        {
            var cmdline_ = Handle;
            var message_ = message.Handle;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ApplicationCommandLineClass.UnmanagedPrintLiteral>(_GType)!(cmdline_, message_);
        }

        /// <include file="ApplicationCommandLine.xmldoc" path="declaration/member[@name='ApplicationCommandLine.DoPrinterrLiteral(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(ApplicationCommandLineClass.UnmanagedPrinterrLiteral))]
        protected virtual unsafe void DoPrinterrLiteral(GISharp.Lib.GLib.UnownedUtf8 message)
        {
            var cmdline_ = Handle;
            var message_ = message.Handle;
            GISharp.Lib.GObject.TypeClass.GetUnmanagedVirtualMethod<ApplicationCommandLineClass.UnmanagedPrinterrLiteral>(_GType)!(cmdline_, message_);
        }
    }
}