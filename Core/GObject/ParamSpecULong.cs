using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamULong", IsWrappedNativeType = true)]
    sealed class ParamSpecULong : ParamSpec
    {
        struct ParamSpecULongStruct
        {
            public ParamSpecStruct ParentInstance;
            public nulong Minimum;
            public nulong Maximum;
            public nulong DefaultValue;
        }

        public nulong Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecULongStruct> (nameof (ParamSpecULongStruct.Minimum));
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)offset);
                return ret;
            }
        }

        public nulong Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecULongStruct> (nameof (ParamSpecULongStruct.Maximum));
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)offset);
                return ret;
            }
        }

        public new nulong DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecULongStruct> (nameof (ParamSpecULongStruct.DefaultValue));
                var ret = Marshal.PtrToStructure<nulong> (Handle + (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[6];
        }

        ParamSpecULong (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecULong (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_ulong (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nulong min,
            nulong max,
            nulong defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_ulong (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
