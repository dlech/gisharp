namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="IIcon"/> is a very minimal interface for icons. It provides functions
    /// for checking the equality of two icons, hashing of icons and
    /// serializing an icon to and from strings.
    /// </summary>
    /// <remarks>
    /// <see cref="IIcon"/> does not provide the actual pixmap for the icon as this is out
    /// of GIO's scope, however implementations of <see cref="IIcon"/> may contain the name
    /// of an icon (see <see cref="ThemedIcon"/>), or the path to an icon (see #GLoadableIcon).
    /// 
    /// To obtain a hash of a <see cref="IIcon"/>, see <see cref="IIcon.GetHashCode"/>.
    /// 
    /// To check if two <see cref="IIcon"/>s are equal, see <see cref="IIcon.Equals"/>.
    /// 
    /// For serializing a <see cref="IIcon"/>, use <see cref="IIcon.Serialize"/> and
    /// <see cref="IIcon.Deserialize"/>.
    /// 
    /// If you want to consume <see cref="IIcon"/> (for example, in a toolkit) you must
    /// be prepared to handle at least the three following cases:
    /// #GLoadableIcon, <see cref="ThemedIcon"/> and #GEmblemedIcon.  It may also make
    /// sense to have fast-paths for other cases (like handling #GdkPixbuf
    /// directly, for example) but all compliant <see cref="IIcon"/> implementations
    /// outside of GIO must implement #GLoadableIcon.
    /// 
    /// If your application or library provides one or more <see cref="IIcon"/>
    /// implementations you need to ensure that your new implementation also
    /// implements #GLoadableIcon.  Additionally, you must provide an
    /// implementation of <see cref="IIcon.Serialize"/> that gives a result that is
    /// understood by <see cref="IIcon.Deserialize"/>, yielding one of the built-in icon
    /// types.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(IconIface))]
    public partial interface IIcon : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon2">
        /// pointer to the second <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="icon1"/> is equal to <paramref name="icon2"/>. <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedEqual))]
        System.Boolean DoEqual(GISharp.Lib.Gio.IIcon icon2);

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <returns>
        /// a #guint containing a hash for the <paramref name="icon"/>, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedHash))]
        System.UInt32 DoHash();

        /// <summary>
        /// Serializes a <see cref="IIcon"/> into a #GVariant. An equivalent <see cref="IIcon"/> can be retrieved
        /// back by calling <see cref="IIcon.Deserialize"/> on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <returns>
        /// a #GVariant, or <c>null</c> when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedSerialize))]
        GISharp.Lib.GLib.Variant DoSerialize();
    }

    public static class Icon
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_icon_get_type();

        /// <summary>
        /// Deserializes a #GIcon previously serialized using g_icon_serialize().
        /// </summary>
        /// <param name="value">
        /// a #GVariant created with g_icon_serialize()
        /// </param>
        /// <returns>
        /// a #GIcon, or %NULL when deserialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_icon_deserialize(
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Deserializes a <see cref="IIcon"/> previously serialized using <see cref="IIcon.Serialize"/>.
        /// </summary>
        /// <param name="value">
        /// a #GVariant created with <see cref="IIcon.Serialize"/>
        /// </param>
        /// <returns>
        /// a <see cref="IIcon"/>, or <c>null</c> when deserialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static unsafe GISharp.Lib.Gio.IIcon Deserialize(GISharp.Lib.GLib.Variant value)
        {
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            var ret_ = g_icon_deserialize(value_);
            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generate a #GIcon instance from @str. This function can fail if
        /// @str is not valid - see g_icon_to_string() for discussion.
        /// </summary>
        /// <remarks>
        /// If your application or library provides one or more #GIcon
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling g_icon_new_for_string().
        /// </remarks>
        /// <param name="str">
        /// A string obtained via g_icon_to_string().
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// An object implementing the #GIcon
        ///          interface or %NULL if @error is set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_icon_new_for_string(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr str,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Generate a <see cref="IIcon"/> instance from <paramref name="str"/>. This function can fail if
        /// <paramref name="str"/> is not valid - see <see cref="IIcon.ToString"/> for discussion.
        /// </summary>
        /// <remarks>
        /// If your application or library provides one or more <see cref="IIcon"/>
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling <see cref="IIcon.NewForString"/>.
        /// </remarks>
        /// <param name="str">
        /// A string obtained via <see cref="IIcon.ToString"/>.
        /// </param>
        /// <returns>
        /// An object implementing the <see cref="IIcon"/>
        ///          interface or <c>null</c> if <paramref name="error"/> is set.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static unsafe GISharp.Lib.Gio.IIcon NewForString(GISharp.Lib.GLib.Utf8 str)
        {
            var str_ = str?.Handle ?? throw new System.ArgumentNullException(nameof(str));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_icon_new_for_string(str_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_icon_get_type();

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <param name="icon">
        /// #gconstpointer to an icon object.
        /// </param>
        /// <returns>
        /// a #guint containing a hash for the @icon, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.UInt32 g_icon_hash(
        /* <type name="Icon" type="gconstpointer" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <param name="icon">
        /// #gconstpointer to an icon object.
        /// </param>
        /// <returns>
        /// a #guint containing a hash for the <paramref name="icon"/>, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        public unsafe static System.Int32 GetHashCode(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_hash(icon_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon1">
        /// pointer to the first #GIcon.
        /// </param>
        /// <param name="icon2">
        /// pointer to the second #GIcon.
        /// </param>
        /// <returns>
        /// %TRUE if @icon1 is equal to @icon2. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_icon_equal(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon1,
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon2);

        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon1">
        /// pointer to the first <see cref="IIcon"/>.
        /// </param>
        /// <param name="icon2">
        /// pointer to the second <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="icon1"/> is equal to <paramref name="icon2"/>. <c>false</c> otherwise.
        /// </returns>
        public unsafe static System.Boolean Equals(this GISharp.Lib.Gio.IIcon icon1, GISharp.Lib.Gio.IIcon icon2)
        {
            var icon1_ = icon1?.Handle ?? System.IntPtr.Zero;
            var icon2_ = icon2?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_icon_equal(icon1_,icon2_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Serializes a #GIcon into a #GVariant. An equivalent #GIcon can be retrieved
        /// back by calling g_icon_deserialize() on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <param name="icon">
        /// a #GIcon
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_icon_serialize(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Serializes a <see cref="IIcon"/> into a #GVariant. An equivalent <see cref="IIcon"/> can be retrieved
        /// back by calling <see cref="IIcon.Deserialize"/> on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <param name="icon">
        /// a <see cref="IIcon"/>
        /// </param>
        /// <returns>
        /// a #GVariant, or <c>null</c> when serialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public unsafe static GISharp.Lib.GLib.Variant Serialize(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_serialize(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generates a textual representation of @icon that can be used for
        /// serialization such as when passing @icon to a different process or
        /// saving it to persistent storage. Use g_icon_new_for_string() to
        /// get @icon back from the returned string.
        /// </summary>
        /// <remarks>
        /// The encoding of the returned string is proprietary to #GIcon except
        /// in the following two cases
        /// 
        /// - If @icon is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for @icon is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// 
        /// - If @icon is a #GThemedIcon with exactly one name, the encoding is
        ///    simply the name (such as `network-server`).
        /// </remarks>
        /// <param name="icon">
        /// a #GIcon.
        /// </param>
        /// <returns>
        /// An allocated NUL-terminated UTF8 string or
        /// %NULL if @icon can't be serialized. Use g_free() to free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_icon_to_string(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Generates a textual representation of <paramref name="icon"/> that can be used for
        /// serialization such as when passing <paramref name="icon"/> to a different process or
        /// saving it to persistent storage. Use <see cref="IIcon.NewForString"/> to
        /// get <paramref name="icon"/> back from the returned string.
        /// </summary>
        /// <remarks>
        /// The encoding of the returned string is proprietary to <see cref="IIcon"/> except
        /// in the following two cases
        /// 
        /// - If <paramref name="icon"/> is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for <paramref name="icon"/> is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// 
        /// - If <paramref name="icon"/> is a <see cref="ThemedIcon"/> with exactly one name, the encoding is
        ///    simply the name (such as `network-server`).
        /// </remarks>
        /// <param name="icon">
        /// a <see cref="IIcon"/>.
        /// </param>
        /// <returns>
        /// An allocated NUL-terminated UTF8 string or
        /// <c>null</c> if <paramref name="icon"/> can't be serialized. Use g_free() to free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public unsafe static GISharp.Lib.GLib.Utf8 ToString(this GISharp.Lib.Gio.IIcon icon)
        {
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            var ret_ = g_icon_to_string(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}