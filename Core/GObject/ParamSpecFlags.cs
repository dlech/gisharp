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
    sealed class ParamSpecFlags : ParamSpec
    {
        struct ParamSpecFlagsStruct
        {
            public ParamSpecStruct ParentInstance;
            public IntPtr FlagsClass;
            public int DefaultValue;
        }

        public FlagsClass FlagsClass {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFlagsStruct> (nameof (ParamSpecFlagsStruct.FlagsClass));
                var ret = Marshal.ReadIntPtr (Handle, (int)offset);
                return (FlagsClass)GTypeStruct.CreateInstance (ret, false);
            }
        }

        public Type FlagsType {
            get {
                return GType.TypeOf (FlagsClass.GType);
            }
        }

        public new System.Enum DefaultValue {
            get {
                var offset = Marshal.OffsetOf<ParamSpecFlagsStruct> (nameof (ParamSpecFlagsStruct.DefaultValue));
                var ret = Marshal.ReadInt32 (Handle, (int)offset);
                return (System.Enum)System.Enum.ToObject (FlagsType, ret);
            }
        }

        static GType getGType ()
        {
            return paramSpecTypes[11];
        }

        ParamSpecFlags (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }

        public ParamSpecFlags (string name, string nick, string blurb, GType flagsType, System.Enum defaultValue, ParamFlags flags)
            : this (New (name, nick, blurb, flagsType, Convert.ToInt32 (defaultValue), flags), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_flags (IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType flagsType,
            int defaultValue,
            ParamFlags flags);

        static IntPtr New (string name, string nick, string blurb, GType flagsType, int defaultValue, ParamFlags flags)
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
            var pspecPtr = g_param_spec_flags (namePtr, nickPtr, blurbPtr, flagsType, defaultValue, flags);

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
