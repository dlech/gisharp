using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for double properties.
    /// </summary>
    [GType ("GParamDouble", IsWrappedNativeType = true)]
    public sealed class ParamSpecDouble : ParamSpec
    {
        public sealed new class SafeHandle : ParamSpec.SafeHandle
        {
            public static new SafeHandle Zero = _Zero.Value;
            static Lazy<SafeHandle> _Zero = new Lazy<SafeHandle> (() => new SafeHandle ());

            struct ParamSpecDouble
            {
#pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public double Minimum;
                public double Maximum;
                public double DefaultValue;
                public double Epsilon;
#pragma warning restore CS0649
            }

            public double Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecDouble> (nameof (ParamSpecDouble.Minimum));
                    var ret = Marshal.PtrToStructure<double> (handle + (int)offset);
                    return ret;
                }
            }

            public double Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecDouble> (nameof (ParamSpecDouble.Maximum));
                    var ret = Marshal.PtrToStructure<double> (handle + (int)offset);
                    return ret;
                }
            }

            public double DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecDouble> (nameof (ParamSpecDouble.DefaultValue));
                    var ret = Marshal.PtrToStructure<double> (handle + (int)offset);
                    return ret;
                }
            }

            public double Epsilon {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecDouble> (nameof (ParamSpecDouble.Epsilon));
                    var ret = Marshal.PtrToStructure<double> (handle + (int)offset);
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

        public double Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public double Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new double DefaultValue {
            get {
                return Handle.DefaultValue;
            }
        }

        public double Epsilon {
            get {
                return Handle.Epsilon;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[13];
        }

        public ParamSpecDouble (SafeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_double (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            double min,
            double max,
            double defaultValue,
            ParamFlags flags);

        static SafeHandle New (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_double (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
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

        public ParamSpecDouble (string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
