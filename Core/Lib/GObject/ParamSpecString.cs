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
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct>(nameof(Struct.DefaultValue));
        static readonly IntPtr csetFirstOffset = Marshal.OffsetOf<Struct>(nameof(Struct.CsetFirst));
        static readonly IntPtr csetNthOffset = Marshal.OffsetOf<Struct>(nameof(Struct.CsetNth));
        static readonly IntPtr substitutorOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Substitutor));
        static readonly IntPtr bitfieldOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Bitfield));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public IntPtr DefaultValue;
            public IntPtr CsetFirst;
            public IntPtr CsetNth;
            public sbyte Substitutor;
            public uint Bitfield;
#pragma warning restore CS0649
        }

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new UnownedUtf8 DefaultValue {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)defaultValueOffset);
                var ret = new UnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the first byte
        /// </summary>
        public NullableUnownedUtf8 CsetFirst {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)csetFirstOffset);
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the subsequent bytes
        /// </summary>
        public NullableUnownedUtf8 CsetNth {
            get {
                var ret_ = Marshal.ReadIntPtr(Handle, (int)csetNthOffset);
                var ret = new NullableUnownedUtf8(ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// the replacement byte for bytes which don't match <see cref="CsetFirst"/>
        /// or <see cref="CsetNth"/> .
        /// </summary>
        public sbyte Substitutor => (sbyte)Marshal.ReadByte(Handle, (int)substitutorOffset);

        uint Bitfield => (uint)Marshal.ReadInt32(Handle, (int)bitfieldOffset);

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
