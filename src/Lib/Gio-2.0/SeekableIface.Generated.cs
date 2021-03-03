// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='SeekableIface']/*" />
    public sealed unsafe class SeekableIface : GISharp.Lib.GObject.TypeInterface
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GIface']/*" />
            public readonly GISharp.Lib.GObject.TypeInterface.UnmanagedStruct GIface;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Tell']/*" />
            public readonly System.IntPtr Tell;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanSeek']/*" />
            public readonly System.IntPtr CanSeek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.Seek']/*" />
            public readonly System.IntPtr Seek;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.CanTruncate']/*" />
            public readonly System.IntPtr CanTruncate;

            /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='UnmanagedStruct.TruncateFn']/*" />
            public readonly System.IntPtr TruncateFn;
#pragma warning restore CS0169, CS0649
        }

        static SeekableIface()
        {
            System.Int32 tellOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Tell));
            RegisterVirtualMethod(tellOffset, TellMarshal.Create);
            System.Int32 canSeekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanSeek));
            RegisterVirtualMethod(canSeekOffset, CanSeekMarshal.Create);
            System.Int32 seekOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Seek));
            RegisterVirtualMethod(seekOffset, SeekMarshal.Create);
            System.Int32 canTruncateOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.CanTruncate));
            RegisterVirtualMethod(canTruncateOffset, CanTruncateMarshal.Create);
            System.Int32 truncateFnOffset = (System.Int32)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.TruncateFn));
            RegisterVirtualMethod(truncateFnOffset, TruncateFnMarshal.Create);
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Tell']/*" />
        public delegate long Tell();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate long UnmanagedTell(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="Tell"/> methods.
        /// </summary>
        public static unsafe class TellMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTell Create(System.Reflection.MethodInfo methodInfo)
            {
                long unmanagedTell(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_) { try { var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!; var doTell = (Tell)methodInfo.CreateDelegate(typeof(Tell), seekable); var ret = doTell(); var ret_ = (long)ret; return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(long); }

                return unmanagedTell;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='CanSeek']/*" />
        public delegate System.Boolean CanSeek();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanSeek(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="CanSeek"/> methods.
        /// </summary>
        public static unsafe class CanSeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanSeek(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_) { try { var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!; var doCanSeek = (CanSeek)methodInfo.CreateDelegate(typeof(CanSeek), seekable); var ret = doCanSeek(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCanSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='Seek']/*" />
        public delegate void Seek(long offset, GISharp.Lib.GLib.SeekType type, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedSeek(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
long offset,
/* <type name="GLib.SeekType" type="GSeekType" managed-name="GISharp.Lib.GLib.SeekType" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.GLib.SeekType type,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="Seek"/> methods.
        /// </summary>
        public static unsafe class SeekMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedSeek Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedSeek(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_, long offset_, GISharp.Lib.GLib.SeekType type_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!; var offset = (long)offset_; var type = (GISharp.Lib.GLib.SeekType)type_; var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doSeek = (Seek)methodInfo.CreateDelegate(typeof(Seek), seekable); doSeek(offset, type, cancellable); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedSeek;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='CanTruncate']/*" />
        public delegate System.Boolean CanTruncate();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedCanTruncate(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable);

        /// <summary>
        /// Class for marshalling <see cref="CanTruncate"/> methods.
        /// </summary>
        public static unsafe class CanTruncateMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCanTruncate Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedCanTruncate(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_) { try { var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!; var doCanTruncate = (CanTruncate)methodInfo.CreateDelegate(typeof(CanTruncate), seekable); var ret = doCanTruncate(); var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret); return ret_; } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

                return unmanagedCanTruncate;
            }
        }

        /// <include file="SeekableIface.xmldoc" path="declaration/member[@name='TruncateFn']/*" />
        public delegate void TruncateFn(long offset, GISharp.Lib.Gio.Cancellable? cancellable = null);

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:in */
        public unsafe delegate GISharp.Runtime.Boolean UnmanagedTruncateFn(
/* <type name="Seekable" type="GSeekable*" managed-name="Seekable" is-pointer="1" /> */
/* transfer-ownership:none direction:in */
GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable,
/* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
/* transfer-ownership:none direction:in */
long offset,
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable,
/* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
/* direction:inout transfer-ownership:full */
GISharp.Lib.GLib.Error.UnmanagedStruct** error);

        /// <summary>
        /// Class for marshalling <see cref="TruncateFn"/> methods.
        /// </summary>
        public static unsafe class TruncateFnMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedTruncateFn Create(System.Reflection.MethodInfo methodInfo)
            {
                GISharp.Runtime.Boolean unmanagedTruncateFn(GISharp.Lib.Gio.Seekable.UnmanagedStruct* seekable_, long offset_, GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_) { try { var seekable = (GISharp.Lib.Gio.ISeekable)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)seekable_, GISharp.Runtime.Transfer.None)!; var offset = (long)offset_; var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doTruncateFn = (TruncateFn)methodInfo.CreateDelegate(typeof(TruncateFn), seekable); doTruncateFn(offset, cancellable); return GISharp.Runtime.Boolean.True; } catch (GISharp.Runtime.GErrorException ex) { GISharp.Runtime.GMarshal.PropagateError(error_, ex.Error); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } return default(GISharp.Runtime.Boolean); }

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