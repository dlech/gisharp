namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Provides an interface for implementing seekable functionality on I/O Streams.
    /// </summary>
    public sealed class SeekableIface : GISharp.Lib.GObject.TypeInterface
    {
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            /// <summary>
            /// The parent interface.
            /// </summary>
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;
            public UnmanagedTell Tell;
            public UnmanagedCanSeek CanSeek;
            public UnmanagedSeek Seek;
            public UnmanagedCanTruncate CanTruncate;
            public UnmanagedTruncateFn TruncateFn;
#pragma warning restore CS0649
        }

        static SeekableIface()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Tell));
            RegisterVirtualMethod(tellOffset, TellFactory.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekFactory.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Seek));
            RegisterVirtualMethod(seekOffset, SeekFactory.Create);
            System.Int32 canTruncateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanTruncate));
            RegisterVirtualMethod(canTruncateOffset, CanTruncateFactory.Create);
            System.Int32 truncateFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.TruncateFn));
            RegisterVirtualMethod(truncateFnOffset, TruncateFnFactory.Create);
        }

        public delegate System.Int64 Tell();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int64 UnmanagedTell(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Factory for creating <see cref="Tell"/> methods.
        /// </summary>
        public static class TellFactory
        {
            public static unsafe UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int64 tell(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None);
                        var doTell = (Tell)methodInfo.CreateDelegate(typeof(Tell), seekable);
                        var ret = doTell();
                        var ret_ = (System.Int64)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Int64);
                }

                return tell;
            }
        }

        public delegate System.Boolean CanSeek();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedCanSeek(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Factory for creating <see cref="CanSeek"/> methods.
        /// </summary>
        public static class CanSeekFactory
        {
            public static unsafe UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean canSeek(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None);
                        var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), seekable);
                        var ret = doCanSeek();
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return canSeek;
            }
        }

        public delegate void Seek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate System.Boolean UnmanagedSeek(
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
        /// Factory for creating <see cref="Seek"/> methods.
        /// </summary>
        public static class SeekFactory
        {
            public static unsafe UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean seek(System.IntPtr seekable_, System.Int64 offset_, GISharp.Lib.GLib.SeekType type_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None);
                        var offset = (System.Int64)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), seekable);
                        doSeek(offset, type, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return seek;
            }
        }

        public delegate System.Boolean CanTruncate();

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Boolean UnmanagedCanTruncate(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Factory for creating <see cref="CanTruncate"/> methods.
        /// </summary>
        public static class CanTruncateFactory
        {
            public static unsafe UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean canTruncate(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None);
                        var doCanTruncate = (CanTruncate)methodInfo.CreateDelegate(typeof(CanTruncate), seekable);
                        var ret = doCanTruncate();
                        var ret_ = (System.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return canTruncate;
            }
        }

        public delegate void TruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable cancellable = null);

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate System.Boolean UnmanagedTruncateFn(
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
        /// Factory for creating <see cref="TruncateFn"/> methods.
        /// </summary>
        public static class TruncateFnFactory
        {
            public static unsafe UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Boolean truncateFn(System.IntPtr seekable_, System.Int64 offset_, System.IntPtr cancellable_, System.IntPtr* error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None);
                        var offset = (System.Int64)offset_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doTruncateFn = (TruncateFn)methodInfo.CreateDelegate(typeof(TruncateFn), seekable);
                        doTruncateFn(offset, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(System.Boolean);
                }

                return truncateFn;
            }
        }

        public SeekableIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}