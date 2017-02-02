using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{

    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for character properties.
    /// </summary>
    [GType ("GParamChar", IsWrappedNativeType = true)]
    public sealed class ParamSpecChar : ParamSpec
    {
        public sealed class SafeParamSpecCharHandle : SafeParamSpecHandle
        {
            struct ParamSpecChar
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public sbyte Minimum;
                public sbyte Maximum;
                public sbyte DefaultValue;
                #pragma warning restore CS0649
            }

            public sbyte Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecChar> (nameof (ParamSpecChar.Minimum));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return (sbyte)ret;
                }
            }

            public sbyte Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecChar> (nameof (ParamSpecChar.Maximum));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return (sbyte)ret;
                }
            }

            public sbyte DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecChar> (nameof (ParamSpecChar.DefaultValue));
                    var ret = Marshal.ReadByte (handle, (int)offset);
                    return (sbyte)ret;
                }
            }

            public SafeParamSpecCharHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecCharHandle Handle {
            get {
                return (SafeParamSpecCharHandle)base.Handle;
            }
        }

        public sbyte Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public sbyte Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new sbyte DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[0];
        }

        public ParamSpecChar (SafeParamSpecCharHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_char (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            sbyte min,
            sbyte max,
            sbyte defaultValue,
            ParamFlags flags);

        static SafeParamSpecCharHandle New (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_char (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecCharHandle (ret_, Transfer.Full);

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
        public ParamSpecChar (string name, string nick, string blurb, sbyte min, sbyte max, sbyte defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
