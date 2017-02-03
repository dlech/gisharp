using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for 64bit integer properties.
    /// </summary>
    [GType ("GParamInt64", IsWrappedNativeType = true)]
    public sealed class ParamSpecInt64 : ParamSpec
    {
        public sealed class SafeParamSpecInt64Handle : SafeParamSpecHandle
        {
            struct ParamSpecInt64
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
                    var offset = Marshal.OffsetOf<ParamSpecInt64> (nameof (ParamSpecInt64.Minimum));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return ret;
                }
            }

            public long Maximum {
                get {
                    var offset = Marshal.OffsetOf<ParamSpecInt64> (nameof (ParamSpecInt64.Maximum));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return ret;
                }
            }

            public long DefaultValue {
                get {
                    var offset = Marshal.OffsetOf<ParamSpecInt64> (nameof (ParamSpecInt64.DefaultValue));
                    var ret = Marshal.ReadInt64 (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecInt64Handle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecInt64Handle Handle {
            get {
                return (SafeParamSpecInt64Handle)base.Handle;
            }
        }

        public long Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public long Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new long DefaultValue {
            get {
               return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[7];
        }

        public ParamSpecInt64 (SafeParamSpecInt64Handle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int64 (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            long min,
            long max,
            long defaultValue,
            ParamFlags flags);

        static SafeParamSpecInt64Handle New (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_int64 (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecInt64Handle (ret_, Transfer.None);

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

        public ParamSpecInt64 (string name, string nick, string blurb, long min, long max, long defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
