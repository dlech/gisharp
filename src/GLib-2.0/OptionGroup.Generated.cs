// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="OptionGroup.xmldoc" path="declaration/member[@name='OptionGroup']/*" />
    [GISharp.Runtime.GTypeAttribute("GOptionGroup", IsProxyForUnmanagedType = true)]
    public sealed partial class OptionGroup : GISharp.Lib.GObject.Boxed
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_option_group_get_type();

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionGroup(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.GLib.UnownedUtf8 description, GISharp.Lib.GLib.UnownedUtf8 helpDescription, System.IntPtr userData, GISharp.Lib.GLib.DestroyNotify? destroy);

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
        private static extern unsafe System.IntPtr g_option_group_new(
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
        System.IntPtr destroy);
        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_option_group_get_type();

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
        private static extern unsafe void g_option_group_add_entries(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <array type="const GOptionEntry*" zero-terminated="1" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="OptionEntry" type="GOptionEntry" managed-name="OptionEntry" />
* </array> */
        /* transfer-ownership:none direction:in */
        in GISharp.Lib.GLib.OptionEntry entries);

        /// <summary>
        /// Increments the reference count of @group by one.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <returns>
        /// a #GOptionGroup
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_option_group_ref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
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
        private static extern unsafe void g_option_group_set_parse_hooks(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc? preParseFunc,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc? postParseFunc);

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
        private static extern unsafe void g_option_group_set_translate_func(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="TranslateFunc" type="GTranslateFunc" managed-name="UnmanagedTranslateFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        System.IntPtr func,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        System.IntPtr destroyNotify);
        static partial void CheckSetTranslateFuncArgs(GISharp.Lib.GLib.TranslateFunc? func);

        /// <include file="OptionGroup.xmldoc" path="declaration/member[@name='OptionGroup.SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc? func)
        {
            CheckSetTranslateFuncArgs(func);
            var group_ = Handle;
            var (func_, destroyNotify_, data_) = GISharp.Lib.GLib.TranslateFuncMarshal.ToUnmanagedFunctionPointer(func, GISharp.Runtime.CallbackScope.Notified);
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
        private static extern unsafe void g_option_group_set_translation_domain(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr domain);
        static partial void CheckSetTranslationDomainArgs(GISharp.Lib.GLib.UnownedUtf8 domain);

        /// <include file="OptionGroup.xmldoc" path="declaration/member[@name='OptionGroup.SetTranslationDomain(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslationDomain(GISharp.Lib.GLib.UnownedUtf8 domain)
        {
            CheckSetTranslationDomainArgs(domain);
            var group_ = Handle;
            var domain_ = domain.Handle;
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
        private static extern unsafe void g_option_group_unref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);
    }
}