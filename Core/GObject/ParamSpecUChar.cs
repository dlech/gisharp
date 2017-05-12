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
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

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

            public SafeHandle (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }

            public SafeHandle ()
            {
            }
        }

        public new SafeHandle Handle => (SafeHandle)base.Handle;

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

        public ParamSpecUChar (SafeHandle handle) : base (handle)
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

        static SafeHandle New (string name, string nick, string blurb, byte min, byte max, byte defaultValue, ParamFlags flags)
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
            var ret = new SafeHandle (ret_, Transfer.None);

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
