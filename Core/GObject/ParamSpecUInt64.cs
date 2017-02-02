using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType ("GParamUInt64", IsWrappedNativeType = true)]
    public sealed class ParamSpecUInt64 : ParamSpec
    {
        public sealed class SafeParamSpecUInt64Handle : SafeParamSpecHandle
        {
            struct ParamSpecUInt64
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public ulong Minimum;
                public ulong Maximum;
                public ulong DefaultValue;
                #pragma warning restore CS0649
            }

            public ulong Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt64> (nameof (ParamSpecUInt64.Minimum));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return (ulong)ret;
                }
            }

            public ulong Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt64> (nameof (ParamSpecUInt64.Maximum));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return (ulong)ret;
                }
            }

            public ulong DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt64> (nameof (ParamSpecUInt64.DefaultValue));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return (ulong)ret;
                }
            }

            public SafeParamSpecUInt64Handle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecUInt64Handle Handle {
            get {
                return (SafeParamSpecUInt64Handle)base.Handle;
            }
        }

        public ulong Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public ulong Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new ulong DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[8];
        }

        public ParamSpecUInt64 (SafeParamSpecUInt64Handle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint64 (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            ulong min,
            ulong max,
            ulong defaultValue,
            ParamFlags flags);

        static SafeParamSpecUInt64Handle New (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_uint64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecUInt64Handle (ret_, Transfer.Full);

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

        public ParamSpecUInt64 (string name, string nick, string blurb, ulong min, ulong max, ulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
