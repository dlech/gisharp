// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable']/*" />
    [GISharp.Runtime.GTypeAttribute("GSeekable", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(SeekableIface))]
    public partial interface ISeekable : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_seekable_get_type();

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_seekable_get_type();

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable.DoCanSeek()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedCanSeek))]
        System.Boolean DoCanSeek();

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable.DoCanTruncate()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedCanTruncate))]
        System.Boolean DoCanTruncate();

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable.DoSeek(System.Int64,GISharp.Lib.GLib.SeekType,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedSeek))]
        void DoSeek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable.DoTell()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedTell))]
        System.Int64 DoTell();

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='ISeekable.DoTruncateFn(System.Int64,GISharp.Lib.Gio.Cancellable?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(SeekableIface.UnmanagedTruncateFn))]
        void DoTruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable? cancellable = null);
    }

    /// <summary>
    /// Extension methods for <see cref="ISeekable"/>
    /// </summary>
    public static partial class Seekable
    {
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
        private static extern unsafe GISharp.Runtime.Boolean g_seekable_can_seek(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);
        static partial void CheckCanSeekArgs(this GISharp.Lib.Gio.ISeekable seekable);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='Seekable.CanSeek(GISharp.Lib.Gio.ISeekable)']/*" />
        public unsafe static System.Boolean CanSeek(this GISharp.Lib.Gio.ISeekable seekable)
        {
            CheckCanSeekArgs(seekable);
            var seekable_ = seekable.UnsafeHandle;
            var ret_ = g_seekable_can_seek(seekable_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        private static extern unsafe GISharp.Runtime.Boolean g_seekable_can_truncate(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);
        static partial void CheckCanTruncateArgs(this GISharp.Lib.Gio.ISeekable seekable);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='Seekable.CanTruncate(GISharp.Lib.Gio.ISeekable)']/*" />
        public unsafe static System.Boolean CanTruncate(this GISharp.Lib.Gio.ISeekable seekable)
        {
            CheckCanTruncateArgs(seekable);
            var seekable_ = seekable.UnsafeHandle;
            var ret_ = g_seekable_can_truncate(seekable_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        private static extern unsafe GISharp.Runtime.Boolean g_seekable_seek(
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
        ref System.IntPtr error);
        static partial void CheckSeekArgs(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='Seekable.Seek(GISharp.Lib.Gio.ISeekable,System.Int64,GISharp.Lib.GLib.SeekType,GISharp.Lib.Gio.Cancellable?)']/*" />
        public unsafe static void Seek(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckSeekArgs(seekable, offset, type, cancellable);
            var seekable_ = seekable.UnsafeHandle;
            var offset_ = (System.Int64)offset;
            var type_ = (GISharp.Lib.GLib.SeekType)type;
            var cancellable_ = cancellable?.UnsafeHandle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_seekable_seek(seekable_, offset_, type_, cancellable_, ref error_);
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
        private static extern unsafe System.Int64 g_seekable_tell(
        /* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr seekable);
        static partial void CheckTellArgs(this GISharp.Lib.Gio.ISeekable seekable);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='Seekable.Tell(GISharp.Lib.Gio.ISeekable)']/*" />
        public unsafe static System.Int64 Tell(this GISharp.Lib.Gio.ISeekable seekable)
        {
            CheckTellArgs(seekable);
            var seekable_ = seekable.UnsafeHandle;
            var ret_ = g_seekable_tell(seekable_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Sets the length of the stream to @offset. If the stream was previously
        /// larger than @offset, the extra data is discarded. If the stream was
        /// previously shorter than @offset, it is extended with NUL ('\0') bytes.
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
        private static extern unsafe GISharp.Runtime.Boolean g_seekable_truncate(
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
        ref System.IntPtr error);
        static partial void CheckTruncateArgs(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <include file="Seekable.xmldoc" path="declaration/member[@name='Seekable.Truncate(GISharp.Lib.Gio.ISeekable,System.Int64,GISharp.Lib.Gio.Cancellable?)']/*" />
        public unsafe static void Truncate(this GISharp.Lib.Gio.ISeekable seekable, System.Int64 offset, GISharp.Lib.Gio.Cancellable? cancellable = null)
        {
            CheckTruncateArgs(seekable, offset, cancellable);
            var seekable_ = seekable.UnsafeHandle;
            var offset_ = (System.Int64)offset;
            var cancellable_ = cancellable?.UnsafeHandle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_seekable_truncate(seekable_, offset_, cancellable_, ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }
    }
}