using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for object properties.
    /// </summary>
    [GType("GParamObject", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecObject : ParamSpec
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            public ParamSpec.UnmanagedStruct ParentInstance;
#pragma warning restore CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecObject(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[19];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_object(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType objectType,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, GType objectType, ParamFlags flags)
        {
            if (!objectType.IsA(GType.Object)) {
                throw new ArgumentException("Expecting object type.", nameof(objectType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_object(namePtr, nickPtr, blurbPtr, objectType, flags);

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
        /// Creates a new <see cref="ParamSpecObject"/> instance specifying a
        /// <see cref="GType.Object"/> property.
        /// </summary>
        public ParamSpecObject(string name, string nick, string blurb, GType objectType, ParamFlags flags)
            : this(New(name, nick, blurb, objectType, flags), Transfer.None)
        {
        }
    }
}
