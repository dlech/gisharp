// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data
    /// for <see cref="GType"/> properties.
    /// </summary>
    [Since("2.10")]
    [GType("GParamGType", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecGType : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecGType"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// a GType whose subtypes can occur as values
            /// </summary>
            public GType IsAType;
#pragma warning restore CS0649
        }

        /// <summary>
        /// a <see cref="GType"/> whose subtypes can occur as values
        /// </summary>
        public unsafe GType IsAType => ((UnmanagedStruct*)UnsafeHandle)->IsAType;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecGType(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[21];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_gtype(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            GType isAType,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, GType isAType, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_gtype(namePtr, nickPtr, blurbPtr, isAType, flags);

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
        /// Creates a new <see cref="ParamSpecGType"/> instance specifying a
        /// <see cref="GType.Type"/> property.
        /// </summary>
        public ParamSpecGType(string name, string nick, string blurb, GType isAType, ParamFlags flags)
            : this(New(name, nick, blurb, isAType, flags), Transfer.None)
        {
        }
    }
}
