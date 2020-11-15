using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for string properties.
    /// </summary>
    [GType("GParamString", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecString : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecString"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// default value for the property specified
            /// </summary>
            public IntPtr DefaultValue;

            /// <summary>
            /// a string containing the allowed values for the first byte
            /// </summary>
            public IntPtr CsetFirst;

            /// <summary>
            /// a string containing the allowed values for the subsequent bytes
            /// </summary>
            public IntPtr CsetNth;

            /// <summary>
            /// the replacement byte for bytes which don't match cset_first or cset_nth .
            /// </summary>
            public sbyte Substitutor;

            /// <summary>
            /// null_fold_if_empty : 1; replace empty string by NULL
            /// ensure_non_null : 1; replace NULL strings by an empty string
            /// </summary>
            public uint Bitfield;
#pragma warning restore CS0649
        }

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new UnownedUtf8 DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->DefaultValue;
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the first byte
        /// </summary>
        public unsafe NullableUnownedUtf8 CsetFirst {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->CsetFirst;
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the subsequent bytes
        /// </summary>
        public unsafe NullableUnownedUtf8 CsetNth {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->CsetNth;
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// the replacement byte for bytes which don't match <see cref="CsetFirst"/>
        /// or <see cref="CsetNth"/> .
        /// </summary>
        public unsafe sbyte Substitutor => ((UnmanagedStruct*)Handle)->Substitutor;

        unsafe uint Bitfield => ((UnmanagedStruct*)Handle)->Bitfield;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecString(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// replace empty string by <c>null</c>
        /// </summary>
        public bool NullFoldIfEmpty {
            get {
                var ret = Convert.ToBoolean(Bitfield & 0x1);
                return ret;
            }
        }

        /// <summary>
        /// replace <c>null</c> strings by an empty string
        /// </summary>
        public bool EnsureNonNull {
            get {
                var ret = Convert.ToBoolean(Bitfield & 0x2);
                return ret;
            }
        }

        static readonly GType _GType = paramSpecTypes[14];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_string(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, string? defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var defaultValuePtr = GMarshal.StringToUtf8Ptr(defaultValue);
            var ret = g_param_spec_string(namePtr, nickPtr, blurbPtr, defaultValuePtr, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(namePtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nickPtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurbPtr);
            }
            GMarshal.Free(defaultValuePtr);

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecString"/> instance specifying a
        /// <see cref="GType.String"/> property.
        /// </summary>
        public ParamSpecString(string name, string nick, string blurb, string? defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, defaultValue, flags), Transfer.None)
        {
        }
    }
}
