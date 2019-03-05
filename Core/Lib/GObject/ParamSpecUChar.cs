using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamUChar", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecUChar : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public byte Minimum;
            public byte Maximum;
            public byte DefaultValue;
            #pragma warning restore CS0649
        }

        public byte Minimum => Marshal.ReadByte(Handle, (int)minimumOffset);

        public byte Maximum => Marshal.ReadByte(Handle, (int)maximumOffset);

        public new byte DefaultValue => Marshal.ReadByte(Handle, (int)defaultValueOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecUChar (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[1];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uchar (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            byte min,
            byte max,
            byte defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_uchar (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag (ParamFlags.StaticName)) {
                GMarshal.Free (namePtr);
            }
            if (!flags.HasFlag (ParamFlags.StaticNick)) {
                GMarshal.Free (nickPtr);
            }
            if (!flags.HasFlag (ParamFlags.StaticBlurb)) {
                GMarshal.Free (blurbPtr);
            }

            return ret;
        }

        public ParamSpecUChar (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
