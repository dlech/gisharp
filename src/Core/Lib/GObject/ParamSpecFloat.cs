using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for float properties.
    /// </summary>
    [GType("GParamFloat", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecFloat : ParamSpec
    {
        static readonly IntPtr minimumOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Minimum));
        static readonly IntPtr maximumOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Maximum));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct>(nameof(Struct.DefaultValue));
        static readonly IntPtr epsilonOffset = Marshal.OffsetOf<Struct>(nameof(Struct.Epsilon));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public float Minimum;
            public float Maximum;
            public float DefaultValue;
            public float Epsilon;
#pragma warning restore CS0649
        }

        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public float Minimum => Marshal.PtrToStructure<float>(Handle + (int)minimumOffset);

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public float Maximum => Marshal.PtrToStructure<float>(Handle + (int)maximumOffset);

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new float DefaultValue => Marshal.PtrToStructure<float>(Handle + (int)defaultValueOffset);

        public float Epsilon => Marshal.PtrToStructure<float>(Handle + (int)epsilonOffset);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecFloat(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[12];


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_float(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            float min,
            float max,
            float defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_float(namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecFloat"/> instance specifying a
        /// <see cref="GType.Float"/> property.
        /// </summary>
        public ParamSpecFloat(string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}