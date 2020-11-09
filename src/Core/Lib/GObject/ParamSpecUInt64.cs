using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType("GParamUInt64", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecUInt64 : ParamSpec
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            public ParamSpec.UnmanagedStruct ParentInstance;
            public ulong Minimum;
            public ulong Maximum;
            public ulong DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public unsafe ulong Minimum => ((UnmanagedStruct*)Handle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public unsafe ulong Maximum => ((UnmanagedStruct*)Handle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new ulong DefaultValue => ((UnmanagedStruct*)Handle)->DefaultValue;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecUInt64(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[8];


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint64(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ulong min,
            ulong max,
            ulong defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_uint64(namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecUInt64"/> instance specifying a
        /// <see cref="GType.UInt64"/> property.
        /// </summary>
        public ParamSpecUInt64(string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
