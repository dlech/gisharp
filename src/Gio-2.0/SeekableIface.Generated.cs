// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='SeekableIface']/*" />
    public sealed class SeekableIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// Unmanaged data structure
        /// </summary>
        unsafe new struct Struct
        {
#pragma warning disable CS0649
            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.GIface']/*" />
            public GISharp.Lib.GObject.TypeInterface.Struct GIface;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.Tell']/*" />
            public System.IntPtr Tell;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.CanSeek']/*" />
            public System.IntPtr CanSeek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.Seek']/*" />
            public System.IntPtr Seek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.CanTruncate']/*" />
            public System.IntPtr CanTruncate;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Struct.TruncateFn']/*" />
            public System.IntPtr TruncateFn;
#pragma warning restore CS0649
        }

        static SeekableIface()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Tell));
            RegisterVirtualMethod(tellOffset, TellMarshal.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekMarshal.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.Seek));
            RegisterVirtualMethod(seekOffset, SeekMarshal.Create);
            System.Int32 canTruncateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.CanTruncate));
            RegisterVirtualMethod(canTruncateOffset, CanTruncateMarshal.Create);
            System.Int32 truncateFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<Struct>(nameof(Struct.TruncateFn));
            RegisterVirtualMethod(truncateFnOffset, TruncateFnMarshal.Create);
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Tell']/*" />
        public delegate System.Int64 Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate System.Int64 UnmanagedTell(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Class for marshalling <see cref="Tell"/> methods.
        /// </summary>
        public static class TellMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                System.Int64 unmanagedTell(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None)!;
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

                return unmanagedTell;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='CanSeek']/*" />
        public delegate System.Boolean CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Class for marshalling <see cref="CanSeek"/> methods.
        /// </summary>
        public static class CanSeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanSeek(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None)!;
                        var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), seekable);
                        var ret = doCanSeek();
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Seek']/*" />
        public delegate void Seek(System.Int64 offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
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

        /// <summary>
        /// Class for marshalling <see cref="Seek"/> methods.
        /// </summary>
        public static class SeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedSeek(System.IntPtr seekable_, System.Int64 offset_, GISharp.Lib.GLib.SeekType type_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None)!;
                        var offset = (System.Int64)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), seekable);
                        doSeek(offset, type, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='CanTruncate']/*" />
        public delegate System.Boolean CanTruncate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanTruncate(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
System.IntPtr seekable);

        /// <summary>
        /// Class for marshalling <see cref="CanTruncate"/> methods.
        /// </summary>
        public static class CanTruncateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanTruncate(System.IntPtr seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None)!;
                        var doCanTruncate = (CanTruncate)methodInfo.CreateDelegate(typeof(CanTruncate), seekable);
                        var ret = doCanTruncate();
                        var ret_ = (GISharp.Runtime.Boolean)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanTruncate;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='TruncateFn']/*" />
        public delegate void TruncateFn(System.Int64 offset, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTruncateFn(
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

        /// <summary>
        /// Class for marshalling <see cref="TruncateFn"/> methods.
        /// </summary>
        public static class TruncateFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static unsafe UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTruncateFn(System.IntPtr seekable_, System.Int64 offset_, System.IntPtr cancellable_, ref System.IntPtr error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance(seekable_, GISharp.Runtime.Transfer.None)!;
                        var offset = (System.Int64)offset_;
                        var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                        var doTruncateFn = (TruncateFn)methodInfo.CreateDelegate(typeof(TruncateFn), seekable);
                        doTruncateFn(offset, cancellable);
                        return true;
                    }
                    catch (GISharp.Runtime.GErrorException ex)
                    {
                        GISharp.Runtime.GMarshal.PropagateError(ref error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Lib.GLib.Log.LogUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedTruncateFn;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        public SeekableIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}