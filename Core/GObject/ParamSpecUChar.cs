using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamUChar", IsWrappedNativeType = true)]
    sealed class ParamSpecUChar : ParamSpec
    {
        struct ParamSpecUCharStruct
        {
            public ParamSpecStruct ParentInstance;
            public byte Minimum;
            public byte Maximum;
            public byte DefaultValue;
        }

        public byte Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUCharStruct> (nameof (ParamSpecUCharStruct.Minimum));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return ret;
            }
        }

        public byte Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUCharStruct> (nameof (ParamSpecUCharStruct.Maximum));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return ret;
            }
        }

        public new byte DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUCharStruct> (nameof (ParamSpecUCharStruct.DefaultValue));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[1];
        }

        ParamSpecUChar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUChar (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uchar (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            byte min,
            byte max,
            byte defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_uchar (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
