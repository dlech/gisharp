using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for flags
    /// properties.
    /// </summary>
    [GType ("GParamFlags", IsWrappedNativeType = true)]
    public sealed class ParamSpecFlags : ParamSpec
    {
        public sealed class SafeParamSpecFlagsHandle : SafeParamSpecHandle
        {
            struct ParamSpecFlags
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public IntPtr FlagsClass;
                public int DefaultValue;
                #pragma warning restore CS0649
            }

            public IntPtr FlagsClass {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFlags> (nameof (ParamSpecFlags.FlagsClass));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public int DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecFlags> (nameof (ParamSpecFlags.DefaultValue));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecFlagsHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecFlagsHandle Handle {
            get {
                return (SafeParamSpecFlagsHandle)base.Handle;
            }
        }

        public Type FlagsType {
            get {
                var type = Marshal.PtrToStructure<GType> (Handle.FlagsClass);
                return GType.TypeOf (type);
            }
        }

        public new System.Enum DefaultValue {
            get {
                var ret_ = Handle.DefaultValue;
                var ret = (System.Enum)System.Enum.ToObject (FlagsType, ret_);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[11];
        }

        public ParamSpecFlags (SafeParamSpecFlagsHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_flags (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType flagsType,
            int defaultValue,
            ParamFlags flags);

        static SafeParamSpecFlagsHandle New (string name, string nick, string blurb, GType flagsType, int defaultValue, ParamFlags flags)
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
            if (!flagsType.IsA (GType.Flags)) {
                throw new ArgumentException ("Expecting an enum type", nameof (flagsType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret_ = g_param_spec_flags (namePtr, nickPtr, blurbPtr, flagsType, defaultValue, flags);
            var ret = new SafeParamSpecFlagsHandle (ret_, Transfer.None);

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

        public ParamSpecFlags (string name, string nick, string blurb, GType flagsType, System.Enum defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, flagsType, Convert.ToInt32 (defaultValue), flags))
        {
        }
    }
}
