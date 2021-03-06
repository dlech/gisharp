// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon']/*" />
    [GISharp.Runtime.GTypeAttribute("GThemedIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(ThemedIconClass))]
    public unsafe partial class ThemedIcon : GISharp.Lib.GObject.Object, GISharp.Lib.Gio.IIcon
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_themed_icon_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.Name']/*" />
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [GISharp.Runtime.GPropertyAttribute("name", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8? Name { set => SetProperty("name", value); }

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.Names_']/*" />
        [GISharp.Runtime.GPropertyAttribute("names", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Strv? Names_ { get => (GISharp.Lib.GLib.Strv?)GetProperty("names")!; set => SetProperty("names", value); }

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.UseDefaultFallbacks']/*" />
        [GISharp.Runtime.GPropertyAttribute("use-default-fallbacks", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public System.Boolean UseDefaultFallbacks { get => (System.Boolean)GetProperty("use-default-fallbacks")!; set => SetProperty("use-default-fallbacks", value); }

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.Names']/*" />
        public GISharp.Lib.GLib.Strv Names { get => GetNames(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* g_themed_icon_new(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* iconname);
        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 iconname);

        static GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* New(GISharp.Lib.GLib.UnownedUtf8 iconname)
        {
            CheckNewArgs(iconname);
            var iconname_ = (byte*)iconname.UnsafeHandle;
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* g_themed_icon_new_from_names(
        /* <array length="1" zero-terminated="0" type="char**" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        byte** iconnames,
        /* <type name="gint" type="int" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int len);
        static partial void CheckNewFromNamesArgs(GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.GLib.Utf8> iconnames);

        static GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* NewFromNames(GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.GLib.Utf8> iconnames)
        {
            fixed (System.IntPtr* iconnamesData_ = iconnames)
            {
                CheckNewFromNamesArgs(iconnames);
                var iconnames_ = (byte**)iconnamesData_;
                var len_ = (int)iconnames.Length;
                var ret_ = g_themed_icon_new_from_names(iconnames_,len_);
                return ret_;
            }
        }

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.ThemedIcon(GISharp.Runtime.UnownedCPtrArray&lt;GISharp.Lib.GLib.Utf8&gt;)']/*" />
        public ThemedIcon(GISharp.Runtime.UnownedCPtrArray<GISharp.Lib.GLib.Utf8> iconnames) : this((System.IntPtr)NewFromNames(iconnames), GISharp.Runtime.Transfer.Full)
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
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* g_themed_icon_new_with_default_fallbacks(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* iconname);
        static partial void CheckNewWithDefaultFallbacksArgs(GISharp.Lib.GLib.UnownedUtf8 iconname);

        static GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* NewWithDefaultFallbacks(GISharp.Lib.GLib.UnownedUtf8 iconname)
        {
            CheckNewWithDefaultFallbacksArgs(iconname);
            var iconname_ = (byte*)iconname.UnsafeHandle;
            var ret_ = g_themed_icon_new_with_default_fallbacks(iconname_);
            return ret_;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_themed_icon_get_type();

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
        /* transfer-ownership:none direction:in */
        private static extern void g_themed_icon_append_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* iconname);
        partial void CheckAppendNameArgs(GISharp.Lib.GLib.UnownedUtf8 iconname);

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.AppendName(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public void AppendName(GISharp.Lib.GLib.UnownedUtf8 iconname)
        {
            CheckAppendNameArgs(iconname);
            var icon_ = (GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct*)UnsafeHandle;
            var iconname_ = (byte*)iconname.UnsafeHandle;
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
        /* <array type="const gchar* const*" zero-terminated="1" name="GLib.Strv" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" />
* </array> */
        /* transfer-ownership:none direction:in */
        private static extern byte** g_themed_icon_get_names(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* icon);
        partial void CheckGetNamesArgs();

        private GISharp.Lib.GLib.Strv GetNames()
        {
            CheckGetNamesArgs();
            var icon_ = (GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_themed_icon_get_names(icon_);
            var ret = new GISharp.Lib.GLib.Strv((System.IntPtr)ret_, -1, GISharp.Runtime.Transfer.None);
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
        /* transfer-ownership:none direction:in */
        private static extern void g_themed_icon_prepend_name(
        /* <type name="ThemedIcon" type="GThemedIcon*" managed-name="ThemedIcon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct* icon,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* iconname);
        partial void CheckPrependNameArgs(GISharp.Lib.GLib.UnownedUtf8 iconname);

        /// <include file="ThemedIcon.xmldoc" path="declaration/member[@name='ThemedIcon.PrependName(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.18")]
        public void PrependName(GISharp.Lib.GLib.UnownedUtf8 iconname)
        {
            CheckPrependNameArgs(iconname);
            var icon_ = (GISharp.Lib.Gio.ThemedIcon.UnmanagedStruct*)UnsafeHandle;
            var iconname_ = (byte*)iconname.UnsafeHandle;
            g_themed_icon_prepend_name(icon_, iconname_);
        }

        System.Boolean GISharp.Lib.Gio.IIcon.DoEqual(GISharp.Lib.Gio.IIcon? icon2)
        {
            throw new System.NotImplementedException();
        }

        uint GISharp.Lib.Gio.IIcon.DoHash()
        {
            throw new System.NotImplementedException();
        }

        GISharp.Lib.GLib.Variant GISharp.Lib.Gio.IIcon.DoSerialize()
        {
            throw new System.NotImplementedException();
        }
    }
}