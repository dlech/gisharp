using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType ("GParamInt64", IsWrappedNativeType = true)]
    sealed class ParamSpecInt64 : ParamSpec
    {
        struct ParamSpecInt64Struct
        {
            #pragma warning disable CS0649
            public ParamSpecStruct ParentInstance;
            public long Minimum;
            public long Maximum;
            public long DefaultValue;
            #pragma warning restore CS0649
        }

        public long Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecInt64Struct> (nameof (ParamSpecInt64Struct.Minimum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return ret;
            }
        }

        public long Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecInt64Struct> (nameof (ParamSpecInt64Struct.Maximum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return ret;
            }
        }

        public new long DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecInt64Struct> (nameof (ParamSpecInt64Struct.DefaultValue));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[7];
        }

        public ParamSpecInt64 (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecInt64 (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int64 (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            long min,
            long max,
            long defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_int64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
