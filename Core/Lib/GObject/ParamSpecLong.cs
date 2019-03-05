using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamLong", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecLong : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public nlong Minimum;
            public nlong Maximum;
            public nlong DefaultValue;
            #pragma warning restore CS0649
        }

        public nlong Minimum => Marshal.PtrToStructure<nlong>(Handle + (int)minimumOffset);

        public nlong Maximum => Marshal.PtrToStructure<nlong>(Handle + (int)maximumOffset);

        public new nlong DefaultValue => Marshal.PtrToStructure<nlong>(Handle + (int)defaultValueOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecLong (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[5];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_long (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nlong min,
            nlong max,
            nlong defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_long (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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

        public ParamSpecLong (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
