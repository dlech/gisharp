using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data
    /// for <see cref="GType"/> properties.
    /// </summary>
    [Since ("2.10")]
    [GType ("GParamGType", IsWrappedNativeType = true)]
    sealed class ParamSpecGType : ParamSpec
    {
        struct ParamSpecGTypeStruct
        {
            public ParamSpecStruct ParentInstance;
            public GType IsAType;
        }

        public GType IsAType {
            get {
                var offset = Marshal.OffsetOf<ParamSpecGTypeStruct> (nameof (ParamSpecGTypeStruct.IsAType));
                var ret = Marshal.PtrToStructure<GType> (Handle + (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[21];
        }

        ParamSpecGType (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecGType (string name, string nick, string blurb, GType isAType, ParamFlags flags)
            : this (New (name, nick, blurb, isAType, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_gtype (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType isAType,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, GType isAType, ParamFlags flags)
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
            var pspecPtr = g_param_spec_gtype (namePtr, nickPtr, blurbPtr, isAType, flags);

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
