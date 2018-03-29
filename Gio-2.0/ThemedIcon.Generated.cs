namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="ThemedIcon"/> is an implementation of <see cref="IIcon"/> that supports icon themes.
    /// <see cref="ThemedIcon"/> contains a list of all of the icons present in an icon
    /// theme, so that icons can be looked up quickly. <see cref="ThemedIcon"/> does
    /// not provide actual pixmaps for icons, just the icon names.
    /// Ideally something like gtk_icon_theme_choose_icon() should be used to
    /// resolve the list of names so that fallback icons work nicely with
    /// themes that inherit other themes.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GThemedIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ThemedIconClass))]
    public partial class ThemedIcon : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IIcon
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_themed_icon_get_type();

        /// <summary>
        /// The icon name.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8 Name { set => SetProperty("name", value); }

        /// <summary>
        /// A <c>null</c>-terminated array of icon names.
        /// </summary>
        [GISharp.Runtime.GPropertyAttribute("names", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Strv Names_ { get => (GISharp.Lib.GLib.Strv)GetProperty("names"); set => SetProperty("names", value); }

        /// <summary>
        /// Whether to use the default fallbacks found by shortening the icon name
        /// at '-' characters. If the "names" array has more than one element,
        /// ignores any past the first.
        /// </summary>
        /// <remarks>
        /// For example, if the icon name was "gnome-dev-cdrom-audio", the array
        /// would become
        /// |[&lt;!-- language="C" --&gt;
        /// {
        ///   "gnome-dev-cdrom-audio",
        ///   "gnome-dev-cdrom",
        ///   "gnome-dev",
        ///   "gnome",
        ///   NULL
        /// };
        /// ]|
        /// </remarks>
        [GISharp.Runtime.GPropertyAttribute("use-default-fallbacks", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public System.Boolean UseDefaultFallbacks { get => (System.Boolean)GetProperty("use-default-fallbacks"); set => SetProperty("use-default-fallbacks", value); }

        /// <summary>
        /// Gets the names of icons from within <paramref name="icon"/>.
        /// </summary>
        public GISharp.Lib.GLib.Strv Names { get => GetNames(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ThemedIcon(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new themed icon for @iconname.
        /// </summary>
        /// <param name="iconname">
        /// a string containing an icon name.
        /// </param>
        /// <returns>
        /// a new #GThemedIcon.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_themed_icon_new(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        static unsafe System.IntPtr New(GISharp.Lib.GLib.Utf8 iconname)
        {
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            var ret_ = g_themed_icon_new(iconname_);
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for @iconnames.
        /// </summary>
        /// <param name="iconnames">
        /// an array of strings containing icon names.
        /// </param>
        /// <param name="len">
        /// the length of the @iconnames array, or -1 if @iconnames is
        ///     %NULL-terminated
        /// </param>
        /// <returns>
        /// a new #GThemedIcon
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_themed_icon_new_from_names(
        /* <array length="1" zero-terminated="0" type="char**" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconnames,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 len);

        static unsafe System.IntPtr NewFromNames(GISharp.Runtime.IArray<GISharp.Lib.GLib.Utf8> iconnames)
        {
            var (iconnames_, len_) = ((System.IntPtr, System.Int32))((iconnames?.Data ?? throw new System.ArgumentNullException(nameof(iconnames)), iconnames?.Length ?? 0));
            var ret_ = g_themed_icon_new_from_names(iconnames_,len_);
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for <paramref name="iconnames"/>.
        /// </summary>
        /// <param name="iconnames">
        /// an array of strings containing icon names.
        /// </param>
        public ThemedIcon(GISharp.Runtime.IArray<GISharp.Lib.GLib.Utf8> iconnames) : this(NewFromNames(iconnames), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new themed icon for @iconname, and all the names
        /// that can be created by shortening @iconname at '-' characters.
        /// </summary>
        /// <remarks>
        /// In the following example, @icon1 and @icon2 are equivalent:
        /// |[&lt;!-- language="C" --&gt;
        /// const char *names[] = {
        ///   "gnome-dev-cdrom-audio",
        ///   "gnome-dev-cdrom",
        ///   "gnome-dev",
        ///   "gnome"
        /// };
        /// 
        /// icon1 = g_themed_icon_new_from_names (names, 4);
        /// icon2 = g_themed_icon_new_with_default_fallbacks ("gnome-dev-cdrom-audio");
        /// ]|
        /// </remarks>
        /// <param name="iconname">
        /// a string containing an icon name
        /// </param>
        /// <returns>
        /// a new #GThemedIcon.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ThemedIcon" type="GIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_themed_icon_new_with_default_fallbacks(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        static unsafe System.IntPtr NewWithDefaultFallbacks(GISharp.Lib.GLib.Utf8 iconname)
        {
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            var ret_ = g_themed_icon_new_with_default_fallbacks(iconname_);
            return ret_;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_themed_icon_get_type();

        /// <summary>
        /// Append a name to the list of icons from within @icon.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to g_icon_hash().
        /// </remarks>
        /// <param name="icon">
        /// a #GThemedIcon
        /// </param>
        /// <param name="iconname">
        /// name of icon to append to list of icons from within @icon.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_themed_icon_append_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        /// <summary>
        /// Append a name to the list of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to <see cref="IIcon.GetHashCode"/>.
        /// </remarks>
        /// <param name="iconname">
        /// name of icon to append to list of icons from within <paramref name="icon"/>.
        /// </param>
        public unsafe void AppendName(GISharp.Lib.GLib.Utf8 iconname)
        {
            var icon_ = Handle;
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            g_themed_icon_append_name(icon_, iconname_);
        }

        /// <summary>
        /// Gets the names of icons from within @icon.
        /// </summary>
        /// <param name="icon">
        /// a #GThemedIcon.
        /// </param>
        /// <returns>
        /// a list of icon names.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="const gchar* const*" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_themed_icon_get_names(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Gets the names of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <returns>
        /// a list of icon names.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Strv GetNames()
        {
            var icon_ = Handle;
            var ret_ = g_themed_icon_get_names(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Prepend a name to the list of icons from within @icon.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to g_icon_hash().
        /// </remarks>
        /// <param name="icon">
        /// a #GThemedIcon
        /// </param>
        /// <param name="iconname">
        /// name of icon to prepend to list of icons from within @icon.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.18")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_themed_icon_prepend_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr iconname);

        /// <summary>
        /// Prepend a name to the list of icons from within <paramref name="icon"/>.
        /// </summary>
        /// <remarks>
        /// Note that doing so invalidates the hash computed by prior calls
        /// to <see cref="IIcon.GetHashCode"/>.
        /// </remarks>
        /// <param name="iconname">
        /// name of icon to prepend to list of icons from within <paramref name="icon"/>.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.18")]
        public unsafe void PrependName(GISharp.Lib.GLib.Utf8 iconname)
        {
            var icon_ = Handle;
            var iconname_ = iconname?.Handle ?? throw new System.ArgumentNullException(nameof(iconname));
            g_themed_icon_prepend_name(icon_, iconname_);
        }

        System.Boolean GISharp.Lib.Gio.IIcon.DoEqual(GISharp.Lib.Gio.IIcon icon2)
        {
            throw new System.NotImplementedException();
        }

        System.UInt32 GISharp.Lib.Gio.IIcon.DoHash()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IIcon.DoSerialize()
        {
            throw new System.NotImplementedException();
        }
    }
}