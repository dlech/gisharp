using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for boxed properties.
    /// </summary>
    [GType("GParamBoxed", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecBoxed : ParamSpec
    {
        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
#pragma warning restore CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecBoxed(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[16];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boxed(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType boxedType,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, GType boxedType, ParamFlags flags)
        {
            if (!boxedType.IsA(GType.Boxed)) {
                throw new ArgumentException("Expecting boxed type.", nameof(boxedType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_boxed(namePtr, nickPtr, blurbPtr, boxedType, flags);

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
        /// Creates a new <see cref="ParamSpecBoxed"/> instance specifying a
        /// <see cref="GType.Boxed"/> property.
        /// </summary>
        public ParamSpecBoxed(string name, string nick, string blurb, GType boxedType, ParamFlags flags)
            : this(New(name, nick, blurb, boxedType, flags), Transfer.None)
        {
        }
    }
}
