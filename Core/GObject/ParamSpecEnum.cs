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
        static readonly IntPtr enumClassOffset = Marshal.OffsetOf<Struct> (nameof (Struct.EnumClass));
        static readonly IntPtr defaultValueOffset = Marshal.OffsetOf<Struct> (nameof (Struct.DefaultValue));

        new struct Struct
        {
#pragma warning disable CS0649
            public ParamSpec.Struct ParentInstance;
            public IntPtr EnumClass;
            public int DefaultValue;
#pragma warning restore CS0649
        }

        IntPtr EnumClass {
            get {
                AssertNotDisposed ();
                var ret = Marshal.ReadIntPtr (Handle, (int)enumClassOffset);
                return ret;
            }
        }

        public new System.Enum DefaultValue {
            get {
                AssertNotDisposed ();
                var ret_ = Marshal.ReadInt32 (Handle, (int)defaultValueOffset);
                var ret = (System.Enum)System.Enum.ToObject (EnumType, ret_);
                return ret;
            }
        }

        public ParamSpecEnum (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public Type EnumType {
            get {
                var type = Marshal.PtrToStructure<GType> (EnumClass);
                return GType.TypeOf (type);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[10];
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_enum (
            IntPtr name,
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
            var ret = g_param_spec_enum (namePtr, nickPtr, blurbPtr, enumType, defaultValue, flags);

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
            : this (New (name, nick, blurb, enumType, Convert.ToInt32 (defaultValue), flags), Transfer.None)
        {
        }
    }
}
