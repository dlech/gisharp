namespace GISharp.Lib.GLib
{
    /// <summary>
    /// A `GOptionGroup` struct defines the options in a single
    /// group. The struct has only private fields and should not be directly accessed.
    /// </summary>
    /// <remarks>
    /// All options in a group share the same translation function. Libraries which
    /// need to parse commandline options are expected to provide a function for
    /// getting a `GOptionGroup` holding their options, which
    /// the application can then add to its <see cref="OptionContext"/>.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GOptionGroup", IsProxyForUnmanagedType = true)]
    public sealed partial class OptionGroup : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_option_group_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionGroup(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GOptionGroup.
        /// </summary>
        /// <param name="name">
        /// the name for the option group, this is used to provide
        ///   help for the options in this group with `--help-`@name
        /// </param>
        /// <param name="description">
        /// a description for this group to be shown in
        ///   `--help`. This string is translated using the translation
        ///   domain or translation function of the group
        /// </param>
        /// <param name="helpDescription">
        /// a description for the `--help-`@name option.
        ///   This string is translated using the translation domain or translation function
        ///   of the group
        /// </param>
        /// <param name="userData">
        /// user data that will be passed to the pre- and post-parse hooks,
        ///   the error hook and to callbacks of %G_OPTION_ARG_CALLBACK options, or %NULL
        /// </param>
        /// <param name="destroy">
        /// a function that will be called to free @user_data, or %NULL
        /// </param>
        /// <returns>
        /// a newly created option group. It should be added
        ///   to a #GOptionContext or freed with g_option_group_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_group_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr description,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr helpDescription,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify destroy);
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_option_group_get_type();

        /// <summary>
        /// Adds the options specified in @entries to @group.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="entries">
        /// a %NULL-terminated array of #GOptionEntrys
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_add_entries(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <array zero-terminated="1" type="GOptionEntry*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="OptionEntry" type="1" managed-name="OptionEntry" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr entries);

        /// <summary>
        /// Increments the reference count of @group by one.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <returns>
        /// a #GoptionGroup
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_group_ref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);
        public override System.IntPtr Take() => g_option_group_ref(Handle);

        /// <summary>
        /// Associates two functions with @group which will be called
        /// from g_option_context_parse() before the first option is parsed
        /// and after the last option has been parsed, respectively.
        /// </summary>
        /// <remarks>
        /// Note that the user data to be passed to @pre_parse_func and
        /// @post_parse_func can be specified when constructing the group
        /// with g_option_group_new().
        /// </remarks>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="preParseFunc">
        /// a function to call before parsing, or %NULL
        /// </param>
        /// <param name="postParseFunc">
        /// a function to call after parsing, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_parse_hooks(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc preParseFunc,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc postParseFunc);

        /// <summary>
        /// Sets the function which is used to translate user-visible strings,
        /// for `--help` output. Different groups can use different
        /// #GTranslateFuncs. If @func is %NULL, strings are not translated.
        /// </summary>
        /// <remarks>
        /// If you are using gettext(), you only need to set the translation
        /// domain, see g_option_group_set_translation_domain().
        /// </remarks>
        /// <param name="group">
        /// a #GOptionGroup
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
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_translate_func(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
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
        /// Sets the function which is used to translate user-visible strings,
        /// for `--help` output. Different groups can use different
        /// #GTranslateFuncs. If <paramref name="func"/> is <c>null</c>, strings are not translated.
        /// </summary>
        /// <remarks>
        /// If you are using gettext(), you only need to set the translation
        /// domain, see <see cref="OptionGroup.SetTranslationDomain"/>.
        /// </remarks>
        /// <param name="func">
        /// the <see cref="TranslateFunc"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc func)
        {
            var group_ = Handle;
            var (func_, destroyNotify_, data_) = func == null ? (default(GISharp.Lib.GLib.UnmanagedTranslateFunc), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.GLib.TranslateFuncFactory.Create(func, GISharp.Runtime.CallbackScope.Notified);
            g_option_group_set_translate_func(group_, func_, data_, destroyNotify_);
        }

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_translation_domain(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
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
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslationDomain(GISharp.Lib.GLib.Utf8 domain)
        {
            var group_ = Handle;
            var domain_ = domain?.Handle ?? throw new System.ArgumentNullException(nameof(domain));
            g_option_group_set_translation_domain(group_, domain_);
        }

        /// <summary>
        /// Decrements the reference count of @group by one.
        /// If the reference count drops to 0, the @group will be freed.
        /// and all memory allocated by the @group is released.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_unref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);
    }
}