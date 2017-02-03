using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for enum
    /// properties.
    /// </summary>
    [GType ("GParamEnum", IsWrappedNativeType = true)]
    public sealed class ParamSpecEnum : ParamSpec
    {
        public sealed class SafeParamSpecEnumHandle : SafeParamSpecHandle
        {
            struct ParamSpecEnum
            {
                #pragma warning disable CS0649
                public ParamSpecStruct ParentInstance;
                public IntPtr EnumClass;
                public int DefaultValue;
                #pragma warning restore CS0649
            }

            public IntPtr EnumClass {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecEnum> (nameof (ParamSpecEnum.EnumClass));
                    var ret = Marshal.ReadIntPtr (handle, (int)offset);
                    return ret;
                }
            }

            public int DefaultValue {
                get {
                    if (IsClosed) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<ParamSpecEnum> (nameof (ParamSpecEnum.DefaultValue));
                    var ret = Marshal.ReadInt32 (handle, (int)offset);
                    return ret;
                }
            }

            public SafeParamSpecEnumHandle (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        public new SafeParamSpecEnumHandle Handle {
            get {
                return (SafeParamSpecEnumHandle)base.Handle;
            }
        }

        public Type EnumType {
            get {
                var type = Marshal.PtrToStructure<GType> (Handle.EnumClass);
                return GType.TypeOf (type);
            }
        }

        public new System.Enum DefaultValue {
            get {
                var ret_ = Handle.DefaultValue;
                var ret = (System.Enum)System.Enum.ToObject (EnumType, ret_);
                return ret;
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[10];
        }

        public ParamSpecEnum (SafeParamSpecEnumHandle handle) : base (handle)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_enum (
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType enumType,
            int defaultValue,
            ParamFlags flags);

        static SafeParamSpecEnumHandle New (string name, string nick, string blurb, GType enumType, int defaultValue, ParamFlags flags)
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
            if (!enumType.IsA (GType.Enum)) {
                throw new ArgumentException ("Expecting an enum type", nameof (enumType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr (name);
            var nickPtr = GMarshal.StringToUtf8Ptr (nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr (blurb);
            var ret_ = g_param_spec_enum (namePtr, nickPtr, blurbPtr, enumType, defaultValue, flags);
            var ret = new SafeParamSpecEnumHandle (ret_, Transfer.None);

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

        public ParamSpecEnum (string name, string nick, string blurb, GType enumType, System.Enum defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, enumType, Convert.ToInt32 (defaultValue), flags))
        {
        }
    }
}
