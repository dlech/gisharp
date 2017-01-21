using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for string properties.
    /// </summary>
    [GType ("GParamString", IsWrappedNativeType = true)]
    sealed class ParamSpecString : ParamSpec
    {
        struct ParamSpecStringStruct
        {
            public ParamSpecStruct ParentInstance;
            public IntPtr DefaultValue;
            public IntPtr CsetFirst;
            public IntPtr CsetNth;
            public sbyte Substitutor;
            public uint Flags;
        }

        public new string DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.DefaultValue));
                var ret_ = Marshal.ReadIntPtr (Handle, (int)offset);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public string CsetFirst {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.CsetFirst));
                var ret_ = Marshal.ReadIntPtr (Handle, (int)offset);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public string CsetNth {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.CsetNth));
                var ret_ = Marshal.ReadIntPtr (Handle, (int)offset);
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public sbyte Substitutor {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.Substitutor));
                var ret = Marshal.ReadByte (Handle, (int)offset);
                return (sbyte)ret;
            }
        }

        public bool NullFoldIfEmpty {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.Flags));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return Convert.ToBoolean (ret & 0x1);
            }
        }

        public bool EnsureNonNull {
            get {
                var offset = Marshal.OffsetOf<ParamSpecStringStruct> (nameof (ParamSpecStringStruct.Flags));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return Convert.ToBoolean (ret & 0x2);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[14];
        }

        ParamSpecString (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecString (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_string (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
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
            var defaultValuePtr = GMarshal.StringToUtf8Ptr (defaultValue);
            var pspecPtr = g_param_spec_string (namePtr, nickPtr, blurbPtr, defaultValuePtr, flags);

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
            GMarshal.Free (defaultValuePtr);

            return pspecPtr;
        }
    }
}
