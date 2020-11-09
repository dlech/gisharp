using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType("GParamUnichar", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecUnichar : ParamSpec
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            public ParamSpec.UnmanagedStruct ParentInstance;
            public uint DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new uint DefaultValue => ((UnmanagedStruct*)Handle)->DefaultValue;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecUnichar(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[9];


        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_unichar(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, uint defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_unichar(namePtr, nickPtr, blurbPtr, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecUnichar"/> instance specifying a
        /// <see cref="GType.UInt"/> property. <see cref="Value"/> structures
        /// for this property can be accessed with <see cref="Value.UInt"/>.
        /// </summary>
        public ParamSpecUnichar(string name, string nick, string blurb, int defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, (uint)defaultValue, flags), Transfer.None)
        {
        }
    }
}
