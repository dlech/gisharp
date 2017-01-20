using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamUnichar", IsWrappedNativeType = true)]
    sealed class ParamSpecUnichar : ParamSpec
    {
        struct ParamSpecUnicharStruct
        {
            public ParamSpecStruct ParentInstance;
            public uint DefaultValue;
        }

        public new int DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUnicharStruct> (nameof (ParamSpecUnicharStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[9];
        }

        ParamSpecUnichar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUnichar (string name, string nick, string blurb, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, (uint)defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_unichar (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, uint defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_unichar (namePtr, nickPtr, blurbPtr, defaultValue, flags);

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

            return pspecPtr;
        }
    }
}
