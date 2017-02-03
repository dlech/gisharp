using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for integer properties.
    /// </summary>
    [GType ("GParamInt", IsWrappedNativeType = true)]
    public sealed class ParamSpecInt : ParamSpec
    {
        public sealed class SafeParamSpecIntHandle : SafeParamSpecHandle
        {
            struct ParamSpecInt
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public int Minimum;
                public int Maximum;
                public int DefaultValue;
                #pragma warning restore CS0649
            }

            public int Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecInt> (nameof (ParamSpecInt.Minimum));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public int Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecInt> (nameof (ParamSpecInt.Maximum));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public int DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecInt> (nameof (ParamSpecInt.DefaultValue));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecIntHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecIntHandle Handle {
            get {
                return (SafeParamSpecIntHandle)base.Handle;
            }
        }

        public int Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public int Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new int DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[3];
        }

        public ParamSpecInt (SafeParamSpecIntHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_int (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            int min,
            int max,
            int defaultValue,
            ParamFlags flags);

        static SafeParamSpecIntHandle New (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_int (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecIntHandle (ret_, Transfer.None);

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

        public ParamSpecInt (string name, string nick, string blurb, int min, int max, int defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
