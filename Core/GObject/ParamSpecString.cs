using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for string properties.
    /// </summary>
    [GType ("GParamString", IsWrappedNativeType = true)]
    public sealed class ParamSpecString : ParamSpec
    {
        public sealed class SafeParamSpecStringHandle : SafeParamSpecHandle
        {
            struct ParamSpecString
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public IntPtr DefaultValue;
                public IntPtr CsetFirst;
                public IntPtr CsetNth;
                public sbyte Substitutor;
                public uint Bitfield;
                #pragma warning restore CS0649
            }

            public IntPtr DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecString> (nameof (ParamSpecString.DefaultValue));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public IntPtr CsetFirst {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecString> (nameof (ParamSpecString.CsetFirst));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public IntPtr CsetNth {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecString> (nameof (ParamSpecString.CsetNth));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public sbyte Substitutor {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecString> (nameof (ParamSpecString.Substitutor));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return (sbyte)ret;
                }
            }

            public uint Bitfield {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecString> (nameof (ParamSpecString.Bitfield));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public SafeParamSpecStringHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecStringHandle Handle {
            get {
                return (SafeParamSpecStringHandle)base.Handle;
            }
        }

        public new string DefaultValue {
            get {
                var ret_ = Handle.DefaultValue;
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public string CsetFirst {
            get {
                var ret_ = Handle.CsetFirst;
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public string CsetNth {
            get {
                var ret_ = Handle.CsetNth;
                var ret = GMarshal.Utf8PtrToString (ret_);
                return ret;
            }
        }

        public sbyte Substitutor {
            get {
                return Handle.Substitutor;
            }
        }

        public bool NullFoldIfEmpty {
            get {
                var ret = Convert.ToBoolean (Handle.Bitfield & 0x1);
                return ret;
            }
        }

        public bool EnsureNonNull {
            get {
                var ret = Convert.ToBoolean (Handle.Bitfield & 0x2);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[14];
        }

        public ParamSpecString (SafeParamSpecStringHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_string (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            IntPtr defaultValue,
            ParamFlags flags);

        static SafeParamSpecStringHandle New (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_string (namePtr, nickPtr, blurbPtr, defaultValuePtr, flags);
            var ret = new SafeParamSpecStringHandle (ret_, Transfer.Full);

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

            return ret;
        }

        public ParamSpecString (string name, string nick, string blurb, string defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, defaultValue, flags))
        {
        }
    }
}
