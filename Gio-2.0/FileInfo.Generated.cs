namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Functionality for manipulating basic metadata for files. <see cref="FileInfo"/>
    /// implements methods for getting information that all files should
    /// contain, and allows for manipulation of extended attributes.
    /// </summary>
    /// <remarks>
    /// See [GFileAttribute][gio-GFileAttribute] for more information on how
    /// GIO handles file attributes.
    /// 
    /// To obtain a <see cref="FileInfo"/> for a #GFile, use g_file_query_info() (or its
    /// async variant). To obtain a <see cref="FileInfo"/> for a file input or output
    /// stream, use <see cref="FileInputStream.QueryInfo"/> or
    /// <see cref="FileOutputStream.QueryInfo"/> (or their async variants).
    /// 
    /// To change the actual attributes of a file, you should then set the
    /// attribute in the <see cref="FileInfo"/> and call g_file_set_attributes_from_info()
    /// or g_file_set_attributes_async() on a GFile.
    /// 
    /// However, not all attributes can be changed in the file. For instance,
    /// the actual size of a file cannot be changed via <see cref="FileInfo.SetSize"/>.
    /// You may call g_file_query_settable_attributes() and
    /// g_file_query_writable_namespaces() to discover the settable attributes
    /// of a particular file at runtime.
    /// 
    /// <see cref="FileAttributeMatcher"/> allows for searching through a <see cref="FileInfo"/> for
    /// attributes.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GFileInfo", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(FileInfoClass))]
    public partial class FileInfo : GISharp.Lib.GObject.Object
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_info_get_type();

        /// <summary>
        /// Gets the file's content type.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 ContentType { get => GetContentType(); set => SetContentType(value); }

        /// <summary>
        /// Returns the #GDateTime representing the deletion date of the file, as
        /// available in G_FILE_ATTRIBUTE_TRASH_DELETION_DATE. If the
        /// G_FILE_ATTRIBUTE_TRASH_DELETION_DATE attribute is unset, <c>null</c> is returned.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.36")]
        public GISharp.Lib.GLib.DateTime DeletionDate { get => GetDeletionDate(); }

        /// <summary>
        /// Gets a display name for a file.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 DisplayName { get => GetDisplayName(); set => SetDisplayName(value); }

        /// <summary>
        /// Gets the edit name for a file.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 EditName { get => GetEditName(); set => SetEditName(value); }

        /// <summary>
        /// Gets the [entity tag][gfile-etag] for a given
        /// <see cref="FileInfo"/>. See %G_FILE_ATTRIBUTE_ETAG_VALUE.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 Etag { get => GetEtag(); }

        /// <summary>
        /// Gets a file's type (whether it is a regular file, symlink, etc).
        /// This is different from the file's content type, see <see cref="FileInfo.GetContentType"/>.
        /// </summary>
        public GISharp.Lib.Gio.FileType FileType { get => GetFileType(); set => SetFileType(value); }

        /// <summary>
        /// Gets the icon for a file.
        /// </summary>
        public GISharp.Lib.Gio.IIcon Icon { get => GetIcon(); set => SetIcon(value); }

        /// <summary>
        /// Checks if a file is a backup file.
        /// </summary>
        public System.Boolean IsBackup { get => GetIsBackup(); }

        /// <summary>
        /// Checks if a file is hidden.
        /// </summary>
        public System.Boolean IsHidden { get => GetIsHidden(); set => SetIsHidden(value); }

        /// <summary>
        /// Checks if a file is a symlink.
        /// </summary>
        public System.Boolean IsSymlink { get => GetIsSymlink(); set => SetIsSymlink(value); }

        /// <summary>
        /// Gets the name for a file.
        /// </summary>
        public GISharp.Lib.GLib.Filename Name { get => GetName(); set => SetName(value); }

        /// <summary>
        /// Gets the file's size.
        /// </summary>
        public System.Int64 Size { get => GetSize(); set => SetSize(value); }

        /// <summary>
        /// Gets the value of the sort_order attribute from the <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_SORT_ORDER.
        /// </summary>
        public System.Int32 SortOrder { get => GetSortOrder(); set => SetSortOrder(value); }

        /// <summary>
        /// Gets the symbolic icon for a file.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public GISharp.Lib.Gio.IIcon SymbolicIcon { get => GetSymbolicIcon(); set => SetSymbolicIcon(value); }

        /// <summary>
        /// Gets the symlink target for a given <see cref="FileInfo"/>.
        /// </summary>
        public GISharp.Lib.GLib.Utf8 SymlinkTarget { get => GetSymlinkTarget(); set => SetSymlinkTarget(value); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileInfo(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new file info structure.
        /// </summary>
        /// <returns>
        /// a #GFileInfo.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_info_new();

        static unsafe System.IntPtr New()
        {
            var ret_ = g_file_info_new();
            return ret_;
        }

        /// <summary>
        /// Creates a new file info structure.
        /// </summary>
        public FileInfo() : this(New(), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_info_get_type();

        /// <summary>
        /// Clears the status information from @info.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_clear_status(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Clears the status information from <paramref name="info"/>.
        /// </summary>
        public unsafe void ClearStatus()
        {
            var info_ = Handle;
            g_file_info_clear_status(info_);
        }

        /// <summary>
        /// First clears all of the [GFileAttribute][gio-GFileAttribute] of @dest_info,
        /// and then copies all of the file attributes from @src_info to @dest_info.
        /// </summary>
        /// <param name="srcInfo">
        /// source to copy attributes from.
        /// </param>
        /// <param name="destInfo">
        /// destination to copy attributes to.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_copy_into(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr srcInfo,
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr destInfo);

        /// <summary>
        /// First clears all of the [GFileAttribute][gio-GFileAttribute] of <paramref name="destInfo"/>,
        /// and then copies all of the file attributes from <paramref name="srcInfo"/> to <paramref name="destInfo"/>.
        /// </summary>
        /// <param name="destInfo">
        /// destination to copy attributes to.
        /// </param>
        public unsafe void CopyInto(GISharp.Lib.Gio.FileInfo destInfo)
        {
            var srcInfo_ = Handle;
            var destInfo_ = destInfo?.Handle ?? throw new System.ArgumentNullException(nameof(destInfo));
            g_file_info_copy_into(srcInfo_, destInfo_);
        }

        /// <summary>
        /// Duplicates a file info structure.
        /// </summary>
        /// <param name="other">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a duplicate #GFileInfo of @other.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_info_dup(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr other);

        /// <summary>
        /// Duplicates a file info structure.
        /// </summary>
        /// <returns>
        /// a duplicate <see cref="FileInfo"/> of <paramref name="other"/>.
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileInfo Dup()
        {
            var other_ = Handle;
            var ret_ = g_file_info_dup(other_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileInfo>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the value of a attribute, formated as a string.
        /// This escapes things as needed to make the string valid
        /// utf8.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a UTF-8 string associated with the given @attribute.
        ///    When you're done with the string it must be freed with g_free().
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_info_get_attribute_as_string(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a attribute, formated as a string.
        /// This escapes things as needed to make the string valid
        /// utf8.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a UTF-8 string associated with the given <paramref name="attribute"/>.
        ///    When you're done with the string it must be freed with g_free().
        /// </returns>
        public unsafe GISharp.Lib.GLib.Utf8 GetAttributeAsString(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_as_string(info_,attribute_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the value of a boolean attribute. If the attribute does not
        /// contain a boolean value, %FALSE will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the boolean value contained within the attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_get_attribute_boolean(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a boolean attribute. If the attribute does not
        /// contain a boolean value, <c>false</c> will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the boolean value contained within the attribute.
        /// </returns>
        public unsafe System.Boolean GetAttributeBoolean(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_boolean(info_,attribute_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of a byte string attribute. If the attribute does
        /// not contain a byte string, %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the @attribute value as a byte string, or
        /// %NULL otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_attribute_byte_string(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a byte string attribute. If the attribute does
        /// not contain a byte string, <c>null</c> will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the <paramref name="attribute"/> value as a byte string, or
        /// <c>null</c> otherwise.
        /// </returns>
        public unsafe GISharp.Lib.GLib.Utf8 GetAttributeByteString(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_byte_string(info_,attribute_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the attribute type, value and status for an attribute key.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo
        /// </param>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="type">
        /// return location for the attribute type, or %NULL
        /// </param>
        /// <param name="valuePp">
        /// return location for the
        ///    attribute value, or %NULL; the attribute value will not be %NULL
        /// </param>
        /// <param name="status">
        /// return location for the attribute status, or %NULL
        /// </param>
        /// <returns>
        /// %TRUE if @info has an attribute named @attribute,
        ///      %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_get_attribute_data(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="FileAttributeType" type="GFileAttributeType*" managed-name="FileAttributeType" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        GISharp.Lib.Gio.FileAttributeType* type,
        /* <type name="gpointer" type="gpointer*" managed-name="System.IntPtr" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.IntPtr* valuePp,
        /* <type name="FileAttributeStatus" type="GFileAttributeStatus*" managed-name="FileAttributeStatus" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        GISharp.Lib.Gio.FileAttributeStatus* status);

        /// <summary>
        /// Gets the attribute type, value and status for an attribute key.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="type">
        /// return location for the attribute type, or <c>null</c>
        /// </param>
        /// <param name="valuePp">
        /// return location for the
        ///    attribute value, or <c>null</c>; the attribute value will not be <c>null</c>
        /// </param>
        /// <param name="status">
        /// return location for the attribute status, or <c>null</c>
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="info"/> has an attribute named <paramref name="attribute"/>,
        ///      <c>false</c> otherwise.
        /// </returns>
        public unsafe System.Boolean TryGetAttributeData(GISharp.Lib.GLib.Utf8 attribute, out GISharp.Lib.Gio.FileAttributeType type, out System.IntPtr valuePp, out GISharp.Lib.Gio.FileAttributeStatus status)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            GISharp.Lib.Gio.FileAttributeType type_;
            System.IntPtr valuePp_;
            GISharp.Lib.Gio.FileAttributeStatus status_;
            var ret_ = g_file_info_get_attribute_data(info_,attribute_,&type_,&valuePp_,&status_);
            type = (GISharp.Lib.Gio.FileAttributeType)type_;
            valuePp = (System.IntPtr)valuePp_;
            status = (GISharp.Lib.Gio.FileAttributeStatus)status_;
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets a signed 32-bit integer contained within the attribute. If the
        /// attribute does not contain a signed 32-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a signed 32-bit integer from the attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint32" type="gint32" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_file_info_get_attribute_int32(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets a signed 32-bit integer contained within the attribute. If the
        /// attribute does not contain a signed 32-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a signed 32-bit integer from the attribute.
        /// </returns>
        public unsafe System.Int32 GetAttributeInt32(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_int32(info_,attribute_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets a signed 64-bit integer contained within the attribute. If the
        /// attribute does not contain an signed 64-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a signed 64-bit integer from the attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int64 g_file_info_get_attribute_int64(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets a signed 64-bit integer contained within the attribute. If the
        /// attribute does not contain an signed 64-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a signed 64-bit integer from the attribute.
        /// </returns>
        public unsafe System.Int64 GetAttributeInt64(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_int64(info_,attribute_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of a #GObject attribute. If the attribute does
        /// not contain a #GObject, %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a #GObject associated with the given @attribute, or
        /// %NULL otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_attribute_object(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a #GObject attribute. If the attribute does
        /// not contain a #GObject, <c>null</c> will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a #GObject associated with the given <paramref name="attribute"/>, or
        /// <c>null</c> otherwise.
        /// </returns>
        public unsafe GISharp.Lib.GObject.Object GetAttributeObject(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_object(info_,attribute_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the attribute status for an attribute key.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo
        /// </param>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <returns>
        /// a #GFileAttributeStatus for the given @attribute, or
        ///    %G_FILE_ATTRIBUTE_STATUS_UNSET if the key is invalid.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeStatus" type="GFileAttributeStatus" managed-name="FileAttributeStatus" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.Gio.FileAttributeStatus g_file_info_get_attribute_status(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the attribute status for an attribute key.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <returns>
        /// a <see cref="FileAttributeStatus"/> for the given <paramref name="attribute"/>, or
        ///    <see cref="FileAttributeStatus.Unset"/> if the key is invalid.
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileAttributeStatus GetAttributeStatus(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_status(info_,attribute_);
            var ret = (GISharp.Lib.Gio.FileAttributeStatus)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of a string attribute. If the attribute does
        /// not contain a string, %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the @attribute value as a UTF-8 string, or
        /// %NULL otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_attribute_string(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a string attribute. If the attribute does
        /// not contain a string, <c>null</c> will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the <paramref name="attribute"/> value as a UTF-8 string, or
        /// <c>null</c> otherwise.
        /// </returns>
        public unsafe GISharp.Lib.GLib.Utf8 GetAttributeString(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_string(info_,attribute_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the value of a stringv attribute. If the attribute does
        /// not contain a stringv, %NULL will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the @attribute value as a stringv, or
        /// %NULL otherwise. Do not free. These returned strings are UTF-8.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="char**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_attribute_stringv(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the value of a stringv attribute. If the attribute does
        /// not contain a stringv, <c>null</c> will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// the contents of the <paramref name="attribute"/> value as a stringv, or
        /// <c>null</c> otherwise. Do not free. These returned strings are UTF-8.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe GISharp.Lib.GLib.Strv GetAttributeStringv(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_stringv(info_,attribute_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the attribute type for an attribute key.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a #GFileAttributeType for the given @attribute, or
        /// %G_FILE_ATTRIBUTE_TYPE_INVALID if the key is not set.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeType" type="GFileAttributeType" managed-name="FileAttributeType" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.Gio.FileAttributeType g_file_info_get_attribute_type(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets the attribute type for an attribute key.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a <see cref="FileAttributeType"/> for the given <paramref name="attribute"/>, or
        /// <see cref="FileAttributeType.Invalid"/> if the key is not set.
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileAttributeType GetAttributeType(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_type(info_,attribute_);
            var ret = (GISharp.Lib.Gio.FileAttributeType)ret_;
            return ret;
        }

        /// <summary>
        /// Gets an unsigned 32-bit integer contained within the attribute. If the
        /// attribute does not contain an unsigned 32-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// an unsigned 32-bit integer from the attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint32" type="guint32" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.UInt32 g_file_info_get_attribute_uint32(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets an unsigned 32-bit integer contained within the attribute. If the
        /// attribute does not contain an unsigned 32-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// an unsigned 32-bit integer from the attribute.
        /// </returns>
        public unsafe System.UInt32 GetAttributeUint32(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_uint32(info_,attribute_);
            var ret = (System.UInt32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets a unsigned 64-bit integer contained within the attribute. If the
        /// attribute does not contain an unsigned 64-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a unsigned 64-bit integer from the attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.UInt64 g_file_info_get_attribute_uint64(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Gets a unsigned 64-bit integer contained within the attribute. If the
        /// attribute does not contain an unsigned 64-bit integer, or is invalid,
        /// 0 will be returned.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// a unsigned 64-bit integer from the attribute.
        /// </returns>
        public unsafe System.UInt64 GetAttributeUint64(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_get_attribute_uint64(info_,attribute_);
            var ret = (System.UInt64)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the file's content type.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the file's content type.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_content_type(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the file's content type.
        /// </summary>
        /// <returns>
        /// a string containing the file's content type.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetContentType()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_content_type(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Returns the #GDateTime representing the deletion date of the file, as
        /// available in G_FILE_ATTRIBUTE_TRASH_DELETION_DATE. If the
        /// G_FILE_ATTRIBUTE_TRASH_DELETION_DATE attribute is unset, %NULL is returned.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.DateTime" type="GDateTime*" managed-name="GISharp.Lib.GLib.DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_info_get_deletion_date(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Returns the #GDateTime representing the deletion date of the file, as
        /// available in G_FILE_ATTRIBUTE_TRASH_DELETION_DATE. If the
        /// G_FILE_ATTRIBUTE_TRASH_DELETION_DATE attribute is unset, <c>null</c> is returned.
        /// </summary>
        /// <returns>
        /// a #GDateTime, or <c>null</c>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.36")]
        private unsafe GISharp.Lib.GLib.DateTime GetDeletionDate()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_deletion_date(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets a display name for a file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the display name.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_display_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets a display name for a file.
        /// </summary>
        /// <returns>
        /// a string containing the display name.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetDisplayName()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_display_name(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the edit name for a file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the edit name.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_edit_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the edit name for a file.
        /// </summary>
        /// <returns>
        /// a string containing the edit name.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetEditName()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_edit_name(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the [entity tag][gfile-etag] for a given
        /// #GFileInfo. See %G_FILE_ATTRIBUTE_ETAG_VALUE.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the value of the "etag:value" attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_etag(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the [entity tag][gfile-etag] for a given
        /// <see cref="FileInfo"/>. See %G_FILE_ATTRIBUTE_ETAG_VALUE.
        /// </summary>
        /// <returns>
        /// a string containing the value of the "etag:value" attribute.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetEtag()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_etag(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets a file's type (whether it is a regular file, symlink, etc).
        /// This is different from the file's content type, see g_file_info_get_content_type().
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a #GFileType for the given file.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileType" type="GFileType" managed-name="FileType" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.Gio.FileType g_file_info_get_file_type(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets a file's type (whether it is a regular file, symlink, etc).
        /// This is different from the file's content type, see <see cref="FileInfo.GetContentType"/>.
        /// </summary>
        /// <returns>
        /// a <see cref="FileType"/> for the given file.
        /// </returns>
        private unsafe GISharp.Lib.Gio.FileType GetFileType()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_file_type(info_);
            var ret = (GISharp.Lib.Gio.FileType)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the icon for a file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// #GIcon for the given @info.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_icon(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the icon for a file.
        /// </summary>
        /// <returns>
        /// <see cref="IIcon"/> for the given <paramref name="info"/>.
        /// </returns>
        private unsafe GISharp.Lib.Gio.IIcon GetIcon()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_icon(info_);
            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Checks if a file is a backup file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// %TRUE if file is a backup file, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_get_is_backup(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Checks if a file is a backup file.
        /// </summary>
        /// <returns>
        /// <c>true</c> if file is a backup file, <c>false</c> otherwise.
        /// </returns>
        private unsafe System.Boolean GetIsBackup()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_is_backup(info_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if a file is hidden.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// %TRUE if the file is a hidden file, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_get_is_hidden(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Checks if a file is hidden.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the file is a hidden file, <c>false</c> otherwise.
        /// </returns>
        private unsafe System.Boolean GetIsHidden()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_is_hidden(info_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if a file is a symlink.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// %TRUE if the given @info is a symlink.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_get_is_symlink(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Checks if a file is a symlink.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the given <paramref name="info"/> is a symlink.
        /// </returns>
        private unsafe System.Boolean GetIsSymlink()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_is_symlink(info_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the modification time of the current @info and sets it
        /// in @result.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="result">
        /// a #GTimeVal.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_get_modification_time(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="GLib.TimeVal" type="GTimeVal*" managed-name="GISharp.Lib.GLib.TimeVal" is-pointer="1" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        GISharp.Lib.GLib.TimeVal* result);

        /// <summary>
        /// Gets the modification time of the current <paramref name="info"/> and sets it
        /// in <paramref name="result"/>.
        /// </summary>
        /// <param name="result">
        /// a #GTimeVal.
        /// </param>
        public unsafe void GetModificationTime(out GISharp.Lib.GLib.TimeVal result)
        {
            var info_ = Handle;
            GISharp.Lib.GLib.TimeVal result_;
            g_file_info_get_modification_time(info_, &result_);
            result = (GISharp.Lib.GLib.TimeVal)result_;
        }

        /// <summary>
        /// Gets the name for a file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the file name.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="filename" type="const char*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the name for a file.
        /// </summary>
        /// <returns>
        /// a string containing the file name.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Filename GetName()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_name(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Filename>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the file's size.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a #goffset containing the file's size.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int64 g_file_info_get_size(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the file's size.
        /// </summary>
        /// <returns>
        /// a #goffset containing the file's size.
        /// </returns>
        private unsafe System.Int64 GetSize()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_size(info_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the value of the sort_order attribute from the #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_SORT_ORDER.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a #gint32 containing the value of the "standard::sort_order" attribute.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint32" type="gint32" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_file_info_get_sort_order(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the value of the sort_order attribute from the <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_SORT_ORDER.
        /// </summary>
        /// <returns>
        /// a #gint32 containing the value of the "standard::sort_order" attribute.
        /// </returns>
        private unsafe System.Int32 GetSortOrder()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_sort_order(info_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the symbolic icon for a file.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// #GIcon for the given @info.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_symbolic_icon(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the symbolic icon for a file.
        /// </summary>
        /// <returns>
        /// <see cref="IIcon"/> for the given <paramref name="info"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.34")]
        private unsafe GISharp.Lib.Gio.IIcon GetSymbolicIcon()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_symbolic_icon(info_);
            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Gets the symlink target for a given #GFileInfo.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <returns>
        /// a string containing the symlink target.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_info_get_symlink_target(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Gets the symlink target for a given <see cref="FileInfo"/>.
        /// </summary>
        /// <returns>
        /// a string containing the symlink target.
        /// </returns>
        private unsafe GISharp.Lib.GLib.Utf8 GetSymlinkTarget()
        {
            var info_ = Handle;
            var ret_ = g_file_info_get_symlink_target(info_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Checks if a file info structure has an attribute named @attribute.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// %TRUE if @Ginfo has an attribute named @attribute,
        ///     %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_has_attribute(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Checks if a file info structure has an attribute named <paramref name="attribute"/>.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="ginfo"/> has an attribute named <paramref name="attribute"/>,
        ///     <c>false</c> otherwise.
        /// </returns>
        public unsafe System.Boolean HasAttribute(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_info_has_attribute(info_,attribute_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Checks if a file info structure has an attribute in the
        /// specified @name_space.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="nameSpace">
        /// a file attribute namespace.
        /// </param>
        /// <returns>
        /// %TRUE if @Ginfo has an attribute in @name_space,
        ///     %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_has_namespace(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr nameSpace);

        /// <summary>
        /// Checks if a file info structure has an attribute in the
        /// specified <paramref name="nameSpace"/>.
        /// </summary>
        /// <param name="nameSpace">
        /// a file attribute namespace.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="ginfo"/> has an attribute in <paramref name="nameSpace"/>,
        ///     <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe System.Boolean HasNamespace(GISharp.Lib.GLib.Utf8 nameSpace)
        {
            var info_ = Handle;
            var nameSpace_ = nameSpace?.Handle ?? throw new System.ArgumentNullException(nameof(nameSpace));
            var ret_ = g_file_info_has_namespace(info_,nameSpace_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Lists the file info structure's attributes.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="nameSpace">
        /// a file attribute key's namespace, or %NULL to list
        ///   all attributes.
        /// </param>
        /// <returns>
        /// a
        /// null-terminated array of strings of all of the possible attribute
        /// types for the given @name_space, or %NULL on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="char**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_file_info_list_attributes(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr nameSpace);

        /// <summary>
        /// Lists the file info structure's attributes.
        /// </summary>
        /// <param name="nameSpace">
        /// a file attribute key's namespace, or <c>null</c> to list
        ///   all attributes.
        /// </param>
        /// <returns>
        /// a
        /// null-terminated array of strings of all of the possible attribute
        /// types for the given <paramref name="nameSpace"/>, or <c>null</c> on error.
        /// </returns>
        public unsafe GISharp.Lib.GLib.Strv ListAttributes(GISharp.Lib.GLib.Utf8 nameSpace)
        {
            var info_ = Handle;
            var nameSpace_ = nameSpace?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_file_info_list_attributes(info_,nameSpace_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Removes all cases of @attribute from @info if it exists.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_remove_attribute(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Removes all cases of <paramref name="attribute"/> from <paramref name="info"/> if it exists.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        public unsafe void RemoveAttribute(GISharp.Lib.GLib.Utf8 attribute)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            g_file_info_remove_attribute(info_, attribute_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given value, if possible. To unset the
        /// attribute, use %G_ATTRIBUTE_TYPE_INVALID for @type.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="type">
        /// a #GFileAttributeType
        /// </param>
        /// <param name="valueP">
        /// pointer to the value
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="FileAttributeType" type="GFileAttributeType" managed-name="FileAttributeType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeType type,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr valueP);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given value, if possible. To unset the
        /// attribute, use %G_ATTRIBUTE_TYPE_INVALID for <paramref name="type"/>.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="type">
        /// a <see cref="FileAttributeType"/>
        /// </param>
        /// <param name="valueP">
        /// pointer to the value
        /// </param>
        public unsafe void SetAttribute(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.Gio.FileAttributeType type, System.IntPtr valueP)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var type_ = (GISharp.Lib.Gio.FileAttributeType)type;
            var valueP_ = (System.IntPtr)valueP;
            g_file_info_set_attribute(info_, attribute_, type_, valueP_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a boolean value.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_boolean(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a boolean value.
        /// </param>
        public unsafe void SetAttributeBoolean(GISharp.Lib.GLib.Utf8 attribute, System.Boolean attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = (System.Boolean)attrValue;
            g_file_info_set_attribute_boolean(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a byte string.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_byte_string(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a byte string.
        /// </param>
        public unsafe void SetAttributeByteString(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.GLib.Utf8 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = attrValue?.Handle ?? throw new System.ArgumentNullException(nameof(attrValue));
            g_file_info_set_attribute_byte_string(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a signed 32-bit integer
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_int32(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="gint32" type="gint32" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a signed 32-bit integer
        /// </param>
        public unsafe void SetAttributeInt32(GISharp.Lib.GLib.Utf8 attribute, System.Int32 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = (System.Int32)attrValue;
            g_file_info_set_attribute_int32(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// attribute name to set.
        /// </param>
        /// <param name="attrValue">
        /// int64 value to set attribute to.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_int64(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// attribute name to set.
        /// </param>
        /// <param name="attrValue">
        /// int64 value to set attribute to.
        /// </param>
        public unsafe void SetAttributeInt64(GISharp.Lib.GLib.Utf8 attribute, System.Int64 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = (System.Int64)attrValue;
            g_file_info_set_attribute_int64(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets @mask on @info to match specific attribute types.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="mask">
        /// a #GFileAttributeMatcher.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_mask(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr mask);

        /// <summary>
        /// Sets <paramref name="mask"/> on <paramref name="info"/> to match specific attribute types.
        /// </summary>
        /// <param name="mask">
        /// a <see cref="FileAttributeMatcher"/>.
        /// </param>
        public unsafe void SetAttributeMask(GISharp.Lib.Gio.FileAttributeMatcher mask)
        {
            var info_ = Handle;
            var mask_ = mask?.Handle ?? throw new System.ArgumentNullException(nameof(mask));
            g_file_info_set_attribute_mask(info_, mask_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a #GObject.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_object(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a #GObject.
        /// </param>
        public unsafe void SetAttributeObject(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.GObject.Object attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = attrValue?.Handle ?? throw new System.ArgumentNullException(nameof(attrValue));
            g_file_info_set_attribute_object(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the attribute status for an attribute key. This is only
        /// needed by external code that implement g_file_set_attributes_from_info()
        /// or similar functions.
        /// </summary>
        /// <remarks>
        /// The attribute must exist in @info for this to work. Otherwise %FALSE
        /// is returned and @info is unchanged.
        /// </remarks>
        /// <param name="info">
        /// a #GFileInfo
        /// </param>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="status">
        /// a #GFileAttributeStatus
        /// </param>
        /// <returns>
        /// %TRUE if the status was changed, %FALSE if the key was not set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_info_set_attribute_status(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="FileAttributeStatus" type="GFileAttributeStatus" managed-name="FileAttributeStatus" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeStatus status);

        /// <summary>
        /// Sets the attribute status for an attribute key. This is only
        /// needed by external code that implement g_file_set_attributes_from_info()
        /// or similar functions.
        /// </summary>
        /// <remarks>
        /// The attribute must exist in <paramref name="info"/> for this to work. Otherwise <c>false</c>
        /// is returned and <paramref name="info"/> is unchanged.
        /// </remarks>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="status">
        /// a <see cref="FileAttributeStatus"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the status was changed, <c>false</c> if the key was not set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public unsafe System.Boolean SetAttributeStatus(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.Gio.FileAttributeStatus status)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var status_ = (GISharp.Lib.Gio.FileAttributeStatus)status;
            var ret_ = g_file_info_set_attribute_status(info_,attribute_,status_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a UTF-8 string.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_string(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// a UTF-8 string.
        /// </param>
        public unsafe void SetAttributeString(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.GLib.Utf8 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = attrValue?.Handle ?? throw new System.ArgumentNullException(nameof(attrValue));
            g_file_info_set_attribute_string(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <remarks>
        /// Sinze: 2.22
        /// </remarks>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="attrValue">
        /// a %NULL terminated array of UTF-8 strings.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_stringv(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <array zero-terminated="1" type="char**" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <remarks>
        /// Sinze: 2.22
        /// </remarks>
        /// <param name="attribute">
        /// a file attribute key
        /// </param>
        /// <param name="attrValue">
        /// a <c>null</c> terminated array of UTF-8 strings.
        /// </param>
        public unsafe void SetAttributeStringv(GISharp.Lib.GLib.Utf8 attribute, GISharp.Lib.GLib.Strv attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = attrValue?.Handle ?? throw new System.ArgumentNullException(nameof(attrValue));
            g_file_info_set_attribute_stringv(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// an unsigned 32-bit integer.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_uint32(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="guint32" type="guint32" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// an unsigned 32-bit integer.
        /// </param>
        public unsafe void SetAttributeUint32(GISharp.Lib.GLib.Utf8 attribute, System.UInt32 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = (System.UInt32)attrValue;
            g_file_info_set_attribute_uint32(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the @attribute to contain the given @attr_value,
        /// if possible.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// an unsigned 64-bit integer.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_attribute_uint64(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute,
        /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:in */
        System.UInt64 attrValue);

        /// <summary>
        /// Sets the <paramref name="attribute"/> to contain the given <paramref name="attrValue"/>,
        /// if possible.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <param name="attrValue">
        /// an unsigned 64-bit integer.
        /// </param>
        public unsafe void SetAttributeUint64(GISharp.Lib.GLib.Utf8 attribute, System.UInt64 attrValue)
        {
            var info_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var attrValue_ = (System.UInt64)attrValue;
            g_file_info_set_attribute_uint64(info_, attribute_, attrValue_);
        }

        /// <summary>
        /// Sets the content type attribute for a given #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_CONTENT_TYPE.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="contentType">
        /// a content type. See [GContentType][gio-GContentType]
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_content_type(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr contentType);

        /// <summary>
        /// Sets the content type attribute for a given <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_CONTENT_TYPE.
        /// </summary>
        /// <param name="contentType">
        /// a content type. See [GContentType][gio-GContentType]
        /// </param>
        private unsafe void SetContentType(GISharp.Lib.GLib.Utf8 contentType)
        {
            var info_ = Handle;
            var contentType_ = contentType?.Handle ?? throw new System.ArgumentNullException(nameof(contentType));
            g_file_info_set_content_type(info_, contentType_);
        }

        /// <summary>
        /// Sets the display name for the current #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_DISPLAY_NAME.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="displayName">
        /// a string containing a display name.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_display_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr displayName);

        /// <summary>
        /// Sets the display name for the current <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_DISPLAY_NAME.
        /// </summary>
        /// <param name="displayName">
        /// a string containing a display name.
        /// </param>
        private unsafe void SetDisplayName(GISharp.Lib.GLib.Utf8 displayName)
        {
            var info_ = Handle;
            var displayName_ = displayName?.Handle ?? throw new System.ArgumentNullException(nameof(displayName));
            g_file_info_set_display_name(info_, displayName_);
        }

        /// <summary>
        /// Sets the edit name for the current file.
        /// See %G_FILE_ATTRIBUTE_STANDARD_EDIT_NAME.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="editName">
        /// a string containing an edit name.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_edit_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr editName);

        /// <summary>
        /// Sets the edit name for the current file.
        /// See %G_FILE_ATTRIBUTE_STANDARD_EDIT_NAME.
        /// </summary>
        /// <param name="editName">
        /// a string containing an edit name.
        /// </param>
        private unsafe void SetEditName(GISharp.Lib.GLib.Utf8 editName)
        {
            var info_ = Handle;
            var editName_ = editName?.Handle ?? throw new System.ArgumentNullException(nameof(editName));
            g_file_info_set_edit_name(info_, editName_);
        }

        /// <summary>
        /// Sets the file type in a #GFileInfo to @type.
        /// See %G_FILE_ATTRIBUTE_STANDARD_TYPE.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="type">
        /// a #GFileType.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_file_type(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="FileType" type="GFileType" managed-name="FileType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileType type);

        /// <summary>
        /// Sets the file type in a <see cref="FileInfo"/> to <paramref name="type"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_TYPE.
        /// </summary>
        /// <param name="type">
        /// a <see cref="FileType"/>.
        /// </param>
        private unsafe void SetFileType(GISharp.Lib.Gio.FileType type)
        {
            var info_ = Handle;
            var type_ = (GISharp.Lib.Gio.FileType)type;
            g_file_info_set_file_type(info_, type_);
        }

        /// <summary>
        /// Sets the icon for a given #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_ICON.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="icon">
        /// a #GIcon.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_icon(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Sets the icon for a given <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_ICON.
        /// </summary>
        /// <param name="icon">
        /// a <see cref="IIcon"/>.
        /// </param>
        private unsafe void SetIcon(GISharp.Lib.Gio.IIcon icon)
        {
            var info_ = Handle;
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            g_file_info_set_icon(info_, icon_);
        }

        /// <summary>
        /// Sets the "is_hidden" attribute in a #GFileInfo according to @is_hidden.
        /// See %G_FILE_ATTRIBUTE_STANDARD_IS_HIDDEN.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="isHidden">
        /// a #gboolean.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_is_hidden(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean isHidden);

        /// <summary>
        /// Sets the "is_hidden" attribute in a <see cref="FileInfo"/> according to <paramref name="isHidden"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_IS_HIDDEN.
        /// </summary>
        /// <param name="isHidden">
        /// a #gboolean.
        /// </param>
        private unsafe void SetIsHidden(System.Boolean isHidden)
        {
            var info_ = Handle;
            var isHidden_ = (System.Boolean)isHidden;
            g_file_info_set_is_hidden(info_, isHidden_);
        }

        /// <summary>
        /// Sets the "is_symlink" attribute in a #GFileInfo according to @is_symlink.
        /// See %G_FILE_ATTRIBUTE_STANDARD_IS_SYMLINK.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="isSymlink">
        /// a #gboolean.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_is_symlink(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean isSymlink);

        /// <summary>
        /// Sets the "is_symlink" attribute in a <see cref="FileInfo"/> according to <paramref name="isSymlink"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_IS_SYMLINK.
        /// </summary>
        /// <param name="isSymlink">
        /// a #gboolean.
        /// </param>
        private unsafe void SetIsSymlink(System.Boolean isSymlink)
        {
            var info_ = Handle;
            var isSymlink_ = (System.Boolean)isSymlink;
            g_file_info_set_is_symlink(info_, isSymlink_);
        }

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_TIME_MODIFIED attribute in the file
        /// info to the given time value.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="mtime">
        /// a #GTimeVal.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_modification_time(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="GLib.TimeVal" type="GTimeVal*" managed-name="GISharp.Lib.GLib.TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* mtime);

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_TIME_MODIFIED attribute in the file
        /// info to the given time value.
        /// </summary>
        /// <param name="mtime">
        /// a #GTimeVal.
        /// </param>
        public unsafe void SetModificationTime(GISharp.Lib.GLib.TimeVal mtime)
        {
            var info_ = Handle;
            var mtime_ = (GISharp.Lib.GLib.TimeVal)mtime;
            g_file_info_set_modification_time(info_, &mtime_);
        }

        /// <summary>
        /// Sets the name attribute for the current #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_NAME.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="name">
        /// a string containing a name.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_name(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="filename" type="const char*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name);

        /// <summary>
        /// Sets the name attribute for the current <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_NAME.
        /// </summary>
        /// <param name="name">
        /// a string containing a name.
        /// </param>
        private unsafe void SetName(GISharp.Lib.GLib.Filename name)
        {
            var info_ = Handle;
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            g_file_info_set_name(info_, name_);
        }

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_STANDARD_SIZE attribute in the file info
        /// to the given size.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="size">
        /// a #goffset containing the file's size.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_size(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 size);

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_STANDARD_SIZE attribute in the file info
        /// to the given size.
        /// </summary>
        /// <param name="size">
        /// a #goffset containing the file's size.
        /// </param>
        private unsafe void SetSize(System.Int64 size)
        {
            var info_ = Handle;
            var size_ = (System.Int64)size;
            g_file_info_set_size(info_, size_);
        }

        /// <summary>
        /// Sets the sort order attribute in the file info structure. See
        /// %G_FILE_ATTRIBUTE_STANDARD_SORT_ORDER.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="sortOrder">
        /// a sort order integer.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_sort_order(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="gint32" type="gint32" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 sortOrder);

        /// <summary>
        /// Sets the sort order attribute in the file info structure. See
        /// %G_FILE_ATTRIBUTE_STANDARD_SORT_ORDER.
        /// </summary>
        /// <param name="sortOrder">
        /// a sort order integer.
        /// </param>
        private unsafe void SetSortOrder(System.Int32 sortOrder)
        {
            var info_ = Handle;
            var sortOrder_ = (System.Int32)sortOrder;
            g_file_info_set_sort_order(info_, sortOrder_);
        }

        /// <summary>
        /// Sets the symbolic icon for a given #GFileInfo.
        /// See %G_FILE_ATTRIBUTE_STANDARD_SYMBOLIC_ICON.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="icon">
        /// a #GIcon.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.34")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_symbolic_icon(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);

        /// <summary>
        /// Sets the symbolic icon for a given <see cref="FileInfo"/>.
        /// See %G_FILE_ATTRIBUTE_STANDARD_SYMBOLIC_ICON.
        /// </summary>
        /// <param name="icon">
        /// a <see cref="IIcon"/>.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.34")]
        private unsafe void SetSymbolicIcon(GISharp.Lib.Gio.IIcon icon)
        {
            var info_ = Handle;
            var icon_ = icon?.Handle ?? throw new System.ArgumentNullException(nameof(icon));
            g_file_info_set_symbolic_icon(info_, icon_);
        }

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_STANDARD_SYMLINK_TARGET attribute in the file info
        /// to the given symlink target.
        /// </summary>
        /// <param name="info">
        /// a #GFileInfo.
        /// </param>
        /// <param name="symlinkTarget">
        /// a static string containing a path to a symlink target.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_set_symlink_target(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr symlinkTarget);

        /// <summary>
        /// Sets the %G_FILE_ATTRIBUTE_STANDARD_SYMLINK_TARGET attribute in the file info
        /// to the given symlink target.
        /// </summary>
        /// <param name="symlinkTarget">
        /// a static string containing a path to a symlink target.
        /// </param>
        private unsafe void SetSymlinkTarget(GISharp.Lib.GLib.Utf8 symlinkTarget)
        {
            var info_ = Handle;
            var symlinkTarget_ = symlinkTarget?.Handle ?? throw new System.ArgumentNullException(nameof(symlinkTarget));
            g_file_info_set_symlink_target(info_, symlinkTarget_);
        }

        /// <summary>
        /// Unsets a mask set by g_file_info_set_attribute_mask(), if one
        /// is set.
        /// </summary>
        /// <param name="info">
        /// #GFileInfo.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_info_unset_attribute_mask(
        /* <type name="FileInfo" type="GFileInfo*" managed-name="FileInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr info);

        /// <summary>
        /// Unsets a mask set by <see cref="FileInfo.SetAttributeMask"/>, if one
        /// is set.
        /// </summary>
        public unsafe void UnsetAttributeMask()
        {
            var info_ = Handle;
            g_file_info_unset_attribute_mask(info_);
        }
    }
}