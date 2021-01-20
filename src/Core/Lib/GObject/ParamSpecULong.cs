// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

using culong = GISharp.Runtime.CULong;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for long integer properties.
    /// </summary>
    [GType("GParamULong", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecULong : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecULong"/>.
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
            /// minimum value for the property specified
            /// </summary>
            public culong Minimum;

            /// <summary>
            /// maximum value for the property specified
            /// </summary>
            public culong Maximum;

            /// <summary>
            /// maximum value for the property specified
            /// </summary>
            public culong DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public unsafe culong Minimum => ((UnmanagedStruct*)Handle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public unsafe culong Maximum => ((UnmanagedStruct*)Handle)->Maximum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public unsafe new culong DefaultValue => ((UnmanagedStruct*)Handle)->DefaultValue;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecULong(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[6];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_ulong(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            culong min,
            culong max,
            culong defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, culong min, culong max, culong defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_ulong(namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

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
        /// Creates a new <see cref="ParamSpecULong"/> instance specifying a
        /// <see cref="GType.ULong"/> property.
        /// </summary>
        public ParamSpecULong(string name, string nick, string blurb, culong min, culong max, culong defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
