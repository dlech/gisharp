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
    sealed class ParamSpecEnum : ParamSpec
    {
        struct ParamSpecEnumStruct
        {
            public ParamSpecStruct ParentInstance;
            public IntPtr EnumClass;
            public int DefaultValue;
        }

        public EnumClass EnumClass {
            get {
                var offset = Marshal.OffsetOf<ParamSpecEnumStruct> (nameof (ParamSpecEnumStruct.EnumClass));
                var ret = Marshal.ReadIntPtr (Handle, (int)offset);
                return (EnumClass)GTypeStruct.CreateInstance (ret, false);
            }
        }

        public Type EnumType {
            get {
                return GType.TypeOf (EnumClass.GType);
            }
        }

        public new System.Enum DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecEnumStruct> (nameof (ParamSpecEnumStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return (System.Enum)System.Enum.ToObject (EnumType, ret);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[10];
        }

        ParamSpecEnum (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecEnum (string name, string nick, string blurb, GType enumType, System.Enum defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, enumType, Convert.ToInt32 (defaultValue), flags), Transfer.All)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_enum (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType enumType,
            int defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, GType enumType, int defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_enum (namePtr, nickPtr, blurbPtr, enumType, defaultValue, flags);

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

            return pspecPtr;
        }
    }
}
