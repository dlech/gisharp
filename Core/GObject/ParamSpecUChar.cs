using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamUChar", IsWrappedNativeType = true)]
    public sealed class ParamSpecUChar : ParamSpec
    {
        public sealed class SafeParamSpecUCharHandle : SafeParamSpecHandle
        {
            struct ParamSpecUChar
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public byte Minimum;
                public byte Maximum;
                public byte DefaultValue;
                #pragma warning restore CS0649
            }

            public byte Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUChar> (nameof (ParamSpecUChar.Minimum));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return ret;
                }
            }

            public byte Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUChar> (nameof (ParamSpecUChar.Maximum));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return ret;
                }
            }

            public byte DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUChar> (nameof (ParamSpecUChar.DefaultValue));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecUCharHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecUCharHandle Handle {
            get {
                return (SafeParamSpecUCharHandle)base.Handle;
            }
        }

        public byte Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public byte Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new byte DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[1];
        }

        public ParamSpecUChar (SafeParamSpecUCharHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uchar (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            byte min,
            byte max,
            byte defaultValue,
            ParamFlags flags);

        static SafeParamSpecUCharHandle New (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_uchar (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecUCharHandle (ret_, Transfer.Full);

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

            return ret;
        }

        public ParamSpecUChar (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
