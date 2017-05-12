using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for float properties.
    /// </summary>
    [GType ("GParamFloat", IsWrappedNativeType = true)]
    public sealed class ParamSpecFloat : ParamSpec
    {
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            struct ParamSpecFloat
            {
#pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public float Minimum;
                public float Maximum;
                public float DefaultValue;
                public float Epsilon;
#pragma warning restore CS0649
            }

            public float Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFloat> (nameof (ParamSpecFloat.Minimum));
                    var ret = Marshal.PtrToStructure<float> (handle + (int)offset);
                    return ret;
                }
            }

            public float Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFloat> (nameof (ParamSpecFloat.Maximum));
                    var ret = Marshal.PtrToStructure<float> (handle + (int)offset);
                    return ret;
                }
            }

            public float DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFloat> (nameof (ParamSpecFloat.DefaultValue));
                    var ret = Marshal.PtrToStructure<float> (handle + (int)offset);
                    return ret;
                }
            }

            public float Epsilon {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFloat> (nameof (ParamSpecFloat.Epsilon));
                    var ret = Marshal.PtrToStructure<float> (handle + (int)offset);
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

        public float Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public float Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new float DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        public float Epsilon {
            get {
                return Handle.Epsilon;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[12];
        }

        public ParamSpecFloat (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_float (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            float min,
            float max,
            float defaultValue,
            ParamFlags flags);

        static SafeHandle New (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_float (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
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

        public ParamSpecFloat (string name, string nick, string blurb, float min, float max, float defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
