using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for float properties.
    /// </summary>
    [GType ("GParamFloat", IsWrappedNativeType = true)]
    sealed class ParamSpecFloat : ParamSpec
    {
        struct ParamSpecFloatStruct
        {
            public ParamSpecStruct ParentInstance;
            public float Minimum;
            public float Maximum;
            public float DefaultValue;
            public float Epsilon;
        }

        public float Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFloatStruct> (nameof (ParamSpecFloatStruct.Minimum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return BitConverter.ToSingle (BitConverter.GetBytes (ret), 0);
            }
        }

        public float Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFloatStruct> (nameof (ParamSpecFloatStruct.Maximum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return BitConverter.ToSingle (BitConverter.GetBytes (ret), 0);
            }
        }

        public new float DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFloatStruct> (nameof (ParamSpecFloatStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return BitConverter.ToSingle (BitConverter.GetBytes (ret), 0);
            }
        }

        public float Epsilon {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFloatStruct> (nameof (ParamSpecFloatStruct.Epsilon));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return BitConverter.ToSingle (BitConverter.GetBytes (ret), 0);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[12];
        }

        public ParamSpecFloat (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecFloat (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_float (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            float min,
            float max,
            float defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_float (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
