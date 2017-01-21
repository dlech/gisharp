using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType ("GParamUInt", IsWrappedNativeType = true)]
    sealed class ParamSpecUInt : ParamSpec
    {
        struct ParamSpecUIntStruct
        {
            public ParamSpecStruct ParentInstance;
            public uint Minimum;
            public uint Maximum;
            public uint DefaultValue;
        }

        public uint Minimum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUIntStruct> (nameof (ParamSpecUIntStruct.Minimum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return (uint)ret;
            }
        }

        public uint Maximum {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUIntStruct> (nameof (ParamSpecUIntStruct.Maximum));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return (uint)ret;
            }
        }

        public new uint DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecUIntStruct> (nameof (ParamSpecUIntStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return (uint)ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[4];
        }

        ParamSpecUInt (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecUInt (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint min,
            uint max,
            uint defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_uint (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
