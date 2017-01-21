using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamLong", IsWrappedNativeType = true)]
    sealed class ParamSpecLong : ParamSpec
    {
        struct ParamSpecLongStruct
        {
            public ParamSpecStruct ParentInstance;
            public nlong Minimum;
            public nlong Maximum;
            public nlong DefaultValue;
        }

        public nlong Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecLongStruct> (nameof (ParamSpecLongStruct.Minimum));
                var ret = Marshal.PtrToStructure<nlong> (Handle + (int)offset);
                return ret;
            }
        }

        public nlong Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecLongStruct> (nameof (ParamSpecLongStruct.Maximum));
                var ret = Marshal.PtrToStructure<nlong> (Handle + (int)offset);
                return ret;
            }
        }

        public new nlong DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecLongStruct> (nameof (ParamSpecLongStruct.DefaultValue));
                var ret = Marshal.PtrToStructure<nlong> (Handle + (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[5];
        }

        ParamSpecLong (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecLong (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_long (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nlong min,
            nlong max,
            nlong defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_long (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
