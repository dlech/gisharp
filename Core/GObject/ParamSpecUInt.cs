using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType ("GParamUInt", IsWrappedNativeType = true)]
    public sealed class ParamSpecUInt : ParamSpec
    {
        public sealed class SafeParamSpecUIntHandle : SafeParamSpecHandle
        {
            struct ParamSpecUInt
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public uint Minimum;
                public uint Maximum;
                public uint DefaultValue;
                #pragma warning restore CS0649
            }

            public uint Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt> (nameof (ParamSpecUInt.Minimum));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public uint Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt> (nameof (ParamSpecUInt.Maximum));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public uint DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecUInt> (nameof (ParamSpecUInt.DefaultValue));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return (uint)ret;
                }
            }

            public SafeParamSpecUIntHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecUIntHandle Handle {
            get {
                return (SafeParamSpecUIntHandle)base.Handle;
            }
        }

        public uint Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public uint Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new uint DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[4];
        }

        public ParamSpecUInt (SafeParamSpecUIntHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_uint (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            uint min,
            uint max,
            uint defaultValue,
            ParamFlags flags);

        static SafeParamSpecUIntHandle New (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_uint (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecUIntHandle (ret_, Transfer.Full);

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

        public ParamSpecUInt (string name, string nick, string blurb, uint min, uint max, uint defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
