using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType ("GParamUInt64", IsWrappedNativeType = true)]
    sealed class ParamSpecUInt64 : ParamSpec
    {
        struct ParamSpecUInt64Struct
        {
            public ParamSpecStruct ParentInstance;
            public ulong Minimum;
            public ulong Maximum;
            public ulong DefaultValue;
        }

        public ulong Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUInt64Struct> (nameof (ParamSpecUInt64Struct.Minimum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return (ulong)ret;
            }
        }

        public ulong Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUInt64Struct> (nameof (ParamSpecUInt64Struct.Maximum));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return (ulong)ret;
            }
        }

        public new ulong DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUInt64Struct> (nameof (ParamSpecUInt64Struct.DefaultValue));
                var ret = Marshal.ReadInt64 (Handle, (int)offset);
                return (ulong)ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[8];
        }

        ParamSpecUInt64 (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUInt64 (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint64 (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ulong min,
            ulong max,
            ulong defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_uint64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
