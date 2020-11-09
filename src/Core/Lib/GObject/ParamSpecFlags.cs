using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for flags
    /// properties.
    /// </summary>
    [GType("GParamFlags", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecFlags : ParamSpec
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            public ParamSpec.UnmanagedStruct ParentInstance;
            public IntPtr FlagsClass;
            public int DefaultValue;
#pragma warning restore CS0649
        }

        public unsafe IntPtr FlagsClass => ((UnmanagedStruct*)Handle)->FlagsClass;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new System.Enum DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)Handle)->DefaultValue;
                var ret = (System.Enum)System.Enum.ToObject(FlagsType, ret_);
                return ret;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecFlags(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public Type FlagsType {
            get {
                var type = Marshal.PtrToStructure<GType>(FlagsClass);
                return type.ToType();
            }
        }

        static readonly GType _GType = paramSpecTypes[11];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_flags(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType flagsType,
            int defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, GType flagsType, int defaultValue, ParamFlags flags)
        {
            if (!flagsType.IsA(GType.Flags)) {
                throw new ArgumentException("Expecting an enum type", nameof(flagsType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_flags(namePtr, nickPtr, blurbPtr, flagsType, defaultValue, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(namePtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nickPtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurbPtr);
            }

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecFlags"/> instance specifying a
        /// <see cref="GType.Flags"/> property.
        /// </summary>
        public ParamSpecFlags(string name, string nick, string blurb, GType flagsType, System.Enum defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, flagsType, Convert.ToInt32(defaultValue), flags), Transfer.None)
        {
        }
    }
}
