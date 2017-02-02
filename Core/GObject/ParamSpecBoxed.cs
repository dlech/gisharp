using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for boxed properties.
    /// </summary>
    [GType ("GParamBoxed", IsWrappedNativeType = true)]
    public sealed class ParamSpecBoxed : ParamSpec
    {
        public sealed class SafeParamSpecBoxedHandle : SafeParamSpecHandle
        {
            struct ParamSpecBoxed
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                #pragma warning restore CS0649
            }

            public SafeParamSpecBoxedHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecBoxedHandle Handle {
            get {
                return (SafeParamSpecBoxedHandle)base.Handle;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[16];
        }

        public ParamSpecBoxed (SafeParamSpecBoxedHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boxed (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType boxedType,
            ParamFlags flags);

        static SafeParamSpecBoxedHandle New (string name, string nick, string blurb, GType boxedType, ParamFlags flags)
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
            if (!boxedType.IsA (GType.Boxed)) {
                throw new ArgumentException ("Expecting boxed type.", nameof (boxedType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret_ = g_param_spec_boxed (namePtr, nickPtr, blurbPtr, boxedType, flags);
            var ret = new SafeParamSpecBoxedHandle (ret_, Transfer.Full);

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

        public ParamSpecBoxed (string name, string nick, string blurb, GType boxedType, ParamFlags flags)
            : this (New (name, nick, blurb, boxedType, flags))
        {
        }
    }
}
