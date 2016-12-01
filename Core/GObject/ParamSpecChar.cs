using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{

    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamChar", IsWrappedNativeType = true)]
    sealed class ParamSpecChar : ParamSpec
    {
        struct ParamSpecCharStruct
        {
            public ParamSpecStruct ParentInstance;
            public sbyte Minimum;
            public sbyte Maximum;
            public sbyte DefaultValue;
        }

        public sbyte Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecCharStruct> (nameof (ParamSpecCharStruct.Minimum));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return (sbyte)ret;
            }
        }

        public sbyte Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecCharStruct> (nameof (ParamSpecCharStruct.Maximum));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return (sbyte)ret;
            }
        }

        public new sbyte DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecCharStruct> (nameof (ParamSpecCharStruct.DefaultValue));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return (sbyte)ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[0];
        }

        ParamSpecChar (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecChar (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_char (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            sbyte min,
            sbyte max,
            sbyte defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_char (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
