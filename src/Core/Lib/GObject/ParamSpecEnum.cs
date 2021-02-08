// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for enum
    /// properties.
    /// </summary>
    [GType("GParamEnum", IsProxyForUnmanagedType = true)]
    public sealed unsafe class ParamSpecEnum : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecEnum"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// the GEnumClass for the enum
            /// </summary>
            public EnumClass.UnmanagedStruct* EnumClass;

            /// <summary>
            /// default value for the property specified
            /// </summary>
            public int DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// the <see cref="EnumClass"/> for the enum
        /// </summary>
        public EnumClass EnumClass =>
            Opaque.GetInstance<EnumClass>((IntPtr)((UnmanagedStruct*)UnsafeHandle)->EnumClass, Transfer.None);

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new System.Enum DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;
                var gType = ((UnmanagedStruct*)UnsafeHandle)->EnumClass->GTypeClass.GType;
                var ret = (System.Enum)System.Enum.ToObject(gType.ToType(), ret_);
                return ret;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecEnum(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[10];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_enum(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType enumType,
            int defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, GType enumType, int defaultValue, ParamFlags flags)
        {
            if (!enumType.IsA(GType.Enum)) {
                throw new ArgumentException("Expecting an enum type", nameof(enumType));
            }
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_enum(namePtr, nickPtr, blurbPtr, enumType, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecEnum"/> instance specifying a
        /// <see cref="GType.Enum"/> property.
        /// </summary>
        public ParamSpecEnum(string name, string nick, string blurb, GType enumType, System.Enum defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, enumType, Convert.ToInt32(defaultValue), flags), Transfer.None)
        {
        }
    }
}
