using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType ("GParamInt", IsWrappedNativeType = true)]
    sealed class ParamSpecInt : ParamSpec
    {
        struct ParamSpecIntStruct
        {
            public ParamSpecStruct ParentInstance;
            public int Minimum;
            public int Maximum;
            public int DefaultValue;
        }

        public int Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecIntStruct> (nameof (ParamSpecIntStruct.Minimum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return ret;
            }
        }

        public int Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecIntStruct> (nameof (ParamSpecIntStruct.Maximum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return ret;
            }
        }

        public new int DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecIntStruct> (nameof (ParamSpecIntStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[3];
        }

        ParamSpecInt (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecInt (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            int min,
            int max,
            int defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_int (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
