using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for <see cref="ParamSpec"/>
    /// properties.
    /// </summary>
    [GType ("GParamParam", IsWrappedNativeType = true)]
    public sealed class ParamSpecParam : ParamSpec
    {
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            struct ParamSpecParam
            {
#pragma warning disable CS0649
                public ParamSpecStruct parentInstance;
#pragma warning restore CS0649
            }

            public SafeHandle (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }

            public SafeHandle ()
            {
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

        static GType getGType ()
        {
            return paramSpecTypes[15];
        }

        public ParamSpecParam (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_param (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType paramType,
            ParamFlags flags);

        static SafeHandle New (string name, string nick, string blurb, GType paramType, ParamFlags flags)
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
            if (!paramType.IsA (GType.Param)) {
                throw new ArgumentException ("Expecting param type.", nameof (paramType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret_ = g_param_spec_param (namePtr, nickPtr, blurbPtr, paramType, flags);
            var ret = new SafeHandle (ret_, Transfer.None);

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

        public ParamSpecParam (string name, string nick, string blurb, GType paramType, ParamFlags flags)
            : this (New (name, nick, blurb, paramType, flags))
        {
        }
    }
}
