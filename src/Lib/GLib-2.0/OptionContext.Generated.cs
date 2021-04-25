// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext']/*" />
    public sealed unsafe partial class OptionContext : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.Description']/*" />
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Runtime.NullableUnownedUtf8 Description { get => GetDescription(); set => SetDescription(value); }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.HelpEnabled']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public bool HelpEnabled { get => GetHelpEnabled(); set => SetHelpEnabled(value); }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.IgnoreUnknownOptions']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public bool IgnoreUnknownOptions { get => GetIgnoreUnknownOptions(); set => SetIgnoreUnknownOptions(value); }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.MainGroup']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Lib.GLib.OptionGroup MainGroup { get => GetMainGroup(); set => SetMainGroup(value); }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.StrictPosix']/*" />
        [GISharp.Runtime.SinceAttribute("2.44")]
        public bool StrictPosix { get => GetStrictPosix(); set => SetStrictPosix(value); }

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.Summary']/*" />
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Runtime.NullableUnownedUtf8 Summary { get => GetSummary(); set => SetSummary(value); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionContext(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The @parameter_string can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the #GOptionContext, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the @arg_description of the corresponding #GOptionEntry in
        /// the usage summary.
        /// </para>
        /// <para>
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use g_option_context_set_summary().
        /// </para>
        /// <para>
        /// Note that the @parameter_string is translated using the
        /// function set with g_option_context_set_translate_func(), so
        /// it should normally be passed untranslated.
        /// </para>
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
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.OptionContext.UnmanagedStruct* g_option_context_new(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* parameterString);
        static partial void CheckNewArgs(GISharp.Runtime.NullableUnownedUtf8 parameterString);

        [GISharp.Runtime.SinceAttribute("2.6")]
        static GISharp.Lib.GLib.OptionContext.UnmanagedStruct* New(GISharp.Runtime.NullableUnownedUtf8 parameterString)
        {
            CheckNewArgs(parameterString);
            var parameterString_ = (byte*)parameterString.UnsafeHandle;
            var ret_ = g_option_context_new(parameterString_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_add_group(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="OptionGroup" type="GOptionGroup*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group);
        partial void CheckAddGroupArgs(GISharp.Lib.GLib.OptionGroup group);

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.AddGroup(GISharp.Lib.GLib.OptionGroup)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void AddGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            CheckAddGroupArgs(group);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var group_ = (GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*)group.Take();
            g_option_context_add_group(context_, group_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Frees context and all the groups which have been
        /// added to it.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Please note that parsed arguments need to be freed separately (see
        /// #GOptionEntry).
        /// </para>
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_free(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_option_context_free((UnmanagedStruct*)handle);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            base.Dispose(disposing);
        }

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
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_option_context_get_description(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetDescriptionArgs();

        [GISharp.Runtime.SinceAttribute("2.12")]
        private GISharp.Runtime.NullableUnownedUtf8 GetDescription()
        {
            CheckGetDescriptionArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_description(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.NullableUnownedUtf8(ret_);
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
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_option_context_get_help(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean mainHelp,
        /* <type name="OptionGroup" type="GOptionGroup*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group);
        partial void CheckGetHelpArgs(bool mainHelp, GISharp.Lib.GLib.OptionGroup? group);

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.GetHelp(bool,GISharp.Lib.GLib.OptionGroup?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.14")]
        public GISharp.Runtime.Utf8 GetHelp(bool mainHelp, GISharp.Lib.GLib.OptionGroup? group)
        {
            CheckGetHelpArgs(mainHelp, group);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var mainHelp_ = GISharp.Runtime.BooleanExtensions.ToBoolean(mainHelp);
            var group_ = (GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*)(group?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_option_context_get_help(context_,mainHelp_,group_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
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
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_option_context_get_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetHelpEnabledArgs();

        [GISharp.Runtime.SinceAttribute("2.6")]
        private bool GetHelpEnabled()
        {
            CheckGetHelpEnabledArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_help_enabled(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_option_context_get_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetIgnoreUnknownOptionsArgs();

        [GISharp.Runtime.SinceAttribute("2.6")]
        private bool GetIgnoreUnknownOptions()
        {
            CheckGetIgnoreUnknownOptionsArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_ignore_unknown_options(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* <type name="OptionGroup" type="GOptionGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* g_option_context_get_main_group(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetMainGroupArgs();

        [GISharp.Runtime.SinceAttribute("2.6")]
        private GISharp.Lib.GLib.OptionGroup GetMainGroup()
        {
            CheckGetMainGroupArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_main_group(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.OptionGroup.GetInstance<GISharp.Lib.GLib.OptionGroup>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See g_option_context_set_strict_posix() for more information.
        /// </para>
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if strict POSIX is enabled, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_option_context_get_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetStrictPosixArgs();

        [GISharp.Runtime.SinceAttribute("2.44")]
        private bool GetStrictPosix()
        {
            CheckGetStrictPosixArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_strict_posix(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_option_context_get_summary(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context);
        partial void CheckGetSummaryArgs();

        [GISharp.Runtime.SinceAttribute("2.12")]
        private GISharp.Runtime.NullableUnownedUtf8 GetSummary()
        {
            CheckGetSummaryArgs();
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_option_context_get_summary(context_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output after the list
        /// of options. This text often includes a bug reporting address.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func()).
        /// </para>
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_description(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* description);
        partial void CheckSetDescriptionArgs(GISharp.Runtime.NullableUnownedUtf8 description);

        [GISharp.Runtime.SinceAttribute("2.12")]
        private void SetDescription(GISharp.Runtime.NullableUnownedUtf8 description)
        {
            CheckSetDescriptionArgs(description);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var description_ = (byte*)description.UnsafeHandle;
            g_option_context_set_description(context_, description_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean helpEnabled);
        partial void CheckSetHelpEnabledArgs(bool helpEnabled);

        [GISharp.Runtime.SinceAttribute("2.6")]
        private void SetHelpEnabled(bool helpEnabled)
        {
            CheckSetHelpEnabledArgs(helpEnabled);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var helpEnabled_ = GISharp.Runtime.BooleanExtensions.ToBoolean(helpEnabled);
            g_option_context_set_help_enabled(context_, helpEnabled_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets whether to ignore unknown options or not. If an argument is
        /// ignored, it is left in the @argv array after parsing. By default,
        /// g_option_context_parse() treats unknown options as error.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This setting does not affect non-option arguments (i.e. arguments
        /// which don't start with a dash). But note that GOption cannot reliably
        /// determine whether a non-option belongs to a preceding unknown option.
        /// </para>
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean ignoreUnknown);
        partial void CheckSetIgnoreUnknownOptionsArgs(bool ignoreUnknown);

        [GISharp.Runtime.SinceAttribute("2.6")]
        private void SetIgnoreUnknownOptions(bool ignoreUnknown)
        {
            CheckSetIgnoreUnknownOptionsArgs(ignoreUnknown);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var ignoreUnknown_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ignoreUnknown);
            g_option_context_set_ignore_unknown_options(context_, ignoreUnknown_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_main_group(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="OptionGroup" type="GOptionGroup*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group);
        partial void CheckSetMainGroupArgs(GISharp.Lib.GLib.OptionGroup group);

        [GISharp.Runtime.SinceAttribute("2.6")]
        private void SetMainGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            CheckSetMainGroupArgs(group);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var group_ = (GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*)group.Take();
            g_option_context_set_main_group(context_, group_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets strict POSIX mode.
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, this mode is disabled.
        /// </para>
        /// <para>
        /// In strict POSIX mode, the first non-argument parameter encountered
        /// (eg: filename) terminates argument processing.  Remaining arguments
        /// are treated as non-options and are not attempted to be parsed.
        /// </para>
        /// <para>
        /// If strict POSIX mode is disabled then parsing is done in the GNU way
        /// where option arguments can be freely mixed with non-options.
        /// </para>
        /// <para>
        /// As an example, consider "ls foo -l".  With GNU style parsing, this
        /// will list "foo" in long mode.  In strict POSIX style, this will list
        /// the files named "foo" and "-l".
        /// </para>
        /// <para>
        /// It may be useful to force strict POSIX mode when creating "verb
        /// style" command line tools.  For example, the "gsettings" command line
        /// tool supports the global option "--schemadir" as well as many
        /// subcommands ("get", "set", etc.) which each have their own set of
        /// arguments.  Using strict POSIX mode will allow parsing the global
        /// options up to the verb name while leaving the remaining options to be
        /// parsed by the relevant subcommand (which can be determined by
        /// examining the verb name, which should be present in argv[1] after
        /// parsing).
        /// </para>
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="strictPosix">
        /// the new value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean strictPosix);
        partial void CheckSetStrictPosixArgs(bool strictPosix);

        [GISharp.Runtime.SinceAttribute("2.44")]
        private void SetStrictPosix(bool strictPosix)
        {
            CheckSetStrictPosixArgs(strictPosix);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var strictPosix_ = GISharp.Runtime.BooleanExtensions.ToBoolean(strictPosix);
            g_option_context_set_strict_posix(context_, strictPosix_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output before the list
        /// of options. This is typically a summary of the program functionality.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func() and
        /// g_option_context_set_translation_domain()).
        /// </para>
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_summary(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        byte* summary);
        partial void CheckSetSummaryArgs(GISharp.Runtime.NullableUnownedUtf8 summary);

        [GISharp.Runtime.SinceAttribute("2.12")]
        private void SetSummary(GISharp.Runtime.NullableUnownedUtf8 summary)
        {
            CheckSetSummaryArgs(summary);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var summary_ = (byte*)summary.UnsafeHandle;
            g_option_context_set_summary(context_, summary_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Sets the function which is used to translate the contexts
        /// user-visible strings, for `--help` output. If @func is %NULL,
        /// strings are not translated.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that option groups have their own translation functions,
        /// this function only affects the @parameter_string (see g_option_context_new()),
        /// the summary (see g_option_context_set_summary()) and the description
        /// (see g_option_context_set_description()).
        /// </para>
        /// <para>
        /// If you are using gettext(), you only need to set the translation
        /// domain, see g_option_context_set_translation_domain().
        /// </para>
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_translate_func(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="TranslateFunc" type="GTranslateFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        delegate* unmanaged[Cdecl]<byte*, System.IntPtr, byte*> func,
        /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        delegate* unmanaged[Cdecl]<System.IntPtr, void> destroyNotify);
        partial void CheckSetTranslateFuncArgs(GISharp.Lib.GLib.TranslateFunc? func);

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.12")]
        public void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc? func)
        {
            CheckSetTranslateFuncArgs(func);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var func_ = func is null ? default : (delegate* unmanaged[Cdecl]<byte*, System.IntPtr, byte*>)&GISharp.Lib.GLib.TranslateFuncMarshal.Callback;
            var funcHandle = func is null ? default : System.Runtime.InteropServices.GCHandle.Alloc((func, GISharp.Runtime.CallbackScope.Notified));
            var data_ = (System.IntPtr)funcHandle;
            var destroyNotify_ = func is null ? default : (delegate* unmanaged[Cdecl]<System.IntPtr, void>)&GISharp.Runtime.GMarshal.DestroyGCHandle;
            g_option_context_set_translate_func(context_, func_, data_, destroyNotify_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
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
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_option_context_set_translation_domain(
        /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* domain);
        partial void CheckSetTranslationDomainArgs(GISharp.Runtime.UnownedUtf8 domain);

        /// <include file="OptionContext.xmldoc" path="declaration/member[@name='OptionContext.SetTranslationDomain(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.12")]
        public void SetTranslationDomain(GISharp.Runtime.UnownedUtf8 domain)
        {
            CheckSetTranslationDomainArgs(domain);
            var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)UnsafeHandle;
            var domain_ = (byte*)domain.UnsafeHandle;
            g_option_context_set_translation_domain(context_, domain_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}