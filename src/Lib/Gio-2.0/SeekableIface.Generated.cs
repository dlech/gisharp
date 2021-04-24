// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='SeekableIface']/*" />
    public sealed unsafe partial class SeekableIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0414, CS0649
            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Tell']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Seekable.UnmanagedStruct*, long> Tell;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanSeek']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Seekable.UnmanagedStruct*, GISharp.Runtime.Boolean> CanSeek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Seek']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Seekable.UnmanagedStruct*, long, GISharp.Lib.GLib.SeekType, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, GISharp.Runtime.Boolean> Seek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanTruncate']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Seekable.UnmanagedStruct*, GISharp.Runtime.Boolean> CanTruncate;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.TruncateFn']/*" />
            public readonly delegate* unmanaged[Cdecl]<GISharp.Lib.Gio.Seekable.UnmanagedStruct*, long, GISharp.Lib.Gio.Cancellable.UnmanagedStruct*, GISharp.Lib.GLib.Error.UnmanagedStruct**, GISharp.Runtime.Boolean> TruncateFn;
#pragma warning restore CS0169, CS0414, CS0649
        }

        static SeekableIface()
        {
            int tellOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Tell));
            RegisterVirtualMethod(tellOffset, TellMarshal.Create);
            int canSeekOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekMarshal.Create);
            int seekOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Seek));
            RegisterVirtualMethod(seekOffset, SeekMarshal.Create);
            int canTruncateOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanTruncate));
            RegisterVirtualMethod(canTruncateOffset, CanTruncateMarshal.Create);
            int truncateFnOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.TruncateFn));
            RegisterVirtualMethod(truncateFnOffset, TruncateFnMarshal.Create);
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='_Tell']/*" />
        public delegate long _Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate long UnmanagedTell(
/* <type name="Seekable" type="GSeekable*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="_Tell"/> methods.
        /// </summary>
        public static unsafe class TellMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                long unmanagedTell(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!;
                        var doTell = (_Tell)methodInfo.CreateDelegate(typeof(_Tell), seekable);
                        var ret = doTell();
                        var ret_ = (long)ret;
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(long);
                }

                return unmanagedTell;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='_CanSeek']/*" />
        public delegate bool _CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="Seekable" type="GSeekable*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="_CanSeek"/> methods.
        /// </summary>
        public static unsafe class CanSeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanSeek(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!;
                        var doCanSeek = (_CanSeek)methodInfo.CreateDelegate(typeof(_CanSeek), seekable);
                        var ret = doCanSeek();
                        var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='_Seek']/*" />
        public delegate void _Seek(long offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
/* <type name="Seekable" type="GSeekable*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable,
/* <type name="gint64" type="goffset" /> */
/* transfer-ownership:none direction:in */
long offset,
/* <type name="GLib.SeekType" type="GSeekType" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.SeekType type,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_Seek"/> methods.
        /// </summary>
        public static unsafe class SeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedSeek(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_, long offset_, GISharp.Lib.GLib.SeekType type_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!;
                        var offset = (long)offset_;
                        var type = (GISharp.Lib.GLib.SeekType)type_;
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doSeek = (_Seek)methodInfo.CreateDelegate(typeof(_Seek), seekable);
                        doSeek(offset, type, cancellable);
                        return GISharp.Runtime.Boolean.True;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='_CanTruncate']/*" />
        public delegate bool _CanTruncate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanTruncate(
/* <type name="Seekable" type="GSeekable*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="_CanTruncate"/> methods.
        /// </summary>
        public static unsafe class CanTruncateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanTruncate(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!;
                        var doCanTruncate = (_CanTruncate)methodInfo.CreateDelegate(typeof(_CanTruncate), seekable);
                        var ret = doCanTruncate();
                        var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                        return ret_;
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedCanTruncate;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='_TruncateFn']/*" />
        public delegate void _TruncateFn(long offset, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTruncateFn(
/* <type name="Seekable" type="GSeekable*" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable,
/* <type name="gint64" type="goffset" /> */
/* transfer-ownership:none direction:in */
long offset,
/* <type name="Cancellable" type="GCancellable*" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="_TruncateFn"/> methods.
        /// </summary>
        public static unsafe class TruncateFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTruncateFn(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_, long offset_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
                {
                    try
                    {
                        var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!;
                        var offset = (long)offset_;
                        var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None);
                        var doTruncateFn = (_TruncateFn)methodInfo.CreateDelegate(typeof(_TruncateFn), seekable);
                        doTruncateFn(offset, cancellable);
                        return GISharp.Runtime.Boolean.True;
                    }
                    catch (GISharp.Lib.GLib.Error.Exception ex)
                    {
                        GISharp.Lib.GLib.Error.Propagate(error_, ex.Error);
                    }
                    catch (System.Exception ex)
                    {
                        GISharp.Runtime.GMarshal.PushUnhandledException(ex);
                    }

                    return default(GISharp.Runtime.Boolean);
                }

                return unmanagedTruncateFn;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SeekableIface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}