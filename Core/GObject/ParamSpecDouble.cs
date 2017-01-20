using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for double properties.
    /// </summary>
    [GType ("GParamDouble", IsWrappedNativeType = true)]
    sealed class ParamSpecDouble : ParamSpec
    {
        struct ParamSpecDoubleStruct
        {
            public ParamSpecStruct ParentInstance;
            public double Minimum;
            public double Maximum;
            public double DefaultValue;
            public double Epsilon;
        }

        public double Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecDoubleStruct> (nameof (ParamSpecDoubleStruct.Minimum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return BitConverter.ToDouble (BitConverter.GetBytes (ret), 0);
            }
        }

        public double Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecDoubleStruct> (nameof (ParamSpecDoubleStruct.Maximum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return BitConverter.ToDouble (BitConverter.GetBytes (ret), 0);
            }
        }

        public new double DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecDoubleStruct> (nameof (ParamSpecDoubleStruct.DefaultValue));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return BitConverter.ToDouble (BitConverter.GetBytes (ret), 0);
            }
        }

        public double Epsilon {
            get {
                var offset = Marshal.OffsetOf<ParamSpecDoubleStruct> (nameof (ParamSpecDoubleStruct.Epsilon));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return BitConverter.ToDouble (BitConverter.GetBytes (ret), 0);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[13];
        }

        ParamSpecDouble (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecDouble (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_double (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            double min,
            double max,
            double defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_double (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
