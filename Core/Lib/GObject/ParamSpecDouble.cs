using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for double properties.
    /// </summary>
    [GType ("GParamDouble", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecDouble : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));
        static readonly IntPtr epsilonOffset = Marshal.OffsetOf<Struct> (nameof (Struct.Epsilon));

        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public double Minimum;
            public double Maximum;
            public double DefaultValue;
            public double Epsilon;
            #pragma warning restore CS0649
        }

        public double Minimum => Marshal.PtrToStructure<double>(Handle + (int)minimumOffset);

        public double Maximum => Marshal.PtrToStructure<double>(Handle + (int)maximumOffset);

        public new double DefaultValue => Marshal.PtrToStructure<double>(Handle + (int)defaultValueOffset);

        public double Epsilon => Marshal.PtrToStructure<double>(Handle + (int)epsilonOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecDouble (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[13];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_double (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            double min,
            double max,
            double defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_double (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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

        public ParamSpecDouble (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
