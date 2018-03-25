using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for pointer properties.
    /// </summary>
    [GType ("GParamPointer", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecPointer : ParamSpec
    {
        new struct Struct
        {
            #pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            #pragma warning restore CS0649
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecPointer (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[17];

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_pointer (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, ParamFlags flags)
        {
            if (name == null) {
                throw new ArgumentNullException (nameof (name));
            }
            if (nick == null) {
                throw new ArgumentNullException (nameof (nick));
            }
            if (blurb == null) {
                throw new ArgumentNullException (nameof (blurb));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret = g_param_spec_pointer (namePtr, nickPtr, blurbPtr, flags);

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

        public ParamSpecPointer (string name, string nick, string blurb, ParamFlags flags)
            : this (New (name, nick, blurb, flags), Transfer.None)
        {
        }
    }
}
