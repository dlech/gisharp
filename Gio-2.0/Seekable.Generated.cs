namespace GISharp.Lib.Gio
{
    /// <summary>
    /// <see cref="ISeekable"/> is implemented by streams (implementations of
    /// <see cref="InputStream"/> or <see cref="OutputStream"/>) that support seeking.
    /// </summary>
    /// <remarks>
    /// Seekable streams largely fall into two categories: resizable and
    /// fixed-size.
    /// 
    /// <see cref="ISeekable"/> on fixed-sized streams is approximately the same as POSIX
    /// lseek() on a block device (for example: attmepting to seek past the
    /// end of the device is an error).  Fixed streams typically cannot be
    /// truncated.
    /// 
    /// <see cref="ISeekable"/> on resizable streams is approximately the same as POSIX
    /// lseek() on a normal file.  Seeking past the end and writing data will
    /// usually cause the stream to resize by introducing zero bytes.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GSeekable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(SeekableIface))]
    public partial interface ISeekable : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        /// <summary>
        /// Tests if the stream supports the <see cref="SeekableIface"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <paramref name="seekable"/> can be seeked. <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedCanSeek))]
        System.Boolean DoCanSeek();

        /// <summary>
        /// Tests if the length of the stream can be adjusted with
        /// <see cref="ISeekable.Truncate"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream can be truncated, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedCanTruncate))]
        System.Boolean DoCanTruncate();

        /// <summary>
        /// Seeks in the stream by the given <paramref name="offset"/>, modified by <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// Attempting to seek past the end of the stream will have different
        /// results depending on if the stream is fixed-sized or resizable.  If
        /// the stream is resizable then seeking past the end and then writing
        /// will result in zeros filling the empty space.  Seeking past the end
        /// of a resizable stream and reading will result in EOF.  Seeking past
        /// the end of a fixed-sized stream will fail.
        /// 
        /// Any operation that would result in a negative offset will fail.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// </remarks>
        /// <param name="offset">
        /// a #goffset.
        /// </param>
        /// <param name="type">
        /// a #GSeekType.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful. If an error
        ///     has occurred, this function will return <c>false</c> and set <paramref name="error"/>
        ///     appropriately if present.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedSeek))]
        void DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable = null);

        /// <summary>
        /// Tells the current position within the stream.
        /// </summary>
        /// <returns>
        /// the offset from the beginning of the buffer.
        /// </returns>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedTell))]
        System.Int64 DoTell();

        /// <summary>
        /// Sets the length of the stream to <paramref name="offset"/>. If the stream was previously
        /// larger than <paramref name="offset"/>, the extra data is discarded. If the stream was
        /// previouly shorter than <paramref name="offset"/>, it is extended with NUL ('\0') bytes.
        /// </summary>
        /// <remarks>
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="offset">
        /// new length for <paramref name="seekable"/>, in bytes.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <returns>
        /// <c>true</c> if successful. If an error
        ///     has occurred, this function will return <c>false</c> and set <paramref name="error"/>
        ///     appropriately if present.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedTruncateFn))]
        void DoTruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable cancellable = null);
    }

    public static class Seekable
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_seekable_get_type();

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_seekable_get_type();

        /// <summary>
        /// Tests if the stream supports the #GSeekableIface.
        /// </summary>
        /// <param name="seekable">
        /// a #GSeekable.
        /// </param>
        /// <returns>
        /// %TRUE if @seekable can be seeked. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_seekable_can_seek(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);

        /// <summary>
        /// Tests if the stream supports the <see cref="SeekableIface"/>.
        /// </summary>
        /// <param name="seekable">
        /// a <see cref="ISeekable"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="seekable"/> can be seeked. <c>false</c> otherwise.
        /// </returns>
        public unsafe static System.Boolean CanSeek(this GISharp.Lib.Gio.ISeekable seekable)
        {
            var seekable_ = seekable?.Handle ?? throw new System.ArgumentNullException(nameof(seekable));
            var ret_ = g_seekable_can_seek(seekable_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Tests if the length of the stream can be adjusted with
        /// g_seekable_truncate().
        /// </summary>
        /// <param name="seekable">
        /// a #GSeekable.
        /// </param>
        /// <returns>
        /// %TRUE if the stream can be truncated, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_seekable_can_truncate(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);

        /// <summary>
        /// Tests if the length of the stream can be adjusted with
        /// <see cref="ISeekable.Truncate"/>.
        /// </summary>
        /// <param name="seekable">
        /// a <see cref="ISeekable"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the stream can be truncated, <c>false</c> otherwise.
        /// </returns>
        public unsafe static System.Boolean CanTruncate(this GISharp.Lib.Gio.ISeekable seekable)
        {
            var seekable_ = seekable?.Handle ?? throw new System.ArgumentNullException(nameof(seekable));
            var ret_ = g_seekable_can_truncate(seekable_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Seeks in the stream by the given @offset, modified by @type.
        /// </summary>
        /// <remarks>
        /// Attempting to seek past the end of the stream will have different
        /// results depending on if the stream is fixed-sized or resizable.  If
        /// the stream is resizable then seeking past the end and then writing
        /// will result in zeros filling the empty space.  Seeking past the end
        /// of a resizable stream and reading will result in EOF.  Seeking past
        /// the end of a fixed-sized stream will fail.
        /// 
        /// Any operation that would result in a negative offset will fail.
        /// 
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned.
        /// </remarks>
        /// <param name="seekable">
        /// a #GSeekable.
        /// </param>
        /// <param name="offset">
        /// a #goffset.
        /// </param>
        /// <param name="type">
        /// a #GSeekType.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful. If an error
        ///     has occurred, this function will return %FALSE and set @error
        ///     appropriately if present.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_seekable_seek(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable,
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 offset,
        /* <type name="GLib.SeekType" type="GSeekType" managed-name="GISharp.Lib.GLib.SeekType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.SeekType type,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Seeks in the stream by the given <paramref name="offset"/>, modified by <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// Attempting to seek past the end of the stream will have different
        /// results depending on if the stream is fixed-sized or resizable.  If
        /// the stream is resizable then seeking past the end and then writing
        /// will result in zeros filling the empty space.  Seeking past the end
        /// of a resizable stream and reading will result in EOF.  Seeking past
        /// the end of a fixed-sized stream will fail.
        /// 
        /// Any operation that would result in a negative offset will fail.
        /// 
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned.
        /// </remarks>
        /// <param name="seekable">
        /// a <see cref="ISeekable"/>.
        /// </param>
        /// <param name="offset">
        /// a #goffset.
        /// </param>
        /// <param name="type">
        /// a #GSeekType.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe static void Seek(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var seekable_ = seekable?.Handle ?? throw new System.ArgumentNullException(nameof(seekable));
            var offset_ = (System.Int64)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_seekable_seek(seekable_, offset_, type_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Tells the current position within the stream.
        /// </summary>
        /// <param name="seekable">
        /// a #GSeekable.
        /// </param>
        /// <returns>
        /// the offset from the beginning of the buffer.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int64 g_seekable_tell(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);

        /// <summary>
        /// Tells the current position within the stream.
        /// </summary>
        /// <param name="seekable">
        /// a <see cref="ISeekable"/>.
        /// </param>
        /// <returns>
        /// the offset from the beginning of the buffer.
        /// </returns>
        public unsafe static System.Int64 Tell(this GISharp.Lib.Gio.ISeekable seekable)
        {
            var seekable_ = seekable?.Handle ?? throw new System.ArgumentNullException(nameof(seekable));
            var ret_ = g_seekable_tell(seekable_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Sets the length of the stream to @offset. If the stream was previously
        /// larger than @offset, the extra data is discarded. If the stream was
        /// previouly shorter than @offset, it is extended with NUL ('\0') bytes.
        /// </summary>
        /// <remarks>
        /// If @cancellable is not %NULL, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error %G_IO_ERROR_CANCELLED will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="seekable">
        /// a #GSeekable.
        /// </param>
        /// <param name="offset">
        /// new length for @seekable, in bytes.
        /// </param>
        /// <param name="cancellable">
        /// optional #GCancellable object, %NULL to ignore.
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful. If an error
        ///     has occurred, this function will return %FALSE and set @error
        ///     appropriately if present.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_seekable_truncate(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable,
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 offset,
        /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr cancellable,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Sets the length of the stream to <paramref name="offset"/>. If the stream was previously
        /// larger than <paramref name="offset"/>, the extra data is discarded. If the stream was
        /// previouly shorter than <paramref name="offset"/>, it is extended with NUL ('\0') bytes.
        /// </summary>
        /// <remarks>
        /// If <paramref name="cancellable"/> is not <c>null</c>, then the operation can be cancelled by
        /// triggering the cancellable object from another thread. If the operation
        /// was cancelled, the error <see cref="IOErrorEnum.Cancelled"/> will be returned. If an
        /// operation was partially finished when the operation was cancelled the
        /// partial result will be returned, without an error.
        /// </remarks>
        /// <param name="seekable">
        /// a <see cref="ISeekable"/>.
        /// </param>
        /// <param name="offset">
        /// new length for <paramref name="seekable"/>, in bytes.
        /// </param>
        /// <param name="cancellable">
        /// optional <see cref="Cancellable"/> object, <c>null</c> to ignore.
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        public unsafe static void Truncate(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.Gio.Cancellable cancellable = null)
        {
            var seekable_ = seekable?.Handle ?? throw new System.ArgumentNullException(nameof(seekable));
            var offset_ = (System.Int64)offset;
            var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_seekable_truncate(seekable_, offset_, cancellable_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }
    }
}