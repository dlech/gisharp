namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A `GOptionContext` struct defines which options
    /// are accepted by the commandline option parser. The struct has only private
    /// fields and should not be directly accessed.
    /// </summary>
    public sealed partial class OptionContext : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// Returns the description. See <see cref="OptionContext.SetDescription"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Lib.GLib.Utf8 Description { get => GetDescription(); set => SetDescription(value); }

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for <paramref name="context"/>. See <see cref="OptionContext.SetHelpEnabled"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean HelpEnabled { get => GetHelpEnabled(); set => SetHelpEnabled(value); }

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// <see cref="OptionContext.SetIgnoreUnknownOptions"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean IgnoreUnknownOptions { get => GetIgnoreUnknownOptions(); set => SetIgnoreUnknownOptions(value); }

        /// <summary>
        /// Returns a pointer to the main group of <paramref name="context"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Lib.GLib.OptionGroup MainGroup { get => GetMainGroup(); set => SetMainGroup(value); }

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See <see cref="OptionContext.SetStrictPosix"/> for more information.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public System.Boolean StrictPosix { get => GetStrictPosix(); set => SetStrictPosix(value); }

        /// <summary>
        /// Returns the summary. See <see cref="OptionContext.SetSummary"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Lib.GLib.Utf8 Summary { get => GetSummary(); set => SetSummary(value); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionContext(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// The @parameter_string can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the #GOptionContext, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the @arg_description of the corresponding #GOptionEntry in
        /// the usage summary.
        /// 
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use g_option_context_set_summary().
        /// 
        /// Note that the @parameter_string is translated using the
        /// function set with g_option_context_set_translate_func(), so
        /// it should normally be passed untranslated.
        /// </remarks>
        /// <param name="parameterString">
        /// a string which is displayed in
        ///    the first line of `--help` output, after the usage summary
        ///    `programname [OPTION...]`
        /// </param>
        /// <returns>
        /// a newly created #GOptionContext, which must be
        ///    freed with g_option_context_free() after use.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_context_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterString);

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// The <paramref name="parameterString"/> can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the <see cref="OptionContext"/>, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the <paramref name="argDescription"/> of the corresponding <see cref="OptionEntry"/> in
        /// the usage summary.
        /// 
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use <see cref="OptionContext.SetSummary"/>.
        /// 
        /// Note that the <paramref name="parameterString"/> is translated using the
        /// function set with <see cref="OptionContext.SetTranslateFunc"/>, so
        /// it should normally be passed untranslated.
        /// </remarks>
        /// <param name="parameterString">
        /// a string which is displayed in
        ///    the first line of `--help` output, after the usage summary
        ///    `programname [OPTION...]`
        /// </param>
        /// <returns>
        /// a newly created <see cref="OptionContext"/>, which must be
        ///    freed with <see cref="OptionContext.Free"/> after use.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.Utf8 parameterString)
        {
            var parameterString_ = parameterString?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_option_context_new(parameterString_);
            return ret_;
        }

        /// <summary>
        /// Adds a #GOptionGroup to the @context, so that parsing with @context
        /// will recognize the options in the group. Note that this will take
        /// ownership of the @group and thus the @group should not be freed.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="group">
        /// the group to add
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_add_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr group);

        /// <summary>
        /// Adds a <see cref="OptionGroup"/> to the <paramref name="context"/>, so that parsing with <paramref name="context"/>
        /// will recognize the options in the group. Note that this will take
        /// ownership of the <paramref name="group"/> and thus the <paramref name="group"/> should not be freed.
        /// </summary>
        /// <param name="group">
        /// the group to add
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void AddGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var group_ = group?.Take() ?? throw new System.ArgumentNullException(nameof(group));
            g_option_context_add_group(context_, group_);
        }

        /// <summary>
        /// Frees context and all the groups which have been
        /// added to it.
        /// </summary>
        /// <remarks>
        /// Please note that parsed arguments need to be freed separately (see
        /// #GOptionEntry).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_free(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the description. See g_option_context_set_description().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the description
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_description(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the description. See <see cref="OptionContext.SetDescription"/>.
        /// </summary>
        /// <returns>
        /// the description
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe GISharp.Lib.GLib.Utf8 GetDescription()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_description(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Returns a formatted, translated help text for the given context.
        /// To obtain the text produced by `--help`, call
        /// `g_option_context_get_help (context, TRUE, NULL)`.
        /// To obtain the text produced by `--help-all`, call
        /// `g_option_context_get_help (context, FALSE, NULL)`.
        /// To obtain the help text for an option group, call
        /// `g_option_context_get_help (context, FALSE, group)`.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="mainHelp">
        /// if %TRUE, only include the main group
        /// </param>
        /// <param name="group">
        /// the #GOptionGroup to create help for, or %NULL
        /// </param>
        /// <returns>
        /// A newly allocated string containing the help text
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_context_get_help(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean mainHelp,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr group);

        /// <summary>
        /// Returns a formatted, translated help text for the given context.
        /// To obtain the text produced by `--help`, call
        /// `g_option_context_get_help (context, TRUE, NULL)`.
        /// To obtain the text produced by `--help-all`, call
        /// `g_option_context_get_help (context, FALSE, NULL)`.
        /// To obtain the help text for an option group, call
        /// `g_option_context_get_help (context, FALSE, group)`.
        /// </summary>
        /// <param name="mainHelp">
        /// if <c>true</c>, only include the main group
        /// </param>
        /// <param name="group">
        /// the <see cref="OptionGroup"/> to create help for, or <c>null</c>
        /// </param>
        /// <returns>
        /// A newly allocated string containing the help text
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public unsafe GISharp.Lib.GLib.Utf8 GetHelp(System.Boolean mainHelp, GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var mainHelp_ = (System.Boolean)mainHelp;
            var group_ = group?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_option_context_get_help(context_,mainHelp_,group_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for @context. See g_option_context_set_help_enabled().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if automatic help generation is turned on.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for <paramref name="context"/>. See <see cref="OptionContext.SetHelpEnabled"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if automatic help generation is turned on.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe System.Boolean GetHelpEnabled()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_help_enabled(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// g_option_context_set_ignore_unknown_options().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if unknown options are ignored.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// <see cref="OptionContext.SetIgnoreUnknownOptions"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if unknown options are ignored.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe System.Boolean GetIgnoreUnknownOptions()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_ignore_unknown_options(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns a pointer to the main group of @context.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the main group of @context, or %NULL if
        ///  @context doesn't have a main group. Note that group belongs to
        ///  @context and should not be modified or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_main_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns a pointer to the main group of <paramref name="context"/>.
        /// </summary>
        /// <returns>
        /// the main group of <paramref name="context"/>, or <c>null</c> if
        ///  <paramref name="context"/> doesn't have a main group. Note that group belongs to
        ///  <paramref name="context"/> and should not be modified or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe GISharp.Lib.GLib.OptionGroup GetMainGroup()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_main_group(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionGroup>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See g_option_context_set_strict_posix() for more information.
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if strict POSIX is enabled, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See <see cref="OptionContext.SetStrictPosix"/> for more information.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if strict POSIX is enabled, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private unsafe System.Boolean GetStrictPosix()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_strict_posix(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the summary. See g_option_context_set_summary().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the summary
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_summary(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the summary. See <see cref="OptionContext.SetSummary"/>.
        /// </summary>
        /// <returns>
        /// the summary
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe GISharp.Lib.GLib.Utf8 GetSummary()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_summary(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output after the list
        /// of options. This text often includes a bug reporting address.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func()).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="description">
        /// a string to be shown in `--help` output
        ///   after the list of options, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_description(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr description);

        /// <summary>
        /// Adds a string to be displayed in `--help` output after the list
        /// of options. This text often includes a bug reporting address.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// <see cref="OptionContext.SetTranslateFunc"/>).
        /// </remarks>
        /// <param name="description">
        /// a string to be shown in `--help` output
        ///   after the list of options, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe void SetDescription(GISharp.Lib.GLib.Utf8 description)
        {
            var context_ = Handle;
            var description_ = description?.Handle ?? System.IntPtr.Zero;
            g_option_context_set_description(context_, description_);
        }

        /// <summary>
        /// Enables or disables automatic generation of `--help` output.
        /// By default, g_option_context_parse() recognizes `--help`, `-h`,
        /// `-?`, `--help-all` and `--help-groupname` and creates suitable
        /// output to stdout.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="helpEnabled">
        /// %TRUE to enable `--help`, %FALSE to disable it
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean helpEnabled);

        /// <summary>
        /// Enables or disables automatic generation of `--help` output.
        /// By default, g_option_context_parse() recognizes `--help`, `-h`,
        /// `-?`, `--help-all` and `--help-groupname` and creates suitable
        /// output to stdout.
        /// </summary>
        /// <param name="helpEnabled">
        /// <c>true</c> to enable `--help`, <c>false</c> to disable it
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetHelpEnabled(System.Boolean helpEnabled)
        {
            var context_ = Handle;
            var helpEnabled_ = (System.Boolean)helpEnabled;
            g_option_context_set_help_enabled(context_, helpEnabled_);
        }

        /// <summary>
        /// Sets whether to ignore unknown options or not. If an argument is
        /// ignored, it is left in the @argv array after parsing. By default,
        /// g_option_context_parse() treats unknown options as error.
        /// </summary>
        /// <remarks>
        /// This setting does not affect non-option arguments (i.e. arguments
        /// which don't start with a dash). But note that GOption cannot reliably
        /// determine whether a non-option belongs to a preceding unknown option.
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="ignoreUnknown">
        /// %TRUE to ignore unknown options, %FALSE to produce
        ///    an error when unknown options are met
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean ignoreUnknown);

        /// <summary>
        /// Sets whether to ignore unknown options or not. If an argument is
        /// ignored, it is left in the <paramref name="argv"/> array after parsing. By default,
        /// g_option_context_parse() treats unknown options as error.
        /// </summary>
        /// <remarks>
        /// This setting does not affect non-option arguments (i.e. arguments
        /// which don't start with a dash). But note that GOption cannot reliably
        /// determine whether a non-option belongs to a preceding unknown option.
        /// </remarks>
        /// <param name="ignoreUnknown">
        /// <c>true</c> to ignore unknown options, <c>false</c> to produce
        ///    an error when unknown options are met
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetIgnoreUnknownOptions(System.Boolean ignoreUnknown)
        {
            var context_ = Handle;
            var ignoreUnknown_ = (System.Boolean)ignoreUnknown;
            g_option_context_set_ignore_unknown_options(context_, ignoreUnknown_);
        }

        /// <summary>
        /// Sets a #GOptionGroup as main group of the @context.
        /// This has the same effect as calling g_option_context_add_group(),
        /// the only difference is that the options in the main group are
        /// treated differently when generating `--help` output.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="group">
        /// the group to set as main group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_main_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr group);

        /// <summary>
        /// Sets a <see cref="OptionGroup"/> as main group of the <paramref name="context"/>.
        /// This has the same effect as calling <see cref="OptionContext.AddGroup"/>,
        /// the only difference is that the options in the main group are
        /// treated differently when generating `--help` output.
        /// </summary>
        /// <param name="group">
        /// the group to set as main group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetMainGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var group_ = group?.Take() ?? throw new System.ArgumentNullException(nameof(group));
            g_option_context_set_main_group(context_, group_);
        }

        /// <summary>
        /// Sets strict POSIX mode.
        /// </summary>
        /// <remarks>
        /// By default, this mode is disabled.
        /// 
        /// In strict POSIX mode, the first non-argument parameter encountered
        /// (eg: filename) terminates argument processing.  Remaining arguments
        /// are treated as non-options and are not attempted to be parsed.
        /// 
        /// If strict POSIX mode is disabled then parsing is done in the GNU way
        /// where option arguments can be freely mixed with non-options.
        /// 
        /// As an example, consider "ls foo -l".  With GNU style parsing, this
        /// will list "foo" in long mode.  In strict POSIX style, this will list
        /// the files named "foo" and "-l".
        /// 
        /// It may be useful to force strict POSIX mode when creating "verb
        /// style" command line tools.  For example, the "gsettings" command line
        /// tool supports the global option "--schemadir" as well as many
        /// subcommands ("get", "set", etc.) which each have their own set of
        /// arguments.  Using strict POSIX mode will allow parsing the global
        /// options up to the verb name while leaving the remaining options to be
        /// parsed by the relevant subcommand (which can be determined by
        /// examining the verb name, which should be present in argv[1] after
        /// parsing).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="strictPosix">
        /// the new value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean strictPosix);

        /// <summary>
        /// Sets strict POSIX mode.
        /// </summary>
        /// <remarks>
        /// By default, this mode is disabled.
        /// 
        /// In strict POSIX mode, the first non-argument parameter encountered
        /// (eg: filename) terminates argument processing.  Remaining arguments
        /// are treated as non-options and are not attempted to be parsed.
        /// 
        /// If strict POSIX mode is disabled then parsing is done in the GNU way
        /// where option arguments can be freely mixed with non-options.
        /// 
        /// As an example, consider "ls foo -l".  With GNU style parsing, this
        /// will list "foo" in long mode.  In strict POSIX style, this will list
        /// the files named "foo" and "-l".
        /// 
        /// It may be useful to force strict POSIX mode when creating "verb
        /// style" command line tools.  For example, the "gsettings" command line
        /// tool supports the global option "--schemadir" as well as many
        /// subcommands ("get", "set", etc.) which each have their own set of
        /// arguments.  Using strict POSIX mode will allow parsing the global
        /// options up to the verb name while leaving the remaining options to be
        /// parsed by the relevant subcommand (which can be determined by
        /// examining the verb name, which should be present in argv[1] after
        /// parsing).
        /// </remarks>
        /// <param name="strictPosix">
        /// the new value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private unsafe void SetStrictPosix(System.Boolean strictPosix)
        {
            var context_ = Handle;
            var strictPosix_ = (System.Boolean)strictPosix;
            g_option_context_set_strict_posix(context_, strictPosix_);
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output before the list
        /// of options. This is typically a summary of the program functionality.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func() and
        /// g_option_context_set_translation_domain()).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="summary">
        /// a string to be shown in `--help` output
        ///  before the list of options, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_summary(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr summary);

        /// <summary>
        /// Adds a string to be displayed in `--help` output before the list
        /// of options. This is typically a summary of the program functionality.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// <see cref="OptionContext.SetTranslateFunc"/> and
        /// <see cref="OptionContext.SetTranslationDomain"/>).
        /// </remarks>
        /// <param name="summary">
        /// a string to be shown in `--help` output
        ///  before the list of options, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe void SetSummary(GISharp.Lib.GLib.Utf8 summary)
        {
            var context_ = Handle;
            var summary_ = summary?.Handle ?? System.IntPtr.Zero;
            g_option_context_set_summary(context_, summary_);
        }

        /// <summary>
        /// Sets the function which is used to translate the contexts
        /// user-visible strings, for `--help` output. If @func is %NULL,
        /// strings are not translated.
        /// </summary>
        /// <remarks>
        /// Note that option groups have their own translation functions,
        /// this function only affects the @parameter_string (see g_option_context_new()),
        /// the summary (see g_option_context_set_summary()) and the description
        /// (see g_option_context_set_description()).
        /// 
        /// If you are using gettext(), you only need to set the translation
        /// domain, see g_option_context_set_translation_domain().
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="func">
        /// the #GTranslateFunc, or %NULL
        /// </param>
        /// <param name="data">
        /// user data to pass to @func, or %NULL
        /// </param>
        /// <param name="destroyNotify">
        /// a function which gets called to free @data, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_translate_func(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="TranslateFunc" type="GTranslateFunc" managed-name="UnmanagedTranslateFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        GISharp.Lib.GLib.UnmanagedTranslateFunc func,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify destroyNotify);

        /// <summary>
        /// Sets the function which is used to translate the contexts
        /// user-visible strings, for `--help` output. If <paramref name="func"/> is <c>null</c>,
        /// strings are not translated.
        /// </summary>
        /// <remarks>
        /// Note that option groups have their own translation functions,
        /// this function only affects the <paramref name="parameterString"/> (see <see cref="OptionContext.New"/>),
        /// the summary (see <see cref="OptionContext.SetSummary"/>) and the description
        /// (see <see cref="OptionContext.SetDescription"/>).
        /// 
        /// If you are using gettext(), you only need to set the translation
        /// domain, see <see cref="OptionContext.SetTranslationDomain"/>.
        /// </remarks>
        /// <param name="func">
        /// the <see cref="TranslateFunc"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc func)
        {
            var context_ = Handle;
            var (func_, destroyNotify_, data_) = func == null ? (default(GISharp.Lib.GLib.UnmanagedTranslateFunc), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.GLib.TranslateFuncFactory.Create(func, GISharp.Runtime.CallbackScope.Notified);
            g_option_context_set_translate_func(context_, func_, data_, destroyNotify_);
        }

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_translation_domain(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr domain);

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetTranslationDomain(GISharp.Lib.GLib.Utf8 domain)
        {
            var context_ = Handle;
            var domain_ = domain?.Handle ?? throw new System.ArgumentNullException(nameof(domain));
            g_option_context_set_translation_domain(context_, domain_);
        }
    }
}