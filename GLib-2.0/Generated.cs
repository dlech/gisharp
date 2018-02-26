namespace GISharp.GLib
{
    /// <summary>
    /// The GKeyFile struct contains only private data
    /// and should not be accessed directly.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GKeyFile", IsProxyForUnmanagedType = true)]
    public sealed partial class KeyFile : GISharp.GObject.Boxed
    {
        static readonly GISharp.GObject.GType _GType = g_key_file_get_type();

        /// <summary>
        /// The name of the main group of a desktop entry file, as defined in the
        /// [Desktop Entry Specification](http://freedesktop.org/Standards/desktop-entry-spec).
        /// Consult the specification for more
        /// details about the meanings of the keys below.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopGroup = "Desktop Entry";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string list
        /// giving the available application actions.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public const System.String DesktopKeyActions = "Actions";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the categories in which the desktop entry
        /// should be shown in a menu.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyCategories = "Categories";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the tooltip for the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyComment = "Comment";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean set to true
        /// if the application is D-Bus activatable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public const System.String DesktopKeyDbusActivatable = "DBusActivatable";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the command line to execute. It is only valid for desktop
        /// entries with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyExec = "Exec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the generic name of the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyGenericName = "GenericName";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry has been deleted by the user.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyHidden = "Hidden";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the name of the icon to be displayed for the desktop
        /// entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyIcon = "Icon";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the MIME types supported by this desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyMimeType = "MimeType";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the specific name of the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyName = "Name";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should not display the
        /// desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyNotShowIn = "NotShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry should be shown in menus.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyNoDisplay = "NoDisplay";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should display the
        /// desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyOnlyShowIn = "OnlyShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// containing the working directory to run the program in. It is only
        /// valid for desktop entries with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyPath = "Path";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the application supports the
        /// [Startup Notification Protocol Specification](http://www.freedesktop.org/Standards/startup-notification-spec).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupNotify = "StartupNotify";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is string
        /// identifying the WM class or name hint of a window that the application
        /// will create, which can be used to emulate Startup Notification with
        /// older applications.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupWmClass = "StartupWMClass";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the program should be run in a terminal window.
        /// It is only valid for desktop entries with the
        /// `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyTerminal = "Terminal";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the file name of a binary on disk used to determine if the
        /// program is actually installed. It is only valid for desktop entries
        /// with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyTryExec = "TryExec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the type of the desktop entry. Usually
        /// #G_KEY_FILE_DESKTOP_TYPE_APPLICATION,
        /// #G_KEY_FILE_DESKTOP_TYPE_LINK, or
        /// #G_KEY_FILE_DESKTOP_TYPE_DIRECTORY.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyType = "Type";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the URL to access. It is only valid for desktop entries
        /// with the `Link` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyUrl = "URL";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the version of the Desktop Entry Specification used for
        /// the desktop entry file.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyVersion = "Version";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing applications.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeApplication = "Application";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing directories.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeDirectory = "Directory";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing links to documents.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeLink = "Link";

        public KeyFile(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_new();

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        static System.IntPtr New()
        {
            var ret_ = g_key_file_new();
            return ret_;
        }

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public KeyFile() : this(New(), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GISharp.GObject.GType g_key_file_get_type();

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_get_boolean(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean GetBoolean(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_get_boolean(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of booleans returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gboolean*" is-pointer="1">
*   <type name="gboolean" managed-name="Gboolean" />
* </array> */
        /* transfer-ownership:container */
        static extern System.IntPtr g_key_file_get_boolean_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Runtime.IArray<System.Boolean> GetBooleanList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            System.IntPtr error_;
            var ret_ = g_key_file_get_boolean_list(this_, groupName_, key_,out length_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Boolean>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <remarks>
        /// Note that the returned string includes the '#' comment markers.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <remarks>
        /// Note that the returned string includes the '#' comment markers.
        /// </remarks>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 GetComment(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret_ = g_key_file_get_comment(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
        /* transfer-ownership:none */
        static extern System.Double g_key_file_get_double(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public System.Double GetDouble(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_get_double(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of doubles returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gdouble*" is-pointer="1">
*   <type name="gdouble" managed-name="Gdouble" />
* </array> */
        /* transfer-ownership:container */
        static extern System.IntPtr g_key_file_get_double_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Runtime.IArray<System.Double> GetDoubleList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            System.IntPtr error_;
            var ret_ = g_key_file_get_double_list(this_, groupName_, key_,out length_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Double>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_groups(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.UIntPtr length);

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Strv GetGroups(out System.UIntPtr length)
        {
            var this_ = this.Handle;
            var ret_ = g_key_file_get_groups(this_,out length);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        static extern System.Int64 g_key_file_get_int64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int64 GetInt64(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_get_int64(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer, or is out of range
        /// for a #gint, then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        static extern System.Int32 g_key_file_get_integer(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer, or is out of range
        /// for a #gint, then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Int32 GetInteger(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_get_integer(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers, or are out of range for
        /// #gint, then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of integers returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gint*" is-pointer="1">
*   <type name="gint" managed-name="Gint" />
* </array> */
        /* transfer-ownership:container */
        static extern System.IntPtr g_key_file_get_integer_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers, or are out of range for
        /// #gint, then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Runtime.IArray<System.Int32> GetIntegerList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            System.IntPtr error_;
            var ret_ = g_key_file_get_integer_list(this_, groupName_, key_,out length_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Int32>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_keys(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Strv GetKeys(GISharp.GLib.Utf8 groupName, out System.UIntPtr length)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            System.IntPtr error_;
            var ret_ = g_key_file_get_keys(this_, groupName_,out length,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_locale_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr locale,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 GetLocaleString(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 locale)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? System.IntPtr.Zero;
            System.IntPtr error_;
            var ret_ = g_key_file_get_locale_string(this_, groupName_, key_, locale_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="3" zero-terminated="1" type="gchar**" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_locale_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr locale,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Strv GetLocaleStringList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 locale)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? System.IntPtr.Zero;
            System.UIntPtr length_;
            System.IntPtr error_;
            var ret_ = g_key_file_get_locale_string_list(this_, groupName_, key_, locale_,out length_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_start_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile);

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 StartGroup
        {
            get
            {
                var this_ = this.Handle;
                var ret_ = g_key_file_get_start_group(this_);
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
                return ret;
            }
        }

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 GetString(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret_ = g_key_file_get_string(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="1" type="gchar**" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Strv GetStringList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            System.IntPtr error_;
            var ret_ = g_key_file_get_string_list(this_, groupName_, key_,out length_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
        /* transfer-ownership:none */
        static extern System.UInt64 g_key_file_get_uint64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.UInt64 GetUint64(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_get_uint64(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_get_value(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 GetValue(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret_ = g_key_file_get_value(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_has_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName);

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean HasGroup(GISharp.GLib.Utf8 groupName)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var ret = g_key_file_has_group(this_, groupName_);
            return ret;
        }

        /// <summary>
        /// Loads a key file from the data in @bytes into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_load_from_bytes(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr bytes,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none */
        GISharp.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Loads a key file from the data in @bytes into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="bytes"/> is <c>null</c>.
        ///</exception>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.50")]
        public System.Boolean LoadFromBytes(GISharp.GLib.Bytes bytes, GISharp.GLib.KeyFileFlags flags)
        {
            var this_ = this.Handle;
            var bytes_ = bytes?.Handle ?? throw new System.ArgumentNullException(nameof(bytes));
            System.IntPtr error_;
            var ret = g_key_file_load_from_bytes(this_, bytes_, flags,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_load_from_data(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr data,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none */
        GISharp.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="data"/> is <c>null</c>.
        ///</exception>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean LoadFromData(GISharp.GLib.Utf8 data, System.UIntPtr length, GISharp.GLib.KeyFileFlags flags)
        {
            var this_ = this.Handle;
            var data_ = data?.Handle ?? throw new System.ArgumentNullException(nameof(data));
            System.IntPtr error_;
            var ret = g_key_file_load_from_data(this_, data_, length, flags,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_load_from_data_dirs(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="filename" type="gchar*" managed-name="Filename" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr file,
        /* <type name="filename" type="gchar**" managed-name="Filename" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr fullPath,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none */
        GISharp.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="file"/> is <c>null</c>.
        ///</exception>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean TryLoadFromDataDirs(GISharp.GLib.Filename file, out GISharp.GLib.Filename fullPath, GISharp.GLib.KeyFileFlags flags)
        {
            var this_ = this.Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            System.IntPtr fullPath_;
            System.IntPtr error_;
            var ret = g_key_file_load_from_data_dirs(this_, file_,out fullPath_, flags,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            fullPath = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Filename>(fullPath_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.
        /// </summary>
        /// <remarks>
        /// If the file could not be found in any of the @search_dirs,
        /// %G_KEY_FILE_ERROR_NOT_FOUND is returned. If
        /// the file is found but the OS returns an error when opening or reading the
        /// file, a %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_load_from_dirs(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="filename" type="gchar*" managed-name="Filename" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr file,
        /* <array type="gchar**" is-pointer="1">
*   <type name="filename" managed-name="Filename" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr searchDirs,
        /* <type name="filename" type="gchar**" managed-name="Filename" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.IntPtr fullPath,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none */
        GISharp.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.
        /// </summary>
        /// <remarks>
        /// If the file could not be found in any of the @search_dirs,
        /// %G_KEY_FILE_ERROR_NOT_FOUND is returned. If
        /// the file is found but the OS returns an error when opening or reading the
        /// file, a %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// </remarks>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="file"/> is <c>null</c>.
        ///</exception>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="searchDirs"/> is <c>null</c>.
        ///</exception>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public System.Boolean TryLoadFromDirs(GISharp.GLib.Filename file, GISharp.Runtime.IArray<GISharp.GLib.Filename> searchDirs, out GISharp.GLib.Filename fullPath, GISharp.GLib.KeyFileFlags flags)
        {
            var this_ = this.Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            var searchDirs_ = searchDirs?.Data ?? throw new System.ArgumentNullException(nameof(searchDirs));
            System.IntPtr fullPath_;
            System.IntPtr error_;
            var ret = g_key_file_load_from_dirs(this_, file_, searchDirs_,out fullPath_, flags,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            fullPath = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Filename>(fullPath_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// </summary>
        /// <remarks>
        /// If the OS returns an error when opening or reading the file, a
        /// %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// 
        /// This function will never return a %G_KEY_FILE_ERROR_NOT_FOUND error. If the
        /// @file is not found, %G_FILE_ERROR_NOENT is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_load_from_file(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="filename" type="gchar*" managed-name="Filename" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr file,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none */
        GISharp.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// </summary>
        /// <remarks>
        /// If the OS returns an error when opening or reading the file, a
        /// %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// 
        /// This function will never return a %G_KEY_FILE_ERROR_NOT_FOUND error. If the
        /// @file is not found, %G_FILE_ERROR_NOENT is returned.
        /// </remarks>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="file"/> is <c>null</c>.
        ///</exception>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean LoadFromFile(GISharp.GLib.Filename file, GISharp.GLib.KeyFileFlags flags)
        {
            var this_ = this.Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            System.IntPtr error_;
            var ret = g_key_file_load_from_file(this_, file_, flags,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_remove_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean RemoveComment(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? System.IntPtr.Zero;
            System.IntPtr error_;
            var ret = g_key_file_remove_comment(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_remove_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean RemoveGroup(GISharp.GLib.Utf8 groupName)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            System.IntPtr error_;
            var ret = g_key_file_remove_group(this_, groupName_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_remove_key(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean RemoveKey(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.IntPtr error_;
            var ret = g_key_file_remove_key(this_, groupName_, key_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_save_to_file(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr filename,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="filename"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public System.Boolean SaveToFile(GISharp.GLib.Utf8 filename)
        {
            var this_ = this.Handle;
            var filename_ = filename?.Handle ?? throw new System.ArgumentNullException(nameof(filename));
            System.IntPtr error_;
            var ret = g_key_file_save_to_file(this_, filename_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_boolean(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        System.Boolean value);

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetBoolean(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, System.Boolean value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            g_key_file_set_boolean(this_, groupName_, key_, value);
        }

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        /// <param name="length">
        /// length of @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_boolean_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gboolean" is-pointer="1">
*   <type name="gboolean" type="gboolean" managed-name="Gboolean" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="list"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetBooleanList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.Runtime.IArray<System.Boolean> list)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var list_ = list?.Data ?? throw new System.ArgumentNullException(nameof(list));
            var length_ = (System.UIntPtr)(list?.Length ?? 0);
            g_key_file_set_boolean_list(this_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// </summary>
        /// <remarks>
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// 
        /// Note that this function prepends a '#' comment marker to
        /// each line of @comment.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_key_file_set_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr comment,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// </summary>
        /// <remarks>
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// 
        /// Note that this function prepends a '#' comment marker to
        /// each line of @comment.
        /// </remarks>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="comment"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean SetComment(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 comment)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? System.IntPtr.Zero;
            var comment_ = comment?.Handle ?? throw new System.ArgumentNullException(nameof(comment));
            System.IntPtr error_;
            var ret = g_key_file_set_comment(this_, groupName_, key_, comment_,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            return ret;
        }

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_double(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gdouble" type="gdouble" managed-name="Gdouble" /> */
        /* transfer-ownership:none */
        System.Double value);

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public void SetDouble(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, System.Double value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            g_key_file_set_double(this_, groupName_, key_, value);
        }

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        /// <param name="length">
        /// number of double values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_double_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gdouble" is-pointer="1">
*   <type name="gdouble" type="gdouble" managed-name="Gdouble" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="list">
        /// an array of double values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="list"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public void SetDoubleList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.Runtime.IArray<System.Double> list)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var list_ = list?.Data ?? throw new System.ArgumentNullException(nameof(list));
            var length_ = (System.UIntPtr)(list?.Length ?? 0);
            g_key_file_set_double_list(this_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_int64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gint64" type="gint64" managed-name="Gint64" /> */
        /* transfer-ownership:none */
        System.Int64 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public void SetInt64(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, System.Int64 value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            g_key_file_set_int64(this_, groupName_, key_, value);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_integer(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="gint" type="gint" managed-name="Gint" /> */
        /* transfer-ownership:none */
        System.Int32 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetInteger(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, System.Int32 value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            g_key_file_set_integer(this_, groupName_, key_, value);
        }

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        /// <param name="length">
        /// number of integer values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_integer_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gint" is-pointer="1">
*   <type name="gint" type="gint" managed-name="Gint" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="list"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetIntegerList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.Runtime.IArray<System.Int32> list)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var list_ = list?.Data ?? throw new System.ArgumentNullException(nameof(list));
            var length_ = (System.UIntPtr)(list?.Length ?? 0);
            g_key_file_set_integer_list(this_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_list_separator(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="gchar" type="gchar" managed-name="Gchar" /> */
        /* transfer-ownership:none */
        System.SByte separator);

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetListSeparator(System.SByte separator)
        {
            var this_ = this.Handle;
            g_key_file_set_list_separator(this_, separator);
        }

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_locale_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr locale,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr @string);

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="locale"/> is <c>null</c>.
        ///</exception>
        /// <param name="string">
        /// a string
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="string"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetLocaleString(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 locale, GISharp.GLib.Utf8 @string)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? throw new System.ArgumentNullException(nameof(locale));
            var @string_ = @string?.Handle ?? throw new System.ArgumentNullException(nameof(@string));
            g_key_file_set_locale_string(this_, groupName_, key_, locale_, @string_);
        }

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        /// <param name="length">
        /// the length of @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_locale_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr locale,
        /* <array length="4" zero-terminated="1" type="gchar*" is-pointer="1">
*   <type name="utf8" type="gchar" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="locale"/> is <c>null</c>.
        ///</exception>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="list"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetLocaleStringList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 locale, GISharp.GLib.Strv list)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? throw new System.ArgumentNullException(nameof(locale));
            var list_ = list?.Handle ?? throw new System.ArgumentNullException(nameof(list));
            var length_ = (System.UIntPtr)(list?.Length ?? 0);
            g_key_file_set_locale_string_list(this_, groupName_, key_, locale_, list_, length_);
        }

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr @string);

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="string">
        /// a string
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="string"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetString(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 @string)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var @string_ = @string?.Handle ?? throw new System.ArgumentNullException(nameof(@string));
            g_key_file_set_string(this_, groupName_, key_, @string_);
        }

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <param name="length">
        /// number of string values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <array length="3" zero-terminated="1" type="gchar*" is-pointer="1">
*   <type name="utf8" managed-name="Utf8" />
* </array> */
        /* transfer-ownership:none */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="Gsize" /> */
        /* transfer-ownership:none */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="list"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetStringList(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Strv list)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var list_ = list?.Handle ?? throw new System.ArgumentNullException(nameof(list));
            var length_ = (System.UIntPtr)(list?.Length ?? 0);
            g_key_file_set_string_list(this_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_uint64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="guint64" type="guint64" managed-name="Guint64" /> */
        /* transfer-ownership:none */
        System.UInt64 value);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public void SetUint64(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, System.UInt64 value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            g_key_file_set_uint64(this_, groupName_, key_, value);
        }

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_set_value(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr value);

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="groupName"/> is <c>null</c>.
        ///</exception>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// a string
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public void SetValue(GISharp.GLib.Utf8 groupName, GISharp.GLib.Utf8 key, GISharp.GLib.Utf8 value)
        {
            var this_ = this.Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_key_file_set_value(this_, groupName_, key_, value_);
        }

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_key_file_to_data(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile,
        /* <type name="gsize" type="gsize*" managed-name="Gsize" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        out System.UIntPtr length,
        /* <type name="GLib.Error" managed-name="GLib.Error" /> */
        /* direction:out */
        out System.IntPtr error);

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.GLib.Utf8 ToData(out System.UIntPtr length)
        {
            var this_ = this.Handle;
            System.IntPtr error_;
            var ret_ = g_key_file_to_data(this_,out length,out error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_key_file_unref(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr keyFile);
    }

    /// <summary>
    /// Error codes returned by key file parsing.
    /// </summary>
    [GISharp.Runtime.GErrorDomainAttribute("g-key-file-error-quark")]
    public enum KeyFileError
    {
        /// <summary>
        /// the text being parsed was in
        ///     an unknown encoding
        /// </summary>
        UnknownEncoding = 0,
        /// <summary>
        /// document was ill-formed
        /// </summary>
        Parse = 1,
        /// <summary>
        /// the file was not found
        /// </summary>
        NotFound = 2,
        /// <summary>
        /// a requested key was not found
        /// </summary>
        KeyNotFound = 3,
        /// <summary>
        /// a requested group was not found
        /// </summary>
        GroupNotFound = 4,
        /// <summary>
        /// a value could not be parsed
        /// </summary>
        InvalidValue = 5
    }

    public static class KeyFileErrorDomain
    {
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none */
        static extern GISharp.GLib.Quark g_key_file_error_quark();

        public static GISharp.GLib.Quark Quark
        {
            get
            {
                var ret = g_key_file_error_quark();
                return ret;
            }
        }
    }

    /// <summary>
    /// Flags which influence the parsing.
    /// </summary>
    [System.FlagsAttribute]
    public enum KeyFileFlags
    {
        /// <summary>
        /// No flags, default behaviour
        /// </summary>
        None = 0,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise all comments will be lost when the key file is
        ///     written back.
        /// </summary>
        KeepComments = 1,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise only the translations for the current language will be
        ///     written back.
        /// </summary>
        KeepTranslations = 2
    }

    /// <summary>
    /// The #GOptionArg enum values determine which type of extra argument the
    /// options expect to find. If an option expects an extra argument, it can
    /// be specified in several ways; with a short option: `-x arg`, with a long
    /// option: `--name arg` or combined in a single argument: `--name=arg`.
    /// </summary>
    public enum OptionArg
    {
        /// <summary>
        /// No extra argument. This is useful for simple flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// The option takes a string argument.
        /// </summary>
        String = 1,
        /// <summary>
        /// The option takes an integer argument.
        /// </summary>
        Int = 2,
        /// <summary>
        /// The option provides a callback (of type
        ///     #GOptionArgFunc) to parse the extra argument.
        /// </summary>
        Callback = 3,
        /// <summary>
        /// The option takes a filename as argument.
        /// </summary>
        Filename = 4,
        /// <summary>
        /// The option takes a string argument, multiple
        ///     uses of the option are collected into an array of strings.
        /// </summary>
        StringArray = 5,
        /// <summary>
        /// The option takes a filename as argument,
        ///     multiple uses of the option are collected into an array of strings.
        /// </summary>
        FilenameArray = 6,
        /// <summary>
        /// The option takes a double argument. The argument
        ///     can be formatted either for the user's locale or for the "C" locale.
        ///     Since 2.12
        /// </summary>
        Double = 7,
        /// <summary>
        /// The option takes a 64-bit integer. Like
        ///     %G_OPTION_ARG_INT but for larger numbers. The number can be in
        ///     decimal base, or in hexadecimal (when prefixed with `0x`, for
        ///     example, `0xffffffff`). Since 2.12
        /// </summary>
        Int64 = 8
    }

    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate System.Boolean UnmanagedOptionArgFunc(
    /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
    /* transfer-ownership:none */
    System.IntPtr optionName,
    /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
    /* transfer-ownership:none */
    System.IntPtr value,
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 */
    System.IntPtr data,
    /* <type name="GLib.Error" managed-name="GLib.Error" /> */
    /* direction:inout */
    ref System.IntPtr error);

    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    public delegate System.Boolean OptionArgFunc(GISharp.GLib.Utf8 optionName, GISharp.GLib.Utf8 value);

    /// <summary>
    /// Factory for creating <see cref="UnmanagedOptionArgFunc"/> methods.
    /// </summary>
    public static class UnmanagedOptionArgFuncFactory
    {
        class UserData
        {
            public GISharp.GLib.OptionArgFunc ManagedDelegate;
            public GISharp.GLib.UnmanagedOptionArgFunc UnmanagedDelegate;
            public GISharp.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        /// <summary>
        /// Wraps a <see cref="OptionArgFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static System.ValueTuple<GISharp.GLib.UnmanagedOptionArgFunc, GISharp.GLib.UnmanagedDestroyNotify, System.IntPtr> Create(GISharp.GLib.OptionArgFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static System.Boolean UnmanagedCallback(System.IntPtr optionName_, System.IntPtr value_, System.IntPtr data_, ref System.IntPtr error_)
        {
            try
            {
                var optionName = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(optionName_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(value_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                var ret = data.ManagedDelegate(optionName, value);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }

                return ret;
            }
            catch (System.Exception ex)
            {
                ex.LogUnhandledException();
            }

            return default(System.Boolean);
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                ex.LogUnhandledException();
            }
        }
    }

    /// <summary>
    /// Flags which modify individual options.
    /// </summary>
    [System.FlagsAttribute]
    public enum OptionFlags
    {
        /// <summary>
        /// No flags. Since: 2.42.
        /// </summary>
        None = 0,
        /// <summary>
        /// The option doesn't appear in `--help` output.
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// The option appears in the main section of the
        ///     `--help` output, even if it is defined in a group.
        /// </summary>
        InMain = 2,
        /// <summary>
        /// For options of the %G_OPTION_ARG_NONE kind, this
        ///     flag indicates that the sense of the option is reversed.
        /// </summary>
        Reverse = 4,
        /// <summary>
        /// For options of the %G_OPTION_ARG_CALLBACK kind,
        ///     this flag indicates that the callback does not take any argument
        ///     (like a %G_OPTION_ARG_NONE option). Since 2.8
        /// </summary>
        NoArg = 8,
        /// <summary>
        /// For options of the %G_OPTION_ARG_CALLBACK
        ///     kind, this flag indicates that the argument should be passed to the
        ///     callback in the GLib filename encoding rather than UTF-8. Since 2.8
        /// </summary>
        Filename = 16,
        /// <summary>
        /// For options of the %G_OPTION_ARG_CALLBACK
        ///     kind, this flag indicates that the argument supply is optional.
        ///     If no argument is given then data of %GOptionParseFunc will be
        ///     set to NULL. Since 2.8
        /// </summary>
        OptionalArg = 32,
        /// <summary>
        /// This flag turns off the automatic conflict
        ///     resolution which prefixes long option names with `groupname-` if
        ///     there is a conflict. This option should only be used in situations
        ///     where aliasing is necessary to model some legacy commandline interface.
        ///     It is not safe to use this option, unless all option groups are under
        ///     your direct control. Since 2.8.
        /// </summary>
        NoAlias = 64
    }

    /// <summary>
    /// A utility type for constructing container-type #GVariant instances.
    /// </summary>
    /// <remarks>
    /// This is an opaque structure and may only be accessed using the
    /// following functions.
    /// 
    /// #GVariantBuilder is not threadsafe in any way.  Do not attempt to
    /// access it from more than one thread.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GVariantBuilder", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantBuilder : GISharp.GObject.Boxed
    {
        static readonly GISharp.GObject.GType _GType = g_variant_builder_get_type();

        public VariantBuilder(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_variant_builder_new(
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr type);

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="type"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        static System.IntPtr New(GISharp.GLib.VariantType type)
        {
            AssertNewArgs(type);
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            var ret_ = g_variant_builder_new(type_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="type"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public VariantBuilder(GISharp.GLib.VariantType type) : this(New(type), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GISharp.GObject.GType g_variant_builder_get_type();

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_builder_add_value(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr builder,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr value);

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Add(GISharp.GLib.Variant value)
        {
            var this_ = this.Handle;
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_variant_builder_add_value(this_, value_);
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_builder_close(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr builder);

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Close()
        {
            var this_ = this.Handle;
            g_variant_builder_close(this_);
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// g_variant_builder_end().
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
        static extern System.IntPtr g_variant_builder_end(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr builder);

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// g_variant_builder_end().
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public GISharp.GLib.Variant End()
        {
            var this_ = this.Handle;
            var ret_ = g_variant_builder_end(this_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called. @type
        /// is the type of the container: so to build a tuple of several values, @type
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_builder_open(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr builder,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr type);

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called. @type
        /// is the type of the container: so to build a tuple of several values, @type
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="type"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public void Open(GISharp.GLib.VariantType type)
        {
            var this_ = this.Handle;
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            g_variant_builder_open(this_, type_);
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_variant_builder_ref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr builder);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_builder_unref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full */
        System.IntPtr builder);
    }

    /// <summary>
    /// #GVariantDict is a mutable interface to #GVariant dictionaries.
    /// </summary>
    /// <remarks>
    /// It can be used for doing a sequence of dictionary lookups in an
    /// efficient way on an existing #GVariant dictionary or it can be used
    /// to construct new dictionaries with a hashtable-like interface.  It
    /// can also be used for taking existing dictionaries and modifying them
    /// in order to create new ones.
    /// 
    /// #GVariantDict can only be used with %G_VARIANT_TYPE_VARDICT
    /// dictionaries.
    /// 
    /// It is possible to use #GVariantDict allocated on the stack or on the
    /// heap.  When using a stack-allocated #GVariantDict, you begin with a
    /// call to g_variant_dict_init() and free the resources with a call to
    /// g_variant_dict_clear().
    /// 
    /// Heap-allocated #GVariantDict follows normal refcounting rules: you
    /// allocate it with g_variant_dict_new() and use g_variant_dict_ref()
    /// and g_variant_dict_unref().
    /// 
    /// g_variant_dict_end() is used to convert the #GVariantDict back into a
    /// dictionary-type #GVariant.  When used with stack-allocated instances,
    /// this also implicitly frees all associated memory, but for
    /// heap-allocated instances, you must still call g_variant_dict_unref()
    /// afterwards.
    /// 
    /// You will typically want to use a heap-allocated #GVariantDict when
    /// you expose it as part of an API.  For most other uses, the
    /// stack-allocated form will be more convenient.
    /// 
    /// Consider the following two examples that do the same thing in each
    /// style: take an existing dictionary and look up the "count" uint32
    /// key, adding 1 to it if it is found, or returning an error if the
    /// key is not found.  Each returns the new dictionary as a floating
    /// #GVariant.
    /// 
    /// ## Using a stack-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict dict;
    ///     guint32 count;
    /// 
    ///     g_variant_dict_init (&amp;dict, orig);
    ///     if (!g_variant_dict_lookup (&amp;dict, "count", "u", &amp;count))
    ///       {
    ///         g_set_error (...);
    ///         g_variant_dict_clear (&amp;dict);
    ///         return NULL;
    ///       }
    /// 
    ///     g_variant_dict_insert (&amp;dict, "count", "u", count + 1);
    /// 
    ///     return g_variant_dict_end (&amp;dict);
    ///   }
    /// ]|
    /// 
    /// ## Using heap-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict *dict;
    ///     GVariant *result;
    ///     guint32 count;
    /// 
    ///     dict = g_variant_dict_new (orig);
    /// 
    ///     if (g_variant_dict_lookup (dict, "count", "u", &amp;count))
    ///       {
    ///         g_variant_dict_insert (dict, "count", "u", count + 1);
    ///         result = g_variant_dict_end (dict);
    ///       }
    ///     else
    ///       {
    ///         g_set_error (...);
    ///         result = NULL;
    ///       }
    /// 
    ///     g_variant_dict_unref (dict);
    /// 
    ///     return result;
    ///   }
    /// ]|
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.40")]
    [GISharp.Runtime.GTypeAttribute("GVariantDict", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantDict : GISharp.GObject.Boxed
    {
        static readonly GISharp.GObject.GType _GType = g_variant_dict_get_type();

        public VariantDict(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_variant_dict_new(
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr fromAsv);

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        static System.IntPtr New(GISharp.GLib.Variant fromAsv)
        {
            AssertNewArgs(fromAsv);
            var fromAsv_ = fromAsv?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_new(fromAsv_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public VariantDict(GISharp.GLib.Variant fromAsv) : this(New(fromAsv), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GISharp.GObject.GType g_variant_dict_get_type();

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_variant_dict_contains(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key);

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public System.Boolean Contains(GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var ret = g_variant_dict_contains(this_, key_);
            return ret;
        }

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
        static extern System.IntPtr g_variant_dict_end(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict);

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public GISharp.GLib.Variant End()
        {
            var this_ = this.Handle;
            var ret_ = g_variant_dict_end(this_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_dict_insert_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr value);

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="value">
        /// the value to insert
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="value"/> is <c>null</c>.
        ///</exception>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public void Insert(GISharp.GLib.Utf8 key, GISharp.GLib.Variant value)
        {
            var this_ = this.Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_variant_dict_insert_value(this_, key_, value_);
        }

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_variant_dict_lookup_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 */
        System.IntPtr expectedType);

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public GISharp.GLib.Variant Lookup(GISharp.GLib.Utf8 key, GISharp.GLib.VariantType expectedType = null)
        {
            var this_ = this.Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var expectedType_ = expectedType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_lookup_value(this_, key_, expectedType_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full */
        static extern System.IntPtr g_variant_dict_ref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern System.Boolean g_variant_dict_remove(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        System.IntPtr key);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <exception name="System.ArgumentNullException">
        /// If <paramref name="key"/> is <c>null</c>.
        ///</exception>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public System.Boolean Remove(GISharp.GLib.Utf8 key)
        {
            var this_ = this.Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var ret = g_variant_dict_remove(this_, key_);
            return ret;
        }

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_variant_dict_unref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full */
        System.IntPtr dict);
    }

    public static partial class Version
    {
        /// <summary>
        /// The major version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #glib_major_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 major = 2;

        /// <summary>
        /// The micro version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_micro_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 micro = 0;

        /// <summary>
        /// The minor version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_minor_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 minor = 54;

        /// <summary>
        /// A macro that should be defined by the user prior to including
        /// the glib.h header.
        /// The definition should be one of the predefined GLib version
        /// macros: %GLIB_VERSION_2_26, %GLIB_VERSION_2_28,...
        /// </summary>
        /// <remarks>
        /// This macro defines the earliest version of GLib that the package is
        /// required to be able to compile against.
        /// 
        /// If the compiler is configured to warn about the use of deprecated
        /// functions, then using functions that were deprecated in version
        /// %GLIB_VERSION_MIN_REQUIRED or earlier will cause warnings (but
        /// using functions deprecated in later releases will not).
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.32")]
        private const System.Int32 minRequired = 2;

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="Utf8" is-pointer="1" /> */
        /* transfer-ownership:none */
        static extern System.IntPtr glib_check_version(
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        System.UInt32 requiredMajor,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        System.UInt32 requiredMinor,
        /* <type name="guint" type="guint" managed-name="Guint" /> */
        /* transfer-ownership:none */
        System.UInt32 requiredMicro);

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static GISharp.GLib.Utf8 Check(System.UInt32 requiredMajor, System.UInt32 requiredMinor, System.UInt32 requiredMicro)
        {
            var ret_ = glib_check_version(requiredMajor, requiredMinor, requiredMicro);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }
}