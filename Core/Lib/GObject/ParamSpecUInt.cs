using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType("GParamUInt", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecUInt : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct>(nameof(Struct.DefaultValue));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public uint Minimum;
            public uint Maximum;
            public uint DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public uint Minimum => (uint)Marshal.ReadInt32(Handle, (int)minimumOffset);

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public uint Maximum => (uint)Marshal.ReadInt32(Handle, (int)maximumOffset);

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new uint DefaultValue => (uint)Marshal.ReadInt32(Handle, (int)defaultValueOffset);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecUInt(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[4];


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint min,
            uint max,
            uint defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_uint(namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecUInt"/> instance specifying a
        /// <see cref="GType.UInt"/> property.
        /// </summary>
        public ParamSpecUInt(string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
