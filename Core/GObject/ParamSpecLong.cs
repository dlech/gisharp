using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using nlong = GISharp.Runtime.NativeLong;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType ("GParamLong", IsWrappedNativeType = true)]
    public sealed class ParamSpecLong : ParamSpec
    {
        public sealed class SafeParamSpecLongHandle : SafeParamSpecHandle
        {
            struct ParamSpecLong
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public nlong Minimum;
                public nlong Maximum;
                public nlong DefaultValue;
                #pragma warning restore CS0649
            }

            public nlong Minimum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecLong> (nameof (ParamSpecLong.Minimum));
                    var ret = Marshal.PtrToStructure<nlong> (handle + (int)offset);
                    return ret;
                }
            }

            public nlong Maximum {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecLong> (nameof (ParamSpecLong.Maximum));
                    var ret = Marshal.PtrToStructure<nlong> (handle + (int)offset);
                    return ret;
                }
            }

            public nlong DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecLong> (nameof (ParamSpecLong.DefaultValue));
                    var ret = Marshal.PtrToStructure<nlong> (handle + (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecLongHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecLongHandle Handle {
            get {
                return (SafeParamSpecLongHandle)base.Handle;
            }
        }

        public nlong Minimum {
            get {
                return Handle.Minimum;
            }
        }

        public nlong Maximum {
            get {
                return Handle.Maximum;
            }
        }

        public new nlong DefaultValue {
            get {
               return Handle.DefaultValue;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[5];
        }

        public ParamSpecLong (SafeParamSpecLongHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_long (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            nlong min,
            nlong max,
            nlong defaultValue,
            ParamFlags flags);

        static SafeParamSpecLongHandle New (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
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
            var ret_ = g_param_spec_long (namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);
            var ret = new SafeParamSpecLongHandle (ret_, Transfer.None);

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

        public ParamSpecLong (string name, string nick, string blurb, nlong min, nlong max, nlong defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, min, max, defaultValue, flags))
        {
        }
    }
}
