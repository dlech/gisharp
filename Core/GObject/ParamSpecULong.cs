using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamULong", IsWrappedNativeType = true)]
    public sealed class ParamSpecULong : ParamSpec
    {
        public sealed class SafeParamSpecULongHandle : SafeParamSpecHandle
        {
            struct ParamSpecULong
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public nulong Minimum;
                public nulong Maximum;
                public nulong DefaultValue;
                #pragma warning restore CS0649
            }

            public nulong Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecULong> (nameof (ParamSpecULong.Minimum));
                    var ret = Marshal.PtrToStructure<nulong> (handle + (int)offset);
                    return ret;
                }
            }

            public nulong Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecULong> (nameof (ParamSpecULong.Maximum));
                    var ret = Marshal.PtrToStructure<nulong> (handle + (int)offset);
                    return ret;
                }
            }

            public nulong DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecULong> (nameof (ParamSpecULong.DefaultValue));
                    var ret = Marshal.PtrToStructure<nulong> (handle + (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecULongHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecULongHandle Handle {
            get {
                return (SafeParamSpecULongHandle)base.Handle;
            }
        }

        public nulong Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public nulong Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new nulong DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[6];
        }

        public ParamSpecULong (SafeParamSpecULongHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_ulong (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nulong min,
            nulong max,
            nulong defaultValue,
            ParamFlags flags);

        static SafeParamSpecULongHandle New (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_ulong (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecULongHandle (ret_, Transfer.Full);

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

        public ParamSpecULong (string name, string nick, string blurb, nulong min, nulong max, nulong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
