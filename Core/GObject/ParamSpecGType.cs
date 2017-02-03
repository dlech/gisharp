using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data
    /// for <see cref="GType"/> properties.
    /// </summary>
    [Since ("2.10")]
    [GType ("GParamGType", IsWrappedNativeType = true)]
    public sealed class ParamSpecGType : ParamSpec
    {
        public sealed class SafeParamSpecGTypeHandle : SafeParamSpecHandle
        {
            struct ParamSpecGType
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public GType IsAType;
                #pragma warning restore CS0649
            }

            public GType IsAType {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecGType> (nameof (ParamSpecGType.IsAType));
                    var ret = Marshal.PtrToStructure<GType> (handle + (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecGTypeHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecGTypeHandle Handle {
            get {
                return (SafeParamSpecGTypeHandle)base.Handle;
            }
        }

        public GType IsAType {
            get {
                return Handle.IsAType;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[21];
        }

        public ParamSpecGType (SafeParamSpecGTypeHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_gtype (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType isAType,
            ParamFlags flags);

        static SafeParamSpecGTypeHandle New (string name, string nick, string blurb, GType isAType, ParamFlags flags)
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
            var ret_ = g_param_spec_gtype (namePtr, nickPtr, blurbPtr, isAType, flags);
            var ret = new SafeParamSpecGTypeHandle (ret_, Transfer.None);

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

        public ParamSpecGType (string name, string nick, string blurb, GType isAType, ParamFlags flags)
            : this (New (name, nick, blurb, isAType, flags))
        {
        }
    }
}
