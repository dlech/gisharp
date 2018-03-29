namespace GISharp.Lib.Gio
{
    public static partial class FileAttribute
    {
        /// <summary>
        /// A key in the "access" namespace for checking deletion privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to delete the file.
        /// </summary>
        public const System.String AccessCanDelete = "access::can-delete";

        /// <summary>
        /// A key in the "access" namespace for getting execution privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to execute the file.
        /// </summary>
        public const System.String AccessCanExecute = "access::can-execute";

        /// <summary>
        /// A key in the "access" namespace for getting read privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to read the file.
        /// </summary>
        public const System.String AccessCanRead = "access::can-read";

        /// <summary>
        /// A key in the "access" namespace for checking renaming privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to rename the file.
        /// </summary>
        public const System.String AccessCanRename = "access::can-rename";

        /// <summary>
        /// A key in the "access" namespace for checking trashing privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to move the file to
        /// the trash.
        /// </summary>
        public const System.String AccessCanTrash = "access::can-trash";

        /// <summary>
        /// A key in the "access" namespace for getting write privileges.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// This attribute will be <c>true</c> if the user is able to write to the file.
        /// </summary>
        public const System.String AccessCanWrite = "access::can-write";

        /// <summary>
        /// A key in the "dos" namespace for checking if the file's archive flag
        /// is set. This attribute is <c>true</c> if the archive flag is set. This attribute
        /// is only available for DOS file systems. Corresponding <see cref="FileAttributeType"/>
        /// is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String DosIsArchive = "dos::is-archive";

        /// <summary>
        /// A key in the "dos" namespace for checking if the file's backup flag
        /// is set. This attribute is <c>true</c> if the backup flag is set. This attribute
        /// is only available for DOS file systems. Corresponding <see cref="FileAttributeType"/>
        /// is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String DosIsSystem = "dos::is-system";

        /// <summary>
        /// A key in the "etag" namespace for getting the value of the file's
        /// entity tag. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String EtagValue = "etag::value";

        /// <summary>
        /// A key in the "filesystem" namespace for getting the number of bytes of free space left on the
        /// file system. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        public const System.String FilesystemFree = "filesystem::free";

        /// <summary>
        /// A key in the "filesystem" namespace for checking if the file system
        /// is read only. Is set to <c>true</c> if the file system is read only.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String FilesystemReadonly = "filesystem::readonly";

        /// <summary>
        /// A key in the "filesystem" namespace for checking if the file system
        /// is remote. Is set to <c>true</c> if the file system is remote.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String FilesystemRemote = "filesystem::remote";

        /// <summary>
        /// A key in the "filesystem" namespace for getting the total size (in bytes) of the file system,
        /// used in g_file_query_filesystem_info(). Corresponding <see cref="FileAttributeType"/>
        /// is <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        public const System.String FilesystemSize = "filesystem::size";

        /// <summary>
        /// A key in the "filesystem" namespace for getting the file system's type.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String FilesystemType = "filesystem::type";

        /// <summary>
        /// A key in the "filesystem" namespace for getting the number of bytes of used on the
        /// file system. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public const System.String FilesystemUsed = "filesystem::used";

        /// <summary>
        /// A key in the "filesystem" namespace for hinting a file manager
        /// application whether it should preview (e.g. thumbnail) files on the
        /// file system. The value for this key contain a
        /// #GFilesystemPreviewType.
        /// </summary>
        public const System.String FilesystemUsePreview = "filesystem::use-preview";

        /// <summary>
        /// A key in the "gvfs" namespace that gets the name of the current
        /// GVFS backend in use. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String GvfsBackend = "gvfs::backend";

        /// <summary>
        /// A key in the "id" namespace for getting a file identifier.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// An example use would be during listing files, to avoid recursive
        /// directory scanning.
        /// </summary>
        public const System.String IdFile = "id::file";

        /// <summary>
        /// A key in the "id" namespace for getting the file system identifier.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// An example use would be during drag and drop to see if the source
        /// and target are on the same filesystem (default to move) or not (default
        /// to copy).
        /// </summary>
        public const System.String IdFilesystem = "id::filesystem";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) can be ejected.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String MountableCanEject = "mountable::can-eject";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) is mountable.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String MountableCanMount = "mountable::can-mount";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) can be polled.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableCanPoll = "mountable::can-poll";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) can be started.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableCanStart = "mountable::can-start";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) can be started
        /// degraded.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableCanStartDegraded = "mountable::can-start-degraded";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE) can be stopped.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableCanStop = "mountable::can-stop";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE)  is unmountable.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String MountableCanUnmount = "mountable::can-unmount";

        /// <summary>
        /// A key in the "mountable" namespace for getting the HAL UDI for the mountable
        /// file. Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String MountableHalUdi = "mountable::hal-udi";

        /// <summary>
        /// A key in the "mountable" namespace for checking if a file (of type G_FILE_TYPE_MOUNTABLE)
        /// is automatically polled for media.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableIsMediaCheckAutomatic = "mountable::is-media-check-automatic";

        /// <summary>
        /// A key in the "mountable" namespace for getting the #GDriveStartStopType.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableStartStopType = "mountable::start-stop-type";

        /// <summary>
        /// A key in the "mountable" namespace for getting the unix device.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String MountableUnixDevice = "mountable::unix-device";

        /// <summary>
        /// A key in the "mountable" namespace for getting the unix device file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.22")]
        public const System.String MountableUnixDeviceFile = "mountable::unix-device-file";

        /// <summary>
        /// A key in the "owner" namespace for getting the file owner's group.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String OwnerGroup = "owner::group";

        /// <summary>
        /// A key in the "owner" namespace for getting the user name of the
        /// file's owner. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String OwnerUser = "owner::user";

        /// <summary>
        /// A key in the "owner" namespace for getting the real name of the
        /// user that owns the file. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String OwnerUserReal = "owner::user-real";

        /// <summary>
        /// A key in the "preview" namespace for getting a <see cref="IIcon"/> that can be
        /// used to get preview of the file. For example, it may be a low
        /// resolution thumbnail without metadata. Corresponding
        /// <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Object"/>.  The value
        /// for this key should contain a <see cref="IIcon"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public const System.String PreviewIcon = "preview::icon";

        /// <summary>
        /// A key in the "recent" namespace for getting time, when the metadata for the
        /// file in `recent:///` was last changed. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Int64"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.52")]
        public const System.String RecentModified = "recent::modified";

        /// <summary>
        /// A key in the "selinux" namespace for getting the file's SELinux
        /// context. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.String"/>. Note that this attribute is only
        /// available if GLib has been built with SELinux support.
        /// </summary>
        public const System.String SelinuxContext = "selinux::context";

        /// <summary>
        /// A key in the "standard" namespace for getting the amount of disk space
        /// that is consumed by the file (in bytes).  This will generally be larger
        /// than the file size (due to block size overhead) but can occasionally be
        /// smaller (for example, for sparse files).
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.20")]
        public const System.String StandardAllocatedSize = "standard::allocated-size";

        /// <summary>
        /// A key in the "standard" namespace for getting the content type of the file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// The value for this key should contain a valid content type.
        /// </summary>
        public const System.String StandardContentType = "standard::content-type";

        /// <summary>
        /// A key in the "standard" namespace for getting the copy name of the file.
        /// The copy name is an optional version of the name. If available it's always
        /// in UTF8, and corresponds directly to the original filename (only transcoded to
        /// UTF8). This is useful if you want to copy the file to another filesystem that
        /// might have a different encoding. If the filename is not a valid string in the
        /// encoding selected for the filesystem it is in then the copy name will not be set.
        /// </summary>
        /// <remarks>
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </remarks>
        public const System.String StandardCopyName = "standard::copy-name";

        /// <summary>
        /// A key in the "standard" namespace for getting the description of the file.
        /// The description is a utf8 string that describes the file, generally containing
        /// the filename, but can also contain furter information. Example descriptions
        /// could be "filename (on hostname)" for a remote file or "filename (in trash)"
        /// for a file in the trash. This is useful for instance as the window title
        /// when displaying a directory or for a bookmarks menu.
        /// </summary>
        /// <remarks>
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </remarks>
        public const System.String StandardDescription = "standard::description";

        /// <summary>
        /// A key in the "standard" namespace for getting the display name of the file.
        /// A display name is guaranteed to be in UTF8 and can thus be displayed in
        /// the UI.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String StandardDisplayName = "standard::display-name";

        /// <summary>
        /// A key in the "standard" namespace for edit name of the file.
        /// An edit name is similar to the display name, but it is meant to be
        /// used when you want to rename the file in the UI. The display name
        /// might contain information you don't want in the new filename (such as
        /// "(invalid unicode)" if the filename was in an invalid encoding).
        /// </summary>
        /// <remarks>
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </remarks>
        public const System.String StandardEditName = "standard::edit-name";

        /// <summary>
        /// A key in the "standard" namespace for getting the fast content type.
        /// The fast content type isn't as reliable as the regular one, as it
        /// only uses the filename to guess it, but it is faster to calculate than the
        /// regular content type.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String StandardFastContentType = "standard::fast-content-type";

        /// <summary>
        /// A key in the "standard" namespace for getting the icon for the file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Object"/>.
        /// The value for this key should contain a <see cref="IIcon"/>.
        /// </summary>
        public const System.String StandardIcon = "standard::icon";

        /// <summary>
        /// A key in the "standard" namespace for checking if a file is a backup file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String StandardIsBackup = "standard::is-backup";

        /// <summary>
        /// A key in the "standard" namespace for checking if a file is hidden.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String StandardIsHidden = "standard::is-hidden";

        /// <summary>
        /// A key in the "standard" namespace for checking if the file is a symlink.
        /// Typically the actual type is something else, if we followed the symlink
        /// to get the type.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String StandardIsSymlink = "standard::is-symlink";

        /// <summary>
        /// A key in the "standard" namespace for checking if a file is virtual.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String StandardIsVirtual = "standard::is-virtual";

        /// <summary>
        /// A key in the "standard" namespace for checking if a file is
        /// volatile. This is meant for opaque, non-POSIX-like backends to
        /// indicate that the URI is not persistent. Applications should look
        /// at #G_FILE_ATTRIBUTE_STANDARD_SYMLINK_TARGET for the persistent URI.
        /// </summary>
        /// <remarks>
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.46")]
        public const System.String StandardIsVolatile = "standard::is-volatile";

        /// <summary>
        /// A key in the "standard" namespace for getting the name of the file.
        /// The name is the on-disk filename which may not be in any known encoding,
        /// and can thus not be generally displayed as is.
        /// Use #G_FILE_ATTRIBUTE_STANDARD_DISPLAY_NAME if you need to display the
        /// name in a user interface.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.ByteString"/>.
        /// </summary>
        public const System.String StandardName = "standard::name";

        /// <summary>
        /// A key in the "standard" namespace for getting the file's size (in bytes).
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        public const System.String StandardSize = "standard::size";

        /// <summary>
        /// A key in the "standard" namespace for setting the sort order of a file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Int32"/>.
        /// An example use would be in file managers, which would use this key
        /// to set the order files are displayed. Files with smaller sort order
        /// should be sorted first, and files without sort order as if sort order
        /// was zero.
        /// </summary>
        public const System.String StandardSortOrder = "standard::sort-order";

        /// <summary>
        /// A key in the "standard" namespace for getting the symbolic icon for the file.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Object"/>.
        /// The value for this key should contain a <see cref="IIcon"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.34")]
        public const System.String StandardSymbolicIcon = "standard::symbolic-icon";

        /// <summary>
        /// A key in the "standard" namespace for getting the symlink target, if the file
        /// is a symlink. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.ByteString"/>.
        /// </summary>
        public const System.String StandardSymlinkTarget = "standard::symlink-target";

        /// <summary>
        /// A key in the "standard" namespace for getting the target URI for the file, in
        /// the case of <see cref="FileType.Shortcut"/> or <see cref="FileType.Mountable"/> files.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        public const System.String StandardTargetUri = "standard::target-uri";

        /// <summary>
        /// A key in the "standard" namespace for storing file types.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// The value for this key should contain a <see cref="FileType"/>.
        /// </summary>
        public const System.String StandardType = "standard::type";

        /// <summary>
        /// A key in the "thumbnail" namespace for checking if thumbnailing failed.
        /// This attribute is <c>true</c> if thumbnailing failed. Corresponding
        /// <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String ThumbnailingFailed = "thumbnail::failed";

        /// <summary>
        /// A key in the "thumbnail" namespace for checking whether the thumbnail is outdated.
        /// This attribute is <c>true</c> if the thumbnail is up-to-date with the file it represents,
        /// and <c>false</c> if the file has been modified since the thumbnail was generated.
        /// </summary>
        /// <remarks>
        /// If %G_FILE_ATTRIBUTE_THUMBNAILING_FAILED is <c>true</c> and this attribute is <c>false</c>,
        /// it indicates that thumbnailing may be attempted again and may succeed.
        /// 
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public const System.String ThumbnailIsValid = "thumbnail::is-valid";

        /// <summary>
        /// A key in the "thumbnail" namespace for getting the path to the thumbnail
        /// image. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.ByteString"/>.
        /// </summary>
        public const System.String ThumbnailPath = "thumbnail::path";

        /// <summary>
        /// A key in the "time" namespace for getting the time the file was last
        /// accessed. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint64"/>, and contains the time since the
        /// file was last accessed, in seconds since the UNIX epoch.
        /// </summary>
        public const System.String TimeAccess = "time::access";

        /// <summary>
        /// A key in the "time" namespace for getting the microseconds of the time
        /// the file was last accessed. This should be used in conjunction with
        /// #G_FILE_ATTRIBUTE_TIME_ACCESS. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String TimeAccessUsec = "time::access-usec";

        /// <summary>
        /// A key in the "time" namespace for getting the time the file was last
        /// changed. Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>,
        /// and contains the time since the file was last changed, in seconds since the
        /// UNIX epoch.
        /// </summary>
        /// <remarks>
        /// This corresponds to the traditional UNIX ctime.
        /// </remarks>
        public const System.String TimeChanged = "time::changed";

        /// <summary>
        /// A key in the "time" namespace for getting the microseconds of the time
        /// the file was last changed. This should be used in conjunction with
        /// #G_FILE_ATTRIBUTE_TIME_CHANGED. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String TimeChangedUsec = "time::changed-usec";

        /// <summary>
        /// A key in the "time" namespace for getting the time the file was created.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>,
        /// and contains the time since the file was created, in seconds since the UNIX
        /// epoch.
        /// </summary>
        /// <remarks>
        /// This corresponds to the NTFS ctime.
        /// </remarks>
        public const System.String TimeCreated = "time::created";

        /// <summary>
        /// A key in the "time" namespace for getting the microseconds of the time
        /// the file was created. This should be used in conjunction with
        /// #G_FILE_ATTRIBUTE_TIME_CREATED. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String TimeCreatedUsec = "time::created-usec";

        /// <summary>
        /// A key in the "time" namespace for getting the time the file was last
        /// modified. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint64"/>, and contains the time since the
        /// file was modified, in seconds since the UNIX epoch.
        /// </summary>
        public const System.String TimeModified = "time::modified";

        /// <summary>
        /// A key in the "time" namespace for getting the microseconds of the time
        /// the file was last modified. This should be used in conjunction with
        /// #G_FILE_ATTRIBUTE_TIME_MODIFIED. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String TimeModifiedUsec = "time::modified-usec";

        /// <summary>
        /// A key in the "trash" namespace.  When requested against
        /// items in `trash:///`, will return the date and time when the file
        /// was trashed. The format of the returned string is YYYY-MM-DDThh:mm:ss.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.String"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public const System.String TrashDeletionDate = "trash::deletion-date";

        /// <summary>
        /// A key in the "trash" namespace.  When requested against
        /// `trash:///` returns the number of (toplevel) items in the trash folder.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String TrashItemCount = "trash::item-count";

        /// <summary>
        /// A key in the "trash" namespace.  When requested against
        /// items in `trash:///`, will return the original path to the file before it
        /// was trashed. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.ByteString"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public const System.String TrashOrigPath = "trash::orig-path";

        /// <summary>
        /// A key in the "unix" namespace for getting the number of blocks allocated
        /// for the file. This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        public const System.String UnixBlocks = "unix::blocks";

        /// <summary>
        /// A key in the "unix" namespace for getting the block size for the file
        /// system. This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixBlockSize = "unix::block-size";

        /// <summary>
        /// A key in the "unix" namespace for getting the device id of the device the
        /// file is located on (see stat() documentation). This attribute is only
        /// available for UNIX file systems. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixDevice = "unix::device";

        /// <summary>
        /// A key in the "unix" namespace for getting the group ID for the file.
        /// This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixGid = "unix::gid";

        /// <summary>
        /// A key in the "unix" namespace for getting the inode of the file.
        /// This attribute is only available for UNIX file systems. Corresponding
        /// <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint64"/>.
        /// </summary>
        public const System.String UnixInode = "unix::inode";

        /// <summary>
        /// A key in the "unix" namespace for checking if the file represents a
        /// UNIX mount point. This attribute is <c>true</c> if the file is a UNIX mount
        /// point. This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Boolean"/>.
        /// </summary>
        public const System.String UnixIsMountpoint = "unix::is-mountpoint";

        /// <summary>
        /// A key in the "unix" namespace for getting the mode of the file
        /// (e.g. whether the file is a regular file, symlink, etc). See lstat()
        /// documentation. This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixMode = "unix::mode";

        /// <summary>
        /// A key in the "unix" namespace for getting the number of hard links
        /// for a file. See lstat() documentation. This attribute is only available
        /// for UNIX file systems. Corresponding <see cref="FileAttributeType"/> is
        /// <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixNlink = "unix::nlink";

        /// <summary>
        /// A key in the "unix" namespace for getting the device ID for the file
        /// (if it is a special file). See lstat() documentation. This attribute
        /// is only available for UNIX file systems. Corresponding <see cref="FileAttributeType"/>
        /// is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixRdev = "unix::rdev";

        /// <summary>
        /// A key in the "unix" namespace for getting the user ID for the file.
        /// This attribute is only available for UNIX file systems.
        /// Corresponding <see cref="FileAttributeType"/> is <see cref="FileAttributeType.Uint32"/>.
        /// </summary>
        public const System.String UnixUid = "unix::uid";
    }
}